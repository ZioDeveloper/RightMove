namespace RightMove
{
    partial class frmMain
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
            this.cmdLoad = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtFileContent = new System.Windows.Forms.TextBox();
            this.cmdParse2 = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.chkCopyFile = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmdLoad
            // 
            this.cmdLoad.Location = new System.Drawing.Point(13, 13);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(75, 24);
            this.cmdLoad.TabIndex = 0;
            this.cmdLoad.Text = "Load file";
            this.cmdLoad.UseVisualStyleBackColor = true;
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(108, 23);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(16, 13);
            this.lblFileName.TabIndex = 1;
            this.lblFileName.Text = "...";
            // 
            // txtFileContent
            // 
            this.txtFileContent.Location = new System.Drawing.Point(13, 53);
            this.txtFileContent.Multiline = true;
            this.txtFileContent.Name = "txtFileContent";
            this.txtFileContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFileContent.Size = new System.Drawing.Size(443, 129);
            this.txtFileContent.TabIndex = 2;
            // 
            // cmdParse2
            // 
            this.cmdParse2.Location = new System.Drawing.Point(381, 13);
            this.cmdParse2.Name = "cmdParse2";
            this.cmdParse2.Size = new System.Drawing.Size(75, 24);
            this.cmdParse2.TabIndex = 4;
            this.cmdParse2.Text = "Parse file";
            this.cmdParse2.UseVisualStyleBackColor = true;
            this.cmdParse2.Click += new System.EventHandler(this.cmdParse2_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(381, 191);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(75, 24);
            this.cmdExit.TabIndex = 5;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // chkCopyFile
            // 
            this.chkCopyFile.AutoSize = true;
            this.chkCopyFile.Checked = true;
            this.chkCopyFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyFile.Location = new System.Drawing.Point(13, 189);
            this.chkCopyFile.Name = "chkCopyFile";
            this.chkCopyFile.Size = new System.Drawing.Size(83, 17);
            this.chkCopyFile.TabIndex = 6;
            this.chkCopyFile.Text = "Create copy";
            this.chkCopyFile.UseVisualStyleBackColor = true;
            this.chkCopyFile.CheckedChanged += new System.EventHandler(this.chkCopyFile_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 226);
            this.Controls.Add(this.chkCopyFile);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdParse2);
            this.Controls.Add(this.txtFileContent);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.cmdLoad);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.Text = "Do the right mov !";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdLoad;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtFileContent;
        private System.Windows.Forms.Button cmdParse2;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.CheckBox chkCopyFile;
    }
}

