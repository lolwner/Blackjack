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

        public Deck()
        {
            deck = new List<Card>();

            for (int i = 0; i <= 8; i++)
            {
                int name = i + 2;
                deck.Add(new BlackJack.Card(name.ToString(), "Clubs", i+2));
            }
            deck.Add(new Card("Ace", "Clubs", 11));
            deck.Add(new Card("King", "Clubs", 10));
            deck.Add(new Card("Queen", "Clubs", 10));
            deck.Add(new Card("Jack", "Clubs", 10));

            for (int i = 0; i <= 8; i++)
            {
                int name = i + 2;
                deck.Add(new BlackJack.Card(name.ToString(), "Spades", i + 2));
            }
            deck.Add(new Card("Ace", "Spades", 11));
            deck.Add(new Card("King", "Spades", 10));
            deck.Add(new Card("Queen", "Spades", 10));
            deck.Add(new Card("Jack", "Spades", 10));

            for (int i = 0; i <= 8; i++)
            {
                int name = i + 2;
                deck.Add(new BlackJack.Card(name.ToString(), "Hearts", i + 2));
            }
            deck.Add(new Card("Ace", "Hearts", 11));
            deck.Add(new Card("King", "Hearts", 10));
            deck.Add(new Card("Queen", "Hearts", 10));
            deck.Add(new Card("Jack", "Hearts", 10));

            for (int i = 0; i <= 8; i++)
            {
                int name = i + 2;
                deck.Add(new BlackJack.Card(name.ToString(), "Diamonds", i + 2));
            }
            deck.Add(new Card("Ace", "Diamonds", 11));
            deck.Add(new Card("King", "Diamonds", 10));
            deck.Add(new Card("Queen", "Diamonds", 10));
            deck.Add(new Card("Jack", "Diamonds", 10));

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
