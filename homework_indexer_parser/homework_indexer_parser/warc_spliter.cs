using mshtml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationRetrieval
{
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
        public static void tokenize(string file, Action<List<string>> action)
        {
            action(tokenize(file));
        }

        public static List<string> tokenize(string file)
        {
            HTMLDocument doc = new HTMLDocument();
            IHTMLDocument2 doc2 = (IHTMLDocument2)doc;
            doc2.write(File.ReadAllText(file));

            var paralist = doc.getElementsByTagName("html");
            List<string> tokens = new List<string>();
            foreach (IHTMLElement element in paralist)
            {
                tokens.AddRange(element.innerText.Split(new char[] { '|', ' ', '\n', '\r', '\t', '(', ')' }, StringSplitOptions.RemoveEmptyEntries));
            }
            return (tokens);
        }
    }
}
