using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_game
{
    class Wepon : Places
    {

        public Player Begin(Player MainPlayer)
        {
            this.MainPlayer = MainPlayer;
            string PlayerInput = " ";
            CountersZero();
            Console.Clear();

            Console.WriteLine(@"You are in a weapon merchant.
There is an old man running the shop and many weapons lay around:
You can speak to the old man by entering S
Return to the village by entering R
or to view player information codes enter P
");



            while (PlayerInput != "S" && PlayerInput != "R")
            {
                PlayerInput = FilterInput(Console.ReadLine());
            }

            switch (PlayerInput)
            {
                case "S":
                    Speak();
                    break;
                case "R":
                    MainPlayer.Place = "Village";
                    break;
            }

            return MainPlayer;
        }

        private void Speak()
        {
            if (MainPlayer.FaceBroken==false)
            {
                FaceBrokenFalse();
            }
            else if(MainPlayer.Sword > 0)
            {
                BoughtSword();
            }
            else
            {
                FaceBrokenTrue();
            }
        }

        private void FaceBrokenTrue()
        {
            int SwordCost;


            if (MainPlayer.CheckItem("Letter from the Tavern"))
            {
                Letter();
            }

            if (MainPlayer.CheckItem("Badge from Weapon Merchant"))
            {
                SwordCost = 10;
            }
            else
            {
                SwordCost = 100;
            }
            


            Console.WriteLine($@"

""Would you like to buy any weapons sir?
We have an excellent sword with an attack power of 40.
For you the price will be only {SwordCost} gold!!""
Enter B to buy
Enter R to return
");
            string PlayerInput = " ";

            while (PlayerInput != "B" && PlayerInput != "R")
            {
                PlayerInput = FilterInput(Console.ReadLine());
            }

            switch (PlayerInput)
            {
                case "B":
                    if (MainPlayer.Gold>=SwordCost)
                    {
                        MainPlayer.Gold -= SwordCost;
                        MainPlayer.Sword += 40;
                        MainPlayer.NewItem("Sword");
                        MainPlayer.Attack = MainPlayer.Attack; //updates attack
                        Console.WriteLine(@"""I hope this sword brings you luck""

press enter to return to the village");
                        Console.Read();
                        

                    }
                    else
                    {
                        Console.WriteLine("You do not have the required funds");
                        Console.WriteLine("Press enter to return to the vilage");
                        Console.Read();
                    }

                    MainPlayer.Place = "Village";
                    break;
                case "R":
                    break;
            }

        }

        private void FaceBrokenFalse()
        {
            Console.WriteLine(@"
""I would love to sell you a sword. However you know that I cannot aid you in your quest. 
The king would surly kill my family if I was to help you. Please leave and return to the
village and don’t show your face here again.""



Press enter to return to the village");

            Console.Read();
            MainPlayer.Place = "Village";


        }

        private void BoughtSword()
        {
            Console.WriteLine(@"""You have already bought a sword from me.
I have nothing else to sell you.""");
            System.Threading.Thread.Sleep(1800);
        }

        private void Letter()
        {
            String PlayerInput = " ";
            Console.WriteLine($@"


Would you like to show the old man the letter from the Tavern?
Enter S to show 
Enter R to return");

            while (PlayerInput != "S" && PlayerInput != "R")
            {
                PlayerInput = FilterInput(Console.ReadLine());
            }

            switch (PlayerInput)
            {
                case "S":
                    Console.WriteLine($@"

Hmmmmmmmm…………….
I understand now what you are trying to achieve.
I will sell you the best sword I have at the cost it was to make it.
For only 10 gold you can now by a sword from my shop. 
Please take this badge for good luck on your quest.
I hope you succeed");

                    MainPlayer.NewItem("Badge from Weapon Merchant");
                    MainPlayer.UseItem("Letter from the Tavern");
                    break;
                case "R":
                    break;
            }

            
        }

    }
}
