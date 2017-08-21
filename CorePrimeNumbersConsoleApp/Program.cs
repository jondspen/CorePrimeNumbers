using CorePrimeNumberLibraries;
using System;
using System.Collections.Generic;

namespace CorePrimeNumbersConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number N (greater than 1) to get a list of all primes <= N: ");
            int maxNumber = 0;
            bool validMaxNumber = true;
            List<int> ListOfPrimes = new List<int>();

            // Create the list of known prime numbers <= maxNumber
            if (int.TryParse(Console.ReadLine(), out maxNumber))
            {
                if (maxNumber > 1)
                {
                    ListOfPrimes = PrimeNumberList.CreateListOfPrimes(maxNumber);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Number of primes found for {maxNumber} was {ListOfPrimes.Count}.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (int i = 0; i < ListOfPrimes.Count; i++)
                    {
                        Console.Write(ListOfPrimes[i].ToString() + " ");
                    }

                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("\nValue was not greater than 1.");
                    validMaxNumber = false;
                }                
            }
            else
            {
                Console.WriteLine("\nInvalid number entered.");
                validMaxNumber = false;
            }

            // Factor user's number into its primes
            if (validMaxNumber)
            {
                Console.ResetColor();
                Console.Write("\n\nEnter a number M to factor into its prime components: ");
                int numberToFactor = 0;
                if (int.TryParse(Console.ReadLine(), out numberToFactor))
                {
                    if ((numberToFactor > 1) && (ListOfPrimes.Count > 0))
                    {
                        var primeFactorList = FactorByPrimes.FactorIntoPrimes(numberToFactor, ListOfPrimes);

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"The number {numberToFactor} is the product of the following primes:");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        for (int i = 0; i < primeFactorList.Count; i++)
                        {
                            Console.Write(primeFactorList[i].ToString() + " ");
                        }
                    }
                }
            }
            Console.ResetColor();
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey(true);
        }
    }
}