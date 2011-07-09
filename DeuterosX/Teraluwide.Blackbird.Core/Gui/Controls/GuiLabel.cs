using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Teraluwide.Blackbird.Core.ScriptingSupport;
using System.Drawing;
using SdlDotNet.Graphics;
using System.Runtime.InteropServices;
using System.Threading;

namespace Teraluwide.Blackbird.Core.Gui.Controls
{
	/// <summary>
	/// Represents a text label.
	/// </summary>
	public class GuiLabel : GuiControl
	{
		static int uniqueId = 0;

		/// <summary>
		/// Initializes a new instance of the <see cref="GuiLabel"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public GuiLabel(BlackbirdGame game)
			: base(game)
		{ }

		/// <summary>
		/// Gets or sets the text.
		/// </summary>
		/// <value>The text.</value>
		public GuiValue<string> Text { get; private set; }

		/// <summary>
		/// Gets or sets the color.
		/// </summary>
		/// <value>The color.</value>
		public GuiValue<Color> Color { get; private set; }

		/// <summary>
		/// Gets or sets the font.
		/// </summary>
		/// <value>The font.</value>
		public GuiValue<string> Font { get; private set; }

		TextureManagerItem cachedTexture;

		Color oldColor;
		string oldFont;
		string oldText;

		/// <summary>
		/// Renders this control.
		/// </summary>
		/// <param name="offsetX">The X offset.</param>
		/// <param name="offsetY">The Y offset.</param>
		public override void RenderControl(int offsetX, int offsetY)
		{
			// TODO: Maybe most of this should be in a helper class/manager instead? Also, this is quite a slow way to do the job for constantly changing text.
			// If it becomes necessary to display lots of changing text at the same time, this should be rewritten to render the text manually using
			// polygons mapping to a bitmap font texture (which has to be made in FontManager - either from a bitmap font definiton (texture + char map) or
			// from a system/vector font where we have to create both the texture and the char map at load time).
			if (cachedTexture == null || oldColor != Color.Value || oldFont != Font.Value || oldText != Text.Value)
			{
				if (cachedTexture != null)
				{
					cachedTexture.Dispose();
					cachedTexture = null;
				}

				Surface surface = Game.FontManager.DrawText(Font.Value, Text.Value, Color.Value);

				try
				{
					cachedTexture = new TextureManagerItem(Game.TextureManager, "labelText-" + Interlocked.Increment(ref uniqueId).ToString("X4"), string.Empty, false, false, false, Rectangle.Empty, true, true, 1);
					cachedTexture.LoadTexture(surface.Width, surface.Height, surface.Pixels);
				}
				finally
				{
					surface.Dispose();
				}

				oldColor = Color.Value;
				oldFont = Font.Value;
				oldText = Text.Value;
			}

			if (cachedTexture != null)
			{
				cachedTexture.Draw(X + offsetX, Y + offsetY);
			}
		}

		/// <summary>
		/// Loads the specified control.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="currentFileName"></param>
		public override void Load(XmlElement element, string currentFileName)
		{
			base.Load(element, currentFileName);

			this.Text = GuiValue<string>.Parse(Game, element.GetAttribute("text"), this);
			this.Color = GuiValue<Color>.Parse(Game, element.GetAttribute("color"), this);
			this.Font = GuiValue<string>.Parse(Game, element.GetAttribute("font"), this);
		}
	}
}
