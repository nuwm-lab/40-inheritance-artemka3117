using System;

class HalfPlane
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
        Console.WriteLine($"HalfPlane: a={a}, b={b}, c={c}");
    }

    public bool ContainsPoint(double x1, double x2)
    {
        // a*x1 + b*x2 + c >= 0 — точка належить півплощині
        return a * x1 + b * x2 + c >= 0;
    }
}

class HalfSpace : HalfPlane
{
    private double d;

    public void SetCoefficients(double a, double b, double c, double d)
    {
        base.SetCoefficients(a, b, c);
        this.d = d;
    }

    public new void PrintCoefficients()
    {
        Console.WriteLine($"HalfSpace: a={a}, b={b}, c={c}, d={d}");
    }

    public bool ContainsPoint(double x1, double x2, double x3)
    {
        // a*x1 + b*x2 + c*x3 + d >= 0 — точка належить півпростору
        return a * x1 + b * x2 + c * x3 + d >= 0;
    }
}

class Program
{
    static void Main()
    {
        // Створення об'єкта півплощини
        HalfPlane hp = new HalfPlane();
        hp.SetCoefficients(1, -2, 3);
        hp.PrintCoefficients();

        Console.WriteLine("Введіть точку для HalfPlane (x1 x2):");
        var planeInput = Console.ReadLine().Split();
        double x1 = double.Parse(planeInput[0]);
        double x2 = double.Parse(planeInput[1]);
        Console.WriteLine(hp.ContainsPoint(x1, x2)
            ? "Точка належить півплощині"
            : "Точка не належить півплощині");

        // Створення об'єкта півпростору
        HalfSpace hs = new HalfSpace();
        hs.SetCoefficients(1, 2, -1, 4);
        hs.PrintCoefficients();

        Console.WriteLine("Введіть точку для HalfSpace (x1 x2 x3):");
        var spaceInput = Console.ReadLine().Split();
        double sx1 = double.Parse(spaceInput[0]);
        double sx2 = double.Parse(spaceInput[1]);
        double sx3 = double.Parse(spaceInput[2]);
        Console.WriteLine(hs.ContainsPoint(sx1, sx2, sx3)
            ? "Точка належить півпростору"
            : "Точка не належить півпростору");
    }
}
