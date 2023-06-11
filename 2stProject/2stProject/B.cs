using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2stProject
{
    public class B
    {
        // 따로 클래스 안에 함수를 만들어야 문장이 실행된다.
        // static의 경우 public class 이더라도 접근이 불가능하다.
        // public void로 변경해야 한다.
          public void PrintMyArray(int[,] array_)
        {
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    Console.Write("{0} ", array_[y, x]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
