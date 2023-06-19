using System;
using System.Collections.Generic;
using System.Linq;
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
        static void Main(string[] args)
        {
            Jokbo.Get_Card_Numbers(1,3,3,4,5);
            Jokbo.Get_Card_Patterns(0, 3, 2, 0, 1, 2);
            Jokbo.Set_ConvertCards();

            Jokbo.Royal_Straight_Flush();
            Jokbo.Straight_Flush();
            Jokbo.Four_Of_A_Kind();
            Jokbo.Full_House();
            Jokbo.Flush();
            Jokbo.Straight();

        }

    }

}
