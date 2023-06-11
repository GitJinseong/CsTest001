using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// C#은 클래스 없이 단독으로 함수를 만들 수 없다.
// c#에서의 함수는 '메서드'라고 한다.
// 클래스 내부 함수 = 멤버 함수 = 메서드

namespace _1stProject
{
    internal class Program
    {
        static void Main(String[] args)
        {
            //Description();

            // C#은 내부적으로 초기화가 된다.
            int[] numbers = new int[5];
            int[,] numbers2 = new int[5, 5];

            int valueCount = 0;
            // C#은 기본적으로 초기화가 되어있어 0이 나온다.
            for(int y=0; y<5; y++)
            {
                for(int x = 0; x < 5; x++)
                {
                    valueCount += 1;
                    numbers2[y, x] = valueCount;
                }
            }

            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    // Write는 줄넘김 없다.
                    Console.Write("numbers2[{0}{1}] 의 값 : {2} ", y, x, numbers2[y, x]);
                }
                // WriteLine을 줄넘김이 기본이다.
                Console.WriteLine();    // 공백일 경우 한 칸 줄넘김한다.
            }
        }

        // static 메서드는 static 안에서만 부를 수 있다.
        static void Description()
        {
            Console.WriteLine("Hello World! \n");   // 출력

            string userInput1 = default; // c#은 default;로 초기화 한다.
            string userInput2 = default;
            int number = default;
            float floatNumber = default;

            int userNumber1 = default;
            int userNumber2 = default;

            // 여기서 입력을 받는다.
            userInput1 = Console.ReadLine(); // 입력(string으로 받는다)
            userInput2 = Console.ReadLine();

            // 입력 받은 것을 숫자로 변환한다.
            //userNumber1 = System.Convert.ToInt32(userInput1); // 숫자를 제외한 다른 타입의 값 입력시 오류
            //userNumber2 = System.Convert.ToInt32(userInput2); //

            //userNumber1 = int.Parse(userInput1);      // 숫자를 제외한 다른 타입의 값 입력시 오류
            //userNumber1 = int.Parse(userInput2);

            int.TryParse(userInput1, out userNumber1);  // 쓸모 없는 값은 0으로 바꾼다.
            int.TryParse(userInput2, out userNumber2);  // ex) asd = 0으로 변환

            // {번호}를 사용하여 변수를 출력한다.
            // 순서는 0~부터 시작한다.
            Console.WriteLine("입력 받은 내용을 출력하고 싶어 -> {0}, {1} \n\n", userInput1, userInput2);

            // string끼리 더하기가 가능하지만
            // int로 적용되는게 아니라 문자열을 합친다.
            Console.WriteLine("{0} + {1} = {2} \n", userNumber1, userNumber2, userNumber1 + userNumber2);
        }
    }
}
