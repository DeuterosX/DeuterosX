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
		/// Performs all necessary changes when advancing the simulation (ie. "Next turn").
		/// </summary>
		void Advance();
	}
}
