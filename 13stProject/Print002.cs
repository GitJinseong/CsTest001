using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13stProject
{
    public class Print002
    {
        // 클래스 내부에 있는 것을 멤버라고 한다.
        // 멤버 == 필드 둘다 같다.
        // ex)멤버 변수 or 필드 변수
        // 함수는 메서드라고도 한다.
        string message = default;

        public void PrintMessage(string localMessage)   // 메서드의 접근 수준도 public
        {
            message = localMessage;
            Console.WriteLine("이런걸 출력할 것 - > {0}", message);
            // PrintMessage()
        }
    }
}
