﻿namespace Teraluwide.Blackbird.DataEditor
{
    partial class TileSetUI
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openTileSetFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFileSelect = new System.Windows.Forms.Button();
            this.pictureBoxTileSet = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelImageSize = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownTileWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTileHeight = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelHorzTiles = new System.Windows.Forms.Label();
            this.labelVertTiles = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownTileX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTileY = new System.Windows.Forms.NumericUpDown();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxTileSetName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownTileSetViewScale = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPreviewViewScale = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileSetViewScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPreviewViewScale)).BeginInit();
            this.SuspendLayout();
            // 
            // openTileSetFileDialog
            // 
            this.openTileSetFileDialog.FileName = "openFileDialog1";
            this.openTileSetFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openTileSetFileDialog_FileOk);
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(96, 43);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.ReadOnly = true;
            this.textBoxFileName.Size = new System.Drawing.Size(379, 20);
            this.textBoxFileName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnFileSelect
            // 
            this.btnFileSelect.Location = new System.Drawing.Point(481, 41);
            this.btnFileSelect.Name = "btnFileSelect";
            this.btnFileSelect.Size = new System.Drawing.Size(75, 23);
            this.btnFileSelect.TabIndex = 5;
            this.btnFileSelect.Text = "Select";
            this.btnFileSelect.UseVisualStyleBackColor = true;
            this.btnFileSelect.Click += new System.EventHandler(this.btnFileSelect_Click);
            // 
            // pictureBoxTileSet
            // 
            this.pictureBoxTileSet.InitialImage = null;
            this.pictureBoxTileSet.Location = new System.Drawing.Point(222, 94);
            this.pictureBoxTileSet.Name = "pictureBoxTileSet";
            this.pictureBoxTileSet.Size = new System.Drawing.Size(153, 157);
            this.pictureBoxTileSet.TabIndex = 0;
            this.pictureBoxTileSet.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Size:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelImageSize
            // 
            this.labelImageSize.AutoSize = true;
            this.labelImageSize.Location = new System.Drawing.Point(52, 70);
            this.labelImageSize.Name = "labelImageSize";
            this.labelImageSize.Size = new System.Drawing.Size(78, 13);
            this.labelImageSize.TabIndex = 8;
            this.labelImageSize.Text = "labelImageSize";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tile width";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDownTileWidth
            // 
            this.numericUpDownTileWidth.Enabled = false;
            this.numericUpDownTileWidth.Location = new System.Drawing.Point(78, 140);
            this.numericUpDownTileWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownTileWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTileWidth.Name = "numericUpDownTileWidth";
            this.numericUpDownTileWidth.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownTileWidth.TabIndex = 10;
            this.numericUpDownTileWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTileWidth.ValueChanged += new System.EventHandler(this.numericUpDownTileWidth_ValueChanged);
            // 
            // numericUpDownTileHeight
            // 
            this.numericUpDownTileHeight.Enabled = false;
            this.numericUpDownTileHeight.Location = new System.Drawing.Point(78, 164);
            this.numericUpDownTileHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownTileHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTileHeight.Name = "numericUpDownTileHeight";
            this.numericUpDownTileHeight.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownTileHeight.TabIndex = 11;
            this.numericUpDownTileHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTileHeight.ValueChanged += new System.EventHandler(this.numericUpDownTileHeight_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tile height";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Horizontal tiles:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelHorzTiles
            // 
            this.labelHorzTiles.AutoSize = true;
            this.labelHorzTiles.Location = new System.Drawing.Point(100, 94);
            this.labelHorzTiles.Name = "labelHorzTiles";
            this.labelHorzTiles.Size = new System.Drawing.Size(73, 13);
            this.labelHorzTiles.TabIndex = 14;
            this.labelHorzTiles.Text = "labelHorzTiles";
            // 
            // labelVertTiles
            // 
            this.labelVertTiles.AutoSize = true;
            this.labelVertTiles.Location = new System.Drawing.Point(100, 118);
            this.labelVertTiles.Name = "labelVertTiles";
            this.labelVertTiles.Size = new System.Drawing.Size(70, 13);
            this.labelVertTiles.TabIndex = 15;
            this.labelVertTiles.Text = "labelVertTiles";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Vertical tiles:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Tile X";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 214);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Tile Y";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDownTileX
            // 
            this.numericUpDownTileX.Enabled = false;
            this.numericUpDownTileX.Location = new System.Drawing.Point(78, 188);
            this.numericUpDownTileX.Name = "numericUpDownTileX";
            this.numericUpDownTileX.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownTileX.TabIndex = 19;
            this.numericUpDownTileX.ValueChanged += new System.EventHandler(this.numericUpDownTileX_ValueChanged);
            // 
            // numericUpDownTileY
            // 
            this.numericUpDownTileY.Enabled = false;
            this.numericUpDownTileY.Location = new System.Drawing.Point(78, 212);
            this.numericUpDownTileY.Name = "numericUpDownTileY";
            this.numericUpDownTileY.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownTileY.TabIndex = 20;
            this.numericUpDownTileY.ValueChanged += new System.EventHandler(this.numericUpDownTileY_ValueChanged);
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.InitialImage = null;
            this.pictureBoxPreview.Location = new System.Drawing.Point(19, 310);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(106, 63);
            this.pictureBoxPreview.TabIndex = 21;
            this.pictureBoxPreview.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 286);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Tile preview:";
            // 
            // textBoxTileSetName
            // 
            this.textBoxTileSetName.Location = new System.Drawing.Point(96, 17);
            this.textBoxTileSetName.Name = "textBoxTileSetName";
            this.textBoxTileSetName.Size = new System.Drawing.Size(379, 20);
            this.textBoxTileSetName.TabIndex = 23;
            this.textBoxTileSetName.Validated += new System.EventHandler(this.textBoxTileSetName_Validated);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Tile set name";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 238);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "TileSet view scale";
            // 
            // numericUpDownTileSetViewScale
            // 
            this.numericUpDownTileSetViewScale.Enabled = false;
            this.numericUpDownTileSetViewScale.Location = new System.Drawing.Point(118, 236);
            this.numericUpDownTileSetViewScale.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownTileSetViewScale.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDownTileSetViewScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTileSetViewScale.Name = "numericUpDownTileSetViewScale";
            this.numericUpDownTileSetViewScale.Size = new System.Drawing.Size(38, 20);
            this.numericUpDownTileSetViewScale.TabIndex = 26;
            this.numericUpDownTileSetViewScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTileSetViewScale.ValueChanged += new System.EventHandler(this.numericUpDownTileSetViewScale_ValueChanged);
            // 
            // numericUpDownPreviewViewScale
            // 
            this.numericUpDownPreviewViewScale.Enabled = false;
            this.numericUpDownPreviewViewScale.Location = new System.Drawing.Point(118, 260);
            this.numericUpDownPreviewViewScale.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownPreviewViewScale.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDownPreviewViewScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPreviewViewScale.Name = "numericUpDownPreviewViewScale";
            this.numericUpDownPreviewViewScale.Size = new System.Drawing.Size(38, 20);
            this.numericUpDownPreviewViewScale.TabIndex = 27;
            this.numericUpDownPreviewViewScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPreviewViewScale.ValueChanged += new System.EventHandler(this.numericUpDownPreviewViewScale_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 262);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Preview view scale";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(219, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "TileSet image:";
            // 
            // TileSetUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pictureBoxTileSet);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.numericUpDownPreviewViewScale);
            this.Controls.Add(this.numericUpDownTileSetViewScale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxTileSetName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBoxPreview);
            this.Controls.Add(this.numericUpDownTileY);
            this.Controls.Add(this.numericUpDownTileX);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelVertTiles);
            this.Controls.Add(this.labelHorzTiles);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownTileHeight);
            this.Controls.Add(this.numericUpDownTileWidth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelImageSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFileSelect);
            this.Controls.Add(this.textBoxFileName);
            this.Name = "TileSetUI";
            this.Size = new System.Drawing.Size(597, 638);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileSetViewScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPreviewViewScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openTileSetFileDialog;
        private System.Windows.Forms.Button btnFileSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.PictureBox pictureBoxTileSet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelImageSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownTileWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownTileHeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelHorzTiles;
        private System.Windows.Forms.Label labelVertTiles;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownTileX;
        private System.Windows.Forms.NumericUpDown numericUpDownTileY;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxTileSetName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownTileSetViewScale;
        private System.Windows.Forms.NumericUpDown numericUpDownPreviewViewScale;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}