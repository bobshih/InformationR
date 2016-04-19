using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InformationRetrieval
{
    public static class DictionaryAndPosting
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
                    new XElement("position", pair.Value.Select(x => new XElement("p", x)))//posting
                    );
                root.Add(node);
            }
            root.Save(file);
        }

        public void Load(out Dictionary<string, List<int>> dic, string file)
        {
            dic = new Dictionary<string, List<int>>();
            XElement root = XElement.Parse(File.ReadAllText(file));
            root.Descendants("node").ToDictionary(
                x=>(string)x.Attribute("term"),
                x=>x.Descendants("position").First().Descendants("p")
                )
        }
    }
}
