using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

// [과제]
// tic tac toe 게임 만들기
// 사이즈는 3x3
// 인덱스 1~9 or 0~8번 받아서 출력후 선택하기
// 선택시 원하는 패턴 표시하고 
// 먼저 3줄 빙고 하나 만들면 승리(오목 같은 느낌)
// 상대가 빙고를 완성하지 못하게 막을 수 있다.
// 승리 / 패배 구현하기
namespace _11stProject
{
    public class TicTacToe
    {
        string[] mapArray;
        string playerPattern;
        string computerPattern;
        string blankPattern;

        bool firstRun = true;

        public void CreateMap()
        {
            mapArray = new string[9];
            
            for (int i = 0; i < mapArray.Length; i++)
            {
                mapArray[i] = blankPattern;
            }

        }

        public void PrintMap()
        {

            for (int i = 1; i< mapArray.Length + 1; i++)
            {
                Console.Write(mapArray[i - 1]);

                if (i % 3 == 0)
                {
                    Console.WriteLine();
                }

            }

        }

        public void SetPattern(int inputValue, string pattern, bool boolValue, out bool playerTurn)
        {
            playerTurn = boolValue;

            if (mapArray[inputValue - 1] == blankPattern)
            {
                mapArray[inputValue - 1] = pattern;
                playerTurn = !boolValue;
            }
            else if (playerTurn)
            {
                Console.WriteLine("해당 위치는 선택하실 수 없습니다.");
                Task.Delay(1000).Wait();
            }

        }

        public int InputKey()
        {
            Console.WriteLine("원하시는 위치를 입력해주세요.(1~9)");
            Console.Write(" : ");

            int inputValue;
            int.TryParse(Console.ReadLine(), out inputValue);

            if (!(0 < inputValue && inputValue < 10))
            {
                inputValue = 0;
            }

            return inputValue;
        }


        public void ComputerAI(bool boolValue, out bool playerTurn)
        {
            playerTurn = boolValue;

            int[] array_A = new int[4] { 1, 3, 7, 9 };
            int[] array_B = new int[4] { 2, 4, 6, 8 };

            Random random = new Random();

            int randomValue;

            if (firstRun)
            {

                for (int i = 0; i < 4; i++)
                {
                    if (mapArray[4] == playerPattern)
                    {
                        if (mapArray[array_A[i] - 1] == blankPattern)
                        {
                            SetPattern(array_A[i], computerPattern, boolValue, out playerTurn);
                            firstRun = !firstRun;
                            break;
                        }
                    }

                    if (mapArray[array_A[i] - 1] == playerPattern && mapArray[4] == blankPattern)
                    {
                        SetPattern(5, computerPattern, boolValue, out playerTurn);
                        firstRun = !firstRun;
                        break;
                    }

                    if (mapArray[array_B[i] - 1] == playerPattern && mapArray[4] == blankPattern)
                    {
                        firstRun = !firstRun;
                        break;
                    }

                }

            }
            else
            {
                while (true)
                {
                    randomValue = random.Next(0, 8);

                    if (mapArray[randomValue] == blankPattern)
                    {
                        SetPattern(randomValue + 1, computerPattern, boolValue, out playerTurn);
                        break;
                    }
                    
                }
            }
        }

        public void CheckBingo(out bool runWhile)
        {
            runWhile = true;

            int count = 0;

            int[,] bingoArray = new int[8, 3] {
            {0,1,2}, {3,4,5}, {6,7,8}, {0,3,6}, {1,4,7}, {2,5,8}, {0,4,8}, {2,4,6}
            };

            for (int i = 0; i < 8; i++)
            {
                count = 0;

                for (int j = 0; j < 3; j++)
                {
                    if ((mapArray[bingoArray[i,j]] != blankPattern) && (mapArray[bingoArray[i, j]] != computerPattern))
                    {
                        count++;
                    }
                    else if ((mapArray[bingoArray[i, j]] != blankPattern) && (mapArray[bingoArray[i, j]] != playerPattern))
                    {
                        count--;
                    }

                    switch (count)
                    {
                        case 3:
                            runWhile = false;
                            Victiory();
                            break;

                        case -3:
                            runWhile = false;
                            Defeat();
                            break;
                    }

                }

            }

        }

        public void Victiory()
        {
            Console.Clear();
            Console.WriteLine("당신은 승리하였습니다!!!");
            Task.Delay(1000000000).Wait();
        }

        public void Defeat()
        {
            Console.Clear();
            Console.WriteLine("당신은 패배하였습니다!!!");
            Task.Delay(1000000000).Wait();
        }

        public void Initialize(string playerPattern, string computerPattern, string blankPattern)
        {
            this.playerPattern = playerPattern;
            this.computerPattern = computerPattern;
            this.blankPattern = blankPattern;
        }

        public void Start()
        {
            CreateMap();

            bool runWhile = true;
            bool playerTurn = true;

            while (runWhile)
            {
                Console.Clear();
                PrintMap();

                if (playerTurn)
                {
                    int inputValue = InputKey();

                    if (inputValue == 0)
                    {
                        Console.WriteLine("올바르지 않은 키 입력입니다.");
                        Task.Delay(1000).Wait();
                        continue;
                    }

                    SetPattern(inputValue, playerPattern, playerTurn, out playerTurn);
                }
                else
                {
                    ComputerAI(playerTurn, out playerTurn);
                }

                CheckBingo(out runWhile);
                Task.Delay(100).Wait();
            }

        }

    }
}
