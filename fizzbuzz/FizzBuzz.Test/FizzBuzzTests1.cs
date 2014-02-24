using NUnit.Framework;

namespace FizzBuzz.Test
{
    [TestFixture]
    public class FizzBuzzTests1
    {
        [TestCase(1, "1")]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(7, "7")]
        [TestCase(15, "FizzBuzz")]
        public void NumericValueHasCorrectFizzBuzzTextValue(int inputValue, string outputValue)
        {
            var fizzBuzz = new FizzBuzz();
            var result = fizzBuzz.GetFizzBuzzText(inputValue);
            Assert.That(result, Is.EqualTo(outputValue));
        }

        [Test]
        public void NumberRangeOf15HasCorrectTextOutput()
        {
            var fizzBuzz = new FizzBuzz();
            var result = fizzBuzz.GetFizzBuzzTextValues(1, 15).Replace("\r\n", " ").Trim();
            Assert.That(result, Is.EqualTo("1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz"));
        }
    }
}
