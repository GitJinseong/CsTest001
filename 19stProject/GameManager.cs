using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// 콘솔 맵에서 매 턴 랜덤한 곳에 숫자 1이 등장한다.
// 방향키 중 오른쪽 키(혹은 D)를 입력하면 맵에 존재하는
// 모든 1이 오른쪽 끝으로 이동한다. 
// 만약, 오른쪽 끝에 이미 1이 있는 경우 1이 더해진다.
// 턴이라는 것은 1회의 입력을 말한다.
// 2 방향만 구현할 것.
// 맵에 매 턴 1이 랜덤한 1 곳에 생성된다. (Easy)
// 맵에 매 턴 1이 랜덤한 3 곳에 생성된다. (Normal)
// 가장 우측 열과 가장 아래쪽 행의 숫자는 이동하지 않는다.(Hard)
// -> 오른쪽, 아래로 입력 가능.
namespace _19stProject
{
    #region 게임을 관리하는 클래스
    #endregion
    public class GameManager
    {
        #region 변수와 배열, 리스트 선언
        [DllImport("msvcrt.dll")]
        static extern char _getch();
        public int Size { get; private set; } = default;
        public string[,] Map { get; private set; } = default;
        public string[] Patterns { get; private set; } = default;
        public List<Number> Numbers { get; private set; } = default;
        #endregion

        #region 생성자 함수
        #endregion
        public GameManager(int size)
        {
            Start(size);
        }

        #region 초기화 함수
        #endregion
        public void Start(int size_)
        {
            Size = size_;
            Map = new string[Size, Size];
            Patterns = new string[10] {"①", "②", "③", "④", "⑤", "⑥", "⑦", "⑧", "⑨", "⑩"};
            Numbers = new List<Number>();

            while (true)
            {
                Console.Clear();
                Set_RandomOne();
                Set_AddMatchingNumbers();
                Set_CreateMap();
                Get_PrintMap();
                Get_HandleInput();
                Get_IsEndGame();
            }

        }

        #region 게임이 끝나는지 조건을 확인하는 함수
        #endregion
        public void Get_IsEndGame()
        {
            for (int i = 0; i < Numbers.Count; i++)
            {

                if (Numbers[i].Value > 1000)
                {
                    Console.WriteLine("당신은 승리하였습니다!!!");
                    Task.Delay(1000000000).Wait();
                }

            }

        }

        #region 화면에 맵을 출력하는 함수
        #endregion
        public void Get_PrintMap()
        {

            for (int y = 0; y < Size; y++)
            {

                for (int x = 0; x < Size; x++)
                {
                    Console.Write("{0}", Map[y, x]);
                }

                Console.WriteLine();
            }

        }

        #region 사용자의 키 입력을 받는 함수(왼쪽: a / 오른쪽: d)
        #endregion
        public void Get_HandleInput()
        {
            char inputValue = _getch();

            switch (inputValue)
            {
                case 'a': case 'A':
                    Set_MoveOnesLeft();
                    break;

                case 'd': case 'D':
                    Set_MoveOnesRight();
                    break;
            }

        }

        #region 리스트에 포함된 객체를 삭제하는 함수
        #endregion
        public void Set_RemoveList()
        {

            for (int i = Numbers.Count - 1; -1 < i; i--)
            {

                if (Numbers[i].Value == 0)
                {
                    Numbers.RemoveAt(i);
                }

            }

        }

        #region 같은 숫자를 만나면 숫자를 합치는 함수
        #endregion
        public void Set_AddMatchingNumbers()
        {
            for (int i = 0; i < Numbers.Count; i++)
            {
                int x = Numbers[i].Dir_X;
                int y = Numbers[i].Dir_Y;

                for (int j = i + 1; j < Numbers.Count; j++)
                {

                    if ((x == Numbers[j].Dir_X && y == Numbers[j].Dir_Y && 0 < Numbers[j].Value))
                    {
                        Numbers[i].Set_Value(Numbers[i].Value + Numbers[j].Value);
                        Numbers[j].Set_Value(0);
                    }

                }

            }

            #region 리스트를 삭제하지 않으면 꼬여서 오류 발생함
            #endregion
            Set_RemoveList();
        }

        #region 맵에 존재하는 모든 숫자를 왼쪽 끝으로 이동시키는 함수
        #endregion
        public void Set_MoveOnesLeft()
        {
            for (int i = 0; i < Numbers.Count; i++)
            {

                for (int j = 0; j < Size; j++)
                {
                    int x = Numbers[i].Dir_X;
                    Numbers[i].Set_Dir_X(x == 0 ? x : x - 1);
                }

            }

        }

        #region 맵에 존재하는 모든 숫자를 오른쪽 끝으로 이동시키는 함수
        #endregion
        public void Set_MoveOnesRight()
        {
            for (int i = 0; i < Numbers.Count; i++)
            {

                for (int j = 0; j < Size; j++)
                {
                    int x = Numbers[i].Dir_X;
                    Numbers[i].Set_Dir_X(x == Size - 1 ? x : x + 1);
                }

            }
        }

        #region 맵을 생성하는 함수
        #endregion
        public void Set_CreateMap()
        {
            for (int y = 0; y < Size; y++)
            {

                for (int x = 0; x < Size; x++)
                {
                    Map[y, x] = "□";

                    for (int k = 0; k < Numbers.Count; k++)
                    {

                        if ((x == Numbers[k].Dir_X) && (Numbers[k].Dir_Y) == y)
                        {

                           if (Numbers[k].Value <= 10)
                           {
                              Map[y, x] = Patterns[Numbers[k].Value - 1];
                           }
                           else
                           {
                              Map[y, x] = Numbers[k].Value.ToString();
                           }

                        }

                    }

                }

            }

        }

        #region 맵에 랜덤하게 1을 생성하는 함수
        #endregion
        public void Set_RandomOne()
        {
            Random random = new Random();

            for (int i = 0; i < 3; i++)
            {
                int x = random.Next(0, Size);
                int y = random.Next(0, Size);
                Number number = new Number(x, y);
                Numbers.Add(number);
            }

        }

    }

}
