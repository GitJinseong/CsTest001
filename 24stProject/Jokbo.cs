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

        #region 카드 넘버 값 추가
        #endregion
        public static void Set_Card_Numbers(params int[] numbers)
        {
            Card_Numbers = numbers;
        }

        #region 카드 패턴 값 추가
        #endregion
        public static void Set_Card_Patterns(params int[] patterns)
        {
            Card_Patterns = patterns;
        }

        #region 카드 스트링 변환 함수
        #endregion
        public static void Set_ToStringCards()
        {
            Cards = new string[Card_Numbers.Count()];
            for (int i = 0; i < Card_Numbers.Count(); i++)
            {
                int p = Card_Patterns[i];
                int n = Card_Numbers[i] - 1;
                Cards[i] = Convert_Patterns[p] + Convert_Numbers[n];
                Console.Write(Cards[i] + " ");
            }
            Console.WriteLine();
        }

        #region 1. 로얄 스트레이트 플러시(같은 문양의 {A, 10, J, Q, K})
        #endregion
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
                    return true;
                }
            }

            return false;
        }

        #region 2. 스트레이트 플러시(같은 문양의 이어지는 숫자)
        #endregion
        public static bool Straight_Flush()
        {
            if (Straight() && Flush())
            {
                return true;
            }

            return false;
        }

        #region 3. 포카드(같은 숫자의 카드 4장)
        #endregion
        public static bool Four_Of_A_Kind()
        {
            if (Get_SameNumbers(4, 1))
            {
                return true;
            }

            return false;
        }

        #region 4. 풀하우스(같은 숫자의 카드 3장과, 다른 같은 숫자의 카드 2장)
        #endregion
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
                    return true;
                }
            }

            return false;
        }

        #region 5. 플러시(같은 문양의 카드 5장)
        #endregion
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
                    return true;
                }
            }

            return false;
        }

        #region 6. 스트레이트(다른 문양의 연속된 숫자)
        #endregion
        public static bool Straight()
        {
            int minValue = Card_Numbers.Min();
            int maxValue = Card_Numbers.Max();

            // 중복 숫자 제거
            int[] temp1 = new int[Card_Numbers.Count()];
            int[] temp2 = (int[])Card_Numbers.Clone(); // 배열 복제
            for (int i = 0; i < temp2.Count(); i++)
            {
                temp1[i] = temp2[i];
                for (int j = 0; j < temp1.Count() - 1; j++)
                {
                    if (temp1[i] == temp2[j])
                    {
                        temp2[j] = 0;
                    }
                    if (temp1[j] > temp1[j + 1])
                    {
                        int temp = temp1[j + 1];
                        temp1[j + 1] = temp1[j];
                        temp1[j] = temp;

                        //Console.WriteLine(temp1[i]);
                    }
                }
                Console.WriteLine(temp1[i]);
            }

            for (int i = 0; i < temp1.Count(); i++)
            {
                if (temp1[i] == 0)
                {
                    continue;
                }
                int n = 0;
                int count = 0;
                for (int j = 0; j < temp1.Count(); j++)
                {
                    if (temp1[i] + n == temp1[j])
                    {
                        count++;
                        //Console.WriteLine("count : {0}", count);
                    }

                    //Console.WriteLine("n : {0}", temp1[i] + n);
                    n++;
                }

                if (count >= 5) // 스트레이트
                {
                    return true;
                }
            }

            return false;
        }

        #region 7. 트리플(같은 숫자의 카드 3장)
        #endregion
        public static bool Three_Of_A_Kind()
        {
            if (Get_SameNumbers(3, 1))
            {
                return true;
            }

            return false;
        }

        #region 8. 투 페어(같은 숫자의 카드 2장의 두 쌍)
        #endregion
        public static bool Two_Pair()
        {
            if (Get_SameNumbers(2, 2))
            {
                return true;
            }

            return false;
        }

        #region 9. 원 페어(같은 숫자의 카드 2장)
        #endregion
        public static bool One_Pair()
        {
            if (Get_SameNumbers(2, 1))
            {
                return true;
            }

            return false;
        }

        #region 10. 탑(아무것도 아닐 경우)
        #endregion
        public static bool High_Card()
        {
            return true;
        }


        #region 같은 숫자 찾기 함수
        #endregion
        public static bool Get_SameNumbers(int checkNumber, int checkPair)
        {
            int pair = 0;
            int min = Card_Numbers.Min();
            int max = Card_Numbers.Max();
            for (int i = min; i < max + 1; i++)
            {
                int count = 0;
                for (int j = 0; j < Card_Numbers.Count(); j++)
                {
                    if (Card_Numbers[j] == i)
                    {
                        count++;
                    }
                }
                if (count >= checkNumber)
                {
                    pair++;
                    if (pair >= checkPair)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    }

}
