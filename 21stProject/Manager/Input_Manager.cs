using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _21stProject.Manager
{
    public class Input_Manager
    {
        #region 초기 선언부
        [DllImport("msvcrt.dll")]
        static extern char _getch();
        #endregion

        public char _GetCh()
        {
            return _getch();
        }

        public int _GetInt()
        {
            int num = 0;
            int.TryParse(_getch().ToString(), out num);

            return num;
        }

    }
}
