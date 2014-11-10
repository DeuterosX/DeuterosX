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
    public partial class AnimationUI : UserControl
    {
        private AnimationType _animation;
        private FrameType _currentframe;
        private List<TileSetType> _tilesetlist;
        private TileSetType _tileset;
        private TreeNode _tsnode;
        private Bitmap _tilesetimgscale;
        private Bitmap _tilepreviewimgscale;
        private Dictionary<string, TileSetType> comboTS;
        private int _currentpreviewframe;

        public AnimationUI()
        {
            InitializeComponent();
            InitializeFramesGridView();
            labelHorzTiles.Text = "";
            labelVertTiles.Text = "";
            tileWidthLabel.Text = "";
            tileHeightLabel.Text = "";
            _currentpreviewframe = 0;
        }

        public AnimationUI(TreeNode tsNode, string rootfolder, List<TileSetType> tileSets)
            : this()
        {
            _tsnode = tsNode;
            _animation = (AnimationType)tsNode.Tag;
            if (_animation.Frames.Count > 0)
            {
                _currentframe = _animation.Frames[0];
            }
            _tilesetlist = tileSets;
            _tileset = _tilesetlist.FirstOrDefault(t => t.Name == _animation.TileSet);

            if (_tileset != null)
            {
                _tileset.LoadTileSetBitmap();
                _animation.TileSetObject = _tileset;
                _animation.LoadFrameBitmaps(); //.LoadTextureBitmap();
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
            
            textBoxAnimationName.Text = _animation.Name;
            if (_currentframe == null)
            {
                numericUpDownTileX.Enabled = false;
                numericUpDownTileY.Enabled = false;
            }
            else
            {
                numericUpDownTileX.Value = _currentframe.TileX;
                numericUpDownTileY.Value = _currentframe.TileY;
            }
            if (_tileset != null)
            {
                LoadTileSetImage();
            }

            numericUpDownFrameDuration.Value = _animation.FrameDuration;
            timerAnimationFrame.Interval = _animation.FrameDuration;

            if (_animation.Frames.Count > 0)
            {
                timerAnimationFrame.Start();
            }
            

        }

        private void InitializeFramesGridView()
        {
            //dataGridViewFrames.ColumnCount = 2;
            dataGridViewFrames.Columns.Add(new DataGridViewImageColumn());
            dataGridViewFrames.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridViewFrames.ColumnHeadersVisible = false;
            dataGridViewFrames.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewFrames.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewFrames.Rows.Clear();
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
            if (!_animation.Loaded)
            {
                _animation.LoadFrameBitmaps(); //.LoadTextureBitmap();
            }
            if (_tileset != null)
            {
                if (!_tileset.Loaded)
                {
                    _tileset.LoadTileSetBitmap();
                }
                if (_currentframe != null)
                {
                    _tilepreviewimgscale = ScaleImage(_currentframe.FrameBitmap, (int)numericUpDownPreviewViewScale.Value);
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
            _animation.Name = textBoxAnimationName.Text;
            _tsnode.Name = textBoxAnimationName.Text;
            _tsnode.Text = textBoxAnimationName.Text;
        }

        private void numericUpDownTileX_ValueChanged(object sender, EventArgs e)
        {
            _currentframe.TileX = (int)numericUpDownTileX.Value;
            _currentframe.LoadFrameBitmap(_tileset.TileSetBitmap, _tileset.TileWidth, _tileset.TileHeight);
            //_animation.LoadTextureBitmap();
            UpdateFramesGridView();
            UpdatePreview();
        }

        private void numericUpDownTileY_ValueChanged(object sender, EventArgs e)
        {
            _currentframe.TileY = (int)numericUpDownTileY.Value;
            _currentframe.LoadFrameBitmap(_tileset.TileSetBitmap, _tileset.TileWidth, _tileset.TileHeight);
            //_animation.LoadTextureBitmap();
            UpdateFramesGridView();
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
                    _animation.TileSetObject = _tileset;
                    _animation.TileSet = _tileset.Name;
                    AdjustTileSetControls();
                    if (!_tileset.Loaded)
                    {
                        _tileset.LoadTileSetBitmap();
                    }
                    _animation.LoadFrameBitmaps(); //.LoadTextureBitmap();
                    LoadTileSetImage();
                }
            }
        }

        //private void UpdateFramesListView()
        //{
        //    ImageList il = new ImageList();
        //    ListViewItem lvi;
        //    listViewFrames.Items.Clear();
        //    for (int i = 0; i < _animation.Frames.Count; i++)
        //    {
        //        lvi = new ListViewItem("Frame " + i.ToString(), i);
        //        listViewFrames.Items.Add(lvi);
        //        il.Images.Add(_animation.Frames[i].FrameBitmap);
        //    }
        //}

        private void UpdateFramesGridView()
        {
            dataGridViewFrames.Rows.Clear();
            for (int i = 0; i < _animation.Frames.Count; i++)
            {
                dataGridViewFrames.Rows.Add();
                dataGridViewFrames.Rows[i].Cells[0].Value = _animation.Frames[i].FrameBitmap;
                dataGridViewFrames.Rows[i].Cells[1].Value = "Frame " + i.ToString();
                dataGridViewFrames.Rows[i].Selected = false;
            }
            if (_currentframe != null)
            {
                dataGridViewFrames.Rows[_currentframe.Sequence].Selected = true;
            }
        }

        private void buttonAddFrame_Click(object sender, EventArgs e)
        {
            FrameType f = new FrameType();
            f.TileX = (int)numericUpDownTileX.Value;
            f.TileY = (int)numericUpDownTileY.Value;
            f.Sequence = _animation.Frames.Count;
            _animation.Frames.Add(f);
            f.LoadFrameBitmap(_tileset.TileSetBitmap, _tileset.TileWidth, _tileset.TileHeight);
            _currentframe = f;
            numericUpDownTileX.Enabled = true;
            numericUpDownTileY.Enabled = true;
            UpdateFramesGridView();
            if (!timerAnimationFrame.Enabled)
            {
                timerAnimationFrame.Start();
            }
        }

        private void buttonDeleteFrame_Click(object sender, EventArgs e)
        {
            FrameType f = _currentframe;
            _animation.Frames.Remove(_currentframe);
            if (_animation.Frames.Count > 0)
            {
                _currentframe = _animation.Frames[f.Sequence > 0 ? f.Sequence - 1 : 0];
            }
            else
            {
                _currentframe = null;
                numericUpDownTileX.Enabled = false;
                numericUpDownTileY.Enabled = false;
            }
            UpdateFramesGridView();
            if (_animation.Frames.Count == 0)
            {
                timerAnimationFrame.Stop();
            }
        }

        private void UpdateFrameSequences()
        {
            for (int i = 0; i < _animation.Frames.Count; i++)
            {
                _animation.Frames[i].Sequence = i;
            }
            UpdateFramesGridView();
        }

        private void timerAnimationPause_Tick(object sender, EventArgs e)
        {
            timerAnimationPause.Stop();
            timerAnimationFrame.Start();
        }

        private void timerAnimationFrame_Tick(object sender, EventArgs e)
        {
            if (_animation.Frames.Count > 0)
            {
                if (_currentpreviewframe < _animation.Frames.Count)
                {
                    pictureBoxPreview.Image = ScaleImage(_animation.Frames[_currentpreviewframe].FrameBitmap, (int)numericUpDownPreviewViewScale.Value);
                    _currentpreviewframe++;
                    if (_currentpreviewframe >= _animation.Frames.Count)
                    {
                        _currentpreviewframe = 0;
                        if (!checkBoxLoopAnimation.Checked)
                        {
                            timerAnimationFrame.Stop();
                            timerAnimationPause.Start();
                        }
                    }
                }
                else
                {
                    _currentpreviewframe = 0;
                }
            }
        }

        //private void listViewFrames_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int selectedIndex = listViewFrames.SelectedItems[0].Index;
        //    _currentframe = _animation.Frames[selectedIndex];
        //    if (selectedIndex == 0)
        //    {
        //        buttonMoveUp.Enabled = false;
        //        if (_animation.Frames.Count > 1)
        //        {
        //            buttonMoveDown.Enabled = true;
        //        }
        //    }
        //    if (selectedIndex > 0)
        //    {
        //        buttonMoveUp.Enabled = true;
        //        if (selectedIndex == _animation.Frames.Count - 1)
        //        {
        //            buttonMoveDown.Enabled = false;
        //        }
        //    }
        //}

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            if (_currentframe.Sequence > 0)
            {
                _animation.Frames[_currentframe.Sequence] = _animation.Frames[_currentframe.Sequence - 1];
                _animation.Frames[_currentframe.Sequence - 1] = _currentframe;
                _animation.Frames[_currentframe.Sequence].Sequence++;
                _currentframe.Sequence--;
            }
            UpdateFramesGridView();
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            if (_currentframe.Sequence < _animation.Frames.Count - 1)
            {
                _animation.Frames[_currentframe.Sequence] = _animation.Frames[_currentframe.Sequence + 1];
                _animation.Frames[_currentframe.Sequence + 1] = _currentframe;
                _animation.Frames[_currentframe.Sequence].Sequence--;
                _currentframe.Sequence++;
            }
            UpdateFramesGridView();
        }

        private void numericUpDownFrameDuration_ValueChanged(object sender, EventArgs e)
        {
            _animation.FrameDuration = (int)numericUpDownFrameDuration.Value;
            timerAnimationFrame.Interval = _animation.FrameDuration;
        }

        private void dataGridViewFrames_Click(object sender, EventArgs e)
        {
            if (dataGridViewFrames.CurrentRow != null)
            {
                int selectedIndex = dataGridViewFrames.CurrentRow.Index;
                _currentframe = _animation.Frames[selectedIndex];
                numericUpDownTileX.Value = _currentframe.TileX;
                numericUpDownTileY.Value = _currentframe.TileY;
                if (selectedIndex == 0)
                {
                    buttonMoveUp.Enabled = false;
                    if (_animation.Frames.Count > 1)
                    {
                        buttonMoveDown.Enabled = true;
                    }
                }
                if (selectedIndex > 0)
                {
                    buttonMoveUp.Enabled = true;
                    if (selectedIndex == _animation.Frames.Count - 1)
                    {
                        buttonMoveDown.Enabled = false;
                    }
                }
            }
        }


    }
}
