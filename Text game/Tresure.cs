using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_game
{
    class Tresure : Places
    {
        private bool GoldPieces = true;
        public Player Begin(Player MainPlayer)
        {
            this.MainPlayer = MainPlayer;
            string PlayerInput = " ";
            CountersZero();
            Console.Clear();


            if (GoldPieces == true)
            {
                Console.WriteLine($@"You have stumbled upon a clearing.
You see a chest and go to open it and find 10 gold coins!!");
                MainPlayer.AddGold(10);
                GoldPieces = false;
            }
            else
            {
                Console.WriteLine($@"
The chest is still here but there is now nothing of value in it");
            }

            Console.WriteLine("When you are ready to return to the scary woods enter R");


            while (PlayerInput != "R")
            {
                PlayerInput = FilterInput(Console.ReadLine());
            }
            MainPlayer.Place = "Scary";
            return MainPlayer;


        }
    }
}
