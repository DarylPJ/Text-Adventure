using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_game
{
    class MonsterLoc : Places
    {
        private Person Monster = new Person
        {
            Attack = 10,
            HP = 200,
            MaxHP = 200,
            NumPotions = 0
        };
        private int counter = 0;


        public Player Begin(Player MainPlayer)
        {
            this.MainPlayer = MainPlayer;
            string PlayerInput = " ";
            CountersZero();
            Console.Clear();


            if (counter == 0)
            {
                Console.WriteLine($@"You are stopped on the way to the castle by a large monster.
Monster Attack power:{Monster.Attack} Monster HP:{Monster.HP}/{Monster.MaxHP}
The monster looks at you for a long time and asks why you are traveling this way.
You say you are from a different realm and here to visit the castle.
The monster says that security is now high due to a battle that threatened the
royal family only recently and that no one is allowed through.

You can:
Enter R to return to the forest
Enter A to attack the monster
or to view player information codes enter P
");

                while (PlayerInput != "R" && PlayerInput != "A")
                {
                    PlayerInput = FilterInput(Console.ReadLine());
                }

                switch (PlayerInput)
                {
                    case "R":
                        MainPlayer.Place = "Forest";
                        break;
                    case "A":


                        counter++;
                        Monster.HP -= MainPlayer.Attack;
                        Console.WriteLine($@"

You attack the monster.
Monster HP -{MainPlayer.Attack} 
New monster HP:{Monster.HP}/{Monster.MaxHP}

The monster looks at you and begins laughing. 
“You thought you could defeat me with your fists!!” the monster yells.
If you attack me again I will mess up that pretty face of yours.

To continue press enter");
                        Console.Read();




                        break;
                }


            }
            else if (counter == 1)
            {
                Console.WriteLine($@"The monster looks angry at you.
Monster Attack power:{Monster.Attack} Monster HP:{Monster.HP}/{Monster.MaxHP}
If you attack you have no hope of winning.
The monster said he would mess up your face if you attack.

You can:
Enter R to return to the forest
Enter A to attack the monster
or to view player information codes enter P
");


                while (PlayerInput != "R" && PlayerInput != "A")
                {
                    PlayerInput = FilterInput(Console.ReadLine());
                }

                switch (PlayerInput)
                {
                    case "R":
                        MainPlayer.Place = "Forest";
                        break;
                    case "A":

                        counter++;
                        Monster.HP -= MainPlayer.Attack;
                        Console.WriteLine($@"

You attack the monster.
Monster HP -{MainPlayer.Attack} 
New monster HP:{Monster.HP}/{Monster.MaxHP}

The monster runs towards you to attack. 
Not using his full strength he scratches your face with his claws.");

                        MainPlayer.ReduceHealth(1);
                        MainPlayer.FaceBroken = true;

                        Console.WriteLine($@"Your face is now swollen and unrecognisable. 
The monster laughs at the cuts on your face and makes it clear that the next attack 
will be using all his power. 

To continue press enter");
                        Console.Read();
                        break;
                }

            }
            else if (Monster.Alive == true)
            {
                Console.WriteLine($@"The monster blocks your path.
Monster Attack power:{Monster.Attack} Monster HP:{Monster.HP}/{Monster.MaxHP}

You can:
Enter R to return to the forest
Enter A to attack the monster
or to view player information codes enter P
");


                while (PlayerInput != "R" && PlayerInput != "A")
                {
                    PlayerInput = FilterInput(Console.ReadLine());
                }

                switch (PlayerInput)
                {
                    case "R":
                        MainPlayer.Place = "Forest";
                        break;
                    case "A":
                        Battle();
                        break;
                }
            }
            else
            {
                MainPlayer.Place = "CastleDoor";
            }

            return MainPlayer;
  
        }

        private void Battle()
        {
            Monster.HP -= MainPlayer.Attack;

            if (Monster.HP > 0)
            {

                Console.WriteLine($@"


You attack the monster.
Monster HP -{MainPlayer.Attack} 
New monster HP:{Monster.HP}/{Monster.MaxHP}

The monster attacks you.
Your HP -{Monster.Attack}");
            MainPlayer.ReduceHealth(Monster.Attack);
            }
            else
            {
                Console.WriteLine($@"


You attack the monster.
The monster is defeated!!

Press enter to continue to the castle.");
                Monster.Alive = false;
                Console.Read();
                

            }


            if (MainPlayer.Alive == true && Monster.Alive==true)
            {
                Console.WriteLine(@"To attack again enter A
To run away to the forest enter R");

                string PlayerInput = " ";
                while (PlayerInput != "A" && PlayerInput != "R")
                {
                    PlayerInput = FilterInput(Console.ReadLine());
                }

                switch (PlayerInput)
                {
                    case "R":
                        MainPlayer.Place = "Forest";
                        break;
                    case "A":
                        Battle();
                        break;
                }
            }

        }


    }
}
