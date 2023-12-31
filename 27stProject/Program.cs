﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27stProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 안내 문구
            Console.WriteLine("로딩중...");

            // 커서 숨기기
            Console.CursorVisible = false;

            // 콘솔 창 크기 설정
            Console.SetWindowSize(50,55);

            // 버퍼 사이즈 설정
            Console.SetBufferSize(50,55);

            // 플레이어 위치 설정
            Manager.CP.Set_Move(5,5);

            // 벽 생성
            Manager.Set_Create_Wall(30);

            // 게임 실행
            while (true)
            {
                // 커서 위치 설정
                Console.SetCursorPosition(0, 0);

                // 몬스터 생성
                if (Manager.CP.Point % 10 == 0)
                {
                    Manager.Set_Create_Monster();
                }
                // 게임 출력
                Manager.Get_CheckDefeat();
                Manager.CM.Set_CreateMap();
                Manager.CM.Get_PrintMap();
                Manager.CP.Get_PrintPoint();
                Manager.CK.Get_Input();
                Manager.CP.Set_AddPoint();
                Manager.CEA.Set_Move();

                // 대기
                System.Threading.Thread.Sleep(16);
            }
            // 게임 실행

        }

    }

}
