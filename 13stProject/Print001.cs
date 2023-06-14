using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13stProject
{
    public class Print001       // 클래스의 접근 수준이 public
    {
        // 클래스 내부에 있는 것을 멤버라고 한다.
        // 멤버 == 필드 둘다 같다.
        // ex)멤버 변수 or 필드 변수
        // 함수는 메서드라고도 한다.

        public static string staticMessage = default;

        string message = default;

        // 공통적으로 여러 클래스에서 호출할 때 static을 사용한다.
        // 많이 사용할 경우 메모리에 과부하를 줄 수 있다.
        // 임의로 지울 수 없다.(프로그램 종료 전 까지)
        public static void PrintMessage(string localMessage)   // 메서드의 접근 수준도 public
        { 
            staticMessage = localMessage;
            Console.WriteLine("이런걸 출력할 것 - > {0}", staticMessage);
                // PrintMessage()
        }

        public static void PrintMessage2()
        {
            // static에서 인스턴스 필드에 있는 멤버 변수/함수를 호출하려면
            // 따로 클래스 인스턴스 객체를 생성하여 호출 해야한다.
            Print001 myPrint = new Print001();
            myPrint.message = staticMessage;
            Console.WriteLine("Static 메서드에서 인스턴스 필드를 찍어볼 수 있을까? - > {0}", myPrint.message);
        }
    }
}
