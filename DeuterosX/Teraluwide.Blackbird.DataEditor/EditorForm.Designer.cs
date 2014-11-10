namespace Teraluwide.Blackbird.DataEditor
{
    partial class EditorForm
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
            this.components = new System.ComponentModel.Container();
            this.DataStructureTreeView = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseRootFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.userControlPanel = new System.Windows.Forms.Panel();
            this.rootMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addTileSetSectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTextureSectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAnimationSectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileSetListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newTileSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTileSetFileAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTileSetSectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textureListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newTextureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTextureFileAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTextureSectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animationListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newAnimationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAnimationSectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileSetMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteTileSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textureMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteTextureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animationMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteAnimationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.rootFolderPathLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.rootMenu.SuspendLayout();
            this.tileSetListMenu.SuspendLayout();
            this.textureListMenu.SuspendLayout();
            this.animationListMenu.SuspendLayout();
            this.tileSetMenu.SuspendLayout();
            this.textureMenu.SuspendLayout();
            this.animationMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataStructureTreeView
            // 
            this.DataStructureTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataStructureTreeView.Location = new System.Drawing.Point(3, 3);
            this.DataStructureTreeView.Name = "DataStructureTreeView";
            this.DataStructureTreeView.ShowNodeToolTips = true;
            this.DataStructureTreeView.Size = new System.Drawing.Size(224, 535);
            this.DataStructureTreeView.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(781, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileToolStripMenuItem,
            this.loadFileToolStripMenuItem,
            this.saveFileToolStripMenuItem,
            this.saveFileAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newFileToolStripMenuItem
            // 
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.newFileToolStripMenuItem.Text = "New";
            this.newFileToolStripMenuItem.Click += new System.EventHandler(this.newFileToolStripMenuItem_Click);
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.loadFileToolStripMenuItem.Text = "Load";
            this.loadFileToolStripMenuItem.Click += new System.EventHandler(this.loadFileToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveFileToolStripMenuItem.Text = "Save";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // saveFileAsToolStripMenuItem
            // 
            this.saveFileAsToolStripMenuItem.Name = "saveFileAsToolStripMenuItem";
            this.saveFileAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveFileAsToolStripMenuItem.Text = "Save As";
            this.saveFileAsToolStripMenuItem.Click += new System.EventHandler(this.saveFileAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseRootFolderToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // chooseRootFolderToolStripMenuItem
            // 
            this.chooseRootFolderToolStripMenuItem.Name = "chooseRootFolderToolStripMenuItem";
            this.chooseRootFolderToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.chooseRootFolderToolStripMenuItem.Text = "Choose root folder";
            this.chooseRootFolderToolStripMenuItem.Click += new System.EventHandler(this.chooseRootFolderToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.DataStructureTreeView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.userControlPanel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(781, 541);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // userControlPanel
            // 
            this.userControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlPanel.Location = new System.Drawing.Point(232, 2);
            this.userControlPanel.Margin = new System.Windows.Forms.Padding(2);
            this.userControlPanel.Name = "userControlPanel";
            this.userControlPanel.Size = new System.Drawing.Size(547, 537);
            this.userControlPanel.TabIndex = 1;
            // 
            // rootMenu
            // 
            this.rootMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTileSetSectionToolStripMenuItem,
            this.addTextureSectionToolStripMenuItem,
            this.addAnimationSectionToolStripMenuItem});
            this.rootMenu.Name = "contextMenuStrip1";
            this.rootMenu.Size = new System.Drawing.Size(197, 70);
            // 
            // addTileSetSectionToolStripMenuItem
            // 
            this.addTileSetSectionToolStripMenuItem.Name = "addTileSetSectionToolStripMenuItem";
            this.addTileSetSectionToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.addTileSetSectionToolStripMenuItem.Text = "Add TileSet section";
            this.addTileSetSectionToolStripMenuItem.Click += new System.EventHandler(this.addTileSetSectionToolStripMenuItem_Click);
            // 
            // addTextureSectionToolStripMenuItem
            // 
            this.addTextureSectionToolStripMenuItem.Name = "addTextureSectionToolStripMenuItem";
            this.addTextureSectionToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.addTextureSectionToolStripMenuItem.Text = "Add Texture section";
            this.addTextureSectionToolStripMenuItem.Click += new System.EventHandler(this.addTextureSectionToolStripMenuItem_Click);
            // 
            // addAnimationSectionToolStripMenuItem
            // 
            this.addAnimationSectionToolStripMenuItem.Name = "addAnimationSectionToolStripMenuItem";
            this.addAnimationSectionToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.addAnimationSectionToolStripMenuItem.Text = "Add Animation section";
            this.addAnimationSectionToolStripMenuItem.Click += new System.EventHandler(this.addAnimationSectionToolStripMenuItem_Click);
            // 
            // tileSetListMenu
            // 
            this.tileSetListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTileSetToolStripMenuItem,
            this.saveTileSetFileAsToolStripMenuItem,
            this.removeTileSetSectionToolStripMenuItem});
            this.tileSetListMenu.Name = "tileSetListMenu";
            this.tileSetListMenu.Size = new System.Drawing.Size(197, 70);
            // 
            // newTileSetToolStripMenuItem
            // 
            this.newTileSetToolStripMenuItem.Name = "newTileSetToolStripMenuItem";
            this.newTileSetToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.newTileSetToolStripMenuItem.Text = "New TileSet";
            this.newTileSetToolStripMenuItem.Click += new System.EventHandler(this.newTileSetToolStripMenuItem_Click);
            // 
            // saveTileSetFileAsToolStripMenuItem
            // 
            this.saveTileSetFileAsToolStripMenuItem.Name = "saveTileSetFileAsToolStripMenuItem";
            this.saveTileSetFileAsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.saveTileSetFileAsToolStripMenuItem.Text = "Save TileSet File As";
            this.saveTileSetFileAsToolStripMenuItem.Click += new System.EventHandler(this.saveTileSetFileAsToolStripMenuItem_Click);
            // 
            // removeTileSetSectionToolStripMenuItem
            // 
            this.removeTileSetSectionToolStripMenuItem.Name = "removeTileSetSectionToolStripMenuItem";
            this.removeTileSetSectionToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.removeTileSetSectionToolStripMenuItem.Text = "Remove TileSet section";
            this.removeTileSetSectionToolStripMenuItem.Click += new System.EventHandler(this.removeTileSetSectionToolStripMenuItem_Click);
            // 
            // textureListMenu
            // 
            this.textureListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTextureToolStripMenuItem,
            this.saveTextureFileAsToolStripMenuItem,
            this.removeTextureSectionToolStripMenuItem});
            this.textureListMenu.Name = "textureListMenu";
            this.textureListMenu.Size = new System.Drawing.Size(201, 70);
            // 
            // newTextureToolStripMenuItem
            // 
            this.newTextureToolStripMenuItem.Name = "newTextureToolStripMenuItem";
            this.newTextureToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.newTextureToolStripMenuItem.Text = "New Texture";
            this.newTextureToolStripMenuItem.Click += new System.EventHandler(this.newTextureToolStripMenuItem_Click);
            // 
            // saveTextureFileAsToolStripMenuItem
            // 
            this.saveTextureFileAsToolStripMenuItem.Name = "saveTextureFileAsToolStripMenuItem";
            this.saveTextureFileAsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.saveTextureFileAsToolStripMenuItem.Text = "Save Texture File As";
            this.saveTextureFileAsToolStripMenuItem.Click += new System.EventHandler(this.saveTextureFileAsToolStripMenuItem_Click);
            // 
            // removeTextureSectionToolStripMenuItem
            // 
            this.removeTextureSectionToolStripMenuItem.Name = "removeTextureSectionToolStripMenuItem";
            this.removeTextureSectionToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.removeTextureSectionToolStripMenuItem.Text = "Remove Texture section";
            this.removeTextureSectionToolStripMenuItem.Click += new System.EventHandler(this.removeTextureSectionToolStripMenuItem_Click);
            // 
            // animationListMenu
            // 
            this.animationListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newAnimationToolStripMenuItem,
            this.removeAnimationSectionToolStripMenuItem});
            this.animationListMenu.Name = "animationListMenu";
            this.animationListMenu.Size = new System.Drawing.Size(218, 48);
            // 
            // newAnimationToolStripMenuItem
            // 
            this.newAnimationToolStripMenuItem.Name = "newAnimationToolStripMenuItem";
            this.newAnimationToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.newAnimationToolStripMenuItem.Text = "New Animation";
            this.newAnimationToolStripMenuItem.Click += new System.EventHandler(this.newAnimationToolStripMenuItem_Click);
            // 
            // removeAnimationSectionToolStripMenuItem
            // 
            this.removeAnimationSectionToolStripMenuItem.Name = "removeAnimationSectionToolStripMenuItem";
            this.removeAnimationSectionToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.removeAnimationSectionToolStripMenuItem.Text = "Remove Animation section";
            this.removeAnimationSectionToolStripMenuItem.Click += new System.EventHandler(this.removeAnimationSectionToolStripMenuItem_Click);
            // 
            // tileSetMenu
            // 
            this.tileSetMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteTileSetToolStripMenuItem});
            this.tileSetMenu.Name = "tileSetMenu";
            this.tileSetMenu.Size = new System.Drawing.Size(146, 26);
            // 
            // deleteTileSetToolStripMenuItem
            // 
            this.deleteTileSetToolStripMenuItem.Name = "deleteTileSetToolStripMenuItem";
            this.deleteTileSetToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteTileSetToolStripMenuItem.Text = "Delete TileSet";
            this.deleteTileSetToolStripMenuItem.Click += new System.EventHandler(this.deleteTileSetToolStripMenuItem_Click);
            // 
            // textureMenu
            // 
            this.textureMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteTextureToolStripMenuItem});
            this.textureMenu.Name = "textureMenu";
            this.textureMenu.Size = new System.Drawing.Size(150, 26);
            // 
            // deleteTextureToolStripMenuItem
            // 
            this.deleteTextureToolStripMenuItem.Name = "deleteTextureToolStripMenuItem";
            this.deleteTextureToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteTextureToolStripMenuItem.Text = "Delete Texture";
            this.deleteTextureToolStripMenuItem.Click += new System.EventHandler(this.deleteTextureToolStripMenuItem_Click);
            // 
            // animationMenu
            // 
            this.animationMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteAnimationToolStripMenuItem});
            this.animationMenu.Name = "animationMenu";
            this.animationMenu.Size = new System.Drawing.Size(167, 48);
            // 
            // deleteAnimationToolStripMenuItem
            // 
            this.deleteAnimationToolStripMenuItem.Name = "deleteAnimationToolStripMenuItem";
            this.deleteAnimationToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.deleteAnimationToolStripMenuItem.Text = "Delete Animation";
            this.deleteAnimationToolStripMenuItem.Click += new System.EventHandler(this.deleteAnimationToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.rootFolderPathLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 565);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(781, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(69, 17);
            this.toolStripStatusLabel1.Text = "Root folder:";
            // 
            // rootFolderPathLabel
            // 
            this.rootFolderPathLabel.Name = "rootFolderPathLabel";
            this.rootFolderPathLabel.Size = new System.Drawing.Size(118, 17);
            this.rootFolderPathLabel.Text = "toolStripStatusLabel2";
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 587);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EditorForm";
            this.Text = "DeuterosX Data Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.rootMenu.ResumeLayout(false);
            this.tileSetListMenu.ResumeLayout(false);
            this.textureListMenu.ResumeLayout(false);
            this.animationListMenu.ResumeLayout(false);
            this.tileSetMenu.ResumeLayout(false);
            this.textureMenu.ResumeLayout(false);
            this.animationMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView DataStructureTreeView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem newFileToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip rootMenu;
        private System.Windows.Forms.ContextMenuStrip tileSetListMenu;
        private System.Windows.Forms.ContextMenuStrip textureListMenu;
        private System.Windows.Forms.ContextMenuStrip animationListMenu;
        private System.Windows.Forms.ContextMenuStrip tileSetMenu;
        private System.Windows.Forms.ContextMenuStrip textureMenu;
        private System.Windows.Forms.ContextMenuStrip animationMenu;
        private System.Windows.Forms.ToolStripMenuItem addTileSetSectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTextureSectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAnimationSectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTileSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTileSetSectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTextureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTextureSectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newAnimationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAnimationSectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTileSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTextureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAnimationToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseRootFolderToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel rootFolderPathLabel;
        private System.Windows.Forms.Panel userControlPanel;
        private System.Windows.Forms.ToolStripMenuItem saveFileAsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveTileSetFileAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTextureFileAsToolStripMenuItem;
    }
}

