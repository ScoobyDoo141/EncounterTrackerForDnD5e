using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncounterTracker5e
{
    class Program
    {
        //The newEnemy function creates a new enemy and adds it to the enemies list, where they are stored
        static List<string> newEnemy(List<string>enemies)
        {
            bool error;
            string newName;
            int newHP;
            string output = "";
            do
            { 
                //This gives the name for the creature (plus some validation)
                Console.WriteLine("What should the creature be called?");
                newName = Console.ReadLine();
                error = true;
                for (int c = 0; c < enemies.ToArray().Length; c++)
                {
                    if (enemies[c] == newName)
                    {
                        error = false;
                    }
                }
            } while (error == false);
            do
            {
                //This gives the health of the creature (plus some validation)
                error = true;
                Console.WriteLine("How much health does the creature have?");
                error = int.TryParse(Console.ReadLine(), out newHP);
                if (newHP >= 10000)
                {
                    error = false;
                }             
            } while (error == false);
            for (int c = 4; c > newHP.ToString().Length; c--)
            {
                //This formats the number to be four digits
                output += "0";
            }
            //This adds the new output string to the list
            output += newHP + newName;
            enemies.Add(output);
            return enemies;           
        }
        //The dealDamage function manages damage being dealt to an enemy
        static List<string> dealDamage(List<string> enemies)
        {
            string enemyHit;
            int errorCount = 0;
            int damageDealt;
            bool error;
            do
            {
                //This gets the name of a creature
                if (errorCount >= 1)
                {
                    Console.WriteLine("Please enter the name of an existing enemy");
                }
                errorCount = 0;
                error = false;
                Console.WriteLine("Who do you want to take damage?");
                enemyHit = Console.ReadLine().ToLower();
                for (int c = 0; c < enemies.ToArray().Length; c++)
                {
                    if (enemies[c].Substring(4).ToLower() == enemyHit)
                    {
                        enemyHit = "" + c;
                        error = true;
                    }
                }
            } while (errorCount >= 1);
            do
            {             
                //This gets the damage the creature takes
                if (error == false)
                {
                    Console.WriteLine("Please enter an integer");
                }
                error = true;
                Console.WriteLine("How much damage do they take?");
                error = int.TryParse(Console.ReadLine(), out damageDealt);                                            
            } while (error == false);
            //This seperates the string so that it can deal with the damage
            string output = "";
            string enemyName = enemies[int.Parse(enemyHit)].Substring(4);
            int enemyHP = int.Parse(enemies[int.Parse(enemyHit)].Substring(0, 4));
            enemyHP -= damageDealt;
            for (int c = 4; c > enemyHP.ToString().Length; c--)
            {
                output += "0";
            }
            //This outputs the creatures health and name back into the output string
            output += enemyHP + enemyName;
            enemies[int.Parse(enemyHit)] = output;
            return (enemies);
        }
        static void Main(string[] args)
        {
            List<string> enemies = new List<string>();
         
            while (true)
            {
                //This should call the different functions and acts as an interface
                Console.WriteLine("What do you want to do? (Write Help for a command list)");
                if (Console.ReadLine().ToUpper() == "HELP")
                {
                    Console.WriteLine("NewEnemy - Allows input of a new enemy\nDealDamage - Allows the dealing of damage to an already existing enemy" +
                        "\nDisplayHealth - Shows the health of all of the enemies stored in the program\nHelp - Displays the command list");
                }
                if (Console.ReadLine().ToUpper() == "NEWENEMY")
                {
                    enemies = newEnemy(enemies);
                }
                else if (Console.ReadLine().ToUpper() == "DEALDAMAGE")
                {
                    enemies = dealDamage(enemies);
                }
                else if (Console.ReadLine().ToUpper() == "DISPLAYHEALTH")
                {
                    for(int c = 0; c < enemies.ToArray().Length; c++)
                    {
                        Console.WriteLine("{0} has {1} health", enemies[c].Substring(4), enemies[c].Substring(0, 4));
                    }
                }
            }
        }       
    }
}


