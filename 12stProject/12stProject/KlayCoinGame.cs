using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
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
namespace _12stProject
{
    public class KlayCoinGame
    {
        // _getch() 생성
        [DllImport("msvcrt")]
        static extern char _getch();

        int mapSize;
        int playerScore;
        int moveCount;
        int[] playerLocation;
        int[] coinLocation;
        string[,] mapArray;

        public void Victory()
        {
            Console.Clear();
            Console.WriteLine("당신은 승리하였습니다!!!");
            Task.Delay(1000000000);
        }

        public void CheckScore(out bool runWhile)
        {

            if (playerScore == 10)
            {
                Victory();
                runWhile = false;
            }
            else // 여기 부분 else 사용 안해서 무한 반복되는 버그 있었음!ㅋ
            {
                runWhile = true;
            }

        }

        public void CheckCoin()
        {
            if ((coinLocation[0] == playerLocation[0]) && (playerLocation[1] == coinLocation[1]))
            {
                playerScore++;
                moveCount = 0;
                CreateCoin();
            }
        }

        public void MoveToUp()
        {
            int y = playerLocation[0];

            playerLocation[0] = y < 1 ? y : y - 1;
        }

        public void MoveToDown()
        {
            int y = playerLocation[0];

            playerLocation[0] = y < mapSize - 1 ? y + 1 : y;
        }

        public void MoveToLeft()
        {
            int x = playerLocation[1];

            playerLocation[1] = x < 1 ? x : x - 1;
        }

        public void MoveToRight()
        {
            int x = playerLocation[1];

            playerLocation[1] = x < mapSize - 1 ? x + 1: x;
        }

        public void InputKey()
        {
            char inputValue;
            bool runWhile = true;

            while (runWhile)
            {
                runWhile = false;
                inputValue = _getch();

                switch (inputValue)
                {
                    case 'w':
                        Console.Write("w");
                        MoveToUp();
                        break;

                    case 'a':
                        MoveToLeft();
                        Console.Write("a");
                        break;

                    case 's':
                        MoveToDown();
                        Console.Write("s");
                        break;

                    case 'd':
                        MoveToRight();
                        Console.Write("d");
                        break;

                    default:
                        runWhile = true;
                        break;
                }

            }
        }

        public void PrintScore()
        {
            Console.WriteLine("당신의 현재 스코어는 : {0} / 10", playerScore);
        }

        public void PrintMap()
        {
            Console.Clear();

            for (int i = 0; i < mapSize; i++)
            {
                
                for (int j = 0; j < mapSize; j++)
                {
                    Console.Write(mapArray[i, j]);
                }

                Console.WriteLine("\n");
            }

        }

        public void CreateCoin()
        {
            Random random = new Random();
            coinLocation[0] = random.Next(0, mapSize);
            coinLocation[1] = random.Next(0, mapSize);
        }

        public void CreateMap()
        {

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (i == playerLocation[0] && playerLocation[1] == j)
                    {
                        mapArray[i, j] = " ◆ ";
                        continue;
                    }
                    if (i == coinLocation[0] && coinLocation[1] == j)
                    {
                        mapArray[i, j] = " ㉭ ";
                        continue;
                    }    
                    mapArray[i, j] = " □ ";
                }
            }

        }

        public void Initialize(int mapSize, int x, int y)
        {
            this.mapSize = mapSize;
            this.playerLocation = new int[2] {x, y};
            mapArray = new string[mapSize, mapSize];
            coinLocation = new int[2];
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void Start()
        {
            bool runWhile = true;

            while (runWhile)
            {
                CreateMap();
                PrintMap();
                PrintScore();
                InputKey();

                if (moveCount == 4)
                {
                    CreateCoin();
                    moveCount = 0;
                }

                CheckCoin();
                CheckScore(out runWhile);

                moveCount++;
            }
        }
    }
}
