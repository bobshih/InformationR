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

        private async void TestFunction(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Timer clock = new Timer();
            clock.Interval = 3;
            clock.Tick += (s, ev) =>
            {
                TimeSpan timespan = timer.Elapsed;
                label1.Text = String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10);
            };
            timer.Start();
            clock.Start();
            await Task.Run(() => InnerTestFunction());
            clock.Stop();
            timer.Stop();
        }

        private void InnerTestFunction()
        {
            //UI
            InvodeUpdateButtonState(false, "Parsing...");

            //Read File
            SGMLReader reader = new SGMLReader();

            for (int i = 0; i <= 21; ++i)
            {
                reader.ReadFile("test\\reut2-" + String.Format("{0:000}", i) + ".sgm");
                InvokeUpdateProgressBar(22, i);
            }

            //UI
            InvodeUpdateButtonState(false, "Creating Index...");

            //Indexing
            Dictionary dictionary = new Dictionary();

            List<String> article;
            while ((article = reader.GetNext()) != null)
            {
                dictionary.AddArticle(article);
                InvokeUpdateProgressBar(reader.ProcessedArticleCount, reader.ProcessedArticleCount - reader.AvalibleArticleCount);
            }

            //UI
            InvodeUpdateButtonState(false, "Writting File...");
            InvokeUpdateProgressBar(100, 0);

            //Serialize
            dictionary.OutputFile();
            InvokeUpdateProgressBar(100, 50);

            //Creat Dictionary File
            InvodeUpdateButtonState(false, "Writing Dictionary");
            dictionary.OutputDictionary();
            InvokeUpdateProgressBar(100, 75);

            //UI
            InvodeUpdateButtonState(false, "Index Createed");
            InvokeUpdateProgressBar(100, 100);
        }

        private void InvodeUpdateButtonState(bool enable, string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => InvodeUpdateButtonState(enable, text)));
            }
            else
            {
                Button_Test.Text = text;
                Button_Test.Enabled = enable;
            }
        }

        private void InvokeUpdateProgressBar(int max, int current)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => InvokeUpdateProgressBar(max, current)));
            }
            else
            {
                progressBar1.Maximum = max;
                progressBar1.Value = current;
            }
        }
    }
}
