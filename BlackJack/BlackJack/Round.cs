using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Round
    {
        public List<Card> InitializeDeck()
        {
            List<Card> cardDeck = new List<Card>();


            foreach (Suits suit in Enum.GetValues(typeof(Suits)))
            {
                foreach (Face item in Enum.GetValues(typeof(Face)))
                {
                    Card card = new Card();
                    if (item == Face.Ace || item == Face.King || item == Face.Queen || item == Face.Jack)
                    {
                        card.Name = item.ToString();
                        card.Value = 10;
                        card.Suit = suit;
                        cardDeck.Add(card);

                        continue;
                    }
                    card.Name = item.ToString();
                    card.Value = (int)item;
                    card.Suit = suit;
                    cardDeck.Add(card);
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
