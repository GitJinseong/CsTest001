using _31stProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31stProject
{
    public class EnemyClass : IActions
    {
        #region 선언부
        public string Name { get; set; } = default;
        public int Hp { get; set; } = default;
        public int MaxHP { get; set; } = default;
        public int Atk { get; set; } = default;
        public int Def { get; set; } = default;

        #endregion

        // 부활
        public void Set_Rebirth()
        {
            Hp = MaxHP;
        }

        public void Get_EnemyCallback(string name)
        {
            Center_Manager.PC.Set_EnemyKill_Dictionary(name);
        }

        // 데미지
        public void Get_Damage(PlayerClass player, EnemyClass enemy)
        {
            int damage = enemy.Atk < player.Def ? 1 : enemy.Atk - player.Def;
            player.Hp -= damage;
        }

        // 상태 출력
        public void Get_PrintStats()
        {
            Console.WriteLine("{0}의 체력: {1} / {2}", Name, Hp, MaxHP);
            Console.WriteLine("{0}의 공격력: {1}", Name, Atk);
            Console.WriteLine("{0}의 방어력: {1}\n", Name, Def);
        }

        // 사망 확인
        public bool Get_IsDead()
        {
            if (Hp < 0)
            {
                Get_EnemyCallback(Name);
                return true;
            }

            return false;
        }

    }

}
