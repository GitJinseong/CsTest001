using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

// [포커 게임 만들기]
// 1. 컴퓨터는 7장을 받고, 플레이어는 5장을 받는다. 플레이어는 카드를 보고 배팅한다.
// 2. 플레이어는 5장 중에 2장을 다른 카드로 교체한다.
// 3. 결과는 포커의 족보로 비교한다.
// 4. 플레이어가 승리한 경우 플레이어는 1번의 게임을 승리하여 배팅 점수의 2배를 얻는다.
// 5. 컴퓨터가 승리한 경우 플레이어는 1번의 게임을 패배하여 배팅 점수를 잃는다.
// 6. 플레이어는 일정 점수를 획득하면 게임을 최종 승리하며, 0점 이하인 경우 게임을 최종 패배한다.
// 이 경우 게임을 종료한다.
namespace _24stProject
{
    public class Program
    {

        static Func<bool>[] Functions = new Func<bool>[]
        {
            Jokbo.Royal_Straight_Flush,
            Jokbo.Straight_Flush,
            Jokbo.Four_Of_A_Kind,
            Jokbo.Full_House,
            Jokbo.Flush,
            Jokbo.Straight,
            Jokbo.Three_Of_A_Kind,
            Jokbo.Two_Pair,
            Jokbo.One_Pair,
            Jokbo.High_Card
        };

        static string[] CardTypes = new string[10] {
            "로얄 스트레이트 플러시!", "스트레이트 플러시!", "포카드!",
            "풀하우스!", "플러시!", "스트레이트!", "트리플!", "투페어!",
            "원페어!", "탑!"
        };

        static int[] ComputerNumbers = default;
        static int[] ComputerPatterns = default;

        static int Get_Jokbo()
        {
            int point = 10;
            // 족보 체크
            for (int i = 0; i < 10; i++)
            {
                point--;
                if (Functions[i]())
                {
                    Console.WriteLine(CardTypes[i]);
                    Console.WriteLine();
                    break;
                }
            }
            return point;
        }

        static void Get_IsWin(int playerPoint, int computerPoint)
        {
            // 승리 체크
            if (playerPoint > computerPoint)
            {
                Console.WriteLine("당신은 승리하였습니다.");
            }
            else if (playerPoint == computerPoint)
            {
                Console.WriteLine("당신은 비겼습니다.");
            }
            else if (playerPoint < computerPoint)
            {
                Console.WriteLine("당신은 패배했습니다.");
            }
        }

        static void Set_PlayerCards()
        {
            Random random = new Random();
            int[] n = new int[7];
            int[] p = new int[7];
            while (true)
            {
                for (int i = 0; i < 7; i++)
                {
                    n[i] = random.Next(1, 13);
                    System.Threading.Thread.Sleep(30);
                    p[i] = random.Next(0, 3);
                    System.Threading.Thread.Sleep(30);
                }
                int count = 0;
                for (int i = 0; i < 6; i++)
                {
                    for (int j = i + 1; j < 7; j++)
                    {
                        if ((n[i] == n[j] && p[i] == p[j]))
                        {
                            count++;
                        }
                     
                    }
                }

                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if ((n[i] == ComputerNumbers[j] && p[i] == ComputerPatterns[j]))
                        {
                            count++;
                        }
                    }
                }

                if (count == 0)
                {
                    break;
                }
            }
         
            Jokbo.Set_Card_Numbers(n[0], n[1], n[2], n[3], n[4]);
            Jokbo.Set_Card_Patterns(p[0], p[1], p[2], p[3], p[4]);
            Jokbo.Set_ToStringCards();
        }
        static void Set_ComputerCards()
        {
            Random random = new Random();
            int[] n = new int[7];
            int[] p = new int[7];
            while (true)
            {
                for (int i = 0; i < 7; i++)
                {
                    n[i] = random.Next(1, 13);
                    System.Threading.Thread.Sleep(30);
                    p[i] = random.Next(0, 3);
                    System.Threading.Thread.Sleep(30);
                }
                int count = 0;
                for (int i = 0; i < 6; i++)
                {
                    for (int j = i + 1; j < 7; j++)
                    {
                        if ((n[i] == n[j] && p[i] == p[j]))
                        {
                            count++;
                        }

                    }
                }
                if (count == 0)
                {
                    break;
                }
            }

            ComputerNumbers = (int[])n.Clone();
            ComputerPatterns = (int[])p.Clone();

            Jokbo.Set_Card_Numbers(1,5,4,3,6,7);
            Jokbo.Set_Card_Patterns(p[0], p[1], p[2], p[3], p[4], p[5], p[6]);
            Jokbo.Set_ToStringCards();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                // 화면 지우기
                Console.Clear();

                // 컴퓨터 카드
                Set_ComputerCards();

                // 족보 체크
                int computerPoint = Get_Jokbo();

                // 플레이어 카드
                Set_PlayerCards();

                // 족보 체크
                int playerPoint = Get_Jokbo();

                // 승리 체크
                Get_IsWin(playerPoint, computerPoint);

                // 입력 대기
                Console.WriteLine("\n다시 시작하려면 아무 키를 눌러주세요.");
                Console.ReadKey();
            }
        }

    }

}
