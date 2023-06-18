using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21stProject
{
    public class Item
    {
        #region 초기 선언부
        public string Name { get; private set; } = default;
        public int Price { get; private set; } = default;
        #endregion

        #region 생성자 함수
        #endregion
        public Item(string name_, int price_)
        {
            Name = name_;
            Price = price_;
        }

    }
}
