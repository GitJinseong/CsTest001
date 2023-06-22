using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30stProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 튜플 선언하는 법
            (int xPos, int yPos) playerPosition = (0, 1);

            // 튜플에 값 넣기
            playerPosition.xPos = 10;
            playerPosition.yPos = 20;

            // 아래와 같은 형태로 데이터 스왑이 가능하다.
            Console.WriteLine("Player position: ({0}, {1})",playerPosition.xPos, playerPosition.yPos);
            (playerPosition.xPos, playerPosition.yPos) = (playerPosition.yPos, playerPosition.xPos);
            Console.WriteLine("Player position: ({0}, {1})", playerPosition.xPos, playerPosition.yPos);
        }
    }
}
