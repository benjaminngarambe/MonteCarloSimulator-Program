using System;

namespace MonteCarlo_Program
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            Console.WriteLine("Enter tasks in the following format: C1,C2,..." + "\nWhere Cx is cost" + "\nType END to finish entering tasks.");
            try
            {
                Behaviour behaviour = new Behaviour();
                int TaskId = 1;
                while (true)
                {
                    Console.Write($"Task #{TaskId}:");
                    string Input = Console.ReadLine();
                    if (Input.ToLower() == "END") break;
                    else TaskId++;
                    behaviour.AddDuty(new Input(Input));
                }
                int[] EstimatedValues = behaviour.EstimationCalculator();
                int lowest = EstimatedValues[0], highest = EstimatedValues[2];

                Bucket bucket = behaviour.Simulator();
                Console.WriteLine("After probing 10000 random plans, The result are:" + $"\nMinimum = {lowest} days" + $"\nAverage = {behaviour.AverageEstimation} days" + $"\nMaximum = {highest} days");
                Console.WriteLine("Probability of finishing the plan in:\n" + bucket);
                bucket.AccumulatedProbabilites();
                Console.WriteLine("Accumulated Probability of finishing the plan in or before:" + bucket);
                Console.ReadKey();
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.Message + "Incorrect Format Provided\nTry Again!");
            }
        }
    }
}