using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LincolnGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> validresponse = new List<string> {"yes","no"}; // list of valid responses to the questions
            string StartGame = null; 
            Console.WriteLine("Please enter your name to play Lincoln: ");
            string Name = Console.ReadLine(); // name used as the player ID for the human
            PlayLincoln Lincoln = new PlayLincoln(Name);
            Console.WriteLine($"Hello {Name}! I want to play a game of Lincoln with you :)");
            Console.WriteLine("\nDo you know how to play? (yes/no) "); //allows rules to be explained
            string RulesChoice = Console.ReadLine().ToLower();
            if (RulesChoice == validresponse[1]) 
            {
                RuleExplain();
                Console.Clear();
            }
            do
            {
                int RoundVal = RoundCounter(); //get number of rounds to be played
                Console.WriteLine("Game Starting...");
                Thread.Sleep(5000); //delay clearing console for Lincoln.DisplayLincoln by 5 seconds 
                Lincoln.DisplayLincoln(RoundVal); // Game displayed by Lincoln class
                Console.WriteLine("Do you wish to quit the game? ");
                StartGame = Console.ReadLine().ToLower();
                while (!validresponse.Contains(StartGame)) //checks if the response given is in the list
                {
                    Console.WriteLine("Do you wish to quit the game? ");
                    StartGame = Console.ReadLine().ToLower();
                }
            } while (StartGame != validresponse[0]); //inputting yes quits game
            Console.WriteLine("Thanks for playing :)"); 
            Thread.Sleep(5000); //wait 5 seconds before closing console
            Environment.Exit(0);
        }

        private static int RoundCounter()
        {
            while (true) // Forces the loop to keep going while the exception is raised.
            {
                try
                {
                    Console.WriteLine("How many rounds are in this game? ");
                    int RoundCount = Int32.Parse(Console.ReadLine());
                    return RoundCount; //returns the number of rounds desired
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter a valid number please"); 
                    continue; //continues if an invalid response is given
                }
            }
        }

        private static void RuleExplain()
        {
            /*This function just explains the rules. nothing much to say to be honest*/
            Console.WriteLine("You are given ten cards, in which each round you play two");
            Console.WriteLine("\nEach card has a value corresponding to the number on the card, except ace, which has value 14");
            Console.WriteLine("\nThe aim is for your 2 cards to have a higher combined value than the computer. If you do, you win the hand");
            Console.WriteLine("\nIf you win a round, both players' card values are added to your score.");
            Console.WriteLine("\nThe person with the highest score at the end of the round wins");
            Console.WriteLine("\nPress <Enter> to proceed");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { } // forces user to press enter
        }

    }
}
