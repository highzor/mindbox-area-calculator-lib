using Area.Calculator.Models;
using System;
using Xunit;

namespace Area.Calculator.Tests;

public class TriangleTests
{
    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(double.MaxValue, double.MaxValue, double.MaxValue)]
    public void MayBeCreated(double a, double b, double c)
    {
        new Triangle(a, b, c);
    }

    [Theory]
    [InlineData(1, 2, 3)]
    public void ThrowsIfSidesAreInvalid(double a, double b, double c)
    {
        Assert.Throws<ApplicationException>(() => new Triangle(a, b, c));
    }

    [Theory]
    [InlineData(0, 1, 1)]
    [InlineData(1, 0, 1)]
    [InlineData(1, 1, 0)]
    [InlineData(-1, 1, 1)]
    [InlineData(1, -1, 1)]
    [InlineData(1, 1, -1)]
    [InlineData(double.MinValue, double.MinValue, double.MinValue)]
    public void ThrowsWhenSidesAreNonPositive(double a, double b, double c)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(a, b, c));
    }

    [Theory]
    [InlineData(3, 4, 5, 6)]
    [InlineData(double.MaxValue, double.MaxValue, double.MaxValue, double.PositiveInfinity)]
    public void CanCalculateArea(double a, double b, double c, double expectedArea)
    {
        var triangle = new Triangle(a, b, c);
        var area = triangle.CalculateArea();

        Assert.Equal(expectedArea, area);
    }

    [Theory]
    [InlineData(3, 4, 5, true)]
    [InlineData(6, 4, 5, false)]
    public void CanCalculateIfIsRightSquared(double a, double b, double c, bool expectedResult)
    {
        var triangle = new Triangle(a, b, c);
        var isRightAngled = triangle.IsRightAngled();

        Assert.Equal(expectedResult, isRightAngled);
    }
}