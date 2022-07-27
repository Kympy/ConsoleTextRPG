using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class MainGame
    {
        const int waitTick = 1000 / 30; // Frame Rate

        public static void Main()
        {
            int lastTick = 0; // 마지막 틱
            int currentTick; // 현재 틱
            // 윈도우 크기 세팅
            GameManager.Instance.settings.SetWindow(90, 55);
            // 타일 생성
            GameManager.Instance.mapClass.CreateTile();

            while (true)// 반복
            {
                currentTick = System.Environment.TickCount; // 현재 시간
                if (currentTick - lastTick < waitTick)
                {
                    continue; // 경과 시간이 1 / 30 초 보다 작다면 실행 건너뜀
                }
                else
                {
                    lastTick = currentTick;
                    GameManager.Instance.display.SetCursorZero(); // 커서 위치 초기화
                    GameManager.Instance.input.GetKey(); // 키 입력 감지
                    GameManager.Instance.display.DisplayInfo(); // 정보 표시
                    GameManager.Instance.display.DisplayMap(); // 타일 표시
                    GameManager.Instance.combat.EnterCombat(); // 전투 감지
                    GameManager.Instance.shop.EnterShop(); // 상점 감지
                    if(GameManager.Instance.display.GameOver()) // 게임 오버 감지
                    {
                        return;
                    }
                    if(GameManager.Instance.display.EndGame()) // 게임 종료 감지
                    {
                        return;
                    }
                }
            }
        }
    }
}
