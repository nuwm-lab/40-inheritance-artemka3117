using System;
using System.Globalization;

namespace Geometry
{
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
        public HalfPlane() { }

        public void SetCoefficients(double a1, double a2, double b)
        {
            _a1 = a1;
            _a2 = a2;
            _b = b;
        }

        public virtual void PrintCoefficients()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"HalfPlane: a1={_a1}, a2={_a2}, b={_b}";
        }

        public virtual bool ContainsPoint(double x1, double x2)
        {
            return _a1 * x1 + _a2 * x2 <= _b;
        }
    }

    public class HalfSpace : HalfPlane
    {
        private double _a3;
        public double A3 => _a3;

        public HalfSpace(double a1, double a2, double a3, double b) : base(a1, a2, b)
        {
            _a3 = a3;
        }
        public HalfSpace() { }

        public void SetCoefficients(double a1, double a2, double a3, double b)
        {
            base.SetCoefficients(a1, a2, b);
            _a3 = a3;
        }

        public override void PrintCoefficients()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"HalfSpace: a1={A1}, a2={A2}, a3={_a3}, b={B}";
        }

        public override bool ContainsPoint(double x1, double x2)
        {
            throw new NotSupportedException("Для HalfSpace використовуйте ContainsPoint(x1, x2, x3)");
        }

        public bool ContainsPoint(double x1, double x2, double x3)
        {
            return A1 * x1 + A2 * x2 + _a3 * x3 <= B;
        }
    }
}

using Geometry;

class Program
{
    static void Main()
    {
        // Створення об'єкта півплощини
        HalfPlane hp = null;
        while (true)
        {
            Console.WriteLine("Введіть коефіцієнти для HalfPlane (a1 a2 b):");
            var input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("Ввід перервано.");
                return;
            }
            var arr = input.Split();
            if (arr.Length != 3)
            {
                Console.WriteLine("Помилка: потрібно 3 коефіцієнти.");
                continue;
            }
            if (double.TryParse(arr[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double a1) &&
                double.TryParse(arr[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double a2) &&
                double.TryParse(arr[2], NumberStyles.Float, CultureInfo.InvariantCulture, out double b))
            {
                hp = new HalfPlane(a1, a2, b);
                break;
            }
            else
            {
                Console.WriteLine("Помилка: некоректний ввід.");
            }
        }
        hp.PrintCoefficients();
        while (true)
        {
            Console.WriteLine("Введіть точку для HalfPlane (x1 x2):");
            var input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("Ввід перервано.");
                return;
            }
            var arr = input.Split();
            if (arr.Length != 2)
            {
                Console.WriteLine("Помилка: потрібно 2 координати.");
                continue;
            }
            if (double.TryParse(arr[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double x1) &&
                double.TryParse(arr[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double x2))
            {
                Console.WriteLine(hp.ContainsPoint(x1, x2)
                    ? "Точка належить півплощині"
                    : "Точка не належить півплощині");
                break;
            }
            else
            {
                Console.WriteLine("Помилка: некоректний ввід.");
            }
        }

        // Створення об'єкта півпростору
        HalfSpace hs = null;
        while (true)
        {
            Console.WriteLine("Введіть коефіцієнти для HalfSpace (a1 a2 a3 b):");
            var input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("Ввід перервано.");
                return;
            }
            var arr = input.Split();
            if (arr.Length != 4)
            {
                Console.WriteLine("Помилка: потрібно 4 коефіцієнти.");
                continue;
            }
            if (double.TryParse(arr[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double sa1) &&
                double.TryParse(arr[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double sa2) &&
                double.TryParse(arr[2], NumberStyles.Float, CultureInfo.InvariantCulture, out double sa3) &&
                double.TryParse(arr[3], NumberStyles.Float, CultureInfo.InvariantCulture, out double sb))
            {
                hs = new HalfSpace(sa1, sa2, sa3, sb);
                break;
            }
            else
            {
                Console.WriteLine("Помилка: некоректний ввід.");
            }
        }
        hs.PrintCoefficients();
        while (true)
        {
            Console.WriteLine("Введіть точку для HalfSpace (x1 x2 x3):");
            var input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("Ввід перервано.");
                return;
            }
            var arr = input.Split();
            if (arr.Length != 3)
            {
                Console.WriteLine("Помилка: потрібно 3 координати.");
                continue;
            }
            if (double.TryParse(arr[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double sx1) &&
                double.TryParse(arr[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double sx2) &&
                double.TryParse(arr[2], NumberStyles.Float, CultureInfo.InvariantCulture, out double sx3))
            {
                Console.WriteLine(hs.ContainsPoint(sx1, sx2, sx3)
                    ? "Точка належить півпростору"
                    : "Точка не належить півпростору");
                break;
            }
            else
            {
                Console.WriteLine("Помилка: некоректний ввід.");
            }
        }
    }
}
