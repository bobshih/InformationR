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
        public static void split(string file, Action<string> action)
        {
            if (action == null)
                return;
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
                }
            }
        }
    }

    public static class html_tokenizer
    {
        public static void tokenize(string file, Action<List<string>> action)
        {
            if (action == null)
                return;
            HTMLDocument doc = new HTMLDocument();
            IHTMLDocument2 doc2 = (IHTMLDocument2)doc;
            doc2.write(File.ReadAllText(file));

            var paralist = doc.getElementsByTagName("html");
            List<string> tokens = new List<string>();
            foreach (IHTMLElement element in paralist)
            {
                tokens.AddRange(element.innerText.Split(new char[] { '|', ' ', '\n', '\r', '\t', '(', ')' }, StringSplitOptions.RemoveEmptyEntries));
            }
            action(tokens);
        }
    }
}
