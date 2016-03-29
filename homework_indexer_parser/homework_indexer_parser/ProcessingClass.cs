using homework_indexer_parser.DictionaryFolder;
using homework_indexer_parser.ParserFolder;
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

        public bool Processing
        {
            get;
            private set;
        }
        public bool Pause
        {
            get;
            private set;
        }
        public bool Finish
        {
            get;
            private set;
        }
        private bool Started
        {
            get;
            set;
        }
        public bool End
        {
            get;
            private set;
        }


        private List<string> files;
        private Dictionary dictionary = new Dictionary();
        private Thread thread;
        private AutoResetEvent suspendEvent;
        private AutoResetEvent abortEvent;

        private void PostMessage(MessageType type, string message)
        {
            if (MessageHandler != null)
            {
                Task.Run(() => MessageHandler(type, message));
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

        public ~ProcessingClass()
        {
            Stop();
        }

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

        public void Suspend()
        {
            if (Started)
                return;
            Pause = true;
            suspendEvent.Reset();
        }

        public void Resume()
        {
            suspendEvent.Set();
            Pause = false;
        }

        public void Stop()
        {
            abortEvent.Set();
        }

        private void ProcessFile(object parameters)
        {
            List<string> fileNames = parameters as List<string>;
            WARCReader reader = new WARCReader();
            foreach (string file in fileNames)
            {
                List<string> tokenList;
                try
                {
                    reader.ReadFile(file);
                    tokenList = reader.GetNext();
                }
                catch
                {
                    PostMessage(MessageType.ERROR, "Can not parse file " + file);
                    continue;
                }

                while (!suspendEvent.WaitOne(1000))
                {
                    if (abortEvent.WaitOne(0))
                    {
                        //Abort Requested
                        ProcessAbort();
                        return;
                    }
                }
                //TODO: one word by one to track progress
                dictionary.AddArticle(tokenList);
            }
            ProcessFinish();
        }
        private void ProcessFinish()
        {
            Processing = false;
            Finish = true;
            End = true;
        }
        private void ProcessAbort()
        {
            Processing = false;
            Finish = true;
            End = true;
        }
    }
}
