using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace InformationRetrieval
{
    class IndexingClass
    {
        public enum MessageType
        {
            ERROR,
            WARNNING,
            NOTICE,
            NOTICE_SMALL
        };
        public event Action<MessageType, string> MessageHandler;
        /// <summary>
        /// param : is finish
        /// </summary>
        public event Action<bool> ProcessEndHandler;

        #region Process State Properties
        private bool Started = false;

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
                MessageHandler(type, message);
            }
        }

        /// <summary>
        /// Initialize Processing Class With File List
        /// </summary>
        /// <param name="filenames">files to process</param>
        public IndexingClass(string file, DirectoryOrganizer dirorg)
        {
            this.dirorg = dirorg;
            this.file = file;
            thread = new Thread(ProcessFile);
        }

        ~IndexingClass()
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
            thread.Start();
        }

        /// <summary>
        /// Pause Processing
        /// </summary>
        public void Suspend()
        {
            if (Started)
                return;
            suspendEvent.Reset();
        }

        /// <summary>
        /// Resume Processing
        /// </summary>
        public void Resume()
        {
            suspendEvent.Set();
        }

        /// <summary>
        /// Abort Processing
        /// </summary>
        public void Stop()
        {
            abortEvent.Set();
        }

        #endregion

        class AbortedException : Exception
        {
            public AbortedException()
                : base("Process Aborted")
            {
            }
        }

        private void ProcessFile()
        {
            try
            {
                var waitGroup = new EventWaitHandle[] { abortEvent, suspendEvent };

                int artical_count = Process_Split(waitGroup);
                Process_Tokenize(waitGroup, artical_count);
                Process_Indexing(waitGroup, artical_count);

                #region DEV
                PostMessage(MessageType.NOTICE, "Weighting ...");
                Dictionary<string, List<int>> mainDic;
                DictionaryAndPostingSerializer.Load(out mainDic, dirorg.GetMainDictionaryPath());
                var dic_idf = indexing.idf(indexing.fetch_df(mainDic), artical_count);
                DictionaryAndPostingSerializer.Save(dic_idf, dirorg.GetInverseDocumentFrequencyPath());
                mainDic = null;
                for (int i = 0; i < artical_count; ++i)
                {
                    if (EventWaitHandle.WaitAny(waitGroup) == 0)
                        throw new AbortedException();
                    PostMessage(MessageType.NOTICE, "Weighting File " + i.ToString());
                    Dictionary<string, List<int>> dic;
                    DictionaryAndPostingSerializer.Load(out dic, dirorg.GetDictionaryPath(i));
                    var tfidf = indexing.tfidf(indexing.weighted_tf(indexing.fetch_tf(dic)), dic_idf);
                    tfidf = indexing.normalize_tfidf(tfidf);
                    DictionaryAndPostingSerializer.Save(tfidf, dirorg.GetNormalizedWeightVectorPath(i));
                }
                PostMessage(MessageType.NOTICE, "Weighting Finish");



                #endregion

            }
            catch (NotImplementedException)
            {
                throw;
            }
            catch (AbortedException)
            {
                PostMessage(MessageType.WARNNING, "Progress Abort");
                throw;
            }
            catch (Exception e)
            {
                PostMessage(MessageType.ERROR, "Something Bad Happened :(");
                PostMessage(MessageType.ERROR, e.Message);
                if (ProcessEndHandler != null)
                {
                    ProcessEndHandler(false);
                }
            }
            if (ProcessEndHandler != null)
            {
                ProcessEndHandler(true);
            }
        }

        #region process detail
        private void Process_Indexing(EventWaitHandle[] waitGroup, int artical_count)
        {
            PostMessage(MessageType.NOTICE, "Indexing File ...");
            Dictionary<string, List<int>> mainDic = new Dictionary<string, List<int>>();
            for (int i = 0; i < artical_count; ++i)
            {
                if (EventWaitHandle.WaitAny(waitGroup) == 0)
                    throw new AbortedException();
                PostMessage(MessageType.NOTICE_SMALL, "Indexing File " + i.ToString());
                var dic = indexing.genetrateInvertedIndex(File.ReadAllLines(dirorg.GetTokenPath(i)));
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
        }

        private void Process_Tokenize(EventWaitHandle[] waitGroup, int artical_count)
        {
            PostMessage(MessageType.NOTICE, "Tokenizing File ...");
            for (int i = 0; i < artical_count; ++i)
            {
                if (EventWaitHandle.WaitAny(waitGroup) == 0)
                    throw new AbortedException();
                PostMessage(MessageType.NOTICE_SMALL, "Tokenizing File " + i.ToString());
                File.WriteAllLines(dirorg.GetTokenPath(i), html_tokenizer.tokenize(File.ReadAllText(dirorg.GetArticalPath(i))));
            }
            PostMessage(MessageType.NOTICE, "Tokenizing File Finish");
        }

        private int Process_Split(EventWaitHandle[] waitGroup)
        {
            int currentsplitedartical = 0;
            PostMessage(MessageType.NOTICE, "Splitting File ...");
            Action<string> callback = x =>
            {
                if (EventWaitHandle.WaitAny(waitGroup) == 0)
                    throw new AbortedException();
                PostMessage(MessageType.NOTICE_SMALL, "Find Artical # " + currentsplitedartical.ToString());
                File.WriteAllText(dirorg.GetArticalPath(currentsplitedartical++), x);
            };
            int artical_count = warc_spliter.split(file, callback);
            PostMessage(MessageType.NOTICE, "Splitting File Finish");
            return artical_count;
        }
        #endregion

        private void ProcessFinish()
        {
        }
    }
}
