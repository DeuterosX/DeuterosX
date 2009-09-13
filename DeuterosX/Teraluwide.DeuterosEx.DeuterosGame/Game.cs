using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core;
using SdlDotNet.Graphics;
using System.Drawing;
using SdlDotNet.Input;

namespace Teraluwide.DeuterosEx.DeuterosGame
{
	/// <summary>
	/// Represents the base Deuteros game class.
	/// </summary>
	public class Game : BlackbirdGame
	{
		TextureManagerItem item;

		/// <summary>
		/// Initializes a new instance of the <see cref="Game"/> class.
		/// </summary>
		public Game()
		{
			this.BeforeQuit += new EventHandler<SdlDotNet.Core.QuitEventArgs>(Game_BeforeQuit);
		}

		/// <summary>
		/// Handles the AfterQuit event of the Game control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="SdlDotNet.Core.QuitEventArgs"/> instance containing the event data.</param>
		void Game_BeforeQuit(object sender, SdlDotNet.Core.QuitEventArgs e)
		{
			TextureManager.ReturnTexture(item.Id);
		}

		/// <summary>
		/// Performs the initialization steps required to setup the game.
		/// </summary>
		/// <param name="args"></param>
		public override void Init(string[] args)
		{
			base.Init(args);

			item = TextureManager.GetTexture("cursor");
			Mouse.ShowCursor = false;
		}

		/// <summary>
		/// Called every time the simulation is advanced.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="SdlDotNet.Core.TickEventArgs"/> instance containing the event data.</param>
		public override void Tick(object sender, SdlDotNet.Core.TickEventArgs e)
		{
			Video.Screen.Fill(Color.CornflowerBlue);
			Video.Screen.Blit(item.Texture, new Rectangle(Mouse.MousePosition.X - 14, Mouse.MousePosition.Y - 13, 28, 26), new Rectangle(0, 0, 28, 26));
			Video.Screen.Blit(FontManager.DrawText("fntMain", "Nazdar ptáku", Color.Black), new Point(100, 20));
			
			Video.Screen.Update();
		}

		
	}
}
