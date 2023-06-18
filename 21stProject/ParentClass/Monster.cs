using _21stProject.Manager;
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
        public string Name { get; protected set; } = default;
        public int HP { get; protected set; } = default;
        public int MaxHP { get; protected set; } = default;
        public int Atk { get; protected set; } = default;
        public int Def { get; protected set; } = default;
        public int GiveGolds { get; protected set; } = default;
        #endregion

        #region 생성자 함수
        #endregion
        public Monster(string name_, int hp_, int maxHP_, int atk_, int def_, int golds_)
        {
            Name = name_;
            HP = hp_;
            MaxHP = maxHP_;
            Atk = atk_;
            Def = def_;
            GiveGolds = golds_;
        }

        #region 부활 함수
        #endregion
        public void Respawn()
        {
            HP = MaxHP;
        }

        #region 공격 함수
        #endregion
        public void Get_Attack(Player player)
        {
            player.Set_HP(player.HP - (Atk > player.Def ? Atk - player.Def : 1));
        }

        #region 피격 함수
        #endregion
        public void Get_TakeDamage(Player player)
        {
            int damage = player.Atk > Def ? player.Atk - Def : 1;
            HP -= damage;
        }

        #region 사망 확인 함수
        #endregion
        public bool Get_IsAlive()
        {
            if (HP <= 0)
            {
                return false;
            }

            return true;
        }

        #region 체력 호출 함수
        #endregion
        public int Get_HP()
        {
            return HP;
        }

        #region 최대 체력 호출 함수
        #endregion
        public int Get_MaxHP()
        {
            return MaxHP;
        }

        #region 공격력 호출 함수
        #endregion
        public int Get_Atk()
        {
            return Atk;
        }

        #region 방어력 호출 함수
        #endregion
        public int Get_Def()
        {
            return Def;
        }

        #region 지급 골드 호출 함수
        #endregion
        public int Get_GiveGolds()
        {
            return GiveGolds;
        }


    }

}
