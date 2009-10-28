using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core;
using SdlDotNet.Graphics;
using System.Drawing;
using SdlDotNet.Input;
using Tao.OpenGl;

namespace Teraluwide.DeuterosEx.DeuterosGame
{
	/// <summary>
	/// Represents the base Deuteros game class.
	/// </summary>
	public class Game : BlackbirdGame
	{
		TextureManagerItem cursor;

		public int BackbufferWidth { get { return 1088; } }
		public int BackbufferHeight { get { return 672; } }

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
			
			cursor = TextureManager.GetTexture("cursor");
			Mouse.ShowCursor = false;
		}

		/// <summary>
		/// Called every time the simulation is advanced.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="SdlDotNet.Core.TickEventArgs"/> instance containing the event data.</param>
		public override void Tick(object sender, SdlDotNet.Core.TickEventArgs e)
		{
			Gl.glViewport(0, 0, BackbufferWidth, BackbufferHeight);
			Gl.glMatrixMode(Gl.GL_PROJECTION);
			Gl.glLoadIdentity();
			Glu.gluPerspective(45d, (double)BackbufferWidth / (double)BackbufferHeight, 0.1d, 100d);
			Gl.glMatrixMode(Gl.GL_MODELVIEW);
			Gl.glLoadIdentity();

			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);        // Clear Screen And Depth Buffer

			Gl.glLoadIdentity();                                                // Reset The Current Modelview Matrix
			Gl.glTranslatef(-1.5f, 0, -6);                                      // Move Left 1.5 Units And Into The Screen 6.0
			Gl.glBegin(Gl.GL_TRIANGLES);                                        // Drawing Using Triangles
			Gl.glColor3f(1, 0, 0);                                          // Set The Color To Red
			Gl.glVertex3f(0, 1, 0);                                         // Top
			Gl.glColor3f(0, 1, 0);                                          // Set The Color To Green
			Gl.glVertex3f(-1, -1, 0);                                       // Bottom Left
			Gl.glColor3f(0, 0, 1);                                          // Set The Color To Blue
			Gl.glVertex3f(1, -1, 0);                                        // Bottom Right
			Gl.glEnd();                                                         // Finished Drawing The Triangle
			Gl.glTranslatef(3, 0, 0);                                           // Move Right 3 Units
			Gl.glColor3f(0.5f, 0.5f, 1);                                        // Set The Color To Blue One Time Only
			
			//Gl.glBindTexture(Gl.GL_TEXTURE_2D, cursor.Texture);
			
			Gl.glBegin(Gl.GL_QUADS);                                            // Draw A Quad
			Gl.glTexCoord2f(0, 0); Gl.glVertex3f(-1, -1, 0);
			Gl.glTexCoord2f(1, 0); Gl.glVertex3f(1, -1, 0);
			Gl.glTexCoord2f(1, 1); Gl.glVertex3f(1, 1, 0);
			Gl.glTexCoord2f(0, 1); Gl.glVertex3f(-1, 1, 0); 
			Gl.glEnd();    
			
			// render the current game screen
			GameScreenManager.CurrentGameScreen.Render(Video.Screen);

			// render the FPS
			Video.Screen.Blit(FontManager.DrawText("fntMain", e.Fps.ToString(), Color.Yellow), new Point(100, 20));
			
			// render the mouse cursor
			Video.Screen.Blit(cursor.Texture, new Rectangle(Mouse.MousePosition.X - 14, Mouse.MousePosition.Y - 13, 28, 26), new Rectangle(0, 0, 28, 26));
			
			Video.GLSwapBuffers();
		}

		
	}
}
