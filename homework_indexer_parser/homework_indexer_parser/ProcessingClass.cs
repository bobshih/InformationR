using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace InformationRetrieval
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

        public string CurrentFile
        {
            get;
            private set;
        }

        #endregion

        private Thread thread;
        private EventWaitHandle suspendEvent = new ManualResetEvent(true);
        private EventWaitHandle abortEvent = new ManualResetEvent(false);

        private string file;
        private DirectoryOrganizer dirorg;

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
        public ProcessingClass(string file, DirectoryOrganizer dirorg)
        {
            this.dirorg = dirorg;
            this.file = file;
            thread = new Thread(ProcessFile);
            Processing = false;
            Pause = false;
            Finish = false;
            Started = false;
            End = false;
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
            try
            {
                var waitGroup = new EventWaitHandle[] { abortEvent, suspendEvent };
                int currentsplitedartical = 0;
                PostMessage(MessageType.NOTICE, "Splitting File");
                int artical_count = warc_spliter.split(file, x => File.WriteAllText(dirorg.GetArticalPath(currentsplitedartical++), x));
                PostMessage(MessageType.NOTICE, "Splitting File Finish");

                PostMessage(MessageType.NOTICE, "Tokenizing File");
                for (int i = 0; i < artical_count; ++i)
                {
                    PostMessage(MessageType.NOTICE, "Tokenizing File " + i.ToString());
                    File.WriteAllLines(dirorg.GetTokenPath(i), html_tokenizer.tokenize(dirorg.GetArticalPath(i)));
                }
                PostMessage(MessageType.NOTICE, "Tokenizing File Finish");

                PostMessage(MessageType.NOTICE, "Indexing File");
                Dictionary<string, List<int>> mainDic = new Dictionary<string, List<int>>();
                for (int i = 0; i < artical_count; ++i)
                {
                    PostMessage(MessageType.NOTICE, "Indexing File " + i.ToString());
                    var dic = indexing.genetrateInvertedIndex(dirorg.GetTokenPath(i));
                    DictionaryAndPostingSerializer.Save(dic, dirorg.GetDictionaryPath(i));
                    foreach (var key in dic.Keys)
                    {
                        List<int> doc;
                        if (mainDic.TryGetValue(key, out doc))
                        {
                            doc.Add(i);
                        }
                        else
                        {
                            mainDic.Add(key, new List<int>(new int[] { i }));
                        }
                    }
                }
                DictionaryAndPostingSerializer.Save(mainDic, dirorg.GetMainDictionaryPath());
                PostMessage(MessageType.NOTICE, "Indexing File Finish");
                /*
                if (EventWaitHandle.WaitAny(waitGroup) == 0)
                {
                    //aborted
                    PostMessage(MessageType.WARNNING, "Progress Abort");
                    UpdateFileProgress();
                    ProcessAbort();
                    return;
                }
                */
                ProcessFinish();
            }
            catch (Exception e)
            {
                PostMessage(MessageType.ERROR, "Something Bad Happened :(");
                PostMessage(MessageType.ERROR, e.Message);
            }
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
            End = true;
        }
    }
}
