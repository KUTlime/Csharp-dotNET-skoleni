using FluentAssertions;
using Xunit;

namespace Extensions.Tests
{
    public static class StringExtensionsTests
    {
        public class IsValidValueTests
        {
            [Theory]
            [InlineData("Radek")]
            [InlineData("a")]
            [InlineData("Zahradník")]
            [InlineData("zahradník")]
            [InlineData(" zahradník")]
            [InlineData("zahradník ")]
            [InlineData(" zahradník ")]
            [InlineData(" a")]
            [InlineData("a ")]
            [InlineData(" a ")]
            [InlineData(" A")]
            [InlineData("A ")]
            [InlineData(" A ")]
            public void ValidValueTest(string inputValue)
            {
                inputValue.IsValidValue().Should().Be(true);
            }

            [Theory]
            [InlineData("")]
            [InlineData(" ")]
            [InlineData(null)]
            [InlineData("  ")]
            [InlineData("\n")]
            [InlineData("\t")]
            [InlineData("\n\n")]
            [InlineData("\t\t")]
            public void InValidValueTest(string? inputValue)
            {
                inputValue.IsValidValue().Should().Be(false);
            }
        }

        public class IsValidPathTests
        {
            [Theory]
            [InlineData("")]
            [InlineData(" ")]
            [InlineData(null)]
            [InlineData("  ")]
            [InlineData("\n")]
            [InlineData("\t")]
            [InlineData("\n\n")]
            [InlineData("\t\t")]
            [InlineData(@"a:\?")]
            public void NonPathExistsTest(string? inputValue)
            {
                inputValue.IsValidPath().Should().Be(false);
            }

            [Theory]
            [InlineData("a:\\")]
            public void NonPathExistsBasedOnGuidTest(string inputValue)
            {
                inputValue += Guid.NewGuid();
                inputValue.IsValidPath().Should().Be(false);
            }

            [Fact]
            public void PathExistsTest()
            {
                string inputValue = Environment.GetEnvironmentVariable("Temp") + $"Test_{Guid.NewGuid()}.txt";
                File.WriteAllText(inputValue, "Test value");
                inputValue.IsValidPath().Should().Be(true);
            }
        }
    }
}