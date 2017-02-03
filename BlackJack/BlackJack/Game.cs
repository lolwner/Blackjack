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
            Card card = deck.PickCard();
            score += card.Value;
            MSG.ShowCard(card);
            return score;
        }

        public int NewGame()
        {
            Deck deck = new Deck();
            deck.InitializeDeck();
            Console.WriteLine("Player`s card");
            PlayerScore += TakeCard(deck);
            PlayerScore += TakeCard(deck);
            MSG.ShowScore(PlayerScore);
            Console.WriteLine("Player score is {0}", PlayerScore);

            Console.WriteLine("Casino card");
            CasinoScore += TakeCard(deck);
            CasinoScore += TakeCard(deck);
            Console.WriteLine("Casino score is {0}", CasinoScore);

            while (PlayerScore < 21)
            {
                if (PlayerScore == 21)
                {
                    Console.WriteLine("BlackJack, player win");
                    return 0;
                }
                if (CasinoScore == 21)
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

            }
            return 0;
        }

        public void Play()
        {
            Deck deck = new Deck();
            deck.InitializeDeck();

            PlayerScore += TakeCard(deck);
            PlayerScore += TakeCard(deck);
            MSG.ShowScore(PlayerScore);

            CasinoScore += TakeCard(deck);
            CasinoScore += TakeCard(deck);
            MSG.ShowScore(CasinoScore);

            while (PlayerScore < 21 && CasinoScore < 21)
            {

                if (CheckScore(PlayerScore) == "BlackJack")
                {
                    MSG.PlayerWin();
                    return;
                }
                if (CheckScore(CasinoScore) == "BlackJack")
                {
                    MSG.CasinoWin();
                    return;
                }

                bool a = MSG.Continue();

                if (a == false)
                {
                    CasinoScore += TakeCard(deck);
                    MSG.ShowScore(CasinoScore);
                    switch (CheckScore(CasinoScore))
                    {
                        case "BlackJack":
                            MSG.CasinoWin();
                            return;
                        case "Too many":
                            MSG.PlayerWin();
                            return;
                    }
                    return;
                }

                if (a == true)
                {
                    PlayerScore += TakeCard(deck);
                    MSG.ShowScore(PlayerScore);

                    CasinoScore += TakeCard(deck);
                    MSG.ShowScore(CasinoScore);

                    switch (CheckScore(PlayerScore))
                    {
                        case "BlackJack":
                            MSG.PlayerWin();
                            return;
                        case "Too many":
                            MSG.CasinoWin();
                            return;
                    }

                    switch (CheckScore(CasinoScore))
                    {
                        case "BlackJack":
                            MSG.CasinoWin();
                            return;
                        case "Too many":
                            MSG.PlayerWin();
                            return;
                    }
                }

            }
        }

        public string CheckScore(int score)
        {
            if (score == 21)
            {
                return "BlackJack";
            }
            if (score > 21)
            {
                return "Too many";
            }
            return null;
        }





    }
}
