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
                label_TimeSpan.Text = String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10);
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
                label_State.Text = "State: " + text;
                //Button_Test.Text = text;
                //Button_Test.Enabled = enable;
                button_ChooseFile.Enabled = enable;
                button_ReadAllFiles.Enabled = enable;
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
        #endregion

        private void Button_Test_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var path in openFileDialog1.FileNames)
                {
                    //try

                    //Read(Parser)
                    //Process(Parser&Dictionary)

                    //catch "not good file"
                }
                /*Write To File*/
            }
        }

        private void button_ChooseFile_Click(object sender, EventArgs e)
        {
            // 開啟檔案選擇視窗
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String path in fileDialog.FileNames)
                {
                    if (!path.EndsWith(".warc"))
                    {
                        //MessageBox.Show(path + " 的檔案格式不是.marc", "檔案格式不符合");
                        continue;
                    }
                    dataGridView_FilePath.Rows.Add(path);

                    //try

                    //Read(Parser)
                    //Process(Parser&Dictionary)

                    //catch "not good file"
                }
                /*Write To File*/
            }
        }

        private void dataGridView_FilePath_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                //MessageBox.Show("here");
                MessageBox.Show(dataGridView_FilePath.Rows[e.RowIndex].Cells[0].Value.ToString());
                RunParsing(new List<String>(new String[] { dataGridView_FilePath.Rows[e.RowIndex].Cells[0].Value.ToString() }));
                //DataGridViewDisableButtonCell button = (DataGridViewDisableButtonCell)dataGridView_FilePath.Rows[e.RowIndex].Cells[];
                //button.Enabled = false;
            }
        }

        private void button_ReadAllFiles_Click(object sender, EventArgs e)
        {
            List<String> paths = new List<string>();
            for (int i = 0; i < dataGridView_FilePath.Rows.Count; i++)
            {
                paths.Add(dataGridView_FilePath.Rows[i].Cells[0].Value.ToString());
                //dataGridView_FilePath_CellContentClick(new object(), new DataGridViewCellEventArgs(1, i));
            }

            RunParsing(paths);
        }

    }
}
