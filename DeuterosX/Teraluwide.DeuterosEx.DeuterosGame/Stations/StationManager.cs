using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core;
using System.Xml;

namespace Teraluwide.DeuterosEx.DeuterosGame.Stations
{
	public class StationManager : IBlackbirdSavegameComponent, IBlackbirdSimulationComponent
	{
		BlackbirdGame game;
		List<StationBase> stations;

		/// <summary>
		/// Initializes a new instance of the <see cref="StationManager"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public StationManager(BlackbirdGame game)
		{
			this.game = game;
			this.stations = new List<StationBase>();
		}

		#region IBlackbirdSavegameComponent Members

		/// <summary>
		/// Loads the component specific data from the specified save game node.
		/// </summary>
		/// <param name="node">The node.</param>
		public void LoadGame(System.Xml.XmlNode node)
		{
			foreach (var el in node.SelectSingleNode("Stations").ChildNodes.OfType<XmlElement>())
			{
				var station = (StationBase)XmlHelper.CreateType(game, el.Attributes["type"].Value, game);
				station.LoadXml(el);
				stations.Add(station);
			}
		}

		/// <summary>
		/// Saves the component specific data to the specified save game node.
		/// </summary>
		/// <param name="node">The node.</param>
		public void SaveGame(System.Xml.XmlNode node)
		{
			var doc = node.OwnerDocument;

			XmlElement xmlStations = doc.CreateElement("Stations");
			node.AppendChild(xmlStations);
			foreach (var station in stations)
			{
				var el = doc.CreateElement("Station");
				station.SaveXml(el);
				xmlStations.AppendChild(el);
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
			get { return "StationManager"; }
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
		/// This basically means calling Advance on each of the station, which in turn do the same for their modules.
		/// </summary>
		public void Advance()
		{
			foreach (var station in stations)
				station.ProcessTurn();
		}

		#endregion
	}
}
