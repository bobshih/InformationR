using mshtml;
using System;
using System.Collections.Generic;
using System.IO;
///
///Contributor : 101820302 101820307
///

namespace homework_indexer_parser.Parser
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
        //private Queue<WARC_TOPIC_TOKENS> parseResultBuffer = new Queue<WARC_TOPIC_TOKENS>();
        private Queue<string> fileBuffer = new Queue<string>();
        private WARC_HTML_ONLYReader warchtmlReader = null;
        private PostProcessingChoice choice;

        private bool HasFlag(PostProcessingChoice flag)
        {
            return (choice & flag) != PostProcessingChoice.NONE;
        }


        /// <summary>
        /// </summary>
        public WARCReader(PostProcessingChoice choice)
        {
            this.choice = choice;
        }

        /// <summary>
        /// Add File To ReadBuffer
        /// </summary>
        /// <param name="filename">file to parse</param>
        public void AddFile(string filename)
        {
            fileBuffer.Enqueue(filename);
        }

        private WARC_TOPIC_TOKENS ParseOneArticle(HTMLRecord record)
        {
            HTMLDocument doc = new HTMLDocument();
            IHTMLDocument2 doc2 = (IHTMLDocument2)doc;
            doc2.write(record.htmlContent);

            var temp = doc.getElementsByTagName("html");
            List<string> tokens = new List<string>();
            foreach (IHTMLElement element in temp)
            {
                tokens.AddRange(ParseAndRemoveSeperator(element));
            }
            WARC_TOPIC_TOKENS tk = new WARC_TOPIC_TOKENS();
            tk.ID = record.recordID;
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


        /// <summary>
        /// Get Next Article ,If No Article Avalible ,null is returned
        /// </summary>
        public WARC_TOPIC_TOKENS GetNext()
        {
            if (warchtmlReader == null && fileBuffer.Count != 0)
            {
                warchtmlReader = new WARC_HTML_ONLYReader(fileBuffer.Dequeue());
            }
            else
            {
                return null;
            }

        AGAIN:
            var topic = warchtmlReader.ReadNextHtml();
            if (topic == null)
            {
                if (fileBuffer.Count == 0)
                {
                    return null;
                }
                else
                {
                    warchtmlReader = new WARC_HTML_ONLYReader(fileBuffer.Dequeue());
                    goto AGAIN;
                }
            }

            return this.ParseOneArticle(topic);
        }
        /*
        /// <summary>
        /// Get Buffered (Not Get By GetNext()) Artical Count
        /// </summary>
        public int AvalibleArticleCount
        {
            get
            {
                return parseResultBuffer.Count;
            }
        }
        */
        /*
        /// <summary>
        /// Get Processed (All) Artical Count
        /// </summary>
        public int ProcessedArticleCount
        {
            get;
            private set;
        }
         * */
    }
}
