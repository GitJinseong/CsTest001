using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26stProject
{
    // 무언가 클릭이 가능한 오브젝트를 만들고 싶을 때 사용할 클래스임.
    abstract public class Clickable
    {
        protected bool isClickOk = false;

        // virtual을 사용하지 않아도 프로그램에서 붙여주지만
        // virtual을 붙이는 것을 생활화하자!
        public virtual void ClickThisObject(bool isClick_)
        {
            isClickOk = isClick_;

            Console.WriteLine("당신은 이 오브젝트를 클릭했습니다.");
        }
    }
}
