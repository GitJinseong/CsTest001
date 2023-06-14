using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _14stProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Dictionary<키, 값>의 사용방법 TIP
            // Dictionary<int, class> 형태로 클래스에 접근할 수 있다.

            // Dictionary는 Count로 접근할 수 없다.
            Dictionary<string, int> myInventory = new Dictionary<string, int>();
            myInventory.Add("빨간 포션", 5);
            myInventory.Add("골드", 500);
            myInventory.Add("몰락한 왕의 검", 1);

            // 키와 값을 동시에 가져오려면 KeyValuePair<데이터타입, 데이터타입>을
            // foreach에서 사용해야 한다. 그러면 Key와 Value를 가져올 수 있다.
            foreach(KeyValuePair<string, int> item in myInventory)
             {
                Console.WriteLine("아이템 이름: {0}, 아이템 갯수: {1}", item.Key, item.Value);
            }

            // 값만 가져오려면 아래와 같이 myInventory["키"]로 가져올 수 있다.
            Console.WriteLine("아이템 갯수: {0}", myInventory["빨간 포션"]);

            // Desc001();
        }       // Main();
        public static void Desc001()
        {
            // List는 List<데이터타입> 변수명 = new List<데이터타입>(); 으로 생성한다.
            List<int> numbers = new List<int>();
            //Console.WriteLine("내 리스트의 크기는 몇일까? -> {0}", numbers.Count);

            for (int i = 0; i < 10; i++)
            {
                numbers.Add(i + 1);
            }

            // 리스트는 여러개 지우려면 뒤에서 부터 지워야 한다.
            for (int i = numbers.Count; 0 <= i; i--)
            {
                if (i % 2 == 0)
                {
                    numbers.Remove(i);
                }
            }

            foreach (int n in numbers)
            {
                Console.WriteLine("내 리스트의 크기는 몇일까? -> {0}", n);
            }
        }

    }
}
