using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_indexer_parser.DictionaryFolder
{
    class Dictionary
    {
        List<Posting> posting;
        int maximumDoc;

        public Dictionary()
        {
            maximumDoc = 0;
            posting = new List<Posting>();
        }

        public Dictionary(String filePath)
        {
            throw new NotImplementedException();
        }

        public void AddArticle(List<String> article)
        {
            maximumDoc++;
            for (int i = 0; i < article.Count;i++ )
            {
                bool flag = true;
                foreach (Posting p in posting)
                {
                    if (p.GetWord().Equals(article[i]))
                    {
                        PostingInformation temp = p.GetFinalPostingInformation();
                        if (temp.GetDocNum() == maximumDoc)
                        {
                            temp.AddPostingInformation(i);
                        }
                        else
                        {
                            p.SetNewPostingInformation(maximumDoc, i);
                        }
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    Posting newPosting = new Posting(article[i], maximumDoc, i);
                    posting.Add(newPosting);
                }
            }

            // sort
            posting.Sort(
                delegate(Posting p1, Posting p2)
                {
                    return p1.GetWord().CompareTo(p2.GetWord());
                }
            );
        }

        public void OutputFile()
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter("output.txt"))
            {
                foreach (Posting p in posting)
                {
                    file.WriteLine(p.GetWord()+", "+p.GetFreq().ToString());

                    file.WriteLine("<");
                    List<PostingInformation> position = p.getFreqList();
                    foreach (PostingInformation postingInformation in position)
                    {
                        String line = postingInformation.GetDocNum() + ", " + postingInformation.GetFreq()+":<";
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
