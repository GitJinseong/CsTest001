using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27stProject
{
    interface IActions
    {
        void Set_Move(int x, int y);
        void Set_Dir_X(int x);
        void Set_Dir_Y(int y);
    }
}
