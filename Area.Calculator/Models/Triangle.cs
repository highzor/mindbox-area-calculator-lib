using Area.Calculator.Interface;
using System;
using System.Linq;

namespace Area.Calculator.Models;

public class Triangle : IFigure
{
    private readonly double _a;
    private readonly double _b;
    private readonly double _c;

    const double TOLERANCE = 0.000000001;

    public Triangle(double a, double b, double c)
    {
        checkAreSidesValid(a, b, c);

        _a = a;
        _b = b;
        _c = c;
    }

    private void checkAreSidesValid(double a, double b, double c)
    {
        isSideNegative(a, nameof(a));
        isSideNegative(b, nameof(b));
        isSideNegative(c, nameof(c));

        var isTriangleForm = a + b > c && a + c > b && b + c > a;
        if (!isTriangleForm)
            throw new ApplicationException($"given arguments: {nameof(a)}: {a}, {nameof(b)}: {b}, {nameof(c)}: {c} are invalid");
    }

    private void isSideNegative(double sideValue, string sideName)
    {
        if (sideValue <= 0)
            throw new ArgumentOutOfRangeException(nameof(sideValue), sideValue, $"side can't be less than 0, {sideName}");
    }

    public bool IsRightAngled()
    {
        var sides = new[] { _a, _b, _c };
        var maxSide = sides.Max();

        return Math.Abs(2 * Math.Pow(maxSide, 2) - (Math.Pow(_a, 2) + Math.Pow(_b, 2) + Math.Pow(_c, 2))) < TOLERANCE;
    }

    public double CalculateArea()
    {
        var semiPerimeter = (_a + _b + _c) / 2;

        return Math.Sqrt(semiPerimeter * (semiPerimeter - _a) * (semiPerimeter - _b) * (semiPerimeter - _c));
    }
}