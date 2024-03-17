using Area.Calculator.Models;
using System;
using Xunit;

namespace Area.Calculator.Tests;

public class CircleTest
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void ThrowsWhenRadiusIsInvalid(double r)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(r));
    }

    [Theory]
    [InlineData(1, Math.PI)]
    [InlineData(2, 12.5663706144)]
    public void CanCalculateArea(double r, double expectedArea)
    {
        var circle = new Circle(r);
        var area = circle.CalculateArea();

        Assert.Equal(expectedArea, area, 10);
    }
}