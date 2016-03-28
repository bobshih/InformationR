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
            //Button_Test.Click += TestFunction;
        }

        #region somthing useful...
        private async void RunParsing(List<String> path)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Timer clock = new Timer();
            clock.Interval = 3;
            clock.Tick += (s, ev) =>
            {
                TimeSpan timespan = timer.Elapsed;
            };
            timer.Start();
            clock.Start();
            await Task.Run(() => Parse(path));
            clock.Stop();
            timer.Stop();
        }


        private void Parse(List<String> path)
        {
            //UI
            InvodeUpdateButtonState(false, "Parsing...");

            //Read File
            WARCReader reader = new WARCReader();

            for (int i = 0; i < path.Count; ++i)
            {
                reader.ReadFile(path[i]);
                //reader.ReadFile("test\\reut2-" + String.Format("{0:000}", i) + ".sgm");
                InvokeUpdateProgressBar(22, i);
            }

            if (reader.ProcessedArticleCount == 0)
                throw new NotImplementedException("reader not read anything yet");

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
            }
        }
        #endregion

        private void ParseFile(string path)
        {

        }

        private void Button_Start_Click(object sender, EventArgs e)
        {
            
        }

        private void Button_AddFile_Clicked(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.ValidateNames = true;
            dialog.CheckFileExists = true;
            var result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                ParseFile(dialog.FileName);
            }
        }

        private void Button_RemoveFile_Click(object sender, EventArgs e)
        {

        }

    }
}
