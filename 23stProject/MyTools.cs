using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23stProject
{
    public static class MyTools
    {
        public static bool IsValid<T>(this List<T> list_)
        {
            bool isValid = (list_ != null) && (0 < list_.Count);
            return isValid;
        }

        public static void DogPrint(this Dog myDog)
        {
            myDog.PrintInfos();
        }

        public static int Plus(this int firstValue, int secondValue)
        {
            return firstValue + secondValue;
        }

        public static void PlusAndPrint(this int firstValue, int secondValue)
        {
            Console.WriteLine("{0} + {1} = {2}", firstValue, secondValue,
                firstValue + secondValue);
        }

    }

}
