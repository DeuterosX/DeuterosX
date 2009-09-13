using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using Teraluwide.Blackbird.Core.Properties;

namespace Teraluwide.Blackbird.Core
{
	public static class VirtualPathProvider
	{
		const string BaseModPath = "mods";
		const string ModArchiveExtension = ".fdr";
		const string ModFilePath = "~mod/";

		/// <summary>
		/// Gets the kind of the virtual path.
		/// </summary>
		/// <param name="path">The virtual path.</param>
		/// <returns></returns>
		private static VirtualPathKind GetPathKind(string path)
		{
			if (path.StartsWith(ModFilePath))
				return VirtualPathKind.ModFile;

			return VirtualPathKind.Unknown;
		}

		/// <summary>
		/// If the original path is already a virtual path, returns the original path. Otherwise a virtual path is created using the specified mod name.
		/// </summary>
		/// <param name="originalPath">The original path.</param>
		/// <param name="modName">Name of the mod.</param>
		/// <returns></returns>
		public static string EnsureModVirtualPath(string originalPath, string modName)
		{
			if (GetPathKind(originalPath) == VirtualPathKind.Unknown)
				return ModFilePath + modName + "/" + originalPath;
			else
				return originalPath;
		}

		/// <summary>
		/// Gets file stream using the specified virtual path.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <returns></returns>
		public static Stream GetFile(string path)
		{
			switch (GetPathKind(path))
			{
				case VirtualPathKind.ModFile:
					{
						string[] fragments = path.Split('/');

						string modName = fragments[1];

						string modPath = Path.Combine(Path.Combine(Environment.CurrentDirectory, BaseModPath), modName);
						string filePath = Path.Combine(modPath, string.Join(Path.DirectorySeparatorChar.ToString(), fragments, 2, fragments.Length - 2));

						// Unpacked mod.
						if (File.Exists(filePath))
						{
							return File.Open(filePath, FileMode.Open);
						}
						// Packed mod.
						else if (File.Exists(Path.ChangeExtension(modPath, ModArchiveExtension)))
						{
							throw new NotImplementedException("Packed mods not implemented yet.");
						}
						// Mod not found.
						else
						{
							throw new BlackbirdException(string.Format(Resources.ModNotFoundException, modName));
						}
					}

				default: throw new ArgumentException(string.Format(Resources.InvalidVirtualPathException, path));
			}
		}
	}

	/// <summary>
	/// Represents the kind of a virtual path.
	/// </summary>
	public enum VirtualPathKind
	{
		/// <summary>
		/// Unknown virtual path.
		/// </summary>
		Unknown = 0,
		/// <summary>
		/// Mod specific file. The file is loaded from a virtual or real mod archive.
		/// </summary>
		ModFile = 1,
	}
}
