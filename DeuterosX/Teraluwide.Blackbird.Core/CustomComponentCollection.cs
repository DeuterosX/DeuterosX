using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Teraluwide.Blackbird.Core
{
	/// <summary>
	/// Represents a custom component collection indexed by component unique identifier.
	/// </summary>
	public class CustomComponentCollection : Dictionary<string, ICustomBlackbirdComponent>
	{
		/// <summary>
		/// Loads the component data for the currently selected mod.
		/// </summary>
		public void Load()
		{
			foreach (ICustomBlackbirdComponent component in this.Values)
				component.Load();
		}

		/// <summary>
		/// Saves the component data of the currently selected mod.
		/// </summary>
		public void Save()
		{
			foreach (ICustomBlackbirdComponent component in this.Values)
				component.Save();
		}

		/// <summary>
		/// Loads the component specific data from the specified save game node.
		/// </summary>
		/// <param name="node">The parent node.</param>
		public void LoadGame(XmlNode node)
		{
			foreach (XmlNode component in node.ChildNodes)
			{
				if (this.ContainsKey(component.Name))
				{
					IBlackbirdSavegameComponent sim = this[component.Name] as IBlackbirdSavegameComponent;

					if (sim != null)
						sim.LoadGame(component);
				}
			}
		}

		/// <summary>
		/// Saves the component specific data to the specified save game node.
		/// </summary>
		/// <param name="node">The parent node.</param>
		public void SaveGame(XmlNode node)
		{
			foreach (ICustomBlackbirdComponent component in this.Values)
			{
				IBlackbirdSavegameComponent sim = component as IBlackbirdSavegameComponent;

				if (sim != null)
				{
					XmlElement el = node.OwnerDocument.CreateElement(sim.Id);
					node.AppendChild(el);
					sim.SaveGame(el);
				}
			}
		}

		/// <summary>
		/// Performs all necessary changes when advancing the simulation (ie. "Next turn").
		/// </summary>
		public void Advance()
		{
			foreach (ICustomBlackbirdComponent component in this.Values)
			{
				IBlackbirdSimulationComponent sim = component as IBlackbirdSimulationComponent;

				if (sim != null)
					sim.Advance();
			}
		}
	}
}
