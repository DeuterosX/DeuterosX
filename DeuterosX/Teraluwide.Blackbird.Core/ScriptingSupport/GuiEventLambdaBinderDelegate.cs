using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core.Gui.Controls;

namespace Teraluwide.Blackbird.Core.ScriptingSupport
{
	/// <summary>
	/// A delegate used to return an instance of a delegate to a gui event.
	/// </summary>
	public delegate GuiControlEventDelegate<T> GuiEventLambdaBinderDelegate<T>(GuiControl sender);
}
