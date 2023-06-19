using _21stProject.ChildClass;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21stProject.Manager
{
    public class Shop_Manager
    {
        #region 초기 선언부
        public const int SHOP_ITEMS_COUNT = 3;
        public List<Item> ShopList { get; private set; } = default;
        #endregion

        #region 생성자 함수
        #endregion
        public Shop_Manager()

        {
            Set_CreateItemList();
        }

        #region 초기화 함수
        #endregion
        public void Set_CreateItemList()
        {
            ShopList = new List<Item>();
            for (int i = 0; i < SHOP_ITEMS_COUNT; i++)
            {
                Random random = new Random();
                Item item = new Item("잡화", random.Next(0, 2147483647));
                ShopList.Add(item);
                System.Threading.Thread.Sleep(16);
            }

        }

        #region 상점 열기 함수
        #endregion
        public void Get_OpenShop(Player player)
        {
            Console.Clear();
            Console.WriteLine("상점에 오신 것을 반기지 않습니다.");
            Console.WriteLine("아이템을 구매해야 나갈 수 있습니다.\n");
            Console.WriteLine("[판매 목록]");

            for (int i = 0; i < ShopList.Count; i++)
            {
                Console.WriteLine("<{0}> [이름]: {1}   /   가격: {2}", i, ShopList[i].Name, ShopList[i].Price);
            }

            Console.WriteLine("\n 아이템 옆에 표시된 번호를 눌러 살 수는 있습니다.");
            Console.WriteLine("내가 보유한 골드: {0}", player.Golds);

            Set_BuyItem(player, Managers.Input._GetInt());
        }

        #region 상점 아이템 구매 함수
        #endregion
        public void Set_BuyItem(Player player, int inputValue)
        {
            if (inputValue >= ShopList.Count)
            {
                Console.WriteLine("\n잘못된 값을 입력했습니다.");
                Task.Delay(500).Wait();

                return;
            }

            string name = ShopList[inputValue].Name;
            int price = ShopList[inputValue].Price;
            int golds = player.Golds;
            if (player.Golds >= price)
            {
                player.Set_Golds(golds - price);
                Console.WriteLine("\n{0} 아이템을 구매했습니다.", name);
                Task.Delay(500).Wait();

            }
            else
            {
                Console.WriteLine("\n골드가 부족합니다.");
                Task.Delay(500).Wait();
            }

        }

    }

}
