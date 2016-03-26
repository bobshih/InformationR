namespace homework_indexer_parser
{
    partial class Form1
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

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelForm = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView_FilePath = new System.Windows.Forms.DataGridView();
            this.column_FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_StartButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel_FileInput = new System.Windows.Forms.TableLayoutPanel();
            this.button_ChooseFile = new System.Windows.Forms.Button();
            this.button_ReadAllFiles = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_TimeSpan = new System.Windows.Forms.Label();
            this.label_State = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_FilePath)).BeginInit();
            this.tableLayoutPanel_FileInput.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(662, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tableLayoutPanelForm
            // 
            this.tableLayoutPanelForm.ColumnCount = 2;
            this.tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.78175F));
            this.tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.21825F));
            this.tableLayoutPanelForm.Controls.Add(this.dataGridView_FilePath, 0, 1);
            this.tableLayoutPanelForm.Controls.Add(this.tableLayoutPanel_FileInput, 0, 0);
            this.tableLayoutPanelForm.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.tableLayoutPanelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelForm.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanelForm.Name = "tableLayoutPanelForm";
            this.tableLayoutPanelForm.RowCount = 2;
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.37631F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.6237F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelForm.Size = new System.Drawing.Size(662, 263);
            this.tableLayoutPanelForm.TabIndex = 6;
            // 
            // dataGridView_FilePath
            // 
            this.dataGridView_FilePath.AllowUserToAddRows = false;
            this.dataGridView_FilePath.AllowUserToDeleteRows = false;
            this.dataGridView_FilePath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_FilePath.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_FilePath,
            this.Column_StartButton});
            this.dataGridView_FilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_FilePath.Location = new System.Drawing.Point(3, 46);
            this.dataGridView_FilePath.Name = "dataGridView_FilePath";
            this.dataGridView_FilePath.ReadOnly = true;
            this.dataGridView_FilePath.RowHeadersVisible = false;
            this.dataGridView_FilePath.RowTemplate.Height = 24;
            this.dataGridView_FilePath.Size = new System.Drawing.Size(376, 214);
            this.dataGridView_FilePath.TabIndex = 4;
            this.dataGridView_FilePath.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_FilePath_CellContentClick);
            // 
            // column_FilePath
            // 
            this.column_FilePath.HeaderText = "檔案路徑";
            this.column_FilePath.Name = "column_FilePath";
            this.column_FilePath.ReadOnly = true;
            this.column_FilePath.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.column_FilePath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.column_FilePath.Width = 200;
            // 
            // Column_StartButton
            // 
            this.Column_StartButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_StartButton.HeaderText = "開始解析";
            this.Column_StartButton.Name = "Column_StartButton";
            this.Column_StartButton.ReadOnly = true;
            this.Column_StartButton.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column_StartButton.Text = "開始解析";
            this.Column_StartButton.UseColumnTextForButtonValue = true;
            // 
            // tableLayoutPanel_FileInput
            // 
            this.tableLayoutPanel_FileInput.ColumnCount = 2;
            this.tableLayoutPanel_FileInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_FileInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tableLayoutPanel_FileInput.Controls.Add(this.button_ChooseFile, 0, 0);
            this.tableLayoutPanel_FileInput.Controls.Add(this.button_ReadAllFiles, 1, 0);
            this.tableLayoutPanel_FileInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_FileInput.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_FileInput.Name = "tableLayoutPanel_FileInput";
            this.tableLayoutPanel_FileInput.RowCount = 1;
            this.tableLayoutPanel_FileInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_FileInput.Size = new System.Drawing.Size(376, 37);
            this.tableLayoutPanel_FileInput.TabIndex = 5;
            // 
            // button_ChooseFile
            // 
            this.button_ChooseFile.Location = new System.Drawing.Point(3, 3);
            this.button_ChooseFile.Name = "button_ChooseFile";
            this.button_ChooseFile.Size = new System.Drawing.Size(111, 31);
            this.button_ChooseFile.TabIndex = 3;
            this.button_ChooseFile.Text = "選擇檔案";
            this.button_ChooseFile.UseVisualStyleBackColor = true;
            this.button_ChooseFile.Click += new System.EventHandler(this.button_ChooseFile_Click);
            // 
            // button_ReadAllFiles
            // 
            this.button_ReadAllFiles.Location = new System.Drawing.Point(217, 3);
            this.button_ReadAllFiles.Name = "button_ReadAllFiles";
            this.button_ReadAllFiles.Size = new System.Drawing.Size(111, 31);
            this.button_ReadAllFiles.TabIndex = 4;
            this.button_ReadAllFiles.Text = "讀全部的檔案";
            this.button_ReadAllFiles.UseVisualStyleBackColor = true;
            this.button_ReadAllFiles.Click += new System.EventHandler(this.button_ReadAllFiles_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(3, 99);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(268, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_TimeSpan, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_State, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(385, 46);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(274, 214);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label_TimeSpan
            // 
            this.label_TimeSpan.AutoSize = true;
            this.label_TimeSpan.Location = new System.Drawing.Point(3, 48);
            this.label_TimeSpan.Name = "label_TimeSpan";
            this.label_TimeSpan.Size = new System.Drawing.Size(47, 12);
            this.label_TimeSpan.TabIndex = 2;
            this.label_TimeSpan.Text = "00:00:00";
            // 
            // label_State
            // 
            this.label_State.AutoSize = true;
            this.label_State.Location = new System.Drawing.Point(3, 0);
            this.label_State.Name = "label_State";
            this.label_State.Size = new System.Drawing.Size(33, 12);
            this.label_State.TabIndex = 3;
            this.label_State.Text = "State: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 287);
            this.Controls.Add(this.tableLayoutPanelForm);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Information Retrieval";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanelForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_FilePath)).EndInit();
            this.tableLayoutPanel_FileInput.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelForm;
        private System.Windows.Forms.DataGridView dataGridView_FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_FilePath;
        private System.Windows.Forms.DataGridViewButtonColumn Column_StartButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_FileInput;
        private System.Windows.Forms.Button button_ChooseFile;
        private System.Windows.Forms.Button button_ReadAllFiles;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_TimeSpan;
        private System.Windows.Forms.Label label_State;
    }
}

