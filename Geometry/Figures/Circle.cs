using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Figures
{
    public class Circle : Figure
    {
        public double Radius { get; }
        public override double Area { get => Math.Pow(Radius, 2) * Math.PI; }
        public Circle(double radius)
        {
            if (radius <= 0) throw new ArgumentOutOfRangeException(nameof(radius), radius, "Радиус должен быть положительным числом");
            Radius = radius;
        }
    }
}
