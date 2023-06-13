using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 플레이어에게서 사이즈를 입력받아서 * 배열을 초기화한다.
// 단 입력은 (5~15 사이의 값)
// ex) 사용자가 5를 입력한 경우
// * * * * *
// * * * * *
// * * * * *
// * * * * *
// * * * * *
// [색 표현 팁]
// Console.BackgroundColor = consoleColor.Red;
// Console.ForegroundColor = consoleColor.Red;
// [조건]
// 0. 사이즈는 (5~15)
// 1. w, a, s, d로 플레이어가 4방향 이동한다.
// 2. 무작위로 일정 시간마다 코인이 등장한다. or 3번 움직일 때마다.
// 3. 플레이어가 코인을 먹을 수 있다.
// 4. 플레이어가 코인을 먹는 경우 스코어가 올라간다.
// 5. 일정 스코어를 달성하면 게임을 종료한다.
// [추가]
// 1. 벽이 생성된다.
// 2. 벽을 들어서 움직일 수 있다.
// 3. 벽이 두 개가 일렬로 위치하면 움직 일 수 없다.
namespace _12stProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputValue = 0;

            KlayCoinGame game = new KlayCoinGame();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("게임 사이즈를 입력해주세요.(5~15)");
                Console.Write(" : ");

                int.TryParse(Console.ReadLine(), out inputValue);

                if (inputValue == 0 || (5 > inputValue && inputValue < 16))
                {
                    Console.WriteLine("ERROR! 다시 입력해주세요!!!");
                    Task.Delay(1000).Wait();
                }
                else
                {
                    game.Initialize(inputValue, 20, 3, 3);
                    game.Start();
                }

            }

        }
    }
}
