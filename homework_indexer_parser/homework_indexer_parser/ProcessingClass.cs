using homework_indexer_parser.DictionaryFolder;
using homework_indexer_parser.ParserFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_indexer_parser
{
    class ProcessingClass
    {
        public enum MessageType
        {
            ERROR,
            WARNNING,
            NOTICE
        };
        public event Action<Dictionary> Successed;
        public event Action<MessageType, string> MessageHandler;

        private void PostMessage(MessageType type, string message)
        {
            if (MessageHandler != null)
            {
                MessageHandler(type, message);
            }
        }

        private void ProcessFile(object parameters)
        {
            List<string> fileNames = parameters as List<string>;
            WARCReader reader = new WARCReader();
            Dictionary dictionary = new Dictionary();
            foreach (string file in fileNames)
            {
                List<string> tokenList;
                try
                {
                    reader.ReadFile(file);
                    tokenList = reader.GetNext();
                }
                catch
                {
                    PostMessage(MessageType.ERROR, "Can not parse file " + file);
                    continue;
                }
                //TODO: one word by one to track progress
                dictionary.AddArticle(tokenList);
            }
        }
    }
}
