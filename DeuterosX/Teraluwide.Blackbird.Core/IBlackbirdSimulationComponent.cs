using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Teraluwide.Blackbird.Core
{
	/// <summary>
	/// Represents a shared data structure with savegame and modgame input/output and simulation cycle updates.
	/// </summary>
	public interface IBlackbirdSimulationComponent : ICustomBlackbirdComponent
	{
		/// <summary>
		/// Loads the component specific data from the specified save game node.
		/// </summary>
		/// <param name="node">The node.</param>
		void LoadGame(XmlNode node);

		/// <summary>
		/// Saves the component specific data to the specified save game node.
		/// </summary>
		/// <param name="node">The node.</param>
		void SaveGame(XmlNode node);

		/// <summary>
		/// Performs all necessary changes when advancing the simulation (ie. "Next turn").
		/// </summary>
		void Advance();
	}
}
