using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22stProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            int number = 10;
            char charValue = 'A';
            string textStr = "Hello World!";

            // 박싱의 예시
            object canSaveAll1 = number;
            object canSaveAll2 = charValue;
            object canSaveAll3 = textStr;

            // 리플렉션: 컴파일 타임의 타입을 추론
            var canSaveAnything1 = number;
            var canSaveAnything2 = charValue;
            var canSaveAnything3 = textStr;
            var canSaveAnything4 = canSaveAll1;

            // 언박싱의 예시 (리플렉션: 컴파일 타임의 타입을 추론)
            int number2 = (int)canSaveAll1;

            Console.WriteLine(number2);
            Console.WriteLine(canSaveAll2);
            Console.WriteLine(canSaveAll3);
        }

    }
}
