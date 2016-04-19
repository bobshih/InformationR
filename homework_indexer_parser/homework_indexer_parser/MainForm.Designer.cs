﻿namespace InformationRetrieval
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
            this.Button_Start = new System.Windows.Forms.Button();
            this.ListBox_FileName = new System.Windows.Forms.ListBox();
            this.Button_AddFile = new System.Windows.Forms.Button();
            this.Button_RemoveFile = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Button_LoadList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Button_Start
            // 
            this.Button_Start.Location = new System.Drawing.Point(429, 214);
            this.Button_Start.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.ListBox_FileName.Location = new System.Drawing.Point(12, 68);
            this.ListBox_FileName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListBox_FileName.Name = "ListBox_FileName";
            this.ListBox_FileName.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListBox_FileName.Size = new System.Drawing.Size(320, 124);
            this.ListBox_FileName.TabIndex = 8;
            // 
            // Button_AddFile
            // 
            this.Button_AddFile.AutoSize = true;
            this.Button_AddFile.Location = new System.Drawing.Point(12, 12);
            this.Button_AddFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Button_AddFile.Name = "Button_AddFile";
            this.Button_AddFile.Size = new System.Drawing.Size(68, 38);
            this.Button_AddFile.TabIndex = 6;
            this.Button_AddFile.Text = "Add";
            this.Button_AddFile.UseVisualStyleBackColor = true;
            this.Button_AddFile.Click += new System.EventHandler(this.Button_AddFile_Clicked);
            // 
            // Button_RemoveFile
            // 
            this.Button_RemoveFile.AutoSize = true;
            this.Button_RemoveFile.Location = new System.Drawing.Point(96, 12);
            this.Button_RemoveFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Button_RemoveFile.Name = "Button_RemoveFile";
            this.Button_RemoveFile.Size = new System.Drawing.Size(72, 38);
            this.Button_RemoveFile.TabIndex = 6;
            this.Button_RemoveFile.Text = "Remove";
            this.Button_RemoveFile.UseVisualStyleBackColor = true;
            this.Button_RemoveFile.Click += new System.EventHandler(this.Button_RemoveFile_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(180, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 38);
            this.button1.TabIndex = 9;
            this.button1.Text = "SaveList";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button_SaveList_Click);
            // 
            // Button_LoadList
            // 
            this.Button_LoadList.AutoSize = true;
            this.Button_LoadList.Location = new System.Drawing.Point(264, 12);
            this.Button_LoadList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Button_LoadList.Name = "Button_LoadList";
            this.Button_LoadList.Size = new System.Drawing.Size(69, 38);
            this.Button_LoadList.TabIndex = 9;
            this.Button_LoadList.Text = "AddList";
            this.Button_LoadList.UseVisualStyleBackColor = true;
            this.Button_LoadList.Click += new System.EventHandler(this.Button_LoadList_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 359);
            this.Controls.Add(this.Button_LoadList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ListBox_FileName);
            this.Controls.Add(this.Button_RemoveFile);
            this.Controls.Add(this.Button_AddFile);
            this.Controls.Add(this.Button_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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

