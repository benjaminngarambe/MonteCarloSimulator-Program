using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo_Program
{
    class TddTest
    {
        public void TestBucket()
        {
            Behaviour behavior = new Behaviour();
            int[] Approximation = behavior.EstimationCalculator();
            int low = Approximation[0];
            int high = Approximation[2];
            var bucket = new Bucket(10,40,160)//new bucketcount,high,low
        }
    }
}
