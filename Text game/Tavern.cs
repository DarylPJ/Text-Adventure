using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_game
{
    class Tavern : Places
    {
        private bool SpokenAboutGold = false;
        private bool HasPotion = true;
        public Player Begin(Player MainPlayer)
        {
            this.MainPlayer = MainPlayer;
            CountersZero();
            Console.Clear();

            if (MainPlayer.FaceBroken)
            {
                FaceBroken();
            }
            else
            {
                FaceFine();
            }

            
            return MainPlayer;
        }



        private void FaceFine()
        {
            Console.WriteLine(@"You are in an old tavern.
There are some empty tables and a bar.
Behind the bar is a young woman.
To approach the bar and speak to the women enter S
To return to the village enter R
or to view player information codes enter P");

            string PlayerInput = " ";
            while (PlayerInput != "S" && PlayerInput != "R")
            {
                PlayerInput = FilterInput(Console.ReadLine());
            }

            switch (PlayerInput)
            {
                case "S":
                    Console.WriteLine(@"

""You know I can’t speak with you.
As much as I would like to help you I can’t!!
If I am even caught talking with you the kings guards will come and torture me.""


press enter to continue");
                    Console.Read();

                    break;
                case "R":
                    MainPlayer.Place = "Village";
                    break;
            }
        }

        private void FaceBroken()
        {
            Console.Clear();
            Console.WriteLine(@"You are in an old tavern.
There are some tables and a bar.
Behind the bar is a young woman.
Sat around one of the tables are some pirates
To approach the bar and speak to the women enter S
To approach the pirates and speak to them enter A");
            if (SpokenAboutGold)
            {
                Console.WriteLine("To approach the empty table and sit down enter E");
            }
            Console.WriteLine(@"To return to the village enter R
or to view player information codes enter P");
            FaceBrokenInput();
        }

        private void FaceBrokenInput()
        {
            String PlayerInput = " ";
            while (PlayerInput != "S" && PlayerInput != "A" && PlayerInput != "E" && PlayerInput != "R")
            {
                PlayerInput = FilterInput(Console.ReadLine());
            }

            switch (PlayerInput)
            {
                case "S":
                    Console.WriteLine(@"

Id recognise you anywhere!!
What an incredible idea to keep your cover by scratching your face.
If I can help you in anyway to overthrow the king just ask:

To ask about improving your Health enter E
To ask about getting gold enter D
To ask about getting a weapon enter W
To stop taking to the women at the bar enter R");
                    Bar();
                    break;
                case "A":
                    Console.WriteLine(@"

""What arr you doing here?""

To talk about where to get gold enter D
To talk about how to increase your health enter E
To talk about Wepons enter W
To stop taking to the pirates enter R");
                    Pirates();
                    break;
                case "E":
                    if (SpokenAboutGold)
                    {
                        Emptytable();
                    }
                    else
                    {
                        FaceBroken();
                    }
                    break;
                case "R":
                    MainPlayer.Place = "Village";
                    break;
            }
        }

        private void Bar()
        {
            String PlayerInput = " ";
            while (PlayerInput != "D" && PlayerInput != "E" && PlayerInput != "R" && PlayerInput != "W")
            {
                PlayerInput = FilterInput(Console.ReadLine());
            }

            Console.WriteLine(@"

                                ");
            switch (PlayerInput)
            {
                case "D":

                    Console.WriteLine(@"The pirates are constantly speaking about their treasure.
Problem is they would never tell you where it is.
Maybe if you sit on an empty table nearby you might overhear them talking.");
                    SpokenAboutGold = true;
                    Bar();

                    break;
                case "E":
                    if (!MainPlayer.CheckItem("Sword"))
                    {
                        Console.WriteLine(@"Talk to me about improving your health once you have a sword.
Our top priority is for you to be able to attack the king and you can’t do that without a sword!!");
                    }
                    else if (HasPotion && !MainPlayer.CheckItem("Cross"))
                    {
                        Console.WriteLine(@"I have one potion left. It will give you restore 50HP.
I will sell you it for only 5 gold. That’s less than I paid for it!!

Enter B to buy
Enter R to not buy");
                        
                        while (PlayerInput != "B" && PlayerInput != "R")
                        {
                            PlayerInput = FilterInput(Console.ReadLine());
                        }

                        Console.WriteLine(@"

                                            ");
                        if (PlayerInput == "B")
                        {
                            if (MainPlayer.Gold >= 5)
                            {
                                MainPlayer.Gold -= 5;
                                MainPlayer.NumPotions += 1;
                                Console.WriteLine("I hope this potion is useful to your quest");
                            }
                            else
                            {
                                Console.WriteLine("You don’t have the required funds");
                            }
                        }
                    
                    }
                    else if(!HasPotion)
                    {
                        Console.WriteLine("I unfortunately don’t have any other potions to sell you.");
                    }
                    else
                    {
                        Console.WriteLine(@"You have all the health you could need as a member of the clergy.
I couldn’t give you anything that would help you anymore than you have already been helped.
With god on your side I’m sure your health will always be the best.");
                    }

                    Bar();

                    break;
                case "W":

                    if (MainPlayer.CheckItem("Sword"))
                    {
                        Console.WriteLine(@"Well done on buying the sword. Now you can show the king whose boss!");
                    }
                    else if(MainPlayer.CheckItem("Badge from Weapon Merchant"))
                    {
                        Console.WriteLine(@"I see you gave the letter to the Weapon Merchant.
I hope you can afford a sword now.");
                    }
                    else if(MainPlayer.CheckItem("Letter from the Tavern"))
                    {
                        Console.WriteLine("Take the letter I gave you to the Weapon Merchant");
                    }
                    else
                    {
                        Console.WriteLine(@"The Weapon Merchant should be able to sell you a sword.
However his prices are very high. 
Please take this letter to him.
It explains that you need a weapon to defeat the king.
He should lower the price he sells you the sword for.
");
                        MainPlayer.NewItem("Letter from the Tavern");
                    }
                    Bar();

                    break;
                case "R":
                    break;
            }





        }

        private void Emptytable()
        {
            Console.WriteLine(@"

""Where did yeh hide the treasure?""

""It’s safe in the dark woods. No one will find it
You just go right 5 times in a row.""

Press enter to leave the table");

            Console.Read();
            

        }

        private void Pirates()
        {

            String PlayerInput = " ";
            while (PlayerInput != "D" && PlayerInput != "E" && PlayerInput != "R" && PlayerInput != "W")
            {
                PlayerInput = FilterInput(Console.ReadLine());
            }

            switch (PlayerInput)
            {
                case "D":
                    Console.WriteLine(@"

""We are not going to tell you anything about our treasure!!""");
                    Pirates();
                    break;
                case "E":
                    Console.WriteLine(@"

Our health is always improved buy some rum!!");
                    Pirates();
                    break;
                case "W":
                    Console.WriteLine($@"

…………Yee not gettin’ me sword ");
                    Pirates();
                    break;
                case "R":
                    break;
            }

        }


    }
}
