using FluentAssertions;
using Geometry.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.UnitTests
{
    [TestFixture]
    public class CustomFigureTests
    {
        [Test]
        public void CommonSquare() 
        {
            Figure customFigure = new Square(2);
            customFigure.Area.Should().Be(4);
        }

    }
    public class Square : Figure
    {
        public double Side { get; }

        public override double Area => Math.Pow(Side,2);

        public Square(double side) 
        {
            Side = side;
        }
    }
}
