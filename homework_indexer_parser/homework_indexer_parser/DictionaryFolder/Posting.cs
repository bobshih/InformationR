using System;
using System.Collections.Generic;
using System.Linq;

namespace homework_indexer_parser.DictionaryFolder
{
    class Posting
    {
        String word;
        List<PostingInformation> docPostition;

        public Posting()
        {
            docPostition = new List<PostingInformation>();
        }

        public Posting(String newWord, int doc, int position)
        {
            word = newWord;
            docPostition = new List<PostingInformation>();
            SetNewPostingInformation(doc, position);
        }

        #region getter

        public String GetWord()
        {
            return word;
        }

        public int GetFreq()
        {
            int sumFreq = 0;
            for (int i = 0; i < docPostition.Count; i++)
            {
                sumFreq += docPostition[i].GetFreq();
            }
            return sumFreq;
        }

        public List<PostingInformation> getFreqList()
        {
            return docPostition;
        }

        #endregion

        #region setter

        public void SetWord(String w)
        {
            word = w;
        }

        public void SetNewPostingInformation(int docNum, int position)
        {
            PostingInformation postingInformation = new PostingInformation();
            postingInformation.SetDocNum(docNum);
            postingInformation.AddPostingInformation(position);
            docPostition.Add(postingInformation);
        }

        #endregion

        public PostingInformation GetFinalPostingInformation()
        {
            return docPostition.LastOrDefault();
        }

    }
}
