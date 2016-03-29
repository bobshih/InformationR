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

    public enum WARCType
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

    public struct WARCHeader
    {
        public double WARC_Version;
        public WARCType WARC_Type;
        public int content_length;
        public string ID;
        public Dictionary<string, string> named_field;
        public char[] content;
    }

    public class WARCHeaderParser
    {
        public static WARCHeader ReadHeader(StreamReader reader)
        {
            WARCHeader header = new WARCHeader();
            GetVersion(reader, ref header);
            Get_warc_fields(reader, ref header);
            char[] buffer = new char[header.content_length];
            reader.ReadBlock(buffer,0,header.content_length);
            header.content = buffer;
            return header;
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
                throw new ParserException("Not Warc File");
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
                ParseMandatoryField(ref header);
            }
            catch
            {
                throw new ParserException("Not Valid Warc Fields");
            }
        }

        private static void ParseMandatoryField(ref WARCHeader header)
        {
            string type;
            header.named_field.TryGetValue("WARC-Type", out type);
            header.WARC_Type = (WARCType)Enum.Parse(typeof(WARCType), type);

            string length;
            header.named_field.TryGetValue("Content-Length", out length);
            header.content_length = int.Parse(length);

            header.named_field.TryGetValue("WARC-Record-ID", out header.ID);
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
