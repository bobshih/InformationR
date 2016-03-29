using homework_indexer_parser.DictionaryFolder;
using homework_indexer_parser.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_indexer_parser
{
    class Model
    {
        Dictionary dictionary;
        WARCReader parser;

        public Model()
        {
            dictionary = new Dictionary();
            parser = new WARCReader();
        }

        /// <summary>
        /// 讀取一個以上的檔案，以list的方式輸入進來
        /// </summary>
        /// <param name="files"></param>
        public void ReadFiles(List<String> files)
        {
            foreach (String path in files)
                ReadFile(path);
        }

        /// <summary>
        /// 讀取單一檔案的方法
        /// </summary>
        /// <param name="file"></param>
        private void ReadFile(String file)
        {
            parser.ReadFile(file);
        }
    }
}
