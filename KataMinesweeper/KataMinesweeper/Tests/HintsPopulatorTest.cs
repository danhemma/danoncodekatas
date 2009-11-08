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
        public void Test_1x2_One_Mine()
        {
            var field = new Field()
                            {
                                ColumnCount = 2,
                                Rows = new FieldRows(new[] { "*." })
                            };
            var populator = new HintsPopulator(field);
            Assert.That(populator.GetHints().Rows, Is.EquivalentTo(new[] { "*1" }));
        }
        
        [Test]
        public void Test_2x2_One_Mine()
        {
            var field = new Field()
                            {
                                ColumnCount = 2,
                                Rows = new FieldRows(new[] { "*.", ".." })
                            };
            var populator = new HintsPopulator(field);
            Assert.That(populator.GetHints().Rows, Is.EquivalentTo(new[] { "*1", "11" }));
        }
        
        [Test]
        public void Test_2x2_Two_Mines()
        {
            var field = new Field()
                            {
                                ColumnCount = 2,
                                Rows = new FieldRows(new[] { "**", "22" })
                            };
            var populator = new HintsPopulator(field);
            Assert.That(populator.GetHints().Rows, Is.EquivalentTo(new[] { "**", "22" }));
        }
    }
}