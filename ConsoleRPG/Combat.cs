using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class Combat
    {
        int X; // 플레이어 타일 좌표
        int Y;
        int Danger; // 위험도
        public bool isCombat = false; // 전투 중 인지
        public void EnterCombat()
        {
            X = GameManager.Instance.playerClass.GetNowX();
            Y = GameManager.Instance.playerClass.GetNowY();
            Danger = GameManager.Instance.mapClass.GetTileDanger(X, Y);

            switch(Danger)
            {
                case 1: // 위험도 1
                    {
                        isCombat = true;
                        GameManager.Instance.display.DisplayCombat(isCombat);
                        break;
                    }
                case 2: // 위험도 2
                    {
                        isCombat = true;
                        GameManager.Instance.display.DisplayCombat(isCombat);
                        break;
                    }
                case 0:
                    {
                        isCombat = false;
                        GameManager.Instance.display.DisplayCombat(isCombat);
                        break;
                    }
            }
        }
        public void DeleteTile() // 처치된 타일 안전하게
        {
            X = GameManager.Instance.playerClass.GetNowX();
            Y = GameManager.Instance.playerClass.GetNowY();
            GameManager.Instance.mapClass.SetTileSafe(X, Y); // 타일 위험도 safe
        }
    }
}
