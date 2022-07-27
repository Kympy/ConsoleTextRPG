using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class GameManager : Singleton<GameManager> // 싱글톤 상속
    {
        // 게임 관련 클래스
        public GameSettings settings;
        public Map mapClass;
        public Player playerClass;
        public Display display;
        public InputMananger input;
        public Combat combat;
        public Shop shop;

        public GameManager()
        {
            display = new Display();
            settings = new GameSettings();
            mapClass = new Map();
            playerClass = new Player();
            input = new InputMananger();
            combat = new Combat();
            shop = new Shop();
        }
    }
}
