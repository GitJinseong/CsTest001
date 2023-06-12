using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9stProject
{
    // 클래스의 경우 선언하자마자 메모리에 할당되는게 아니라
    // 클래스명 객체명 = new 클래스명(); 해서 객체를 생성할 때
    // 메모리에 할당된다.
    public class MonsterBase
    {
        // (캡슐화) -> 필드를 private로 처리해서 외부에서 접근 불가능하도록
        // 하겠다는 의미.
        // 아래는 상속받은 클래스다. 따라서 변수 값을 선언 안해도
        // 부모의 변수를 호출(상속)할 수 있어서 지장이 없다.
        // 부모의 메서드(함수)도 상속받는다.
        protected string name;  // protected는 상속받은 자식 클래스에서는 사용가능하다.
        protected int hp;
        protected int mp;
        protected int damage;
        protected int defence;
        protected string type;

    // 부모 클래스에 있는 메서드에 virtual을 붙여야
    // 자식 클래스에서 override를 사용할 수 있다.
    public virtual void Initilize(string name, int hp, int mp, int damage, int defence, string type)
    {
        this.name = name;
        this.hp = hp;
        this.mp = mp;
        this.damage = damage;
        this.defence = defence;
        this.type = type;
    }   // Initilize()

    // 부모 클래스에 있는 메서드에 virtual을 붙여야
    // 자식 클래스에서 override를 사용할 수 있다.
        public virtual void Print_MonsterInfo()
    {
        Console.WriteLine("몬스터 이름 : {0}", name);
        Console.WriteLine("몬스터 체력 : {0}", hp);
        Console.WriteLine("몬스터 체력 : {0}", mp);
        Console.WriteLine("몬스터 데미지 : {0}", damage);
        Console.WriteLine("몬스터 방어력 : {0}", defence);
        Console.WriteLine("몬스터 타입 : {0}", type);
    }

    }
}
