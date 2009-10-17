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
		/// Loads the station module from a XmlNode.
		/// </summary>
		/// <param name="node">The Xml node.</param>
		public virtual void LoadXml(XmlNode node)
		{
		}

		/// <summary>
		/// Saves the station module to a XmlNode.
		/// </summary>
		/// <param name="node">The Xml node.</param>
		public virtual void SaveXml(XmlNode node)
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
