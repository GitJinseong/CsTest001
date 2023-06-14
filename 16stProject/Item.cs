using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16stProject
{
    public class Item
    {
        public string itemName;
        public int itemPrice;

        // 아이템 생성
        public void InitItem(string itemName, int itemPrice)
        {
            this.itemName = itemName;
            this.itemPrice = itemPrice;
        }
    }
}
