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

        public static Random rng = new Random();
        public int TakeCard(Deck deck)
        {

            int k = rng.Next(0, deck.cardDeck.Count);
            Card card = deck.cardDeck[k];
            int score = 0;
            score += card.Value;
            MSG.ShowCard(card);
            return score;
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

            if (PlayerCheck(PlayerScore) == false)
                return;

            if (CasinoCheck(CasinoScore) == false)
                return;

            while (PlayerScore < 21 && CasinoScore < 21)
            {
                bool a = MSG.Continue();

                if (a == false)
                {
                    CasinoScore += TakeCard(deck);
                    MSG.ShowScore(CasinoScore);

                    if (CasinoCheck(CasinoScore) == false)
                        break;
                        return;
                }

                if (a == true)
                {
                    PlayerScore += TakeCard(deck);
                    MSG.ShowScore(PlayerScore);

                    CasinoScore += TakeCard(deck);
                    MSG.ShowScore(CasinoScore);

                    if (PlayerCheck(PlayerScore) == false)
                        return;

                    if (CasinoCheck(CasinoScore) == false)
                        return;
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

        public bool PlayerCheck(int PlayerScore)
        {
            if (CheckScore(PlayerScore) == "BlackJack")
            {
                MSG.PlayerWin();
                return false;
            }
            if (CheckScore(PlayerScore) == "Too many")
            {
                MSG.CasinoWin();
                return false;
            }
            return true;
        }

        public bool CasinoCheck(int CasinoScore)
        {
            if (CheckScore(CasinoScore) == "BlackJack")
            {
                MSG.CasinoWin();
                return false;
            }
            if (CheckScore(CasinoScore) == "Too many")
            {
                MSG.PlayerWin();
                return false;
            }
            return true;
        }





    }
}
