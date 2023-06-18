using _21stProject.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _21stProject.ChildClass
{
    #region 자식 클래스 슬라임
    #endregion
    public class Slime : Monster
    {
        #region 생성자 함수
        #endregion
        public Slime(string name, int hp, int maxHp, int atk, int def, int golds) : base(name, hp, maxHp, atk, def, golds){} // base를 사용하여 Monster의 생성자를 호출

    }

}
