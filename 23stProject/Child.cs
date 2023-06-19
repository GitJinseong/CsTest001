using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23stProject
{
    public class Child : Parent
    {
        string strChild = default;

        public override void PrintInfos()
        {
            //base.PrintInfos();

            number = 10;
            strValue = "This is Child";
            strChild = "Sentences of child added";
            Console.WriteLine("child Class -> number: {0}, strValue: {1}, strChild: {2}",
                this.number, this.strValue, this.strChild);
        }
    }
}
