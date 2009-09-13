using System;
using System.Collections.Generic;
using System.Text;

namespace Teraluwide.Blackbird.Core
{
	public class GuiMenu : IDisposable
	{
		/// <summary>
		/// Gets the buttons in this menu.
		/// </summary>
		/// <value>The buttons.</value>
		public Dictionary<string, GuiButtonInfo> Buttons { get; private set; }

		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
