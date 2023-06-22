using _31stProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31stProject
{
    public class TileClass
    {
        public MapClass Map = default;

        // 링크 연결
        public void Get_Link(MapClass myClass)
        {
            Map = myClass;
        }

        // 풀숲 체크
        public bool Get_CheckGrass(int x, int y)
        {
            int size = Map.GC_List.Count();
            for (int i = 0; i < size; i++)
            {
                if (y == Map.GC_List[i].Dir_Y && Map.GC_List[i].Dir_X == x)
                {
                    return true;
                }

            }

            return false;
        }

        // NPC 체크
        public bool Get_CheckNPC(int x, int y, NpcClass npc)
        {
            if (y == npc.Dir_Y && npc.Dir_X == x)
            {
                return true;
            }

            return false;
        }

    }

}
