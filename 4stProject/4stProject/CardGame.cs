using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _4stProject
{

    // [실습]
    // 플레이어와 컴퓨터가 각각 카드를 2장씩 뽑는다.
    // 두 카드의 합이 더 큰쪽이 승리, 작은 쪽은 패배한다.
    // 동일한 숫자가 나올 경우 문양은 -> 스페이드, 다이아몬드, 하트, 클로버 순서로 승리한다.
    public class CardGame
    {
        string[] cardPatterns_A = { "♣", "♥", "◆", "♠" };
        string[] cardPatterns_B = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        int[] cardNumbers = new int[13];
        int[,] playerCards = new int[1, 2];
        int[,] computerCards = new int[1, 2];

        // 카드 뽑기
        public void DrowCards()
        {
            // 랜덤 클래스 호출
            Random random = new Random();

            playerCards[0, 0] = random.Next(0, 3);
            playerCards[0, 1] = random.Next(0, 12);

            computerCards[0, 0] = random.Next(0, 3);
            computerCards[0, 1] = random.Next(0, 12);

            // 0.5초 대기
            Task.Delay(500).Wait();

            Console.WriteLine("플레이어의 카드 : {0}{1} ", cardPatterns_A[playerCards[0, 0]], cardPatterns_B[playerCards[0, 1]]);
            Console.WriteLine();

            // 0.5초 대기
            Task.Delay(500).Wait();

            Console.WriteLine("컴퓨터의 카드 : {0}{1} ", cardPatterns_A[computerCards[0, 0]], cardPatterns_B[computerCards[0, 1]]);
            Console.WriteLine();

            // 카드 체크 함수 호출
            CheckCards();
        }

        // 누가 이겼는지 카드를 체크한다.
        public void CheckCards()
        {
            int playerPattern = playerCards[0, 0];
            int computerPattern = computerCards[0, 0];
            int playerNumber = playerCards[0, 1];
            int computerNumber = computerCards[0, 1];

            // 1초 대기
            Task.Delay(1000).Wait();

            if (playerNumber > computerNumber)
            {
                Console.WriteLine("당신은 승리했습니다.\n");
            }
            else if (playerNumber == computerNumber)
            {

                if (playerPattern > computerPattern)
                {
                    Console.WriteLine("당신은 승리했습니다.\n");
           
                }
                else if(playerPattern < computerPattern)
                {
                    Console.WriteLine("당신은 패배했습니다.\n");
                }
                else
                {
                    Console.WriteLine("당신은 비겼습니다.\n");
                }

            }
            else
            {
                Console.WriteLine("당신은 패배했습니다.\n");
            }
        }

        // public을 해야 다른 클래스의 함수에 접근이 가능하다.
        public void Start()
        {
            // 패턴 생성 함수 호출
            DrowCards();
        }

    }
}
