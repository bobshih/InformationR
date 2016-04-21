using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InformationRetrieval
{
    public static class StreamReaderExtension
    {
        public static string ReadUntil(this StreamReader reader, string delim)
        {
            if (delim.Length == 1)
            {
                return ReadUntil(reader, delim[0]);
            }

            StringBuilder builder = new StringBuilder();
            string fdelim = delim.Substring(0, delim.Length - 1);
            while (reader.Peek() != -1)
            {
                string temp = reader.ReadUntil(delim[delim.Length - 1]);
                if (temp == null)
                    return "";
                if (temp.Length > delim.Length - 1 && temp.Substring(temp.Length - fdelim.Length).Equals(fdelim))
                {
                    //find 'delim'
                    builder.Append(temp.Substring(0, temp.Length - fdelim.Length));
                    break;
                }
                else
                {
                    //not find 'delim'
                    builder.Append(temp);
                    builder.Append(delim[delim.Length - 1]);
                    continue;
                }
            }
            return builder.ToString();
        }

        /// <summary>
        /// Read Until Reach 'delim', 'delim' Is Removed From Stream After Read
        /// </summary>
        public static string ReadUntil(this StreamReader reader, char delim)
        {
            List<char> chars = new List<char>();

            while (reader.Peek() >= 0)
            {
                char c = (char)reader.Read();
                if (c == delim)
                {
                    return new string(chars.ToArray());
                }
                chars.Add(c);
            }
            return null;
        }
    }
}
