using System;
namespace Teraluwide.Blackbird.Core
{
	public interface IBlackbirdSavegameComponent : ICustomBlackbirdComponent
	{
		/// <summary>
		/// Loads the component specific data from the specified save game node.
		/// </summary>
		/// <param name="node">The node.</param>
		void LoadGame(System.Xml.XmlNode node);

		/// <summary>
		/// Saves the component specific data to the specified save game node.
		/// </summary>
		/// <param name="node">The node.</param>
		void SaveGame(System.Xml.XmlNode node);
	}
}
