using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9stProject
{
    public class Cat : MonsterBase
    {
        // (캡슐화) -> 필드를 private로 처리해서 외부에서 접근 불가능하도록
        // 하겠다는 의미.
        // 아래는 상속받은 클래스다. 따라서 변수 값을 선언 안해도
        // 부모의 변수를 호출(상속)할 수 있어서 지장이 없다.
        // 부모의 메서드(함수)도 상속받는다.
        //protected string name;  // protected는 상속받은 자식 클래스에서는 사용가능하다.
        //protected int hp;
        //protected int mp;
        //protected int damage;
        //protected int defence;
        //protected string type;

    // 아래의 이니셜라이즈(변수에 값 입력)만 있으면
    // 부모에 있는 메서드(함수)를 호출해서 사용할 수 있다.
    // 이렇게 부모에 있는 함수를 호출하여 사용하는 것을
    // override(오버라이딩)이라고 한다.
    public override void Initilize(string name, int hp, int mp, int damage, int defence, string type)
    {
        // base는 부모를 뜻한다.
        base.Initilize(name, hp, mp, damage, defence, type);
            //this.name = name;
            //this.hp = hp;
            //this.mp = mp;
            //this.damage = damage;
            //this.defence = defence;
            //this.type = type;
        }   // Initilize()

    public override void Print_MonsterInfo()
    {
        // base는 부모를 뜻한다.
        base.Print_MonsterInfo();
    }

    // 매개 인수가 같은(시그니처) 메서드의 경우
    // 오버로딩을 할 수 없다.
    // 그래서 맨 아래의 경우 out int를 인수로 넣어줬다.
    // 인수에 값을 넣지 않으면 아래에 있는 메서드가 실행되고
    // 값을 넣으면 맨 아래에 있는 메서드가 실행된다.
    public void Print_OverloadingTest()
    {
        Console.WriteLine("함수 찍힌다");
    }


    public void Print_OverloadingTest(out int number)
    {
        Console.WriteLine("함수 찍힌다");
        number = 10;
    }

    }   // class Cat
}
