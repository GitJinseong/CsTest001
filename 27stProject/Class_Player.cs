using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27stProject
{
    public class Class_Player : IActions
    {
        #region 선언부
        public int Dir_X { get; set; } = default;
        public int Dir_Y { get; set; } = default;
        public int Point { get; set; } = default;

        #endregion

        // 플레이어 점수 증가
        public void Set_AddPoint()
        {
            Point++;

        }

        // 플레이어 이동
        public void Set_Move(int x, int y)
        {
            Dir_X = x;
            Dir_Y = y;
        }

        // X 좌표 변경
        public void Set_Dir_X(int x)
        {
            Dir_X = x;
        }

        // Y 좌표 변경
        public void Set_Dir_Y(int y)
        {
            Dir_Y = y;
        }

        // 플레이어 점수 출력
        public void Get_PrintPoint()
        {
            Console.WriteLine("점수: {0}", Point);
        }
    }

}
