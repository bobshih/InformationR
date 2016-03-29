using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homework_indexer_parser.Parser
{
    public class ParserException : Exception
    {
        public ParserException(string message = "parser error") :
            base(message)
        {
        }
    }

    enum WARCType
    {
        warcinfo,
        response,
        resource,
        request,
        metadata,
        revisit,
        conversion,
        continuation
    };

    struct WARCHeader
    {
        public double WARC_Version;
        public WARCType WARC_Type;
    }

    internal class WARCHeaderParser
    {
        public void ReadHeader(StreamReader reader)
        {
            WARCHeader header = new WARCHeader();
            GetVersion(reader, ref header);
        }

        private static void GetVersion(StreamReader reader, ref WARCHeader header)
        {
            try
            {
                string str = reader.ReadLine();
                header.WARC_Version = double.Parse(str);
            }
            catch
            {
                throw new ParserException("Not Warc File");
            }
        }
    }
}
