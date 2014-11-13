using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Teraluwide.Blackbird.DataTypes;

namespace Teraluwide.Blackbird.DataEditor
{
    public partial class TileSetUI : UserControl
    {
        public event EventHandler<TileSetEventArgs> TileSetUpdated;

        private TileSetType _tileset;
        //private string _rootfolder;
        private TreeNode _tsnode;
        //private Bitmap _tilesetimgraw;
        private Bitmap _tilesetimgscale;
        private Bitmap _tilepreviewimgraw;
        private Bitmap _tilepreviewimgscale;

        public TileSetType TileSet
        {
            get
            {
                return this._tileset;
            }
            set
            {
                this._tileset = value;
            }
        }

        //public string RootFolder
        //{
        //    get
        //    {
        //        return this._rootfolder;
        //    }
        //    set
        //    {
        //        this._rootfolder = value;
        //    }
        //}

        public TreeNode TSNode
        {
            get
            {
                return this._tsnode;
            }
            set
            {
                this._tsnode = value;
            }
        }

        public TileSetUI()
        {
            InitializeComponent();
        }

        public TileSetUI(TileSetType ts, string rootfolder) : this()
        {
            _tileset = ts;
            _tileset.RootFolder = rootfolder;
            openTileSetFileDialog.InitialDirectory = rootfolder;
            textBoxFileName.Text = ts.File;
            textBoxTileSetName.Text = ts.Name;
            numericUpDownTileWidth.Value = ts.TileWidth;
            pictureBoxPreview.Width = ts.TileWidth;
            numericUpDownTileHeight.Value = ts.TileHeight;
            pictureBoxPreview.Height = ts.TileHeight;
            numericUpDownTileX.Value = 0;
            numericUpDownTileX.Maximum = ts.TilesX;
            labelHorzTiles.Text = ts.TilesX.ToString();
            numericUpDownTileY.Value = 0;
            numericUpDownTileY.Maximum = ts.TilesY;
            labelVertTiles.Text = ts.TilesY.ToString();
        }

        public TileSetUI(TileSetType ts, string rootfolder, TreeNode tsNode)
            : this(ts, rootfolder)
        {
            _tsnode = tsNode;
        }

        public TileSetUI(TreeNode tsNode, string rootfolder)
            : this()
        {
            _tsnode = tsNode;
            _tileset = (TileSetType)tsNode.Tag;
            _tileset.RootFolder = rootfolder;
            openTileSetFileDialog.InitialDirectory = rootfolder;
            textBoxFileName.Text = _tileset.File;
            textBoxTileSetName.Text = _tileset.Name;
            numericUpDownTileWidth.Value = _tileset.TileWidth;
            pictureBoxPreview.Width = _tileset.TileWidth;
            numericUpDownTileHeight.Value = _tileset.TileHeight;
            pictureBoxPreview.Height = _tileset.TileHeight;
            numericUpDownTileX.Value = 0;
            numericUpDownTileX.Maximum = _tileset.TilesX;
            labelHorzTiles.Text = _tileset.TilesX.ToString();
            numericUpDownTileY.Value = 0;
            numericUpDownTileY.Maximum = _tileset.TilesY;
            labelVertTiles.Text = _tileset.TilesY.ToString();
            if (_tileset.File.Length > 0)
            {
                LoadTileSetImage();
            }
        }

        protected virtual void OnTileSetUpdated(TileSetEventArgs e)
        {
            EventHandler<TileSetEventArgs> eh = TileSetUpdated;
            if (eh != null)
                eh(this, e);
        }

        private void numericUpDownTileWidth_ValueChanged(object sender, EventArgs e)
        {
            _tileset.TileWidth = (int)numericUpDownTileWidth.Value;
            pictureBoxPreview.Width = (int)numericUpDownTileWidth.Value;
            numericUpDownTileX.Maximum = ((int)_tileset.TileSetWidth / _tileset.TileWidth)-1;
            _tileset.TilesX = (int)numericUpDownTileX.Maximum + 1;
            labelHorzTiles.Text = ((int)_tileset.TileSetWidth / _tileset.TileWidth).ToString();
            numericUpDownTileX.Value = numericUpDownTileX.Value > numericUpDownTileX.Maximum ? numericUpDownTileX.Maximum : numericUpDownTileX.Value;
            UpdatePreview();
        }

        private void numericUpDownTileHeight_ValueChanged(object sender, EventArgs e)
        {
            _tileset.TileHeight = (int)numericUpDownTileHeight.Value;
            pictureBoxPreview.Height = (int)numericUpDownTileHeight.Value;
            numericUpDownTileY.Maximum = ((int)_tileset.TileSetHeight / _tileset.TileHeight)-1;
            _tileset.TilesY = (int)numericUpDownTileY.Maximum + 1;
            labelVertTiles.Text = ((int)_tileset.TileSetHeight / _tileset.TileHeight).ToString();
            numericUpDownTileY.Value = numericUpDownTileY.Value > numericUpDownTileY.Maximum ? numericUpDownTileY.Maximum : numericUpDownTileY.Value;
            UpdatePreview();
        }

