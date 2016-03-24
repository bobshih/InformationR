using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace homework_indexer_parser.ParserFolder
{
    public static class Parser
    {
        public static bool FileOpening
        {
            get;
            set;
        }


        private static UInt64 CurrentDataIndex;
        static Parser()
        {
            if (!File.Exists("parse.index"))
            {
                File.WriteAllText("parse.index", "0");
                CurrentDataIndex = 0;
            }
            else
            {
                CurrentDataIndex = UInt64.Parse(File.ReadAllText("parse.index"));
            }
        }

        public static void Open(string str)
        {
            XmlDocument document = new XmlDocument();
            document.XmlResolver = null;
            //XmlDocumentFragment frag = document.CreateDocumentFragment();
            string test = File.ReadAllText(str);
            test = "<root>" + test.Substring(test.IndexOf("\n")) + "</root>";
            //frag.InnerXml = test;
            document.LoadXml(test);
            var elements = document.GetElementsByTagName("REUTERS");
            foreach (XmlElement reuters in elements)
            {
                reuters.GetElementsByTagName("");
            }
        }



        static List<string> GetNext()
        {
            throw new NotImplementedException();
        }
    }
}
