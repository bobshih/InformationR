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
}
