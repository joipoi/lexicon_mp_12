using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lexicon_mp_12
{
    class Item
    {
        public string Category { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }

        public Item(string category, string productName, int price)
        {
            Category = category;
            ProductName = productName;
            Price = price;
        }

        public override string? ToString()
        {
            //,-20 is same as PadRight(20)
            return $"{Category,-20}{ProductName,-20}{Price,-20}";
        }
    }

}
