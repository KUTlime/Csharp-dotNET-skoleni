using System.ComponentModel;
using FluentAssertions;
using Tuples;

namespace Tuples.Tests;

// Task.GetStatistics

public static class TaskTests
{
    public class GetStatisticsTests
    {
        private const double _delta = 1e-12;
        [Theory]
        [InlineData(new double[] { 1, 2, 3, 4, 5, 6 }, 3.5, 1.707825127659933, 2.916666666666667), DisplayName("Test from Wiki")]
        [InlineData(new double[] { 1, 2, 3, 4, 5 }, 3, 1.4142135623730951, 2.5)]
        [InlineData(new double[] { 1 }, 1, 0, 0)]
        [InlineData(new double[] { }, 0, 0, 0)]
        [InlineData(new double[] { -1, 0, 1 }, 0, 1, 2.0 / 3.0)]
        [InlineData(new double[] { 0, 0, 0 }, 0, 0, 0)]
        [InlineData(new double[] { 1, -1, 1, -1, 1, -1 }, 0, 1, 1)]
        [InlineData(new double[] { 1, 2, 3, 4, 5, -5, -4, -3, -2, -1 }, 0, 3.0276503540974917, 9.166666666666666)]
        [InlineData(new double[] { 1.1, 2.2, 3.3, 4.4, 5.5 }, 3.3, 1.4907119849998598, 2.2116666666666664)]
        [InlineData(new double[] { 1.1, -2.2, 3.3, -4.4, 5.5 }, 0.66, 3.142857142857143, 9.809999999999999)]
        [InlineData(new double[] { 1.1, 2.2, 3.3, 4.4, 5.5, -5.5, -4.4, -3.3, -2.2, -1.1 }, 0, 3.0276503540974917, 9.166666666666666)]
        [InlineData(new double[] { 1, 2, 3, 4, 5, -5, -4, -3, -2, -1, 0, 0, 0, 0, 0 }, 0, 2.958039891549808, 8.766666666666667)]
        [InlineData(new double[] { 1, 2, 3, 4, 5, -5, -4, -3, -2, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 1.0, 1.0)]
        public void GetStatistics_ReturnsCorrectValues(double[] values, double expectedAverage, double expectedDeviation, double expectedVariance)
        {
            var (average, deviation, variance) = Task.GetStatistics(values);

            average.Should().BeApproximately(expectedAverage, _delta);
            deviation.Should().BeApproximately(expectedDeviation, _delta);
            variance.Should().BeApproximately(expectedVariance, _delta);
        }
    }
}
