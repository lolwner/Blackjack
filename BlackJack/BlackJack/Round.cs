using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Round
    {
        public List<Card> InitializeDeck()
        {
            List<Card> cardDeck = new List<Card>();
            const int NumericCards = 8;

            foreach (Suits suit in Enum.GetValues(typeof(Suits)))
            {
                for (int i = 0; i < Enum.GetNames(typeof(Face)).Length; i++)
                {
                    Card card = new Card();
                    if (i <= NumericCards)
                    {
                        card.Name = Enum.GetName(typeof(Face), i);
                        card.Value = i + 2;
                        card.Suit = suit;
                        cardDeck.Add(card);
                        continue;
                    }
                    if (i > NumericCards)
                    {
                        card.Name = Enum.GetName(typeof(Face), i);
                        card.Value = 10;
                        card.Suit = suit;
                        cardDeck.Add(card);
                    }

                }
            }
            return cardDeck;
        }

        public static void StartRound()
        {
            Game game = new Game();
            Round round = new Round();
            game.Play(round.InitializeDeck());
        }

        public static void StartGame()
        {
            ConsoleUI.ShowDialogNewRound();
            while (ConsoleUI.ShowDialogUserInput() == true)
            {
                StartRound();
                ConsoleUI.ShowDialogNewRound();
            }

        }
    }
}
