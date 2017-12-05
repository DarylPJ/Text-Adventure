using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_game
{
    class Forest : Places
    {

        public Player Begin(Player MainPlayer)
        {
            this.MainPlayer = MainPlayer;
            string PlayerInput = " ";
            CountersZero();
            Console.Clear();




            Console.WriteLine(@"You are in a nice forest and have stumbled upon a familiar path:
To go to the castle enter C 
To go to the village enter V
To go into the scary woods enter S
To return to the cave enter R
or to view player information codes enter P
");



            while (PlayerInput != "C" && PlayerInput != "V" && PlayerInput != "S" && PlayerInput != "R")
            {
                PlayerInput = FilterInput(Console.ReadLine());
            }

            switch (PlayerInput)
            {
                case "C":
                    MainPlayer.Place = "Monster";
                    break;
                case "V":
                    MainPlayer.Place = "Village";
                    break;
                case "S":
                    MainPlayer.Place = "Scary";
                    break;
                case "R":
                    MainPlayer.Place = "Cave";
                    break;
            }


            return MainPlayer;


        }
    }
}
