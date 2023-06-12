using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _6stProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] str = new string[2] { "Hello", "World" };
            // CallFunc001(str);
            // CallFunc002("Hello", "World", "+", "Hello", "World");
            // CallFunc003(ref str);

            
            string[] resultStr; // string 배열을 선언함.
            CallFunc004(str, out resultStr);    // out을 활용해서 값을 넘겨 받음.
            foreach(string result_ in resultStr)      // C++의 int 함수처럼 return 값을 받는다고 보면 된다.
            {
                Console.Write("{0}", result_);
            }
            Console.WriteLine();
        }       // Main()

        //! 네번 째 방법은 매개변수를 Call by reference 방시으로 넘기는 방법
        //! 매개변수를 통해서 값을 Return 한다.
        //! 아래의 경우 out을 사용하면 무조건 무언가를 out 해야 한다.
        //! 참고로 out을 사용하기 전에 함수를 실행한 메서드 안에 값을
        //! 저장할 공간을 미리 만들어야 한다.
        //! 절대 비어있으면 안되는 곳에 사용한다 ex)닉네임
        static void CallFunc004(string[] str, out string[] outStr)
        {
            string[] resultString = new string[str.Length + 1];

            for (int i = 0; i < str.Length; i++)
            {
                resultString[i] = str[i];
            }
            resultString[str.Length] = "!";
            outStr = resultString;

            int number = 0;
            number = number++;
            Console.WriteLine("number은 무슨 값이 들어 있나? {0}", number);
            // 위의 결과가 0이 나오는 이유는
            // int number = 0;으로 스택에 값을 생성한 후 닫고.
            // number = number++;로 연산 공간을 임시로 새로 만든다음
            // 연산하고 닫는다. 그래서 값이 0이다.
            // 만약 ++number;로 전위 연산할 경우 스택을 닫기 전에 값을 변경해서 1이 나온다.
            // number = number++는 이렇게 작동한다.
            // temp = number + 1;
            // number = 0;
            // number = ++number는 이렇게 작동한다.
            // number = 0;
            // temp = number + 1;

        }

        //! 세번 째 방법은 매개변수를 Call by reference 방식으로 넘기는 방법
        //! 받은 값을 수정하면 원래 보냈던 값도 같이 변한다.
        //! 역참조와 같다고 보면 된다.
        static void CallFunc003(ref string[] str)
        {
            str[0] = "COla";
            foreach (string strElement in str)
            {
                Console.Write("{0}", strElement);
            }
        }

        //! 두번 째 방법은 매개변수를 Call by value 방식으로 넘기는건 똑같음. 그런데
        //! 배열을 보내는게 아니라 매개 변수들을 여러개 보낸 후 메서드 안에서 배열로 만든다.
        //! CallFunc002("Hello", "World", "+", "Hello", "World"); 를 하면
        //! static void CallFunc002(params string[] str) 해당 메서드에서
        //! str 배열로 생성이 된다.
        //! params = 파라메터(매개변수를 뜻함), 아그먼트, 인자, 인수 등을 뜻함.
        static void CallFunc002(params string[] str)
        {
            foreach (string strElement in str)
            {
                Console.Write("{0}", strElement);
            }
        }

        //! 첫 번째 방법은 매개변수를 Call by value 방식으로 넘기는 방법
        static void CallFunc001(string[] str)
        {
            foreach(string strElement in str) // 배열과 비슷한 데이터 타입을
            {
                Console.Write("{0} ", strElement);
            }
            Console.WriteLine();
        }       // CallFunc001()
    }       // class Program
}
 