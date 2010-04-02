using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Tao.OpenGl;

namespace Teraluwide.Blackbird.Core
{
	public static class GlHelper
	{
		/// <summary>
		/// Sets the color.
		/// </summary>
		/// <param name="color">The color.</param>
		public static void SetColor(Color color)
		{
			Gl.glColor4f((float)color.R / 255f, (float)color.G / 255f, (float)color.B / 255f, (float)color.A / 255f);
		}
	}
}
