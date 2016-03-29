using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///
///Contributor : 101820307
///

namespace homework_indexer_parser.Parser
{
    internal class HTMLRecord
    {
        public string recordID;
        public string htmlContent;
    }

    internal class WARC_HTML_ONLYReader
    {
        FileStream fstream;
        StreamReader sreader;
        public WARC_HTML_ONLYReader(string path)
        {
            fstream = File.OpenRead(path);
            sreader = new StreamReader(fstream);
        }

        public HTMLRecord ReadNextHtml()
        {
            while (!sreader.EndOfStream)
            {
                var block = WARCBasicParser.ReadOne(sreader);
                if (block.Type() != WARCType.response)
                    continue;
                string text;
                try
                {
                    HTMLRecord response = new HTMLRecord();
                    text = new string(block.content);
                    int contenttypeindex = text.IndexOf("Content-Type:", StringComparison.CurrentCultureIgnoreCase) + "Content-Type:".Length;
                    if (contenttypeindex == -1)
                        continue;
                    if (text.Substring(contenttypeindex, 20).IndexOf("text", StringComparison.CurrentCultureIgnoreCase) == -1)
                        continue;
                    int begin = text.IndexOf("<html>");
                    int end = text.IndexOf("</html>") + 7;
                    response.htmlContent = text.Substring(begin, end - begin);
                    response.recordID = block.ID();
                    return response;
                }
                catch
                {
                    continue;
                }
            }
            return null;
        }

    }
}
