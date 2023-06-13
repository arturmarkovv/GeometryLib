using FluentAssertions;
using Geometry.Figures;

namespace Geometry.UnitTests
{
    [TestFixture]
    public class TriangleTests
    {
        [Test]
        public void RightTriangle()
        {
            var triangle = new Triangle(3, 4, 5);
            triangle.Area.Should().Be(6);
            triangle.Type.Should().Be(Triangle.TriangleType.Right);
        }
        [Test]
        public void EquilateralTriangle()
        {
            var triangle = new Triangle(2, 2, 2);
            triangle.Area.Should().Be(Math.Sqrt(3));
            triangle.Type.Should().Be(Triangle.TriangleType.Equilateral);
        }
        [Test]
        public void IsoscelesTriangle()
        {
            var triangle = new Triangle(6, 5, 5);
            triangle.Area.Should().Be(12);
            triangle.Type.Should().Be(Triangle.TriangleType.Isosceles);
        }
        [Test]
        public void CustomTriangle()
        {
            var triangle = new Triangle(149, 148, 4);
            triangle.Area.Should().Be(210);
            triangle.Type.Should().Be(Triangle.TriangleType.Default);
        }
        [Test]
        public void LineTriangle()
        {
            var triangle = new Triangle(7, 14, 7);
            triangle.Area.Should().Be(0);
            triangle.Type.Should().Be(Triangle.TriangleType.Isosceles);
        }
        [Test]
        public void ImpossibleTriangle()
        {
            Action act = () => new Triangle(7, 15, 7);
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void ZeroSideTriangle()
        {
            Action act = () => new Triangle(7, 0, 7);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
