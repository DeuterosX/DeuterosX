using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core;

namespace DeuterosMod.Components
{
	public class UniverseComponent : ICustomBlackbirdComponent, IBlackbirdSavegameComponent, IBlackbirdSimulationComponent
	{
		#region ICustomBlackbirdComponent Members

		public string Id
		{
			get { throw new NotImplementedException(); }
		}

		#endregion

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

		#region IBlackbirdSavegameComponent Members

		public void LoadGame(System.Xml.XmlNode node)
		{
			throw new NotImplementedException();
		}

		public void SaveGame(System.Xml.XmlNode node)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region IBlackbirdSimulationComponent Members

		public void Advance()
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
