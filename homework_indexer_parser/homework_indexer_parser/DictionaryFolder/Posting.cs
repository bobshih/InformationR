using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

///
///Contributor : 101820302 101820307
///

namespace homework_indexer_parser.DictionaryFolder
{
    internal class Posting
    {
        public String Word
        {
            get;
            set;
        }
        private Dictionary<int, List<int>> docPostition = new Dictionary<int, List<int>>();
        public int Frequency
        {
            get;
            private set;
        }

        public Posting(String newWord)
        {
            Word = newWord;
        }

        public void AddPostingInformation(int docNum, int position)
        {
            List<int> postingIndex;
            if (!docPostition.TryGetValue(docNum, out postingIndex))
            {
                docPostition.Add(docNum, new List<int>(new int[] { position }));
            }
            else
            {
                postingIndex.Add(position);
            }
            ++Frequency;
        }

        internal void WriteToFile(StreamWriter writer)
        {

            writer.WriteLine(Word + ", " + Frequency.ToString() + " :");

            writer.WriteLine("<");
            var sortedDocPostition = docPostition.OrderBy((x) => x.Key);
            foreach (var docIndexListPair in sortedDocPostition)
            {
                StringBuilder line = new StringBuilder(docIndexListPair.Key + ", " + docIndexListPair.Value.Count + ":<");
                List<int> positions = docIndexListPair.Value;
                for (int i = 0; i < positions.Count; i++)
                {
                    line.Append(positions[i]);
                    if (i != positions.Count - 1)
                    {
                        line.Append(", ");
                    }
                }
                line.Append(">;");
                writer.WriteLine(line);
            }
            writer.WriteLine(">");
        }
    }
}
