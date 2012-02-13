using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Teraluwide.DeuterosEx.DeuterosGame.Stations
{
	/// <summary>
	/// Represents a mining store station module.
	/// </summary>
	public class MiningStoreStationModule : StationModuleBase
	{
		const int MaxItemStorage = 150;
		const int MaxMaterialStorage = 50000;

		/// <summary>
		/// Gets the store materials.
		/// </summary>
		public Dictionary<string, int> StoreMaterials { get; private set; }
		/// <summary>
		/// Gets the store items.
		/// </summary>
		public Dictionary<string, int> StoreItems { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="StationModuleMiningStore"/> class.
		/// </summary>
		public MiningStoreStationModule()
		{
			this.StoreItems = new Dictionary<string, int>();
			this.StoreMaterials = new Dictionary<string, int>();

			LoadItemTemplates();
		}

		/// <summary>
		/// Adds the specified item or material to the stores in the specified amount. The maximum storage size is respected; returns how much of the amount has been really added.
		/// </summary>
		/// <param name="isItem">if set to <c>true</c>, the object to check is an item.</param>
		/// <param name="id">The id of the item.</param>
		/// <param name="amount">The amount to add.</param>
		/// <returns>The amount successfully added to storage.</returns>
		public int AddToStorage(bool isItem, string id, int amount)
		{
			if (isItem)
			{
				int toadd = amount;
				if (StoreItems[id] + amount > MaxItemStorage) toadd = MaxItemStorage - StoreItems[id];

				StoreItems[id] += toadd;

				return toadd;
			}
			else
			{
				int toadd = amount;
				if (StoreMaterials[id] + amount > MaxMaterialStorage) toadd = MaxMaterialStorage - StoreMaterials[id];

				StoreMaterials[id] += toadd;
				
				return toadd;
			}
		}

		/// <summary>
		/// Checks the storage for the specified amount of the item or material. Returns false if there's not enough in the stores.
		/// </summary>
		/// <param name="isItem">if set to <c>true</c>, the object to check is an item.</param>
		/// <param name="id">The id of the item.</param>
		/// <param name="amount">The amount to check.</param>
		/// <returns></returns>
		public bool CheckStorage(bool isItem, string id, int amount)
		{
			if (isItem)
			{
				if (StoreItems[id] - amount < 0)
					return false;
				else
					return true;
			}
			else
			{
				if (StoreMaterials[id] - amount < 0)
					return false;
				else
					return true;
			}
		}

		/// <summary>
		/// Removes the specified amount of the item or material from storage, if available. Returns false if there's not enough in the stores.
		/// </summary>
		/// <param name="isItem">if set to <c>true</c>, the object to remove is an item.</param>
		/// <param name="id">The id of the item.</param>
		/// <param name="amount">The amount to remove.</param>
		/// <returns></returns>
		public bool RemoveFromStorage(bool isItem, string id, int amount)
		{
			if (isItem)
			{
				if (StoreItems[id] - amount < 0)
					return false;
				else
				{
					StoreItems[id] -= amount;

					return true;
				}
			}
			else
			{
				if (StoreMaterials[id] - amount < 0)
					return false;
				else
				{
					StoreMaterials[id] -= amount;

					return true;
				}
			}
		}

		/// <summary>
		/// Loads the item templates.
		/// </summary>
		void LoadItemTemplates()
		{
			// TODO: Port the item templates

			//foreach (KeyValuePair<string, StoreItem> it in GameEngine.Instance.ItemTemplates)
			//{
			//  if (it.Value != null)
			//  {
			//    if (it.Value.Type == ItemType.Mineral)
			//    {
			//      this.StoreMaterials.Add(it.Key, 0);
			//    }
			//    else
			//    {
			//      this.StoreItems.Add(it.Key, 0);
			//    }
			//  }
			//}
		}

		/// <summary>
		/// Loads the station module from a XmlNode.
		/// </summary>
		/// <param name="node">The Xml node.</param>
		public override void LoadXml(XmlElement node)
		{
			base.LoadXml(node);

			XmlDocument doc = node.OwnerDocument;

			XmlElement el;

			StoreMaterials.Clear();
			StoreItems.Clear();

			LoadItemTemplates();

			el = node["StoreMaterials"];
			foreach (XmlNode xMat in el.ChildNodes)
			{
				StoreMaterials[xMat.Name] = int.Parse(xMat.InnerText);
			}

			el = node["StoreItems"];
			foreach (XmlNode xIt in el.ChildNodes)
			{
				StoreItems[xIt.Name] = int.Parse(xIt.InnerText);
			}
		}

		/// <summary>
		/// Saves the station module to a XmlNode.
		/// </summary>
		/// <param name="node">The Xml node.</param>
		public override void SaveXml(XmlElement node)
		{
			base.SaveXml(node);

			XmlDocument doc = node.OwnerDocument;

			XmlElement el = doc.CreateElement("StoreMaterials");
			node.AppendChild(el);

			XmlElement el2;

			foreach (KeyValuePair<string, int> it in this.StoreMaterials)
			{
				el2 = doc.CreateElement(it.Key);
				el2.InnerText = it.Value.ToString();
				el.AppendChild(el2);
			}

			el = doc.CreateElement("StoreItems");
			node.AppendChild(el);

			foreach (KeyValuePair<string, int> it in this.StoreItems)
			{
				el2 = doc.CreateElement(it.Key.Replace(" ", "_"));
				el2.InnerText = it.Value.ToString();
				el.AppendChild(el2);
			}
		}


		/// <summary>
		/// Processes the turn.
		/// </summary>
		public override void ProcessTurn()
		{
			// Nothing to do in the mining store
		}
	}
}
