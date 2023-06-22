using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29stProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            string strValue = "I am a boy.";
            string[] strArray = strValue.Split(' ');

            Console.WriteLine("몇 개로 Split 되었는가? -> {0}", strArray.Count());
            Console.WriteLine();

            for (int i = 0; i < strArray.Length; i++)
            {
                Console.WriteLine(strArray[i]);
            }
        }
    }
}
