﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Teraluwide.Blackbird.Core.Gui.Controls;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;
using System.Drawing;
using Tao.OpenGl;

namespace Teraluwide.Blackbird.Core.Gui
{
	/// <summary>
	/// Represents a gui interface part.
	/// </summary>
	public class GuiFace : IDisposable
	{
		/// <summary>
		/// Gets or sets the game.
		/// </summary>
		/// <value>The game.</value>
		protected BlackbirdGame Game { get; private set; }

		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		/// <value>The id.</value>
		public string Id { get; private set; }

		/// <summary>
		/// Gets or sets the background.
		/// </summary>
		/// <value>The background.</value>
		public GuiBackground Background { get; private set; }

		/// <summary>
		/// Gets or sets the size.
		/// </summary>
		/// <value>The size.</value>
		public GuiSize Size { get; private set; }

		/// <summary>
		/// Gets or sets the controls.
		/// </summary>
		/// <value>The controls.</value>
		public List<GuiControl> Controls { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="GuiFace"/> class.
		/// </summary>
		/// <param name="id">The id.</param>
		public GuiFace(BlackbirdGame game, string id)
		{
			this.Game = game;

			this.Id = id;
			this.Background = new GuiBackground(game);
			this.Size = new GuiSize(game);
			this.Controls = new List<GuiControl>();
		}

		/// <summary>
		/// Loads the face from the specified Xml element.
		/// </summary>
		/// <param name="el">The source Xml element.</param>
		/// <param name="currentFileName">Name of the current file.</param>
		public void Load(XmlElement el, string currentFileName)
		{
			foreach (XmlElement child in el.ChildNodes)
			{
				switch (child.Name)
				{
					case "background":
						this.Background.Load(child, currentFileName); break;
					case "size":
						this.Size.Load(child, currentFileName); break;
					case "control":
						this.Controls.Add(GuiControl.Load(Game, child, currentFileName)); break;
				}
			}
		}

		string lastImageId = string.Empty;
		TextureManagerItem lastTexture;

		/// <summary>
		/// Renders this face.
		/// </summary>
		public void Render(int offsetX, int offsetY)
		{
			if (this.Background.Color.HasValue && Size.Width.HasValue && Size.Height.HasValue)
			{
				Rectangle DrawArea = new Rectangle(offsetX, offsetY, Size.Width.Value, Size.Height.Value);

				Gl.glMatrixMode(Gl.GL_MODELVIEW);
				Gl.glPushMatrix();
				Gl.glLoadIdentity();

				Gl.glScalef(Game.Scale, Game.Scale, 1);

				Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);

				GlHelper.SetColor(this.Background.Color.Value);

				Gl.glBegin(Gl.GL_QUADS);
				Gl.glVertex3f(DrawArea.Left, DrawArea.Top, 0);
				Gl.glVertex3f(DrawArea.Right, DrawArea.Top, 0);
				Gl.glVertex3f(DrawArea.Right, DrawArea.Bottom, 0);
				Gl.glVertex3f(DrawArea.Left, DrawArea.Bottom, 0);
				Gl.glEnd();

				Gl.glColor3f(1, 1, 1);
				Gl.glPopMatrix();
			}

			if (this.Background.Image.HasValue)
			{
				string currentImageId = this.Background.Image.Value;

				if (!string.IsNullOrEmpty(lastImageId) && currentImageId == lastImageId)
					lastTexture.Draw(offsetX, offsetY);
				else
				{
					if (lastTexture != null)
						lastTexture.RemoveUser();

					lastImageId = currentImageId;
					lastTexture = Game.TextureManager.GetTexture(this.Background.Image.Value);

					lastTexture.Draw(offsetX, offsetY);
				}
			}

			if (this.Background.Repeat.GetValueOrDefault(GuiRepeatStyle.NoRepeat) != GuiRepeatStyle.NoRepeat)
				throw new NotSupportedException("Background repeat not supported yet.");

			foreach (var control in Controls)
				control.Render(offsetX, offsetY);
		}

		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			if (lastTexture != null)
			{
				lastTexture.RemoveUser();
				lastTexture = null;
			}

			GC.SuppressFinalize(this);
		}

		#endregion
	}
}
