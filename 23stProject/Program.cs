using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23stProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Parent myParent = new Parent();
            Child myChild = new Child();

            //myParent.PrintInfos();
            //myChild.PrintInfos();

            // 아래는 업 캐스팅의 예시다.
            Parent tempParent = myChild;

            // 아래는 다운 캐스팅의 예시다.
            // 다운 캐스팅으로 강제 형변환되서 자식에서 생성된
            // 고유의 변수에 접근하는데 문제가 발생할 수 있다.
            Child tempChild = (Child)tempParent;

            tempParent.PrintInfos();
            tempChild.PrintInfos();

            Dog myDog = new Dog();
            myDog.DogPrint();

            int number = 10;
            number.Plus(5);
            number.PlusAndPrint(5);

            List<int> numberList = new List<int> { 1, 2, 3 };
            if (numberList.IsValid())
            {
                Console.WriteLine("이 리스트는 유효하다. Null도 아니고, 값도 들어 있다.");

            }
            else
            {
                Console.WriteLine("이 리스트는 유효하지 않다. Null이거나, 값이 없다.");

            }

        }

    }

}
