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
    /// This class defines a tile set. A tile set references a single image file in the file system, using a relative path. It also contains additional information about the width and height of the tiles it represents. All tiles are the same size and have no spaces between them.
    /// 
    /// The serializable part of the class is defined in DataFileSerializableClasses.cs.
    /// </summary>
    public partial class TileSetType
    {
        /// <summary>
        /// This is the bitmap that this tile set represents.
        /// 
        /// Since this is not part of the serializable part of the class, the XmlIgnore attribute is used to ensure that the serialization process ignores this member.
        /// </summary>
        [XmlIgnore]
        public Bitmap TileSetBitmap;
        
        /// <summary>
        /// This is the root folder that the relative path of the image file goes out from. Since it is impossible to know in advance where the game is installed, this is only set at runtime. It is set by the GameData class, so that all TileSets will have the same root folder.
        /// 
        /// Since this is not part of the serializable part of the class, the XmlIgnore attribute is used to ensure that the serialization process ignores this member.
        /// </summary>
        [XmlIgnore]
        public string RootFolder;
        
        /// <summary>
        /// This is used by external objects/code to determine whether this tile set object has the necessary runtime data loaded.
        /// 
        /// Since this is not part of the serializable part of the class, the XmlIgnore attribute is used to ensure that the serialization process ignores this member.
        /// </summary>
        [XmlIgnore]
        public bool Loaded;
        
        /// <summary>
        /// This method loads the image that the File member references.
        /// </summary>
        public void LoadTileSetBitmap()
        {
            Loaded = false;

            if (RootFolder.Length > 0 && File.Length > 0)
            {
                try
                {
                    TileSetBitmap = (Bitmap)Image.FromFile(RootFolder + this.File);
                    TileSetWidth = TileSetBitmap.Width;
                    TileSetHeight = TileSetBitmap.Height;
                }
                catch (Exception ex)
                {
                    throw new Exception("A tile set failed to load. TileSet: " + this.Name, ex);
                }
                Loaded = true;
            }
        }
    }
}
