using System;
using System.Collections.Generic;
using System.Text;

namespace Teraluwide.Blackbird.Core
{
	public class GuiMenuManager : IBlackbirdComponent
	{
		private BlackbirdGame game;
		private Dictionary<string, GuiMenu> innerData = new Dictionary<string, GuiMenu>();

		/// <summary>
		/// Initializes a new instance of the <see cref="GuiMenuManager"/> class.
		/// </summary>
		/// <param name="game">The game instance.</param>
		public GuiMenuManager(BlackbirdGame game)
		{
			this.game = game;
			innerData = new Dictionary<string, GuiMenu>();
		}

		#region IBlackbirdComponent Members

		/// <summary>
		/// Gets the game instance associated with this component instance.
		/// </summary>
		/// <value>The game.</value>
		public BlackbirdGame Game
		{
			get { return this.game; }
		}

		/// <summary>
		/// Loads the component data for the currently selected mod.
		/// </summary>
		public void Load()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Loads the component data from the specified stream.
		/// </summary>
		/// <param name="stream">The input stream.</param>
		public void Load(System.IO.Stream stream)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Saves the component data of the currently selected mod.
		/// </summary>
		public void Save()
		{
			throw new NotImplementedException();
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
	}
}
