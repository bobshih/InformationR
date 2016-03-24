using System;
using System.Collections.Generic;
using System.IO;
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

        /// <summary>
        /// Split Texts In [tag] and add to parseResultBuffer[last]
        /// </summary>
        private void ParseFinal(XmlElement subfinal, string tag)
        {
            var element = subfinal.GetElementsByTagName(tag);
            foreach (XmlElement leaf in element)
            {
                parseResultBuffer[parseResultBuffer.Count - 1].AddRange(leaf.InnerText.Split(new char[] { /*',', '.',/*digits*/ '?', '!', '~', ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries));
            }
        }

        /// <summary>
        /// PostProcess For Tokens
        /// </summary>
        private void PostProcess(List<string> tokens)
        {
            for (int i = 0; i < tokens.Count; ++i)
            {
                if (tokens[i].EndsWith(",") || tokens[i].EndsWith("."))
                {
                    tokens[i] = tokens[i].Remove(tokens[i].Length - 1);
                }
                tokens[i] = tokens[i].ToLower();
            }
        }

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
