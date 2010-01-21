using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core;
using System.IO;

namespace Teraluwide.DeuterosEx.DeuterosGame.Screens
{
	/// <summary>
	/// Represents a game screen for station view.
	/// </summary>
	public class StationGameScreen : MainGameScreen
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="StationGameScreen"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public StationGameScreen(BlackbirdGame game)
			: base(game)
		{ }

		/// <summary>
		/// Loads the component data for the currently selected mod.
		/// </summary>
		public override void Load()
		{
			
		}

		/// <summary>
		/// Loads the component data from the specified stream.
		/// </summary>
		/// <param name="stream">The input stream.</param>
		public override void Load(Stream stream)
		{
			
		}

		/// <summary>
		/// Saves the component data of the currently selected mod.
		/// </summary>
		public override void Save()
		{
			
		}

		/// <summary>
		/// Saves the component data of the currently selected mod to the specified stream.
		/// </summary>
		/// <param name="stream">The target stream.</param>
		public override void Save(Stream stream)
		{
			
		}

		/// <summary>
		/// Renders the IRenderable to the specified surface.
		/// </summary>
		/// <param name="surface">The target surface.</param>
		public override void Render()
		{
			base.Render();
		}
	}
}
