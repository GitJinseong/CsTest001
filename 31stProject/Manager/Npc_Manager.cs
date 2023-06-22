using _31stProject;
using _31stProject._31stProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31stProject
{
    public class Npc_Manager
    {
        #region 선언부
        public QuestNpc_Child npc { get; private set; } = new QuestNpc_Child(5, 5);
        #endregion

    }

}
