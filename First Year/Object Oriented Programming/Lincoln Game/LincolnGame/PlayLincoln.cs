using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LincolnGame
{
    sealed class PlayLincoln
    {
        private Deck PlayDeck;
        private Human User;
        private Computer Comp;
        private List<int> Scores;
        private int RoundNum;

        public PlayLincoln(string Name)
        {
            PlayDeck = new Deck();
            PlayDeck.Shuffle();
            User = new Human(Name,PlayDeck);
            Comp = new Computer(PlayDeck);
            Scores = new List<int>();
        }

        public void DisplayLincoln(int RoundVal)
        {
            do
            {
                RoundNum = 1;
                Console.Clear();
                Console.WriteLine("--------------------PLAYABLE CARDS--------------------");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{i + 1}:{User.getPlayCards(i)}                    {i + 6}:{User.getPlayCards(i + 5)}");
                }
                Console.WriteLine("----------------------INTERFACE-----------------------");
                Console.WriteLine($"ROUND {RoundNum}");
                Game();
                RoundNum++;
                Thread.Sleep(8000);
            } while (RoundNum <= RoundVal);
            if (User.getScore() > Comp.getScore())
            {
                Console.WriteLine($"{User.getName()} has won with a score of {User.getScore()}");
            }
            if (User.getScore() < Comp.getScore())
            {
                Console.WriteLine($"Computer has won with a score of {Comp.getScore()}");
            }
            if (User.getScore() == Comp.getScore())
            {
                Console.WriteLine("You guys both won the same number of points. Good Game.");
            }
        }

        private void Game()
        {
            if (User.getWon())
            {
                Console.WriteLine($"{User.getName()} will play first!");
                int num1 = NumParse();
                int num2 = NumParse(num1) - 1;
                num1 -= 1;
                User.HumanPlay(num1, num2);
                Console.WriteLine("Computer now picking...");
                Comp.CompPlay();
                Thread.Sleep(3000);
                Console.WriteLine("Computer has played their cards");
            }
            if (!User.getWon())
            {
                Console.WriteLine("The computer will play first!");
                Console.WriteLine("Computer now picking...");
                Comp.CompPlay();
                Thread.Sleep(3000);
                Console.WriteLine($"Computer has playued their cards, it is now {User.getName()}'s turn");
                int num1 = NumParse();
                int num2 = NumParse(num1) - 1;
                num1 -= 1;
                User.HumanPlay(num1, num2);
            }
            int HumanVal = 0;
            HumanVal = User.getValue();
            Scores.Add(HumanVal);
            int CompVal = 0;
            CompVal = Comp.getValue();
            Scores.Add(CompVal);
            Console.WriteLine($"{User.getName()} has a hand worth {HumanVal} points");
            Console.WriteLine($"The computer has a hand worth {CompVal} points");
            if (HumanVal > CompVal)
            {
                User.ScoreAdd(Scores);
                Console.WriteLine("LINCOLN! "+User);
                if (Comp.getWon())
                {
                    Comp.changeWon(Comp.getWon());
                }
            }
            if (CompVal > HumanVal)
            {
                Comp.ScoreAdd(Scores);
                Console.WriteLine("COMPUTER SAYS LINCOLN! "+Comp);
                if (User.getWon())
                {
                    User.changeWon(User.getWon());
                }
            }
            if (HumanVal == CompVal)
            {
                Console.WriteLine("It is a draw. Good game to you both.");
            }
        }

        private static int NumParse(int checker) //takes arguments as this is called 2nd
        {
            while (true) // this will keep looping as long as an exception is raised
            {
                try
                {
                    Console.WriteLine("What is the second card you wish to play? (1-10)");
                    int num1 = Int32.Parse(Console.ReadLine());
                    ParseCheck(num1, checker); //the argument is put through to check if someone is dealing 2 of the same card
                    return num1; //breaks loop if valid by returning a value
                }
                catch (FormatException)
                {
                    Console.WriteLine("You need to enter a valid number.");
                    continue; // continues the loop if an invalid value is entered
                }
                catch (MatchingNumberException e) // CUSTOM EXCEPTION
                {
                    Console.WriteLine(e.Message); // if numbers match continue
                    continue;
                }
            }
        }

        private static int NumParse()
        {

            /*This function gets called first, it's only after the previous one because I made this function
             later in the coding process. This version of NumParse takes no arguments as it's the first one called*/
            while (true) // same purpose as last time
            {
                try
                {
                    Console.WriteLine("What is the first you wish to play? (1-10)"); 
                    int num1 = Int32.Parse(Console.ReadLine());
                    return num1; //breaks loop if valid by returning a value
                }
                catch (FormatException)
                {
                    Console.WriteLine("You need to enter a valid number.");
                    continue; // continues the loop if an invalid value is entered
                }
            }
        }

        public static void ParseCheck(int Check1, int Check2)
        {
            if (Check1 == Check2) throw new MatchingNumberException("You cannot play the same card twice"); // throws exception
        }
    }
}
