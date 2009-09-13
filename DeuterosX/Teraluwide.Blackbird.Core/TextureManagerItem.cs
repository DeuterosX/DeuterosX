using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlDotNet.Graphics;
using Teraluwide.Blackbird.Core.Properties;
using System.IO;

namespace Teraluwide.Blackbird.Core
{
	/// <summary>
	/// Represents a texture manager item.
	/// </summary>
	public sealed class TextureManagerItem : IDisposable
	{
		private int userCount = 0;
		private TextureManager manager;
		private Surface texture;

		/// <summary>
		/// Gets the unique identifier of this texture.
		/// </summary>
		/// <value>The unique identifier of this texture.</value>
		public string Id { get; private set; }

		/// <summary>
		/// Gets the name of the file.
		/// </summary>
		/// <value>The name of the file.</value>
		public string FileName { get; private set; }

		/// <summary>
		/// Gets or sets a value indicating whether this texture should be loaded on game load.
		/// </summary>
		/// <value><c>true</c> if the texture should be loaded when the game loads; otherwise, <c>false</c>.</value>
		public bool OnLoad { get; private set; }

		/// <summary>
		/// Gets or sets a value indicating whether this texture should be loaded on demand.
		/// </summary>
		/// <value><c>true</c> if [on demand]; otherwise, <c>false</c>.</value>
		public bool OnDemand { get; private set; }

		/// <summary>
		/// Gets or sets a value indicating whether to track users of this texture. If true and the texture loses all of its users, it is disposed. It may be reloaded
		/// again (on trigger or on demand if applicable).
		/// </summary>
		/// <value><c>true</c> if the texture should maintain its user count; otherwise, <c>false</c>.</value>
		public bool TrackUsers { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="TextureManagerItem"/> class.
		/// </summary>
		/// <param name="manager">The manager.</param>
		/// <param name="id">The id.</param>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="onLoad">if set to <c>true</c> the texture will be loaded immediately.</param>
		/// <param name="onDemand">if set to <c>true</c> the texture will be loaded on demand.</param>
		/// <param name="trackUsers">if set to <c>true</c> the texture will have its users tracked.</param>
		public TextureManagerItem(TextureManager manager, string id, string fileName, bool onLoad, bool onDemand, bool trackUsers)
		{
			this.manager = manager;
			this.Id = id;
			this.FileName = fileName;
			this.OnLoad = onLoad;
			this.OnDemand = onDemand;
			this.TrackUsers = trackUsers;
		}

		/// <summary>
		/// Gets the texture.
		/// </summary>
		/// <value>The texture.</value>
		public Surface Texture
		{
			get
			{
				if (texture != null)
					return texture;

				if (!OnDemand)
					throw new BlackbirdException(string.Format(Resources.TextureNotLoaded, Id));

				LoadTexture(true);

				if (texture == null)
					throw new BlackbirdException(string.Format(Resources.TextureCouldNotBeLoaded, Id));

				return texture;
			}
		}

		/// <summary>
		/// Adds a user to the user counter.
		/// </summary>
		public void AddUser()
		{
			userCount++;
		}

		/// <summary>
		/// Removes a user from the user counter.
		/// </summary>
		public void RemoveUser()
		{
			userCount--;

			if (userCount < 0)
				throw new BlackbirdException(string.Format(Resources.TextureUserOverflow, Id));

			if (userCount == 0 && TrackUsers)
				Dispose();
		}

		/// <summary>
		/// Loads the texture.
		/// </summary>
		/// <param name="forced">if set to <c>true</c> the texture is reloaded even if it is already loaded.</param>
		public void LoadTexture(bool forced)
		{
			if (!forced && this.texture != null)
				return;

			Dispose();

			using (Stream stream = VirtualPathProvider.GetFile(VirtualPathProvider.EnsureModVirtualPath(FileName, manager.Game.ModName)))
			{
				int length = (int)stream.Length;

				byte[] data = new byte[length];
				if (stream.Read(data, 0, length) != length)
					return;

				this.texture = new Surface(data);
			}
		}

		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			if (this.texture != null)
			{
				this.texture.Dispose();
				this.texture = null;
			}
		}

		#endregion
	}
}
