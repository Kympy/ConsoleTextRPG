using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class Player
    {
        private string name; // 이름
        private int maxHP; // 최대 체력
        private int currentHP; // 현재 체력
        private int itemCount; // 물약 소지 갯수
        private int exp; // 경험치
        private int gold; // 골드
        private int damage; // 공격력
        private int nowX;
        private int nowY;

        public Player() // 초기화
        {
            name = "콘솔맨";
            maxHP = 100;
            currentHP = maxHP;
            itemCount = 1;
            exp = 0;
            gold = 0;
            damage = 10;
            nowX = 0;
            nowY = 0;
        }

        public string GetName()
        {
            return name;
        }
        public int GetCurrentHP()
        {
            return currentHP;
        }
        public int GetMaxHP()
        {
            return maxHP;
        }
        public int GetItemCount()
        {
            return itemCount;
        }
        public int GetEXP()
        {
            return exp;
        }
        public int GetGold()
        {
            return gold;
        }
        public int GetDamage()
        {
            return damage;
        }
        public int GetNowX()
        {
            return nowX;
        }
        public int GetNowY()
        {
            return nowY;
        }
        public void SetName(string newName) // 이름 설정
        {
            name = newName;
        }
        public void SetHP(int X) // 체력 증감
        {
            currentHP += X;
            if (currentHP < 0) currentHP = 0; // 0 밑으로 떨어짐 방지
            if (currentHP > 100) currentHP = 100; // 100 초과로 올라감 방지
        }
        public void SetItemCount(int X) // 아이템 증감
        {
            itemCount += X;
        }
        public void SetEXP(int X) // 경험치 증감
        {
            exp += X;
        }
        public void SetGold(int X) // 골드 증감
        {
            gold += X;
        }
        public void SetNowX(int x) // 상하 이동
        {
            if (nowX + x < 0 || nowX + x > GameManager.Instance.settings.GetHorizontal() - 1)
            {
                return;
            }
            else nowX += x;
        }
        public void SetNowY(int y) // 좌우 이동
        {
            if (nowY + y < 0 || nowY + y > GameManager.Instance.settings.GetVertical() - 1)
            {
                return;
            }
            else nowY += y;
        }
        public void ResetPos(int x, int y) // 플레이어 리셋 (게임 재시작 시)
        {
            nowX = x;
            nowY = y;
        }
        public void UseItem() // 물약 사용
        {
            if(GetItemCount() > 0) // 물약이 1개 이상이고
            {
                if (GetCurrentHP() < 100) // 현재 체력이 100 미만 이면
                {
                    SetHP(10);
                    SetItemCount(-1);
                    GameManager.Instance.display.DisplayInfo();
                }
            }
        }
    }
}
