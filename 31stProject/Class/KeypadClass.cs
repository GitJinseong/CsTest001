using _31stProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _31stProject
{
    public class KeypadClass
    {
        #region 선언부
        [DllImport("msvcrt.dll")]
        static extern char _getch();
        public Map_Manager MM { get; private set; } = default;
        #endregion

        // 링크 연결
        public void Get_Link(Map_Manager manager)
        {
            MM = manager;
        }

        // 입력
        public void Get_Input()
        {
            Set_Move(_getch());
        }

        // 플레이어 이동
        public void Set_Move(char inputChar)
        {
            int x = Center_Manager.PC.Dir_X;
            int y = Center_Manager.PC.Dir_Y;
            int max_X = MM.List[0].MapSize_X;
            int max_Y = MM.List[0].MapSize_Y;

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
