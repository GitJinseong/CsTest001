using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 클래스명이 겹칠 경우를 대비하여
// namespace를 사용한다.
namespace _13stProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Print002 printClass = new Print002();

            printClass.PrintMessage("Hello World!");
            Print001.PrintMessage("Hi World!");
            Print001.PrineMessage2();
        }
    }
}

