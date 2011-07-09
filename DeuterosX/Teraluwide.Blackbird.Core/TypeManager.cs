using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teraluwide.Blackbird.Core.Properties;
using System.Xml;
using System.IO;

namespace Teraluwide.Blackbird.Core
{
	/// <summary>
	/// Represents a manager simplifying class instancing.
	/// </summary>
	public class TypeManager : IBlackbirdComponent
	{
		const string FileName = "Types.xml";

				/// <summary>
		/// Gets the game instance associated with this component instance.
		/// </summary>
		/// <value>The game.</value>
		public BlackbirdGame Game { get; private set; }

		Dictionary<string, TypeManagerItem> innerData = new Dictionary<string, TypeManagerItem>();

		/// <summary>
		/// Initializes a new instance of the <see cref="TextureManager"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public TypeManager(BlackbirdGame game)
		{
			this.Game = game;
		}

		/// <summary>
		/// Gets the specified type.
		/// </summary>
		/// <param name="id">The type id.</param>
		/// <returns></returns>
		public Type GetType(string id)
		{
			if (innerData.ContainsKey(id))
				return innerData[id].Type;
			else
			{
				TypeManagerItem item = new TypeManagerItem(id, id);
				innerData.Add(id, item);
				return item.Type;
			}
		}

		/// <summary>
		/// Loads the texture definitions for the currently selected mod.
		/// </summary>
		public void Load()
		{
			Load(VirtualPathProvider.GetFile(VirtualPathProvider.EnsureModVirtualPath(FileName, Game.ModName)));
		}

		/// <summary>
		/// Loads the texture definitions from the specified stream.
		/// </summary>
		/// <param name="stream">The input stream.</param>
		public void Load(Stream stream)
		{
			XmlDocument doc = new XmlDocument();
			try
			{
				doc.Load(stream);
			}
			catch (XmlException ex)
			{
				throw new BlackbirdException(string.Format(Resources.ModFileIsInIncorrectFormatException, FileName), ex);
			}
			finally
			{
				stream.Close();
			}

			XmlElement root = doc.SelectSingleNode("/FDRFile") as XmlElement;

			if (root == null || root.Attributes["type"].Value != "types")
				throw new BlackbirdException(string.Format(Resources.ModFileIsInIncorrectFormatException, FileName));

			Log.WriteMessage(string.Format(Resources.TypeDefinitionVersion, root.Attributes["version"].Value));

			foreach (XmlElement el in root.SelectNodes("TypeList/*"))
			{
				string id = el.GetAttribute("id");
				string aqn = el.GetAttribute("aqn");

				if (id == null)
					throw new BlackbirdException(string.Format(Resources.ModFileIsInIncorrectFormatSpecificException, FileName, "null", "id"));

				if (aqn == null)
					throw new BlackbirdException(string.Format(Resources.ModFileIsInIncorrectFormatSpecificException, FileName, "null", "aqn"));

				if (innerData.ContainsKey(id))
					throw new BlackbirdException(string.Format(Resources.TypeAlreadyRegistered, id));

				innerData.Add(
						id,
						new TypeManagerItem(id, aqn)
					);
			}
		}

		/// <summary>
		/// Saves the texture definitions of the currently selected mod.
		/// </summary>
		public void Save()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Saves the texture definitions of the currently selected mod to the specified stream.
		/// </summary>
		/// <param name="stream">The target stream.</param>
		public void Save(Stream stream)
		{
			throw new NotImplementedException();
		}


		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			
		}

		#endregion
	}
}
