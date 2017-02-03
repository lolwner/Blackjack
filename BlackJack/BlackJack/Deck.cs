using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Deck
    {
        public List<Card> deck;

        enum Suits
        {
            Clubs,
            Spades,
            Hearts,
            Diamonds
        };

        public void InitializeDeck()
        {
            deck = new List<Card>();

            Dictionary<string, int> CardNameValue = new Dictionary<string, int>();
            CardNameValue.Add("Two", 2);
            CardNameValue.Add("Three", 3);
            CardNameValue.Add("Four", 4);
            CardNameValue.Add("Five", 5);
            CardNameValue.Add("Six", 6);
            CardNameValue.Add("Seven", 7);
            CardNameValue.Add("Eight", 8);
            CardNameValue.Add("Nine", 9);
            CardNameValue.Add("Ten", 10);
            CardNameValue.Add("Ace", 11);
            CardNameValue.Add("King", 10);
            CardNameValue.Add("Queen", 10);
            CardNameValue.Add("Jack", 10);

            foreach (Suits suit in Enum.GetValues(typeof(Suits)))
            {
                foreach (var item in CardNameValue)
                {
                    deck.Add(new Card(item.Key, suit.ToString(), item.Value));
                }
            }
        }

        private static Random rng = new Random();

        public static void Shuffle(List<Card> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public Card PickCard()
        {
            int k = rng.Next(0, deck.Count);
            var card = deck[k];
            return card;
        }

    }
}
