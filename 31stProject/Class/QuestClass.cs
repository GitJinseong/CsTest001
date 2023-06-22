using _31stProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31stProject
{
    public class QuestClass
    {
        #region 선언부
        string QuestName { get; set; } = default;
        int QuestType { get; set; } = default;  // 타입 0 : 몬스터 처치 / 1 : 아이템 가져오기 / 2 : 특정 행동 하기
        int QuestCount { get; set; } = default; 
        #endregion

        // 생성자
        public QuestClass(string name, int type, int count)
        {
            QuestName = name;
            QuestType = type;
            QuestCount = count;
        }

    }

}
