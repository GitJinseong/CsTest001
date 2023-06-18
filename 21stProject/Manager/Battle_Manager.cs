using _21stProject.ChildClass;
using _21stProject.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21stProject
{
    public class Battle_Manager
    {
        public void Get_Start(Player player, Monster monster)
        {
            Console.Clear();
            monster.Respawn();
     
            while (true)
            {
                monster.Get_Attack(player);
                monster.Get_TakeDamage(player);

                Console.Clear();
                Console.WriteLine("전투를 합니다.\n");

                Console.WriteLine("[{0}]", monster.Name);
                Console.WriteLine("체력: {0}  공격력: {1}  방어력: {2}", monster.HP, monster.Atk, monster.Def);
                
                Console.WriteLine("\n[플레이어]");
                Console.WriteLine("체력: {0}  공격력: {1}  방어력: {2}", player.HP, player.Atk, player.Def);

                if (!player.Get_IsAlive())
                {
                    Console.WriteLine("\n당신은 패배하였습니다.");
                    Console.WriteLine("\n치료비 -10억 추가");

                    player.Set_Golds(player.Golds - 1_000_000_000);
                    DB.Input._GetCh();
                    break;
                }

                if (!monster.Get_IsAlive())
                {
                    Console.WriteLine("\n당신은 승리하였습니다.");

                    DB.Input._GetCh();
                    break;
                }

                System.Threading.Thread.Sleep(166);
            }

        }

    }

}
