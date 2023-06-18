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
            // 플레이어 설정
            DB.Game.Set_Player(DB.Player);

            // 커서 숨기기
            Console.CursorVisible = false;

            // 콘솔 창 크기 설정
            Console.SetWindowSize(80, 40);

            // 버퍼 사이즈 설정
            Console.SetBufferSize(80, 40);

            // 게임 사이즈 설정
            DB.Game.Set_Size(30);

            // 플레이어 위치 이동
            DB.Player.Set_Move(10, 10);

            // 플레이어 스텟 설정
            DB.Player.Set_Stats(50,50,5,3,100);

            while (true)
            {

                // 콘솔 창에 버퍼 내용을 표시
                Console.SetCursorPosition(0, 0);

                // 게임
                DB.Game.Set_CreateMap();
                DB.Game.Get_PrintMap();
                DB.Game.Get_HandleInput();
                DB.Game.Get_CheckEvent();
                // 게임

                // 20fps 설정
                System.Threading.Thread.Sleep(16 * 3);
            }
        }

    }

}
