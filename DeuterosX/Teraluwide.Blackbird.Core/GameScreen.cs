using System;
using System.Collections.Generic;
using System.Text;
using Teraluwide.Blackbird.Core.Gui;

namespace Teraluwide.Blackbird.Core
{
	/// <summary>
	/// Represents a single game screen in the game.
	/// </summary>
	public class GameScreen : IDisposable, IRenderable
	{
		private BlackbirdGame game;

		/// <summary>
		/// Initializes a new instance of the <see cref="GameScreen"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public GameScreen(BlackbirdGame game, string faceId)
		{
			this.game = game;
			this.FaceId = faceId;
		}

		/// <summary>
		/// Gets the game instance associated with this game screen.
		/// </summary>
		/// <value>The game.</value>
		public BlackbirdGame Game { get { return this.game; } }

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
