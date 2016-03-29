using homework_indexer_parser.DictionaryFolder;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace homework_indexer_parser
{
    public partial class ProcessingForm : Form
    {
        private ProcessingClass pclass;

        #region Constructors

        private ProcessingForm()
        {
            InitializeComponent();
        }

        public ProcessingForm(List<string> fileNames)
            : this()
        {
            pclass = new ProcessingClass(fileNames);
        }

        #endregion

        #region State Change Functions

        /// <summary>
        /// Start Process Files
        /// </summary>
        private void Start()
        {
            pclass.Start();
        }

        /// <summary>
        /// Start Process Files
        /// </summary>
        private void Pause()
        {
            pclass.Suspend();
        }

        /// <summary>
        /// Start Process Files
        /// </summary>
        private void Resumn()
        {
            pclass.Resume();
        }

        /// <summary>
        /// Cancel Process
        /// </summary>
        private void Cancel()
        {
            pclass.Stop();
        }

        #endregion

        private void ProcessingForm_Load(object sender, EventArgs e)
        {
            pclass.Start();
        }


    }
}
