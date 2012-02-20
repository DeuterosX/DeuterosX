using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Security.Policy;
using System.Security.Permissions;
using System.Security;
using System.Diagnostics;

namespace Teraluwide.Blackbird.Core.ScriptingSupport
{
	public class ScriptManager : IBlackbirdComponent
	{
		private BlackbirdGame game;
		StringBuilder inlineMethods;
		List<ILateMethodBinder> methodBinders;

		/// <summary>
		/// Initializes a new instance of the <see cref="GameVariableManager"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public ScriptManager(BlackbirdGame game)
		{
			this.game = game;
			this.inlineMethods = new StringBuilder();
			this.methodBinders = new List<ILateMethodBinder>();
		}

		#region IBlackbirdComponent Members

		/// <summary>
		/// Gets the game instance associated with this component instance.
		/// </summary>
		/// <value>The game.</value>
		public BlackbirdGame Game
		{
			get { return this.game; }
		}

		/// <summary>
		/// Registers an inline method.
		/// </summary>
		/// <param name="methodDefinition">The method definition.</param>
		/// <param name="binder">The binder.</param>
		public void RegisterInlineMethod(string methodDefinition, ILateMethodBinder binder)
		{
			// Maybe something a bit more informative than plain text should be used?
			// inlineMethods.Add(methodDefinition);

			inlineMethods.AppendLine(methodDefinition);
			if (binder != null)
				methodBinders.Add(binder);
		}

		/// <summary>
		/// Registers a late method binder.
		/// </summary>
		/// <param name="binder">The binder.</param>
		public void RegisterLateBinder(ILateMethodBinder binder)
		{
			if (binder != null)
				methodBinders.Add(binder);
		}

		object core;
		/// <summary>
		/// Loads the component data for the currently selected mod.
		/// </summary>
		public void Load()
		{
			// TODO: Replace with a more robust building mechanism (and maybe more partial modding support?)
			CSharpCodeProvider codeProvider = new CSharpCodeProvider(new Dictionary<string, string> { { "CompilerVersion", "v3.5" } });
			CompilerParameters pars = new CompilerParameters();
			
			// Uncomment the following line to enforce code security
			// pars.Evidence = new Evidence(new object[] { new Zone(SecurityZone.Internet) }, null);
			pars.GenerateExecutable = false;
			pars.GenerateInMemory = true;
			pars.IncludeDebugInformation = true;

			// NOTE: Maybe the referenced assemblies and usings for inline methods should be defined in a xml?
			pars.ReferencedAssemblies.Add("System.dll");
			pars.ReferencedAssemblies.Add("System.Core.dll");
			pars.ReferencedAssemblies.Add("System.Drawing.dll");
			pars.ReferencedAssemblies.Add("System.Xml.dll");
			pars.ReferencedAssemblies.Add("SdlDotNet.dll");
			pars.ReferencedAssemblies.Add("Teraluwide.Blackbird.Core.dll");
			pars.ReferencedAssemblies.Add(Assembly.GetEntryAssembly().Location);

			if (Game.Debug)
				System.IO.File.WriteAllText("inlineSources.cs", inlineMethods.ToString());

			// NOTE: If we expect to have huge scripts, it may be necessary to use an alternate way to compile them; At present time, this implementation is sufficient.
			CompilerResults res = codeProvider.CompileAssemblyFromSource(pars, VirtualPathProvider.FindFiles(VirtualPathProvider.EnsureModVirtualPath("scripts", Game.ModName), "*.cs").Select(i => VirtualPathProvider.GetFile(i).ReadToEnd()).Concat(new string[] { "using System; using System.Drawing; using System.Text; using Teraluwide.Blackbird.Core.Gui; using Teraluwide.Blackbird.Core.Gui.Controls; public partial class Core { " + inlineMethods.ToString() + " }" }).ToArray());

			// NOTE: Maybe there should be a better way to filter out warnings.
			if (res.Errors.Count > 0 && !res.Errors.OfType<CompilerError>().All(i => i.IsWarning))
			{
				System.IO.File.WriteAllLines("error.log", res.Errors.OfType<CompilerError>().Select(i => i.ToString()).ToArray());

				// TODO: Handle compiler errors.
				if (!Debugger.IsAttached)
					Debugger.Launch();
				
				Debugger.Break();
			}
			else
			{
				Assembly assembly = res.CompiledAssembly;

				Type coreType = assembly.GetType("Core");
				core = Activator.CreateInstance(coreType, Game);

				// Notify the late method binders.
				foreach (var binder in methodBinders)
				{
					// TODO: Add some error handling - missing methods, wrong definitions etc.
					MethodInfo mi = coreType.GetMethod(binder.MethodName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

					binder.BindMethod(Delegate.CreateDelegate(binder.DelegateType, core, mi, true));
				}
			}
		}

		/// <summary>
		/// Loads the component data from the specified stream.
		/// </summary>
		/// <param name="stream">The input stream.</param>
		public void Load(System.IO.Stream stream)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Saves the component data of the currently selected mod.
		/// </summary>
		public void Save()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Saves the component data of the currently selected mod to the specified stream.
		/// </summary>
		/// <param name="stream">The target stream.</param>
		public void Save(System.IO.Stream stream)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
		}

		#endregion

		#region ICustomBlackbirdComponent Members

		/// <summary>
		/// Gets the unique identifier of this custom component.
		/// </summary>
		/// <value>The unique identifier of this custom component.</value>
		public string Id
		{
			get { return "ScriptManager"; }
		}

		#endregion
	}
}
