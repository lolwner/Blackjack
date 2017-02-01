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

        public void StopGame()
        {

        }

        public int TakeCard(Deck deck)
        {
            int score = 0;
            Card PlayerCard = deck.PickCard();
            score += PlayerCard.Value;
            Console.WriteLine("You got {0} of {1}, value is {2}", PlayerCard.Name, PlayerCard.Suit, PlayerCard.Value);
            return score;
        }

        public void NewGame()
        {
            Deck deck = new Deck();
            PlayerScore += TakeCard(deck);
            PlayerScore += TakeCard(deck);

            CasinoScore += TakeCard(deck);
            CasinoScore += TakeCard(deck);

            do
            {
                if (PlayerScore == 21)
                {
                    Console.WriteLine("BlackJack, player win");
                    StopGame();
                } else if (CasinoScore == 21)
                {
                    Console.WriteLine("BlackJack, casino win");
                    StopGame();
                }

                Console.WriteLine("Take card? Y/N");
                string choise = Console.ReadLine().ToString();
                if (choise == "y" || choise == "Y")
                {
                    PlayerScore += TakeCard(deck);
                    if(PlayerScore > 21)
                    {
                        Console.WriteLine("Too many, casino win");
                        StopGame();
                    }
                    CasinoScore += TakeCard(deck);
                    if (CasinoScore > 21)
                    {
                        Console.WriteLine("Casino has too many, player win");
                        StopGame();
                    }
                }
                else if (choise == "n" || choise == "N")
                {
                    CasinoScore += TakeCard(deck);
                    StopGame();
                }
                else
                {
                    Console.WriteLine("Choose Y or N");
                }

            } while (PlayerScore < 21);
            StopGame();
        }




    }
}
