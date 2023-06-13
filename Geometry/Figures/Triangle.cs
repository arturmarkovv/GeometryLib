using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Figures
{
    public class Triangle : Figure
    {
        public double? Hypotenuse { get; }
        public double? SmallLeg { get; }
        public double? BigLeg { get; }
        public double[] Sides { get; }
        public override double Area { get; }
        public TriangleType Type { get; private set; }

        public Triangle(double a, double b, double c)
        {
            try
            {
                ValidateSides(a, b, c);
            }
            catch (Exception)
            {
                throw;
            }

            Sides = new double[3] { a, b, c };

            Area = CalculateArea();
            DetermineType();
        }

        private void ValidateSides(double a, double b, double c)
        {
            if (a <= 0) throw new ArgumentOutOfRangeException(
                nameof(a),
                a,
                "Стороны треугольника должны быть положительными числами");
            if (b <= 0) throw new ArgumentOutOfRangeException(
                nameof(b),
                b,
                "Стороны треугольника должны быть положительными числами");
            if (c <= 0) throw new ArgumentOutOfRangeException(
                nameof(c),
                c,
                "Стороны треугольника должны быть положительными числами");
            if (!(a + b >= c && a + c >= b && b + c >= a))
            {
                throw new ArgumentException("Треугольника с такими сторонами не существует");
            }
        }

        public double CalculateArea()
        {
            if (Type == TriangleType.Right)
            {
                var hypotenuse = Sides.Max();
                var legs = Sides.Where(s => s != hypotenuse).ToList();
                return legs[0] * legs[1] / 2;
            }
            else
            {
                var p = (Sides[0] + Sides[1] + Sides[2]) / 2;
                return Math.Sqrt(p * (p - Sides[0]) * (p - Sides[1]) * (p - Sides[2]));
            }
        }
        private void DetermineType()
        {
            var uniqueSidesCount = Sides.Distinct().Count();
            Type = uniqueSidesCount switch
            {
                1 => TriangleType.Equilateral,
                2 => TriangleType.Isosceles,
                _ => CheckIsRight() ? TriangleType.Right : TriangleType.Default
            };
        }
        private bool CheckIsRight()
        {
            var hypotenuse = Sides.Max();
            var legs = Sides.Where(s => s != hypotenuse).ToList();
            return Math.Pow(hypotenuse, 2) == legs.Select(l => Math.Pow(l, 2)).Sum();
        }
        public enum TriangleType
        {
            Default,
            Right,
            Isosceles,
            Equilateral
        }
    }
}

