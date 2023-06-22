using _31stProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31stProject
{
    public class MapClass
    {
        #region 선언부
        public string[,] Map { get; private set; } = default;
        public int MapSize_X { get; private set; } = default;
        public int MapSize_Y { get; private set; } = default;
        public List<GrassClass> GC_List { get; private set; } = new List<GrassClass>();
        public Npc_Manager NM { get; private set; } = new Npc_Manager();

        #endregion

        // 생성자
        public MapClass(int size_)
        {
            MapSize_X = size_ - 10;
            MapSize_Y = size_;
            Map = new string[size_, size_];
        }

        // 맵 출력
        public void Get_PrintMap()
        {
            for (int y = 0; y < MapSize_Y; y++)
            {
                for (int x = 0; x < MapSize_X; x++)
                {
                    Console.Write(Map[y, x]);
                }
                Console.WriteLine();
            }
        }

        // 수풀 생성
        public void Set_CreateGrass(int count)
        {
            for (int i = 0; i < count; i++)
            {
                int x = Center_Manager.random.Next(0, MapSize_X);
                System.Threading.Thread.Sleep(16);
                int y = Center_Manager.random.Next(0, MapSize_Y);
                GrassClass grass = new GrassClass(x, y);
                GC_List.Add(grass);
            }

        }

        // 맵 생성
        public void Set_CreateMap()
        {
            for (int y = 0; y < MapSize_Y; y++)
            {
                for (int x = 0; x < MapSize_X; x++)
                {
                    Map[y, x] = "　";

                    for (int i = 0; i < GC_List.Count; i++)
                    {
                        if (x == GC_List[i].Dir_X && GC_List[i].Dir_Y == y)
                        {
                            Map[y, x] = "※";
                        }

                    }
                    for (int i = 0; i < 1; i++)
                    {
                        if (x == NM.npc.Dir_X && NM.npc.Dir_Y == y)
                        {
                            Map[y, x] = "ⓝ";
                        }
                    }
                    if (x == Center_Manager.PC.Dir_X && Center_Manager.PC.Dir_Y == y)
                    {
                        Map[y, x] = "★";
                    }

                }

            }

        }

    }

}

