using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;

namespace Teraluwide.Blackbird.DataTypes
{
    /// <summary>
    /// This class represents a single frame of an animation.
    /// 
    /// The serializable part of the class is defined in DataFileSerializableClasses.cs.
    /// </summary>
    public partial class FrameType
    {
        /// <summary>
        /// This is the bitmap that this frame represents.
        /// 
        /// Since this is not part of the serializable part of the class, the XmlIgnore attribute is used to ensure that the serialization process ignores this member.
        /// </summary>
        [XmlIgnore]
        public Bitmap FrameBitmap;
        
        /// <summary>
        /// This is used by external objects/code to determine whether this frame object has the necessary runtime data loaded.
        /// 
        /// Since this is not part of the serializable part of the class, the XmlIgnore attribute is used to ensure that the serialization process ignores this member.
        /// </summary>
        [XmlIgnore]
        public bool Loaded;

        /// <summary>
        /// This method loads the bitmap for one frame of an animation.
        /// </summary>
        /// <param name="tileset">The runtime object of the tile set that this animation uses.</param>
        public void LoadFrameBitmap(TileSetType tileset)
        {
            LoadFrameBitmap(tileset.TileSetBitmap, tileset.TileWidth, tileset.TileHeight);
        }

        /// <summary>
        /// This method loads the bitmap for one frame of an animation.
        /// </summary>
        /// <param name="source">The bitmap of the tile set that this animation uses.</param>
        /// <param name="width">The width of the tiles in the tile set.</param>
        /// <param name="height">The height of the tiles in the tile set.</param>
        public void LoadFrameBitmap(Bitmap source, int width, int height)
        {
            Loaded = false;

            try
            {
                FrameBitmap = new Bitmap(width, height);
                Graphics copy = Graphics.FromImage(FrameBitmap);
                Rectangle srcRect = new Rectangle(this.TileX * width, this.TileY * height, width, height);
                Rectangle destRect = new Rectangle(0, 0, width, height);
                copy.DrawImage(source, destRect, srcRect, GraphicsUnit.Pixel);
            }
            catch (Exception ex)
            {
                throw new Exception("Frame bitmap loading failed.", ex);
            }
            Loaded = true;
        }
    }
}
