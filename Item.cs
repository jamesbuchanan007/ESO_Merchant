using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
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
        private int _ItemID { get; }
        private string _Name { get; }
        private decimal _Cost { get; }
        private decimal _Price { get; }
        private string _ImageName1 { get; }
        private string _ImageName2 { get; }
        private string _DataString { get; }
        private int _isListed { get; }

        private Item(int isListed, int itemID, string name, decimal cost, decimal price, string imageName1, string imageName2, string dataString)
        {
            _isListed = isListed;
            _ItemID = itemID;
            _Name = name;
            _Cost = cost;
            _Price = price;
            _ImageName1 = imageName1;
            _ImageName2 = imageName2;
            _DataString = dataString;
        }
        public int GetID()
        {
            return _ItemID;
        }

        public string GetName()
        {
            return _Name;
        }

        public decimal GetCost()
        {
            return _Cost;
        }

        public decimal GetPrice()
        {
            return _Price;
        }

        public string GetImageName1()
        {
            return _ImageName1;
        }
        public string GetImageName2()
        {
            return _ImageName2;
        }
        public int IsListed()
        {
            return _isListed;
        }

        #region Build Item
        public class BuildItem
        {
            private Item _item;

            public BuildItem(string name, string cost, string price, Image image1, Image image2)
            {
                string checkedName;

                // Do security validation here
                var timeStamp = new DateTime().ToString("yyyyMMddHHmmss");
                var convert = int.TryParse(timeStamp, out var itemId);

                if (!convert) throw new Exception("Problem with ItemID");

                if (!string.IsNullOrEmpty(name) || name.Length < 100)
                    checkedName = name;
                else throw new Exception("Name is Null or Name is too long");

                var isCostValid = decimal.TryParse(cost, out var checkedCost);
                if (!isCostValid) throw new Exception("Cost is not a number");

                var isPriceValid = decimal.TryParse(price, out var checkedPrice);
                if (!isPriceValid) throw new Exception("Price is not a number");

                if (image1 == null) throw new Exception("Something wrong with Image 1");

                if (image2 == null) throw new Exception("Something wrong with Image 2");

                var imageName1 = itemId + "_1.jpg";
                var imageName2 = itemId + "_2.jpg";

                // SAVE IMAGES
                image1.Save(@"D:\ESO Merchant\Images\" + imageName1);
                image2.Save(@"D:\ESO Merchant\Images\" + imageName2);

                var isListed = 0;

                var dataString =
                    isListed.ToString() + '|' +
                    itemId + '|' +
                    checkedName + '|' +
                    checkedCost + '|' +
                    checkedPrice + '|' +
                    imageName1 + '|' +
                    imageName2 + "\r\n";

                // SAVE DATA
                File.AppendAllText(@"D:\ESO Merchant\Data.txt", dataString + Environment.NewLine);

                _item = new Item(isListed, itemId, checkedName, checkedCost, checkedPrice, imageName1, imageName2, dataString);
            }

            public Item Build()
            {
                Item newItem = null;
                if (_item != null) newItem = _item;
                _item = null;    // Destroy Builder Item
                return newItem;
            }
        }
        #endregion


    }
}
