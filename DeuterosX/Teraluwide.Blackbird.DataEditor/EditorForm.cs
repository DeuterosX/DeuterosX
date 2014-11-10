using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Teraluwide.Blackbird.DataTypes;
using System.Configuration;
using System.Xml;
using System.IO;

namespace Teraluwide.Blackbird.DataEditor
{
    public partial class EditorForm : Form
    {
        private GameData thisData;
        private string rootfolder;
        private string datafolder;
        private TileSetUI tsControl;
        private TextureUI txControl;
        private AnimationUI aniControl;

        public EditorForm()
        {
            InitializeComponent();
            rootfolder = ConfigurationManager.AppSettings["rootfolder"];
            if (rootfolder.Length > 0)
            {
                rootFolderPathLabel.Text = rootfolder;
                folderBrowserDialog1.SelectedPath = rootfolder;
            }
            else
            {
                rootFolderPathLabel.Text = "<not set>";
            }
            datafolder = ConfigurationManager.AppSettings["datafolder"];
            if (datafolder.Length > 0)
            {
                openFileDialog1.InitialDirectory = datafolder;
                saveFileDialog1.InitialDirectory = datafolder;
            }
            InitializeOpenFileDialog();
            InitializeSaveFileDialog();
        }

        private void InitializeOpenFileDialog()
        {
            this.openFileDialog1.Filter = "XML Files (*.xml)|*.xml|All files (*.*)|*.*";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Load DeuterosX Data File(s)";
        }

        private void InitializeSaveFileDialog()
        {
            this.saveFileDialog1.Filter = "XML Files (*.xml)|*.xml|All files (*.*)|*.*";
            this.saveFileDialog1.Title = "Save DeuterosX Data File";
            this.saveFileDialog1.OverwritePrompt = true;
        }

        private void BuildTreeViewFromData()
        {
            DataStructureTreeView.Nodes.Clear();
            // Build root node
            TreeNode RootNode = new TreeNode("GameData");
            RootNode.Name = "GameData";
            RootNode.ToolTipText = "Manage data types";
            RootNode.ContextMenuStrip = rootMenu;
            if (thisData.TileSetList != null)
            {
                if (thisData.TileSetList.Count > 0)
                {
                    TreeNode TileSets = BuildListNode("TileSet", tileSetListMenu);
                    foreach (TileSetType ts in thisData.TileSetList)
                    {
                        TileSets.Nodes.Add(BuildLeafNode(ts, tileSetMenu));
                    }
                    RootNode.Nodes.Add(TileSets);
                }
            }
            else
            {
                rootMenu.Items.Find("addTileSetSectionToolStripMenuItem", false)[0].Visible = true;
            }
            if (thisData.TextureList != null)
            {
                if (thisData.TextureList.Count > 0)
                {
                    TreeNode Textures = BuildListNode("Texture", textureListMenu);
                    foreach (TextureType t in thisData.TextureList)
                    {
                        Textures.Nodes.Add(BuildLeafNode(t, textureMenu));
                    }
                    RootNode.Nodes.Add(Textures);
                }
            }
            else
            {
                rootMenu.Items.Find("addTextureSectionToolStripMenuItem", false)[0].Visible = true;
            }
            if (thisData.AnimationList != null)
            {
                if (thisData.AnimationList.Count > 0)
                {
                    TreeNode Animations = BuildListNode("Animation", animationListMenu);
                    foreach (AnimationType a in thisData.AnimationList)
                    {
                        Animations.Nodes.Add(BuildLeafNode(a, animationMenu));
                    }
                    RootNode.Nodes.Add(Animations);
                }
            }
            else
            {
                rootMenu.Items.Find("addAnimationSectionToolStripMenuItem", false)[0].Visible = true;
            }
            DataStructureTreeView.Nodes.Add(RootNode);
            DataStructureTreeView.NodeMouseClick += NodeMouseClick;
            DataStructureTreeView.ExpandAll();
        }

        private TreeNode BuildListNode(string type, ContextMenuStrip con)
        {
            TreeNode tmp = new TreeNode(type + "List");
            tmp.Name = tmp.Text;
            tmp.ToolTipText = "Manage " + type + "s";
            tmp.ContextMenuStrip = con;
            rootMenu.Items.Find("add" + type + "SectionToolStripMenuItem", true)[0].Visible = false;
            return tmp;
        }

        private TreeNode BuildLeafNode(BaseLeafType blt, ContextMenuStrip con)
        {
            TreeNode tmp = new TreeNode(blt.Name);
            tmp.Name = tmp.Text;
            tmp.ContextMenuStrip = con;
            tmp.Tag = blt;
            return tmp;
        }

