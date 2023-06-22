using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28stProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Desc001();
        }

        static void Desc001()
        {
            List<int> inList = new List<int>();
            // 값 타입이 참조 형식인지 아닌지 궁금하면
            // null을 넣어보면 된다.
            // 될 경우 참조 형식이다. 아닐 경우 데이터 타입.
            inList = null;
            CustomClass customClass = new CustomClass();
            GenericClass genericClass = new GenericClass();

            CustomChild customChild = new CustomChild();
            CustomChild customChild2 = default;
            CustomChild customChild3 = new CustomChild();

            customChild.Initalize(0, 1);

            // 아래는 얕은 복사(Link : 주소 값 복사) 이다.
            // 값을 수정할 경우 동시에 바뀐다.
            customChild2 = customChild;

            // 아래는 깊은 복사다. 서로 다른 객체가 된다.
            // 하지만 값은 같다.
            customChild3.Initalize(customChild.xPos, customChild.yPos);

            customChild2.PrintPosition();
            //PrintValue(52f);


            //PrintValue(customChild);

            customChild = null;
            if (customChild == null)
            {
                Console.WriteLine("customChild는 null 입니다.");
            }
            else
            {
                customChild.PrintPosition();
            }
            // nullable : 중간에 ?를 넣어서 null 값을 체크
            // 특정 상황에서 작동되지 않는 오류가 있다.
            // 쓰지 않는 것을 추천.
            customChild?.PrintPosition();
            int? number = null;
        }
        
        // 모든 데이터 타입을 받아올 수 있는 제네릭(일반화) 타입 매개 변수
        // 아래와 같이 where T : CustomClass 를 선언하면
        // CustomClass를 상속 받은 클래스만 접근 가능하다.
        static void PrintValue<T>(T anyValue) where T : CustomClass
        {
            anyValue.PrintPosition();
        }

    //static void PrintValue(int intValue)
    //{
    //    Console.WriteLine("int 변수로 넘겨받은 값을 출력했다. -> {0}", intValue);
    //}

    //static void PrintValue(float floatValue)
    //{
    //    Console.WriteLine("float 변수로 넘겨받은 값을 출력했다. -> {0}", floatValue);
    //}

    //static void PrintValue(string strValue)
    //{
    //    Console.WriteLine("string 변수로 넘겨받은 값을 출력했다. -> {0}", strValue);
    //}
    }
}
