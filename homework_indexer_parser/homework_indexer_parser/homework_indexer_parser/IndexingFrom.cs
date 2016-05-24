using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformationRetrieval
{
    public partial class IndexingFrom : Form
    {
        public IndexingFrom()
        {
            InitializeComponent();
            fileAndDirectoryPanel.NextButtonClicked += button_next_Click;
        }

        IndexingClass pc;
        private void button_next_Click()
        {
            fileAndDirectoryPanel.Enabled = false;
            string path = fileAndDirectoryPanel.Directory;
            string warc = fileAndDirectoryPanel.File;
            pc = new IndexingClass(warc, new DirectoryOrganizer(path), fileAndDirectoryPanel.TokenSetting);
            pc.MessageHandler += (msg, str) =>
            {
                Invoke(new Action(() =>
                {
                    //if (msg != IndexingClass.MessageType.NOTICE_SMALL)
                    listBox1.Items.Add(str);
                    label_currentState.Text = str;
                    //listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    //listBox1.SelectedIndex = -1;
                }));
            };
            pc.ProcessEndHandler += (b) => Invoke(new Action(() => fileAndDirectoryPanel.Enabled = true));
            pc.Start();
        }

        private void IndexingFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            fileAndDirectoryPanel.NextButtonClicked -= button_next_Click;
            if (pc != null)
                pc.Stop();
            if (Application.OpenForms.Count == 1)
            {
                Application.Exit();
            }
        }
    }
}
