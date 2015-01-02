using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlDotNet.Graphics;
using SdlDotNet.Core;
using System.Drawing;
using Teraluwide.Blackbird.Core.Gui;
using Teraluwide.Blackbird.Core.ScriptingSupport;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using System.Xml;
using Teraluwide.Blackbird.Core.Properties;
using System.Threading;

namespace Teraluwide.Blackbird.Core
{
	/// <summary>
	/// Represents a Blackbird engine game.
	/// </summary>
	public abstract class BlackbirdGame
	{
		/// <summary>
		/// Gets a value indicating whether this <see cref="BlackbirdGame"/> is run in debugm ode.
		/// </summary>
		/// <value><c>true</c> if in debug mode; otherwise, <c>false</c>.</value>
		public bool Debug
		{
			get { return true; }
		}

		/// <summary>
		/// Gets or sets whether the simulation is currently running.
		/// </summary>
		public bool SimulationRunning
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the length of the simulation cycle in seconds.
		/// </summary>
		public float SimulationCycleSeconds
		{
			get { return 1f; }
		}

		/// <summary>
		/// Occurs when the application is about to exit.
		/// </summary>
		public event EventHandler<QuitEventArgs> BeforeQuit;

		/// <summary>
		/// Occurs when the core application has quit.
		/// </summary>
		public event EventHandler<QuitEventArgs> AfterQuit;

		/// <summary>
		/// Occurs when a save game is loaded.
		/// </summary>
		public event EventHandler GameLoaded;

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
		public GuiManager GuiManager { get; private set; }

		/// <summary>
		/// Gets or sets the type manager.
		/// </summary>
		/// <value>The type manager.</value>
		public TypeManager TypeManager { get; private set; }

		/// <summary>
		/// Gets or sets the variable manager.
		/// </summary>
		/// <value>The variable manager.</value>
		public GameVariableManager VariableManager { get; private set; }

		/// <summary>
		/// Gets or sets the script manager.
		/// </summary>
		/// <value>The script manager.</value>
		public ScriptManager ScriptManager { get; private set; }

		/// <summary>
		/// Gets or sets the mouse manager.
		/// </summary>
		/// <value>The mouse manager.</value>
		public MouseManager MouseManager { get; private set; }

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
        /// Gets current time.
        /// </summary>
        /// <value>Integer value of time</value>
        public int Time { get; set; }

        /// <summary>
        /// Gets the string formatted game time.
        /// </summary>
        /// <value>The formatted time</value>
        public String FormattedTime { get { return Time.ToString().Length > 4 ? Time.ToString().Insert(4, " ") : ""; } }

		int randomSeed = new Random().Next();
		/// <summary>
		/// Gets the random seed.
		/// </summary>
		/// <returns></returns>
		public int GetRandomSeed()
		{
			return Interlocked.Increment(ref randomSeed);
		}

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
			GuiManager = new GuiManager(this);
			TypeManager = new TypeManager(this);
			VariableManager = new GameVariableManager(this);
			ScriptManager = new ScriptManager(this);
			MouseManager = new MouseManager(this);
            
            VariableManager.SetVariable("time", "");
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

			LoadGame("_newGame");
		}

		/// <summary>
		/// Loads the currently selected mod.
		/// </summary>
		protected virtual void LoadMod()
		{
			TypeManager.Load();
			GameInfo.Load();
			TextureManager.Load();
			FontManager.Load();
			GameScreenManager.Load();
			GuiManager.Load();
			ScriptManager.Load();

			CustomComponents.Add(VariableManager.Id, VariableManager);

			// Load all the custom components - note that the instancing of the components occurs earlier, in GameInfo.Load
			CustomComponents.Load();
		}

		/// <summary>
		/// Loads the specified save game.
		/// </summary>
		/// <param name="fileName">The game file name.</param>
		public void LoadGame(string fileName)
		{
			XmlDocument doc = new XmlDocument();

			using (var stream = VirtualPathProvider.GetFile(VirtualPathProvider.EnsureModVirtualPath("save/" + fileName + ".xml", ModName)))
			{
				try
				{
					doc.Load(stream);
				}
				catch (XmlException ex)
				{
					throw new BlackbirdException(string.Format(Resources.ModFileIsInIncorrectFormatException, fileName), ex);
				}
			}

			LoadGame(doc);

			if (GameLoaded != null)
				GameLoaded(this, EventArgs.Empty);
		}

		/// <summary>
		/// Loads the specified save game.
		/// </summary>
		/// <param name="fileName">The Xml document of the save game.</param>
		protected virtual void LoadGame(XmlDocument doc)
		{
			foreach (XmlNode node in doc.SelectSingleNode("FDRFile/CustomComponents").ChildNodes)
			{
				if (node is XmlElement)
				{
					var el = node as XmlElement;

					if (CustomComponents.ContainsKey(el.Name))
					{
						var bsc = CustomComponents[el.Name] as IBlackbirdSavegameComponent;

						if (bsc != null)
							bsc.LoadGame(el);
					}
				}
			}
		}

		/// <summary>
		/// Saves the game to the specified game name.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		public void SaveGame(string fileName)
		{
			XmlDocument doc = new XmlDocument();
			SaveGame(doc);

			using (var stream = VirtualPathProvider.CreateFile(VirtualPathProvider.EnsureModVirtualPath("save/" + fileName + ".xml", ModName)))
				doc.Save(stream);
		}

		/// <summary>
		/// Loads the specified save game.
		/// </summary>
		/// <param name="fileName">The Xml document of the save game.</param>
		protected virtual void SaveGame(XmlDocument doc)
		{
			doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

			XmlElement root;

			doc.AppendChild(root = doc.CreateElement("FDRFile"));

			root.Attributes.Append(doc.CreateAttributeWithValue("version", "0.1"));
			root.Attributes.Append(doc.CreateAttributeWithValue("type", "save"));

			XmlElement components = doc.CreateElement("CustomComponents");
			root.AppendChild(components);

			foreach (var component in CustomComponents.Select(i => i.Value).OfType<IBlackbirdSavegameComponent>())
			{
				var el = doc.CreateElement(component.Id);
				components.AppendChild(el);

				component.SaveGame(el);
			}
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
			MouseManager.Init();

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

			MouseManager.Exit();
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


		float timeCounter = 0;
		/// <summary>
		/// Called every tick of the update-render cycle.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="SdlDotNet.Core.TickEventArgs"/> instance containing the event data.</param>
		public virtual void Tick(object sender, TickEventArgs e)
		{
			if (SimulationRunning)
			{
				timeCounter += e.SecondsElapsed;

				if (timeCounter > SimulationCycleSeconds)
				{
					// The max is here for unreasonably short simulation cycle times
					timeCounter = Math.Max(0f, timeCounter - SimulationCycleSeconds);

					Advance();
				}
			}
			else
			{
				if (timeCounter > 0)
					timeCounter = 0;
			}
		}

		/// <summary>
		/// Called every time the simulation is advanced.
		/// </summary>
		public virtual void Advance()
		{
			Console.WriteLine("Advance!");
            Time += 1;
            VariableManager.SetVariable("time", FormattedTime);
			CustomComponents.Advance();
		}

		/// <summary>
		/// Gets the game screen manager.
		/// </summary>
		/// <value>The game screen manager.</value>
		public GameScreenManager GameScreenManager { get; private set; }
	}
}
