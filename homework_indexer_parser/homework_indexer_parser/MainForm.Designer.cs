namespace homework_indexer_parser
{
    partial class MainForm
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
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            this.Button_Start = new System.Windows.Forms.Button();
            this.ListBox_FileName = new System.Windows.Forms.ListBox();
            this.Button_AddFile = new System.Windows.Forms.Button();
            this.Button_RemoveFile = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Button_LoadList = new System.Windows.Forms.Button();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Location = new System.Drawing.Point(304, 33);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new System.Drawing.Size(273, 105);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // Button_Start
            // 
            this.Button_Start.Location = new System.Drawing.Point(322, 171);
            this.Button_Start.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Button_Start.Name = "Button_Start";
            this.Button_Start.Size = new System.Drawing.Size(99, 89);
            this.Button_Start.TabIndex = 6;
            this.Button_Start.Text = "Start";
            this.Button_Start.UseVisualStyleBackColor = true;
            this.Button_Start.Click += new System.EventHandler(this.Button_Start_Click);
            // 
            // ListBox_FileName
            // 
            this.ListBox_FileName.FormattingEnabled = true;
            this.ListBox_FileName.HorizontalScrollbar = true;
            this.ListBox_FileName.ItemHeight = 12;
            this.ListBox_FileName.Location = new System.Drawing.Point(9, 54);
            this.ListBox_FileName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ListBox_FileName.Name = "ListBox_FileName";
            this.ListBox_FileName.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListBox_FileName.Size = new System.Drawing.Size(241, 100);
            this.ListBox_FileName.TabIndex = 8;
            // 
            // Button_AddFile
            // 
            this.Button_AddFile.AutoSize = true;
            this.Button_AddFile.Location = new System.Drawing.Point(9, 10);
            this.Button_AddFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Button_AddFile.Name = "Button_AddFile";
            this.Button_AddFile.Size = new System.Drawing.Size(51, 30);
            this.Button_AddFile.TabIndex = 6;
            this.Button_AddFile.Text = "Add";
            this.Button_AddFile.UseVisualStyleBackColor = true;
            this.Button_AddFile.Click += new System.EventHandler(this.Button_AddFile_Clicked);
            // 
            // Button_RemoveFile
            // 
            this.Button_RemoveFile.AutoSize = true;
            this.Button_RemoveFile.Location = new System.Drawing.Point(72, 10);
            this.Button_RemoveFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Button_RemoveFile.Name = "Button_RemoveFile";
            this.Button_RemoveFile.Size = new System.Drawing.Size(54, 30);
            this.Button_RemoveFile.TabIndex = 6;
            this.Button_RemoveFile.Text = "Remove";
            this.Button_RemoveFile.UseVisualStyleBackColor = true;
            this.Button_RemoveFile.Click += new System.EventHandler(this.Button_RemoveFile_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(135, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 30);
            this.button1.TabIndex = 9;
            this.button1.Text = "SaveList";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button_SaveList_Click);
            // 
            // Button_LoadList
            // 
            this.Button_LoadList.AutoSize = true;
            this.Button_LoadList.Location = new System.Drawing.Point(198, 10);
            this.Button_LoadList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Button_LoadList.Name = "Button_LoadList";
            this.Button_LoadList.Size = new System.Drawing.Size(52, 30);
            this.Button_LoadList.TabIndex = 9;
            this.Button_LoadList.Text = "AddList";
            this.Button_LoadList.UseVisualStyleBackColor = true;
            this.Button_LoadList.Click += new System.EventHandler(this.Button_LoadList_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 287);
            this.Controls.Add(this.Button_LoadList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ListBox_FileName);
            this.Controls.Add(tableLayoutPanel1);
            this.Controls.Add(this.Button_RemoveFile);
            this.Controls.Add(this.Button_AddFile);
            this.Controls.Add(this.Button_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Information Retrieval";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_Start;
        private System.Windows.Forms.ListBox ListBox_FileName;
        private System.Windows.Forms.Button Button_AddFile;
        private System.Windows.Forms.Button Button_RemoveFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Button_LoadList;

    }
}

