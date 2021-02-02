using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ESO_Merchant
{
	public class Item
	{
		private int ItemID { get; set; }
		private string Name { get; set; }
		private decimal Cost { get;set }
		private decimal Price { get;set }
		private string Image1 { get; set; }
		private string Image2 { get; set; }

		private Item(string name, decimal cost, decimal price, string image1, string image2)
		{
			this.Name = name;
			this.Cost = cost;
			this.Price = price;
			this.Image1 = image1;
			this.Image2 = image2;
		}

		public Item BuildItem(string name, string cost, string price, string image1, string image2)
		{
			//Build item ID
			// set image IDs
			var checkedName = string.Empty;
			if (!string.IsNullOrEmpty(name) || name.Length > 100)
				checkedName = name;
			else throw new Exception("Name is Null or Name is too long");

			var isCostValid = decimal.TryParse(cost, out var checkedCost);
			if(!isCostValid) throw new Exception("Cost is not a number");

			var isPriceValid = decimal.TryParse(price, out var checkedPrice);
			if (!isPriceValid) throw new Exception("Price is not a number");

			var checkedImage1 = string.Empty;
			if (!string.IsNullOrEmpty(image1) || image1.Length != 14) checkedImage1 = image1;
			else throw new Exception("Something wrong with Image 1");

			var checkedImage2 = string.Empty;
			if (!string.IsNullOrEmpty(image2) || image2.Length != 14) checkedImage2 = image2;
			else throw new Exception("Something wrong with Image 1");

			return new Item(checkedName, checkedCost, checkedPrice, checkedImage1, checkedImage2);
		}
		
	}
}
