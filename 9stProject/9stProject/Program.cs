using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9stProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cat newCat = new Cat();

            newCat.Initilize("야옹이", 150, 80, 200, 5, "불");
            newCat.Print_MonsterInfo();
        }
    }
}
