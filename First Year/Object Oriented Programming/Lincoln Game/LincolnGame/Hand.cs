using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LincolnGame
{
    class Hand
    {
        private List<Card> Playable;
        public List<Card> ToPlay;
        private Deck GameDeck;

        public Hand(Deck useDeck)
        {
            GameDeck = useDeck;
            Playable = new List<Card>(10);
            ToPlay = new List<Card>(2);
            DealCards();
        }

        private void DealCards()
        {
            for (int i = 1; i < 11; i++)
            {
                Playable.Add(GameDeck.Deal()); //adds 10 cards initially
            }
        }

        public Card getPlayable(int num)
        {
            return Playable[num]; // returns the value of the number input
        }

        public bool isEmpty()
        {
            if (Playable.Count == 0) // checks if the number of cards that can be played is 0
            {
                return true;
            }
            else return false;
        }

        public void CardRemove()
        {
            foreach (Card UsedCard in ToPlay.ToArray())
            {
                ToPlay.Remove(UsedCard); // removes the card from the player
            }
        }

        public void DealHand(int num1, int num2)
        {
            ToPlay.Add(Playable[num1]);
            ToPlay.Add(Playable[num2]); // adds cards to the ToPlay list
            if (!GameDeck.isEmpty())
            {
                TopUpPlayable(num1, num2); //Tops up list
            }
        }

        private void TopUpPlayable(int num1,int num2)
        {
            /*This procedure tops up the cards that can be played*/
            Playable[num1] = GameDeck.Deal();
            Playable[num2] = GameDeck.Deal(); 
        }
    }

}
