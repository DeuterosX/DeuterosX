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
	public class StationModuleBase
	{
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
	}
}
