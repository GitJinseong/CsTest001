using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _25stProject
{
    #region 넘버 객체를 생성하는 클래스
    #endregion
    public class Player
    {
        #region 변수 선언
        public int Dir_X { get; private set; } = default;
        public int Dir_Y { get; private set; } = default;
        public int Value { get; private set; } = default;
        #endregion

        #region 생성자 함수
        #endregion
        public Player(int x, int y)
        {;
            Dir_X = x;
            Dir_Y = y;
            Value = 2;
        }

        #region 이동 함수
        #endregion
        public void Set_Move(int x, int y)
        {
            Dir_X = x;
            Dir_Y = y;
        }

        #region X 좌표 설정 함수
        #endregion
        public void Set_Dir_X(int x)
        {
            Dir_X = x;
        }

        #region Y 좌표 설정 함수
        #endregion
        public void Set_Dir_Y(int y)
        {
            Dir_Y = y;
        }

        #region 값 설정 함수
        #endregion
        public void Set_Value(int value_)
        {
            Value = value_;
        }

    }

}
