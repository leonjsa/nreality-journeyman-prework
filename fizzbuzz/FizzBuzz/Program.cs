using System;

namespace FizzBuzz
{
    class Program
    {        
        static void Main(string[] args)
        {
            try
            {
                var fizzBuzz = new FizzBuzz();
                var textOutput = fizzBuzz.GetFizzBuzzTextValues(1, 100);
                Console.Write(textOutput);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        /* Plain solution without refactoring and tdd
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0) Console.WriteLine("FizzBuzz");
                else if (i % 3 == 0) Console.WriteLine("Fizz");
                else if (i % 5 == 0) Console.WriteLine("Buzz");
                else Console.WriteLine(i);
            }

            Console.ReadKey();
        } 
        */
    }
}
