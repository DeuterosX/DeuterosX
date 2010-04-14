namespace Teraluwide.Blackbird.Tools.XMLGenerator
{
    partial class MainForm
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.PathView = new System.Windows.Forms.TextBox();
            this.FolderBtn = new System.Windows.Forms.Button();
            this.ResultView = new System.Windows.Forms.TextBox();
            this.GenerateBtn = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PathView
            // 
            this.PathView.Location = new System.Drawing.Point(24, 28);
            this.PathView.Name = "PathView";
            this.PathView.ReadOnly = true;
            this.PathView.Size = new System.Drawing.Size(341, 20);
            this.PathView.TabIndex = 0;
            this.PathView.WordWrap = false;
            // 
            // FolderBtn
            // 
            this.FolderBtn.Location = new System.Drawing.Point(389, 28);
            this.FolderBtn.Name = "FolderBtn";
            this.FolderBtn.Size = new System.Drawing.Size(98, 20);
            this.FolderBtn.TabIndex = 1;
            this.FolderBtn.Text = "Choose folder";
            this.FolderBtn.UseVisualStyleBackColor = true;
            this.FolderBtn.Click += new System.EventHandler(this.FolderBtn_Click);
            // 
            // ResultView
            // 
            this.ResultView.Location = new System.Drawing.Point(24, 117);
            this.ResultView.Multiline = true;
            this.ResultView.Name = "ResultView";
            this.ResultView.ReadOnly = true;
            this.ResultView.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ResultView.Size = new System.Drawing.Size(463, 300);
            this.ResultView.TabIndex = 2;
            this.ResultView.WordWrap = false;
            // 
            // GenerateBtn
            // 
            this.GenerateBtn.Location = new System.Drawing.Point(24, 83);
            this.GenerateBtn.Name = "GenerateBtn";
            this.GenerateBtn.Size = new System.Drawing.Size(93, 28);
            this.GenerateBtn.TabIndex = 3;
            this.GenerateBtn.Text = "Generate";
            this.GenerateBtn.UseVisualStyleBackColor = true;
            this.GenerateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "XML file|*.xml|Any file|*.*";
            this.saveFileDialog1.ShowHelp = true;
            this.saveFileDialog1.SupportMultiDottedExtensions = true;
            this.saveFileDialog1.Title = "Save File";
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(389, 423);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(98, 34);
            this.SaveBtn.TabIndex = 4;
            this.SaveBtn.Text = "Save file";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 489);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.GenerateBtn);
            this.Controls.Add(this.ResultView);
            this.Controls.Add(this.FolderBtn);
            this.Controls.Add(this.PathView);
            this.Name = "MainForm";
            this.Text = "DeuterosX XML Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox PathView;
        private System.Windows.Forms.Button FolderBtn;
        private System.Windows.Forms.TextBox ResultView;
        private System.Windows.Forms.Button GenerateBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button SaveBtn;
    }
}

