using _21stProject.ChildClass;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21stProject.Manager
{
    public class Monster_Manager
    {
        #region 초기 선언부
        public const int MONSTER_TYPE_COUNT = 3;
        public Dictionary<string,Monster> Storage { get; private set; } = default;
        public Slime slime { get; private set; } = default;
        public Goblin goblin { get; private set; } = default;
        public Orc orc { get; private set; } = default;
        #endregion

        #region 생성자 함수
        #endregion
        public Monster_Manager()

        {
            Set_Respawn();
        }

        #region 초기화 함수
        #endregion
        public void Set_Respawn()
        {
            slime = new Slime("슬아임", 50, 50, 5, 3, 10);
            goblin = new Goblin("고불린", 100, 100, 10, 6, 25);
            orc = new Orc("호크", 200, 200, 20, 12, 50);

            Storage = new Dictionary<string, Monster>();
            Storage.Add("슬라임", slime);
            Storage.Add("고블린", goblin);
            Storage.Add("오크", orc);
        }

        #region 객체 호출 함수
        #endregion
        public Monster Get_Monster(string name)
        {
            return Storage[name];
        }

    }

}
