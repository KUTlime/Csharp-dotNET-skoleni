namespace TestableFizzBuzz.Tests;

public static class FizzBuzzTests
{
    public class FunctionalImplementationTests
    {
        [Fact]
        public void BasicTest()
        {
            // AAA
            // Arrange
            // Act
            // Assert
            var testvalues = new FizzBuzz()
                .FunctionalImplementation()
                .ToList();

            testvalues
                .Should()
                .HaveCount(100)
                .And
                .HaveElementAt(0, "1")
                .And
                .HaveElementAt(1, "2")
                .And
                .HaveElementAt(2, "Fizz")
                .And
                .HaveElementAt(4, "Buzz")
                .And
                .HaveElementAt(14, "FizzBuzz")
                .And
                .HaveElementAt(41, "Fizz")
                .And
                .HaveElementAt(42, "43");
        }
    }
}