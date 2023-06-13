using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// [과제]
// tic tac toe 게임 만들기
// 사이즈는 3x3
// 인덱스 1~9 or 0~8번 받아서 출력후 선택하기
// 선택시 O / X 표시하고 
// 먼저 3줄 빙고 하나 만들면 승리(오목 같은 느낌)
// 상대가 빙고를 완성하지 못하게 막을 수 있다.
// 승리 / 패배 구현하기
namespace _11stProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TicTacToe Game = new TicTacToe();

            Game.Initialize("●", "★", "□");
            Game.Start();
        }
    }
}
