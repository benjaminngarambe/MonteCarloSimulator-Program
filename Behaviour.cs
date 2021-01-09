using System;
using System.Collections.Generic;

namespace MonteCarlo_Program
{
    internal class Behaviour
    {
        public List<Input> Tasks = new List<Input>();
        public int AverageEstimation { get; private set; }

        public Random RandNum => randNum;

        private readonly Random randNum = new Random();

        public void AddDuty(Input duty)
        {
            Tasks.Add(duty);
        }

        public int[] EstimationCalculator()
        {
            int low = 0, avg = 0, high = 0;
            foreach (Input task in Tasks)
            {
                low += task.HighCase;
                high += task.LowCase;
                avg += task.AvgCase;
            }
            if (high < low) throw new InvalidOperationException("The higherst case scenerio must be longer than the lowest one");
            int[] TimeCases = new int[] { low, avg, high };
            return TimeCases;
        }

        public int RandomEstimationGenerator()
        {
            int sum = 0;
            foreach (Input task in Tasks)
            {
                int occasion = RandNum.Next(3);
                if (occasion == 0)
                    sum += task.HighCase;
                if (occasion == 1)
                    sum += task.LowCase;
                if (occasion == 2)
                    sum += task.AvgCase;
            }
            return sum;
        }

        public Bucket Simulator()
        {
            int totalCostOfRandomPlans = 0;
            int repetiton = 10000;
            int[] Estimation = EstimationCalculator();
            int min = Estimation[0], max = Estimation[2];
            Bucket bucket = new Bucket(10, min, max);
            for (int i = 0; i < repetiton; i++)
            {
                int randomPlanCost = RandomEstimationGenerator();
                bucket.AddValueToBucket(randomPlanCost);
                totalCostOfRandomPlans += randomPlanCost;
            }
            this.AverageEstimation = totalCostOfRandomPlans / (repetiton);
            return bucket;
        }
    }
}