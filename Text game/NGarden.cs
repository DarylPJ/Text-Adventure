using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_game
{
    class NGarden : Places
    {
        private bool Attacked = false;
        private Person Guard = new Person
        {
            Attack = 18,
            HP = 140,
            MaxHP = 140,
            NumPotions = 0
        };

        public Player Begin(Player MainPlayer)
        {
            this.MainPlayer = MainPlayer;
            string PlayerInput = " ";
            CountersZero();
            Console.Clear();

            if (Guard.Alive)
            {

                Console.WriteLine($@"You meet one of the kings Guards. Behind the guard is some Armour. 
Guards HP:{Guard.HP}/{Guard.MaxHP}, Guards Attack power: {Guard.Attack}.");
                if (!Attacked)
                {
                    Console.WriteLine("Speak to the Guard by entering S");
                }

                Console.WriteLine(@"Attack the Guard by entering A
Return to the Castle Entrance by entering R
or to view player information codes enter P
");

                while (PlayerInput != "A" && PlayerInput != "S" && PlayerInput != "R")
                {
                    PlayerInput = FilterInput(Console.ReadLine());
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            else
            {
                PlayerInput = "R";
                Console.WriteLine("There is nothing of interest here");
                System.Threading.Thread.Sleep(1500);
            }
            switch (PlayerInput)
            {
                case "A":
                    Attacked = true;


                    Battle();

                    break;
                case "S":
                    if (!Attacked)
                    {
                        Console.WriteLine(@"No one except the king and his guards are allowed here prepare to die!");
                        Console.WriteLine($@"The Guard attacks you.
Your HP -{ Guard.Attack}");
                        MainPlayer.ReduceHealth(Guard.Attack);
                        Console.WriteLine(@"

Press enter to continue");
                        Console.Read();
                        Attacked = true;
                    }
                    


                    break;
                case "R":
                    MainPlayer.Place = "CastleDoor";
                    break;
            }


            return MainPlayer;


        }


        private void Battle()
        {
            Guard.HP -= MainPlayer.Attack;

            if (Guard.HP > 0)
            {

                Console.WriteLine($@"


You attack the Guard.
Guard HP -{MainPlayer.Attack} 
New Guard HP:{Guard.HP}/{Guard.MaxHP}

The Guard attacks you.
Your HP -{Guard.Attack}");
            MainPlayer.ReduceHealth(Guard.Attack);
            }
            else
            {
                Console.WriteLine($@"


You attack the Guard.
The Guard is defeated!!");

                Console.WriteLine(@"

The guard is defeated and you receive a potion and some armour

");
                Console.WriteLine("Press enter to return to the castle door.");
                Guard.Alive = false;
                MainPlayer.NumPotions += 1;
                MainPlayer.NewItem("Armour");
                Console.Read();
                MainPlayer.Place = "CastleDoor";


            }


            if (MainPlayer.Alive == true && Guard.Alive == true)
            {
                Console.WriteLine(@"To attack again enter A
To run away to the Castle Door enter C");

                string PlayerInput = " ";
                while (PlayerInput != "A" && PlayerInput != "C")
                {
                    PlayerInput = FilterInput(Console.ReadLine());
                }

                switch (PlayerInput)
                {
                    case "C":
                        MainPlayer.Place = "CastleDoor";
                        break;
                    case "A":
                        Battle();
                        break;
                }
            }

        }
    }
}
