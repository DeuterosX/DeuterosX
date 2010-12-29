﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlDotNet.Core;
using Teraluwide.Blackbird.Core.Gui;
using Teraluwide.Blackbird.Core.Gui.Controls;
using Teraluwide.Blackbird.Core.ScriptingSupport.EventArguments;

namespace Teraluwide.Blackbird.Core
{
	/// <summary>
	/// A manager for all mouse related actions and events.
	/// </summary>
	public class MouseManager
	{
		private BlackbirdGame game;

		/// <summary>
		/// Initializes a new instance of the <see cref="MouseManager"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public MouseManager(BlackbirdGame game)
		{
			this.game = game;
		}

		/// <summary>
		/// Gets the game.
		/// </summary>
		/// <value>The game.</value>
		public BlackbirdGame Game
		{
			get { return this.game; }
		}

		/// <summary>
		/// Exits this instance.
		/// </summary>
		public void Exit()
		{
			Events.MouseButtonUp -= Events_MouseButtonUp;
		}

		/// <summary>
		/// Inits this instance.
		/// </summary>
		public void Init()
		{
			Events.MouseButtonUp += Events_MouseButtonUp;
		}

		/// <summary>
		/// Handles the MouseButtonUp event of the Events control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="SdlDotNet.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
		public void Events_MouseButtonUp(object sender, SdlDotNet.Input.MouseButtonEventArgs e)
		{
			int realX = e.X / Game.Scale - 2;
			int realY = e.Y / Game.Scale - 2;

			MouseClickEventArgument eventArgument = new MouseClickEventArgument();
			eventArgument.X = realX;
			eventArgument.Y = realY;
			eventArgument.Bubble = true;
			eventArgument.MouseButton = e.Button;

			// Find a suitable control to accept the event
			Stack<GuiControl> stack = new Stack<GuiControl>();

			Game.GuiManager.GetFace(Game.GameScreenManager.CurrentGameScreen.FaceId).Bubble(BubbleFace, eventArgument);
		}

		void BubbleFace(GuiFace face, MouseClickEventArgument e)
		{
			foreach (var control in face.Controls)
			{
				control.Bubble(BubbleControl, e);
			}
		}

		void BubbleControl(GuiControl control, MouseClickEventArgument e)
		{
			int x = control.X;
			int y = control.Y;

			if (e.X >= x && e.X <= x + control.Width
				 && e.Y >= y && e.Y <= y + control.Height)
			{
				control.MouseClick.Invoke(e);

				if (!e.Bubble)
					return;

				if (control is GuiFaceControl)
				{
					e.X -= x;
					e.Y -= y;

					Game.GuiManager.GetFace((control as GuiFaceControl).FaceId).Bubble(BubbleFace, e);

					e.X += x;
					e.Y += y;
				}
			}
		}
	}
}
