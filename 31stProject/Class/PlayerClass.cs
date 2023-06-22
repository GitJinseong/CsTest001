using _31stProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31stProject
{
    public class PlayerClass : IActions
    {
        #region 선언부
        public int Hp { get; set; } = default;
        public int MaxHP { get; set; } = default;
        public int Atk { get; set; } = default;
        public int Def { get; set; } = default;
        public int Dir_X { get; set; } = default;
        public int Dir_Y { get; set; } = default;

        public Dictionary<string, int> EnemyKill_Dictionary = new Dictionary<string, int>();
        public Dictionary<string, QuestClass> Quest_Dictionary = new Dictionary<string, QuestClass>();
        #endregion

        // 생성자
        public PlayerClass()
        {
            Hp = 450;
            MaxHP = 450;
            Atk = 20;
            Def = 10;
        }

        // 부활
        public void Set_Rebirth()
        {
            Hp = MaxHP;
        }

        // 퀘스트 추가
        public void Set_AddQuest(string name, int type, int count)
        {
            QuestClass quest = new QuestClass(name, type, count);
            Quest_Dictionary.Add(name, quest);
        }

        // 적 처치 로그 추가
        public void Set_EnemyKill_Dictionary(string name)
        {
            foreach (KeyValuePair<string, int> index in EnemyKill_Dictionary)
            {
                if (index.Key == name)
                {
                    int temp = EnemyKill_Dictionary[index.Key];
                    EnemyKill_Dictionary[index.Key] = temp + 1;
                    Console.WriteLine("잡은 몬스터: {0}, 마릿수: {1}", name, temp + 1);
                    return;
                }
            }
 
            EnemyKill_Dictionary.Add(name, 1);
            Console.WriteLine("잡은 몬스터: {0}, 마릿수: {1}", name, EnemyKill_Dictionary[name]);
        }

        // 데미지
        public void Get_Damage(PlayerClass player, EnemyClass enemy)
        {
            int damage = player.Atk < enemy.Def ? 1 : player.Atk - enemy.Def;
            enemy.Hp -= damage;
        }

        // 상태 출력
        public void Get_PrintStats()
        {
            Console.WriteLine("플레이어의 체력: {0} / {1}", Hp, MaxHP);
            Console.WriteLine("플레이어의 공격력: {0}", Atk);
            Console.WriteLine("플레이어의 방어력: {0}\n", Def);
        }

        // 사망 확인
        public bool Get_IsDead()
        {
            if (Hp < 0)
            {
                return true;
            }

            return false;
        }

        // 플레이어 이동
        public void Set_Move(int x, int y)
        {
            Dir_X = x;
            Dir_Y = y;
        }

        // X 좌표 변경
        public void Set_Dir_X(int x)
        {
            Dir_X = x;
        }

        // Y 좌표 변경
        public void Set_Dir_Y(int y)
        {
            Dir_Y = y;
        }

    }

}

