using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Teraluwide.DeuterosEx.DeuterosGame
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Game game = new Game();

#if !DEBUG
			try
			{
#endif
				game.Init(args);
				game.Run();
#if !DEBUG
			}
			catch (Exception ex) // The general Exception shouldn't usually be catched - this is just for the purposes of global error handling.
			{
				// TODO: Implement global error handling (ie. message to user, error to log)
				throw;
			}
#endif
		}
	}
}
