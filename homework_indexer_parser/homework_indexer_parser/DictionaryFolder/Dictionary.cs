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
                bool hasword = dic.TryGetValue(token, out posting);
                if (!hasword)
                {
                    Posting newPosting = new Posting(token, currentDocumentID, currentTokenIndex);
                    dic.Add(token, newPosting);
                }
                else
                {
                    posting.SetNewPostingInformation(currentDocumentID, currentTokenIndex);
                }
                ++currentTokenIndex;
            }
            currentDocumentID++;
        }

        public void OutputFile()
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter("output.txt"))
            {
                var sortedPosting = dic.Values.OrderBy((p) => p.GetWord());
                foreach (Posting p in sortedPosting)
                {
                    file.WriteLine(p.GetWord() + ", " + p.GetFreq().ToString() + " :");

                    file.WriteLine("<");
                    List<PostingInformation> position = p.getFreqList();
                    foreach (PostingInformation postingInformation in position)
                    {
                        String line = postingInformation.GetDocNum() + ", " + postingInformation.GetFreq() + ":<";
                        List<int> positions = postingInformation.getPosition();
                        for (int i = 0; i < positions.Count; i++)
                        {
                            line += positions[i].ToString();
                            if (i != positions.Count - 1)
                            {
                                line += ", ";
                            }
                        }
                        line += ">;";
                        file.WriteLine(line);
                    }
                    file.WriteLine(">");
                }
            }
        }
    }
}
