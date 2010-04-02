using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core;

namespace Teraluwide.DeuterosEx.DeuterosGame.Screens
{
	/// <summary>
	/// Represents the base game screen for most screens in the game. Handles the menu.
	/// </summary>
	public class MainGameScreen : GameScreen
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="MainGameScreen"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        public MainGameScreen(BlackbirdGame game, string faceId)
            : base(game, faceId)
        {
        }

        /// <summary>
        /// Loads the component data for the currently selected mod.
        /// </summary>
        public override void Load()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Loads the component data from the specified stream.
        /// </summary>
        /// <param name="stream">The input stream.</param>
        public override void Load(System.IO.Stream stream)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the component data of the currently selected mod.
        /// </summary>
        public override void Save()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the component data of the currently selected mod to the specified stream.
        /// </summary>
        /// <param name="stream">The target stream.</param>
        public override void Save(System.IO.Stream stream)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renders the IRenderable to the specified surface.
        /// </summary>
        public override void Render()
        {
            throw new NotImplementedException();
        }
    }
}
