using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_game
{
    class Cave:Places
    {
        
        public Player Begin(Player MainPlayer)
        {
            this.MainPlayer = MainPlayer;
            string PlayerInput = " ";
            CountersZero();
            Console.Clear();




                Console.WriteLine(@"You are in the cave you can:    
Leave by Entering L
stay and die of natural causes by Entering S
or to view player information codes enter P");



            while (PlayerInput != "L" && PlayerInput != "S")
            {
                PlayerInput = FilterInput(Console.ReadLine());
            }

            switch (PlayerInput)
            {
                case "S":
                    Console.WriteLine($@"
You find a nice spot and decide to lay down.
You think about all that was and all that could have been.
You are so hungry and weak.....
Bye
cruel
world
...
...
...
...
");
                    MainPlayer.ReduceHealth(1);
                    Stay();
                    break;
                case "L":
                    MainPlayer.Place = "Forest";
                    break;
            }


            return MainPlayer;
              

        }

        private void Stay()
        {

            Console.WriteLine($@"
To stand back up and carry on enter S
If you enter anything else natural causes will take you");
            string stand = Console.ReadLine();
            stand = stand.ToUpper();
            switch (stand)
            {
                case "S":
                    Console.WriteLine("That is right you have so much to live for. Go!! Go!!");
                    break;
                default:
                    MainPlayer.ReduceHealth(1);
                    while (MainPlayer.HP != 12 && MainPlayer.HP != 7 && MainPlayer.HP != 2 && MainPlayer.Alive==true)
                    {
                        System.Threading.Thread.Sleep(800);
                        MainPlayer.ReduceHealth(1);
                        if ((MainPlayer.HP==21 || double.Parse(MainPlayer.HP.ToString())%20.0==0) && MainPlayer.HP!=20 && MainPlayer.HP!=0)
                        {
                            break;
                        }
                        
                    }

                    switch (MainPlayer.HP)
                    {
                        case 12:
                            Console.WriteLine("You can't stay here there is an adventure to be had.");
                            Stay();
                            break;
                        case 7:
                            Console.WriteLine($@"
You are just going to stay here and die...
The game is fairly fun I mean its ok. But you’re just going to stay here and die??? 
I’m giving you another chance but this is it!!
");
                            Stay();
                            break;
                        case 2:
                            Console.WriteLine($@"
Are you actually real? I mean what sort of person plays a game and then just decides to lie down. 
You understand this isn’t actually going to happen. I spent a lot of time writing this game. 
A game that YOU clearly don’t appreciate.



FINE!!! DIE! See if I care. This is your final chance if you went through the hassle of installing
this game just to lay down and die of natural causes you are beyond help.
"); 
                            Stay();
                            break;
                        case 0:
                            break;
                        default:
                            Console.WriteLine("You have a second chance.");
                            Stay();
                            break;
                    }
                    break;
            }
        }
    }
}