        private void SetUserControl(TreeNode node)
        {
            userControlPanel.Controls.Clear();
            switch (node.Tag.GetType().ToString())
            {
                case "Teraluwide.Blackbird.DataTypes.TileSetType":
                    tsControl = new TileSetUI(node, rootfolder);
                    userControlPanel.Controls.Add(tsControl);
                    tsControl.Dock = DockStyle.Fill;
                    break;
                case "Teraluwide.Blackbird.DataTypes.TextureType":
                    txControl = new TextureUI(node, rootfolder, thisData.TileSetList);
                    userControlPanel.Controls.Add(txControl);
                    txControl.Dock = DockStyle.Fill;
                    break;
                case "Teraluwide.Blackbird.DataTypes.AnimationType":
                    aniControl = new AnimationUI(node, rootfolder, thisData.TileSetList);
                    userControlPanel.Controls.Add(aniControl);
                    aniControl.Dock = DockStyle.Fill;
                    break;
                default:

                    break;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            DataStructureTreeView.SelectedNode = e.Node;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (e.Node.Tag != null)
                {
                    SetUserControl(e.Node);
                }
            }
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rootfolder.Length > 0)
            {
                thisData = new GameData();
                //thisData.TileSetList = null;
                //thisData.TextureList = null;
                //thisData.AnimationList = null;
                BuildTreeViewFromData();
            }
            else
            {
                MessageBox.Show("You need to select a root folder for your content data.");
            }
        }

