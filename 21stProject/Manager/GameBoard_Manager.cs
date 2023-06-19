using _21stProject.Manager;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#region 게임 설명 주석
// [움직이는 게임 만들기]
// 필요한 기능 : 상점(▣), 몬스터(♬), 카드게임(◎)
// 플레이어가 돌아다니면서 위의 기능을 상징하는
// 문양에 접촉하면 해당 기능을 실행시킨다.
// 문양 설정은 자유롭게.
#endregion
namespace _21stProject
{
    #region 게임을 관리하는 클래스
    #endregion
    public class GameBoard_Manager
    {
        #region 초기 선언부
        const int EVENT_COUNT = 3;
        public Player myPlayer { get; private set; } = default;
        public int Size { get; private set; } = default;
        public string[,] Map { get; private set; } = default;
        public string[] Patterns { get; private set; } = default;
        public int[,] Event { get; private set; } = default;
        #endregion

        #region 생성자 함수
        #endregion
        public GameBoard_Manager(int size_)
        {
            myPlayer = Managers.Player;
            Size = size_;
            Map = new string[Size, Size];
            // [0]: 상점 / [1]: 배틀 / [2]: 카드게임
            Patterns = new string[3] {"＠", "♬", "☎" };
            Event = new int[EVENT_COUNT, 2];

            for (int i = 0; i < EVENT_COUNT; i++)
            {
                Random random = new Random();
                Event[i, 0] = random.Next(5, Size) / (i + 1);
                Event[i, 1] = random.Next(5, Size) / (i + 1);
                System.Threading.Thread.Sleep(16);
            }

        }

        #region 초기화 함수
        #endregion
        public void Set_Size(int size_)
        {
            Size = size_;
            Map = new string[Size, Size];
        }

        #region 플레이어 설정 함수
        #endregion
        public void Set_Player(Player player)
        {
            myPlayer = player;
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

                    if ((x == myPlayer.Dir_X) && (myPlayer.Dir_Y) == y)
                    {
                        Map[y, x] = "★";
                    }

                }

            }

            for (int i = 0; i < EVENT_COUNT; i++)
            {
                int x = Event[i, 0];
                int y = Event[i, 1];
                Map[y, x] = Patterns[i];
            }

        }

        #region 이벤트 접촉 여부 확인 함수
        #endregion
        public void Get_CheckEvent()
        {
            int x = myPlayer.Dir_X;
            int y = myPlayer.Dir_Y;
            for (int i = 0; i < EVENT_COUNT; i++)
            {

                if ((x == Event[i, 0]) && (Event[i, 1]) == y)
                {
                    Get_OpenEvent(i);

                    break;
                }

            }

        }

        public void Get_OpenEvent(int num)
        {
            switch (num)
            {
                case 0:
                    Managers.Shop.Set_CreateItemList();
                    Managers.Shop.Get_OpenShop(myPlayer);
                    break;

                case 1:
                    Random random = new Random();
                    int index = random.Next(0, Managers.Mob.Get_MONSTER_TYPE_COUNT());
                    Managers.Battle.Get_Start(myPlayer, Managers.Mob.Storage[index]);
                    break;

                case 2:
                    Managers.CardGame.Get_Start(myPlayer);
                    break;
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

        #region 사용자의 키 입력을 받는 함수
        #endregion
        public void Get_HandleInput()
        {
            char inputValue = Managers.Input._GetCh();
            int x = myPlayer.Dir_X;
            int y = myPlayer.Dir_Y;

            switch (inputValue)
            {
                case 'w': case 'W':
                    myPlayer.Set_Move(x, y == 0 ? y : y - 1); 
                    break;

                case 'a': case 'A':
                    myPlayer.Set_Move(x == 0 ? x : x - 1, y);
                    break;

                case 's': case 'S':
                    myPlayer.Set_Move(x, y == Size - 1 ? y : y + 1);
                    break;

                case 'd': case 'D':
                    myPlayer.Set_Move(x == Size - 1 ? x : x + 1, y);
                    break;
            }

        }

    }

}
