using _21stProject.ChildClass;
using _21stProject.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _21stProject
{
    public static class DB
    {
        #region 초기 선언부
        public static GameBoard_Manager Game { get; private set; } = new GameBoard_Manager(20);
        public static Monster_Manager Mob { get; private set; } = new Monster_Manager();
        public static Shop_Manager Shop { get; private set; } = new Shop_Manager();
        public static CardGame_Manager CardGame { get; private set; } = new CardGame_Manager();
        public static Battle_Manager Battle { get; private set; } = new Battle_Manager();
        static public Player Player { get; private set; } = new Player(50,50,5,3,100);
        static public Input_Manager Input { get; private set; } = new Input_Manager();
        #endregion

    }

}
