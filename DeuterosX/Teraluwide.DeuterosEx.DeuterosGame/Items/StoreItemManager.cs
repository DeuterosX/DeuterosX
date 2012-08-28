using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core;
using System.Xml;
using Teraluwide.DeuterosEx.DeuterosGame.Properties;

namespace Teraluwide.DeuterosEx.DeuterosGame.Items
{
	public class StoreItemManager : IBlackbirdSavegameComponent, ICustomBlackbirdComponent
	{
		const string FileName = "Items.xml";

		BlackbirdGame game;
		Dictionary<string, StoreItem> storeItems;
        Dictionary<string, StoreItem> researchItems;
        Dictionary<string, StoreItem> productionItems;

		/// <summary>
		/// Gets the store items.
		/// </summary>
		public Dictionary<string, StoreItem> StoreItems { get { return this.storeItems; } }

        public Dictionary<string, StoreItem> ProductionItems { get { return this.productionItems; } }

        public Dictionary<string, StoreItem> ResearchItems { get { return this.productionItems; } }

		/// <summary>
		/// Initializes a new instance of the <see cref="StoreItemManager"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public StoreItemManager(BlackbirdGame game)
		{
			this.game = game;
			this.storeItems = new Dictionary<string, StoreItem>();
            this.researchItems = new Dictionary<string, StoreItem>();
            this.productionItems = new Dictionary<string, StoreItem>();
		}

		#region IBlackbirdSavegameComponent Members

		/// <summary>
		/// Loads the component specific data from the specified save game node.
		/// </summary>
		/// <param name="node">The node.</param>
		public void LoadGame(System.Xml.XmlNode node)
		{
			foreach (var el in node.SelectSingleNode("ResearchedItems").ChildNodes.OfType<XmlElement>())
			{
				string itemName = el.Name;

				// Set as researched
				if (storeItems.ContainsKey(itemName))
					storeItems[itemName].ResearchProgress = int.Parse(el.GetAttributeOrNull("researchProgress") ?? "0");

			}
		}

		/// <summary>
		/// Saves the component specific data to the specified save game node.
		/// </summary>
		/// <param name="node">The node.</param>
		public void SaveGame(System.Xml.XmlNode node)
		{
			var doc = node.OwnerDocument;

			XmlElement xmlResearchedItems = doc.CreateElement("ResearchedItems");
			node.AppendChild(xmlResearchedItems);

			foreach (var item in storeItems)
			{
				var el = doc.CreateElement(item.Key);
				el.Attributes.Append(doc.CreateAttributeWithValue("researchProgress", item.Value.ResearchProgress.ToString()));
				xmlResearchedItems.AppendChild(el);
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
			get { return "StoreItemManager"; }
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
			Load(VirtualPathProvider.GetFile(VirtualPathProvider.EnsureModVirtualPath(FileName, Game.ModName)));
		}

		/// <summary>
		/// Loads the component data from the specified stream.
		/// </summary>
		/// <param name="stream">The input stream.</param>
		public void Load(System.IO.Stream stream)
		{
			XmlDocument doc = new XmlDocument();
			try
			{
				doc.Load(stream);
			}
			catch (XmlException ex)
			{
				throw new BlackbirdException(string.Format(Teraluwide.Blackbird.Core.Properties.Resources.ModFileIsInIncorrectFormatException, FileName), ex);
			}
			finally
			{
				stream.Close();
			}

			XmlElement root = doc.SelectSingleNode("/FDRFile") as XmlElement;

			if (root == null || root.Attributes["type"].Value != "items")
				throw new BlackbirdException(string.Format(Teraluwide.Blackbird.Core.Properties.Resources.ModFileIsInIncorrectFormatException, FileName));

			Log.WriteMessage(string.Format(Resources.ItemsDefinitionVersion, root.Attributes["version"].Value));

			foreach (XmlElement el in root.SelectNodes("ItemTemplates/*"))
			{
				StoreItem item = XmlHelper.CreateType(Game, el.GetAttributeOrNull("type")) as StoreItem;
				item.FromXml(el);
				storeItems.Add(item.Id, item);

                if (item.ShowInProductionScreen)
                {
                    productionItems.Add(item.Id, item);
                }
                if (item.ShowInResearchScreen)
                {
                    researchItems.Add(item.Id, item);
                }
			}
		}

		/// <summary>
		/// Saves the component data of the currently selected mod.
		/// </summary>
		public void Save()
		{
			Save(VirtualPathProvider.CreateFile(VirtualPathProvider.EnsureModVirtualPath(FileName, Game.ModName)));
		}

		/// <summary>
		/// Saves the component data of the currently selected mod to the specified stream.
		/// </summary>
		/// <param name="stream">The target stream.</param>
		public void Save(System.IO.Stream stream)
		{
			throw new NotImplementedException();
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


		/// <summary>
		/// Gets the store item with the specified id.
		/// </summary>
		/// <param name="id">The id.</param>
		/// <returns></returns>
		public StoreItem GetStoreItem(string id)
		{
			if (storeItems.ContainsKey(id))
				return storeItems[id];
			else
				return null;
		}
	}
}
