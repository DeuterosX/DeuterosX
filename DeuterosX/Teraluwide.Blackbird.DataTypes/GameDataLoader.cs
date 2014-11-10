using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Teraluwide.Blackbird.DataTypes
{
    /// <summary>
    /// This is a static helper class used for loading game content XML files into runtime objects.
    /// 
    /// This functionality could have been included directly in the GameData class, but I prefer to keep static methods out of runtime objects.
    /// </summary>
    public static class GameDataLoader
    {
        /// <summary>
        /// This method loads a single content XML file and returns the equivalent runtime object.
        /// </summary>
        /// <param name="file">The full path of the content XML file to be loaded.</param>
        /// <returns>A GameData object containing the data from the content XML and related runtime data such as bitmap objects.</returns>
        public static GameData LoadGameData(string file)
        {
            List<string> files = new List<string>();
            files.Add(file);
            return LoadGameData(files);
        }

        /// <summary>
        /// This method loads a list of content XML files, merges them into a single structure and returns the equivalent runtime object.
        /// </summary>
        /// <param name="files">A list of the content XML files to be loaded, represented as full file paths.</param>
        /// <returns>A GameData object containing the data from the content XML and related runtime data such as bitmap objects.</returns>
        public static GameData LoadGameData(List<string> files)
        {
            GameData finalData = new GameData();
            XmlDocument gameDataXml = new XmlDocument();
            GameData gameDataObj = new GameData();

            foreach (string file in files)
            {
                try
                {
                    gameDataXml.Load(file);
                }
                catch (Exception ex)
                {
                    throw new Exception("There was a problem loading the game data file \"" + file + "\"", ex);
                }
                try
                {
                    gameDataObj = (GameData)SerializationHelper.DeSerializeObject(gameDataXml, gameDataObj.GetType());
                }
                catch (Exception ex)
                {
                    throw new Exception("Could not deserialize the data from the game data file \"" + file + "\"", ex);
                }
                finalData.TileSetList.AddRange(gameDataObj.TileSetList.AsEnumerable());
                finalData.TextureList.AddRange(gameDataObj.TextureList.AsEnumerable());
                finalData.AnimationList.AddRange(gameDataObj.AnimationList.AsEnumerable());
            }

            //try
            //{
            //    finalData.BuildRuntimeDataStructure();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("There was a problem building the runtime object for the content data.", ex);
            //}

            return finalData;
        }
    }
}
