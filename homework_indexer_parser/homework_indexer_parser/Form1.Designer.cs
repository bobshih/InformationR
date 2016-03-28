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
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            this.Button_Start = new System.Windows.Forms.Button();
            this.ListBox_FileName = new System.Windows.Forms.ListBox();
            this.Button_AddFile = new System.Windows.Forms.Button();
            this.Button_RemoveFile = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Location = new System.Drawing.Point(417, 31);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new System.Drawing.Size(348, 131);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // Button_Start
            // 
            this.Button_Start.Location = new System.Drawing.Point(429, 214);
            this.Button_Start.Name = "Button_Start";
            this.Button_Start.Size = new System.Drawing.Size(132, 111);
            this.Button_Start.TabIndex = 6;
            this.Button_Start.Text = "Start";
            this.Button_Start.UseVisualStyleBackColor = true;
            this.Button_Start.Click += new System.EventHandler(this.Button_Start_Click);
            // 
            // ListBox_FileName
            // 
            this.ListBox_FileName.FormattingEnabled = true;
            this.ListBox_FileName.HorizontalScrollbar = true;
            this.ListBox_FileName.ItemHeight = 15;
            this.ListBox_FileName.Location = new System.Drawing.Point(42, 67);
            this.ListBox_FileName.MultiColumn = true;
            this.ListBox_FileName.Name = "ListBox_FileName";
            this.ListBox_FileName.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListBox_FileName.Size = new System.Drawing.Size(290, 109);
            this.ListBox_FileName.TabIndex = 8;
            // 
            // Button_AddFile
            // 
            this.Button_AddFile.Location = new System.Drawing.Point(42, 12);
            this.Button_AddFile.Name = "Button_AddFile";
            this.Button_AddFile.Size = new System.Drawing.Size(68, 38);
            this.Button_AddFile.TabIndex = 6;
            this.Button_AddFile.Text = "Add";
            this.Button_AddFile.UseVisualStyleBackColor = true;
            this.Button_AddFile.Click += new System.EventHandler(this.Button_AddFile_Clicked);
            // 
            // Button_RemoveFile
            // 
            this.Button_RemoveFile.Location = new System.Drawing.Point(116, 12);
            this.Button_RemoveFile.Name = "Button_RemoveFile";
            this.Button_RemoveFile.Size = new System.Drawing.Size(68, 38);
            this.Button_RemoveFile.TabIndex = 6;
            this.Button_RemoveFile.Text = "Remove";
            this.Button_RemoveFile.UseVisualStyleBackColor = true;
            this.Button_RemoveFile.Click += new System.EventHandler(this.Button_RemoveFile_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(190, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 38);
            this.button1.TabIndex = 9;
            this.button1.Text = "SaveList";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(264, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 38);
            this.button2.TabIndex = 9;
            this.button2.Text = "AddList";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 359);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ListBox_FileName);
            this.Controls.Add(tableLayoutPanel1);
            this.Controls.Add(this.Button_RemoveFile);
            this.Controls.Add(this.Button_AddFile);
            this.Controls.Add(this.Button_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Information Retrieval";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_Start;
        private System.Windows.Forms.ListBox ListBox_FileName;
        private System.Windows.Forms.Button Button_AddFile;
        private System.Windows.Forms.Button Button_RemoveFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;

    }
}

