using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _5stProject
{
    // [개별과제]
    // 오늘 만든 카드 뽑은게임 응용해서 -> 카드뽑기 게임 ver.2 만들기
    // 1. 컴퓨터가 카드를 2장 뽑아서 보여준다.
    // 2. 플레이어는 카드를 보고 배팅한다.
    // 3. 플레이어의 카드가, 컴퓨터의 카드 2장 사이에 존재한다면, 플레이어는 한 번의 게임을 승리하여
    // 배팅 점수의 2배를 얻는다.
    // 4. 플레이어의 카드가 컴퓨터의 카드 2장 사이에 존재하지 않는 경우, 플레이어는 한 번의 게임을 패배하여
    // 배팅 점수만큼 잃는다.
    // 5. 플레이어는 일정 점수를 획득하면 게임을 최종 승리하며, 0점 이하인 경우 게임을 최종 패배한다.
    // 이 경우에 게임을 종료한다.
    public class CardGame
    {
        string[] cardNumbers = new string[13] {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};

        int[] playerCards = new int[1];
        int[] computerCards = new int[2];

        int playerPoints = 100;
        int betPoints = 0;

        public void DrowCards()
        {
            Random random = new Random();

            playerCards[0] = random.Next(0, 12);
            computerCards[0] = random.Next(0, 12);
            computerCards[1] = random.Next(0, 12);

            if (computerCards[0] > computerCards[1])
            {
                int temp;
                temp = computerCards[0];
                computerCards[0] = computerCards[1];
                computerCards[1] = temp;
            }

            PrintCumputerCards();
        }

        public void PrintCumputerCards()
        {
            Console.WriteLine("컴퓨터의 카드 : {0}", cardNumbers[computerCards[0]]);
            Console.WriteLine("컴퓨터의 카드 : {0}\n", cardNumbers[computerCards[1]]);
            Console.WriteLine("배팅하시겠습니까 ? (y / n)");

            bool runWhile = true;

            while (runWhile)
            {
                Console.Write(": ");

                switch (Console.ReadLine())
                {
                    case "y":
                        Console.WriteLine("배팅할 포인트를 입력해 주세요.(최대 {0})", playerPoints);
                        Console.Write(" : ");

                        betPoints = Convert.ToInt32(Console.ReadLine());

                        if (betPoints > 0 && betPoints <= playerPoints)
                        {
                            PrintPlayerCards();
                            runWhile = false;
                        }
                        else
                        {
                            Console.WriteLine("오류발생! 초기 화면으로 이동합니다.");
                            Console.WriteLine("배팅하시겠습니까 ? (y / n)");
                        }

                        break;

                    case "n":
                        Console.WriteLine("\n게임을 종료합니다.");
                        runWhile = false;
                        break;

                    default:
                        Console.WriteLine("올바르지 않은 키입니다. \n다시 입력해 주세요.");
                        Console.WriteLine("배팅하시겠습니까 ? (y / n)");
                        break;
                }

            }

        }

        public void PrintPlayerCards()
        {
            Console.WriteLine("플레이어의 카드 : {0}", cardNumbers[playerCards[0]]);

            CheckNumbers();
        }

        public void CheckNumbers()
        {

            if ((computerCards[0] < playerCards[0]) && (playerCards[0] < computerCards[1]))
            {
                playerPoints += betPoints * 2;

                Console.WriteLine("당신은 승리했습니다.");
                Console.WriteLine("획득한 점수 (+{0})\n", betPoints * 2);
            }
            else
            {
                playerPoints -= betPoints * 2;

                Console.WriteLine("당신은 패배했습니다.");
                Console.WriteLine("잃은 점수 (-{0})\n", betPoints);
            }

            Start();

            betPoints = 0;
        }

        public void CheckPoints()
        {

            if (playerPoints < 10)
            {
                Console.WriteLine("보유 점수가 10점 미만이 되어 당신은 패배했습니다.");
            }
            else if (playerPoints < 1000)
            {
                Console.WriteLine("보유 점수가 1000점을 초과하여 당신은 승리했습니다.");
            }
            else
            {
                DrowCards();
            }

        }

        public void Start()

        {
            CheckPoints();
        }
    }
}
