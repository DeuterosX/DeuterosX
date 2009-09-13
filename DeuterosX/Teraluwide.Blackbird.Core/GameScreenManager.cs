using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using Teraluwide.Blackbird.Core.Properties;

namespace Teraluwide.Blackbird.Core
{
	/// <summary>
	/// Represents a manager of game screens in the game.
	/// </summary>
	public class GameScreenManager : IBlackbirdComponent
	{
		const string FileName = "GameScreens.xml";

		private Dictionary<string, GameScreen> innerData = new Dictionary<string, GameScreen>();

		/// <summary>
		/// Initializes a new instance of the <see cref="GameScreenManager"/> class.
		/// </summary>
		/// <param name="game">The game instance.</param>
		public GameScreenManager(BlackbirdGame game)
		{
			this.Game = game;
		}

		/// <summary>
		/// Gets or sets the current game screen.
		/// </summary>
		/// <value>The current game screen.</value>
		public GameScreen CurrentGameScreen { get; set; }

		#region IBlackbirdComponent Members

		/// <summary>
		/// Gets the game instance associated with this component instance.
		/// </summary>
		/// <value>The game.</value>
		public BlackbirdGame Game { get; private set; }

		/// <summary>
		/// Loads the component data for the currently selected mod.
		/// </summary>
		public void Load()
		{
			Load(VirtualPathProvider.GetFile(VirtualPathProvider.EnsureModVirtualPath(FileName, Game.ModName)));
		}

		/// <summary>
		/// Loads the component data from the specified stream.
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

			if (root == null || root.Attributes["type"].Value != "screens")
				throw new BlackbirdException(string.Format(Resources.ModFileIsInIncorrectFormatException, FileName));

			Log.WriteMessage(string.Format(Resources.TextureDefinitionVersion, root.Attributes["version"].Value));

			foreach (XmlElement el in root.SelectNodes("GameScreenList/*"))
			{
				string id = el.GetAttribute("id");
				string type = el.GetAttribute("type");

				if (id == null)
					throw new BlackbirdException(string.Format(Resources.ModFileIsInIncorrectFormatSpecificException, FileName, "null", "id"));

				if (type == null)
					throw new BlackbirdException(string.Format(Resources.GameScreenMissingType, id));

				if (innerData.ContainsKey(id))
					throw new BlackbirdException(string.Format(Resources.GameScreenAlreadyRegistered, id));

				Type screenType = Type.GetType(type, false);

				if (screenType == null)
					throw new BlackbirdException(string.Format(Resources.GameScreenTypeNotFound, type));

				GameScreen screen = Activator.CreateInstance(screenType, Game) as GameScreen;

				if (screen == null)
					throw new BlackbirdException(string.Format(Resources.GameScreenTypeNotInitialized, type));

				innerData.Add(id, screen);
				screen.Load();
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
		public void Save(Stream stream)
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
			foreach (GameScreen screen in innerData.Values)
				screen.Dispose();

			innerData.Clear();
		}

		#endregion
	}
}
