using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Teraluwide.Blackbird.DataTypes
{
    /// <summary>
    /// This is the class that defines an animation. It contains a list of frames, each of which references a specific tile in a tileset. All frames in a single animation must come from the same tileset.
    /// 
    /// The serializable part of the class is defined in DataFileSerializableClasses.cs.
    /// </summary>
    public partial class AnimationType
    {
        /// <summary>
        /// This is used during runtime. Each Animation object keeps a reference to the TileSet object it uses, in order to minimize lookups during game execution.
        /// 
        /// Since this is not part of the serializable part of the class, the XmlIgnore attribute is used to ensure that the serialization process ignores this member.
        /// </summary>
        [XmlIgnore]
        public TileSetType TileSetObject;

        /// <summary>
        /// This is used by external objects/code to determine whether this animation object has the necessary runtime data loaded.
        /// 
        /// Since this is not part of the serializable part of the class, the XmlIgnore attribute is used to ensure that the serialization process ignores this member.
        /// </summary>
        [XmlIgnore]
        public bool Loaded;

        /// <summary>
        /// This method loads the actual bitmap for each frame in the animation.
        /// </summary>
        public void LoadFrameBitmaps()
        {
            Loaded = false;

            if (TileSetObject != null)
            {
                if (TileSetObject.Loaded)
                {
                    foreach (FrameType f in Frames)
                    {
                        try
                        {
                            f.LoadFrameBitmap(TileSetObject.TileSetBitmap, TileSetObject.TileWidth, TileSetObject.TileHeight);
                        }
                        catch (Exception ex)
                        {
                            Loaded = false;
                            throw new Exception("An animation frame failed to load. Animation: \"" + this.Name + "\". Frame: " + Frames.IndexOf(f).ToString() + ". TileSet: " + TileSetObject.Name, ex);
                        }
                    }
                    Loaded = true;
                }
            }
        }
    }
}
