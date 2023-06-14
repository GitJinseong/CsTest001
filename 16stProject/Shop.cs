using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// [상점과 인벤토리 시스템 만들기]
// 1. 아이템을 저장하고 있는 컬렉션을 만들고
// 2. 상점을 열면 -> 위의 컬렉션에서 랜덤으로 3가지 종류의 아이템을 출력한다.
// 3. 상점을 일정시간 (or 열 때마다) 아이템의 종류가 바뀐다.
// 4. 플레이어는 가지고 있는 골드의 범위 안에서 아이템을 구매할 수 있다.
// 5. 구매한 아이템은 플레이어의 인벤토리로 들어가고, 출력해서 볼 수 있다.
// 6. 아이템 갯수 제한은 따로 없음
namespace _16stProject
{
    public class Shop
    {
        public string itemName;
        public int itemPrice; 
        public int itemList_Count;

        private List<string> itemList_Name = new List<string>();
        private List<int> itemList_Price = new List<int>();

        // 상점창 표시
        public void Start()
        {
            Console.Clear();
            Console.WriteLine("상점에 오신 것을 환영합니다!");
            Console.WriteLine("-------[아이템 목록]-------");

            for (int i = 0; i < itemList_Count; i++)
            {
                Console.WriteLine("[{0}]이름: {1}   ->   가격: {2}", i, itemList_Name[i], itemList_Price[i]);
            }

            Inventory.PrintInventory();
            BuyItem();
        }

        // 아이템 구매
        public void BuyItem()
        {
            Console.WriteLine("\n구매하실 아이템 번호를 입력해주세요.");
            Console.Write(" : ");

            int num;
            int.TryParse(Console.ReadLine(), out num);

            if (num >= itemList_Count)
            {
                Console.WriteLine("\n잘못된 키입력 입니다.");
                Task.Delay(1000).Wait();
                return;
            }

            if (Inventory.gold >= itemList_Price[num])
            {
                Inventory.gold -= itemList_Price[num];

                Inventory.InitInventory(itemList_Name[num], 1);
                Inventory.PrintInventory();
            }
            else
            {
                Console.WriteLine("\n골드가 부족합니다.");
                Task.Delay(1000).Wait();
            }

        }

        // 상점 초기화


        // 상점에 아이템 등록
        public void SetItem(string itemName, int itemPrice)
        {
            itemList_Name.Add(itemName);
            itemList_Price.Add(itemPrice);
            itemList_Count++;
        }

        // 상점 아이템 리스트에 아이템 추가
        public void InitItem(string itemName, int itemPrice)
        {
            this.itemName = itemName;
            this.itemPrice = itemPrice;
        }

    }
}
