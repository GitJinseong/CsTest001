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
        private string itemName;
        private int itemCount { get; set; }  // { get; set;}을 프로퍼티(속성) 라고 한다.
                                             // 위에 아무 것도 적지 않으면 get, set 둘 다 선언된 타입으로 지정된다.
                                             // ex private int {get; set;}의 get, set은 private다.
        public int itemPrice { get; private set; }  // 이 경우 get은 public, set은 private 다.
                                                    // 아래와 달리 { get; private set; } 이라는 빌트인(예약어)를 사용하여
                                                    // 쉽게 구현할 수 있다.

        private int _itemPrice;
        public int itemPrice2 // 위의 public int itemPrice { get; private set; }는
        {                     // 아래와 같이 동작한다.
            get 
            {
                return _itemPrice;
            }

            private set
            {
                _itemPrice = value;
            }
        }

        public void InitItem(string name, int count, int price)
        {
            itemName = name;
            itemCount = count;
            itemPrice = price;
        }

        //! 아이템 name을 Return 해보겠음.
        public string Get_ItemName()
        {
            return itemName;
        }       //Get_ItemName()

        //! 아이템 name을 외부에서 변경할 수 있게 해주겠음.
        public void Set_ItemName(string changedName)
        {
            itemName = changedName;
        }       // Set_ItemName()
    }
}
