using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LincolnGame
{
    class Card
    {
        private string Suit { set; get; }
        private int Value { set; get; }
        private string Name { get; set; }

        public Card(string inputSuit, string inputValue)
        {
            Suit = inputSuit;
            Name = inputValue;
            Value = ValueAssign(Name);
        }

        public int GetValue()
        {
            return Value;
        }

        private int ValueAssign(string Name)
        {
            switch (Name)
            {
                case "Ace": return 14;
                case "Two": return 2;
                case "Three": return 3;
                case "Four": return 4;
                case "Five": return 5;
                case "Six": return 6;
                case "Seven": return 7;
                case "Eight": return 8;
                case "Nine": return 9;
                case "Ten": return 10;
                case "Jack": return 11;
                case "Queen": return 12;
                case "King": return 13;
                default: return 0;
            }
        }

        public override string ToString()
        {
            return $"{Name} of {Suit}";
        }

    }

}
