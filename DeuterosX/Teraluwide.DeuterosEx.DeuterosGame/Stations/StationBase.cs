using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Teraluwide.Blackbird.Core;
using Teraluwide.DeuterosEx.DeuterosGame.Properties;

namespace Teraluwide.DeuterosEx.DeuterosGame.Stations
{
	/// <summary>
	/// Represents a base class for all the stations in the game.
	/// </summary>
	public class StationBase
	{
		/// <summary>
		/// Gets or sets the game.
		/// </summary>
		/// <value>The game.</value>
		public BlackbirdGame Game { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="StationBase"/> class.
		/// </summary>
		public StationBase(BlackbirdGame game)
		{
			this.Game = game;
			modules = new List<StationModuleBase>();
		}

		protected string title = "Station";
		/// <summary>
		/// Gets or sets the station title.
		/// </summary>
		public string Title
		{
			get { return title; }
			set { title = value; }
		}

		private string location = "MilkyWay.Sol.Earth";
		/// <summary>
		/// Gets or sets the station location (Galaxy.SolarSystem.Body).
		/// </summary>
		public string Location
		{
			get { return location; }
			set { location = value; }
		}

		private string owner = "Player";
		/// <summary>
		/// Gets or sets the station owner.
		/// </summary>
		public string Owner
		{
			get { return owner; }
			set { owner = value; }
		}

		protected List<StationModuleBase> modules = null;
		/// <summary>
		/// Gets station modules
		/// </summary>
		public List<StationModuleBase> Modules
		{
			get { return this.modules; }
		}

		/// <summary>
		/// Loads the station from a XmlElement.
		/// </summary>
		/// <param name="node">The Xml node.</param>
		public virtual void LoadXml(XmlElement node)
		{
			this.title = node.GetAttributeOrNull("title");
			this.location = node.GetAttributeOrNull("location");
			this.owner = node.GetAttributeOrNull("owner");

			this.modules.Clear();
			foreach (XmlElement xMod in node["Modules"].ChildNodes.OfType<XmlElement>())
			{
				StationModuleBase mod = XmlHelper.CreateType(Game, xMod.Name) as StationModuleBase;
				if (mod == null)
					throw new DeuterosException(string.Format(Resources.InvalidStationModule, xMod.Name));

				mod.LoadXml(xMod);
				this.MountModule(mod);
			}
		}

		/// <summary>
		/// Saves the station to a XmlElement.
		/// </summary>
		/// <param name="node">The Xml node.</param>
		public virtual void SaveXml(XmlElement node)
		{
			XmlDocument doc = node.OwnerDocument;

			XmlAttribute at = doc.CreateAttribute("type");
			at.Value = this.GetType().ToString();
			node.Attributes.Append(at);

			at = doc.CreateAttribute("title");
			at.Value = title;
			node.Attributes.Append(at);

			at = doc.CreateAttribute("location");
			at.Value = this.location;
			node.Attributes.Append(at);

			at = doc.CreateAttribute("owner");
			at.Value = this.owner;
			node.Attributes.Append(at);

			XmlElement el = doc.CreateElement("Modules");
			node.AppendChild(el);

			for (int i = 0; i < modules.Count; i++)
			{
				if (modules[i] != null)
				{
					var xModule = doc.CreateElement(modules[i].GetType().ToString());
					modules[i].SaveXml(xModule);
					el.AppendChild(xModule);
				}
			}
		}

		/// <summary>
		/// Mounts a new module to the station
		/// </summary>
		/// <param name="module">Station module to mount</param>
		/// <returns>Negative if error. If successful, returns the module index.</returns>
		public virtual int MountModule(StationModuleBase module)
		{
			if (modules != null)
			{
				for (int i = 0; i < modules.Count; i++)
				{
					if (modules[i] != null && modules[i].GetType() == module.GetType())
					{
						return -2;
					}
				}

				modules.Add(module);
				module.Mount(this);

				return 0;
			}
			else
				return -3;
		}

		/// <summary>
		/// Dismounts mounted module
		/// </summary>
		/// <param name="index">Index of module to dismount</param>
		/// <returns>True if successful.</returns>
		public virtual bool DismountModule(StationModuleBase module)
		{
			if (modules != null)
			{
				module.Dismount();

				return modules.Remove(module);
			}
			else
				return false;
		}

		/// <summary>
		/// Performs all that is needed to build the station (ie. create all the default modules etc.).
		/// </summary>
		public virtual void Build()
		{

		}

		/// <summary>
		/// Process turn
		/// </summary>
		public virtual void ProcessTurn()
		{
			for (int i = 0; i < Modules.Count; i++)
			{
				if (Modules[i] != null)
				{
					Modules[i].ProcessTurn();
				}
			}
		}
		
		/// <summary>
		/// Gets the module.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public T GetModule<T>()
		{
			return Modules.OfType<T>().FirstOrDefault();
		}
	}

}
