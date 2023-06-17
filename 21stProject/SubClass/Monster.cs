using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _21stProject
{
    #region 몬스터 부모 클래스
    #endregion
    public class Monster
    {
        #region 변수 선언부
        public int Monster_HP { get; private set; } = default;
        public int Monster_MaxHP { get; private set; } = default;
        public int Monster_Atk { get; private set; } = default;
        public int Monster_Def { get; private set; } = default;
        public int Monster_GiveGolds { get; private set; } = default;
        #endregion

        #region 생성자 함수
        #endregion
        public Monster(int hp, int maxHp, int atk, int def, int golds)
        {
            Monster_HP = hp;
            Monster_MaxHP = maxHp;
            Monster_Atk = atk;
            Monster_Def = def;
            Monster_GiveGolds = golds;
        }

        #region 사망 확인 함수
        #endregion
        public bool Get_IsAlive()
        {
            if (Monster_HP <= 0)
            {
                return true;
            }

            return false;
        }

        #region 체력 호출 함수
        #endregion
        public int Get_HP()
        {
            return Monster_HP;
        }

        #region 최대 체력 호출 함수
        #endregion
        public int Get_MaxHP()
        {
            return Monster_MaxHP;
        }

        #region 공격력 호출 함수
        #endregion
        public int Get_Atk()
        {
            return Monster_Atk;
        }

        #region 방어력 호출 함수
        #endregion
        public int Get_Def()
        {
            return Monster_Def;
        }

        #region 지급 골드 호출 함수
        #endregion
        public int Get_GiveGolds()
        {
            return Monster_GiveGolds;
        }


    }

}
