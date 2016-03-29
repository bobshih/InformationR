using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_indexer_parser.Parser
{
    internal class WARCFieldName
    {
        static WARCFieldName()
        {
            mandatoryFields = new string[] { record_id, content_length, data, type };
        }

        public const string record_id = "WARC-Record-ID";
        public const string content_length = "Content-Length";
        public const string data = "WARC-Date";
        public const string type = "WARC-Type";
        public static readonly string[] mandatoryFields;
    }
}
