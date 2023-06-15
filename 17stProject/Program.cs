using _15stProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17stProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Desc003();
        }

        static public void Desc003()
        {
            // 내가 정의한 enum 타입 변수를 선언해 볼 것임.
            ItemType_DY itemType;

            itemType = ItemType_DY.GOLD;
            // itemType의 값이 0이 맞는지 검증하는 방법(1)
            Console.WriteLine("enum type은 무엇이라고 출력이 될까?? -> {0}", ((int)itemType));

            // itemType의 값이 0이 맞는지 검증하는 방법(2)
            if ((int)itemType == 0)
            {
                Console.WriteLine("itemType을 int로 형변환 한 값은 0과 같은 값이 맞다.");
            }

            switch (itemType)
            {
                case ItemType_DY.POTION:
                    Console.WriteLine("이 아이템의 타입은 물약 입니다.");
                    break;
                case ItemType_DY.GOLD:
                    Console.WriteLine("이 아이템의 타입은 금전 입니다.");
                    break;
                case ItemType_DY.WEAPON:
                    Console.WriteLine("이 아이템의 타입은 무기 입니다.");
                    break;
                case ItemType_DY.ARMOR:
                    Console.WriteLine("이 아이템의 타입은 갑옷 입니다.");
                    break;
                default:
                    Console.WriteLine("이 아이템의 타입은 정의되지 않았습니다.");
                    break;
            }
        }

        static public void Desc002()
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
            foreach (var item in myInventory2)
            {
                Console.WriteLine("아이템 이름: {0}, 아이템 갯수: {1}, 아이템 가격: {2}",
                    item.Value.itemName, item.Value.itemCount, item.Value.itemPrice);
            }
        }
    }
}
