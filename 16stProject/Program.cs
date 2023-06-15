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
    public class Program
    {
        static void Main(string[] args)
        {
            // 골드 지급
            Inventory.gold = 10000;
            // 골드 지급

            // 아이템 생성 & 상점 리스트에 등록
            // 이런 방식으로 리스트를 만든 후 for문으로 넣을 수 있다.
            List<Item> itemList = new List<Item>();

            for(int i = 0; i < 10; i++)
            {
                Item item = new Item();
                itemList.Add(item);
                itemList[i].InitItem("아이템" + i+1, 10*(i+1));    // 이런 방식으로 문자열에 숫자를 넣을 수 있다.
            }

            Dictionary<string, Shop> myShopItemList = new Dictionary<string, Shop>();
            List<Shop> ShopList = new List<Shop>();

            for(int i = 0; i < 10; i++)
            {
                Shop item = new Shop();
                ShopList.Add(item);
                ShopList[i].InitItem(itemList[i].itemName, itemList[i].itemPrice);
                myShopItemList.Add(ShopList[i].itemName, ShopList[i]);
            }
            // 아이템 생성 & 상점 리스트에 등록

            // 상점에 랜덤하게 3개 아이템 등록 & 상점 출력
            Random random = new Random();
            int count = 0;

            while (Inventory.gold > 0)
            {
                Shop myShop = new Shop();

                while (count < 3)
                {

                    foreach (KeyValuePair<string, Shop> item in myShopItemList)
                    {

                        if (count == 3)
                        {
                            break;
                        }

                        if (random.Next(0, 5) == 0)
                        {
                            myShop.SetItem(item.Value.itemName, item.Value.itemPrice);
                            count++;
                        }

                    }

                }

                count = 0;

                myShop.Start();
            }
            // 상점에 랜덤하게 3개 아이템 등록 & 상점 출력

        }
    }
}
