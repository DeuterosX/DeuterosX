using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Teraluwide.DeuterosEx.DeuterosGame.Universe
{

	/// <summary>
	/// Class for holding information about survey of body
	/// </summary>
	public class SurveyInfo
	{
		SpaceItem parent;
		/// <summary>
		/// Gets the parent space item.
		/// </summary>
		public SpaceItem Parent { get { return this.parent; } }

		private bool mineralMineable = false;
		/// <summary>
		/// Gets or sets whether this mineral is mineable on this body
		/// </summary>
		public bool MineralMineable
		{
			get { return mineralMineable; }
			set { mineralMineable = value; }
		}

		private int minMineLimit = 1000;
		/// <summary>
		/// Gets or sets the minimal mine resource capacity on a new survey
		/// </summary>
		public int MinMineLimit
		{
			get { return minMineLimit; }
			set { minMineLimit = value; }
		}

		private int maxMineLimit = 150000;
		/// <summary>
		/// Gets or sets the maximal mine resource capacity on a new survey
		/// </summary>
		public int MaxMineLimit
		{
			get { return maxMineLimit; }
			set { maxMineLimit = value; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SurveyInfo"/> class.
		/// </summary>
		public SurveyInfo(SpaceItem parent)
		{
			this.parent = parent;
		}

		/// <summary>
		/// Performs a new survey on the deposit.
		/// </summary>
		/// <returns></returns>
		public int NewSurvey()
		{
			return new Random(Parent.SolarSystem.Galaxy.Manager.Game.GetRandomSeed()).Next(this.minMineLimit, this.maxMineLimit);
		}

		/// <summary>
		/// Loads the survey information from the specified XmlNode.
		/// </summary>
		/// <param name="node">The node.</param>
		public void FromXml(XmlNode node)
		{
			this.maxMineLimit = int.Parse(node.Attributes["maxMineLimit"].Value);
			this.mineralMineable = bool.Parse(node.Attributes["mineralMineable"].Value);
			this.minMineLimit = int.Parse(node.Attributes["minMineLimit"].Value);
		}

		/// <summary>
		/// Saves the survey information to the specified XmlNode.
		/// </summary>
		/// <param name="node">The node.</param>
		public void ToXml(XmlNode node)
		{
			XmlDocument doc = node.OwnerDocument;
			XmlAttribute at;

			at = doc.CreateAttribute("maxMineLimit");
			at.Value = this.maxMineLimit.ToString();
			node.Attributes.Append(at);

			at = doc.CreateAttribute("mineralMineable");
			at.Value = this.mineralMineable.ToString();
			node.Attributes.Append(at);

			at = doc.CreateAttribute("minMineLimit");
			at.Value = this.minMineLimit.ToString();
			node.Attributes.Append(at);
		}
	}
}
