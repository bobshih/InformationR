using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_indexer_parser.Parser
{
    internal class HTMLResponse
    {
        string id;
        string content_type;
        string content;
    }
    internal class SomethingWARCParser
    {
        FileStream fstream;
        StreamReader sreader;
        public SomethingWARCParser(string path)
        {
            fstream = File.OpenRead(path);
            sreader = new StreamReader(fstream);
        }

        public HTMLResponse ReadNextHtml()
        {
            HTMLResponse response = null;
            while (!sreader.EndOfStream)
            {
                var header = WARCBasicParser.ReadOne(sreader);
                if (header.WARC_Type != WARCType.response)
                    continue;

            }
            return response;
        }

    }
}
