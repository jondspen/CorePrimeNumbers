using System;
using System.Collections.Generic;
using System.Text;

namespace CorePrimeNumberLibraries
{
    public static class FactorByPrimes
    {
        public static List<int> FactorIntoPrimes(int value, List<int> knownPrimes)
        {
            List<int> factoredListOfPrimes = new List<int>();
            int indexCounter = 0;

            // Exit while if we're done factoring OR if we run out of prime numbers to factor with
            while ((value > 1) && (indexCounter < knownPrimes.Count))
            {
                if(value % knownPrimes[indexCounter] == 0)
                {
                    factoredListOfPrimes.Add(knownPrimes[indexCounter]);
                    value /= knownPrimes[indexCounter];
                }
                else
                {
                    indexCounter++;
                }
            }

            // Value had a prime that wasn't in the list of knownPrimes, so adding the remainder to the list as negative number
            if (value != 1)
            {
                factoredListOfPrimes.Add(value * -1);
            }
            
            return factoredListOfPrimes;
        }
    }
}
