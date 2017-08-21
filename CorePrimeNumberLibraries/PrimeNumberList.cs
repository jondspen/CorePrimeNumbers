using System;
using System.Collections.Generic;

namespace CorePrimeNumberLibraries
{
    public static class PrimeNumberList
    { 
        public static List<int> CreateListOfPrimes(int maxNumber)
        {
            List<int> primeList = new List<int>();

            /* Creating a list of all prime numbers from 2 to maxNumber
            * Using Sieve of Eratosthenes Algorithm
            * https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes
            * 
            * "The sieve of Eratosthenes can be expressed in pseudocode, as follows"
            *      Input: an integer n > 1.
            *      Let A be an array of Boolean values, indexed by integers 2 to n,
            *      initially all set to true.
            *      
            *      for i = 2, 3, 4, ..., not exceeding √n:
            *          if A[i] is true:
            *              for j = i^2, i^2+i, i^2+2i, i^2+3i, ..., not exceeding n:
            *                  A[j] := false.
            *      Output: all i such that A[i] is true.
            *      
            *      -------------------  Comments added below for each step of the algorithm  -------------------
            *                           Algorithm is proposed to run in O(n * (log log n))
            */

            //  Input: an integer n > 1.
            if (maxNumber > 1)
            {
                //Let A be an array of Boolean values, indexed by integers 2 to n, initially all set to true.
                Dictionary <int, bool> numberDictionary = new Dictionary<int, bool>();

                for (int keyValue = 2; keyValue <= maxNumber; keyValue++)
                {
                    numberDictionary.Add(keyValue, true);
                }

                //  for i = 2, 3, 4, ..., not exceeding √n:
                for (int i = 2; i < Math.Sqrt(maxNumber); i++)
                {
                    // if A[i] is true:
                    if (numberDictionary[i])
                    {
                        //  for j = i^2, i^2+i, i^2+2i, i^2+3i, ..., not exceeding n:
                        int coefficient = 0;
                        int squaredMultiple = MultiplesOfTheValue(i, coefficient);

                        while (squaredMultiple <= maxNumber)
                        {
                            //  A[j] := false
                            numberDictionary[squaredMultiple] = false;
                            // ***** Iterate through i^2+(coefficient * i) by incrementing coefficient and evaluating the next squared multiple *****
                            coefficient++;
                            squaredMultiple = MultiplesOfTheValue(i, coefficient);
                        }
                    }
                }

                //  Output: all i such that A[i] is true
                for (int dictionaryKey = 2; dictionaryKey <= maxNumber; dictionaryKey++)
                {
                    if (numberDictionary[dictionaryKey])
                    {
                        primeList.Add(dictionaryKey);
                    }
                }
            }

            return primeList;
        }

        private static int MultiplesOfTheValue(int keyValue, int coefficient)
        {
            return ((keyValue * keyValue) + (coefficient * keyValue));
        }
    }
}
