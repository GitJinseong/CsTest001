using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    static public class Inventory
    {
        static public List<string> itemName = new List<string>();
        static public List<int> itemPrice = new List<int>();
        static public List<int> itemCount = new List<int>();
        static public int gold;

        // 인벤토리 출력하기
        static public void PrintInventory()
        {
            Console.WriteLine("\n[인벤토리]");

            for (int i = 0; i < itemName.Count; i++)
            {
                Console.WriteLine("▶{0} (x{1})", itemName[i], itemCount[i]);
            }

            Console.WriteLine("▶골드 (x{0})", gold);
        }

        // 인벤토리에 아이템 추가
        static public void InitInventory(string name, int count)
        {
            for (int i = 0; i < itemName.Count; i++)
            {

                if (itemName[i] == name)
                {
                    itemCount[i]++;
                    return;
                }

            }

            itemName.Add(name);
            itemCount.Add(count);
        }

        // 인벤토리에 골드 추가
        static public void InitGold(int value)
        {
            gold = value;
        }

    }
}
