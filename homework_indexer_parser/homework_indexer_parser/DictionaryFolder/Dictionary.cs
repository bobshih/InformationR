using System;
using System.Collections.Generic;
using System.Linq;

namespace homework_indexer_parser.DictionaryFolder
{
    class Dictionary
    {
        private Dictionary<string, Posting> dic = new Dictionary<string, Posting>();
        int currentDocumentID = 0;

        public Dictionary()
        {
        }

        public Dictionary(String filePath)
        {
            throw new NotImplementedException();
        }

        public void AddArticle(List<String> article)
        {
            int currentTokenIndex = 0;
            foreach (string token in article)
            {
                Posting posting;
                if (!dic.TryGetValue(token, out posting))
                {
                    Posting newPosting = new Posting(token);
                    newPosting.AddPostingInformation(currentDocumentID, currentTokenIndex);
                    dic.Add(token, newPosting);
                }
                else
                {
                    posting.AddPostingInformation(currentDocumentID, currentTokenIndex);
                }
                ++currentTokenIndex;
            }
            ++currentDocumentID;
        }

        public void OutputFile()
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter("output.txt"))
            {
                var sortedPosting = dic.Values.OrderBy((p) => p.Word);
                foreach (Posting p in sortedPosting)
                {
                    p.WriteToFile(file);
                }
            }
        }
    }
}
