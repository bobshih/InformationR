using homework_indexer_parser.DictionaryFolder;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace homework_indexer_parser
{
    public partial class ProcessingForm : Form
    {
        #region Event Handler

        public enum MessageType
        {
            ERROR,
            WARNNING,
            NOTICE
        };
        public event Action<Dictionary> Successed;
        public event Action<MessageType, string> MessageHandler;

        #endregion

        private List<string> targetFiles;

        #region Constructors

        private ProcessingForm()
        {
            InitializeComponent();
        }

        public ProcessingForm(List<string> fileNames)
            : this()
        {
            targetFiles = fileNames;
        }

        #endregion

        #region State Change Functions

        /// <summary>
        /// Start Process Files
        /// </summary>
        public void Start()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Start Process Files
        /// </summary>
        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
