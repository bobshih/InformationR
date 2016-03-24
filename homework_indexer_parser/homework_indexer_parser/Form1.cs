using homework_indexer_parser.DictionaryFolder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
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

        private async void button1_Click(object sender, EventArgs e)
        {
            Dictionary dictionary = new Dictionary();
            //List<String> temp = new List<String> { "to", "abc", "ggee", "apple", "to", "apple", "abc", "twrwer" };
            //dictionary.AddArticle(temp);

            //List<String> temp1 = new List<String> { "tor", "arbc", "gegee", "arpple", "tor", "awpwple", "aqbc", "twrwer" };
            //dictionary.AddArticle(temp1);
            //dictionary.OutputFile();
            homework_indexer_parser.ParserFolder.SGMLReader reader = new homework_indexer_parser.ParserFolder.SGMLReader();
            reader.ReadFile("test\\reut2-000.sgm");

            int articles = 0;
            Stopwatch timer = new Stopwatch();

            while (true)
            {
                timer.Start();

                List<String> article = reader.GetNext();
                if (article == null)
                {
                    break;
                }
                dictionary.SetArticle(article);
                await Task.Run(new Action(dictionary.AddArticle));
                
                articles++;
                timer.Stop();
                TimeSpan timespan = timer.Elapsed;
                label1.Text = String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10);
                progressBar1.Value = articles / 10;
            }
            dictionary.OutputFile();

        }
    }
}
