using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LincolnGame
{
    class Deck
    {
        protected List<Card> CardPack { get; set; } // List of the cards
        protected Stack<Card> PlayingDeck { get; set; }
        private Random randInt = new Random();
        protected static string[] SuitsList = new string[] { "Clovers", "Diamonds", "Hearts", "Spades" }; //Array of suits
        protected static string[] CardList = new string[] { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };

        public Deck()
        {
            //initiate list
            CardPack = new List<Card>(52);
            PlayingDeck = new Stack<Card>(52);
            for (int i = 0; i < 4; i++) //starting from 0 going to 3, as this corresponds to suit array
            {
                for (int j = 0; j < 13; j++) //starting at 1 and stopping at 13 to correspond to specific card
                {
                    Card TempCard = new Card(SuitsList[i], CardList[j]); // create a card
                    CardPack.Add(TempCard); // add to list
                }
            }
        }

        public bool isEmpty()
        {
            if (PlayingDeck.Count == 0) // checks number of items in the deck
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Shuffle()
        {
            if (isEmpty() == true)
            {
                List<int> UsedNums = new List<int>(52); //an array used to make sure cards aren't put in twice
                int num = randInt.Next(0, 52);
                for (int i = 1; i <= 52; i++)
                {
                    while (UsedNums.Contains(num) == true)
                    {
                        num = randInt.Next(0, 52);
                    }
                    PlayingDeck.Push(CardPack[num]);
                    UsedNums.Add(num);
                    num = randInt.Next(0, 52);
                }
            }
            else
            {
                int tempLength = PlayingDeck.Count();
                List<int> UsedNums = new List<int>(tempLength);
                List<Card> tempArray = new List<Card>(tempLength);
                while (isEmpty() != true)
                {
                    tempArray.Add(PlayingDeck.Pop());
                }
                int num = randInt.Next(0, tempLength);
                for (int i=1; i <= tempLength; i++)
                {
                    while (UsedNums.Contains(num) == true)
                    {
                        num = randInt.Next(0, tempLength);
                    }
                    PlayingDeck.Push(tempArray[num]);
                    UsedNums.Add(num);
                    num = randInt.Next(0, tempLength);
                }
            }
        }

        public Card Deal()
        {
           return PlayingDeck.Pop();
        }

    }
}
