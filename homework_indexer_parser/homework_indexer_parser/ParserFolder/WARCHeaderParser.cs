using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
///
///Contributor : 101820307
///

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
        public Dictionary<string, string> named_field;
    }

    internal class WARCHeaderParser
    {
        public void ReadHeader(StreamReader reader)
        {
            WARCHeader header = new WARCHeader();
            GetVersion(reader, ref header);
            Get_warc_fields(reader, ref header);
        }

        private static void GetVersion(StreamReader reader, ref WARCHeader header)
        {
            try
            {
                string str = reader.ReadLine();
                if (str.Substring(0, 5) != @"WARC/")
                    throw new ParserException();
                header.WARC_Version = double.Parse(str.Substring(5));
            }
            catch
            {
                throw new ParserException("Not Valid Warc File");
            }
        }

        private static void Get_warc_fields(StreamReader reader, ref WARCHeader header)
        {
            try
            {
                while (Get_named_field(reader, ref header))
                    /*DoNothing*/
                    ;
                if (!CheckMandatoryFieldName(header))
                    throw new ParserException();
            }
            catch
            {
                throw new ParserException("Not Valid Warc Fields");
            }
        }

        private static bool CheckMandatoryFieldName(WARCHeader header)
        {
            string[] mandatory = { "WARC-Record-ID", "Content-Length", "WARC-Date", "WARC-Type" };
            foreach (var s in mandatory)
                if (!header.named_field.ContainsKey(s))
                    return false;
            return true;
        }

        private static bool Get_named_field(StreamReader reader, ref WARCHeader header)
        {
            string str = reader.ReadLine();
            if (str.Length == 0)
                return false;
            int index = str.IndexOf(':');
            if (index == -1)//Not Found
                throw new ParserException();
            string field_name = str.Substring(0, index).Trim();
            string field_value = str.Substring(index + 2).Trim();
            header.named_field.Add(field_name, field_value);
            return true;
            //TODO: validate name-value pair
        }
    }
}
