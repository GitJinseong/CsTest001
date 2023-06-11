using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2stProject
{
    public class myClassA
    {
        static void Main(string[] args)
        {
            int [,]numbers2 = new int[5, 5];
            int valueCount = 0;

            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    valueCount += 1;
                    numbers2[y, x] = valueCount;
                }
            }

            B myClassA = new B();

            myClassA.PrintMyArray(numbers2);
        }

        public class A
        {

        }
    }
}
