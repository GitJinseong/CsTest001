using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _3stProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 랜덤 클래스 호출
            Random random = new Random();
            int[] lottos = new int[6];

            for(int i=0; i<lottos.Length; i++)
            {
                // random.Next(min, max) 랜덤 값
                lottos[i] = random.Next(1, 45);
            }

            lottos.Reverse();

            // 1초 동안 대기
            Task.Delay(1000).Wait();

            // 간단한 for문 사용법
            // foreach(매개변수 in 반복횟수)
            foreach (int lotto_ in lottos)
            {
                Console.Write("{0} ", lotto_);
                //Task.Delay(1000).Wait();

                // 1초 대기
                Thread.Sleep(1000);
            }

            Console.WriteLine();
        }
    }
}
