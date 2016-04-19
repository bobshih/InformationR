using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationRetrieval
{
    public static class indexing
    {
        public static Dictionary<string, List<int>> genetrateInvertedIndex(string file)
        {
            Dictionary<string, List<int>> dic = new Dictionary<string, List<int>>();
            var lines = File.ReadAllLines(file);
            for (int i = 0; i < lines.Length; ++i)
            {
                List<int> posting;
                if (!dic.TryGetValue(lines[i], out posting))
                {
                    List<int> l = new List<int>();
                    l.Add(i);
                    dic.Add(lines[i], l);
                }
                else
                {
                    posting.Add(i);
                }
            }
            return (dic);
        }
    }
}
