using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InformationRetrieval
{
    public static class DictionaryAndPostingSerializer
    {
        private static readonly string Root = "i";
        private static readonly string Term = "T";
        private static readonly string TermAttrTrem = "t";
        private static readonly string TermAttrfrequency = "tf";
        private static readonly string Position = "p"; 
        public static void Save(Dictionary<string, List<int>> dic, string file)
        {
            XElement root = new XElement(Root);
            foreach (var pair in dic)
            {
                XElement node = new XElement(
                    Term,
                    new XAttribute(TermAttrTrem, pair.Key),
                    new XAttribute(TermAttrfrequency, pair.Value.Count),
                    pair.Value.Select(x => new XElement(Position, x))//posting
                    );
                root.Add(node);
            }
            root.Save(file, SaveOptions.DisableFormatting);
        }

        public static void Load(out Dictionary<string, List<int>> dic, string file)
        {
            XElement root = XElement.Parse(File.ReadAllText(file));
            dic = root.Descendants(Root).ToDictionary(
                x => (string)x.Attribute(Term),
                x => x.Descendants(Position).Select(y => int.Parse(y.Value)).ToList()
                );
        }
    }
}
