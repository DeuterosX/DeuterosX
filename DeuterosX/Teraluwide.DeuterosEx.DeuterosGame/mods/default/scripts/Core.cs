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
	}
}