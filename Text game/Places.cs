using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_game
{
    class Places
    { 
        protected Player MainPlayer;
        protected string FilterInput(string PlayerInput)
            //Returns a 1 character string of capital letter.
        {

            string CapitolInput = PlayerInput.ToUpper();
            switch (CapitolInput)
            {
                case "P":
                    Playerstats();
                    break;
                case "G":
                    PlayerGold();
                    break;
                case "H":
                    PlayerHealth();
                    break;
                case "I":
                    PlayerItem();
                    break;
                case "T":
                    PLayerAttack();
                    break;
                case "U":
                    UsePotion();
                    CapitolInput = " ";
                    break;
                default:
                    break;
            }
            return CapitolInput;
        }

        protected void Playerstats()
        {
            if (PlayerStatsCounter == 0)
            {
                Console.WriteLine($@"
You can see how much gold you have by entering G
View Health by entering H
View Items by entering I
View Total Attack points by entering T
Use a potion(+50HP) by entering U");
                PlayerStatsCounter++;
            }
        }


        protected int GoldCounter;
        protected int HealthCounter;
        protected int ItemCounter;
        protected int PlayerStatsCounter;
        protected int PlayerAttackCounter;

        protected void CountersZero()
        {
            GoldCounter = 0;
            HealthCounter = 0;
            ItemCounter = 0;
            PlayerStatsCounter = 0;
            PlayerAttackCounter = 0;

        }

        protected void PlayerGold()
        {
            if (GoldCounter == 0)
            {
                Console.WriteLine($"Gold:{MainPlayer.Gold}");
                GoldCounter++;
            }
        }

        protected void PlayerHealth()
        {
            if (HealthCounter == 0)
            {
                Console.WriteLine($"HP:{MainPlayer.HP}/{MainPlayer.MaxHP}");
                HealthCounter++;
            }
        }


        protected void PlayerItem()
        {
            if (ItemCounter == 0)
            {
                MainPlayer.GetItems();
                ItemCounter++;
            }
        }

        protected void PLayerAttack()
        {
            if (PlayerAttackCounter == 0)
            {
                Console.WriteLine($"Attack Power:{MainPlayer.Attack}");
                PlayerAttackCounter++;
            }
        }

        protected void UsePotion()
        {
            String Input = " ";
            while (Input!="Y" && Input!= "N")
            {
                Console.Write(@"Are you sure you want to use a Potion?

Enter Y for yes
Enter N for no
");
                Input = Console.ReadLine().ToUpper();
                
            }
            if (Input=="Y")
            {
                if (MainPlayer.NumPotions>0)
                {
                    MainPlayer.NumPotions -= 1;
                    int AddHealth;

                    if (50+MainPlayer.HP>MainPlayer.MaxHP)
                    {
                        AddHealth = MainPlayer.MaxHP;
                    }
                    else
                    {
                        AddHealth = 50;
                    }
                    MainPlayer.ReduceHealth(-AddHealth);
                }
                else
                {
                    Console.WriteLine("You dont have any Potions");
                }
            }

        }


    }
}
