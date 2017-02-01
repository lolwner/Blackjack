using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Game
    {
        public int PlayerScore;
        public int CasinoScore;


        public int TakeCard(Deck deck)
        {
            int score = 0;
            Card PlayerCard = deck.PickCard();
            score += PlayerCard.Value;
            Console.WriteLine("You got {0} of {1}, value is {2}", PlayerCard.Name, PlayerCard.Suit, PlayerCard.Value);
            Console.WriteLine();
            return score;
        }

        public int NewGame()
        {
            Deck deck = new Deck();
            Console.WriteLine("Player`s card");
            PlayerScore += TakeCard(deck);
            PlayerScore += TakeCard(deck);
            Console.WriteLine("Player score is {0}", PlayerScore);

            Console.WriteLine("Casino card");
            CasinoScore += TakeCard(deck);
            CasinoScore += TakeCard(deck);
            Console.WriteLine("Casino score is {0}", CasinoScore);

            do
            {
                if (PlayerScore == 21)
                {
                    Console.WriteLine("BlackJack, player win");
                    return 0;
                } else if (CasinoScore == 21)
                {
                    Console.WriteLine("BlackJack, casino win");
                    return 0;
                }

                Console.WriteLine("Take card? Y/N");
                string choise = Console.ReadLine().ToString();
                if (choise == "y" || choise == "Y")
                {
                    Console.WriteLine("Player`s card");
                    PlayerScore += TakeCard(deck);
                    Console.WriteLine("Player score is {0}", PlayerScore);
                    if (PlayerScore > 21)
                    {
                        Console.WriteLine("Too many, casino win");
                        return 0;
                    }
                    Console.WriteLine("Casino card");
                    CasinoScore += TakeCard(deck);
                    Console.WriteLine("Casino score is {0}", CasinoScore);
                    if (CasinoScore > 21)
                    {
                        Console.WriteLine("Casino has too many, player win");
                        return 0;
                    }
                }
                else if (choise == "n" || choise == "N")
                {
                    CasinoScore += TakeCard(deck);
                    Console.WriteLine("Casino score is {0}", CasinoScore);
                    return 0;
                }
                else
                {
                    Console.WriteLine("Choose Y or N");
                }

            } while (PlayerScore < 21);
            return 0;
        }




    }
}
