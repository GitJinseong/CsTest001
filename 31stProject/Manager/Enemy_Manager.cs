using _31stProject._31stProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31stProject
{
    public class Enemy_Manager
    {
        #region 선언부
        public List<EnemyClass> List { get; set; } = default;
        #endregion
        
        // 생성자
        public Enemy_Manager()
        {
            Set_CreateList();
            Set_CreateMonsters();
        }

        // 리스트 초기화
        public void Set_CreateList()
        {
            List = new List<EnemyClass>();
        }

        // 몬스터 생성
        public void Set_CreateMonsters()
        {
            Slime_Child slime = new Slime_Child();
            Goblin_Child goblin = new Goblin_Child();
            Orc_Child orc = new Orc_Child();
            List.Add(slime);
            List.Add(goblin);
            List.Add(orc);
        }

    }

}
