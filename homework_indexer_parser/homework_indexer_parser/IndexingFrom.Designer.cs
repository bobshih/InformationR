namespace InformationRetrieval
{
    partial class IndexingFrom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_pathInput = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label_directory = new System.Windows.Forms.Label();
            this.label_filepath = new System.Windows.Forms.Label();
            this.button_next = new System.Windows.Forms.Button();
            this.button_openDir = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label_currentState = new System.Windows.Forms.Label();
            this.panel_pathInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_pathInput
            // 
            this.panel_pathInput.Controls.Add(this.label_currentState);
            this.panel_pathInput.Controls.Add(this.listBox1);
            this.panel_pathInput.Controls.Add(this.label_directory);
            this.panel_pathInput.Controls.Add(this.label_filepath);
            this.panel_pathInput.Controls.Add(this.button_next);
            this.panel_pathInput.Controls.Add(this.button_openDir);
            this.panel_pathInput.Controls.Add(this.button1);
            this.panel_pathInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_pathInput.Location = new System.Drawing.Point(0, 0);
            this.panel_pathInput.Name = "panel_pathInput";
            this.panel_pathInput.Size = new System.Drawing.Size(927, 361);
            this.panel_pathInput.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(508, 23);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(407, 319);
            this.listBox1.TabIndex = 3;
            // 
            // label_directory
            // 
            this.label_directory.AutoSize = true;
            this.label_directory.Location = new System.Drawing.Point(143, 149);
            this.label_directory.Name = "label_directory";
            this.label_directory.Size = new System.Drawing.Size(31, 15);
            this.label_directory.TabIndex = 2;
            this.label_directory.Text = "dir: ";
            // 
            // label_filepath
            // 
            this.label_filepath.AutoSize = true;
            this.label_filepath.Location = new System.Drawing.Point(143, 76);
            this.label_filepath.Name = "label_filepath";
            this.label_filepath.Size = new System.Drawing.Size(34, 15);
            this.label_filepath.TabIndex = 2;
            this.label_filepath.Text = "file: ";
            // 
            // button_next
            // 
            this.button_next.Location = new System.Drawing.Point(335, 263);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(165, 86);
            this.button_next.TabIndex = 1;
            this.button_next.Text = "NEXT";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // button_openDir
            // 
            this.button_openDir.Location = new System.Drawing.Point(23, 136);
            this.button_openDir.Name = "button_openDir";
            this.button_openDir.Size = new System.Drawing.Size(97, 40);
            this.button_openDir.TabIndex = 1;
            this.button_openDir.Text = "Directory";
            this.button_openDir.UseVisualStyleBackColor = true;
            this.button_openDir.Click += new System.EventHandler(this.button_openDir_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.openFile_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Title = "Open A Warc File";
            // 
            // label_currentState
            // 
            this.label_currentState.AutoSize = true;
            this.label_currentState.Location = new System.Drawing.Point(23, 263);
            this.label_currentState.Name = "label_currentState";
            this.label_currentState.Size = new System.Drawing.Size(41, 15);
            this.label_currentState.TabIndex = 4;
            this.label_currentState.Text = "label1";
            // 
            // IndexingFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 361);
            this.Controls.Add(this.panel_pathInput);
            this.Name = "IndexingFrom";
            this.Text = "IndexingFrom";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IndexingFrom_FormClosing);
            this.panel_pathInput.ResumeLayout(false);
            this.panel_pathInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_pathInput;
        private System.Windows.Forms.Label label_directory;
        private System.Windows.Forms.Label label_filepath;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Button button_openDir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label_currentState;
    }
}