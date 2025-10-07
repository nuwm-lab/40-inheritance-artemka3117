using System;

// Клас півплощина
public class HalfPlane
{
    protected double a, b, c;

    public void SetCoefficients(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public void PrintCoefficients()
    {
        Console.WriteLine($"HalfPlane coefficients: a={a}, b={b}, c={c}");
    }

    public bool ContainsPoint(double x1, double x2)
    {
        return a * x1 + b * x2 + c >= 0;
    }
}

// Похідний клас півпростір
public class HalfSpace : HalfPlane
{
    private double d;

    public void SetCoefficients(double a, double b, double c, double d)
    {
        this.a = a;
        this.b = b;
        this.c = c;
        this.d = d;
    }

    public new void PrintCoefficients()
    {
        Console.WriteLine($"HalfSpace coefficients: a={a}, b={b}, c={c}, d={d}");
    }

    public bool ContainsPoint(double x1, double x2, double x3)
    {
        return a * x1 + b * x2 + c * x3 + d >= 0;
    }
}

class Program
{
    static void Main()
    {
        // Півплощина
        var halfPlane = new HalfPlane();
        Console.WriteLine("Введіть коефіцієнти для півплощини (a b c):");
        var hpCoeffs = Console.ReadLine().Split();
        halfPlane.SetCoefficients(
            double.Parse(hpCoeffs[0]),
            double.Parse(hpCoeffs[1]),
            double.Parse(hpCoeffs[2])
        );
        halfPlane.PrintCoefficients();
        Console.WriteLine("Введіть точку для перевірки (x1 x2):");
        var hpPoint = Console.ReadLine().Split();
        bool hpResult = halfPlane.ContainsPoint(
            double.Parse(hpPoint[0]),
            double.Parse(hpPoint[1])
        );
        Console.WriteLine(hpResult ? "Точка належить півплощині" : "Точка не належить півплощині");

        // Півпростір
        var halfSpace = new HalfSpace();
        Console.WriteLine("Введіть коефіцієнти для півпростору (a b c d):");
        var hsCoeffs = Console.ReadLine().Split();
        halfSpace.SetCoefficients(
            double.Parse(hsCoeffs[0]),
            double.Parse(hsCoeffs[1]),
            double.Parse(hsCoeffs[2]),
            double.Parse(hsCoeffs[3])
        );
        halfSpace.PrintCoefficients();
        Console.WriteLine("Введіть точку для перевірки (x1 x2 x3):");
        var hsPoint = Console.ReadLine().Split();
        bool hsResult = halfSpace.ContainsPoint(
            double.Parse(hsPoint[0]),
            double.Parse(hsPoint[1]),
            double.Parse(hsPoint[2])
        );
        Console.WriteLine(hsResult ? "Точка належить півпростору" : "Точка не належить півпростору");
    }
}
