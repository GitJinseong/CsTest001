using _21stProject.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21stProject
{
    public class CardGame_Manager
    {
        public void Get_Start(Player player)
        {
            Console.Clear();
            Console.WriteLine("카드 게임 입니다.");
            Console.WriteLine("게임을 하시려면 10억 골드가 필요합니다.");
            Console.WriteLine("빛 -10억 추가\n");
            player.Set_Golds(player.Golds - 1_000_000_000);

            Random random = new Random();
            int playerCard = random.Next(0, 10);
            System.Threading.Thread.Sleep(16);
            int computerCard = random.Next(0, 10);

            Console.WriteLine("나의 카드: {0}", playerCard);
            Console.WriteLine("상대의 카드: {0}\n", computerCard);

            if (playerCard > computerCard)
            {
                Console.WriteLine("당신은 승리했습니다.");
                Console.WriteLine("상금 100골드 증정!");
                player.Set_Golds(player.Golds + 100);
            }
            else
            {
                Console.WriteLine("당신은 패배했습니다.");

            }

            DB.Input._GetCh();
        }

    }
}
