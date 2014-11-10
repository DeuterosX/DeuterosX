namespace Teraluwide.Blackbird.DataEditor
{
    partial class AnimationUI
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxTileSet = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelImageSize = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.textBoxAnimationName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownTileSetViewScale = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPreviewViewScale = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tileSetComboBox = new System.Windows.Forms.ComboBox();
            this.tileWidthLabel = new System.Windows.Forms.Label();
            this.tileHeightLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.buttonAddFrame = new System.Windows.Forms.Button();
            this.buttonDeleteFrame = new System.Windows.Forms.Button();
            this.timerAnimationFrame = new System.Windows.Forms.Timer(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.numericUpDownFrameDuration = new System.Windows.Forms.NumericUpDown();
            this.checkBoxLoopAnimation = new System.Windows.Forms.CheckBox();
            this.timerAnimationPause = new System.Windows.Forms.Timer(this.components);
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.dataGridViewFrames = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileSetViewScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPreviewViewScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrameDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFrames)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "TileSet";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tile width:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tile height:";
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
            this.pictureBoxPreview.Location = new System.Drawing.Point(221, 523);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(106, 63);
            this.pictureBoxPreview.TabIndex = 21;
            this.pictureBoxPreview.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(219, 498);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Animation preview:";
            // 
            // textBoxAnimationName
            // 
            this.textBoxAnimationName.Location = new System.Drawing.Point(96, 17);
            this.textBoxAnimationName.Name = "textBoxAnimationName";
            this.textBoxAnimationName.Size = new System.Drawing.Size(379, 20);
            this.textBoxAnimationName.TabIndex = 23;
            this.textBoxAnimationName.Validated += new System.EventHandler(this.textBoxTextureName_Validated);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Animation name";
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
            // tileSetComboBox
            // 
            this.tileSetComboBox.FormattingEnabled = true;
            this.tileSetComboBox.Location = new System.Drawing.Point(96, 43);
            this.tileSetComboBox.Name = "tileSetComboBox";
            this.tileSetComboBox.Size = new System.Drawing.Size(379, 21);
            this.tileSetComboBox.TabIndex = 30;
            this.tileSetComboBox.SelectedIndexChanged += new System.EventHandler(this.tileSetComboBox_SelectedIndexChanged);
            // 
            // tileWidthLabel
            // 
            this.tileWidthLabel.AutoSize = true;
            this.tileWidthLabel.Location = new System.Drawing.Point(75, 142);
            this.tileWidthLabel.Name = "tileWidthLabel";
            this.tileWidthLabel.Size = new System.Drawing.Size(48, 13);
            this.tileWidthLabel.TabIndex = 31;
            this.tileWidthLabel.Text = "tileWidth";
            // 
            // tileHeightLabel
            // 
            this.tileHeightLabel.AutoSize = true;
            this.tileHeightLabel.Location = new System.Drawing.Point(75, 166);
            this.tileHeightLabel.Name = "tileHeightLabel";
            this.tileHeightLabel.Size = new System.Drawing.Size(51, 13);
            this.tileHeightLabel.TabIndex = 32;
            this.tileHeightLabel.Text = "tileHeight";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 285);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Frame list:";
            // 
            // buttonAddFrame
            // 
            this.buttonAddFrame.Location = new System.Drawing.Point(18, 493);
            this.buttonAddFrame.Name = "buttonAddFrame";
            this.buttonAddFrame.Size = new System.Drawing.Size(85, 23);
            this.buttonAddFrame.TabIndex = 36;
            this.buttonAddFrame.Text = "Add Frame";
            this.buttonAddFrame.UseVisualStyleBackColor = true;
            this.buttonAddFrame.Click += new System.EventHandler(this.buttonAddFrame_Click);
            // 
            // buttonDeleteFrame
            // 
            this.buttonDeleteFrame.Location = new System.Drawing.Point(103, 493);
            this.buttonDeleteFrame.Name = "buttonDeleteFrame";
            this.buttonDeleteFrame.Size = new System.Drawing.Size(85, 23);
            this.buttonDeleteFrame.TabIndex = 37;
            this.buttonDeleteFrame.Text = "Delete Frame";
            this.buttonDeleteFrame.UseVisualStyleBackColor = true;
            this.buttonDeleteFrame.Click += new System.EventHandler(this.buttonDeleteFrame_Click);
            // 
            // timerAnimationFrame
            // 
            this.timerAnimationFrame.Tick += new System.EventHandler(this.timerAnimationFrame_Tick);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 554);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 13);
            this.label16.TabIndex = 40;
            this.label16.Text = "Frame duration";
            // 
            // numericUpDownFrameDuration
            // 
            this.numericUpDownFrameDuration.Location = new System.Drawing.Point(103, 552);
            this.numericUpDownFrameDuration.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownFrameDuration.Name = "numericUpDownFrameDuration";
            this.numericUpDownFrameDuration.Size = new System.Drawing.Size(84, 20);
            this.numericUpDownFrameDuration.TabIndex = 41;
            this.numericUpDownFrameDuration.ValueChanged += new System.EventHandler(this.numericUpDownFrameDuration_ValueChanged);
            // 
            // checkBoxLoopAnimation
            // 
            this.checkBoxLoopAnimation.AutoSize = true;
            this.checkBoxLoopAnimation.Checked = true;
            this.checkBoxLoopAnimation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLoopAnimation.Location = new System.Drawing.Point(19, 578);
            this.checkBoxLoopAnimation.Name = "checkBoxLoopAnimation";
            this.checkBoxLoopAnimation.Size = new System.Drawing.Size(99, 17);
            this.checkBoxLoopAnimation.TabIndex = 42;
            this.checkBoxLoopAnimation.Text = "Loop Animation";
            this.checkBoxLoopAnimation.UseVisualStyleBackColor = true;
            // 
            // timerAnimationPause
            // 
            this.timerAnimationPause.Interval = 2000;
            this.timerAnimationPause.Tick += new System.EventHandler(this.timerAnimationPause_Tick);
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.Location = new System.Drawing.Point(18, 522);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(85, 23);
            this.buttonMoveUp.TabIndex = 43;
            this.buttonMoveUp.Text = "Move Up";
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.Location = new System.Drawing.Point(103, 522);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(85, 23);
            this.buttonMoveDown.TabIndex = 44;
            this.buttonMoveDown.Text = "Move Down";
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
            // 
            // dataGridViewFrames
            // 
            this.dataGridViewFrames.AllowUserToAddRows = false;
            this.dataGridViewFrames.AllowUserToDeleteRows = false;
            this.dataGridViewFrames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFrames.Location = new System.Drawing.Point(19, 301);
            this.dataGridViewFrames.MultiSelect = false;
            this.dataGridViewFrames.Name = "dataGridViewFrames";
            this.dataGridViewFrames.ReadOnly = true;
            this.dataGridViewFrames.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewFrames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFrames.Size = new System.Drawing.Size(186, 186);
            this.dataGridViewFrames.TabIndex = 45;
            this.dataGridViewFrames.Click += new System.EventHandler(this.dataGridViewFrames_Click);
            // 
            // AnimationUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewFrames);
            this.Controls.Add(this.buttonMoveDown);
            this.Controls.Add(this.buttonMoveUp);
            this.Controls.Add(this.checkBoxLoopAnimation);
            this.Controls.Add(this.numericUpDownFrameDuration);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.buttonDeleteFrame);
            this.Controls.Add(this.buttonAddFrame);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tileHeightLabel);
            this.Controls.Add(this.tileWidthLabel);
            this.Controls.Add(this.tileSetComboBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pictureBoxTileSet);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.numericUpDownPreviewViewScale);
            this.Controls.Add(this.numericUpDownTileSetViewScale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxAnimationName);
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
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelImageSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "AnimationUI";
            this.Size = new System.Drawing.Size(597, 638);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTileSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileSetViewScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPreviewViewScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrameDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFrames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxTileSet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelImageSize;
        private System.Windows.Forms.Label label4;
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
        private System.Windows.Forms.TextBox textBoxAnimationName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownTileSetViewScale;
        private System.Windows.Forms.NumericUpDown numericUpDownPreviewViewScale;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox tileSetComboBox;
        private System.Windows.Forms.Label tileWidthLabel;
        private System.Windows.Forms.Label tileHeightLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button buttonAddFrame;
        private System.Windows.Forms.Button buttonDeleteFrame;
        private System.Windows.Forms.Timer timerAnimationFrame;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numericUpDownFrameDuration;
        private System.Windows.Forms.CheckBox checkBoxLoopAnimation;
        private System.Windows.Forms.Timer timerAnimationPause;
        private System.Windows.Forms.Button buttonMoveUp;
        private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.DataGridView dataGridViewFrames;
    }
}
