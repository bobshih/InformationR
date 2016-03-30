using mshtml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_indexer_parser.SimpleParser
{
    class Parser
    {
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
                /**/
                StreamReader stream = new StreamReader(filename);
                string[] htmlFile = File.ReadAllLines(filename);
                String paraph = "";


                bool inBody = false;
                while (true)
                {
                    String temp = stream.ReadLine();
                    if (temp == null)
                    {
                        break;
                    }
                    if (temp.Contains("</body>"))
                    {
                        paraph += temp;
                        inBody = false;

                        doc2.write(paraph);
                        var t = doc.getElementsByTagName("body");
                        foreach (IHTMLElement element in t)
                        {
                            List<string> tokens = ParseElement(element);
                            parseResultBuffer.Enqueue(tokens);
                            ++ProcessedArticleCount;
                        }

                        paraph = "";
                    }
                    if (temp.Contains("<body>"))
                    {
                        inBody = true;
                    }
                    if (inBody)
                    {
                        paraph += temp;
                    }
                }
                //int begin = htmlFile.IndexOf("<html>");
                //int end = htmlFile.IndexOf("</html>") + 7;
                //htmlFile = htmlFile.Substring(begin, end - begin);

                //doc2.write(htmlFile);
                //var temp = doc.getElementsByTagName("html");

                /*
                foreach (IHTMLElement element in temp)
                {
                    List<string> tokens = ParseElement(element);
                    parseResultBuffer.Enqueue(tokens);
                    ++ProcessedArticleCount;
                }/**/
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
}
