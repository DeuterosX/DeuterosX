using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teraluwide.Blackbird.Core.Gui
{
	/// <summary>
	/// Represents the image repeat style.
	/// </summary>
	public enum GuiRepeatStyle
	{
		/// <summary>
		/// Repeats the image horizontally.
		/// </summary>
		RepeatX,
		/// <summary>
		/// Repeats the image vertically.
		/// </summary>
		RepeatY,
		/// <summary>
		/// Repeats the image both horizontally and vertically.
		/// </summary>
		RepeatXY,
		/// <summary>
		/// Doesn't repeat the image at all.
		/// </summary>
		NoRepeat
	}
}
