using _21stProject.ChildClass;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21stProject.Manager
{
    public class Player
    {
        #region 초기 선언부
        public int HP { get; private set; } = default;
        public int MaxHP { get; private set; } = default;
        public int Atk { get; private set; } = default;
        public int Def { get; private set; } = default;
        public int Golds { get; private set; } = default;
        public int Dir_X { get; private set; } = default;
        public int Dir_Y { get; private set; } = default;
        #endregion

        #region 생성자 함수
        #endregion
        public Player(int hp_, int maxHP_, int atk_, int def_, int golds_)
        {
            HP = hp_;
            MaxHP = maxHP_;
            Atk = atk_;
            Def = def_;
            Golds = golds_;
        }

        #region 스텟 설정 함수
        #endregion
        public void Set_Stats(int hp_, int maxHP_, int atk_, int def_, int golds_)
        {
            HP = hp_;
            MaxHP = maxHP_;
            Atk = atk_;
            Def = def_;
            Golds = golds_;
        }

        #region 체력 변경 함수
        #endregion
        public void Set_HP(int hp_)
        {
            HP = hp_;

        }
        #region 골드 변경 함수
        #endregion
        public void Set_Golds(int golds_)
        {
            Golds = golds_;
        }

        #region 이동 함수
        #endregion
        public void Set_Move(int x, int y)
        {
            Dir_X = x;
            Dir_Y = y;
        }

        #region 사망 확인 함수
        #endregion
        public bool Get_IsAlive()
        {
            if (HP <= 0)
            {
                HP = MaxHP;
                return false;
            }

            return true;
        }

    }

}
