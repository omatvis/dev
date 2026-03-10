using System;
using Xunit;
using BigIntegerCalculator;

namespace BigIntegerCalculator.UnitTests
{
    public class BigIntTests
    {
        [Fact]
        public void ToString_BeforeParse_ReturnsZero()
        {
            var b = new BigInt("123");
            Assert.Equal("0", b.ToString());
        }

        [Fact]
        public void Parse_Null_ThrowsArgumentException()
        {
            var b = new BigInt(null);
            Assert.Throws<ArgumentException>(() => b.Parse());
        }

        [Fact]
        public void Parse_Empty_ThrowsArgumentException()
        {
            var b = new BigInt(string.Empty);
            Assert.Throws<ArgumentException>(() => b.Parse());
        }

        [Fact]
        public void Parse_InvalidCharacter_ThrowsArgumentException()
        {
            var b = new BigInt("12a3");
            var ex = Assert.Throws<ArgumentException>(() => b.Parse());
            Assert.Contains("Invalid character", ex.Message);
        }

        [Fact]
        public void Parse_TooLarge_ThrowsInvalidOperationException()
        {
            var large = ((long)int.MaxValue + 1).ToString();
            var b = new BigInt(large);
            Assert.Throws<InvalidOperationException>(() => b.Parse());
        }

        [Fact]
        public void Parse_Zero_SetsBinaryToZero()
        {
            var b = new BigInt("0");
            b.Parse();
            Assert.Equal("0", b.ToString());
            Assert.Equal(0, b[0]);
        }

        [Fact]
        public void Parse_Number_SetsBinaryCorrectly()
        {
            var b = new BigInt("6"); // 6 -> 110
            b.Parse();
            Assert.Equal("110", b.ToString());
            // Indexer returns bits from most-significant (index 0) to least-significant
            Assert.Equal(1, b[0]); // most-significant bit
            Assert.Equal(1, b[1]);
            Assert.Equal(0, b[2]); // least-significant bit
        }
    }
}