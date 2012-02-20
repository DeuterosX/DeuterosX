using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core;
using System.Xml;

namespace Teraluwide.DeuterosEx.DeuterosGame.Stations
{
	/// <summary>
	/// Represents a base class for all station modules.
	/// </summary>
	public abstract class StationModuleBase
	{
		private StationBase parent;
		/// <summary>
		/// Gets the parent of this module.
		/// </summary>
		public StationBase Parent
		{
			get { return this.parent; }
		}

		/// <summary>
		/// Gets the game.
		/// </summary>
		protected BlackbirdGame Game { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="StationModuleBase"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public StationModuleBase(BlackbirdGame game)
		{
			this.Game = game;
		}

		/// <summary>
		/// Loads the station module from a XmlNode.
		/// </summary>
		/// <param name="node">The Xml node.</param>
		public virtual void LoadXml(XmlElement node)
		{

		}

		/// <summary>
		/// Saves the station module to a XmlNode.
		/// </summary>
		/// <param name="node">The Xml node.</param>
		public virtual void SaveXml(XmlElement node)
		{

		}

		/// <summary>
		/// Mounts the module to a station.
		/// </summary>
		public virtual void Mount(StationBase parent)
		{
			this.parent = parent;

		}

		/// <summary>
		/// Dismounts the module from a station.
		/// </summary>
		public virtual void Dismount()
		{

		}

		/// <summary>
		/// Processes the turn.
		/// </summary>
		public abstract void ProcessTurn();
	}
}
