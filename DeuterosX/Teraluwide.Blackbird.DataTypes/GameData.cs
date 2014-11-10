using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Teraluwide.Blackbird.DataTypes
{
    /// <summary>
    /// This class represents the combined game content as defined in the content XML files.
    /// 
    /// The serializable part of the class is defined in DataFileSerializableClasses.cs.
    /// </summary>
    public partial class GameData
    {
        /// <summary>
        /// This basically only exists because we need to set the root folder for each tile set whenever the root folder for the combined game data is set. Therefore we need to use a property.
        /// </summary>
        private string _rootfolder;

        /// <summary>
        /// This represents the root folder of the game. This is used for finding the full paths of the files referenced by each tile set.
        /// </summary>
        [XmlIgnore]
        public string RootFolder
        {
            get { return _rootfolder; }
            set
            {
                _rootfolder = value;
                foreach (TileSetType ts in this.TileSetList)
                {
                    ts.RootFolder = value;
                }
            }
        }

        /// <summary>
        /// After a GameData object is created by loading and deserializing one or more content XML files, this method is called to generate the necessary runtime data from the basic information in the files. This happens automatically in the LoadGameData() method in the GameDataLoader helper class.
        /// </summary>
        public void BuildRuntimeDataStructure()
        {
            MatchTileSets();
            LoadAllBitmaps();
        }

        /// <summary>
        /// This method iterates through all the TextureType and AnimationType objects in the game data and sets a reference on each to the TileSetType runtime object representing the tile set they each get their graphics from.
        /// </summary>
        public void MatchTileSets()
        {
            if (TextureList != null)
            {
                if (TextureList.Count > 0)
                {
                    foreach (TextureType tx in TextureList)
                    {
                        try
                        {
                            tx.TileSetObject = TileSetList.First(ts => ts.Name == tx.TileSet);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Error matching tile set to texture. Texture: " + tx.Name + ". TileSet: " + tx.TileSet, ex);
                        }
                    }
                }
            }
            if (AnimationList != null)
            {
                if (AnimationList.Count > 0)
                {
                    foreach (AnimationType a in AnimationList)
                    {
                        try
                        {
                            a.TileSetObject = TileSetList.First(ts => ts.Name == a.TileSet);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Error matching tile set to animation. Animation: " + a.Name + ". TileSet: " + a.TileSet, ex);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This method first loads runtime bitmaps from the image files referenced in the tile sets. Then, from those runtime bitmaps, it creates runtime bitmaps for the tiles referenced by the textures and animations. This method has no exception handling, because there is no additional information to be gained at this level of the call stack.
        /// </summary>
        public void LoadAllBitmaps()
        {
            foreach (TileSetType ts in TileSetList)
            {
                ts.LoadTileSetBitmap();
            }
            foreach (TextureType tx in TextureList)
            {
                tx.LoadTextureBitmap();
            }
            foreach (AnimationType a in AnimationList)
            {
                a.LoadFrameBitmaps();
            }
        }
    }
}
