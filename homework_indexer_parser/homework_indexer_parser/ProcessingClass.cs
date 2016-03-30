using homework_indexer_parser.DictionaryFolder;
using homework_indexer_parser.SimpleParser;
using System;
using System.Collections.Generic;
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


        /// <summary>
        /// Current File Progress (%)
        /// </summary>
        public int Progress
        {
            get;
            private set;
        }

        /// <summary>
        /// Processed File
        /// </summary>
        public int DoneFIlesCount
        {
            get;
            private set;
        }

        #endregion

        private Dictionary dictionary = new Dictionary();
        private Thread thread;
        private EventWaitHandle suspendEvent = new ManualResetEvent(true);
        private EventWaitHandle abortEvent = new ManualResetEvent(false);
        WARCReader reader;

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
        public ProcessingClass(List<string> filenames, PostProcessingChoice choice)
        {
            thread = new Thread(ProcessFile);
            Processing = false;
            Pause = false;
            Finish = false;
            Started = false;
            End = false;
            reader = new WARCReader(choice);
            reader.AddFile(filenames);
            Progress = 0;
            DoneFIlesCount = 0;
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
            thread.Start();
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

        private void ProcessFile()
        {
            var waitGroup = new EventWaitHandle[] { abortEvent, suspendEvent };

            WARC_TOPIC_TOKENS tokenList;
            while ((tokenList = reader.GetNext()) != null)
            {
                Progress = (int)Math.Floor(100 * reader.CurrentFilePosition / (double)reader.CurrentFileSize);
                DoneFIlesCount = reader.ProcessedFileCount;
                this.DoneFIlesCount = reader.ProcessedFileCount;
                if (EventWaitHandle.WaitAny(waitGroup) == 0)
                {
                    //aborted
                    PostMessage(MessageType.WARNNING, "Progress Abort");
                    ProcessAbort();
                    return;
                }
                dictionary.AddArticle(tokenList.tokens);
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
            End = true;
            PostEnd();
        }
    }
}
