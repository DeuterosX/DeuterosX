using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core;
using System.Xml;

namespace Teraluwide.DeuterosEx.DeuterosGame.Universe
{
	public class UniverseManager : IBlackbirdSavegameComponent, IBlackbirdSimulationComponent
	{
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

		#region IBlackbirdSavegameComponent Members

		/// <summary>
		/// Loads the component specific data from the specified save game node.
		/// </summary>
		/// <param name="node">The node.</param>
		public void LoadGame(System.Xml.XmlNode node)
		{
			// NOTE: Should this data really be saved in the save game? Points below... (Also note that the same goes for item templates).
			// + Easy to save orbital positions etc.
			// + Allows changes in the universe - destroying planets, moving moons, whatever.
			// + Makes save games more persistent
			// - Orbital positions don't need to be saved at all - just take the number of days since the start of the game and do some quick math.
			// - Makes save games more persistent - that is, you need to start a new game to make full use of a mod update.

			foreach (var el in node.SelectSingleNode("Galaxies").ChildNodes.OfType<XmlElement>())
			{
				var galaxy = new Galaxy(this);
				galaxy.FromXml(el);
				galaxies.Add(galaxy.Id, galaxy);
			}
		}

		/// <summary>
		/// Saves the component specific data to the specified save game node.
		/// </summary>
		/// <param name="node">The node.</param>
		public void SaveGame(System.Xml.XmlNode node)
		{
			var doc = node.OwnerDocument;

			XmlElement xmlGalaxies = doc.CreateElement("Galaxies");
			node.AppendChild(xmlGalaxies);
			foreach (var galaxy in galaxies)
			{
				var el = doc.CreateElement(galaxy.Key);
				galaxy.Value.ToXml(el);
				xmlGalaxies.AppendChild(el);
			}
		}

		#endregion

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
		}

		/// <summary>
		/// Loads the component data from the specified stream.
		/// </summary>
		/// <param name="stream">The input stream.</param>
		public void Load(System.IO.Stream stream)
		{
		}

		/// <summary>
		/// Saves the component data of the currently selected mod.
		/// </summary>
		public void Save()
		{
		}

		/// <summary>
		/// Saves the component data of the currently selected mod to the specified stream.
		/// </summary>
		/// <param name="stream">The target stream.</param>
		public void Save(System.IO.Stream stream)
		{
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
