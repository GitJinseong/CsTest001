using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15stProject
{
    public class ItemInfo
    {
        // foreach에서 접근하기 위해 public으로 변경
        public string itemName;
        public int itemCount;
        public int itemPrice;

        public void InitItem(string name, int count, int price)
        {
            itemName = name;
            itemCount = count;
            itemPrice = price;
        }
    }
}
