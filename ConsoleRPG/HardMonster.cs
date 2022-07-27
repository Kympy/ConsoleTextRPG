using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class HardMonster : Monster
    {
        private string name;
        private int HP;
        private int gold;
        private int exp;
        private int damage;

        public HardMonster()
        {
            name = "고급 콘솔 몬스터";
            HP = 40;
            gold = 100;
            exp = 100;
            damage = 5;
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
