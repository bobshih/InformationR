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

        public static Dictionary<string, double> fetch_tf(Dictionary<string, List<int>> artical_dic)
        {
            return artical_dic.ToDictionary(x => x.Key, x => (double)x.Value.Count);
        }

        public static Dictionary<string, double> weighted_tf(Dictionary<string, double> artical_tf)
        {
            return artical_tf.ToDictionary(x => x.Key, x => /*x.Value == 0 ? 0 : newver 0*/ 1 + Math.Log10(x.Value));
        }

        public static Dictionary<string, double> fetch_df(Dictionary<string, List<int>> gloable_dic)
        {
            return fetch_tf(gloable_dic);
        }

        public static Dictionary<string, double> idf(Dictionary<string, double> df, double N)
        {
            return df.ToDictionary(x => x.Key, x => Math.Log10(N / x.Value));
        }

        public static Dictionary<string, double> tfidf(Dictionary<string, double> artical_wtf, Dictionary<string, double> gloable_idf)
        {
            return artical_wtf.ToDictionary(x => x.Key, x => x.Value * gloable_idf[x.Key]);
        }
    }
}
