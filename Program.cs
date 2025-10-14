using System;

public class HalfPlane
{
    private double _a1, _a2, _b;
    public double A1 => _a1;
    public double A2 => _a2;
    public double B => _b;

    public HalfPlane(double a1, double a2, double b)
    {
        _a1 = a1;
        _a2 = a2;
        _b = b;
    }

    public void PrintCoefficients()
    {
        Console.WriteLine($"Коефіцієнти півплощини: a1={_a1}, a2={_a2}, b={_b}");
    }

    public bool ContainsPoint(double x1, double x2)
    {
        return _a1 * x1 + _a2 * x2 + 0 <= _b;
    }
} 

// Похідний клас "півпростір"
public class HalfSpace : HalfPlane
{
    private double _a3;
    public double A3 => _a3;

    public HalfSpace(double a1, double a2, double a3, double b) : base(a1, a2, b)
    {
        _a3 = a3;
    }

    public new void PrintCoefficients()
    {
        Console.WriteLine($"Коефіцієнти півпростору: a1={A1}, a2={A2}, a3={_a3}, b={B}");
    }

    public bool ContainsPoint(double x1, double x2, double x3)
    {
        return A1 * x1 + A2 * x2 + _a3 * x3 <= B;
    }
}

class Program
{
    static void Main()
    {
        // Півплощина
        Console.WriteLine("Введіть коефіцієнти для півплощини (a1 a2 b):");
        var hpCoeffs = Console.ReadLine().Split();
        var halfPlane = new HalfPlane(
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
        Console.WriteLine("Введіть коефіцієнти для півпростору (a1 a2 a3 b):");
        var hsCoeffs = Console.ReadLine().Split();
        var halfSpace = new HalfSpace(
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
