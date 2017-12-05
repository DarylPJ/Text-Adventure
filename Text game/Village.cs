using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_game
{
    class Village : Places
    {

        public Player Begin(Player MainPlayer)
        {
            this.MainPlayer = MainPlayer;
            string PlayerInput = " ";
            CountersZero();
            Console.Clear();




            Console.WriteLine(@"You have entered a village you can:
Go to the weapon merchant by entering W 
Go to the church by entering C
Go to the tavern by entering N
return to the forest by entering R
or to view player information codes enter P
");



            while (PlayerInput != "W" && PlayerInput != "C" && PlayerInput != "N" && PlayerInput != "R")
            {
                PlayerInput = FilterInput(Console.ReadLine());
            }

            switch (PlayerInput)
            {
                case "C":
                    MainPlayer.Place = "Church";
                    break;
                case "W":
                    MainPlayer.Place = "Wepons";
                    break;
                case "N":
                    MainPlayer.Place = "Tavern";
                    break;
                case "R":
                    MainPlayer.Place = "Forest";
                    break;
            }


            return MainPlayer;


        }
    }
}
