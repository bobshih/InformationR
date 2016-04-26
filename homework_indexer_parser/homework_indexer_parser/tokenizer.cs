using Majestic12;
using mshtml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformationRetrieval
{
    public enum TokenSetting
    {
        none = 1,
        uppper,
        lower
    }

    public static class warc_spliter
    {
        public static int split(string file, Action<string> action)
        {
            int count = 0;
            if (action == null)
                return 0;
            using (var fstream = File.OpenRead(file))
            using (StreamReader reader = new StreamReader(fstream))
            {
                while (reader.Peek() != -1)
                {
                    //Find <HTML>
                    reader.ReadUntil("<html>");
                    //Find </HTML>
                    var artical = reader.ReadUntil("</html>");
                    action("<html>" + artical + "</html>");
                    ++count;
                }
            }
            return count;
        }
    }

    public static class html_tokenizer
    {
        static TokenSetting tokenSetting = TokenSetting.none;

        public static void SetTokenSetting(string ts)
        {
            switch (ts)
            {
                case "None":
                    tokenSetting = TokenSetting.none;
                    break;
                case "Case Folding (Upper)":
                    tokenSetting = TokenSetting.uppper;
                    break;
                case "Case Folding (Lower)":
                    tokenSetting = TokenSetting.lower;
                    break;
                default:
                    throw new Exception("this kind of token setting, " + ts + ", is invalid.");
            }
        }
        public static void tokenize(string file, Action<List<string>> action)
        {
            action(tokenize(file));
        }

        public static List<string> tokenize(string document)
        {
            HTMLparser p = new HTMLparser(document);
            List<string> tokens = new List<string>();

            while (true)
            {
                HTMLchunk chunk = p.ParseNext();
                if (chunk == null)
                    break;
                else
                {
                    if (chunk.oHTML != "")
                        tokens.AddRange(chunk.oHTML.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries));
                }
            }

            tokens = tokens
                .Select(x => new String(x.Where(Char.IsLetterOrDigit).ToArray()))
                .Where((s) => !String.IsNullOrEmpty(s)).ToList();

            switch (tokenSetting)
            {
                case TokenSetting.none:
                    break;
                case TokenSetting.uppper:
                    for (int i = 0; i < tokens.Count; i++)
                        tokens[i] = tokens[i].ToUpper();
                    break;
                case TokenSetting.lower:
                    for (int i = 0; i < tokens.Count; i++)
                        tokens[i] = tokens[i].ToLower();
                    break;
                default:
                    throw new InvalidEnumArgumentException("this token setting, " + tokenSetting + ", is invalid when converting tokens");
            }

            return tokens;
        }
    }
}
