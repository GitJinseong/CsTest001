using _21stProject.ChildClass;
using _21stProject.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    #region 시작 클래스
    #endregion
    public class Program
    {
        static void Main(string[] args)
        {
            // 커서 숨기기
            Console.CursorVisible = false;

            // 콘솔 창 크기 설정
            Console.SetWindowSize(80, 40);

            // 버퍼 사이즈 설정
            Console.SetBufferSize(80, 40);

            // 플레이어 설정
            Managers.Game.Set_Player(Managers.Player);

            // 게임 사이즈 설정
            Managers.Game.Set_Size(30);

            // 플레이어 위치 이동
            Managers.Player.Set_Move(10, 10);

            // 플레이어 스텟 설정
            Managers.Player.Set_Stats(50,50,5,3,100);

            while (true)
            {
                // 커서 위치 설정
                Console.SetCursorPosition(0, 0);

                // 게임
                Managers.Game.Set_CreateMap();
                Managers.Game.Get_PrintMap();
                Managers.Game.Get_HandleInput();
                Managers.Game.Get_CheckEvent();
                // 게임

                // 120fps 설정
                System.Threading.Thread.Sleep(8);
            }

        }

    }

}
