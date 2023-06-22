using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28stProject
{
    public class CustomChild : CustomClass
    {
        public override void PrintPosition()
        {
            Console.WriteLine("현 위치는 ({0}, {1}) 입니다.", xPos, yPos);
        }
    }
}
