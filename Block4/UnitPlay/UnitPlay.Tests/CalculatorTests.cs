using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using System.Collections;

namespace UnitPlay.Tests
{
    public class CalculatorTests
    {
        private readonly Calculator _calculator;

        public CalculatorTests()
        {
            _calculator = new Calculator();
        }

        [Fact]
        public void Calculator_When1AddTo1_Returns2()
        { 
            var result = _calculator.Sum(1, 1);
            Assert.Equal(2, result);
        }

        [Fact]
        public void Calculator_When1AddTo1_Returns2_FluentAssert()
        {
            var result = _calculator.Sum(1, 1);
            result.Should().Be(2);
        }

        [Fact]
        public void Calculator_When0AddTo0_Returns0_FluentAssert()
        {
            var result = _calculator.Sum(0, 0);
            result.Should().Be(0);
        }

        [Theory]
        [InlineData(2, 1, 1)]
        [InlineData(0, 0, 0)]
        [InlineData(0, -1, 1)]
        public void Calculator_AddTwoNumbers_ReturnsCorrectSum(int expected, int first, int second)
        {
            var result =_calculator.Sum(first, second);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Calculator_AddTwoNumbers_ReturnsCorrectSum_v2(int expected, int first, int second)
        {
            var result = _calculator.Sum(first, second);
            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(MyClass))]
        public void Calculator_AddTwoNumbers_ReturnsCorrectSum_v3(int expected, int first, int second)
        {
            var result = _calculator.Sum(first, second);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 2, 1, 1 };
            yield return new object[] { 0, 0, 0 };
            yield return new object[] { 0, -1, 1 };
            yield return new object[] { 0, 1, -1 };
            yield return new object[] { 100, 99, 1 };
        }

    }

    class MyClass : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2, 1, 1 };
            yield return new object[] { 0, 0, 0 };
            yield return new object[] { 0, -1, 1 };
            yield return new object[] { 0, 1, -1 };
            yield return new object[] { 100, 99, 1 };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