        private void addTileSetSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tnTmp = new TreeNode("TileSetList");
            tnTmp.Name = "TileSetList";
            List<TileSetType> tmpList = new List<TileSetType>();
            tnTmp.Tag = tmpList;
            tnTmp.ContextMenuStrip = tileSetListMenu;
            thisData.TileSetList = tmpList;
            DataStructureTreeView.Nodes["GameData"].Nodes.Add(tnTmp);
            tnTmp.Parent.Expand();
        }

        private void addTextureSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tnTmp = new TreeNode("TextureList");
            tnTmp.Name = "TextureList";
            List<TextureType> tmpList = new List<TextureType>();
            tnTmp.Tag = tmpList;
            tnTmp.ContextMenuStrip = textureListMenu;
            thisData.TextureList = tmpList;
            DataStructureTreeView.Nodes["GameData"].Nodes.Add(tnTmp);
            tnTmp.Parent.Expand();
        }

        private void addAnimationSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tnTmp = new TreeNode("AnimationList");
            tnTmp.Name = "AnimationList";
            List<AnimationType> tmpList = new List<AnimationType>();
            tnTmp.Tag = tmpList;
            tnTmp.ContextMenuStrip = animationListMenu;
            thisData.AnimationList = tmpList;
            DataStructureTreeView.Nodes["GameData"].Nodes.Add(tnTmp);
            tnTmp.Parent.Expand();
        }

        private void newTileSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tnTmp = new TreeNode("<no name>");
            TileSetType tsTmp = CreateBlankTileSet();
            tnTmp.Tag = tsTmp;
            tnTmp.ContextMenuStrip = tileSetMenu;
            thisData.TileSetList.Add(tsTmp);
            DataStructureTreeView.Nodes[0].Nodes["TileSetList"].Nodes.Add(tnTmp);
            tnTmp.Parent.Expand();
        }

        private TileSetType CreateBlankTileSet()
        {
            TileSetType tsTmp = new TileSetType();
            tsTmp.ContentType = "Teraluwide.Blackbird.DataTypes.TileSetType";
            tsTmp.TileHeight = 1;
            tsTmp.TileWidth = 1;
            tsTmp.File = "";
            tsTmp.RootFolder = rootfolder;
            return tsTmp;
        }

        private void removeTileSetSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataStructureTreeView.Nodes[0].Nodes["TileSetList"].Remove();
            thisData.TileSetList = null;
        }

        private void chooseRootFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rootfolder = folderBrowserDialog1.SelectedPath;
                if (thisData != null)
                {
                    thisData.RootFolder = rootfolder;
                }
                rootFolderPathLabel.Text = rootfolder;
                SetConfigValue("rootfolder", rootfolder);
            }
        }

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                datafolder = Path.GetDirectoryName(openFileDialog1.FileNames[0]);
                openFileDialog1.InitialDirectory = datafolder;
                saveFileDialog1.InitialDirectory = datafolder;
                SetConfigValue("datafolder", datafolder);

                if (openFileDialog1.FileNames.Length == 1)
                {
                    saveFileDialog1.FileName = openFileDialog1.FileName;
                }

                thisData = GameDataLoader.LoadGameData(openFileDialog1.FileNames.ToList<string>());
                thisData.RootFolder = rootfolder;
                thisData.BuildRuntimeDataStructure();
                BuildTreeViewFromData();
            }
        }

        private void saveFileAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                datafolder = Path.GetDirectoryName(saveFileDialog1.FileName);
                openFileDialog1.InitialDirectory = datafolder;
                saveFileDialog1.InitialDirectory = datafolder;
                GameDataSave(thisData, saveFileDialog1.FileName);
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName.Length > 0)
            {
                GameDataSave(thisData, saveFileDialog1.FileName);
            }
            else
            {
                saveFileAsToolStripMenuItem_Click(sender, e);
            }
        }

        private void saveTileSetFileAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                datafolder = Path.GetDirectoryName(saveFileDialog1.FileName);
                openFileDialog1.InitialDirectory = datafolder;
                saveFileDialog1.InitialDirectory = datafolder;
                GameData finalData = new GameData();
                finalData.TileSetList = thisData.TileSetList;
                GameDataSave(finalData, saveFileDialog1.FileName);
            }
        }

        private void SetConfigValue(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);
        }

        private void newTextureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tnTmp = new TreeNode("<no name>");
            TextureType txTmp = CreateBlankTexture();
            tnTmp.Tag = txTmp;
            tnTmp.ContextMenuStrip = tileSetMenu;
            thisData.TextureList.Add(txTmp);
            DataStructureTreeView.Nodes[0].Nodes["TextureList"].Nodes.Add(tnTmp);
            tnTmp.Parent.Expand();
        }

        private TextureType CreateBlankTexture()
        {
            TextureType txTmp = new TextureType();
            txTmp.ContentType = "Teraluwide.Blackbird.DataTypes.TextureType";
            txTmp.Name = "";
            txTmp.TileSet = "";
            txTmp.TileX = 0;
            txTmp.TileY = 0;
            return txTmp;
        }

        private void removeTextureSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataStructureTreeView.Nodes[0].Nodes["TextureList"].Remove();
            thisData.TextureList = null;
        }

        private void saveTextureFileAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                datafolder = Path.GetDirectoryName(saveFileDialog1.FileName);
                openFileDialog1.InitialDirectory = datafolder;
                saveFileDialog1.InitialDirectory = datafolder;
                GameData finalData = new GameData();
                finalData.TextureList = thisData.TextureList;
                GameDataSave(finalData, saveFileDialog1.FileName);
            }
        }

        private void GameDataSave(GameData gd, string filename)
        {
            GameData toSave = new GameData();
            if (gd.TileSetList.Count == 0)
            {
                toSave.TileSetList = null;
            }
            else
            {
                toSave.TileSetList = gd.TileSetList;
            }
            if (gd.TextureList.Count == 0)
            {
                toSave.TextureList = null;
            }
            else
            {
                toSave.TextureList = gd.TextureList;
            }
            if (gd.AnimationList.Count == 0)
            {
                toSave.AnimationList = null;
            }
            else
            {
                toSave.AnimationList = gd.AnimationList;
            }
            XmlDocument gameDataXml = SerializationHelper.SerializeObject(toSave);
            gameDataXml.Save(filename);
        }

        private AnimationType CreateBlankAnimation()
        {
            AnimationType aniTemp = new AnimationType();
            aniTemp.ContentType = "Teraluwide.Blackbird.DataTypes.AnimationType";
            aniTemp.Name = "";
            aniTemp.TileSet = "";
            aniTemp.FrameDuration = 100;
            aniTemp.Frames = new List<FrameType>();
            return aniTemp;
        }

        private void newAnimationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tnTmp = new TreeNode("<no name>");
            AnimationType aniTmp = CreateBlankAnimation();
            tnTmp.Tag = aniTmp;
            tnTmp.ContextMenuStrip = animationMenu;
            thisData.AnimationList.Add(aniTmp);
            DataStructureTreeView.Nodes[0].Nodes["AnimationList"].Nodes.Add(tnTmp);
            tnTmp.Parent.Expand();
        }

        private void removeAnimationSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataStructureTreeView.Nodes[0].Nodes["AnimationList"].Remove();
            thisData.AnimationList = null;
        }

        private void deleteTileSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thisData.TileSetList.Remove((TileSetType)DataStructureTreeView.SelectedNode.Tag);
            DataStructureTreeView.SelectedNode.Remove();
        }

        private void deleteTextureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thisData.TextureList.Remove((TextureType)DataStructureTreeView.SelectedNode.Tag);
            DataStructureTreeView.SelectedNode.Remove();
        }

        private void deleteAnimationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thisData.AnimationList.Remove((AnimationType)DataStructureTreeView.SelectedNode.Tag);
            DataStructureTreeView.SelectedNode.Remove();
        }
    }
}
