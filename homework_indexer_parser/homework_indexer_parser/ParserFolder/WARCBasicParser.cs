using System;
using System.Collections.Generic;
using System.IO;
///
///Contributor : 101820307
///

namespace homework_indexer_parser.Parser
{
    public class WARCBasic
    {
        public double WARC_Version;
        public Dictionary<string, string> named_field = new Dictionary<string, string>();
        public char[] content;
    }

    public class WARCBasicParser
    {
        public static WARCBasic ReadOne(StreamReader reader)
        {
            WARCBasic block = new WARCBasic();
            GetVersion(reader, ref block);
            Get_warc_fields(reader, ref block);
            Get_content(reader, ref block);
            reader.ReadLine();
            reader.ReadLine();
            return block;
        }

        private static void Get_content(StreamReader reader, ref WARCBasic header)
        {
            string lengthString;
            header.named_field.TryGetValue(WARCFieldName.content_length, out lengthString);
            int length = int.Parse(lengthString);
            char[] buffer = new char[length];
            reader.Read(buffer, 0, length);
            header.content = buffer;
        }

        private static void GetVersion(StreamReader reader, ref WARCBasic header)
        {
            try
            {
                string str = reader.ReadLine();
                if (str.Substring(0, 5) != @"WARC/")
                    throw new ParserException(str);
                header.WARC_Version = double.Parse(str.Substring(5));
            }
            catch (ParserException e)
            {
                throw new ParserException("Not Warc File");
            }
        }

        private static void Get_warc_fields(StreamReader reader, ref WARCBasic header)
        {
            try
            {
                while (Get_named_field(reader, ref header))
                    /*DoNothing*/
                    ;
                if (!CheckMandatoryFieldName(header))
                    throw new ParserException();
            }
            catch (ParserException e)
            {
                throw new ParserException("Not Valid Warc Fields");
            }
        }
        private static bool CheckMandatoryFieldName(WARCBasic header)
        {
            foreach (var s in WARCFieldName.mandatoryFields)
                if (!header.named_field.ContainsKey(s))
                    return false;
            return true;
        }

        private static bool Get_named_field(StreamReader reader, ref WARCBasic header)
        {
            string str = reader.ReadLine();
            if (str.Length == 0)
                return false;
            int index = str.IndexOf(':');
            if (index == -1)//Not Found
                throw new ParserException();
            string field_name = str.Substring(0, index).Trim();
            string field_value = str.Substring(index).Trim();
            field_value = field_value.Remove(0, 1).Trim();
            header.named_field.Add(field_name, field_value);
            return true;
        }
    }
}
