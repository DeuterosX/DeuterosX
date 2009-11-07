using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlDotNet.Graphics;
using SdlDotNet.Core;
using System.Drawing;

namespace Teraluwide.Blackbird.Core
{
	/// <summary>
	/// Represents a Blackbird engine game.
	/// </summary>
	public abstract class BlackbirdGame
	{
		/// <summary>
		/// Occurs when the application is about to exit.
		/// </summary>
		public event EventHandler<QuitEventArgs> BeforeQuit;

		/// <summary>
		/// Occurs when the core application has quit.
		/// </summary>
		public event EventHandler<QuitEventArgs> AfterQuit;

		/// <summary>
		/// Gets the name of the currently selected mod.
		/// </summary>
		/// <value>The name of the currently selected mod.</value>
		public string ModName { get; protected set; }

		/// <summary>
		/// Gets the game info.
		/// </summary>
		/// <value>The game info.</value>
		public BlackbirdGameInfo GameInfo { get; private set; }

		/// <summary>
		/// Gets the texture manager.
		/// </summary>
		/// <value>The texture manager.</value>
		public TextureManager TextureManager { get; private set; }

		/// <summary>
		/// Gets or sets the font manager.
		/// </summary>
		/// <value>The font manager.</value>
		public FontManager FontManager { get; private set; }

		/// <summary>
		/// Gets the custom components.
		/// </summary>
		/// <value>The custom components.</value>
		public CustomComponentCollection CustomComponents { get; private set; }

		/// <summary>
		/// Gets or sets the Gui menu manager.
		/// </summary>
		/// <value>The Gui menu manager.</value>
		public GuiMenuManager GuiMenuManager { get; private set; }

		/// <summary>
		/// Gets the scale used on all graphics.
		/// </summary>
		/// <value>The scale.</value>
		public abstract int Scale { get; }

		/// <summary>
		/// Gets the width of the backbuffer.
		/// </summary>
		/// <value>The width of the backbuffer.</value>
		public abstract int BackbufferWidth { get; }
		/// <summary>
		/// Gets the height of the backbuffer.
		/// </summary>
		/// <value>The height of the backbuffer.</value>
		public abstract int BackbufferHeight { get; }

		/// <summary>
		/// Gets the mouse X-coordinate.
		/// </summary>
		/// <value>The mouse X.</value>
		public int MouseX { get { return SdlDotNet.Input.Mouse.MousePosition.X / Scale; } }
		/// <summary>
		/// Gets the mouse Y-coordinate.
		/// </summary>
		/// <value>The mouse Y.</value>
		public int MouseY { get { return SdlDotNet.Input.Mouse.MousePosition.Y / Scale; } }

		/// <summary>
		/// Initializes a new instance of the <see cref="BlackbirdGame"/> class.
		/// </summary>
		public BlackbirdGame()
		{
			ModName = "default";
			CustomComponents = new CustomComponentCollection();
			GameInfo = new BlackbirdGameInfo(this);
			TextureManager = new TextureManager(this);
			FontManager = new FontManager(this);
			GameScreenManager = new GameScreenManager(this);
			GuiMenuManager = new GuiMenuManager(this);
		}

		/// <summary>
		/// Performs the initialization steps required to setup the game.
		/// </summary>
		public virtual void Init(string[] args)
		{
			CommandLineArguments = ParseCommandLine(args);

			if (CommandLineArguments.ContainsKey("game"))
				ModName = CommandLineArguments["game"] ?? "default";

			LoadMod();
			
			Video.SetVideoMode(800, 600);
			Video.WindowCaption = GameInfo.Title;
		}

		/// <summary>
		/// Loads the currently selected mod.
		/// </summary>
		protected virtual void LoadMod()
		{
			GameInfo.Load();
			TextureManager.Load();
			FontManager.Load();
			GameScreenManager.Load();

			// Load all the custom components.
			foreach (var component in CustomComponents.Values)
				component.Load();
		}

		/// <summary>
		/// Gets the command line arguments.
		/// </summary>
		/// <value>The command line arguments.</value>
		public Dictionary<string, string> CommandLineArguments { get; protected set; }

		/// <summary>
		/// Parses the command line.
		/// </summary>
		/// <param name="args">The command line arguments.</param>
		/// <returns></returns>
		public Dictionary<string, string> ParseCommandLine(string[] args)
		{
			Dictionary<string, string> pars = new Dictionary<string, string>();

			for (int i = 1; i < args.Length; i++)
			{
				if (args[i].StartsWith("-"))
				{
					if (args.Length > i && !args[i + 1].StartsWith("-"))
						pars.Add(args[i].Substring(1), args[++i]);
					else
						pars.Add(args[i].Substring(1), null);
				}
			}

			return pars;
		}

		/// <summary>
		/// Starts the main game cycle.
		/// </summary>
		public virtual void Run()
		{
			Events.Quit += new EventHandler<QuitEventArgs>(Events_Quit);
			Events.Tick += new EventHandler<TickEventArgs>(Tick);
			Events.Run();
		}

		/// <summary>
		/// Handles the Quit event of the Events control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="SdlDotNet.Core.QuitEventArgs"/> instance containing the event data.</param>
		void Events_Quit(object sender, QuitEventArgs e)
		{
			OnBeforeQuit(sender, e);

			Events.QuitApplication();
			Events.Close();

			OnAfterQuit(sender, e);
		}

		/// <summary>
		/// Called when the application is about to exit.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="SdlDotNet.Core.QuitEventArgs"/> instance containing the event data.</param>
		public void OnBeforeQuit(object sender, QuitEventArgs e)
		{
			if (BeforeQuit != null)
				BeforeQuit(sender, e);
		}

		/// <summary>
		/// Called when after the core application has quit.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="SdlDotNet.Core.QuitEventArgs"/> instance containing the event data.</param>
		public void OnAfterQuit(object sender, QuitEventArgs e)
		{
			if (AfterQuit != null)
				AfterQuit(sender, e);
		}

		/// <summary>
		/// Called every time the simulation is advanced.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="SdlDotNet.Core.TickEventArgs"/> instance containing the event data.</param>
		public virtual void Tick(object sender, TickEventArgs e)
		{

		}

		/// <summary>
		/// Gets the game screen manager.
		/// </summary>
		/// <value>The game screen manager.</value>
		public GameScreenManager GameScreenManager { get; private set; }
	}
}
