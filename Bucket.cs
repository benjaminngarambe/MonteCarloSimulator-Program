using System;
using System.Collections.Generic;
using System.Linq;

namespace MonteCarlo_Program
{
    internal class Bucket
    {
        public Dictionary<int, int> buckets = new Dictionary<int, int>();
        public int BucketCount { get; private set; }
        public int LowRange { get; private set; }
        public int HighRange { get; private set; }
        public int StepSize { get; private set; }

        public Bucket(int newBucketCount, int newRangeLow, int newRangeHigh)
        {
            this.BucketCount = newBucketCount;
            this.LowRange = newRangeLow;
            this.HighRange = newRangeHigh;
            this.StepSize = (Math.Abs(HighRange - Math.Abs(LowRange)) / BucketCount);
            InitialBucket();
        }

        public void InitialBucket()
        {
            for (int i = 0; i < this.BucketCount; i++)
            {
                this.buckets.Add(this.LowRange + (this.StepSize * i), 0);
            }
        }

        public void AddValueToBucket(int val)
        {
            int idx = this.GetBucketIdValue(val);
            this.buckets[this.buckets.ElementAt(idx).Key]++;
        }

        public int GetBucketIdValue(int val)
        {
            int idx = 0;
            while ((idx < this.BucketCount - 1) && val > this.LowRange + this.StepSize * (idx + 1))
            {
                idx++;
            }
            return idx;
        }

        public override string ToString()
        {
            string result = string.Empty;

            foreach (KeyValuePair<int, int> keyValue in this.buckets)
            {
                result += $"{keyValue.Key} days: {keyValue.Value / 100}%\n";
            }
            return result;
        }

        public void AccumulatedProbabilites()
        {
            for (int i = 1; i < buckets.Count; i++)
            {
                buckets[buckets.ElementAt(i).Key] = buckets.ElementAt(i - 1).Value + buckets.ElementAt(i).Value;
            }
        }
    }
}