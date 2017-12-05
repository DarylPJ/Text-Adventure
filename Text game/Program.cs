using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_game
{

    class Program
    {

        static void Main(string[] args)
        {

            Console.WindowWidth = 100;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WindowHeight = 45;

            while (true)
            {

                var CaveLocation = new Cave();
                var ForestLocation = new Forest();
                var ScaryLocation = new ScaryWoods();
                var TresureLocation = new Tresure();
                var MonsterLocation = new MonsterLoc();
                var VillageLocation = new Village();
                var WeponLocation = new Wepon();
                var TavernLocation = new Tavern();
                var ChurchLocation = new Church();
                var CastleDoorLocation = new CastleDoor();
                var SGardenLocation = new SGarden();
                var NGardenLocation = new NGarden();
                var CastleLocation = new Castle();

                var MainPlayer = new Player
                {
                    Attack = 5,
                    HP = 20,
                    MaxHP = 100,
                    NumPotions = 0
                };


                Console.WriteLine($@"You have escaped a fight with the king of Alcombey. Running from the castle you get lost
in the forest and end up hiding in a cave. Your mission is to avenge your family and show
the king that he cannot continue to repress the people and murder those who speak out about him.




Press enter to begin
");


                Console.Read();


                while (MainPlayer.Alive == true)
                {
                    switch (MainPlayer.Place)
                    {
                        case "Cave":
                            MainPlayer = CaveLocation.Begin(MainPlayer);
                            break;
                        case "Forest":
                            MainPlayer = ForestLocation.Begin(MainPlayer);
                            break;
                        case "Scary":
                            MainPlayer = ScaryLocation.Begin(MainPlayer);
                            break;
                        case "Tresure":
                            MainPlayer = TresureLocation.Begin(MainPlayer);
                            break;
                        case "Monster":
                            MainPlayer = MonsterLocation.Begin(MainPlayer);
                            break;
                        case "Village":
                            MainPlayer = VillageLocation.Begin(MainPlayer);
                            break;
                        case "Wepons":
                            MainPlayer = WeponLocation.Begin(MainPlayer);
                            break;
                        case "Tavern":
                            MainPlayer = TavernLocation.Begin(MainPlayer);
                            break;
                        case "Church":
                            MainPlayer = ChurchLocation.Begin(MainPlayer);
                            break;
                        case "CastleDoor":
                            MainPlayer = CastleDoorLocation.Begin(MainPlayer);
                            break;
                        case "SGardens":
                            MainPlayer = SGardenLocation.Begin(MainPlayer);
                            break;
                        case "NGardens":
                            MainPlayer = NGardenLocation.Begin(MainPlayer);
                            break;
                        case "Castle":
                            MainPlayer = CastleLocation.Begin(MainPlayer);
                            break;


                    }
                    if (MainPlayer.Won == true)
                    {
                        break; 
                    }

                }

                if (MainPlayer.Alive == false)
                {
                    Console.WriteLine("You die!!");
                    System.Threading.Thread.Sleep(2500);
                    Console.Clear();
                }

            }
        }
    }
}
