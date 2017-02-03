using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public static class MSG
    {
        public static void PlayerLeft()
        {
            Console.WriteLine("Player left the game");
        }

        public static void PlayerWin()
        {
            Console.WriteLine("Player win!");
        }

        public static void CasinoWin()
        {
            Console.WriteLine("Casino win!");
        }

        public static void ShowScore(int score)
        {
            Console.WriteLine("Score is {0}", score);
        }

        public static void ShowCard(Card PlayerCard)
        {
            Console.WriteLine("You got {0} of {1}, value is {2}", PlayerCard.Name, PlayerCard.Suit, PlayerCard.Value);
            Console.WriteLine();
        }

        public static bool Continue()
        {
            Console.WriteLine("Take card? y/n");
            string choise = Console.ReadLine().ToString();

            while (choise != "y" || choise != "n")
            {
                switch (choise)
                {
                    case "y":
                        return true;
                    case "n":
                        return false;
                    default:
                        Console.WriteLine("Choose y or n");
                        choise = Console.ReadLine().ToString();
                        break;
                }
            }
            return false;

        }
    }
}
