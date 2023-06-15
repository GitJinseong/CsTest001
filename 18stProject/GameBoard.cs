using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
// 플레이어로부터 사이즈를 입력 받아서 해당 사이즈 크기만큼 콘솔 맵을 구현한다.
// 플레이어는 w, a, s, d 등 방향을 입력 받아서 콘솔 맵 안을 자유롭게 움직일 수 있다.
// 콘솔 맵에는 일정 시간 or 일정 움직임 마다 돌 3개가 등장한다.(한 맵에 돌은 최대 3개 까지)
// [조건] 
// 1. 플레이어는 돌을 밀 수 있다. 
// 2. 한번 민 돌은 해당 방향으로 끝까지 쭉 밀린다(한 번에 밀리거나 or 한 칸씩 움직인다).
// 3. 어떤 방향으로든 돌이 연속으로 3개가 붙어 있을 경우 돌은 사라지고, 점수가 올라간다.
// 4. 플레이어가 일정 점수를 획득하면 게임을 종료한다.
// 5. R 키를 눌러서 게임을 초기화 한다.
namespace _18stProject
{
    public class GameBoard
    {

        public int boardSize { get; private set; }
        public string[,] board { get; private set; }
        public int stoneCount { get; private set; }
        public int point { get; private set; }

        List<Stone> myStoneList = new List<Stone>();
        Player myPlayer;
        GameController myController;

        private void Get_Victory()
        {
            Console.Clear();
            Console.WriteLine("당신은 승리하였습니다!");
            Task.Delay(1000000000).Wait();
        }

        private void CheckThreeRocks()
        {
            int count = 0;

            // 타입이 2개
            for (int i = 0; i < myStoneList.Count; i++)
            {
                int x = myStoneList[i].dir_X;
                int y = myStoneList[i].dir_Y;

                for (int j = 0; j < myStoneList.Count; j++)
                {
                    //세로가 3일 경우
                    if ((y == myStoneList[j].dir_Y + 1 && x == myStoneList[j].dir_X)
                        ||
                        (y == myStoneList[j].dir_Y - 1 && x == myStoneList[j].dir_X))
                    {
                        count++;
                    }

                }

                for (int j = 0; j < myStoneList.Count; j++)
                {
                    //가로가 3일 경우
                    if ((x == myStoneList[j].dir_X + 1 && y == myStoneList[j].dir_Y)
                        ||
                        (x == myStoneList[j].dir_X - 1 && y == myStoneList[j].dir_Y))
                    {
                        count++;
                    }

                }

            }

            if (count >= 3)
            {
                Get_Victory();
            }

        }

        private void RockMove(char value, int index)
        {
            int x = myStoneList[index].dir_X;
            int y = myStoneList[index].dir_Y;

            switch (value)
            {
                case 'w': case 'W':
                    if (CheckRockMove(value, x, y) == false)
                    {
                        return;
                    }
                    myStoneList[index].Set_dir_Y(y == 0 ? y : y - 1);
                    break;

                case 'a': case 'A':
                    if (CheckRockMove(value, x, y) == false)
                    {
                        return;
                    }
                    myStoneList[index].Set_dir_X(x == 0 ? x : x - 1);
                    break;

                case 's': case 'S':
                    if (CheckRockMove(value, x, y) == false)
                    {
                        return;
                    }
                    myStoneList[index].Set_dir_Y(y == boardSize - 1 ? y : y + 1);
                    break;

                case 'd': case 'D':
                    if (CheckRockMove(value, x, y) == false)
                    {
                        return;
                    }
                    myStoneList[index].Set_dir_X(x == boardSize - 1 ? x : x + 1);
                    break;
            }

        }

        private bool CheckRockMove(char value, int x, int y)
        {
            switch (value)
            {
                case 'w': case 'W':
                    for (int i = 0; i < myStoneList.Count; i++)
                    {
                        if ((y == myStoneList[i].dir_Y + 1) && (myStoneList[i].dir_X == x))
                        {
                            return false;
                        }
                    }
                    break;

                case 'a': case 'A':
                    for (int i = 0; i < myStoneList.Count; i++)
                    {
                        if ((x == myStoneList[i].dir_X + 1) && (myStoneList[i].dir_Y == y))
                        {
                            return false;
                        }
                    }
                    break;

                case 's': case 'S':
                    for (int i = 0; i < myStoneList.Count; i++)
                    {
                        if ((y == myStoneList[i].dir_Y - 1) && (myStoneList[i].dir_X == x))
                        {
                            return false;
                        }
                    }
                    break;

                case 'd': case 'D':
                    for (int i = 0; i < myStoneList.Count; i++)
                    {
                        if ((x == myStoneList[i].dir_X - 1) && (myStoneList[i].dir_Y == y))
                        {
                            return false;
                        }
                    }

                    break;
                }

            return true;
        }

