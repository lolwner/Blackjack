using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Card
    {
        public string Name; 
        public string Suit; //масть
        public int Value; //очки карты

        public Card(string Name, string Suit, int Value)
        {
            this.Name = Name;
            this.Suit = Suit;
            this.Value = Value;
        }
    }
}
