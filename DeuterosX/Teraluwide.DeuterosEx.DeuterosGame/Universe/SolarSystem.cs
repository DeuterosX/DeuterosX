using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Teraluwide.Blackbird.Core;

namespace Teraluwide.DeuterosEx.DeuterosGame.Universe
{
	/// <summary>
	/// Description of SolarSystem.
	/// </summary>
	public sealed class SolarSystem
	{
		private Galaxy galaxy;
		/// <summary>
		/// Gets the parent galaxy.
		/// </summary>
		public Galaxy Galaxy { get { return this.galaxy; } }

		public SolarSystem(Galaxy galaxy)
		{
			this.galaxy = galaxy;
			bodies = new Dictionary<string, SpaceItem>();
		}
		
		private string id;
		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		/// <value>
		/// The id.
		/// </value>
		public string Id { get { return this.id; } set { this.id = value; } }

		private string name = "Unknown solar system";
		/// <summary>
		/// Gets or sets the name of this solar system.
		/// </summary>
		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

		private Dictionary<string, SpaceItem> bodies = null;
		/// <summary>
		/// Gets the bodies in this galaxy.
		/// </summary>
		public Dictionary<string, SpaceItem> Bodies
		{
			get { return this.bodies; }
		}

		/// <summary>
		/// Loads the solar system data from the specified XmlNode.
		/// </summary>
		/// <param name="node">The node.</param>
		public void FromXml(XmlElement node)
		{
			this.id = node.Name;
			this.name = node.GetAttributeOrNull("name");

			SpaceItem sit;
			bodies.Clear();
			foreach (var xSit in node.ChildNodes.OfType<XmlElement>())
			{
				sit = XmlHelper.CreateType(Galaxy.Manager.Game, xSit.GetAttributeOrNull("type"), null, this) as SpaceItem;
				sit.FromXml(xSit);

				bodies.Add(xSit.Name, sit);
			}
		}

		/// <summary>
		/// Saves the solar system data to the specified XmlNode.
		/// </summary>
		/// <param name="node">The node.</param>
		public void ToXml(XmlElement node)
		{
			XmlDocument doc = node.OwnerDocument;
			
			var at = doc.CreateAttribute("name");
			at.Value = this.name;
			node.Attributes.Append(at);

			XmlElement xBody;
			foreach (KeyValuePair<string, SpaceItem> body in this.bodies)
			{
				xBody = doc.CreateElement(body.Key);
				at = doc.CreateAttribute("type");
				at.Value = body.Value.GetType().ToString();
				xBody.Attributes.Append(at);

				node.AppendChild(xBody);

				body.Value.ToXml(xBody);
			}
		}
	}

}
