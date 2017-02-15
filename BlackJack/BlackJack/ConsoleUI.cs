using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public static class ConsoleUI
    {
        public static void ShowMessagePlayerLeft()
        {
            Console.WriteLine("Player left the game");
        }

        public static void ShowMessagePlayerWin()
        {
            Console.WriteLine("Player win!");
        }

        public static void ShowMessageCasinoWin()
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

        public static void ShowDialogContinue()
        {
            Console.WriteLine("Take card? y/n");
        }

        public static void ShowDialogNewRound()
        {
            Console.WriteLine("Start new round? y/n");
        }

        public static bool ShowDialogUserInput()
        {
            string choise = Console.ReadLine().ToString();

            while (choise != "y" || choise != "n")
            {
                if (choise == "y")
                {
                    return true;
                }
                if (choise == "n")
                {
                    return false;
                }
                if (choise != "y" || choise != "n")
                {
                    Console.WriteLine("Choose y or n");
                    choise = Console.ReadLine().ToString();
                }
            }
            return false;

        }
    }
}
