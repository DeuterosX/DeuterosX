using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Teraluwide.Blackbird.Core.Properties;

namespace Teraluwide.Blackbird.Core.Gui
{
	public class GuiManager : IBlackbirdComponent
	{
		const string FileName = "face/Main.xml";

		private BlackbirdGame game;
		private Dictionary<string, GuiFace> innerData = new Dictionary<string, GuiFace>();

		/// <summary>
		/// Initializes a new instance of the <see cref="GuiManager"/> class.
		/// </summary>
		/// <param name="game">The game instance.</param>
		public GuiManager(BlackbirdGame game)
		{
			this.game = game;
			innerData = new Dictionary<string, GuiFace>();
		}

		/// <summary>
		/// Gets the specified face.
		/// </summary>
		/// <param name="id">The unique identifier of the face.</param>
		/// <returns></returns>
		public GuiFace GetFace(string id)
		{
			if (!string.IsNullOrEmpty(id) && innerData.ContainsKey(id))
				return innerData[id];

			return null;
		}

		#region IBlackbirdComponent Members

		/// <summary>
		/// Gets the game instance associated with this component instance.
		/// </summary>
		/// <value>The game.</value>
		public BlackbirdGame Game
		{
			get { return this.game; }
		}

		/// <summary>
		/// Loads the component data for the currently selected mod.
		/// </summary>
		public void Load()
		{
			Load(FileName);
		}

		/// <summary>
		/// Loads the component data for the currently selected mod.
		/// </summary>
		/// <param name="fileName">The file name.</param>
		public void Load(string fileName)
		{
			Load(VirtualPathProvider.GetFile(VirtualPathProvider.EnsureModVirtualPath(fileName, Game.ModName)), fileName);
		}

		/// <summary>
		/// Loads the component data from the specified stream.
		/// </summary>
		/// <param name="stream">The input stream.</param>
		public void Load(System.IO.Stream stream)
		{
			Load(stream, FileName);
		}

		/// <summary>
		/// Loads the component data from the specified stream.
		/// </summary>
		/// <param name="stream">The input stream.</param>
		public void Load(System.IO.Stream stream, string currentFileName)
		{
			XmlDocument doc = new XmlDocument();
			try
			{
				doc.Load(stream);
			}
			catch (XmlException ex)
			{
				throw new BlackbirdException(string.Format(Resources.ModFileIsInIncorrectFormatException, currentFileName), ex);
			}
			finally
			{
				stream.Close();
			}

			XmlElement root = doc.SelectSingleNode("/FDRFile") as XmlElement;

			if (root == null || root.Attributes["type"].Value != "face")
				throw new BlackbirdException(string.Format(Resources.ModFileIsInIncorrectFormatException, currentFileName));

			Log.WriteMessage(string.Format(Resources.GameScreenDefinitionVersion, root.Attributes["version"].Value));

			foreach (XmlElement el in root.ChildNodes)
			{
				switch (el.Name)
				{
					case "Include":
						{
							string file = el.GetAttribute("file");

							if (file == null)
								throw new BlackbirdException(string.Format(Resources.ModFileIsInIncorrectFormatSpecificException, currentFileName, "null", "file"));

							// Load the file recursively - maybe there should be some checking for cyclic references?
							Load(file);

							break;
						}
					case "Face":
						{
							string id = el.GetAttribute("id");

							if (id == null)
								throw new BlackbirdException(string.Format(Resources.ModFileIsInIncorrectFormatSpecificException, currentFileName, "null", "id"));

							if (innerData.ContainsKey(id))
								throw new BlackbirdException(string.Format(Resources.FaceAlreadyRegistered, id));

							GuiFace face = new GuiFace(Game, id);
							face.Load(el, currentFileName);

							innerData.Add(id, face);

							break;
						}
				}
			}
		}

		/// <summary>
		/// Saves the component data of the currently selected mod.
		/// </summary>
		public void Save()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Saves the component data of the currently selected mod to the specified stream.
		/// </summary>
		/// <param name="stream">The target stream.</param>
		public void Save(System.IO.Stream stream)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			
		}

		#endregion
	}
}
