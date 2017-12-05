using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_game
{
    class Castle : Places
    {
        private Person King = new Person
        {
            Attack = 56,
            HP = 60,
            MaxHP = 80,
            NumPotions = 1
        };


        public Player Begin(Player MainPlayer)
        {
            this.MainPlayer = MainPlayer;
            string PlayerInput = " ";
            CountersZero();
            Console.Clear();

                       
            if (King.Alive == true)
            {
                Console.WriteLine($@"“Welcome to my castle. Have you come to lose again?”
You are filled with rage. It has all been about this moment to avenge your family.
Kings Attack power:{King.Attack} King HP:{King.HP}/{King.MaxHP}

To attack enter A
or to view player information codes enter P
");


                while (PlayerInput != "A")
                {
                    PlayerInput = FilterInput(Console.ReadLine());
                }


                     Battle();

            }


            return MainPlayer;
  
        }

        private void Battle()
        {
            King.HP -= MainPlayer.Attack;

            if (King.HP > 0)
            {

                Console.WriteLine($@"


You attack the King.
King's HP -{MainPlayer.Attack} 
New King's HP:{King.HP}/{King.MaxHP}

The King attacks you.");
                if (MainPlayer.CheckItem("Armour"))
                {
                    Console.WriteLine($"Your HP - {King.Attack / 2}");
                    MainPlayer.ReduceHealth(King.Attack / 2);

                }
                else
                {
                    Console.WriteLine("Your HP -{ King.Attack} ");
                    MainPlayer.ReduceHealth(King.Attack);
                }
                if(King.HP<20 && King.NumPotions > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("The king uses a health potion");
                    King.HP += 50;
                    Console.WriteLine($"King's HP:{King.HP}/{King.MaxHP}");
                }
            }
            else
            {
                Console.WriteLine($@"


You attack the King.
The King is defeated!!

Your quest is fulfilled and you never forgot what has happened. 


Press enter to end the game.");
                MainPlayer.Won = true;
                King.Alive = false;
                Console.Read();
                

            }


            if (MainPlayer.Alive == true && King.Alive==true)
            {
                Console.WriteLine(@"To attack again enter A");

                string PlayerInput = " ";
                while (PlayerInput != "A")
                {
                    PlayerInput = FilterInput(Console.ReadLine());
                }

                    Battle();

                
            }

        }


    }
}
