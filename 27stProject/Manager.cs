using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27stProject
{
    public static class Manager
    {
        #region 선언부
        public static Class_Map CM { get; private set; } = new Class_Map(30);
        public static Class_Keypad CK { get; private set; } = new Class_Keypad();
        public static Class_Player CP { get; private set; } = new Class_Player();
        public static List<Class_Wall> CW_List { get; private set; } = new List<Class_Wall>();
        public static List<Class_Enemy> CE_List { get; private set; } = new List<Class_Enemy>();
        #endregion

        // 벽 생성
        public static void Set_Create_Wall(int count)
        {
            int max_X= CM.MapSize_X;
            int max_Y = CM.MapSize_Y;
            for (int i = 0; i < count; i++)
            {
                Random random = new Random();
                Class_Wall wall = new Class_Wall(random.Next(0, max_Y), random.Next(0, max_X));
                CW_List.Add(wall);
                System.Threading.Thread.Sleep(1);
            }
        }

        public static void Set_Create_Monster()
        {
            int max_X = CM.MapSize_X;
            int max_Y = CM.MapSize_Y;
            bool runWhile = true;
            while (runWhile)
            {
                for (int i = 0; i < 1; i++)
                {
                    Random random = new Random();
                    int randomValue = random.Next(0, max_X);
                    System.Threading.Thread.Sleep(13);
                    int randomValue2 = random.Next(0, max_Y);

                    if (!Get_CheckDuplicate(randomValue, randomValue2))
                    {
                        Class_Enemy enemy = new Class_Enemy(randomValue, randomValue2);
                        CE_List.Add(enemy);
                        runWhile = false;
                    }
                }
            }
        }

        public static bool Get_CheckDuplicate(int x, int y)
        {
            for (int i = 0; i < CW_List.Count; i++)
            {
                if (x == CW_List[i].Dir_X && CW_List[i].Dir_Y == y)
                {
                    return true;
                }

            }

            return false;
        }

        public static void Get_CheckDefeat()
        {
            if (CK.Get_CheckEnemy())
            {
                Console.WriteLine("당신은 패배하였습니다!!!");
                Task.Delay(1000000000).Wait();
            }
        }

    }

}
