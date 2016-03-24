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
                parseResultBuffer.Add(new List<string>());
                ParseFinal(reuters, "TITLE");
                ParseFinal(reuters, "BODY");
                PostProcess(parseResultBuffer[parseResultBuffer.Count - 1]);
            }
        }

        #region ReadFile Implementation

        /// <summary>
        /// Split Texts In [tag] and add to parseResultBuffer[last]
        /// </summary>
        private void ParseFinal(XmlElement subfinal, string tag)
        {
            var element = subfinal.GetElementsByTagName(tag);
            foreach (XmlElement leaf in element)
            {
                var nospace = leaf.InnerText.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                parseResultBuffer[parseResultBuffer.Count - 1].AddRange(nospace);
            }
        }

        private static void KeepAlnum(List<string> candidate)
        {
        }

        /// <summary>
        /// PostProcess For Tokens
        /// </summary>
        private static void PostProcess(List<string> tokens)
        {
            for (int i = 0; i < tokens.Count; ++i)
            {
                char last = tokens[i][tokens[i].Length - 1];
                while (!char.IsLetterOrDigit(last))
                {
                    tokens[i].Remove(tokens[i].Length - 1);
                }

                if (tokens[i].Length == 0)
                {
                    tokens.RemoveAt(i);
                    --i;
                    continue;
                }

                tokens[i] = tokens[i].ToLower();
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
