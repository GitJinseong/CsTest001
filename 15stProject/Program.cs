using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15stProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            ItemInfo redPotion = new ItemInfo();
            redPotion.InitItem("빨간 포션", 5, 100);

            ItemInfo gold = new ItemInfo();
            gold.InitItem("골드", 500, 1);

            ItemInfo sword = new ItemInfo();
            sword.InitItem("몰락한 왕의 검", 1, 39600);

            Dictionary<string, ItemInfo> myInventory2 = new Dictionary<string, ItemInfo>();
            myInventory2.Add("빨간 포션", redPotion);
            myInventory2.Add("골드", gold);
            myInventory2.Add("몰락한 왕의 검", sword);
             
            // Dictionary에 var를 사용하면 foreach(var 매개변수명 in Dictionary객체명)
            // 으로 접근할 수 있다.
            // var는 컴파일 타임에 컴퓨터에게 알아서 타입추론을 해 아래의 경우
            // KeyValuePair<데이터타입(키), 데이터타입(값)>로 설정을 해준다.
            // 하지만 타입추론을 할 경우 모든 데이터 타입을 찾아야 하기 때문에 속도가 느린편.
            // 타입추론과 타입추론을 사용할 떄(ex: 아이템 조합/도감 등) 체감이 될 정도로 속도가 느려진다.
            // 그래서 KeyValuePair을 사용하면 명시적이라 가독성이 좋다.
            foreach(var item in myInventory2)
            {
                Console.WriteLine("아이템 이름: {0}, 아이템 갯수: {1}, 아이템 가격: {2}",
                    item.Value.itemName, item.Value.itemCount, item.Value.itemPrice);
            }

        }
    }
}
