using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27stProject
{
    // 4방향 중에 이동가능한 타일을 찾고
    // 플레이어와의 xy좌표를 비교한다음 최적의 거리로 이동한다.
    public class Class_MonsterAI
    {
        // 이동
        public void Set_Move(char inputChar)
        {
            int x = Manager.CP.Dir_X;
            int y = Manager.CP.Dir_Y;
            int max_X = Manager.CM.MapSize_X;
            int max_Y = Manager.CM.MapSize_Y;
 
            if (!Get_CheckWall(x, y - 1))
            {
                Manager.CP.Set_Dir_Y(y == 0 ? y : y - 1);
            }        

            if (!Get_CheckWall(x - 1, y))
            {
                Manager.CP.Set_Dir_X(x == 0 ? x : x - 1);
            }
 
            if (!Get_CheckWall(x, y + 1))
            {
                Manager.CP.Set_Dir_Y(y == max_Y - 1 ? y : y + 1);
            }
    
            if (!Get_CheckWall(x + 1, y))
            {
                Manager.CP.Set_Dir_X(x == max_X - 1 ? x : x + 1);
            }
     
            
        }

        // 벽 체크
        public bool Get_CheckWall(int x, int y)
        {
            int size = Manager.CW_List.Count();
            for (int i = 0; i < size; i++)
            {
                if (y == Manager.CW_List[i].Dir_Y && Manager.CW_List[i].Dir_X == x)
                {
                    return true;
                }

            }

            return false;
        }

        // 몬스터 체크
        public bool Get_CheckEnemy()
        {
            int x = Manager.CP.Dir_X;
            int y = Manager.CP.Dir_Y;
            int size = Manager.CE_List.Count();
            for (int i = 0; i < size; i++)
            {
                if (y == Manager.CE_List[i].Dir_Y && Manager.CE_List[i].Dir_X == x)
                {
                    return true;
                }

            }

            return false;
        }
    }
}
