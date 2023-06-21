using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27stProject
{
    // 4방향 중에 이동가능한 타일을 찾고
    // 플레이어와의 xy좌표를 비교한다음 최적의 거리로 이동한다.
    public class Class_Enemy_AI
    {

        // 몬스터 이동
        public void Set_Moving(int index, int type)
        {
            int x = Manager.CE_List[index].Dir_X;
            int y = Manager.CE_List[index].Dir_Y;
            int max_X = Manager.CM.MapSize_X;
            int max_Y = Manager.CM.MapSize_Y;

            switch (type)
            {
                case 0:
                    if (!Get_CheckWall(x, y - 1))
                    {
                        Manager.CE_List[index].Set_Dir_Y(y == 0 ? y : y - 1);
                    }
                    break;

                case 1:
                    if (!Get_CheckWall(x - 1, y))
                    {
                        Manager.CE_List[index].Set_Dir_X(x == 0 ? x : x - 1);
                    }
                    break;

                case 2:
                    if (!Get_CheckWall(x, y + 1))
                    {
                        Manager.CE_List[index].Set_Dir_Y(y == max_Y - 1 ? y : y + 1);
                    }
                    break;

                case 3:
                    if (!Get_CheckWall(x + 1, y))
                    {
                        Manager.CE_List[index].Set_Dir_X(x == max_X - 1 ? x : x + 1);
                    }
                    break;
            }
        }

        // 플레이어 찾기
        public void Set_Move()
        {
            int size = Manager.CE_List.Count;
            for (int i = 0; i < size; i++)
            {
                int[] cost = new int[4];
                int x = Manager.CE_List[i].Dir_X;
                int y = Manager.CE_List[i].Dir_Y;
                if (!Get_CheckWall(x, y - 1))
                {
                    cost[0] = Math.Abs(Manager.CP.Dir_X - x) + Math.Abs(Manager.CP.Dir_Y - (y - 1));
                }

                if (!Get_CheckWall(x - 1, y))
                {
                    cost[1] = Math.Abs(Manager.CP.Dir_X - (x - 1)) + Math.Abs(Manager.CP.Dir_Y - y);
                }

                if (!Get_CheckWall(x, y + 1))
                {
                    cost[2] = Math.Abs(Manager.CP.Dir_X - x) + Math.Abs(Manager.CP.Dir_Y - (y + 1));
                }

                if (!Get_CheckWall(x + 1, y))
                {
                    cost[3] = Math.Abs(Manager.CP.Dir_X - (x + 1)) + Math.Abs(Manager.CP.Dir_Y - y);
                }

                int blockCount = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (cost[j] == 0)
                    {
                        blockCount++;
                        cost[j] = cost.Max();
                    }

                }
                
                List<int> cost_List = new List<int>();
                for (int j = 0; j < 4; j++)
                {
                    if (cost[j] == cost.Min())
                    {
                        if (blockCount == 0)
                        {
                            Set_Moving(i, j);
                            break;
                        }
                        cost_List.Add(j);
                    }
                }
                // 주변에 벽이 있을 경우
                if (cost_List.Count > 0)
                {
                    Set_Moving(i, cost_List[Manager.random.Next(0, cost_List.Count)]);
                }
                // 주변이 전부 벽일 경우
                else
                {
                    Set_Moving(i, Manager.random.Next(0,3));
                }
                Console.WriteLine("{0}번 몬스터와 나의 거리: {1:d2}, 충돌 타일: {2}", i, cost.Min(), blockCount);
            }
            
        }

        // 벽 체크
        public bool Get_CheckWall(int x, int y)
        {
            int size = Manager.CW_List.Count();
            for (int i = 0; i < size; i++)
            {
                if (y == Manager.CW_List[i].Dir_Y && Manager.CW_List[i].Dir_X == x)
                {
                    return true;
                }

            }

            return false;
        }

    }

}
