using System;
using System.Text;

namespace FizzBuzz
{
    public class FizzBuzz
    {
        private const string MagicStringFizzBuzz = "FizzBuzz";
        private const string MagicStringFizz = "Fizz";
        private const string MagicStringBuzz = "Buzz";

        public string GetFizzBuzzTextValues(int startValue, int endValue)
        {
            var sbTextValues = new StringBuilder();
            for (int currentNumber = startValue; currentNumber <= endValue; currentNumber++)
            {
                sbTextValues.AppendLine(GetFizzBuzzText(currentNumber));
            }

            return sbTextValues.ToString();
        }

        public string GetFizzBuzzText(int numberToTest)
        {
            if (CheckFizz(numberToTest) && CheckBuzz(numberToTest)) return MagicStringFizzBuzz;
            if (CheckFizz(numberToTest)) return MagicStringFizz;
            if (CheckBuzz(numberToTest)) return MagicStringBuzz;
            
            return numberToTest.ToString();
        }

        private bool CheckFizz(int numberToTest)
        {
            return (numberToTest % 3 == 0);
        }
        private bool CheckBuzz(int numberToTest)
        {
            return (numberToTest % 5 == 0);
        }
    }
}