using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace homework_indexer_parser.ParserFolder
{
    /// <summary>
    /// SGML Reader
    /// </summary>
    public class SGMLReader
    {
        private List<List<string>> parseResultBuffer = new List<List<string>>();

        /// <summary>
        /// </summary>
        public SGMLReader()
        {
        }

        /// <summary>
        /// Read And Append Parsed Result To Current Buffer
        /// </summary>
        /// <param name="filename">file to parse</param>
        public void ReadFile(string filename)
        {
            XmlDocument document = new XmlDocument();
            document.XmlResolver = null;
            string test = File.ReadAllText(filename);
            test = "<root>" + test.Substring(test.IndexOf("\n")) + "</root>";
            document.LoadXml(test);
            var elements = document.GetElementsByTagName("REUTERS");
            foreach (XmlElement reuters in elements)
            {
                List<string> documentTokens = new List<string>();
                ParseFinal(documentTokens, reuters, "TITLE");
                ParseFinal(documentTokens, reuters, "BODY");
                PostProcess(parseResultBuffer[parseResultBuffer.Count - 1]);
                parseResultBuffer.Add(documentTokens);
            }
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
                var ret = parseResultBuffer[0];
                parseResultBuffer.RemoveAt(0);
                return ret;
            }
            return null;
        }
    }
}
