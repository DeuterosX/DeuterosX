using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Teraluwide.Blackbird.Core;

namespace Teraluwide.DeuterosEx.DeuterosGame.Stations
{
	/// <summary>
	/// Represents information about a mining operation in a MiningFacilityStationModule.
	/// </summary>
	public class MiningOperationInfo
	{
		private string id;
		/// <summary>
		/// Gets or sets the operation id (= the material mined).
		/// </summary>
		/// <value>
		/// The id.
		/// </value>
		public string Id
		{
			get { return this.id; }
			set { this.id = value; }
		}

		private int currentMiningLimit = 0;
		/// <summary>
		/// Resources left in the currently running mine.
		/// </summary>
		public int CurrentMiningLimit
		{
			get { return currentMiningLimit; }
			set { currentMiningLimit = value; }
		}

		private int surveyProgress = 10;
		/// <summary>
		/// The survey progress for this mine - when zero, mine is ready to be mined.
		/// </summary>
		public int SurveyProgress
		{
			get { return surveyProgress; }
			set { surveyProgress = value; }
		}

		/// <summary>
		/// Loads the mining operation information from the specified XmlElement.
		/// </summary>
		/// <param name="node">The node.</param>
		public void LoadXml(XmlElement node)
		{
			this.id = node.Name;
			this.currentMiningLimit = int.Parse(node.GetAttributeOrNull("currentMiningLimit"));
			this.surveyProgress = int.Parse(node.GetAttributeOrNull("surveyProgress"));
		}

		/// <summary>
		/// Saves the mining operation information to the specified XmlElement.
		/// </summary>
		/// <param name="node">The node.</param>
		public void SaveXml(XmlElement node)
		{
			node.Attributes.Append(node.OwnerDocument.CreateAttributeWithValue("currentMiningLimit", currentMiningLimit.ToString()));
			node.Attributes.Append(node.OwnerDocument.CreateAttributeWithValue("surveyProgress", surveyProgress.ToString()));
		}
	}
}
