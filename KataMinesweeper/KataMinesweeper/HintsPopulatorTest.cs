using System;
using NUnit.Framework;

namespace KataMinesweeper
{
    [TestFixture]
    public class HintsPopulatorTest
    {
        [Test]
        public void Test_1x1()
        {
            var field = new Field()
                            {
                                ColumnCount = 1, 
                                Rows = new FieldRows(new [] { "*" })
                            };
            var populator = new HintsPopulator(field);
            Assert.That(populator.GetHints().Rows, Is.EquivalentTo(new[] { "*" }));
        }
        
        [Test]
        public void Test_1x2()
        {
            var field = new Field()
                            {
                                ColumnCount = 2,
                                Rows = new FieldRows(new[] { "*." })
                            };
            var populator = new HintsPopulator(field);
            Assert.That(populator.GetHints().Rows, Is.EquivalentTo(new[] { "*1" }));
        }
    }
}