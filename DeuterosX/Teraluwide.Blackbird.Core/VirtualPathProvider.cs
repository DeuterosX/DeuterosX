using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using Teraluwide.Blackbird.Core.Properties;
using System.Security.AccessControl;

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
		/// Gets a read/write file stream for the specified virtual path.
		/// </summary>
		/// <param name="path">The virtual path to the file.</param>
		/// <returns></returns>
		public static Stream CreateFile(string path)
		{
			switch (GetPathKind(path))
			{
				case VirtualPathKind.ModFile:
					{
						string[] fragments = path.Split('/');

						string modName = fragments[1];

						string modPath = Path.Combine(Path.Combine(Environment.CurrentDirectory, BaseModPath), modName);
						string filePath = Path.Combine(modPath, string.Join(Path.DirectorySeparatorChar.ToString(), fragments, 2, fragments.Length - 2));

						// When creating a file, unpacked mod pathway is used.

						// Make sure the directory exists
						Directory.CreateDirectory(Path.GetDirectoryName(filePath));

						if (File.Exists(filePath))
							File.Delete(filePath);

						return File.Create(filePath);
					}

				default: throw new ArgumentException(string.Format(Resources.InvalidVirtualPathException, path));
			}
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
							throw new BlackbirdException(string.Format(Resources.ModFileNotFoundException, filePath, path));
						}
					}

				default: throw new ArgumentException(string.Format(Resources.InvalidVirtualPathException, path));
			}
		}

		/// <summary>
		/// Finds all the files in the specified directory based on the specified filter.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <param name="filter">The filter.</param>
		/// <returns></returns>
		public static string[] FindFiles(string path, string filter)
		{
			// TODO: Implement finding files in packed mods, implement everything in a bit more clean way
			switch (GetPathKind(path))
			{
				case VirtualPathKind.ModFile:
					{
						string[] fragments = path.Split('/');

						string modName = fragments[1];

						string modPath = Path.Combine(Path.Combine(Environment.CurrentDirectory, BaseModPath), modName);
						string directoryPath = Path.Combine(modPath, string.Join(Path.DirectorySeparatorChar.ToString(), fragments, 2, fragments.Length - 2));

						// Unpacked mod.
						if (Directory.Exists(directoryPath))
						{
							return Directory.GetFiles(directoryPath, filter, SearchOption.AllDirectories).Select(i => VirtualPathProvider.EnsureModVirtualPath(i, modName)).ToArray();
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
