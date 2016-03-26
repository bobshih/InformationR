using mshtml;
using System;
using System.Collections.Generic;
using System.IO;
///
///Contributor : 101820302 101820307
///

namespace homework_indexer_parser.ParserFolder
{
    /// <summary>
    /// SGML Reader
    /// </summary>
    public class WARCReader
    {
        private Queue<List<string>> parseResultBuffer = new Queue<List<string>>();

        /// <summary>
        /// </summary>
        public WARCReader()
        {
            ProcessedArticleCount = 0;
        }

        /// <summary>
        /// Read And Append Parsed Result To Current Buffer
        /// </summary>
        /// <param name="filename">file to parse</param>
        public void ReadFile(string filename)
        {
            HTMLDocument doc = new HTMLDocument();
            IHTMLDocument2 doc2 = (IHTMLDocument2)doc;

            string htmlFile = File.ReadAllText(filename);
            int begin = htmlFile.IndexOf("<html>");
            int end = htmlFile.IndexOf("</html>") + 7;
            htmlFile = htmlFile.Substring(begin, end - begin);

            doc2.write(htmlFile);
            var temp = doc.getElementsByTagName("html");


            foreach (IHTMLElement element in temp)
            {
                List<string> tokens = ParseElement(element);
                parseResultBuffer.Enqueue(tokens);
                ++ProcessedArticleCount;
            }
        }

        #region ReadFile Implementation

        private static List<string> ParseElement(IHTMLElement element)
        {
            List<string> documentTokens = new List<string>();
            documentTokens.AddRange(element.innerText.Split(new char[] { '|', ' ', '\n', '\r', '\t', '(', ')', '\u007f'/*???*/}, StringSplitOptions.RemoveEmptyEntries));
            PostProcess(documentTokens);
            return documentTokens;
        }

        private static bool PostProcessOnce(ref string str)
        {
            int finalalnum = str.Length - 1;
            for (; finalalnum >= 0; --finalalnum)
            {
                if (char.IsLetterOrDigit(str[finalalnum]))
                    break;
            }
            int firstalnum = 0;
            for (; firstalnum <= finalalnum; ++firstalnum)
            {
                if (char.IsLetterOrDigit(str[firstalnum]))
                    break;
            }

            if (firstalnum <= finalalnum)
            {
                str = str.Substring(firstalnum, finalalnum - firstalnum + 1);
                str = str.ToLower();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// PostProcess For Tokens
        /// </summary>
        private static void PostProcess(List<string> tokens)
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

        #endregion

        /// <summary>
        /// Get Next Article ,If No Article Avalible ,null is returned
        /// </summary>
        public List<string> GetNext()
        {
            if (parseResultBuffer.Count != 0)
            {
                return parseResultBuffer.Dequeue();
            }
            return null;
        }

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

        /// <summary>
        /// Get Processed (All) Artical Count
        /// </summary>
        public int ProcessedArticleCount
        {
            get;
            private set;
        }
    }
}
