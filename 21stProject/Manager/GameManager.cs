using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#region 게임 설명 주석
// [움직이는 게임 만들기]
// 필요한 기능 : 상점(▣), 몬스터(♬), 카드게임(◎)
// 플레이어가 돌아다니면서 위의 기능을 상징하는
// 문양에 접촉하면 해당 기능을 실행시킨다.
// 문양 설정은 자유롭게.
#endregion
namespace _21stProject
{
    #region 게임 매니저 클래스
    #endregion
    public class GameManager
    {
        #region 클래스 객체, 변수 선언부
        CardGame myCardGame = default;
        Shop myShop = default;
        Battle myBattle = default;
        DB_Manager myDB = default;
        #endregion

        #region 생성자 함수
        #endregion
        public GameManager()
        {
            Start();
        }

        #region 초기화 함수
        #endregion
        public void Start()
        {
            myCardGame = new CardGame();
            myShop = new Shop();
            myBattle = new Battle();
            myDB = new DB_Manager();

            while (true)
            {

            }

        }

    }

}
