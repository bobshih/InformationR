namespace InformationRetrieval
{
    partial class QueryForm
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
            System.Windows.Forms.Label label1;
            this.input_querytext = new System.Windows.Forms.TextBox();
            this.button_query = new System.Windows.Forms.Button();
            this.button_queryWithBooleanOp = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label_directory = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.queryResultListBox = new System.Windows.Forms.ListBox();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ipnut_querytext
            // 
            this.input_querytext.Location = new System.Drawing.Point(82, 92);
            this.input_querytext.Name = "ipnut_querytext";
            this.input_querytext.Size = new System.Drawing.Size(275, 25);
            this.input_querytext.TabIndex = 0;
            // 
            // button_query
            // 
            this.button_query.Location = new System.Drawing.Point(97, 123);
            this.button_query.Name = "button_query";
            this.button_query.Size = new System.Drawing.Size(116, 46);
            this.button_query.TabIndex = 1;
            this.button_query.Text = "Query";
            this.button_query.UseVisualStyleBackColor = true;
            this.button_query.Click += new System.EventHandler(this.button_query_Click);
            // 
            // button_queryWithBooleanOp
            // 
            this.button_queryWithBooleanOp.Location = new System.Drawing.Point(219, 123);
            this.button_queryWithBooleanOp.Name = "button_queryWithBooleanOp";
            this.button_queryWithBooleanOp.Size = new System.Drawing.Size(116, 46);
            this.button_queryWithBooleanOp.TabIndex = 2;
            this.button_queryWithBooleanOp.Text = "BooleanQuery";
            this.button_queryWithBooleanOp.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 37);
            this.button1.TabIndex = 4;
            this.button1.Text = " OpenDirectory";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_directory
            // 
            this.label_directory.AutoSize = true;
            this.label_directory.Location = new System.Drawing.Point(12, 52);
            this.label_directory.Name = "label_directory";
            this.label_directory.Size = new System.Drawing.Size(66, 15);
            this.label_directory.TabIndex = 3;
            this.label_directory.Text = "directory :";
            // 
            // queryResultListBox
            // 
            this.queryResultListBox.FormattingEnabled = true;
            this.queryResultListBox.ItemHeight = 15;
            this.queryResultListBox.Location = new System.Drawing.Point(12, 193);
            this.queryResultListBox.Name = "queryResultListBox";
            this.queryResultListBox.Size = new System.Drawing.Size(345, 244);
            this.queryResultListBox.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 95);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(54, 15);
            label1.TabIndex = 6;
            label1.Text = "Query : ";
            // 
            // QueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 454);
            this.Controls.Add(label1);
            this.Controls.Add(this.queryResultListBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_directory);
            this.Controls.Add(this.button_queryWithBooleanOp);
            this.Controls.Add(this.button_query);
            this.Controls.Add(this.input_querytext);
            this.Name = "QueryForm";
            this.Text = "QueryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox input_querytext;
        private System.Windows.Forms.Button button_query;
        private System.Windows.Forms.Button button_queryWithBooleanOp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_directory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ListBox queryResultListBox;
    }
}