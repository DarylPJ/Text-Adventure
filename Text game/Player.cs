using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_game
{
    class Player:Person
    {
        public bool FaceBroken { get; set; } = false;
        public string Place { get; set; } = "Cave";
        public int Gold { get; set; } = 0;
        public int Sword { get; set; } = 0;
        public override int Attack { set => base.Attack = value + Sword; }

        public bool Won = false;

        //Item properties
        private List<string> Items = new List<string>();
        public void GetItems()
        {
            Console.WriteLine("Your current Items are:");
            foreach (string item in Items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Number of Potions:" + NumPotions);
        }
        public void NewItem(string item)
        {
            Items.Add(item);
        }
        public void UseItem(string item)
        {
            Items.Remove(item);
        }
 
        public bool CheckItem(string item)
        {
            return Items.Contains(item);
        }


        //reduce health 
        public void ReduceHealth(int reduceHP)
        {
            HP = HP - reduceHP;

            if (HP<=0)
            {
                base.Alive = false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"HP: {HP}/{MaxHP}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        //add Gold
        public void AddGold(int MoreGold)
        {
            Gold += MoreGold;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Gold:{Gold}");
            Console.ForegroundColor = ConsoleColor.White;
        }


        

    }
}
