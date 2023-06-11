using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4stProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // [클래스 호출 방법]
            // 클래스명 지을변수명 = new 클래스명();
            // 위에서 만든 변수명 . 함수명();
            CardGame myClassC = new CardGame();
            myClassC.Start();
        }

    }
}
