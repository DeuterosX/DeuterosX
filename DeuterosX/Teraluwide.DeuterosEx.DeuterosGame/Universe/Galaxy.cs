
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Teraluwide.Blackbird.Core;

namespace Teraluwide.DeuterosEx.DeuterosGame.Universe
{
	/// <summary>
	/// Represents a galaxy in the game.
	/// </summary>
	public sealed class Galaxy
	{
		UniverseManager manager;
		/// <summary>
		/// Gets the parent manager.
		/// </summary>
		public UniverseManager Manager { get { return this.manager; } }

		public Galaxy(UniverseManager manager)
		{
			this.manager = manager;
			systems = new Dictionary<string, SolarSystem>();
		}

		private string name = "Unknown galaxy";
		/// <summary>
		/// Gets or sets the name of this galaxy.
		/// </summary>
		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

		private string id = "UnknownGalaxy";
		/// <summary>
		/// Gets or sets the name of this galaxy.
		/// </summary>
		public string Id
		{
			get { return this.id; }
			set { this.id = value; }
		}

		private Dictionary<string, SolarSystem> systems = null;
		/// <summary>
		/// Gets the solar systems in this galaxy.
		/// </summary>
		public Dictionary<string, SolarSystem> Systems
		{
			get { return this.systems; }
		}

		/// <summary>
		/// Loads the galaxy data from the specified XmlNode.
		/// </summary>
		/// <param name="node">The node.</param>
		public void FromXml(XmlElement node)
		{
			this.id = node.Name;
			this.name = node.GetAttributeOrNull("name");

			SolarSystem sol;
			systems.Clear();
			foreach (var xSol in node.ChildNodes.OfType<XmlElement>())
			{
				sol = new SolarSystem(this);
				sol.FromXml(xSol);

				systems.Add(xSol.Name, sol);
			}
		}

		/// <summary>
		/// Saves the galaxy data to the specified XmlNode.
		/// </summary>
		/// <param name="node">The node.</param>
		public void ToXml(XmlElement node)
		{
			XmlDocument doc = node.OwnerDocument;
			
			var at = doc.CreateAttribute("name");
			at.Value = this.name;
			node.Attributes.Append(at);

			XmlElement xSol;
			foreach (KeyValuePair<string, SolarSystem> sol in this.systems)
			{
				xSol = doc.CreateElement(sol.Key);
				at = doc.CreateAttribute("type");
				at.Value = sol.Value.GetType().ToString();
				xSol.Attributes.Append(at);

				node.AppendChild(xSol);

				sol.Value.ToXml(xSol);
			}
		}
	}


}
