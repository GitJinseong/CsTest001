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
                Get_CheckDefeatQuest();

                string questName = default;
                int type = 0;
                int killCount = Center_Manager.random.Next(0, 10);

                Console.WriteLine("어떤 퀘스트를 받을래?\n");
                Console.WriteLine("0. 슬라임을 사냥하기");
                Console.WriteLine("1. 고블린을 퇴치하기");
                Console.WriteLine("2. 오크를 처치하기\n");
                Console.WriteLine("원하는 번호를 눌러줘.");

                char inputValue = Center_Manager.Get_Input();
                
                switch (inputValue)
                {
                    case '0':
                        questName = "슬라임";
                        break;
                    case '1':
                        questName = "고블린";
                        break;
                    case '2':
                        questName = "오크";
                        break;
                    default:
                        Console.WriteLine("잘못된 입력이야!");
                        Thread.Sleep(1000);
                        return;
                }

                Get_GiveDefeatQuest(questName, type, killCount);
            }

            // 처치 퀘스트 지급
            public bool Get_GiveDefeatQuest(string name, int type, int count)
            {
                Console.Clear();
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
                Console.WriteLine("{0}를 {1}마리 잡아오기!", name, count);
                Console.WriteLine("[퀘스트 수락 완료!]");
                player.EnemyKill_Dictionary.Remove(name);
                Thread.Sleep(3000);
                player.Set_AddQuest(name, type, count);

                return true;
            }

            // 처치 퀘스트 체크
            public void Get_CheckDefeatQuest()
            {
                PlayerClass player = Center_Manager.PC;
                foreach (KeyValuePair<string, QuestClass> index in player.Quest_Dictionary)
                {
                    string key = index.Key;
                    QuestClass value = index.Value;
                    foreach (KeyValuePair<string, int> index2 in player.EnemyKill_Dictionary)
                    {
                        if (key == index2.Key)
                        {
                            if (value.QuestCount <= index2.Value)
                            {
                                Console.Clear();
                                Console.WriteLine("{0} 처치 퀘스트를 완료 했다.\n", value.QuestName);
                                player.Quest_Dictionary.Remove(key);
                                player.EnemyKill_Dictionary.Remove(index2.Key);
                                Thread.Sleep(3000);
                                return;
                            }

                        }

                    }  

                }

            }

        }

    }

}
