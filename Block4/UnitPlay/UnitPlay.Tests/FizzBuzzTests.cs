using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitPlay.Tests
{
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(11)]
        [InlineData(13)]
        [InlineData(14)]

        public void FizzBuzz_When1_Returns1(int input)
        {
            //arr
           // var input = 1;
            //act
            var result = FizzBuzz.Execute(input);
            //assert
            Assert.Equal(input.ToString(), result);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        public void FizzBuzz_WhenDivisivleBy3_ReturnsFizz(int input)
        {
            var result = FizzBuzz.Execute(input);
            Assert.Equal("fizz", result);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        public void FizzBuzz_WhenDivisivleBy5_ReturnsBuzz(int input)
        {
            var result = FizzBuzz.Execute(input);
            Assert.Equal("buzz", result);
        }

        [Theory]
        [InlineData(15)]
        public void FizzBuzz_WhenDivisivleBy3And5_ReturnsFizzBuzz(int input)
        {
            var result = FizzBuzz.Execute(input);
            Assert.Equal("fizzbuzz", result);
        }


    }
}
