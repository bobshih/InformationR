using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using mshtml;
using System.Windows.Forms;

namespace homework_indexer_parser.ParserFolder
{
    /// <summary>
    /// SGML Reader
    /// </summary>
    public class SGMLReader
    {
        private Queue<List<string>> parseResultBuffer = new Queue<List<string>>();

        /// <summary>
        /// </summary>
        public SGMLReader()
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

            WebBrowser web = new WebBrowser();
            

            XmlDocument document = new XmlDocument();
            document.XmlResolver = null;
            string htmlFile = File.ReadAllText(filename);
            int begin = htmlFile.IndexOf("<body>");
            int end = htmlFile.IndexOf("</body>") + 7;
            htmlFile = htmlFile.Substring(begin, end - begin);

            doc2.write(htmlFile);
            var temp = doc.getElementsByTagName("body");


            foreach (IHTMLElement element in temp)
            {
                List<string> documentTokens = new List<string>();
                documentTokens.AddRange( element.innerText.Split(new char[] { ' ', '\n', '\r', '\t', '(', ')', '\u007f'/*???*/}, StringSplitOptions.RemoveEmptyEntries));
                PostProcess(documentTokens);
                parseResultBuffer.Enqueue(documentTokens);
                ++ProcessedArticleCount;
            }
            /*document.LoadXml(htmlFile);
            var elements = document.GetElementsByTagName("REUTERS");
            foreach (XmlElement reuters in elements)
            {
                List<string> documentTokens = new List<string>();
                ParseFinal(documentTokens, reuters, "TITLE");
                ParseFinal(documentTokens, reuters, "BODY");
                PostProcess(documentTokens);
                parseResultBuffer.Enqueue(documentTokens);
                ++ProcessedArticleCount;
            }*/
        }

        #region ReadFile Implementation

        /// <summary>
        /// Split Texts In [tag] and add to parseResultBuffer[last]
        /// </summary>
        private static void ParseFinal(List<string> list, XmlElement subfinal, string tag)
        {
            var element = subfinal.GetElementsByTagName(tag);
            foreach (XmlElement leaf in element)
            {
                var nospace = leaf.InnerText.Split(new char[] { ' ', '\n', '\r', '\t', '(', ')', '\u007f'/*???*/}, StringSplitOptions.RemoveEmptyEntries);
                list.AddRange(nospace);
            }
        }

        public static bool PostProcessOnce(ref string str)
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
