using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace Teraluwide.Blackbird.DataTypes
{
    /// <summary>
    /// This class defines a single static texture. A texture is defined as a single tile in a tile set.
    /// 
    /// The serializable part of the class is defined in DataFileSerializableClasses.cs.
    /// </summary>
    public partial class TextureType
    {
        /// <summary>
        /// This is the bitmap that this texture represents.
        /// 
        /// Since this is not part of the serializable part of the class, the XmlIgnore attribute is used to ensure that the serialization process ignores this member.
        /// </summary>
        [XmlIgnore]
        public Bitmap TextureBitmap;
        
        /// <summary>
        /// This is used during runtime. Each Texture object keeps a reference to the TileSet object it uses, in order to minimize lookups during game execution.
        /// 
        /// Since this is not part of the serializable part of the class, the XmlIgnore attribute is used to ensure that the serialization process ignores this member.
        /// </summary>
        [XmlIgnore]
        public TileSetType TileSetObject;
        
        /// <summary>
        /// This is used by external objects/code to determine whether this texture object has the necessary runtime data loaded.
        /// 
        /// Since this is not part of the serializable part of the class, the XmlIgnore attribute is used to ensure that the serialization process ignores this member.
        /// </summary>
        [XmlIgnore]
        public bool Loaded;
        
        /// <summary>
        /// This method loads the bitmap for this texture from the tile set it comes from.
        /// </summary>
        public void LoadTextureBitmap()
        {
            Loaded = false;

            if (TileSetObject != null)
            {
                if (TileSetObject.Loaded)
                {
                    try
                    {
                        TextureBitmap = new Bitmap(TileSetObject.TileWidth, TileSetObject.TileHeight);
                        Graphics copy = Graphics.FromImage(TextureBitmap);
                        Rectangle srcRect = new Rectangle(this.TileX * TileSetObject.TileWidth, this.TileY * TileSetObject.TileHeight, TileSetObject.TileWidth, TileSetObject.TileHeight);
                        Rectangle destRect = new Rectangle(0, 0, TileSetObject.TileWidth, TileSetObject.TileHeight);
                        copy.DrawImage(TileSetObject.TileSetBitmap, destRect, srcRect, GraphicsUnit.Pixel);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("An texture bitmap failed to load. Texture: \"" + this.Name + "\". TileSet: " + TileSetObject.Name, ex);
                    }
                    Loaded = true;
                }
            }
        }
    }
}
