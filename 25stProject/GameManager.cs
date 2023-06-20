using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#region 게임 설명 주석
// 콘솔 맵에서 매 턴 랜덤한 곳에 숫자 1이 등장한다.
// 방향키 중 오른쪽 키(혹은 D)를 입력하면 맵에 존재하는
// 모든 1이 오른쪽 끝으로 이동한다. 
// 만약, 오른쪽 끝에 이미 1이 있는 경우 1이 더해진다.
// 턴이라는 것은 1회의 입력을 말한다.
// 2 방향만 구현할 것.
// 맵에 매 턴 1이 랜덤한 1 곳에 생성된다. (Easy)
// 맵에 매 턴 1이 랜덤한 3 곳에 생성된다. (Normal)
// 가장 우측 열과 가장 아래쪽 행의 숫자는 이동하지 않는다.(Hard)
// -> 오른쪽, 아래로 입력 가능.
#endregion
namespace _25stProject
{
    #region 게임을 관리하는 클래스
    #endregion
    public class GameManager
    {
        #region 변수와 배열, 리스트 선언
        [DllImport("msvcrt.dll")]
        static extern char _getch();
        public int Size { get; private set; } = default;
        public string[,] Map { get; private set; } = default;
        public Player MyPlayer { get; private set; } = default;
        #endregion

        #region 생성자 함수
        #endregion
        public GameManager(int size)
        {
            Start(size);
        }

        #region 초기화 함수
        #endregion
        public void Start(int size_)
        {
            Size = size_;
            Map = new string[Size, Size];
            MyPlayer = new Player(2,2);

            // 커서 숨기기
            Console.CursorVisible = false;

            // 콘솔 창 크기 설정
            Console.SetWindowSize(80, 40);

            // 버퍼 사이즈 설정
            Console.SetBufferSize(80, 40);

            // 포탈 생성
            Set_CreatePortal();

            while (true)
            {
                // 커서 위치 설정
                Console.SetCursorPosition(0, 0);

                // 실행
                Console.Clear();
                Set_CreateMap();
                Get_PrintMap();
                Get_HandleInput();
                Get_CheckPortal();
                // 실행

                // 60fps 설정
                System.Threading.Thread.Sleep(16);
            }

        }


        #region 화면에 맵을 출력하는 함수
        #endregion
        public void Get_PrintMap()
        {
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    Console.Write("{0}", Map[y, x]);
                }

                Console.WriteLine();
            }

        }

        #region 사용자의 키 입력을 받는 함수(왼쪽: a / 오른쪽: d)
        #endregion
        public void Get_HandleInput()
        {
            char inputValue = _getch();

            switch (inputValue)
            {
                case 'w': case 'W':
                    Set_MoveOnesUp();
                    break;
                case 'a': case 'A':
                    Set_MoveOnesLeft();
                    break;

                case 's': case 'S':
                    Set_MoveOnesDown();
                    break;

                case 'd': case 'D':
                    Set_MoveOnesRight();
                    break;
            }

        }

        #region 포탈 접촉 여부 체크 함수
        #endregion
        public void Get_CheckPortal()
        {
            int x = MyPlayer.Dir_X;
            int y = MyPlayer.Dir_Y;

            if ((x == Portal.dir_X) && (Portal.dir_Y == y))
            {
                Set_CreatePortal();
                MyPlayer.Set_Move(Portal.dir_X, Portal.dir_Y);
                Console.Clear();
                Console.WriteLine("로딩중...");
                Task.Delay(1000).Wait();
            }
        }

        #region 플레이어를 위쪽으로 이동시키는 함수
        #endregion
        public void Set_MoveOnesUp()
        {
            int y = MyPlayer.Dir_Y;
            MyPlayer.Set_Dir_Y(y == 0 ? y : y - 1);
        }

        #region 플레이어를 아래쪽으로 이동시키는 함수
        #endregion
        public void Set_MoveOnesDown()
        {
            int y = MyPlayer.Dir_Y;
            MyPlayer.Set_Dir_Y(y == Size - 1 ? y : y + 1);
        }

        #region 플레이어를 왼쪽으로 이동시키는 함수
        #endregion
        public void Set_MoveOnesLeft()
        {
            int x = MyPlayer.Dir_X;
            MyPlayer.Set_Dir_X(x == 0 ? x : x - 1);
        }

        #region 플레이어를 오른쪽으로 이동시키는 함수
        #endregion
        public void Set_MoveOnesRight()
        {
            int x = MyPlayer.Dir_X;
            MyPlayer.Set_Dir_X(x == Size - 1 ? x : x + 1);
        }

        #region 포탈 설정 함수
        #endregion
        public void Set_CreatePortal()
        {
            Random random = new Random();
            Portal.dir_X= random.Next(0, Size);
            System.Threading.Thread.Sleep(16);
            Portal.dir_Y= random.Next(0, Size);
        }

        #region 맵을 생성하는 함수
        #endregion
        public void Set_CreateMap()
        {
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    Map[y, x] = "　";

                    if ((x == Portal.dir_X) && (Portal.dir_Y) == y)
                    {
                        Map[y, x] = "＠";
                    }

                    if ((x == MyPlayer.Dir_X) && (MyPlayer.Dir_Y) == y)
                    {
                        Map[y, x] = "★";
                    }

                }

            }

        }

    }

}
