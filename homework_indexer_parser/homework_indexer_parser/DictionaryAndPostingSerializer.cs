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
        private static class FileParameters
        {
#if DEBUG
            public static readonly SaveOptions sopt = SaveOptions.None;
#else
            public static readonly SaveOptions sopt = SaveOptions.DisableFormatting;
#endif
            public static readonly string Root = "i";
            public static readonly string Term = "T";
            public static readonly string TermAttrTerm = "tt";
            public static readonly string TermAttrfrequency = "tf";
            public static readonly string Position = "p";
            public static readonly string TermAttrWeight = "tw";
        }
        public static void Save(Dictionary<string, List<int>> dic, string file)
        {
            XElement root = new XElement(FileParameters.Root);
            foreach (var pair in dic)
            {
                XElement node = new XElement(
                    FileParameters.Term,
                    new XAttribute(FileParameters.TermAttrTerm, pair.Key),
                    new XAttribute(FileParameters.TermAttrfrequency, pair.Value.Count),
                    pair.Value.Select(x => new XElement(FileParameters.Position, x))//posting
                    );
                root.Add(node);
            }
            root.Save(file, FileParameters.sopt);
        }

        public static void Load(out Dictionary<string, List<int>> dic, string file)
        {
            XElement root = XElement.Parse(File.ReadAllText(file));
            dic = root.Descendants(FileParameters.Term).ToDictionary(
                x => (string)x.Attribute(FileParameters.TermAttrTerm).Value,
                x => x.Descendants(FileParameters.Position).Select(y => int.Parse(y.Value)).ToList()
                );
        }

        public static void Save(Dictionary<string, double> dic, string file)
        {
            XElement root = new XElement(FileParameters.Root,
                dic.Select(x => new XElement(
                    FileParameters.Term,
                    new XAttribute(FileParameters.TermAttrTerm, x.Key),
                    new XAttribute(FileParameters.TermAttrWeight, x.Value))));
            root.Save(file, FileParameters.sopt);
        }

        public static void Load(out Dictionary<string, double> dic, string file)
        {
            XElement root = XElement.Parse(File.ReadAllText(file));
            dic = root.Descendants(FileParameters.Term).ToDictionary(
                x => (string)x.Attribute(FileParameters.TermAttrTerm),
                x => double.Parse(x.Attribute(FileParameters.TermAttrWeight).Value)
                );
        }
    }
}
