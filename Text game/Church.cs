using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_game
{
    class Church : Places
    {
        bool Isgoldthere = true;

        string PlayerInput;
        public Player Begin(Player MainPlayer)
        {
            this.MainPlayer = MainPlayer;
            PlayerInput = " ";
            CountersZero();
            Console.Clear();

            if (!MainPlayer.FaceBroken)
            {
                GoodFace();
            }
            else
            {
                BrokenFace();
            }


            MainPlayer.Place="Village";
            return MainPlayer;


        }

        private void GoodFace()
        {
            Console.WriteLine(@"The church cannot allow you in. 
We are a place of worship and peace

Press enter to return to the village");
            Console.Read();
        }

        private void BrokenFace()
        {
            Console.Clear();
            PlayerInput = " ";
            Console.Write(@"You are in a church there is a family praying you can:
Go to the collection plate by entering C
Approch the family by entering F
Talk to the priest by entering E
To return to the village enter R
or to view player information codes enter P
");

            while (PlayerInput != "C" && PlayerInput != "F" && PlayerInput != "E" && PlayerInput != "R")
            {
                PlayerInput = FilterInput(Console.ReadLine());
            }
            Console.WriteLine();
            Console.WriteLine();
            switch (PlayerInput)
            {
                case "C":
                    CollectionPlate();
                    break;
                case "F":
                    Console.WriteLine(@"You have approached the family you can:

To ask about improving your Health enter E
To ask about getting gold enter D
To ask about getting a weapon enter W
To stop taking to the women at the bar enter R
");
                    Family();
                    break;
                case "E":
                    Priest();
                    break;
                case "R":
                    break;
            }

            
        }

        private void CollectionPlate()
        {
            if (Isgoldthere && !MainPlayer.CheckItem("Cross"))
            {
                Console.WriteLine(@"There is a collection plate with 5 gold pieces on it:
To steal the gold enter S
To return enter R
");

                while (PlayerInput != "S" && PlayerInput != "R")
                {
                    PlayerInput = FilterInput(Console.ReadLine());
                }

                if (PlayerInput=="S")
                {
                    MainPlayer.AddGold(5);
                    Isgoldthere = false;
                    Console.WriteLine("Press enter to continue");
                    Console.Read();
                }

                
            }
            else if(!Isgoldthere)
            {
                Console.WriteLine(@"You have already taken the gold

Press enter to continue
");
                Console.Read();

            }
            else
            {
                Console.WriteLine(@"As a member of the church you are happy to see 5 gold on the donation plate.

Press enter to contine");
                Console.Read();
            }

            BrokenFace();
        }


        private void Family()
        {
            PlayerInput = " ";


            while (PlayerInput != "E" && PlayerInput != "R" && PlayerInput != "D" && PlayerInput != "W")
            {
                PlayerInput = FilterInput(Console.ReadLine());
            }

            switch (PlayerInput)
            {
                case "E":
                    Console.WriteLine(@"

We have no need to improve our health. The light of God means we are always at our maximum health.
");
                    
                    Family();
                    break;
                case "R":
                    BrokenFace();
                    break;
                case "D":
                    Console.WriteLine(@"

Money is of no concern to us. The Lord provides everything we could ever need. 
");
                    Family();
                    break;
                case "W":
                    Console.WriteLine(@"

We have no need for weapons. The good Lord will protect us from any threats.
");
                    Family();
                    break;
                    
                    
            }
                

        }

        private void Priest()
        {
            if (Isgoldthere)
            {
                Console.WriteLine(@"Your face!! 
God can heal all!
Come and join the clergy.
For a life without sin and the chance to share gods message join today

To join enter J
To return enter R
");
                while (PlayerInput != "J" && PlayerInput != "R")
                {
                    PlayerInput = FilterInput(Console.ReadLine());
                }

                if (PlayerInput=="J")
                {
                    Console.WriteLine(@"

You spend 2 years preaching the word of god.
Over that time you learned inner peace and your total health increased.
You now carry a cross around with you to remember you faith at all times");
                    MainPlayer.MaxHP = 125;
                    int Healthdiff = MainPlayer.MaxHP - MainPlayer.HP;
                    MainPlayer.ReduceHealth(-Healthdiff);
                    Console.WriteLine(@"

Press enter to continue");
                    MainPlayer.NewItem("Cross");
                    Console.Read();
                    
                }
               

                
            }
            else
            {
                Console.WriteLine(@"I know what you did.
Stealing from the church!!!!! 
Some people cannot be helped.

Press enter to continue");
                Console.Read();
            }


            BrokenFace();
        }
    }
}
