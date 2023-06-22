using _31stProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _31stProject
{
    public class BattleClass
    {
        public MapClass Map { get; private set; } = default;
        public Enemy_Manager EM { get; private set; } = default;

        public void Get_Link_Map(MapClass myClass)
        {
            Map = myClass;
        }

        public void Get_Link_EM(Enemy_Manager manager)
        {
            EM = manager;
        }

        public void Get_StartBattle(bool boolValue)
        {
            if (!boolValue)
            {
                return;
            }

            PlayerClass player = Center_Manager.PC;
            EnemyClass enemy = EM.List[Center_Manager.random.Next(0, EM.List.Count - 1)];

            // 배틀 실행
            while (true)
            {
                // 출력
                Console.Clear();
                Console.WriteLine("[배틀 시작!]\n");
                player.Get_PrintStats();
                enemy.Get_PrintStats();

                // 전투
                player.Get_Damage(player, enemy);
                enemy.Get_Damage(player, enemy);

                // 플레이어 사망시
                if (player.Get_IsDead())
                {
                    Console.WriteLine("당신은 패배하였습니다.");
                    Thread.Sleep(1000000000);
                    break;
                }
                // 몬스터 사망시
                else if (enemy.Get_IsDead())
                {
                    Console.WriteLine("당신은 승리하였습니다.");
                    Thread.Sleep(1000);
                    player.Set_Rebirth();
                    enemy.Set_Rebirth();
                    break;
                }

                Thread.Sleep(100);
            }
            // 배틀 실행

        }

    }

}
