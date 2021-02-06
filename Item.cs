using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private decimal Cost { get; set }
        private decimal Price { get; set }
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

        public class BuildItem
        {
            private Item item;
            private string checkedName;
            private decimal checkedCost;
            private decimal checkedPrice;
            private string checkedImage1;
            private string checkedImage2;
            public BuildItem(string name, string cost, string price, string image1, string image2)
            {
                if (!string.IsNullOrEmpty(name) || name.Length < 100)
                    checkedName = name;
                else throw new Exception("Name is Null or Name is too long");

                var isCostValid = decimal.TryParse(cost, out checkedCost);
                if (!isCostValid) throw new Exception("Cost is not a number");

                var isPriceValid = decimal.TryParse(price, out checkedPrice);
                if (!isPriceValid) throw new Exception("Price is not a number");

                if (!string.IsNullOrEmpty(image1) || image1.Length != 14) checkedImage1 = image1;
                else throw new Exception("Something wrong with Image 1");

                if (!string.IsNullOrEmpty(image2) || image2.Length != 14) checkedImage2 = image2;
                else throw new Exception("Something wrong with Image 1");

                item = new Item(checkedName, checkedCost, checkedPrice, checkedImage1, checkedImage2);
            }

            public Item Build()
            {
                Item newItem = null;
                if (item != null) newItem = item;
                item = null;    // Destroy Builder Item
                return newItem;
            }
        }

    }
}
