using System;
using System.Collections.Generic;
using System.Text;
using Teraluwide.Blackbird.Core.Gui;

namespace Teraluwide.Blackbird.Core
{
	/// <summary>
	/// Represents a single game screen in the game.
	/// </summary>
	public abstract class GameScreen : IDisposable, IBlackbirdComponent, IRenderable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GameScreen"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public GameScreen(BlackbirdGame game, string faceId)
		{
			this.Game = game;
			this.FaceId = faceId;
		}

		/// <summary>
		/// Gets or sets the face id.
		/// </summary>
		/// <value>The face id.</value>
		public string FaceId { get; private set; }

		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public virtual void Dispose()
		{
			
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
		public abstract void Load();

		/// <summary>
		/// Loads the component data from the specified stream.
		/// </summary>
		/// <param name="stream">The input stream.</param>
		public abstract void Load(System.IO.Stream stream);

		/// <summary>
		/// Saves the component data of the currently selected mod.
		/// </summary>
		public abstract void Save();
		/// <summary>
		/// Saves the component data of the currently selected mod to the specified stream.
		/// </summary>
		/// <param name="stream">The target stream.</param>
		public abstract void Save(System.IO.Stream stream);

		#endregion

		#region IRenderable Members

		/// <summary>
		/// Renders the IRenderable to the specified surface.
		/// </summary>
		/// <param name="surface">The target surface.</param>
		public virtual void Render()
		{
			GuiFace face = Game.GuiManager.GetFace(FaceId);

			if (face != null)
				face.Render(0, 0);
		}

		#endregion
	}
}
