using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Console;

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
        public static void PrintResult (int rolled, int i)
        {
            if (rolled == 2)
                WriteLine($"Roll {i}: Snake eyes!!!");

            else if (rolled == 7 || rolled == 11)
                WriteLine($"Roll {i}: Craps!!!");

            else if (rolled == 12)
                WriteLine($"Roll {i}: Boxcars!!!");

            else
                WriteLine($"Roll {i}: {rolled}");
        }
    }
    class Program
    {
        public static int Validate(string x)
        {
            int sides;
            bool validInput = int.TryParse(x, out sides);
            if (validInput == false || sides > 20 || sides <= 1)
            {
                WriteLine("Try entering a number between 1 and 20!");
                Validate(ReadLine());
            }
            return sides;
        }

        static void Main(string[] args)
        {
            WriteLine("Wanna play a game? (y/n)");

            if (Regex.Match(ReadLine().ToLower(), @"^(y|yes)$").Success)
            {
                int i = 1;
                while (i <= int.MaxValue)
                {
                    WriteLine("How many sides should each die have? (up to 20)");
                    int rolled = DiceRollerApp.RollDice(Validate(ReadLine()));

                    DiceRollerApp.PrintResult(rolled, i);

                    WriteLine("Wanna play again? (y/n)");
                    if (Regex.Match(ReadLine().ToLower(), "^(y|yes)$").Success)
                        i++;
                    else
                        break;
                }
            }
            WriteLine("Goodbye!");
        }
    }
}
