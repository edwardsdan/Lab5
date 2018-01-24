using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{   
    public class DiceRollerApp
    {
        public static int RollDice(int x)
        {
            Random rnd = new Random();
            int die1 = rnd.Next(1, x);
            int die2 = rnd.Next(1, x);
            return die1 + die2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wanna play a game? (y/n)\t");
            string response = Console.ReadLine();
            if (response.ToLower() == "y" || response.ToLower() == "yes")
            {
                int i = 1;
                while (i <= int.MaxValue)
                {
                    Console.WriteLine("How many sides should each die have? (up to 20)");

                    int sides;
                    bool Validate = int.TryParse(Console.ReadLine(), out sides);
                    if (Validate == false || sides > 20 || sides <= 1)
                    {
                        Console.WriteLine("Try entering a number between 1 and 20!");
                        continue;
                    }
                    
                    if (DiceRollerApp.RollDice(sides) == 2)
                        Console.WriteLine($"Roll {i}: Snake eyes!!!");

                    else if (DiceRollerApp.RollDice(sides) == 7 || DiceRollerApp.RollDice(sides) == 11)
                        Console.WriteLine($"Roll {i}: Craps!!!");

                    else if (DiceRollerApp.RollDice(sides) == 12)
                        Console.WriteLine($"Roll {i}: Boxcars!!!");

                    else
                        Console.WriteLine($"Roll {i}: {DiceRollerApp.RollDice(sides)}");

                    Console.WriteLine("Wanna play again? (y/n)");
                    string yesOrNo = Console.ReadLine();
                    if (yesOrNo.ToLower() == "y" || yesOrNo.ToLower() == "yes")
                        i++;
                    else
                        break;
                }
            }
            Console.WriteLine("Goodbye!");
        }
    }
}
