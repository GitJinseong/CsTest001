using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _27stProject
{
    public class Class_Keypad
    {
        #region 선언부
        [DllImport("msvcrt.dll")]
        static extern char _getch();
        public char inputChar { get; private set; } = default;
        #endregion

        // 입력
        public void Get_Input()
        {
            this.inputChar = _getch();

            Set_Move(inputChar);
        }

        // 이동
        public void Set_Move(char inputChar)
        {
            int x = Manager.CP.Dir_X;
            int y = Manager.CP.Dir_Y;
            int max_X = Manager.CM.MapSize_X;
            int max_Y = Manager.CM.MapSize_Y;

            switch (inputChar)
            {
            case 'w': case 'W':
                if (!Get_CheckWall(x, y - 1))
                {
                    Manager.CP.Set_Dir_Y(y == 0 ? y : y - 1);
                }
                break;

            case 'a': case 'A':
                if (!Get_CheckWall(x - 1, y))
                {
                    Manager.CP.Set_Dir_X(x == 0 ? x : x - 1);
                }
                break;

            case 's': case 'S':
                if (!Get_CheckWall(x, y + 1))
                {
                    Manager.CP.Set_Dir_Y(y == max_Y - 1 ? y : y + 1);
                }
                break;

            case 'd': case 'D':
                if (!Get_CheckWall(x + 1, y))
                {
                    Manager.CP.Set_Dir_X(x == max_X - 1 ? x : x + 1);
                }
                break;

            default:
                break;
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
