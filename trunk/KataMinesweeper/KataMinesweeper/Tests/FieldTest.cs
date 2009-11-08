using NUnit.Framework;

namespace KataMinesweeper
{
    [TestFixture]
    public class FieldTest
    {
        [Test]
        public void Test1()
        {
            var field = new Field {ColumnCount = 2, Rows = new FieldRows(new[] {"**", "**"})};
            Assert.That(field.MineAt(0, 0), Is.True);
            Assert.That(field.MineAt(0, 1), Is.True);
            Assert.That(field.MineAt(1, 1), Is.True);
            Assert.That(field.MineAt(1, 0), Is.True);
            Assert.That(field.MineAt(0, 2), Is.False);
            Assert.That(field.MineAt(2, 0), Is.False);
        }        
    }
}