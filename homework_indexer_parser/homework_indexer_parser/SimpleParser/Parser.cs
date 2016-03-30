using mshtml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
///
///Contributor : 101820302 101820307
///

namespace homework_indexer_parser.SimpleParser
{
    [Flags]
    public enum PostProcessingChoice
    {
        NONE = 0,
        CASE_FOLDING = 1,
        NO_NUMBER = 2,
    }

    public class WARC_TOPIC_TOKENS
    {
        public string ID;
        public List<string> tokens;
    }

    /// <summary>
    /// SGML Reader
    /// </summary>
    public class WARCReader
    {
        #region member variable

        //private Queue<WARC_TOPIC_TOKENS> parseResultBuffer = new Queue<WARC_TOPIC_TOKENS>();
        private Queue<string> fileBuffer = new Queue<string>();
        private StreamReader reader = null;
        private PostProcessingChoice choice;


        #endregion

        #region public method

        /// <summary>
        /// </summary>
        public WARCReader(PostProcessingChoice choice)
        {
            this.choice = choice;
            CurrentFile = null;
        }

        /// <summary>
        /// Add File To ReadBuffer
        /// </summary>
        /// <param name="filename">file to parse</param>
        public void AddFile(string filename)
        {
            fileBuffer.Enqueue(filename);
        }

        /// <summary>
        /// Add Many File To ReadBuffer
        /// </summary>
        /// <param name="filename">file list to parse</param>
        public void AddFile(List<string> filenames)
        {
            foreach (string s in filenames)
                fileBuffer.Enqueue(s);
        }

        /// <summary>
        /// Get Next Article ,If No Article Avalible ,null is returned
        /// </summary>
        public WARC_TOPIC_TOKENS GetNext()
        {
            //May Use Buffer Is Not Return Directly
            return this.ReadOneArticle();
        }

        #endregion

        #region Parse Implementation
        private bool ValidateReader()
        {
            while (reader == null || reader.Peek() == -1)
            {
                if (fileBuffer.Count == 0)
                {
                    CurrentFile = null;
                    return false;
                }
                else
                {
                    CurrentFile = fileBuffer.Dequeue();
                    reader = new StreamReader(CurrentFile);
                }
            }
            return true;
        }

        private WARC_TOPIC_TOKENS ReadOneArticle()
        {
            string topic = null;
            while (String.IsNullOrEmpty(topic))
            {
                if (!ValidateReader())
                    return null;
                StringBuilder temptopic = new StringBuilder();
                string temp;

                //Find <HTML>
                while ((temp = reader.ReadLine()) != null)
                {
                    int beingIndex = temp.IndexOf("<html>", StringComparison.CurrentCultureIgnoreCase);
                    if (beingIndex == -1)
                    {
                        continue;
                    }
                    temptopic.AppendLine(temp.Substring(beingIndex));
                }
                if (reader.Peek() == -1)
                    continue;

                //Find Until </HTML>
                while ((temp = reader.ReadLine()) != null)
                {
                    int endIndex = temp.IndexOf("</html>", StringComparison.CurrentCultureIgnoreCase);
                    if (endIndex == -1)
                    {
                        temptopic.AppendLine(temp);
                    }
                    else
                    {
                        temptopic.AppendLine(temp.Substring(0, endIndex + "</html>".Length));
                    }
                }

                topic = temptopic.ToString();
                break;
            }

            HTMLDocument doc = new HTMLDocument();
            IHTMLDocument2 doc2 = (IHTMLDocument2)doc;
            doc2.write(topic);

            var paralist = doc.getElementsByTagName("html");
            List<string> tokens = new List<string>();
            foreach (IHTMLElement element in paralist)
            {
                tokens.AddRange(ParseAndRemoveSeperator(element));
            }
            WARC_TOPIC_TOKENS tk = new WARC_TOPIC_TOKENS();
            tk.ID = CurrentFile;
            tk.tokens = tokens;
            return tk;
        }

        private List<string> ParseAndRemoveSeperator(IHTMLElement element)
        {
            List<string> documentTokens = new List<string>();
            documentTokens.AddRange(element.innerText.Split(new char[] { '|', ' ', '\n', '\r', '\t', '(', ')' }, StringSplitOptions.RemoveEmptyEntries));
            PostProcess(documentTokens);
            return documentTokens;
        }

        private string GetCenterString(string str, Predicate<char> pred)
        {
            int finalalnum = str.Length - 1;
            for (; finalalnum >= 0; --finalalnum)
            {
                if (pred(str[finalalnum]))
                    break;
            }
            int firstalnum = 0;
            for (; firstalnum <= finalalnum; ++firstalnum)
            {
                if (pred(str[firstalnum]))
                    break;
            }

            if (firstalnum <= finalalnum)
            {
                str = str.Substring(firstalnum, finalalnum - firstalnum + 1);
                return str;
            }
            else
            {
                return "";
            }
        }

        private bool PostProcessOnce(ref string str)
        {
            str = GetCenterString(str, Char.IsLetterOrDigit);

            if (HasFlag(PostProcessingChoice.CASE_FOLDING))
            {
                str = str.ToLower();
            }

            if (HasFlag(PostProcessingChoice.NO_NUMBER))
            {
                foreach (var c in str)
                {
                    if (char.IsLetter(c))
                    {
                        return true;
                    }
                }
                return false;
            }

            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// PostProcess For Tokens
        /// </summary>
        private void PostProcess(List<string> tokens)
        {
            for (int i = 0; i < tokens.Count; ++i)
            {
                string str = tokens[i];
                if (!PostProcessOnce(ref str))
                {
                    tokens.RemoveAt(i);
                    --i;
                    continue;
                }
                tokens[i] = str;
            }
        }

        private bool HasFlag(PostProcessingChoice flag)
        {
            return (choice & flag) != PostProcessingChoice.NONE;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get Current Reading File Name
        /// </summary>
        public string CurrentFile
        {
            get;
            private set;
        }

        /// <summary>
        /// Count Of File Added
        /// </summary>
        public int TotalFileCount
        {
            get;
            private set;
        }

        /// <summary>
        /// Count Of File Processed
        /// </summary>
        public int ProcessedFileCount
        {
            get
            {
                return TotalFileCount - fileBuffer.Count;
            }
        }

        /// <summary>
        /// Get Current Reading File Name
        /// </summary>
        public int ProcessedArticalCount
        {
            get;
            private set;
        }

        /// <summary>
        /// Get Current IDNAME
        /// </summary>
        private string IDName
        {
            get
            {
                return ProcessedArticalCount.ToString() + ProcessedFileCount.ToString() + "(" + CurrentFile + ")";
            }
        }

        /// <summary>
        /// Get Current Reading File Length
        /// </summary>
        public long CurrentFileSize
        {
            get
            {
                return reader == null ? reader.BaseStream.Length : 0;
            }
        }

        /// <summary>
        /// Get Current Reading File Position
        /// </summary>
        public long CurrentFilePosition
        {
            get
            {
                return reader == null ? reader.BaseStream.Position : 0;
            }
        }

        #endregion
    }
}
