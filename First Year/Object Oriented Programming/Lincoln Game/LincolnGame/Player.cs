using System;
using System.Collections.Generic;
using System.Text;

namespace LincolnGame
{
    interface IPlayer
    {
        public abstract string ToString(); // returns the player's info
        public abstract void ScoreAdd(List<int> Scores); //adds score to player's scores
        public abstract int getScore(); // gives player score
        public abstract int getWins(); // gives wincount of the player
        public abstract int getValue(); // gets values of cards in the hand
        public abstract bool cantPlay(); // checks to see if the player has no cards left to play

    }

    /*START OF INHERITED CLASSES*/
    class Human : IPlayer
    {
        private Hand PlayHand;
        private int score;
        private int winCount;
        private string ID;
        private bool hasWon;
        public Human(string Name, Deck GameDeck)
        {
            ID = Name;
            winCount = 0;
            score = 0;
            PlayHand = new Hand(GameDeck);
            hasWon = true;
        }

        public bool cantPlay() //checks if the the hand is empty
        {
            return PlayHand.isEmpty();
        }

        public override string ToString()
        {
            return $"{ID} has a total score of {score} and has won a total of {winCount} times";
            //output for when you write the user info to console
        }
        public int getScore()
        {
            return score;
        }

        public Card getPlayCards(int HIndex)
        {
            return PlayHand.getPlayable(HIndex);
        }


        public void HumanPlay(int num1, int num2)
        {
            PlayHand.DealHand(num1, num2); // calls the function in hand
        }

        public string getName()
        {
            return ID;
        }

        public void changeWon(bool last)
        {
            if (last)
            {
                hasWon = false;
            }
            if (!last)
            {
                hasWon = true;
            }
        }
        
        public bool getWon()
        {
            return hasWon;
        }

        public int getWins()
        {
            return winCount;
        }

        public void ScoreAdd(List<int> Scores)
        {
            foreach (int item in Scores.ToArray())
            {
                score += item;
                Scores.Remove(item);
            }
            winCount += 1;
        }

        public int getValue()
        {
            int val = 0;
            foreach(Card PCard in PlayHand.ToPlay)
            {
                val += PCard.GetValue();
            }
            PlayHand.CardRemove();
            return val;
        }
    }

    class Computer : IPlayer
    {
        private Hand PlayHand;
        private int score;
        private int winCount;
        private Random Rand;
        private bool hasWon;

        public Computer(Deck GameDeck)
        {
            PlayHand = new Hand(GameDeck);
            score = 0;
            Rand = new Random();
            winCount = 0;
            hasWon = false;
        }

        public void changeWon(bool last)
        {
            if (last)
            {
                hasWon = false;
            }
            if (!last)
            {
                hasWon = true;
            }
        }

        public bool getWon()
        {
            return hasWon;
        }
        public override string ToString()
        {
            return $"The Computer has a total score of {score} and has won a total of {winCount} times";
        }
        public int getScore()
        {
            return score;
        }

        public void CompPlay()
        {
            int num1 = Rand.Next(1, 10);
            int num2 = Rand.Next(1, 10);
            while (num1 == num2)
            {
                num1 = Rand.Next(1, 10);
                num2 = Rand.Next(1, 10);
            }
            PlayHand.DealHand(num1, num2);
        }

        public int getWins()
        {
            return winCount;
        }

        public void ScoreAdd(List<int> Scores)
        {
            foreach (int item in Scores)
            {
                score += item;
            }
            winCount += 1;
        }

        public bool cantPlay()
        {
            return PlayHand.isEmpty();
        }

        public int getValue()
        {
            int val = 0;
            foreach (Card PCard in PlayHand.ToPlay)
            {
                val += PCard.GetValue();
            }
            PlayHand.CardRemove();
            return val;
        }
    }
}
