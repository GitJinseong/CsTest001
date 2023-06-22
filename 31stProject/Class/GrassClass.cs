using _31stProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31stProject
{
    public class GrassClass
    {
        #region 선언부
        public int Dir_X { get; private set; } = default;
        public int Dir_Y { get; private set; } = default;
        #endregion

        // 생성자
        public GrassClass(int x, int y)
        {
            Dir_X = x;
            Dir_Y = y;
        }

    }

}
