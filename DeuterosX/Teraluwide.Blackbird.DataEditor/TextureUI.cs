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
    public partial class TextureUI : UserControl
    {
        private TextureType _texture;
        private List<TileSetType> _tilesetlist;
        private TileSetType _tileset;
        private TreeNode _tsnode;
        private Bitmap _tilesetimgscale;
        private Bitmap _tilepreviewimgscale;
        private Dictionary<string, TileSetType> comboTS;

        public TextureUI()
        {
            InitializeComponent();
            labelHorzTiles.Text = "";
            labelVertTiles.Text = "";
            tileWidthLabel.Text = "";
            tileHeightLabel.Text = "";
        }

        public TextureUI(TreeNode tsNode, string rootfolder, List<TileSetType> tileSets)
            : this()
        {
            _tsnode = tsNode;
            _texture = (TextureType)tsNode.Tag;
            _tilesetlist = tileSets;
            _tileset = _tilesetlist.FirstOrDefault(t => t.Name == _texture.TileSet);

            if (_tileset != null)
            {
                _tileset.LoadTileSetBitmap();
                _texture.TileSetObject = _tileset;
                _texture.LoadTextureBitmap();
                AdjustTileSetControls();
            }

            comboTS = new Dictionary<string, TileSetType>();
            TileSetType tmpTile = new TileSetType();
            tmpTile.Name = "";
            tmpTile.File = "";
            comboTS.Add("No TileSet selected", tmpTile);
            foreach (TileSetType t in _tilesetlist)
            {
                comboTS.Add(t.Name, t);
            }

            tileSetComboBox.DataSource = new BindingSource(comboTS, null);
            tileSetComboBox.DisplayMember = "Key";
            tileSetComboBox.ValueMember = "Value";

            if (_tileset != null)
            {
                tileSetComboBox.SelectedValue = _tileset;
            }
            else
            {
                tileSetComboBox.SelectedIndex = 0;
            }
            
            textBoxTextureName.Text = _texture.Name;
            numericUpDownTileX.Value = _texture.TileX;
            numericUpDownTileY.Value = _texture.TileY;
            if (_tileset != null)
            {
                LoadTileSetImage();
            }
            
            
        }

        private void AdjustTileSetControls()
        {
            tileWidthLabel.Text = _tileset.TileWidth.ToString();
            tileHeightLabel.Text = _tileset.TileHeight.ToString();
            numericUpDownTileX.Maximum = _tileset.TilesX - 1;
            labelHorzTiles.Text = _tileset.TilesX.ToString();
            numericUpDownTileY.Maximum = _tileset.TilesY - 1;
            labelVertTiles.Text = _tileset.TilesY.ToString();
        }

        private void UpdatePreview()
        {
            if (!_texture.Loaded)
            {
                _texture.LoadTextureBitmap();
            }
            if (_tileset != null)
            {
                if (_tileset.Loaded)
                {
                    _tilepreviewimgscale = ScaleImage(_texture.TextureBitmap, (int)numericUpDownPreviewViewScale.Value);
                    pictureBoxPreview.Image = _tilepreviewimgscale;
                    pictureBoxPreview.Width = pictureBoxPreview.Image.Width;
                    pictureBoxPreview.Height = pictureBoxPreview.Image.Height;
                }
            }
        }

        private void LoadTileSetImage()
        {
            UpdateTileSetImage();
            UpdatePreview();
            numericUpDownTileX.Enabled = true;
            numericUpDownTileY.Enabled = true;
            numericUpDownTileSetViewScale.Enabled = true;
            numericUpDownPreviewViewScale.Enabled = true;
            labelImageSize.Text = _tileset.TileSetWidth.ToString() + "*" + _tileset.TileSetHeight.ToString();
        }

        private void UpdateTileSetImage()
        {
            _tilesetimgscale = ScaleImage(_tileset.TileSetBitmap, (int)numericUpDownTileSetViewScale.Value);
            pictureBoxTileSet.Image = _tilesetimgscale;
            pictureBoxTileSet.Width = pictureBoxTileSet.Image.Width;
            pictureBoxTileSet.Height = pictureBoxTileSet.Image.Height;
        }

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

        private void textBoxTextureName_Validated(object sender, EventArgs e)
        {
            _texture.Name = textBoxTextureName.Text;
            _tsnode.Name = textBoxTextureName.Text;
            _tsnode.Text = textBoxTextureName.Text;
        }

        private void numericUpDownTileX_ValueChanged(object sender, EventArgs e)
        {
            _texture.TileX = (int)numericUpDownTileX.Value;
            _texture.LoadTextureBitmap();
            UpdatePreview();
        }

        private void numericUpDownTileY_ValueChanged(object sender, EventArgs e)
        {
            _texture.TileY = (int)numericUpDownTileY.Value;
            _texture.LoadTextureBitmap();
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

        private void tileSetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tileSetComboBox.SelectedIndex > 0)
            {
                _tileset = (TileSetType)tileSetComboBox.SelectedValue;
                if (_tileset != null)
                {
                    _texture.TileSetObject = _tileset;
                    _texture.TileSet = _tileset.Name;
                    AdjustTileSetControls();
                    if (!_tileset.Loaded)
                    {
                        _tileset.LoadTileSetBitmap();
                    }
                    _texture.LoadTextureBitmap();
                    LoadTileSetImage();
                }
            }
        }
    }
}
