using FluentAssertions;
using Geometry.Figures;

namespace Geometry.UnitTests
{
    [TestFixture]
    public class CircleTests
    {
        [Test]
        public void Unit�ircle()
        {
            new Circle(1).Area.Should().Be(Math.PI);
        }
        [TestCase(0, TestName = "Zero radius")]
        [TestCase(-6, TestName = "Negative radius")]
        public void �ircleInitializationErrorTest(int radius)
        {
            Action act = () => new Circle(radius);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}