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
    public class Monster
    {
        string name;
        string type;
        int hp;
        int mp;
        int attack;
        int defense;

        // 아래는 오버로딩이다.
        public Monster(string name, int hp, int mp, int attack, int defense, string type)
        {
            this.name = name;
            this.hp = hp;
            this.mp = mp;
            this.attack = attack;
            this.defense = defense;
            this.type = type;
        }

        // 아래는 오버로딩이 아닌 일반 메서드다.
        //public void Monster2(string name, int hp, int mp, int attack, int defense, string type)
        //{
        //    this.name = name;
        //    this.hp = hp;
        //    this.mp = mp;
        //    this.attack = attack;
        //    this.defense = defense;
        //    this.type = type;
        //}

        public void PrintMonster()
        {
            Console.WriteLine("몬스터의 이름 : {0}", name);
            Console.WriteLine("몬스터의 체력 : {0}", hp);
            Console.WriteLine("몬스터의 마력 : {0}", mp);
            Console.WriteLine("몬스터의 공격력 : {0}", attack);
            Console.WriteLine("몬스터의 방어력 : {0}", defense);
            Console.WriteLine("몬스터의 타입 : {0}\n\n\n", type);
        }

    }
}
