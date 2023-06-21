using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _27stProject
{
    public class Class_Map
    {
        #region 선언부
        public string[,] Map { get; private set; } = default;
        public int MapSize_X { get; private set; } = default;
        public int MapSize_Y { get; private set; } = default;

        #endregion

        // 생성자
        public Class_Map(int size_)
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

        // 맵 생성
        public void Set_CreateMap()
        {
            for (int y = 0; y < MapSize_Y; y++)
            {
                for (int x = 0; x < MapSize_X; x++)
                {
                    Map[y, x] = "　";

                    if (x == Manager.CP.Dir_X && Manager.CP.Dir_Y == y)
                    {
                        Map[y, x] = "●";
                    }

                    for (int i = 0; i < Manager.CW_List.Count; i++)
                    {
                        if (x == Manager.CW_List[i].Dir_X && Manager.CW_List[i].Dir_Y == y)
                        {
                            Map[y, x] = "■";
                        }

                    }

                    for (int i = 0; i < Manager.CE_List.Count; i++)
                    {
                        if (x == Manager.CE_List[i].Dir_X && Manager.CE_List[i].Dir_Y == y)
                        {
                            Map[y, x] = "ⓔ";
                        }

                    }
                }

            }

        }

        
    }
}
