using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core.ScriptingSupport;

/// <summary>
/// 
/// </summary>
public partial class Core
{
	/// <summary>
	/// This is a part of a basic example in ExamplesAndTests.xml.
	/// </summary>
	/// <value>The value of the variable "hideTest".</value>
	public bool HideTest
	{
		get { return Game.VariableManager.GetVariable("hideTest", false); }
		set { Game.VariableManager.SetVariable("hideTest", value); }
	}

	/// <summary>
	/// This is part of a basic example in ExamplesAndTests.xml.
	/// </summary>
	/// <value>The value of the variable "testX".</value>
	public int TestX
	{
		get { return Game.VariableManager.GetVariable("testX", 0); }
		set { Game.VariableManager.SetVariable("testX", value); }
	}

	public int FPS
	{
		get { return Game.VariableManager.GetVariable("FPS", 1); }
	}
}