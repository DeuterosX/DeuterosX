using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SdlDotNet.Graphics;
using Teraluwide.Blackbird.Core.Properties;
using System.Xml;

namespace Teraluwide.Blackbird.Core
{
	/// <summary>
	/// Represents a repository for textures loaded in memory.
	/// </summary>
	public sealed class TextureManager : IBlackbirdComponent
	{
		const string FileName = "Textures.xml";

		/// <summary>
		/// Gets the game instance associated with this component instance.
		/// </summary>
		/// <value>The game.</value>
		public BlackbirdGame Game { get; private set; }

		Dictionary<string, TextureManagerItem> innerData = new Dictionary<string, TextureManagerItem>();

		/// <summary>
		/// Initializes a new instance of the <see cref="TextureManager"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public TextureManager(BlackbirdGame game)
		{
			this.Game = game;
		}

		/// <summary>
		/// Loads the texture definitions for the currently selected mod.
		/// </summary>
		public void Load()
		{
			Load(VirtualPathProvider.GetFile(VirtualPathProvider.EnsureModVirtualPath(FileName, Game.ModName)));
		}

		/// <summary>
		/// Loads the texture definitions from the specified stream.
		/// </summary>
		/// <param name="stream">The input stream.</param>
		public void Load(Stream stream)
		{
			XmlDocument doc = new XmlDocument();
			try
			{
				doc.Load(stream);
			}
			catch (XmlException ex)
			{
				throw new BlackbirdException(string.Format(Resources.ModFileIsInIncorrectFormatException, FileName), ex);
			}
			finally
			{
				stream.Close();
			}

			XmlElement root = doc.SelectSingleNode("/FDRFile") as XmlElement;

			if (root == null || root.Attributes["type"].Value != "textures")
				throw new BlackbirdException(string.Format(Resources.ModFileIsInIncorrectFormatException, FileName));

			Log.WriteMessage(string.Format(Resources.TextureDefinitionVersion, root.Attributes["version"].Value));

			foreach (XmlElement el in root.SelectNodes("TextureList/*"))
			{
				string id = el.GetAttributeOrNull("id");
				string fileName = el.GetAttributeOrNull("fileName");

				if (id == null)
					throw new BlackbirdException(string.Format(Resources.ModFileIsInIncorrectFormatSpecificException, FileName, "null", "id"));

				if (fileName == null)
					throw new BlackbirdException(string.Format(Resources.ModFileIsInIncorrectFormatSpecificException, FileName, "null", "fileName"));

				if (innerData.ContainsKey(id))
					throw new BlackbirdException(string.Format(Resources.TextureAlreadyRegistered, id));

				TextureManagerItem item;

				innerData.Add(
						id,
						item =
							new TextureManagerItem(
								this, id, fileName,
								XmlHelper.ParseBool(XmlHelper.GetAttribute(el, "onLoad", "0")),
								XmlHelper.ParseBool(XmlHelper.GetAttribute(el, "onDemand", "1")),
								XmlHelper.ParseBool(XmlHelper.GetAttribute(el, "trackUsers", "1")),
								XmlHelper.ParseRectangle(el, "DrawArea", System.Drawing.Rectangle.Empty),
								XmlHelper.ParseBool(XmlHelper.GetAttribute(el, "smoothScale", "1")),
								XmlHelper.ParseBool(XmlHelper.GetAttribute(el, "allowScaling", "1")),
								XmlHelper.Parse<float>(XmlHelper.GetAttribute(el, "scalingModifier", "1")),
								XmlHelper.Parse<int>(XmlHelper.GetAttribute(el, "animationFrames", "0")),
                                XmlHelper.Parse<int>(XmlHelper.GetAttribute(el, "animationTime", "0"))
							)
					);

				if (item.OnLoad)
					item.LoadTexture(false);
			}
		}

		/// <summary>
		/// Saves the texture definitions of the currently selected mod.
		/// </summary>
		public void Save()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Saves the texture definitions of the currently selected mod to the specified stream.
		/// </summary>
		/// <param name="stream">The target stream.</param>
		public void Save(Stream stream)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the texture specified by its unique identifier. This will usually be called in constructors and should be properly disposed using ReturnTexture 
		/// when done with.
		/// </summary>
		/// <param name="id">The unique identifier of the texture.</param>
		/// <returns></returns>
		public TextureManagerItem GetTexture(string id)
		{
			if (!innerData.ContainsKey(id))
				throw new BlackbirdException(string.Format(Resources.TextureUndefined, id));

			var texture = innerData[id];
			texture.AddUser();

			return texture;
		}

		/// <summary>
		/// Returns the texture specified by its unique identifier. This should be called whenever one of the users of this texture is done with it (usually in Dispose).
		/// </summary>
		/// <param name="id">The id.</param>
		public void ReturnTexture(string id)
		{
			if (!innerData.ContainsKey(id))
				throw new BlackbirdException(string.Format(Resources.TextureUndefined, id));

			innerData[id].RemoveUser();
		}

        /// <summary>
        /// On screen change action 
        /// </summary>
        public void OnGameScreenChange()
        {
            ResetAnimations();
        }

        /// <summary>
        /// Resets AnimationStartedFromTick for all animations
        /// </summary>
        private void ResetAnimations()
        {
            foreach (KeyValuePair<String, TextureManagerItem> item in innerData)
            {
                if (item.Value.IsAnimation)
                {
                    item.Value.ResetAnimation();
                }
            }
        }

		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			foreach (var texture in innerData.Values)
				texture.Dispose();
		}

		#endregion

	}


}
