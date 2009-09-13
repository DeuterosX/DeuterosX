using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teraluwide.Blackbird.Core.ScriptingSupport
{
	/// <summary>
	/// Indicates that this member is accessible from outside scripting.
	/// </summary>
	public class GuiAccessibleAttribute : Attribute
	{
		private bool isAccessible = true;
		/// <summary>
		/// Gets whether this member is accessible from outside scripting.
		/// </summary>
		public bool IsAccessible
		{
			get { return this.isAccessible; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GuiAccessibleAttribute"/> class.
		/// </summary>
		/// <param name="isAccessible">if set to <c>true</c> the marked member is accessible from outside scripting.</param>
		public GuiAccessibleAttribute(bool isAccessible)
		{
			this.isAccessible = isAccessible;
		}
	}

}
