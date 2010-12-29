using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Teraluwide.Blackbird.Core.ScriptingSupport
{
	/// <summary>
	/// Represents a repository for all engine variables.
	/// </summary>
	public class GameVariableManager : IBlackbirdComponent, IBlackbirdSavegameComponent
	{
		private BlackbirdGame game;

		/// <summary>
		/// Initializes a new instance of the <see cref="GameVariableManager"/> class.
		/// </summary>
		/// <param name="game">The game.</param>
		public GameVariableManager(BlackbirdGame game)
		{
			this.game = game;
			this.variables = new Dictionary<string, IGameVariable>();
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
		/// Loads the component data for the currently selected mod.
		/// </summary>
		public void Load()
		{
			
		}

		/// <summary>
		/// Loads the component data from the specified stream.
		/// </summary>
		/// <param name="stream">The input stream.</param>
		public void Load(System.IO.Stream stream)
		{
			
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

		#region IBlackbirdSavegameComponent Members

		/// <summary>
		/// Loads the component specific data from the specified save game node.
		/// </summary>
		/// <param name="node">The node.</param>
		public void LoadGame(XmlNode node)
		{
			variables.Clear();

			foreach (XmlElement nVariable in node["variables"].OfType<XmlElement>())
			{
				IGameVariable variable = CreateVariable(nVariable.Attributes["type"].Value);
				variable.LoadXml(nVariable);

				variables.Add(nVariable.Attributes["name"].Value, variable);
			}
		}

		/// <summary>
		/// Creates a variable container for the specified variable type.
		/// </summary>
		/// <param name="typeName">Name of the type.</param>
		/// <returns></returns>
		IGameVariable CreateVariable(string typeName)
		{
			// Get the type of the inner value of the variable.
			Type valueType = game.TypeManager.GetType(typeName);

			// And create the actual generic variable type.
			Type variableType = typeof(GameVariable<>).MakeGenericType(valueType);

			IGameVariable variable = Activator.CreateInstance(variableType) as IGameVariable;

			return variable;
		}

		/// <summary>
		/// Saves the component specific data to the specified save game node.
		/// </summary>
		/// <param name="node">The node.</param>
		public void SaveGame(XmlNode node)
		{
			foreach (KeyValuePair<string, IGameVariable> variable in variables)
			{
				XmlElement nVariable = node.OwnerDocument.CreateElement("var") as XmlElement;
				XmlAttribute name = node.OwnerDocument.CreateAttribute("name");
				name.Value = variable.Key;
				nVariable.Attributes.Append(name);
				node.AppendChild(nVariable);

				variable.Value.SaveXml(nVariable);
			}
		}

		#endregion

		Dictionary<string, IGameVariable> variables;

		/// <summary>
		/// Sets the value of a variable with the specified name.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name">The variable name.</param>
		/// <param name="value">The value.</param>
		public void SetVariable<T>(string name, T value)
		{
			if (variables.ContainsKey(name))
				(variables[name] as GameVariable<T>).Value = value;
			else
				variables.Add(name, new GameVariable<T>(value));
		}

		/// <summary>
		/// Determines whether the variable with the specified exists.
		/// </summary>
		/// <param name="name">The variable name.</param>
		/// <returns>
		/// 	<c>true</c> if the variable with the specified name exists; otherwise, <c>false</c>.
		/// </returns>
		public bool HasVariable(string name)
		{
			return variables.ContainsKey(name);
		}

		/// <summary>
		/// Gets the value of a variable with the specified name or the specified default value if the variable doesn't exist.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name">The variable name.</param>
		/// <returns></returns>
		public T GetVariable<T>(string name)
		{
			return GetVariable<T>(name, default(T));
		}

		/// <summary>
		/// Gets the value of a variable with the specified name or the specified default value if the variable doesn't exist.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name">The variable name.</param>
		/// <param name="defaultValue">The default value.</param>
		/// <returns></returns>
		public T GetVariable<T>(string name, T defaultValue)
		{
			if (variables.ContainsKey(name))
				return (variables[name] as GameVariable<T>).Value;
			else
				return defaultValue;
		}

		#region ICustomBlackbirdComponent Members

		/// <summary>
		/// Gets the unique identifier of this custom component.
		/// </summary>
		/// <value>The unique identifier of this custom component.</value>
		public string Id
		{
			get { return "GameVariableManager"; }
		}

		#endregion
	}
}
