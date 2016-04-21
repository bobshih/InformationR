
namespace InformationRetrieval
{
    public class DirectoryOrganizer
    {
        string root;
        public DirectoryOrganizer(string root)
        {
            if (!root.EndsWith("\\"))
                root += "\\";
            this.root = root;
        }

        public string GetArticalPath(int i)
        {
            return root + i.ToString() + ".record_block.txt";
        }
        public string GetTokenPath(int i)
        {
            return root + i.ToString() + ".tokenized.txt";
        }
        public string GetDictionaryPath(int i)
        {
            return root + i.ToString() + ".dictionary.txt";
        }
        public string GetMainDictionaryPath()
        {
            return root + "mainDictionary.dictionary.txt";
        }
        public string GetNormalizedWeightVectorPath(int i)
        {
            return root + i.ToString() + ".nwtfidf.txt";
        }
        public string GetInverseDocumentFrequencyPath()
        {
            return root + "idf.txt";
        }
    }
}
