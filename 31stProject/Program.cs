using _31stProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _31stProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 객체 생성
            TileClass tile = new TileClass();
            BattleClass battle = new BattleClass();

            // 매니저 생성
            Map_Manager MM = new Map_Manager();
            Enemy_Manager EM = new Enemy_Manager();

            // 링크 연결
            tile.Get_Link(MM.List[0]);
            battle.Get_Link_Map(MM.List[0]);
            battle.Get_Link_EM(EM);

            // 플레이어 링크 연결
            PlayerClass player = Center_Manager.PC;

            // 커서 숨기기
            Console.CursorVisible = false;

            // 콘솔 창 크기 설정
            Console.SetWindowSize(50, 55);

            // 버퍼 사이즈 설정
            Console.SetBufferSize(50, 55);

            // 수풀 생성
            MM.List[0].Set_CreateGrass(20);

            // 몬스터 생성
            EM.Set_CreateMonsters();

            // 게임 실행
            while (true)
            {
                // 커서 위치 설정
                Console.SetCursorPosition(0, 0);

                // 게임 출력
                MM.List[0].Set_CreateMap();
                MM.List[0].Get_PrintMap();
                Center_Manager.Get_Input(MM.List[0].MapSize_X, MM.List[0].MapSize_Y);
                battle.Get_StartBattle(tile.Get_CheckGrass(player.Dir_X, player.Dir_Y));

                // npc와 접촉할 경우
                if (tile.Get_CheckNPC(player.Dir_X, player.Dir_Y, MM.List[0].NM.npc))
                {
                    MM.List[0].NM.npc.Get_PrintDialogue();
                }
                // 게임 출력

                // 대기
                Thread.Sleep(16);
            }
            // 게임 실행

        }

    }

}
