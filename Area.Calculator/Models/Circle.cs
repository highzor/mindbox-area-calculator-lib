using Area.Calculator.Interface;
using System;

namespace Area.Calculator.Models;

public class Circle : IFigure
{
    private readonly double _radius;

    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentOutOfRangeException(nameof(radius), radius, "radius can't be less than or equal to 0");

        _radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * Math.Pow(_radius, 2);
    }
}