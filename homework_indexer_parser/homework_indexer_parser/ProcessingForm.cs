using homework_indexer_parser.SimpleParser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace homework_indexer_parser
{
    public partial class ProcessingForm : Form
    {
        private ProcessingClass pclass;

        private List<String> files;
        private int currentFile;
        private Stopwatch stopwatch_Total;
        private Stopwatch stopwatch_current;
        private bool _pause = false;
        private bool Pause
        {
            get
            {
                return _pause;
            }
            set
            {
                _pause = value;
                Button_CancelOrOK.Text = value ? "Pause" : "Resume";
            }
        }

        #region Constructors

        private ProcessingForm()
        {
            InitializeComponent();
        }

        public ProcessingForm(List<string> fileNames, PostProcessingChoice choice)
            : this()
        {
            files = fileNames;
            currentFile = 0;
            pclass = new ProcessingClass(fileNames, choice);
            InitializeTimer();

            pclass.ProcessEndHandler += (dictionary) =>
            {
                dictionary.OutputDictionary();
                dictionary.OutputFile();
                AfterProcess();
            };
        }

        #endregion

        /// <summary>
        /// 初始化計時器
        /// </summary>
        private void InitializeTimer()
        {
            timer.Interval = 500;
            timer.Enabled = true;
            // start stopwatch
            stopwatch_current.Stop();
            stopwatch_current.Reset();
            stopwatch_current.Start();
            stopwatch_Total = new Stopwatch();
            stopwatch_Total.Reset();
            stopwatch_Total.Start();

            timer.Tick += new EventHandler(CheckProgress);
        }

        /// <summary>
        /// 計時器事件
        /// </summary>
        private void CheckProgress(object obj, EventArgs e)
        {
            // 設定porgress bar
            ProgressBar_TotalPrograss.Value = pclass.DoneFIlesCount * 100 / files.Count;
            ProgressBar_CurrentProgress.Value = pclass.Progress;
            // 顯示經過時間
            Label_TotalTime.Text = stopwatch_Total.Elapsed.ToString(@"hh\:mm\:ss");
            if (pclass.DoneFIlesCount != currentFile)
            {
                currentFile = pclass.DoneFIlesCount;
                stopwatch_current.Stop();
                stopwatch_current.Reset();
                stopwatch_current.Start();
            }
            Label_CurrentTimeComsumed.Text = stopwatch_current.Elapsed.ToString(@"hh\.mm:\:ss");
            // 顯示目前檔案
            String[] filePath = files[currentFile].Split(new char[] { '\\' });
            int ends = filePath.Length;
            Label_CurrentFile.Text = filePath[ends];
        }

        private void AfterProcess()
        {
            if (InvokeRequired)
            {
                Invoke((Action)AfterProcess);
                return;
            }

            Button_OK.Show();
            Button_CancelOrOK.Hide();
        }

        private void ProcessingForm_Load(object sender, EventArgs e)
        {
            pclass.Start();
            _pause = false;
            Button_OK.Visible = false;
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
