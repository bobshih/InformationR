using homework_indexer_parser.SimpleParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace homework_indexer_parser
{
    public partial class MainForm : Form
    {
        private PostProcessingChoice choice = PostProcessingChoice.NONE;

        public MainForm()
        {
            InitializeComponent();
            //Button_Test.Click += TestFunction;
        }

        #region UI CALLBACK
        private void Button_Start_Click(object sender, EventArgs e)
        {
            ProcessingForm pf = new ProcessingForm(ListBox_FileName.GetStringList(), choice);
            pf.ShowDialog();
        }

        private void Button_AddFile_Clicked(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.ValidateNames = true;
            dialog.CheckFileExists = true;
            var result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                ListBox_FileName.Items.AddRange(dialog.FileNames);
            }
            ListBox_FileName.RemoveDuplicate();
        }

        private void Button_RemoveFile_Click(object sender, EventArgs e)
        {
            while (ListBox_FileName.SelectedItems.Count != 0)
            {
                ListBox_FileName.Items.Remove(ListBox_FileName.SelectedItems[0]);
            }
        }

        private void Button_SaveList_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.CheckPathExists = true;
            dialog.OverwritePrompt = true;
            var result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    File.WriteAllLines(dialog.FileName, ListBox_FileName.GetStringList().ToArray());
                }
                catch (IOException)
                {
                    MessageBox.Show("Fail to write file", "WARNNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Button_LoadList_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.ValidateNames = true;
            dialog.CheckFileExists = true;
            var result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var path in dialog.FileNames)
                {
                    var files = ReadPathFromFile(path);
                    ListBox_FileName.Items.AddRange(files.ToArray());
                }
            }
            ListBox_FileName.RemoveDuplicate();
        }
        #endregion

        private List<string> ReadPathFromFile(string path)
        {
            string[] candidatePath;
            try
            {
                candidatePath = File.ReadAllLines(path);
            }
            catch (IOException)
            {
                MessageBox.Show("Read file '" + path + "' failed", "WARNNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new List<string>();
            }

            List<string> existPath = new List<string>();
            foreach (var p in candidatePath)
            {
                if (File.Exists(p))
                {
                    existPath.Add(p);
                }
            }

            return existPath;
        }
    }
}
