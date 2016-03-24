using homework_indexer_parser.DictionaryFolder;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace homework_indexer_parser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary dictionary = new Dictionary();
            //List<String> temp = new List<String> { "to", "abc", "ggee", "apple", "to", "apple", "abc", "twrwer" };
            //dictionary.AddArticle(temp);

            //List<String> temp1 = new List<String> { "tor", "arbc", "gegee", "arpple", "tor", "awpwple", "aqbc", "twrwer" };
            //dictionary.AddArticle(temp1);
            //dictionary.OutputFile();
            homework_indexer_parser.ParserFolder.SGMLReader reader = new homework_indexer_parser.ParserFolder.SGMLReader();
            reader.ReadFile("test\\reut2-000.sgm");
            while (true)
            {
                List<String> article = reader.GetNext();
                if (article == null)
                {
                    break;
                }
                dictionary.SetArticle(article);
                Thread Adder = new Thread(dictionary.AddArticle);
                Adder.Start();
                Thread.Sleep(10);
                Adder.Join();
                //dictionary.AddArticle(article);
            }
            dictionary.OutputFile();

        }
    }
}
