using _31stProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _31stProject
{
    public static class Center_Manager
    {
        #region 선언부
        [DllImport("msvcrt.dll")]
        static extern char _getch();
        public static PlayerClass PC { get; private set; } = new PlayerClass();

        public static Random random = new Random();
        #endregion

        
        // 입력
        public static char Get_Input()
        {
            return _getch();
        }

        // 입력
        public static void Get_Input(int max_X, int max_Y)
        {
            Set_Move(_getch(), max_X, max_Y);
        }

        // 플레이어 이동
        public static void Set_Move(char inputChar, int max_X, int max_Y)
        {
            int x = Center_Manager.PC.Dir_X;
            int y = Center_Manager.PC.Dir_Y;

            switch (inputChar)
            {
                case 'w': case 'W':
                    Center_Manager.PC.Set_Dir_Y(y == 0 ? y : y - 1);
                    break;

                case 'a': case 'A':
                    Center_Manager.PC.Set_Dir_X(x == 0 ? x : x - 1);
                    break;

                case 's': case 'S':
                    Center_Manager.PC.Set_Dir_Y(y == max_Y - 1 ? y : y + 1);
                    break;

                case 'd': case 'D':
                    Center_Manager.PC.Set_Dir_X(x == max_X - 1 ? x : x + 1);
                    break;

                default:
                    break;
            }

        }

    }

}
