using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core.Gui.Controls;
using Teraluwide.Blackbird.Core.Gui;

namespace Teraluwide.Blackbird.Core.ScriptingSupport
{
	public delegate void GuiControlEventDelegate<T>(GuiControl sender, T e);
	public delegate void GuiFaceEventDelegate<T>(GuiFace sender, T e);
}
