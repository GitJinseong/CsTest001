using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 플레이어로부터 사이즈를 입력 받아서 해당 사이즈 크기만큼 콘솔 맵을 구현한다.
// 플레이어는 w, a, s, d 등 방향을 입력 받아서 콘솔 맵 안을 자유롭게 움직일 수 있다.
// 콘솔 맵에는 일정 시간 or 일정 움직임 마다 돌 3개가 등장한다.(한 맵에 돌은 최대 3개 까지)
// [조건] 
// 1. 플레이어는 돌을 밀 수 있다. 
// 2. 한번 민 돌은 해당 방향으로 끝까지 쭉 밀린다(한 번에 밀리거나 or 한 칸씩 움직인다).
// 3. 어떤 방향으로든 돌이 연속으로 3개가 붙어 있을 경우 돌은 사라지고, 점수가 올라간다.
// 4. 플레이어가 일정 점수를 획득하면 게임을 종료한다.
// 5. R 키를 눌러서 게임을 초기화 한다.
namespace _18stProject
{
    public class Stone
    {
        public int dir_X { get; private set; }
        public int dir_Y { get; private set; }

        public void Set_dir_Y(int y)
        {
            dir_Y = y;
        }

        public void Set_dir_X(int x)
        {
            dir_X = x;
        }

        public Stone(int size, int size2)
        {
            Random random = new Random();

            int x = random.Next(size, size2);
            Task.Delay(100).Wait();
            int y = random.Next(0, size2*10) % size2;
            Task.Delay(100).Wait();

            dir_X = x;
            dir_Y = y;
        }

    }

}
