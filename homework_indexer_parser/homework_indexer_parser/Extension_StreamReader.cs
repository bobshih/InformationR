using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InformationRetrieval
{
    public static class StreamReaderExtension
    {
        public static string ReadUntil(this StreamReader reader, string delim)
        {
            StringBuilder builder = new StringBuilder();
            while (reader.Peek() != -1)
            {
                string temp = reader.ReadUntil(delim[0]);
                int i = 1;
                for (; i < delim.Length; ++i)
                {
                    int current = reader.Peek();
                    if (delim[i] == current)
                    {
                        reader.Read();
                    }
                    else
                    {
                        builder.Append(delim.Substring(0, i));
                        break;
                    }
                }
                if (i == delim.Length)//find 'delim'
                {
                    break;
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
