using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 변수를 여러개 모아서 관리하고 싶을 때 아래의 구조체 혹은
// 클래스를 사용한다. > 대부분의 경우 클래스 사용
public struct Cat
{
    private int legCount;
    private string catName;
    private string catColor;

    // 아래의 경우 구조체(클래스)와 동일한 이름을 가진 메서드이다.
    // 생성자와 소멸자라고 한다. new , delete
    // 특징은 자신과 이름이 똑같고, 리턴 타입이 전혀 없다.
    public Cat(int legCount_, string catName_, string catColor_)
    {
        legCount = legCount_;
        catName = catName_;
        catColor = catColor_;
    }

    public void Print_MyCat()
    {
        Console.WriteLine("우리집 고양이 이름은 {0} 이고, 색은 {1} 이다.",
            catName, catColor);
    }
}

namespace _7stProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dog myDog = new Dog();
            Console.WriteLine("우리집 강아지 이름은 {0} 이고, 다리 갯수는 {1}개 이다.", myDog.dogName, myDog.legCount);
            myDog.Print_DogDescription();
            // 아래의 메서드는 static 메서드라서 시점이 달라
            // myDog로 클래스 호출을 한 이후에 생성이 되어
            // Dog(클래스명)으로 호출해야 한다.
            Dog.Print_DogDescription002();

            Cat myCat = new Cat(4, "야옹이", "검정색");
            myCat.Print_MyCat();

        }

        //public struct Cat
        //{
        //    public Cat(int legCount)
        //    {
        //        _legCount = legCount;
        //    }
        //    private int _legCount;

        //}

    }
    public class Dog
    {
        // 접근 제한자, 접근 지정자
        // public, protected, private
        public int legCount = 4;
        public string dogName = "멍멍이";
        private string dogColor = "하얀색";
        private string dogSound = "왈크왈크";

        public void Print_DogDescription()
        {
            Console.WriteLine("강아지 색은 {0} 이고, 짖는 소리는 {1} 이다. ", dogColor, dogSound);
        }

        // static을 사용하면 시점이 달라져서 static 하지 않은
        // 곳에서 불러 올 수 없다.
        // 같은 static 끼리만 호출 가능.
        // 아래의 경우 같은 Dog 클래스 내에 있지만 static을 사용해서
        // 메서드 안에 따로 Dog 클래스를 호출한 후 변수를 호출한다.
        public static void Print_DogDescription002()
        {
            Dog myDog = new Dog();
            Console.WriteLine("강아지 이름은 {0} 이고, 색상은 {1} 이다.", myDog.dogName, myDog.legCount); ;
        }
    }

}
