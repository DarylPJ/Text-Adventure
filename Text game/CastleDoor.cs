using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_game
{
    class CastleDoor : Places
    {

        public Player Begin(Player MainPlayer)
        {
            this.MainPlayer = MainPlayer;
            string PlayerInput = " ";
            CountersZero();
            Console.Clear();




            Console.WriteLine(@"You are at the door to the castle.
The door is in front of you and to each side are the castle gardens.
To go into the castle enter C
To go to the Southern gardens enter S
To go the Northern Gardens enter N 
To return to the Forest enter R
or to view player information codes enter P
");



            while (PlayerInput != "C" && PlayerInput != "S" && PlayerInput != "N" && PlayerInput != "R")
            {
                PlayerInput = FilterInput(Console.ReadLine());
            }

            switch (PlayerInput)
            {
                case "C":
                    if(MainPlayer.CheckItem("Castle Key"))
                    {
                        Console.WriteLine(@"

Once you enter you will not be able to return.

Enter C to continue
or R to retrun");
                        PlayerInput = " ";
                        while (PlayerInput != "C" && PlayerInput != "R")
                        {
                            PlayerInput = FilterInput(Console.ReadLine());
                        }
                        if (PlayerInput == "C")
                        {
                            MainPlayer.Place = "Castle";
                        }
                    }  
                    else
                    {
                        Console.WriteLine("You do not have a key to open the door");
                        Console.WriteLine();
                        Console.WriteLine("Press enter to return");
                        Console.Read();
                    }
                    break;
                case "N":
                    MainPlayer.Place = "NGardens";
                    break;
                case "S":
                    MainPlayer.Place = "SGardens";
                    break;
                case "R":
                    MainPlayer.Place = "Forest";
                    break;
            }


            return MainPlayer;


        }
    }
}
