using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core;
using SdlDotNet.Graphics;
using System.IO;
using System.Drawing;
using Tao.OpenGl;

namespace Teraluwide.DeuterosEx.DeuterosGame.Screens
{
	/// <summary>
	/// Represents a game screen for the intro.
	/// </summary>
	public class IntroGameScreen : GameScreen
	{
		const string FileName = "Intro.xml";

		TextureManagerItem logo;

		/// <summary>
		/// Initializes a new instance of the <see cref="IntroGameScreen"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public IntroGameScreen(BlackbirdGame game) : base(game)
		{

		}

		/// <summary>
		/// Loads the component data for the currently selected mod.
		/// </summary>
		public override void Load()
		{
			Load(VirtualPathProvider.GetFile(VirtualPathProvider.EnsureModVirtualPath(FileName, Game.ModName)));
		}

		/// <summary>
		/// Loads the component data from the specified stream.
		/// </summary>
		/// <param name="stream">The input stream.</param>
		public override void Load(Stream stream)
		{
			logo = Game.TextureManager.GetTexture("deuterosLogo");
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
			throw new NotImplementedException();
		}

		/// <summary>
		/// Renders the IRenderable to the specified surface.
		/// </summary>
		/// <param name="surface">The target surface.</param>
		public override void Render()
		{
			Gl.glMatrixMode(Gl.GL_MODELVIEW);
			Gl.glLoadIdentity();
			Gl.glBindTexture(Gl.GL_TEXTURE_2D, logo.TextureId);

			Gl.glBegin(Gl.GL_QUADS);
			Gl.glTexCoord2f(0, 0); Gl.glVertex3f(0, 0, 0);
			Gl.glTexCoord2f(1, 0); Gl.glVertex3f(1088, 0, 0);
			Gl.glTexCoord2f(1, 1); Gl.glVertex3f(1088, 672, 0);
			Gl.glTexCoord2f(0, 1); Gl.glVertex3f(0, 672, 0);
			Gl.glEnd();
			//surface.Blit(logo.Texture, new Point(-100, -200));
		}
	}
}
