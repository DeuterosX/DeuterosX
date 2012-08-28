using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.ComponentModel;
using Teraluwide.Blackbird.Core;
using System.Drawing;
using Teraluwide.DeuterosEx.DeuterosGame.Teams;

namespace Teraluwide.DeuterosEx.DeuterosGame.Items
{
	public class StoreItem
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="StoreItem"/> class.
		/// </summary>
		public StoreItem()
		{
			this.resources = new List<FactoryResource>();
		}

		/// <summary>
		/// Gets or sets the id of this item.
		/// </summary>
		/// <value>
		/// The id.
		/// </value>
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets whether the item is ready for production
		/// </summary>
		[Browsable(true)]
		[Description("Item is ready for production.")]
		public virtual bool Researched
		{
			get { return ResearchPointsNeeded <= ResearchProgress; }
		}

		private bool canResearch = true;
		/// <summary>
		/// Gets or sets whether the item can be researched
		/// </summary>
		[Description("Item may be researched.")]
		public virtual bool CanResearch
		{
			get { return this.canResearch; }
			set { this.canResearch = value; }
		}

		private string title = "Item";
		/// <summary>
		/// Gets item title
		/// </summary>
		[Description("Item title.")]
		public virtual string Title
		{
			get { return title; }
			set { title = value; }
		}

		private string description = "";
		/// <summary>
		/// Gets/sets the item description
		/// </summary>
		//[Description("Item description as shown in the storage interface.")]
		[Browsable(false)]
		public virtual string Description
		{
			get { return this.description; }
			set { this.description = value; }
		}

		[Editor(@"System.Windows.Forms.Design.StringCollectionEditor, 
		System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
		typeof(System.Drawing.Design.UITypeEditor))]
		[Description("Item description as shown in the storage interface.")]
		public virtual string[] DescriptionLines
		{
			get { return this.description.Split(new string[1] { "\r\n" }, StringSplitOptions.None); }
			set { this.description = string.Join("\r\n", value); }
		}

		private int buildTime = 100;
		/// <summary>
		/// Gets item build time
		/// </summary>
		[Description("Specifies the build time in work units.")]
		public virtual int BuildTime
		{
			get { return buildTime; }
			set { buildTime = value; }
		}

		private int buildRank = 0;
		/// <summary>
		/// Gets/sets the necessary team rank to build
		/// </summary>
		[Browsable(false)]
		public virtual int BuildRank
		{
			get { return this.buildRank; }
			set { this.buildRank = value; }
		}

		/// <summary>
		/// Gets or sets the necessary team rank to build using a ProductionTeamRank enum
		/// </summary>
		[Description("Specifies the lowest team rank that is allowed to build this item.")]
		[DisplayName("Build rank")]
		public virtual ProductionTeamRank BuildRankValue
		{
			get { return (ProductionTeamRank)this.buildRank; }
			set { this.buildRank = (int)value; }
		}

		private int researchRank = 0;
		/// <summary>
		/// Gets/sets the necessary team rank to research
		/// </summary>
		[Browsable(false)]
		public virtual int ResearchRank
		{
			get { return this.researchRank; }
			set { this.researchRank = value; }
		}

		/// <summary>
		/// Gets or sets the necessary team rank to research using a ResearchTeamRank enum
		/// </summary>
		[Description("Specifies the lowest team rank that is allowed to research this item.")]
		[DisplayName("Research rank")]
		public virtual ResearchTeamRank ResearchRankValue
		{
			get { return (ResearchTeamRank)this.buildRank; }
			set { this.buildRank = (int)value; }
		}

		private bool orbitalOnly = false;
		/// <summary>
		/// Gets/sets whether the item may be produced in orbit only or not
		/// </summary>
		[Description("Item may only be built on orbit.")]
		public virtual bool OrbitalOnly
		{
			get { return this.orbitalOnly; }
			set { this.orbitalOnly = value; }
		}

		private ItemType type = ItemType.Unknown;
		/// <summary>
		/// Gets item type
		/// </summary>
		[Description("Item type.")]
		public virtual ItemType Type
		{
			get { return type; }
			set { type = value; }
		}

		private string picture = string.Empty;
		/// <summary>
		/// Gets or sets the texture for item production blueprint
		/// </summary>
		[Description("Texture ID")]
		public virtual string Picture
		{
			get { return this.picture; }
			set { this.picture = value; }
		}

