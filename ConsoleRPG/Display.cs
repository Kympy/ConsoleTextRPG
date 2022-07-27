using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class Display
    {
        const string infoTitle = ">>>> 영웅 정보 <<<<";
        const string nameInfo = "영웅 이름 : ";
        const string HP = "HP :  ";
        const string item = "물약 : ";
        const string exp = "경험치 : ";
        const string gold = "골드 : ";
        const string nowTile = "현재 타일 : ";
        const string danger = "위험도 : ";
        const string setting = "타일 크기 설정 : P";
        const string use = "물약 사용 : F";
        // 맵 좌표
        private int X;
        private int Y;
        // 플레이어 좌표
        private int playerX;
        private int playerY;
        // 커서 위치
        private const int cursorX = 18;
        private const int cursorY = 34;

        public Display()
        {
            Console.CursorVisible = false;
        }
        public void SetCursorZero()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }
        public void DisplayInfo()
        {
            SetCursorZero();
            GetPlayerPos();
            Console.WriteLine(infoTitle + "                " + setting + "  " + use + "  ");
            Console.WriteLine();
            Console.WriteLine(nameInfo + GameManager.Instance.playerClass.GetName());
            Console.WriteLine(HP + GameManager.Instance.playerClass.GetCurrentHP() + " / " + GameManager.Instance.playerClass.GetMaxHP() + "  ");
            Console.WriteLine(item + GameManager.Instance.playerClass.GetItemCount() + "  ");
            Console.WriteLine(exp + GameManager.Instance.playerClass.GetEXP() + "  ");
            Console.WriteLine(gold + GameManager.Instance.playerClass.GetGold() + "  ");
            Console.WriteLine(); Console.WriteLine();
            Console.Write("\t\t  ");
            Console.Write(nowTile);
            switch (GameManager.Instance.mapClass.GetTileType(playerX, playerY))
            {
                case (int)Map.Type.forest:
                    {
                        Console.WriteLine("숲      ");
                        break;
                    }
                case (int)Map.Type.swamp:
                    {
                        Console.WriteLine("늪지    ");
                        break;
                    }
                case (int)Map.Type.flat:
                    {
                        Console.WriteLine("평지    ");
                        break;
                    }
                case (int)Map.Type.shop:
                    {
                        Console.WriteLine("상점    ");
                        break;
                    }
                case (int)Map.Type.start:
                    {
                        Console.WriteLine("시작점");
                        break;
                    }
                case (int)Map.Type.end:
                    {
                        Console.WriteLine("탈출지");
                        break;
                    }
            }
            Console.Write("\t\t  ");
            Console.Write(danger);

            switch (GameManager.Instance.mapClass.GetTileDanger(playerX, playerY))
            {
                case (int)Map.Danger.safe:
                    {
                        Console.WriteLine((int)Map.Danger.safe);
                        break;
                    }
                case (int)Map.Danger.danger:
                    {
                        Console.WriteLine((int)Map.Danger.danger);
                        break;
                    }
                case (int)Map.Danger.VeryDanger:
                    {
                        Console.WriteLine((int)Map.Danger.VeryDanger);
                        break;
                    }
                case (int)Map.Danger.special:
                    {
                        Console.WriteLine(0);
                        break;
                    }
            }
            Console.WriteLine();
        }
        public void GetSize()
        {
            X = GameManager.Instance.settings.GetHorizontal();
            Y = GameManager.Instance.settings.GetVertical();
        }
        public void GetPlayerPos()
        {
            playerX = GameManager.Instance.playerClass.GetNowX();
            playerY = GameManager.Instance.playerClass.GetNowY();
        }
        public void DisplayMap()
        {
            GetSize();
            Console.WriteLine();
            for (int i = 0; i < Y; i++)
            {
                Console.Write("\t\t  ");
                for (int j = 0; j < X; j++)
                {
                    switch (GameManager.Instance.mapClass.GetTileDanger(i, j))
                    {
                        case (int)Map.Danger.safe:
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            }
                        case (int)Map.Danger.danger:
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            }
                        case (int)Map.Danger.VeryDanger:
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            }
                        case (int)Map.Danger.special:
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                break;
                            }
                    }
                    if (i == GameManager.Instance.playerClass.GetNowX() && j == GameManager.Instance.playerClass.GetNowY())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        GameManager.Instance.mapClass.GetTile()[i, j] = '♀';
                        Console.Write(GameManager.Instance.mapClass.GetTile()[i, j]);
                        Console.ResetColor();
                    }
                    else if (GameManager.Instance.mapClass.GetTileType(i, j) == (int)Map.Type.shop) // 타일이 상점 타일이면
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        GameManager.Instance.mapClass.GetTile()[i, j] = '◈';
                        Console.Write(GameManager.Instance.mapClass.GetTile()[i, j]);
                        Console.ResetColor();
                    }
                    else
                    {
                        GameManager.Instance.mapClass.GetTile()[i, j] = '■';
                        Console.Write(GameManager.Instance.mapClass.GetTile()[i, j]);
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write("\t\t  ");
        }
        public void DisplayCombat(bool isCombat)
        {
            GetPlayerPos(); // 플레이어 위치 가져오기
            int Danger = GameManager.Instance.mapClass.GetTileDanger(playerX, playerY); // 현재 위험도 저장
            Monster monster; // 몬스터 저장
            switch (Danger)
            {
                case 1:
                    {
                        monster = new NormalMonster();
                        break;
                    }
                case 2:
                    {
                        monster = new HardMonster();
                        break;
                    }
                default:
                    {
                        monster = new NormalMonster();
                        break;
                    }
            }
            if (isCombat) // 전투중이라면
            {
                GameManager.Instance.combat.isCombat = false;
                while (true)
                {
                    DisplayInfo();
                    ClearBox();
                    if (monster.GetHP() <= 0)
                    {
                        Console.WriteLine("전투에서 승리하였습니다!");
                        Console.Beep();
                        GameManager.Instance.combat.DeleteTile(); // 타일 속성 삭제
                        GameManager.Instance.playerClass.SetEXP(monster.GetEXP()); // 경험치 획득
                        GameManager.Instance.playerClass.SetGold(monster.GetGold()); // 골드 획득
                        Thread.Sleep(1000);
                        return;
                    }
                    Console.WriteLine(monster.GetName() + " 발견!! 전투를 시작합니다. 남은 체력 : " + monster.GetHP());
                    Console.WriteLine(); Console.Write("\t\t  홀(1), 짝(2)을 입력하세요 : ");
                    Console.CursorVisible = true;
                    int temp = int.Parse(Console.ReadLine()); // 유저 입력 받기
                    int tempX = monster.RandNum(); // 몬스터 랜덤 넘버 받기
                    Console.WriteLine("\t\t  " + tempX);
                    if (temp != 1 && temp != 2) // 1과 2가 아닌 값일 경우
                    {
                        Console.WriteLine("\t\t  다시 입력하세요");
                        Thread.Sleep(1000);
                        continue;
                    }
                    if ((temp == 2 && tempX % 2 == 0) || (temp == 1 && tempX % 2 != 0)) // 홀짝 맞췄다면
                    {
                        Console.WriteLine("\t\t  " + GameManager.Instance.playerClass.GetDamage() + " 의 데미지 공격 성공!");
                        monster.SetHP(-GameManager.Instance.playerClass.GetDamage()); // 몬스터 체력 감소
                        Thread.Sleep(1000);
                        ClearBox();
                    }
                    else // 홀수라면
                    {
                        Console.WriteLine("\t\t  공격 실패!" + monster.GetDamage() + " 의 데미지를 입었습니다.");
                        GameManager.Instance.playerClass.SetHP(-monster.GetDamage()); // 플레이어 체력 감소
                        Thread.Sleep(1000);
                        ClearBox();
                    }
                }
            }
            else
            {
                ClearBox(); // 화면 클리어
            }
        }
        public void DisplayShop() // 상점 이벤트
        {
            ClearBox();
            if (GameManager.Instance.playerClass.GetGold() >= 50) // 최소 소지금 부족 시 상점 입장 불가
            {
                while (true)
                {
                    ClearBox();
                    Console.WriteLine("HP 물약 : 50 Gold      종료 : 0\n");
                    Console.Write("\t\t  구매할 물약의 수량을 입력하세요 : ");
                    int temp = int.Parse(Console.ReadLine());
                    if (temp == 0) // 0 입력 시 상점 종료
                    {
                        GetPlayerPos();
                        GameManager.Instance.mapClass.SetTileNormal(playerX, playerY);
                        GameManager.Instance.mapClass.SetTileSafe(playerX, playerY);
                        return;
                    }
                    if (50 * temp <= GameManager.Instance.playerClass.GetGold())
                    {
                        GameManager.Instance.playerClass.SetItemCount(temp); // 물약 수량 증가
                        GameManager.Instance.playerClass.SetGold(-50 * temp); // 골드 감소
                        Console.WriteLine();
                        Console.WriteLine("\t\t  HP 물약 {0}개구매 성공", temp);
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("\t\t  소지금이 부족합니다.");
                        Thread.Sleep(1000);
                    }
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("\t\t  소지금이 부족합니다.");
                Thread.Sleep(1000);
                ClearBox();
            }
        }
        private void ClearBox() // 설명 화면 지우고 커서 제자리
        {
            Console.SetCursorPosition(cursorX, cursorY);
            Console.WriteLine("                                                                   ");
            Console.WriteLine("                                                                   ");
            Console.WriteLine("                                                                   ");
            Console.WriteLine("                                                                   ");
            Console.WriteLine("                                                                   ");
            Console.WriteLine("                                                                   ");
            Console.WriteLine("                                                                   ");
            Console.WriteLine("                                                                   ");
            Console.WriteLine("                                                                   ");
            Console.WriteLine("                                                                   ");
            Console.WriteLine("                                                                   ");
            Console.WriteLine("                                                                   ");
            Console.WriteLine("                                                                   ");
            Console.WriteLine("                                                                   ");
            Console.WriteLine("                                                                   ");
            Console.SetCursorPosition(cursorX, cursorY);
        }
        public bool EndGame() // 도착 지점 도착 시 true 반환
        {
            GetPlayerPos();
            if (GameManager.Instance.mapClass.GetTileType(playerX, playerY) == (int)Map.Type.end)
            {
                ClearBox();
                Console.WriteLine("탈출에 성공했습니다!");
                Console.WriteLine("\t\t  게임을 종료합니다.");
                return true;
            }
            else return false;
        }
        public void Setting() // 타일 세팅 변경
        {
            ClearBox();
            while(true)
            {
                Console.WriteLine("게임 설정을 변경합니다. 10이상 30 이하로 입력하세요. 취소 : 0 ");
                Console.Write("\t\t  가로 사이즈를 입력하세요 : ");
                Console.CursorVisible = true;
                int tempX = int.Parse(Console.ReadLine());
                if (tempX == 0)
                {
                    ClearBox();
                    return;
                }
                if (tempX > 30 || tempX < 10)
                {
                    ClearBox();
                    Console.WriteLine("10이상 30 이하로 입력하세요.");
                    Thread.Sleep(1000);
                    continue;
                }
                else
                {
                    while (true)
                    {
                        Console.Write("\t\t  세로 사이즈를 입력하세요 : ");
                        int tempY = int.Parse(Console.ReadLine());
                        if (tempY > 30 || tempY < 10)
                        {
                            ClearBox();
                            Console.WriteLine("10이상 30 이하로 입력하세요.");
                            Thread.Sleep(1000);
                            continue;
                        }
                        else
                        {
                            ClearBox();
                            Console.WriteLine("게임이 재시작 됩니다...");
                            Thread.Sleep(1000);
                            GameManager.Instance.settings.SetTileSize(tempX, tempY);
                            return;
                        }
                    }
                }
            }

        }
        public bool GameOver()
        {
            if (GameManager.Instance.playerClass.GetCurrentHP() <= 0)
            {
                ClearBox();
                Console.WriteLine("체력이 모두 소진되었습니다!");
                Console.WriteLine("\t\t  게임을 종료합니다.");
                return true;
            }
            else return false;
        }
    }
}
