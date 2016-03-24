using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_indexer_parser.DictionaryFolder
{
    class PostingInformation
    {
        int docNum;
        int freq;
        List<int> postition = new List<int>();

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
