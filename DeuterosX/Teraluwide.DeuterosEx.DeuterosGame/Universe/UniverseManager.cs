﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core;
using System.Xml;
using Teraluwide.DeuterosEx.DeuterosGame.Properties;

namespace Teraluwide.DeuterosEx.DeuterosGame.Universe
{
	public class UniverseManager : IBlackbirdSimulationComponent
	{
		const string FileName = "Universe.xml";

		BlackbirdGame game;
		Dictionary<string, Galaxy> galaxies;

		/// <summary>
		/// Gets the galaxies.
		/// </summary>
		public Dictionary<string, Galaxy> Galaxies { get { return this.galaxies; } }

		/// <summary>
		/// Initializes a new instance of the <see cref="StationManager"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public UniverseManager(BlackbirdGame game)
		{
			this.game = game;
			this.galaxies = new Dictionary<string, Galaxy>();
		}

		#region ICustomBlackbirdComponent Members
		/// <summary>
		/// Gets the unique identifier of this custom component.
		/// </summary>
		/// <value>
		/// The unique identifier of this custom component.
		/// </value>
		public string Id
		{
			get { return "UniverseManager"; }
		}

		#endregion

		#region IBlackbirdComponent Members

		/// <summary>
		/// Gets the game instance associated with this component instance.
		/// </summary>
		/// <value>
		/// The game.
		/// </value>
		public BlackbirdGame Game
		{
			get { return game; }
		}

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
		public void Load(System.IO.Stream stream)
		{
			XmlDocument doc = new XmlDocument();
			try
			{
				doc.Load(stream);
			}
			catch (XmlException ex)
			{
				throw new BlackbirdException(string.Format(Teraluwide.Blackbird.Core.Properties.Resources.ModFileIsInIncorrectFormatException, FileName), ex);
			}
			finally
			{
				stream.Close();
			}

			XmlElement root = doc.SelectSingleNode("/FDRFile") as XmlElement;

			if (root == null || root.Attributes["type"].Value != "universe")
				throw new BlackbirdException(string.Format(Teraluwide.Blackbird.Core.Properties.Resources.ModFileIsInIncorrectFormatException, FileName));

			Log.WriteMessage(string.Format(Resources.UniverseDefinitionVersion, root.Attributes["version"].Value));

			foreach (XmlElement el in root.SelectNodes("Galaxies/*"))
			{
				Galaxy galaxy = new Galaxy(this);
				galaxy.FromXml(el);
				galaxies.Add(galaxy.Id, galaxy);
			}
		}

		/// <summary>
		/// Saves the component data of the currently selected mod.
		/// </summary>
		public void Save()
		{
			Save(VirtualPathProvider.CreateFile(VirtualPathProvider.EnsureModVirtualPath(FileName, Game.ModName)));
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

		#region IBlackbirdSimulationComponent Members

		/// <summary>
		/// Performs all necessary changes when advancing the simulation (ie. "Next turn").
		/// In UniverseManager, this means moving all the celestial bodies along their path. Maybe. Let me think about it a bit more :)
		/// </summary>
		public void Advance()
		{

		}

		#endregion
	}
}