        private void UpdatePreview()
        {
            if (_tileset.Loaded)
            {
                _tilepreviewimgraw = new Bitmap((int)numericUpDownTileWidth.Value, (int)numericUpDownTileHeight.Value);
                Graphics copy = Graphics.FromImage(_tilepreviewimgraw);
                Rectangle srcRect = new Rectangle((int)numericUpDownTileX.Value * _tileset.TileWidth, (int)numericUpDownTileY.Value * _tileset.TileHeight, _tileset.TileWidth, _tileset.TileHeight);
                Rectangle destRect = new Rectangle(0, 0, _tileset.TileWidth, _tileset.TileHeight);
                copy.DrawImage(_tileset.TileSetBitmap, destRect, srcRect, GraphicsUnit.Pixel);
                _tilepreviewimgscale = ScaleImage(_tilepreviewimgraw, (int)numericUpDownPreviewViewScale.Value);
                pictureBoxPreview.Image = _tilepreviewimgscale;
                pictureBoxPreview.Width = pictureBoxPreview.Image.Width;
                pictureBoxPreview.Height = pictureBoxPreview.Image.Height;
            }
        }

        private void LoadTileSetImage()
        {
            _tileset.LoadTileSetBitmap();
            labelHorzTiles.Text = ((int)_tileset.TileSetWidth / _tileset.TileWidth).ToString();
            labelVertTiles.Text = ((int)_tileset.TileSetHeight / _tileset.TileHeight).ToString();
            numericUpDownTileWidth.Maximum = _tileset.TileSetWidth;
            numericUpDownTileHeight.Maximum = _tileset.TileSetHeight;
            UpdateTileSetImage();
            UpdatePreview();
            numericUpDownTileWidth.Enabled = true;
            numericUpDownTileHeight.Enabled = true;
            numericUpDownTileX.Enabled = true;
            numericUpDownTileY.Enabled = true;
            numericUpDownTileSetViewScale.Enabled = true;
            numericUpDownPreviewViewScale.Enabled = true;
            labelImageSize.Text = _tileset.TileSetBitmap.Width.ToString() + "*" + _tileset.TileSetBitmap.Height.ToString();
        }

        private void UpdateTileSetImage()
        {
            _tilesetimgscale = ScaleImage(_tileset.TileSetBitmap, (int)numericUpDownTileSetViewScale.Value);
            pictureBoxTileSet.Image = _tilesetimgscale;
            pictureBoxTileSet.Width = pictureBoxTileSet.Image.Width;
            pictureBoxTileSet.Height = pictureBoxTileSet.Image.Height;
        }

        //private Bitmap ScaleImage(Bitmap source, int scale)
        //{
        //    Bitmap target = new Bitmap(source, new Size((int)(source.Width * scale), (int)(source.Height * scale)));
        //    return target;
        //}

        private Bitmap ScaleImage(Bitmap source, int scale)
        {
            Bitmap target = new Bitmap(source.Width * scale, source.Height * scale);
            using (Graphics g = Graphics.FromImage(target))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                g.DrawImage(source, 0, 0, target.Width, target.Height);
            }
            return target;
        }

        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            openTileSetFileDialog.ShowDialog();
        }

        private void openTileSetFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string relativePath = openTileSetFileDialog.FileName.Substring(_tileset.RootFolder.Length);
            _tileset.File = relativePath;
            textBoxFileName.Text = relativePath;
            LoadTileSetImage();
        }

        private void textBoxTileSetName_Validated(object sender, EventArgs e)
        {
            _tileset.Name = textBoxTileSetName.Text;
            _tsnode.Name = textBoxTileSetName.Text;
            _tsnode.Text = textBoxTileSetName.Text;
            GameData tmpData = (GameData)_tsnode.TreeView.TopNode.Tag;
            tmpData.UpdateTileSetReferences();
        }

        private void numericUpDownTileX_ValueChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void numericUpDownTileY_ValueChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void numericUpDownTileSetViewScale_ValueChanged(object sender, EventArgs e)
        {
            UpdateTileSetImage();
        }

        private void numericUpDownPreviewViewScale_ValueChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }
    }

    public class TileSetEventArgs : EventArgs
    {
        private TileSetType _tileSet;
        private TreeNode _tsNode;

        public TileSetEventArgs(TileSetType ts)
        {
            this._tileSet = ts;
        }

        public TileSetEventArgs(TileSetType ts, TreeNode tsnode)
            : this(ts)
        {
            this._tsNode = tsnode;
        }

        public TileSetType TileSet
        {
            get { return _tileSet; }
        }

        public TreeNode TSNode
        {
            get { return _tsNode; }
        }
    }
}
