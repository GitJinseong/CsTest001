using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26stProject
{
    public class Button : Clickable, IClickable, IDamagable
    {
        public void TestFunc()
        {
            Console.WriteLine("함수 테스트");
        }

        // override를 붙이지 않아도 프로그램에서 자동으로 붙여주지만
        // override를 붙이는 것을 생활화 하자!.
        public override void ClickThisObject(bool isClick_)
        {
            isClickOk = isClick_;

            Console.WriteLine("당신은 이 오브젝트를 클릭?");
        }

        public void Get_Damage(int damage)
        {
            Console.WriteLine("{0} 데미지를 받았습니다!", damage);
        }
    }
}
