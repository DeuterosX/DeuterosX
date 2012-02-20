using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core;
using SdlDotNet.Graphics;
using System.Drawing;
using SdlDotNet.Input;
using Tao.OpenGl;
using System.Threading;
using Teraluwide.DeuterosEx.DeuterosGame.Universe;
using Teraluwide.DeuterosEx.DeuterosGame.Stations;
using Teraluwide.DeuterosEx.DeuterosGame.Items;

namespace Teraluwide.DeuterosEx.DeuterosGame
{
	/// <summary>
	/// Represents the base Deuteros game class.
	/// </summary>
	public class Game : BlackbirdGame
	{
		TextureManagerItem cursor;

		/// <summary>
		/// Gets the width of the backbuffer.
		/// </summary>
		/// <value>The width of the backbuffer.</value>
		public override int BackbufferWidth { get { return 1280; } }
		/// <summary>
		/// Gets the height of the backbuffer.
		/// </summary>
		/// <value>The height of the backbuffer.</value>
		public override int BackbufferHeight { get { return 800; } }

		/// <summary>
		/// Gets the scale used on all graphics.
		/// </summary>
		/// <value>The scale.</value>
		public override int Scale { get { return 4; } }

		/// <summary>
		/// Gets the universe manager.
		/// </summary>
		public UniverseManager UniverseManager { get { return CustomComponents["UniverseManager"] as UniverseManager; } }

		/// <summary>
		/// Gets the station manager.
		/// </summary>
		public StationManager StationManager { get { return CustomComponents["StationManager"] as StationManager; } }

		/// <summary>
		/// Gets the store item manager.
		/// </summary>
		public StoreItemManager StoreItemManager { get { return CustomComponents["StoreItemManager"] as StoreItemManager; } }

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
			TextureManager.ReturnTexture(cursor.Id);

			SaveGame("_lastGame");
		}

		/// <summary>
		/// Performs the initialization steps required to setup the game.
		/// </summary>
		/// <param name="args"></param>
		public override void Init(string[] args)
		{
			base.Init(args);

			Video.SetVideoMode(BackbufferWidth, BackbufferHeight, false, true, false, true);
			Video.GLDoubleBufferEnabled = true;

			Gl.glEnable(Gl.GL_TEXTURE_2D);                                      // Enable Texture Mapping
			Gl.glEnable(Gl.GL_ALPHA);
			Gl.glEnable(Gl.GL_BLEND);
			Gl.glShadeModel(Gl.GL_SMOOTH);                                      // Enable Smooth Shading
			Gl.glClearColor(0, 0, 0, 0.5f);                                     // Black Background
			Gl.glClearDepth(1);                                                 // Depth Buffer Setup
			Gl.glEnable(Gl.GL_DEPTH_TEST);                                      // Enables Depth Testing
			Gl.glDepthFunc(Gl.GL_LEQUAL);                                       // The Type Of Depth Testing To Do
			Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);         // Really Nice Perspective Calculations

			cursor = TextureManager.GetTexture("cursor");
			Mouse.ShowCursor = false;
		}

		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="SdlDotNet.Core.TickEventArgs"/> instance containing the event data.</param>
		public override void Tick(object sender, SdlDotNet.Core.TickEventArgs e)
		{
			base.Tick(sender, e);

			Gl.glViewport(0, 0, BackbufferWidth, BackbufferHeight);
			Gl.glMatrixMode(Gl.GL_PROJECTION);
			Gl.glLoadIdentity();
			Glu.gluOrtho2D(0, BackbufferWidth, BackbufferHeight, 0);

			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

			// render the current game screen
			GameScreenManager.CurrentGameScreen.Render();

			// render the FPS
			VariableManager.SetVariable("FPS", e.Fps);
			// Video.Screen.Blit(FontManager.DrawText("fntMain", e.Fps.ToString(), Color.Yellow), new Point(100, 20));


			// render the mouse cursor
			cursor.Draw(MouseX - cursor.RealSize.Width / 2, MouseY - cursor.RealSize.Height / 2);

			Gl.glFlush();

			Video.GLSwapBuffers();
		}


	}
}
