using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using Teraluwide.Blackbird.Core.Properties;

namespace Teraluwide.Blackbird.Core
{
	/// <summary>
	/// Contains the basic game information specified in the mod file GameInfo.xml along with methods to load and save the data.
	/// </summary>
	public class BlackbirdGameInfo : IBlackbirdComponent
	{
		public const string FileName = "GameInfo.xml";

		/// <summary>
		/// Gets the game instance associated with this component instance.
		/// </summary>
		/// <value>The game.</value>
		public BlackbirdGame Game { get; private set; }

		private string title = "untitled mod";
		private bool showEngineVersion = true;
		private bool showModVersion = true;
		private string modVersion = "0.00";
		private string author = "unknown author";
		private string description = "mod description";
		private string website = "http://www.google.com/";

		/// <summary>
		/// Gets the title.
		/// </summary>
		/// <value>The title.</value>
		public string Title { get { return this.title; } }

		/// <summary>
		/// Gets a value indicating whether to show the engine version in the title.
		/// </summary>
		/// <value><c>true</c> if engine version is to be displayed; otherwise, <c>false</c>.</value>
		public bool ShowEngineVersion { get { return this.showEngineVersion; } }

		/// <summary>
		/// Gets a value indicating whether to show the mod version in the title.
		/// </summary>
		/// <value><c>true</c> if mod version is to be displayed; otherwise, <c>false</c>.</value>
		public bool ShowModVersion { get { return this.showModVersion; } }

		/// <summary>
		/// Gets the mod version.
		/// </summary>
		/// <value>The mod version.</value>
		public string ModVersion { get { return this.modVersion; } }

		/// <summary>
		/// Gets the author.
		/// </summary>
		/// <value>The author.</value>
		public string Author { get { return this.author; } }

		/// <summary>
		/// Gets the description.
		/// </summary>
		/// <value>The description.</value>
		public string Description { get { return this.description; } }

		/// <summary>
		/// Gets the website.
		/// </summary>
		/// <value>The website.</value>
		public string Website { get { return this.website; } }

		/// <summary>
		/// Initializes a new instance of the <see cref="BlackbirdGameInfo"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public BlackbirdGameInfo(BlackbirdGame game)
		{
			this.Game = game;
		}

		/// <summary>
		/// Loads the game info for the currently selected mod.
		/// </summary>
		public void Load()
		{
			Load(VirtualPathProvider.GetFile(VirtualPathProvider.EnsureModVirtualPath(FileName, Game.ModName)));
		}

		/// <summary>
		/// Loads the game info from the specified stream.
		/// </summary>
		/// <param name="file">The file.</param>
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

			if (root == null || root.Attributes["type"].Value != "info" || root["GameInfo"] == null)
				throw new BlackbirdException(string.Format(Resources.ModFileIsInIncorrectFormatException, FileName));

			Log.WriteMessage(string.Format(Resources.GameInfoVersion, root.Attributes["version"].Value));

			foreach (XmlElement el in root.SelectNodes("GameInfo/*"))
			{
				try
				{
					switch (el.Name)
					{
						case "Title": this.title = el.InnerText; break;
						case "ShowEngineVersion": this.showEngineVersion = XmlHelper.ParseBool(el.InnerText); break;
						case "ShowModVersion": this.showModVersion = XmlHelper.ParseBool(el.InnerText); break;
						case "ModVersion": this.modVersion = el.InnerText; break;
						case "Author": this.author = el.InnerText; break;
						case "Description": this.description = el.InnerText; break;
						case "Website": this.website = el.InnerText; break;
					}
				}
				catch (FormatException)
				{
					// not a critical error
					Log.WriteWarning(string.Format(Resources.ModFileIsInIncorrectFormatSpecificException, FileName, el.InnerText, el.Name));
				}
			}

			Game.CustomComponents.Clear();
			// Load the component definitions and instantize them.
			foreach (XmlElement el in root.SelectNodes("Components/*"))
			{
				if (el.Attributes["type"] == null)
					throw new BlackbirdException(string.Format(Resources.ComponentMissingType));

				Type type = Type.GetType(el.Attributes["type"].Value, false);

				if (type == null)
					throw new BlackbirdException(string.Format(Resources.ComponentTypeNotFound, el.Attributes["type"].Value));

				ICustomBlackbirdComponent component = Activator.CreateInstance(type, Game) as ICustomBlackbirdComponent;

				if (component == null)
					throw new BlackbirdException(string.Format(Resources.ComponentTypeNotInitialized, type.AssemblyQualifiedName));

				if (Game.CustomComponents.ContainsKey(component.Id))
					throw new BlackbirdException(string.Format(Resources.ComponentAlreadyRegistered, component.Id));

				Game.CustomComponents.Add(component.Id, component);
			}
		}


		/// <summary>
		/// Saves the game info of the currently selected mod.
		/// </summary>
		public void Save()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Saves the game info of the currently selected mod to the specified stream.
		/// </summary>
		/// <param name="stream">The target stream.</param>
		public void Save(Stream stream)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			
		}
	}
}
