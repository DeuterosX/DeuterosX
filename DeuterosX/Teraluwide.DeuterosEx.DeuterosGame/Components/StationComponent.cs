using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core;
using System.Xml;
using System.IO;

namespace Teraluwide.DeuterosEx.DeuterosGame.Components
{
	public class StationComponent : IBlackbirdSimulationComponent
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="StationComponent"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public StationComponent(BlackbirdGame game)
		{
			this.Game = game;
		}

		#region IBlackbirdSimulationComponent Members

		/// <summary>
		/// Loads the component specific data from the specified save game node.
		/// </summary>
		/// <param name="node">The node.</param>
		public void LoadGame(XmlNode node)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Saves the component specific data to the specified save game node.
		/// </summary>
		/// <param name="node">The node.</param>
		public void SaveGame(XmlNode node)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Performs all necessary changes when advancing the simulation (ie. "Next turn").
		/// </summary>
		public void Advance()
		{
			throw new NotImplementedException();
		}

		#endregion

		#region ICustomBlackbirdComponent Members

		/// <summary>
		/// Gets the unique identifier of this custom component.
		/// </summary>
		/// <value>The unique identifier of this custom component.</value>
		public string Id
		{
			get { throw new NotImplementedException(); }
		}

		#endregion

		#region IBlackbirdComponent Members

		/// <summary>
		/// Gets the game instance associated with this component instance.
		/// </summary>
		/// <value>The game.</value>
		public BlackbirdGame Game { get; private set; }

		/// <summary>
		/// Loads the component data for the currently selected mod.
		/// </summary>
		public void Load()
		{
			
		}

		/// <summary>
		/// Loads the component data from the specified stream.
		/// </summary>
		/// <param name="stream">The input stream.</param>
		public void Load(Stream stream)
		{
			
		}

		/// <summary>
		/// Saves the component data of the currently selected mod.
		/// </summary>
		public void Save()
		{
			
		}

		/// <summary>
		/// Saves the component data of the currently selected mod to the specified stream.
		/// </summary>
		/// <param name="stream">The target stream.</param>
		public void Save(Stream stream)
		{
			
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
	}
}
