using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public abstract class Monster
    {
        public abstract string GetName();
        public abstract int GetHP();
        public abstract int GetEXP();
        public abstract int GetGold();
        public abstract int GetDamage();
        public abstract void SetHP(int damage);
        public abstract int RandNum();
    }
}
