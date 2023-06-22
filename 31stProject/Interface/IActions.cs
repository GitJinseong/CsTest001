using _31stProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31stProject
{
    interface IActions
    {
        void Set_Rebirth();
        void Get_Damage(PlayerClass player, EnemyClass enemy);
        void Get_PrintStats();
        bool Get_IsDead();
    }

}
