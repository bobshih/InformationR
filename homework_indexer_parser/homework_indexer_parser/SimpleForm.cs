﻿using System;
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
    public partial class SimpleForm : Form
    {
        public SimpleForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            label1.Text = openFileDialog.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            if (Directory.EnumerateFileSystemEntries(folderBrowserDialog.SelectedPath).Any())
            {
                label2.Text = "NOT EMPTY";
            }
            else
                label2.Text = folderBrowserDialog.SelectedPath+"\\";
        }

        int currentFile = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            var path = label2.Text;//  +"\\record_block";
            // Directory.CreateDirectory(path);
            warc_spliter.split(label1.Text, (string s) => File.WriteAllText(path + (this.currentFile++).ToString() + ".record_block.txt", s));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var path = label2.Text;
            for (int i = 0; i < currentFile; ++i)
            {
                html_tokenizer.tokenize(path + i.ToString() + ".record_block.txt", (List<string> ls) =>
                    File.WriteAllLines(path + i.ToString() + ".tokenized.txt", ls));
            }
        }
    }
}
