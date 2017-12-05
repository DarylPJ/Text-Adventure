using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_game
{
    class ScaryWoods : Places
    {
        private int GettingOutnum;
        private int Tresure;
       
        public Player Begin(Player MainPlayer)
        {
            this.MainPlayer = MainPlayer;
            CountersZero();
            GettingOutnum = 1;
            Tresure = 1;





            StartText();
            GettingLost();
            


            return MainPlayer;

        }

        private void StartText()
        {
            Console.Clear();
            Console.WriteLine(@"You are lost and afraid all you can do is walk in 4 directions:
Walk forwards by entering F
backwards by entering B
Left by entering L
Right by entering R
or to view player information codes enter P
");
        }

        private void EndText()
        {
            Console.WriteLine("You are back where you started");
            System.Threading.Thread.Sleep(800);
        }

        private void GettingLost()
        {
            string PlayerInput = " ";
            while(PlayerInput != "L" && PlayerInput != "R" && PlayerInput != "B" && PlayerInput != "F")
            {
                PlayerInput = FilterInput(Console.ReadLine());
            }

            if (PlayerInput == "F" && GettingOutnum==1)
            {
                GettingOutnum++;
                GettingLost();
                Tresure = 1;
            }
            else if(PlayerInput == "R" && GettingOutnum == 2)
            {
                GettingOutnum++;
                GettingLost();
            }
            else if(PlayerInput == "F" && GettingOutnum == 3)
            {
                MainPlayer.Place = "Cave";
                Console.WriteLine("You finally stumble out of the dark forrest and somehow end up back at your cave");
                System.Threading.Thread.Sleep(3500);
            }
            else if(PlayerInput == "R" && Tresure < 5)
            {
                EndText();
                StartText();
                Tresure++;
                GettingOutnum = 1;
                CountersZero();
                GettingLost();
                
            }
            else if (PlayerInput == "R" && Tresure == 5)
            {
                MainPlayer.Place = "Tresure";
            }
            else
            {
                EndText();
            }
            
               
            
        }
    }
}
