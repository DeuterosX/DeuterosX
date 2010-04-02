using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlDotNet.Graphics;

namespace Teraluwide.Blackbird.Core
{
	/// <summary>
	/// Represents a class that supports rendering on a surface.
	/// </summary>
	public interface IRenderable
	{
		/// <summary>
		/// Renders the IRenderable to the specified surface.
		/// </summary>
		/// <param name="surface">The target surface.</param>
		void Render();
	}
}
