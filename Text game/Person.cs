using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_game
{
    class Person
    {
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public virtual int Attack { get; set; }
        public int NumPotions { get; set; }
        private const int Potion_increase = 50;
        public bool Alive { get; set; } = true;


        public void UsePotion()
        {
            if (NumPotions>0 && HP<MaxHP-Potion_increase)
            {
                HP = HP + Potion_increase;
            }
            else if (NumPotions>0)
            {
                HP = 100;
            }
            else
            {
                Console.WriteLine("You have no potions");
            }
        }
    }
}
