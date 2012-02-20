using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml;

namespace Teraluwide.DeuterosEx.DeuterosGame.Items
{
	public sealed class FactoryResource
	{
		string itemId = string.Empty;
		int amount = 1;

		/// <summary>
		/// Item Id
		/// </summary>
		[Description("Id of this resource.")]
		public string ItemId
		{
			get { return this.itemId; }
			set { this.itemId = value; }
		}

		/// <summary>
		/// Item amount
		/// </summary>
		[Description("Amount of this item required")]
		public int Amount
		{
			get { return this.amount; }
			set { this.amount = value; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FactoryResource"/> class.
		/// </summary>
		public FactoryResource()
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FactoryResource"/> class.
		/// </summary>
		/// <param name="itemId">The item id.</param>
		/// <param name="amount">The amount.</param>
		public FactoryResource(string itemId, int amount)
			: this()
		{
			this.itemId = itemId;
			this.amount = amount;
		}

		/// <summary>
		/// Loads the factory resource from a XmlElement.
		/// </summary>
		/// <param name="el">The element.</param>
		public void FromXml(XmlElement el)
		{
			this.itemId = el.Name;
			this.amount = int.Parse(el.Attributes["amount"].Value);
		}

		/// <summary>
		/// Saves the factory resource to a XmlElement.
		/// </summary>
		/// <param name="el">The el.</param>
		public void ToXml(XmlElement el)
		{
			XmlAttribute at;
			XmlDocument doc = el.OwnerDocument;

			at = doc.CreateAttribute("amount");
			at.Value = this.amount.ToString();
			el.Attributes.Append(at);
		}
	}

}
