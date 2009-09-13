using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace Teraluwide.Blackbird.Core
{
	/// <summary>
	/// Represents a base Blackbird simulation component. Does nothing by default.
	/// </summary>
	public class BasicSimulationComponent : IBlackbirdSimulationComponent
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BasicSimulationComponent"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		/// <param name="id">The id.</param>
		public BasicSimulationComponent(BlackbirdGame game, string id)
		{
			this.Game = game;
			this.Id = id;
		}


		#region IBlackbirdSimulationComponent Members

		/// <summary>
		/// Loads the component specific data from the specified save game node.
		/// </summary>
		/// <param name="node">The node.</param>
		public virtual void LoadGame(XmlNode node) { }

		/// <summary>
		/// Saves the component specific data to the specified save game node.
		/// </summary>
		/// <param name="node">The node.</param>
		public virtual void SaveGame(XmlNode node) { }

		/// <summary>
		/// Performs all necessary changes when advancing the simulation (ie. "Next turn").
		/// </summary>
		public virtual void Advance() { }

		#endregion

		#region ICustomBlackbirdComponent Members

		/// <summary>
		/// Gets the unique identifier of this custom component.
		/// </summary>
		/// <value>The unique identifier of this custom component.</value>
		public virtual string Id { get; private set; }

		#endregion

		#region IBlackbirdComponent Members

		/// <summary>
		/// Gets the game instance associated with this component instance.
		/// </summary>
		/// <value>The game.</value>
		public virtual BlackbirdGame Game { get; private set; }

		/// <summary>
		/// Loads the component data for the currently selected mod.
		/// </summary>
		public virtual void Load() { }

		/// <summary>
		/// Loads the component data from the specified stream.
		/// </summary>
		/// <param name="stream">The input stream.</param>
		public virtual void Load(System.IO.Stream stream) { }

		/// <summary>
		/// Saves the component data of the currently selected mod.
		/// </summary>
		public virtual void Save() { }

		/// <summary>
		/// Saves the component data of the currently selected mod to the specified stream.
		/// </summary>
		/// <param name="stream">The target stream.</param>
		public virtual void Save(Stream stream) { }

		#endregion

		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public virtual void Dispose() { }

		#endregion
	}
}
