﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28stProject
{
    public class CustomClass
    {
        public int xPos;
        public int yPos;

        public void Initalize(int xPos_, int yPos_)
        {
            xPos = xPos_;
            yPos = yPos_;
        }

        public virtual void PrintPosition()
        {
            Console.WriteLine("현 위치는 ({0}, {1}) 입니다.", xPos, yPos);
        }

    }

}
