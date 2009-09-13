using System;
using System.Collections.Generic;
using System.Text;

namespace Teraluwide.Blackbird.Core
{
	public class GuiMenuManager : IBlackbirdComponent
	{
		private Dictionary<string, GuiMenu> innerData = new Dictionary<string, GuiMenu>();

		/// <summary>
		/// Initializes a new instance of the <see cref="GuiMenuManager"/> class.
		/// </summary>
		/// <param name="game">The game instance.</param>
		public GuiMenuManager(BlackbirdGame game)
		{
			innerData = new Dictionary<string, GuiMenu>();
		}

		#region IBlackbirdComponent Members

		public BlackbirdGame Game
		{
			get { throw new NotImplementedException(); }
		}

		public void Load()
		{
			throw new NotImplementedException();
		}

		public void Load(System.IO.Stream stream)
		{
			throw new NotImplementedException();
		}

		public void Save()
		{
			throw new NotImplementedException();
		}

		public void Save(System.IO.Stream stream)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region IDisposable Members

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
