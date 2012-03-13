using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.DeuterosEx.DeuterosGame.Universe;
using System.Xml;
using Teraluwide.Blackbird.Core;
using Teraluwide.DeuterosEx.DeuterosGame.Items;

namespace Teraluwide.DeuterosEx.DeuterosGame.Stations
{
	public class MiningFacilityStationModule : StationModuleBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MiningFacilityStationModule"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public MiningFacilityStationModule(BlackbirdGame game)
			: base(game)
		{
			mines = new Dictionary<string, MiningOperationInfo>();
		}

		private int derricks = 1;
		/// <summary>
		/// Gets or sets the current number of derricks on this module
		/// </summary>
		public int Derricks
		{
			get { return derricks; }
			set { derricks = value; }
		}

		private Dictionary<string, MiningOperationInfo> mines = null;
		/// <summary>
		/// Gets current mines under this module.
		/// </summary>
		public Dictionary<string, MiningOperationInfo> Mines
		{
			get { return mines; }
		}

		private SpaceItem location = null;
		/// <summary>
		/// Gets the body this module binds to.
		/// </summary>
		public SpaceItem Location
		{
			get
			{
				if (location == null)
				{
					Galaxy gal;
					SolarSystem sys;
					SpaceItem body;
					
					string[] locstr = Parent.Location.Split('.');

					// Find the galaxy...
					if ((Parent.Game as Game).UniverseManager.Galaxies.ContainsKey(locstr[0]))
						gal = (Parent.Game as Game).UniverseManager.Galaxies[locstr[0]];
					else
						return null;

					// The solar system...
					if (gal.Systems.ContainsKey(locstr[1]))
						sys = gal.Systems[locstr[1]];
					else
						return null;

					// The planet...
					if (sys.Bodies.ContainsKey(locstr[2]))
						body = sys.Bodies[locstr[2]];
					else
						return null;

					// And check the satellites too...
					for (int i = 3; i < locstr.Length; i++)
					{
						if (body.Satellites.ContainsKey(locstr[i]))
							body = body.Satellites[locstr[i]];
						else
							return null;
					}

					// And store the location for later.
					return location = body;
				}
				else
					return location;
			}
		}

		private MiningStoreStationModule store = null;
		/// <summary>
		/// Gets the mining store this module uses to store extracted materials.
		/// </summary>
		public MiningStoreStationModule Store
		{
			get
			{
				if (this.store == null || this.store.Parent != this.Parent)
				{
					// Find the mining store on this station.
					return store = Parent.GetModule<MiningStoreStationModule>();
				}
				else
					return this.store;
			}
		}

		/// <summary>
		/// Adds another derrick to the mining facility
		/// </summary>
		public void AddDerrick()
		{
			if (Store.CheckStorage(true, "Derrick", 1))
			{
				Store.RemoveFromStorage(true, "Derrick", 1);

				derricks++;
			}
		}

		/// <summary>
		/// Prepares the mines using all the materials available in the item templates.
		/// </summary>
		public void PrepareMines()
		{
			foreach (var min in (Game as Game).StoreItemManager.StoreItems)
			{
				if (min.Value.Type == ItemType.Mineral && Location.Minerals.ContainsKey(min.Key))
					mines.Add(min.Key, new MiningOperationInfo { Id = min.Key });
			}
		}

		/// <summary>
		/// Loads the station module from a XmlNode.
		/// </summary>
		/// <param name="node">The Xml node.</param>
		public override void LoadXml(XmlElement node)
		{
			base.LoadXml(node);

			this.derricks = int.Parse(node.GetAttributeOrNull("derricks") ?? "0");

			var xMines = node.SelectSingleNode("Mines") as XmlElement;

			// If the save game doesn't contain mine data, create it from scratch.
			if (xMines == null)
			{
				mines.Clear();
			}
			// Otherwise load the saved data.
			else
			{
				mines.Clear();

				foreach (var el in xMines.ChildNodes.OfType<XmlElement>())
				{
					var moi = new MiningOperationInfo();
					moi.LoadXml(el);
					mines.Add(moi.Id, moi);
				}
			}
		}

		/// <summary>
		/// Mounts the module to a station.
		/// </summary>
		/// <param name="parent"></param>
		public override void Mount(StationBase parent)
		{
			base.Mount(parent);

			if (mines.Count == 0)
				PrepareMines();
		}

		/// <summary>
		/// Saves the station module to a XmlNode.
		/// </summary>
		/// <param name="node">The Xml node.</param>
		public override void SaveXml(XmlElement node)
		{
			base.SaveXml(node);

			var doc = node.OwnerDocument;

			node.Attributes.Append(doc.CreateAttributeWithValue("derricks", this.derricks.ToString()));

			var xMines = doc.CreateElement("Mines");
			node.AppendChild(xMines);

			foreach (var moi in Mines)
			{
				var xMoi = doc.CreateElement(moi.Key);
				moi.Value.SaveXml(xMoi);
				xMines.AppendChild(xMoi);
			}
		}

		/// <summary>
		/// Processes the turn.
		/// </summary>
		public override void ProcessTurn()
		{
			foreach (KeyValuePair<string, MiningOperationInfo> moi in Mines)
			{
				if (moi.Value.SurveyProgress > 0) moi.Value.SurveyProgress--;
				else if (moi.Value.SurveyProgress == 0)
				{
					// Generate a new "deposit"
					moi.Value.CurrentMiningLimit = Location.Minerals[moi.Key].NewSurvey();
					Log.WriteMessage(string.Format("Mining facility on {0} found a new deposit of {1}!", Parent.Title, moi.Key));

					moi.Value.SurveyProgress = -1;
				}
				else if (moi.Value.SurveyProgress == -1)
				{
					int amnt = -(Game as Game).StoreItemManager.StoreItems[moi.Key].BuildTime * derricks;

					if (moi.Value.CurrentMiningLimit < amnt) amnt = moi.Value.CurrentMiningLimit;

					moi.Value.CurrentMiningLimit -= amnt;

					Store.AddToStorage(false, moi.Key, amnt);

					// Once the deposit is mined out, start a new survey.
					if (moi.Value.CurrentMiningLimit == 0)
					{
						moi.Value.SurveyProgress = 10;
					}
				}
			}
		}
	}
}
