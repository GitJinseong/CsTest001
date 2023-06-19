using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// A J Q K 
// 1 11 12 13
// 0은 모든무늬
// 1 클로버 2 하트 3 다이아몬드 4 스페이드
namespace _24stProject
{
    public static class Jokbo
    {
        const int JOKBO_COUNT = 10;
        const int PATTERNS_COUNT = 4;
        static int[] Card_Patterns = default;
        static int[] Card_Numbers = default;
        static string[] Convert_Patterns = new string[4] {"♣", "♥", "◆", "♠"};
        static string[] Convert_Numbers = new string[13] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        static string[] Cards = default;
        public static void Get_Card_Numbers(params int[] numbers)
        {
            Card_Numbers = numbers;
        }

        public static void Get_Card_Patterns(params int[] patterns)
        {
            Card_Patterns = patterns;
        }

        public static void Set_ConvertCards()
        {
            Cards = new string[Card_Numbers.Count()];
            for (int i = 0; i < Card_Numbers.Count(); i++)
            {
                int p = Card_Patterns[i];
                int n = Card_Numbers[i] - 1;
                Cards[i] = Convert_Patterns[p] + Convert_Numbers[n];
                Console.Write(Cards[i] + " ");
            }

        }

        // 1. 로얄 스트레이트 플러시
        // 같은 문양의 A, 10, J, Q, K
        public static bool Royal_Straight_Flush()
        {
            string[] jokbo_Array = new string[5] { "10", "J", "Q", "K", "A" };

            for (int i = 0; i < PATTERNS_COUNT; i++)
            {
                int count = 0;
                for (int j = 0; j < Cards.Count(); j++)
                {
                    for (int k = 0; k < jokbo_Array.Count(); k++)
                    {
                        if (Cards[j] == Convert_Patterns[i] + jokbo_Array[k])
                        {
                            count++;
                        }
                    }
                }

                if (count == 5)
                {
                    Console.WriteLine("로얄 스트레이트 플러시!");
                    return true;
                }
            }

            return false;
        }

        // 2. 스트레이트 플러시
        // 같은 문양의 이어지는 숫자.
        public static bool Straight_Flush()
        {
            int minValue = Card_Numbers.Min();
            int maxCount = minValue + Card_Numbers.Count();
            for (int i = 0; i < PATTERNS_COUNT; i++)
            {
                int count = 0;
                for (int j = 0; j < Card_Numbers.Count(); j++)
                {
                    for (int k = minValue; k < maxCount; k++)
                    {
                        if (k == Card_Numbers[j] && Card_Patterns[j] == i)
                        {
                            count++;
                        }
                    }
                }

                if (count == 5)
                {
                    Console.WriteLine("스트레이트 플러시!");
                    return true;
                }
            }

            return false;
        }

        // 3. 포카드
        // 같은 숫자의 카드 4장
        public static bool Four_Of_A_Kind()
        {
            int minValue = Card_Numbers.Min();
            int maxCount = Card_Numbers.Max() + 1;
            for (int i = minValue; i < maxCount; i++)
            {
                int count = 0;
                for (int j = 0; j < Card_Numbers.Count(); j++)
                {
                    if (Card_Numbers[j] == i)
                    {
                        count++;
                    }

                }

                if (count == 4)
                {
                    Console.WriteLine("포카드!");
                    return true;
                }
            }

            return false;
        }

        // 4. 풀하우스
        // 같은 숫자의 카드 3장과, 다른 같은 숫자의 카드 2장
        public static bool Full_House()
        {
            int minValue = Card_Numbers.Min();
            int maxCount = Card_Numbers.Max() + 1;
            int count = 0;
            bool countSub = true;
            for (int i = minValue; i < maxCount - 1; i++)
            {
                if (!(count >= 2))
                {
                    count = 0;
                }
                else
                {
                    countSub = false;
                }

                int count2 = 0;
                for (int j = 0; j < Card_Numbers.Count(); j++)
                {
                    if (Card_Numbers[j] == i && countSub == true)
                    {
                        count++;
                    }
                    
                    if (Card_Numbers[j] == (i + 1))
                    {
                        count2++;
                    }
                }

                if ((3 <= count && count2 >= 2) || (2 <= count && count2 >= 3))
                {
                    Console.WriteLine("풀하우스!");
                    return true;
                }
            }

            return false;
        }

        // 5. 플러시
        // 같은 문양의 카드 5장
        public static bool Flush()
        {
            for (int i = 0; i < PATTERNS_COUNT; i++)
            {
                int count = 0;
                for (int j = 0; j < Card_Numbers.Count(); j++)
                {
                    if (Card_Patterns[j] == i)
                    {
                        count++;
                    }
                }

                if (count >= 5)
                {
                    Console.WriteLine("플러시!");
                    return true;
                }
            }

            return false;
        }

        // 6. 스트레이트
        // 다른 문양의 연속된 숫자
        public static bool Straight()
        {
            // 중복 숫자 제거
            int[] temp = new int[Card_Numbers.Count()];
            for (int i = 0; i < Card_Numbers.Count(); i++)
            {
                for (int j = 0; j < Card_Numbers.Count(); j++)
                {
                    if (!(temp[i] == Card_Numbers[j]))
                    {
                        temp[i] = Card_Numbers[j];
                        
                    }
                }
            }

            // 역순 오류 발생
            int minValue = Card_Numbers.Min();
            int maxValue = Card_Numbers.Max();
            int count = 0;
            for (int i = 0; i < temp.Count(); i++)
            {
                for (int j = minValue; j < minValue + temp.Count(); j++)
                {
                    int k = 1;
                    if (j == temp[i])
                    {
                        count++;
                        continue;
                    }

                    if ((maxValue - k) == temp[i])
                    {
                        count++;
                    }

                    k++;
                }
            }

            if (count >= 5)
            {
                Console.WriteLine("스트레이트!");
                return true;
            }

            return false;
        }

        // 7. 트리플
        // 같은 숫자의 카드 3장
        public static bool Three_Of_A_Kind()
        {
            return false;
        }

        // 8. 투 페어
        // 같은 숫자의 카드 2장의 두 쌍
        public static bool Two_Pair()
        {
            return false;
        }

        // 9. 원 페어
        // 같은 숫자의 카드 2장
        public static bool One_Pair()
        {
            return false;
        }

        // 10. 탑
        // 아무것도 아닐 경우
        public static bool High_Card()
        {
            Console.WriteLine("탑!");
            return true;
        }

    }

}
