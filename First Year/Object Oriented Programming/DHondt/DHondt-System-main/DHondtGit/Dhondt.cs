using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DHondtGit
{
    class PolParty
    {
        public string PName { get;  set; } // Name comes from Party Name
        public int Votes { get; private set; }
        public int DHondtVotes { get; set; } // named for what happens after we apply d'hondt's method of seat division
        public int PartySeats { get; set; }
        public double VotePercent { get; set; }
        public double SeatPercent { get; set; }

        public PolParty(string name, int votes)
        {
            PName = name;
            Votes = votes;
            DHondtVotes = votes;
        }

        //Print info about the party to the console
        public override string ToString()
        {
            return $"Party Name: {PName}   Votes: {Votes}   Percentage of Votes: {VotePercent}%   Seats: {PartySeats}   Percentage of Seats Won: {SeatPercent}%";
        }

        // Does the D'Hondt method od division
        public void DhondtDivide()
        {
            DHondtVotes = Votes / (1 + PartySeats);
        }

        // Calculates what percentage of votes were received
        public void VotePercentSet(double percentage)
        {
            VotePercent = percentage;
        }

        // Calculates what percentage of seats were received
        public void SeatPercentSet(double totalseats)
        {
            double dPartySeats = Convert.ToDouble(PartySeats);
            SeatPercent = (dPartySeats / totalseats)*100;
        }

    }

    class DHondt
    {
        static void Main(string[] args)
        {
            // Creates an instance of the Party class with each class referenced in the file and adds it to a list of these objects
            string filepath = @"C:\Users\Nathaniel.LAPTOP-MJFS3GNQ\Documents\GitHub\DHondt-System\testdata.txt";
            List<PolParty> PartyList = new List<PolParty>();
            using (StreamReader DataFile = File.OpenText(filepath))
               {
                   string line;
                   while ((line = DataFile.ReadLine()) != null)
                   {
                       string[] items = line.Split(',');
                       PolParty UKParty = new PolParty(items[0], Convert.ToInt32(items[1]));
                       PartyList.Add(UKParty);
                   }
                }
            // Prints out the parties on the file, and outputs their vote count
            Console.WriteLine("The parties that ran in the East Midlands, with the number of votes they got, is as follows:");
            foreach(PolParty UKParty in PartyList)
            {
                Console.WriteLine($"{UKParty.PName} with {UKParty.Votes} votes");
            }

            // Ask user how many seats they want to allocate
            Console.WriteLine("\nHow many seats are in the East Midlands Constituency?");
            int seatsCount = Convert.ToInt32(Console.ReadLine());
            // Asks user what threshold needs to be achieved in order to win seats. In testing 5 is input, as this is the threshold in Germany
            // (UK does not have a threshold)
            Console.WriteLine("\nWhat percentage of votes must be achieved to be eligible for seats (input number only)?");
            double threshold = Convert.ToDouble(Console.ReadLine());

            // Calculations of seat counts and percentage of votes
            int totalVotes;
            totalVotes= SumOfVotes(PartyList);
            DisplayPercentages(PartyList, threshold, totalVotes);
            CalculateDhondt(PartyList, seatsCount);
            SeatPercentage(PartyList, seatsCount);
            DisplayWinners(PartyList);

            Console.ReadKey();
        }

        // Print out all partys and there properties to user
        private static void DisplayWinners(List<PolParty> PartyList)
        {
            foreach (PolParty UKParty in PartyList)
            {
                if (UKParty.PartySeats > 0)
                {
                    Console.WriteLine(UKParty);
                }
            }
        }

        // Calculates the percentage of seats won for each party that has a seat
        public static void SeatPercentage(List<PolParty> PartyList, int totalseats)
        {
            foreach (PolParty UKParty in PartyList)
            {
                if (UKParty.PartySeats >= 1)
                {
                    UKParty.SeatPercentSet(Convert.ToDouble(totalseats));
                }
            }
        }

        // Find total votes won by all parties
        private static int SumOfVotes(List<PolParty> PartyList)
        {
            int totalVotes = 0;
            foreach (PolParty UKParty in PartyList)
            {
                totalVotes = totalVotes+ UKParty.Votes;
            }
            Console.WriteLine($"\nThe total number of votes cast in the East Midlands Region is {totalVotes}\n");
            return totalVotes;
        }

        //Calculate the percentage of votes the party input has won
        private static double PercentageGet(PolParty UKParty, int totalvotes)
        {
            double denominator = Convert.ToDouble(totalvotes);
            double numerator = Convert.ToDouble(UKParty.Votes);
            double percentage = ((numerator) / (totalvotes))*100;
            percentage = Math.Round(percentage, 2);
            return percentage;
        }

        // Displays percent of votes for each party that is eligible to win votes
        private static void DisplayPercentages(List<PolParty> PartyList, double threshold, int totalvotes)
        {
            foreach (PolParty UKParty in PartyList)
            {
                double percent = PercentageGet(UKParty, totalvotes);
                if (percent > threshold)
                {
                    Console.WriteLine($"{UKParty.PName} has {percent}% of total votes and is thus eligible for seats.");
                    UKParty.VotePercentSet(percent);
                }
                
            }
        }

        // Method doing main calculations for the D'Hondt Method
        private static void CalculateDhondt(List<PolParty> PartyList, int seatsCount)
        {
            // Find first party with highest votes
            PolParty biggestVote = PartyList.Aggregate((v1, v2) => v1.Votes > v2.Votes ? v1 : v2);
            biggestVote.PartySeats += 1;
            biggestVote.DhondtDivide();

            // loops til all seats are taken
            int totalSeatsCount = 0;
            while (totalSeatsCount != seatsCount)
            {
                PolParty biggestVotes = PartyList.Aggregate((v1, v2) => v1.DHondtVotes > v2.DHondtVotes ? v1 : v2);
                biggestVotes.PartySeats += 1;
                biggestVotes.DhondtDivide();

                foreach (PolParty UKParty in PartyList)
                {
                    totalSeatsCount += UKParty.PartySeats;
                }
                // If we havent reached desired seats count reset the total seats variable
                if (totalSeatsCount != seatsCount)
                {
                    totalSeatsCount = 0;
                }
            }
            Console.WriteLine($"All {seatsCount} seats allocated: ");
        }
    }
}
