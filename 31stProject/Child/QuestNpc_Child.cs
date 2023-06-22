using _31stProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31stProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    namespace _31stProject
    {
        public class QuestNpc_Child : NpcClass
        {
            // 생성자
            public QuestNpc_Child(int x, int y) : base(x, y) { }

            // 상태 출력
            public void Get_PrintDialogue()
            {
                Console.Clear();

                string questName = default;
                int type = 0;
                int killCount = Center_Manager.random.Next(0, 10);

                int randomValue = Center_Manager.random.Next(0, 2);
                switch (randomValue)
                {
                    case 0:
                        questName = "슬라임";
                        break;
                    case 1:
                        questName = "고블린";
                        break;
                    case 2:
                        questName = "오크";
                        break;
                }

                Get_GiveDefeatQuest(questName, type, killCount);
            }

            // 처치 퀘스트 지급
            public bool Get_GiveDefeatQuest(string name, int type, int count)
            {
                PlayerClass player = Center_Manager.PC;
                foreach(KeyValuePair<string, QuestClass> index in player.Quest_Dictionary)
                {
                    if (index.Key == name)
                    {
                        Console.WriteLine("같은 퀘스트는 받을 수 없어.\n 좀 있다가 와봐.");
                        Thread.Sleep(1000);
                        return false;
                    }

                }
                Console.WriteLine("안녕 나는 NPC야 {0} {1}마리좀 잡아와", name, count);
                Console.WriteLine("[퀘스트 수락 완료!]");
                Thread.Sleep(1000);
                player.Set_AddQuest(name, type, count);

                return true;
            }

            // 처치 퀘스트 체크
            // 나중에 하기
            public bool Get_CheckDefeatQuest(string name, int type, int count)
            {
                PlayerClass player = Center_Manager.PC;
                foreach (KeyValuePair<string, QuestClass> index in player.Quest_Dictionary)
                {
                    if (index.Key == name)
                    {
                        Console.WriteLine("같은 퀘스트는 받을 수 없어.\n 좀 있다가 와봐.");
                        Thread.Sleep(1000);
                        return false;
                    }

                }
                Console.WriteLine("안녕 나는 NPC야 {0} {1}마리좀 잡아와", name, count);
                Console.WriteLine("[퀘스트 수락 완료!]");
                Thread.Sleep(1000);
                player.Set_AddQuest(name, type, count);

                return true;
            }

        }

    }

}
