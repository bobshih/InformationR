namespace HTMLparserLibDotNet20
{
    partial class FileAndDirectoryPanel
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label_directory_novariable;
            System.Windows.Forms.Label label_filepath_novariable;
            this.panel_pathInput = new System.Windows.Forms.Panel();
            this.button_next = new System.Windows.Forms.Button();
            this.button_openDir = new System.Windows.Forms.Button();
            this.button_openFile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label_file = new System.Windows.Forms.Label();
            this.label_dir = new System.Windows.Forms.Label();
            label_directory_novariable = new System.Windows.Forms.Label();
            label_filepath_novariable = new System.Windows.Forms.Label();
            this.panel_pathInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_pathInput
            // 
            this.panel_pathInput.Controls.Add(this.label_dir);
            this.panel_pathInput.Controls.Add(this.label_file);
            this.panel_pathInput.Controls.Add(label_directory_novariable);
            this.panel_pathInput.Controls.Add(label_filepath_novariable);
            this.panel_pathInput.Controls.Add(this.button_next);
            this.panel_pathInput.Controls.Add(this.button_openDir);
            this.panel_pathInput.Controls.Add(this.button_openFile);
            this.panel_pathInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_pathInput.Location = new System.Drawing.Point(0, 0);
            this.panel_pathInput.Name = "panel_pathInput";
            this.panel_pathInput.Size = new System.Drawing.Size(429, 371);
            this.panel_pathInput.TabIndex = 1;
            // 
            // label_directory_novariable
            // 
            label_directory_novariable.AutoSize = true;
            label_directory_novariable.Location = new System.Drawing.Point(143, 149);
            label_directory_novariable.Name = "label_directory_novariable";
            label_directory_novariable.Size = new System.Drawing.Size(31, 15);
            label_directory_novariable.TabIndex = 2;
            label_directory_novariable.Text = "dir: ";
            // 
            // label_filepath_novariable
            // 
            label_filepath_novariable.AutoSize = true;
            label_filepath_novariable.Location = new System.Drawing.Point(143, 76);
            label_filepath_novariable.Name = "label_filepath_novariable";
            label_filepath_novariable.Size = new System.Drawing.Size(34, 15);
            label_filepath_novariable.TabIndex = 2;
            label_filepath_novariable.Text = "file: ";
            // 
            // button_next
            // 
            this.button_next.Location = new System.Drawing.Point(217, 227);
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
            // button_openFile
            // 
            this.button_openFile.Location = new System.Drawing.Point(23, 63);
            this.button_openFile.Name = "button_openFile";
            this.button_openFile.Size = new System.Drawing.Size(97, 40);
            this.button_openFile.TabIndex = 0;
            this.button_openFile.Text = "File";
            this.button_openFile.UseVisualStyleBackColor = true;
            this.button_openFile.Click += new System.EventHandler(this.button_openFile_Click);
            // 
            // label_file
            // 
            this.label_file.AutoSize = true;
            this.label_file.Location = new System.Drawing.Point(180, 76);
            this.label_file.Name = "label_file";
            this.label_file.Size = new System.Drawing.Size(41, 15);
            this.label_file.TabIndex = 3;
            this.label_file.Text = "label1";
            // 
            // label_dir
            // 
            this.label_dir.AutoSize = true;
            this.label_dir.Location = new System.Drawing.Point(180, 149);
            this.label_dir.Name = "label_dir";
            this.label_dir.Size = new System.Drawing.Size(41, 15);
            this.label_dir.TabIndex = 4;
            this.label_dir.Text = "label2";
            // 
            // FileAndDirectoryPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panel_pathInput);
            this.Name = "FileAndDirectoryPanel";
            this.Size = new System.Drawing.Size(429, 371);
            this.panel_pathInput.ResumeLayout(false);
            this.panel_pathInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_pathInput;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Button button_openDir;
        private System.Windows.Forms.Button button_openFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label_dir;
        private System.Windows.Forms.Label label_file;

    }
}
