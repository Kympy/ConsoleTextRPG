using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class Shop
    {
        // 플레이어 위치
        private int X;
        private int Y;
        public void EnterShop()
        {
            X = GameManager.Instance.playerClass.GetNowX();
            Y = GameManager.Instance.playerClass.GetNowY();
            // 밟고 있는 타일이 상점이라면
            if(GameManager.Instance.mapClass.GetTileType(X, Y) == (int)Map.Type.shop)
            {
                GameManager.Instance.display.DisplayShop(); // 상점 표시
            }
        }
    }
}
