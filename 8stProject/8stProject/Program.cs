using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 클래스 작성 실습 해보기
// 본인이 만들고 싶은 몬스터 클래스 3개 만들것.
// - 몬스터 이름, HP, MP, Attack, Defense, 몬스터 타입
// - 위에 정의된 값을 출력하는 함수를 클래스 내부에 구현할 것
namespace _8stProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 아래는 오버로딩을 사용하지 않은 상태다.
            //Monster myMonster = new Monster();
            //myMonster.Monster2("달팽이", 100, 50, 5, 3, "반격");
            //myMonster.PrintMonster();

            //아래는 오버로딩을 사용했다
            Monster myMonster = new Monster("달팽이", 100, 50, 5, 3, "반격");
            Monster myMonster2 = new Monster("슬라임", 200, 100, 10, 6, "반격");
            Monster myMonster3 = new Monster("고블린", 400, 200, 20, 12, "선공격");

            myMonster.PrintMonster();
            myMonster.PrintMonster();
            myMonster3.PrintMonster();
        }
    }
}
