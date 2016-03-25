using System.Collections.Generic;

namespace homework_indexer_parser.DictionaryFolder
{
    class PostingInformation
    {
        private int docNum;
        private int freq;
        private List<int> postition = new List<int>();

        public PostingInformation()
        {
            docNum = 0;
            freq = 0;
        }

        public void AddPostingInformation(int positionNum)
        {
            freq++;
            postition.Add(positionNum);
        }

        public void SetDocNum(int doc)
        {
            docNum = doc;
        }

        #region getter

        public int GetDocNum()
        {
            return docNum;
        }

        public int GetFreq()
        {
            return freq;
        }

        public List<int> getPosition()
        {
            return postition;
        }

        #endregion
    }
}
