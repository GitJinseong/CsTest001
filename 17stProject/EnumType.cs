using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17stProject
{
    enum ItemType_DY
    {   // enum은 상수에 이름을 넣어서 쓴다.(int형 정수).
        // 0부터 시작한다 ex)0~3
        // 만약 중간에 값을 이상하게 넣으면 순서가 바껴서 오류가 발생한다.
        // ex) POTION = 1, GOLD = 3, WEAPON = 2, ARMOR
        // 아래는 사용하는 방법이다.
        // ex2) POTION은 값이 0인 상수
        // ex3) WEAPON은 값이 2인 상수
        // ex4) ARMOR는 값이 6인 상수
        POTION, GOLD, WEAPON, ARMOR = 6, KOREA = 100_000
    }
        
}
