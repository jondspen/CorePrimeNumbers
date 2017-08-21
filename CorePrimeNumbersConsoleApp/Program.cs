using CorePrimeNumberLibraries;
using System;

namespace CorePrimeNumbersConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number N (greater than 1) to get a list of all primes <= N: ");
            int maxNumber = 0;
            if (int.TryParse(Console.ReadLine(), out maxNumber))
            {
                if (maxNumber > 1)
                {
                    var ListOfPrimes = PrimeNumberList.CreateListOfPrimes(maxNumber);
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
                }                
            }
            else
            {
                Console.WriteLine("\nInvalid number entered.");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey(true);
        }
    }
}