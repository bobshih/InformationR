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
        public static void Save(Dictionary<string, List<int>> dic, string file)
        {
            XElement root = new XElement("items");
            foreach (var pair in dic)
            {
                XElement node = new XElement(
                    "node",
                    new XAttribute("term", pair.Key),
                    new XAttribute("term-frequency", pair.Value.Count),
                    pair.Value.Select(x => new XElement("p", x))//posting
                    );
                root.Add(node);
            }
            root.Save(file);
        }

        public static void Load(out Dictionary<string, List<int>> dic, string file)
        {
            XElement root = XElement.Parse(File.ReadAllText(file));
            dic = root.Descendants("node").ToDictionary(
                x => (string)x.Attribute("term"),
                x => x.Descendants("p").Select(y => int.Parse(y.Value)).ToList()
                );
        }
    }
}
