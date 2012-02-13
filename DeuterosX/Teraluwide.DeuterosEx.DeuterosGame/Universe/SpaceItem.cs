using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core;
using System.Xml;

namespace Teraluwide.DeuterosEx.DeuterosGame.Universe
{
	/// <summary>
	/// Defines a celestial body under solar system.
	/// </summary>
	public class SpaceItem
	{
		SpaceItem parent;
		/// <summary>
		/// Gets the parent space item (if any).
		/// </summary>
		public SpaceItem Parent { get { return this.parent; } }

		SolarSystem solarSystem;
		/// <summary>
		/// Gets the parent solar system.
		/// </summary>
		public SolarSystem SolarSystem { get { return this.solarSystem; } }

		private Dictionary<string, SpaceItem> satellites;
		/// <summary>
		/// Gets the satellites of this celestial body.
		/// </summary>
		public Dictionary<string, SpaceItem> Satellites { get { return this.satellites; } }

		// TODO: Add orbital parameters - radius, eccentricity, phase, inclination

		/// <summary>
		/// Initializes a new instance of the <see cref="SpaceItem"/> class.
		/// </summary>
		public SpaceItem(SpaceItem parent, SolarSystem solarSystem)
		{
			this.parent = parent;
			this.solarSystem = solarSystem;

			this.satellites = new Dictionary<string, SpaceItem>();
			this.minerals = new Dictionary<string, SurveyInfo>();

			// TODO: Port the item templates.
			//foreach (KeyValuePair<string, StoreItem> min in GameEngine.Instance.ItemTemplates)
			//{
			//  if (min.Value.Type == ItemType.Mineral)
			//  {
			//    minerals.Add(min.Key, new SurveyInfo());
			//  }
			//}
		}

		private string id;
		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		/// <value>
		/// The id.
		/// </value>
		public string Id { get { return this.id; } set { this.id = value; } }

		private string name = "Earth";
		/// <summary>
		/// Gets or sets the body name.
		/// </summary>
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private Dictionary<string, SurveyInfo> minerals = null;
		/// <summary>
		/// Gets the survey information.
		/// </summary>
		public Dictionary<string, SurveyInfo> Minerals
		{
			get { return minerals; }
		}

		/// <summary>
		/// Gets the celestial body information from the specified XmlNode.
		/// </summary>
		/// <param name="node">The node.</param>
		public void FromXml(XmlElement node)
		{
			this.id = node.Name;
			this.name = node.GetAttributeOrNull("name");

			SurveyInfo mineral;
			foreach (XmlElement xMineral in node["Surveys"].ChildNodes.OfType<XmlElement>())
			{
				mineral = new SurveyInfo(this);
				mineral.FromXml(xMineral);
				this.minerals[xMineral.Name] = mineral;
			}

			foreach (XmlElement xSpaceItem in node["Satellites"].ChildNodes.OfType<XmlElement>())
			{
				var item = XmlHelper.CreateType(SolarSystem.Galaxy.Manager.Game, xSpaceItem.GetAttributeOrNull("type"), this, SolarSystem) as SpaceItem;
				item.FromXml(xSpaceItem);

				satellites.Add(item.Id, item);
			}
		}

		/// <summary>
		/// Saves the celestial body information to the specified XmlNode.
		/// </summary>
		/// <param name="node">The node.</param>
		public void ToXml(XmlElement node)
		{
			XmlDocument doc = node.OwnerDocument;

			var attr = doc.CreateAttribute("name");
			attr.Value = this.name;
			node.Attributes.Append(attr);


			XmlNode surveys = doc.CreateElement("Surveys");
			node.AppendChild(surveys);

			XmlNode xMineral;
			foreach (var mineral in this.minerals)
			{
				xMineral = doc.CreateElement(mineral.Key);
				surveys.AppendChild(xMineral);
				mineral.Value.ToXml(xMineral);
			}

			XmlElement xSatellites = doc.CreateElement("Satellites");
			node.AppendChild(xSatellites);
			
			foreach (var satellite in this.satellites)
			{
				var xSatellite = doc.CreateElement(satellite.Key);
				satellite.Value.ToXml(xSatellite);
				xSatellites.AppendChild(xSatellite);
			}
		}
	}
}
