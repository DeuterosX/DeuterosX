using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Teraluwide.Blackbird.Core
{
	/// <summary>
	/// Represents a Blackbird Engine Component.
	/// </summary>
	public interface IBlackbirdComponent : IDisposable
	{
		/// <summary>
		/// Gets the game instance associated with this component instance.
		/// </summary>
		/// <value>The game.</value>
		BlackbirdGame Game { get; }

		/// <summary>
		/// Loads the component data for the currently selected mod.
		/// </summary>
		void Load();

		/// <summary>
		/// Loads the component data from the specified stream.
		/// </summary>
		/// <param name="stream">The input stream.</param>
		void Load(Stream stream);

		/// <summary>
		/// Saves the component data of the currently selected mod.
		/// </summary>
		void Save();

		/// <summary>
		/// Saves the component data of the currently selected mod to the specified stream.
		/// </summary>
		/// <param name="stream">The target stream.</param>
		void Save(Stream stream);
	}
}