        private bool CheckPlayerMove(char value, int x, int y)
        {
            switch (value)
            {
                case 'w': case 'W':
                    for (int i = 0; i < myStoneList.Count; i++)
                    {
                        if ((y == myStoneList[i].dir_Y + 1) && (myStoneList[i].dir_X == x))
                        {
                            RockMove(value, i);
                            return false;
                        }
                    }
                    break;

                case 'a': case 'A':
                    for (int i = 0; i < myStoneList.Count; i++)
                    {
                        if ((x == myStoneList[i].dir_X + 1) && (myStoneList[i].dir_Y == y))
                        {
                            RockMove(value, i);
                            return false;
                        }
                    }
                    break;

                case 's': case 'S':
                    for (int i = 0; i < myStoneList.Count; i++)
                    {
                        if ((y == myStoneList[i].dir_Y - 1) && (myStoneList[i].dir_X == x))
                        {
                            RockMove(value, i);
                            return false;
                        }
                    }
                    break;

                case 'd': case 'D':
                    for (int i = 0; i < myStoneList.Count; i++)
                    {
                        if ((x == myStoneList[i].dir_X - 1) && (myStoneList[i].dir_Y == y))
                        {
                            RockMove(value, i);
                            return false;
                        }
                    }
                    break;

            }

            return true;
        }

        private void ResetGame()
        {
            myStoneList = new List<Stone>();
            board = new string[boardSize, boardSize];
            myPlayer = new Player(boardSize/2, boardSize/2);
            myController = new GameController();
            boardSize = boardSize;
            stoneCount = 3;
            point = 0;

            for (int i = 0; i < stoneCount; i++)
            {
                Stone myStone = new Stone(boardSize-i);
                myStoneList.Add(myStone);
            }

        }

        private void HandleDirectionKey(char value)
        {
            int x = myPlayer.dir_X;
            int y = myPlayer.dir_Y;

            switch (value)
            {
                case 'w': case 'W':
                    if (CheckPlayerMove(value, x, y) == false)
                    {
                        return;
                    }
                    myPlayer.Set_dir_Y(y == 0 ? y : y - 1);
                    break;

                case 'a': case 'A':
                    if (CheckPlayerMove(value, x, y) == false)
                    {
                        return;
                    }
                    myPlayer.Set_dir_X(x == 0 ? x : x - 1);
                    break;

                case 's': case 'S':
                    if (CheckPlayerMove(value, x, y) == false)
                    {
                        return;
                    }
                    myPlayer.Set_dir_Y(y == boardSize - 1 ? y : y + 1);
                    break;

                case 'd': case 'D':
                    if (CheckPlayerMove(value, x, y) == false)
                    {
                        return;
                    }
                    myPlayer.Set_dir_X(x == boardSize - 1 ? x : x + 1);
                    break;

                case 'r': case 'R':
                    ResetGame();
                    break;
            }

        }

        private void Get_Map()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Console.Write("{0}", board[i, j]);
                }

                Console.WriteLine();
            }

        }

        private void Set_Map()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j< boardSize; j++)
                {
                    board[i, j] = "□";

                    if ((i == myPlayer.dir_Y) && (myPlayer.dir_X == j))
                    {
                        board[i, j] = "★";

                        continue;
                    }

                    for (int k = 0; k < stoneCount; k++)
                    {
                        if ((i == myStoneList[k].dir_Y) && (myStoneList[k].dir_X == j))
                        {
                            board[i, j] = "●";
                        }
                    }

                }

            }

        }

        public GameBoard(int size)
        {
            board = new string[size, size];
            myPlayer = new Player(size/2, size/2);
            myController = new GameController();
            boardSize = size;
            stoneCount = 3;

            for (int i = 0; i < stoneCount; i++)
            {
                Stone myStone = new Stone(size-i);
                myStoneList.Add(myStone);
            }

            Start();
        }

        private void Start()
        {
            while (true)
            {
                Console.Clear();
                Set_Map();
                Get_Map();
                HandleDirectionKey(myController.Get_Key());
                CheckThreeRocks();
            }

        }

    }

}
