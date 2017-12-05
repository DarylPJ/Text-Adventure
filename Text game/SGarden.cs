using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_game
{
    class SGarden : Places
    {
        private bool Attacked = false;
        private bool GardenerHasKey = true;
        Person Gardener = new Person
        {
            Attack = 3,
            HP = 200,
            MaxHP = 200,
            NumPotions = 1
        };

        public Player Begin(Player MainPlayer)
        {
            this.MainPlayer = MainPlayer;
            string PlayerInput = " ";
            CountersZero();
            Console.Clear();

            if (Gardener.Alive)
            {

                Console.WriteLine($@"You meet one of the kings gardeners. 
Gardeners HP:{Gardener.HP}/{Gardener.MaxHP}, Gardeners Attack power: {Gardener.Attack}.");
                if (!Attacked)
                {
                    Console.WriteLine("Speak to the Gardener by entering S");
                }

                Console.WriteLine(@"Attack the Gardener by entering A
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
                    if (!Attacked && !MainPlayer.CheckItem("Castle Key"))
                    {
                        Console.WriteLine(@"I know why you are here. Despite your scratched face I recognise you.
Please take the castle key from me and this potion.

Press enter to continue");
                        MainPlayer.NewItem("Castle Key");
                        GardenerHasKey = false;
                        MainPlayer.NumPotions += 1;
                        Console.Read();
                    }
                    else if(!Attacked && MainPlayer.CheckItem("Castle Key"))
                    {
                        Console.WriteLine(@"I have already given you the key. Please kill the king

Press enter to continue");
                        Console.Read();

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
            Gardener.HP -= MainPlayer.Attack;

            if (Gardener.HP > 0)
            {

                Console.WriteLine($@"


You attack the Gardener.
Gardener HP -{MainPlayer.Attack} 
New Gardener HP:{Gardener.HP}/{Gardener.MaxHP}

The Gardener attacks you.");
                if (MainPlayer.CheckItem("Armour"))
                {
                    Console.WriteLine("Your HP -{ Gardener.Attack/2} ");
                    MainPlayer.ReduceHealth(Gardener.Attack/2);
                }
                else
                {
                    Console.WriteLine("Your HP -{ Gardener.Attack} ");
                    MainPlayer.ReduceHealth(Gardener.Attack);
                }
            

                if (Gardener.HP<100 && Gardener.NumPotions>0)
                {
                    Console.WriteLine("Gardener uses a health potion.");
                    Gardener.NumPotions -= 1;
                    Gardener.HP += 50;
                    Console.WriteLine($"Gardener HP:{Gardener.HP}/{Gardener.MaxHP}");
                }
            }
            else
            {
                Console.WriteLine($@"


You attack the Gardener.
The Gardener is defeated!!");
                if (GardenerHasKey)
                {
                    GardenerHasKey = false;
                    MainPlayer.NewItem("Castle Key");
                    Console.WriteLine("You find the Castle Door key in the Gardeners coat pocket.");
                }

                Console.WriteLine();
                Console.WriteLine("Press enter to return to the castle door.");
                Gardener.Alive = false;
                Console.Read();
                MainPlayer.Place = "CastleDoor";


            }


            if (MainPlayer.Alive == true && Gardener.Alive == true)
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
