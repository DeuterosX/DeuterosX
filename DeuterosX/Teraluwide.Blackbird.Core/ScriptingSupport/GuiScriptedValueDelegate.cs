using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core.Gui.Controls;

namespace Teraluwide.Blackbird.Core.ScriptingSupport
{
	public delegate T GuiScriptedValueDelegate<T>(GuiControl sender);
	public delegate T GuiScriptedDataBoundValueDelegate<T>(GuiControl sender, IDataContainer container);
}
