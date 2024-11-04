using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ukol
{
    internal class Program
    {
        static void CandidatesIteration(Dictionary<string, int> candidates)
        {
            float totalVotes = 0;
            string candidateName;
            int candidateValue;
            float percentage = 0;
            float mostVotes = int.MinValue;
            string electionWinner = "";
            foreach (KeyValuePair<string, int> candidateKVP in candidates)
            {
                candidateName = candidateKVP.Key;
                candidateValue = candidateKVP.Value;
                if (candidateKVP.Value >= mostVotes)
                {
                    mostVotes = candidateKVP.Value;
                    electionWinner = candidateKVP.Key;
                }
                totalVotes += candidateValue;
                Console.WriteLine("Candidate " + candidateName + " has " + candidateValue + " ");

            }
            Console.WriteLine("Total amount of votes is " + totalVotes);

            foreach (KeyValuePair<string, int> candidateKVP in candidates)
            {
                candidateName = candidateKVP.Key;
                percentage = candidateKVP.Value/(totalVotes / 100) ;
                Console.WriteLine("Candidate " + candidateName + " has " + percentage + "% of votes");

            }
            Console.WriteLine("The election winner is " + electionWinner + " with the total amount of votes " + mostVotes);


        }
        static void Main(string[] args)
        {
            Console.WriteLine("To stop adding candidates write: stop");
            Dictionary<string, int> candidates = new Dictionary<string, int>();
            int i = 1;
            Random rnd = new Random();
            while (true)
            {
                Console.WriteLine("Select candidate " + i);
                string candidateNameInput = Console.ReadLine();
                if (candidateNameInput == "stop")
                {
                    break;
                }
                else { 
                candidates[candidateNameInput] = rnd.Next(0, 100000);
                i++;
                }
            }
            CandidatesIteration(candidates);
            Console.ReadKey();
        }
    }
}
