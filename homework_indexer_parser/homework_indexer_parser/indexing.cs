using System;
using System.Collections.Generic;
using System.Linq;

namespace InformationRetrieval
{
    public static class indexing
    {
        public static Dictionary<string, List<int>> genetrateInvertedIndex(IEnumerable<string> tokens)
        {
            Dictionary<string, List<int>> dic = new Dictionary<string, List<int>>();
            int i = 0;
            foreach (var str in tokens)
            {
                List<int> posting;
                if (!dic.TryGetValue(str, out posting))
                {
                    posting = new List<int>();
                    dic.Add(str, posting);
                }
                posting.Add(i);
                ++i;
            }
            return (dic);
        }

        public static Dictionary<string, double> fetch_tf(Dictionary<string, List<int>> artical_dic)
        {
            return artical_dic.ToDictionary(x => x.Key, x => (double)x.Value.Count);
        }

        public static Dictionary<string, double> weighted_tf(Dictionary<string, double> artical_tf)
        {
            return artical_tf.ToDictionary(x => x.Key, x => 1 + Math.Log10(x.Value));
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

        public static Dictionary<string, double> normalize_tfidf(Dictionary<string, double> artical_wtf)
        {
            double length = Math.Sqrt(artical_wtf.Values.Select(x => x * x).Sum());
            if (length == 0)
            {
                return artical_wtf;
            }
            return artical_wtf.ToDictionary(x => x.Key, x => x.Value / length);
        }
    }
}
