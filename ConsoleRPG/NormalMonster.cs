using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class NormalMonster : Monster
    {
        private string name;
        private int HP;
        private int gold;
        private int exp;
        private int damage;
        public NormalMonster()
        {
            name = "일반 콘솔 몬스터";
            HP = 20;
            gold = 50;
            exp = 100;
            damage = 2;
        }
        Random rand = new Random();
        public override string GetName()
        {
            return name;
        }
        public override int GetHP()
        {
            return HP;
        }
        public override int GetGold()
        {
            return gold;
        }
        public override int GetEXP()
        {
            return exp;
        }
        public override int GetDamage()
        {
            return damage;
        }
        public override void SetHP(int damage)
        {
            HP += damage;
        }
        public override int RandNum()
        {
            return rand.Next(1, 10);
        }
    }
}
