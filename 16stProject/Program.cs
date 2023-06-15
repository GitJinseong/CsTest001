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
            Item item_001 = new Item();
            Item item_002 = new Item();
            Item item_003 = new Item();
            Item item_004 = new Item();
            Item item_005 = new Item();
            Item item_006 = new Item();
            Item item_007 = new Item();
            Item item_008 = new Item();
            Item item_009 = new Item();
            Item item_010 = new Item();

            item_001.InitItem("아이템1", 10);
            item_002.InitItem("아이템2", 20);
            item_003.InitItem("아이템3", 30);
            item_004.InitItem("아이템4", 40);
            item_005.InitItem("아이템5", 50);
            item_006.InitItem("아이템6", 60);
            item_007.InitItem("아이템7", 70);
            item_008.InitItem("아이템8", 80);
            item_009.InitItem("아이템9", 90);
            item_010.InitItem("아이템10", 100);

            Shop shopItem_001 = new Shop();
            Shop shopItem_002 = new Shop();
            Shop shopItem_003 = new Shop();
            Shop shopItem_004 = new Shop();
            Shop shopItem_005 = new Shop();
            Shop shopItem_006 = new Shop();
            Shop shopItem_007 = new Shop();
            Shop shopItem_008 = new Shop();
            Shop shopItem_009 = new Shop();
            Shop shopItem_010 = new Shop();

            shopItem_001.InitItem(item_001.itemName, item_001.itemPrice);
            shopItem_002.InitItem(item_002.itemName, item_002.itemPrice);
            shopItem_003.InitItem(item_003.itemName, item_003.itemPrice);
            shopItem_004.InitItem(item_004.itemName, item_004.itemPrice);
            shopItem_005.InitItem(item_005.itemName, item_005.itemPrice);
            shopItem_006.InitItem(item_006.itemName, item_006.itemPrice);
            shopItem_007.InitItem(item_007.itemName, item_007.itemPrice);
            shopItem_008.InitItem(item_008.itemName, item_008.itemPrice);
            shopItem_009.InitItem(item_009.itemName, item_009.itemPrice);
            shopItem_010.InitItem(item_010.itemName, item_010.itemPrice);

            Dictionary<string, Shop> myShopItemList = new Dictionary<string, Shop>();
            myShopItemList.Add(shopItem_001.itemName, shopItem_001);
            myShopItemList.Add(shopItem_002.itemName, shopItem_002);
            myShopItemList.Add(shopItem_003.itemName, shopItem_003);
            myShopItemList.Add(shopItem_004.itemName, shopItem_004);
            myShopItemList.Add(shopItem_005.itemName, shopItem_005);
            myShopItemList.Add(shopItem_006.itemName, shopItem_006);
            myShopItemList.Add(shopItem_007.itemName, shopItem_007);
            myShopItemList.Add(shopItem_008.itemName, shopItem_008);
            myShopItemList.Add(shopItem_009.itemName, shopItem_009);
            myShopItemList.Add(shopItem_010.itemName, shopItem_010);
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