		private Rectangle textureArea = Rectangle.Empty;
		/// <summary>
		/// Gets or sets the texture area for item production blueprint
		/// </summary>
		[Description("Texture area (only 1 stage of the picture)")]
		public virtual Rectangle TextureArea
		{
			get { return this.textureArea; }
			set { this.textureArea = value; }
		}

		private List<FactoryResource> resources = null;
		/// <summary>
		/// List of all resources required to build this item.
		/// </summary>
		[Description("Resources required to build the item.")]
		public List<FactoryResource> Resources
		{
			get { return resources; }
		}

		private int mass = 1;
		/// <summary>
		/// Item mass
		/// </summary>
		[Description("Item mass.")]
		public int Mass
		{
			get { return this.mass; }
			set { this.mass = value; }
		}

        private bool showInProductionScreen = false;
        /// <summary>
        /// Should the item be presented in production screen?
        /// </summary>
        [Description("Show item in production screen.")]
        public bool ShowInProductionScreen
        {
            get { return this.showInProductionScreen; }
            set { this.showInProductionScreen = value; }
        }

        private bool showInResearchScreen = false;
        /// <summary>
        /// Should the item be presented in research screen?
        /// </summary>
        [Description("Show item in research screen.")]
        public bool ShowInResearchScreen
        {
            get { return this.showInResearchScreen; }
            set { this.showInResearchScreen = value; }
        }

		private int researchProgress = 0;
		/// <summary>
		/// Research progress. Doesn't save into template.
		/// </summary>
		[Description("Research progress. Doesn't save into TemplateItems, saves with SaveGame.")]
		public int ResearchProgress
		{
			get { return this.researchProgress; }
			set { this.researchProgress = value; }
		}

		private int researchPointsNeeded = 0;
		/// <summary>
		/// Research points needed to finish the research.
		/// </summary>
		[Description("Total amount of research points required to research the item.")]
		public int ResearchPointsNeeded
		{
			get { return this.researchPointsNeeded; }
			set { this.researchPointsNeeded = value; }
		}


		/// <summary>
		/// Loads the item from a XmlElement.
		/// </summary>
		/// <param name="node">The Xml node.</param>
		public virtual void FromXml(XmlElement node)
		{
			this.Id = node.Name;
			this.title = node.SelectSingleNode("Title").InnerText;

			// NOTE: Those are save in the save game, along with research progress.
			//this.researched = bool.Parse(node.SelectSingleNode("Researched").InnerText);
			//this.canResearch = bool.Parse(node.SelectSingleNode("CanResearch").InnerText);

			this.type = XmlHelper.ParseEnum<ItemType>(node.SelectSingleNode("ItemType").InnerText);
			this.description = node.SelectSingleNode("Description").InnerText;
			this.buildTime = int.Parse(node.SelectSingleNode("BuildTime").InnerText);
			this.buildRank = int.Parse(node.SelectSingleNode("BuildRank").InnerText);
			this.researchRank = int.Parse(node.SelectSingleNode("ResearchRank").InnerText);
			this.orbitalOnly = bool.Parse(node.SelectSingleNode("OrbitalOnly").InnerText);
			this.picture = node.SelectSingleNode("Picture").InnerText;

            if (node.SelectSingleNode("ShowInProductionScreen") != null)
                this.showInProductionScreen = bool.Parse(node.SelectSingleNode("ShowInProductionScreen").InnerText);
            if (node.SelectSingleNode("ShowInResearchScreen") != null)
                this.showInResearchScreen = bool.Parse(node.SelectSingleNode("ShowInResearchScreen").InnerText);
			if (node.SelectSingleNode("Mass") != null)
				this.mass = int.Parse(node.SelectSingleNode("Mass").InnerText);
			if (node.SelectSingleNode("ResearchPointsNeeded") != null)
				this.researchPointsNeeded = int.Parse(node.SelectSingleNode("ResearchPointsNeeded").InnerText);

			XmlNode par;

			this.textureArea = XmlHelper.ParseRectangle(node, "TextureArea", Rectangle.Empty);

			par = node.SelectSingleNode("Resources");

			this.resources.Clear();
			foreach (var el in par.ChildNodes.OfType<XmlElement>())
			{
				FactoryResource res = new FactoryResource();
				res.FromXml(el);

				this.resources.Add(res);
			}
		}

		/// <summary>
		/// Saves the item to a XmlElement.
		/// </summary>
		/// <param name="node">The Xml node.</param>
		public virtual void ToXml(XmlElement node)
		{
			throw new NotImplementedException();
		}
	}
}
