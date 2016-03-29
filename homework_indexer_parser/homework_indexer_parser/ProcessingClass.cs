using homework_indexer_parser.DictionaryFolder;
using homework_indexer_parser.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace homework_indexer_parser
{
    class ProcessingClass
    {
        public enum MessageType
        {
            ERROR,
            WARNNING,
            NOTICE
        };
        public event Action<MessageType, string> MessageHandler;
        public event Action<Dictionary> ProcessEndHandler;

        #region Process State Properties

        /// <summary>
        /// Is Processing (Include Pausing)
        /// </summary>
        public bool Processing
        {
            get;
            private set;
        }

        /// <summary>
        /// Is Pauseing
        /// </summary>
        public bool Pause
        {
            get;
            private set;
        }

        /// <summary>
        /// Is Suscessfully Processed
        /// </summary>
        public bool Finish
        {
            get;
            private set;
        }

        /// <summary>
        /// Is Processing Begin Started (Include After Finish)
        /// </summary>
        private bool Started
        {
            get;
            set;
        }

        /// <summary>
        /// Is Processing End (Include Abort And Finish)
        /// </summary>
        public bool End
        {
            get;
            private set;
        }

        #endregion

        private List<string> files;
        private Dictionary dictionary = new Dictionary();
        private Thread thread;
        private EventWaitHandle suspendEvent = new ManualResetEvent(true);
        private EventWaitHandle abortEvent = new ManualResetEvent(false);

        private void PostMessage(MessageType type, string message)
        {
            if (MessageHandler != null)
            {
                Task.Run(() => MessageHandler(type, message));
            }
        }
        private void PostEnd()
        {
            if (ProcessEndHandler != null)
            {
                ProcessEndHandler(dictionary);
            }
        }

        /// <summary>
        /// Initialize Processing Class With File List
        /// </summary>
        /// <param name="filenames">files to process</param>
        public ProcessingClass(List<string> filenames)
        {
            thread = new Thread(ProcessFile);
            files = filenames;
            Processing = false;
            Pause = false;
            Finish = false;
            Started = false;
            End = false;
        }

        ~ProcessingClass()
        {
            Stop();
            thread.Join();
        }

        #region State Controll Functions

        /// <summary>
        /// Start Processing
        /// </summary>
        public void Start()
        {
            if (Started)
                return;
            Started = true;
            Processing = true;
            thread.Start(files);
        }

        /// <summary>
        /// Pause Processing
        /// </summary>
        public void Suspend()
        {
            if (Started)
                return;
            Pause = true;
            suspendEvent.Reset();
        }

        /// <summary>
        /// Resume Processing
        /// </summary>
        public void Resume()
        {
            suspendEvent.Set();
            Pause = false;
        }

        /// <summary>
        /// Abort Processing
        /// </summary>
        public void Stop()
        {
            abortEvent.Set();
        }

        #endregion

        private void ProcessFile(object parameters)
        {
            var waitGroup = new EventWaitHandle[] { abortEvent, suspendEvent };
            List<string> fileNames = parameters as List<string>;
            WARCReader reader = new WARCReader();
            foreach (string file in fileNames)
            {
                if (EventWaitHandle.WaitAny(waitGroup) == 0)
                {
                    //aborted
                    ProcessAbort();
                    return;
                }
                List<string> tokenList;
                try
                {
                    reader.ReadFile(file);
                }
                catch
                {
                    PostMessage(MessageType.ERROR, "Can not parse file " + file);
                    continue;
                }

                while ((tokenList = reader.GetNext()) != null)
                {
                    if (EventWaitHandle.WaitAny(waitGroup) == 0)
                    {
                        //aborted
                        ProcessAbort();
                        return;
                    }
                    //TODO: one word by one to track progress
                    dictionary.AddArticle(tokenList);
                }
            }
            ProcessFinish();
        }

        private void ProcessFinish()
        {
            Processing = false;
            Finish = true;
            End = true;
            PostEnd();
        }

        private void ProcessAbort()
        {
            Processing = false;
            Finish = true;
            End = true;
            PostEnd();
        }
    }
}
