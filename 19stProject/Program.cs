using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 콘솔 맵에서 매 턴 랜덤한 곳에 숫자 1이 등장한다.
// 방향키 중 오른쪽 키(혹은 D)를 입력하면 맵에 존재하는
// 모든 1이 오른쪽 끝으로 이동한다. 
// 만약, 오른쪽 끝에 이미 1이 있는 경우 1이 더해진다.
// 턴이라는 것은 1회의 입력을 말한다.
// 2 방향만 구현할 것.
// 맵에 매 턴 1이 랜덤한 1 곳에 생성된다. (Easy)
// 맵에 매 턴 1이 랜덤한 3 곳에 생성된다. (Normal)
// 가장 우측 열과 가장 아래쪽 행의 숫자는 이동하지 않는다.(Hard)
// -> 오른쪽, 아래로 입력 가능.
namespace _19stProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 게임 실행을 위한 객체 생성
            #endregion
            GameManager game = new GameManager(10);
        }
    }
}
