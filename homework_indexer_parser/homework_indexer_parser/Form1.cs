using homework_indexer_parser.DictionaryFolder;
using homework_indexer_parser.ParserFolder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework_indexer_parser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Button_Test.Click += TestFunction;
        }

        private void UpdateButtonState(bool enable, string text)
        {
            Button_Test.Text = text;
            Button_Test.Enabled = enable;
        }

        private async void TestFunction(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            //Diable Button
            MethodInvoker invokerBegin = delegate()
            {
                UpdateButtonState(false, "Parsing...");
            };
            this.Invoke(invokerBegin);

            //Read File
            SGMLReader reader = new SGMLReader();
            reader.ReadFile("test\\reut2-000.sgm");

            //UI
            MethodInvoker invokerDictionary = delegate()
            {
                UpdateButtonState(false, "Creating Index...");
            };
            this.Invoke(invokerDictionary);

            //Indexing
            Dictionary dictionary = new Dictionary();

            List<String> article;
            while ((article = reader.GetNext()) != null)
            {
                await Task.Run(() => dictionary.AddArticle(article));

                TimeSpan timespan = timer.Elapsed;
                label1.Text = String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10);
                progressBar1.Maximum = reader.ProcessedArticleCount;
                progressBar1.Value = reader.ProcessedArticleCount - reader.AvalibleArticleCount;
            }

            //UI
            MethodInvoker invokerOutput = delegate()
            {
                UpdateButtonState(false, "Writting File...");
            };
            this.Invoke(invokerOutput);
            
            //Serialize
            dictionary.OutputFile();

            //UI
            MethodInvoker invokerend = delegate()
            {
                UpdateButtonState(false, "Index Createed");
            };
            this.Invoke(invokerend);
            timer.Stop();
        }
    }
}
