using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Game
    {
        int PlayerScore;
        int CasinoScore;
        const int WinValue = 21;
        static Random RandomObj = new Random();

        public int TakeCard(List<Card> deck)
        {
            int RandomItemIndex = RandomObj.Next(0, deck.Count);
            Card card = deck[RandomItemIndex];
            int score = 0;
            score += card.Value;
            ConsoleUI.ShowCard(card);
            return score;
        }

        public void Play(List<Card> deck)
        {
            PlayerScore += TakeCard(deck);
            PlayerScore += TakeCard(deck);
            ConsoleUI.ShowScore(PlayerScore);

            CasinoScore += TakeCard(deck);
            CasinoScore += TakeCard(deck);
            ConsoleUI.ShowScore(CasinoScore);

            if (CheckPlayerScore(PlayerScore) == false)
            {
                return;
            }

            if (CheckCasinoScore(CasinoScore) == false)
            {
                return;
            }

            while (PlayerScore < WinValue && CasinoScore < WinValue)
            {
                ConsoleUI.ShowDialogContinue();
                bool UserInput = ConsoleUI.ShowDialogUserInput();

                if (UserInput == false)
                {
                    RejectNextTurn(deck);
                    break;
                }

                if (UserInput == true)
                {
                    AcceptNextTurn(deck);
                }

            }
        }

        public void AcceptNextTurn(List<Card> deck)
        {
            PlayerScore += TakeCard(deck);
            ConsoleUI.ShowScore(PlayerScore);

            CasinoScore += TakeCard(deck);
            ConsoleUI.ShowScore(CasinoScore);

            if (CheckPlayerScore(PlayerScore) == false)
                return;

            if (CheckCasinoScore(CasinoScore) == false)
                return;
        }

        public void RejectNextTurn(List<Card> deck)
        {
            CasinoScore += TakeCard(deck);
            ConsoleUI.ShowScore(CasinoScore);

            if (CheckCasinoScore(CasinoScore) == false)
            {
                return;
            }

        }

        public string CheckScore(int score)
        {
            if (score == WinValue)
            {
                return "BlackJack";
            }
            if (score > WinValue)
            {
                return "Too many";
            }
            return null;
        }

        public bool CheckPlayerScore(int PlayerScore)
        {
            if (CheckScore(PlayerScore) == "BlackJack")
            {
                ConsoleUI.ShowMessagePlayerWin();
                return false;
            }
            if (CheckScore(PlayerScore) == "Too many")
            {
                ConsoleUI.ShowMessageCasinoWin();
                return false;
            }
            return true;
        }

        public bool CheckCasinoScore(int CasinoScore)
        {
            if (CheckScore(CasinoScore) == "BlackJack")
            {
                ConsoleUI.ShowMessageCasinoWin();
                return false;
            }
            if (CheckScore(CasinoScore) == "Too many")
            {
                ConsoleUI.ShowMessagePlayerWin();
                return false;
            }
            return true;
        }





    }
}
