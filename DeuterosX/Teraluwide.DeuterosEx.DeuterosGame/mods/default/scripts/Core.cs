using System;
using System.Text;
using Teraluwide.Blackbird.Core;
using SdlDotNet.Core;
using Teraluwide.Blackbird.Core.ScriptingSupport.EventArguments;
using Teraluwide.Blackbird.Core.ScriptingSupport;
using Teraluwide.Blackbird.Core.Gui.Controls;

public partial class Core : BasicSimulationComponent
{
	public Core(BlackbirdGame game)
		: base(game, "Core")
	{
		Events.KeyboardUp += Events_KeyboardUp;
		Events.MouseMotion += Events_MouseMotion;
	}

	void Events_MouseMotion(object sender, SdlDotNet.Input.MouseMotionEventArgs e)
	{
		SetToolTip(string.Empty);
	}

	void Events_KeyboardUp(object sender, SdlDotNet.Input.KeyboardEventArgs e)
	{
		//if (e.Key == SdlDotNet.Input.Key.One)
		//  Game.GuiManager.GetFace("mainScreen").Controls[0].MouseClick.Invoke(new MouseClickEventArgument { X = 23, MouseButton = SdlDotNet.Input.MouseButton.PrimaryButton });

		if (e.Key == SdlDotNet.Input.Key.Space)
		{
			if (Game.GameScreenManager.CurrentGameScreen == Game.GameScreenManager["earthCity"])
				ChangeGamescreen("intro");
			else
				ChangeGamescreen("earthCity");
		}
		// Go to the test screen on Home
		else if (e.Key == SdlDotNet.Input.Key.Home)
		{
			ChangeGamescreen("testScreen");
		}
	}

	/// <summary>
	/// Sets the tool tip.
	/// </summary>
	/// <param name="text">The text.</param>
	public void SetToolTip(string text)
	{
		Game.VariableManager.SetVariable("toolTip", text);
	}

	/// <summary>
	/// A method called in a basic gui/scripting tutorial.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The e.</param>
	public void HideTest_OnClick(GuiControl sender, MouseClickEventArgument e)
	{
		HideTest = true;
	}
}