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
                                Rows = 1, 
                                Columns = 1, 
                                Content = "*" + Environment.NewLine
                            };
            var populator = new HintsPopulator(field);
            Assert.That(populator.GetHints().Content, Is.EqualTo("*" + Environment.NewLine));
        }
        
        [Test]
        public void Test_1x2()
        {
            var field = new Field()
                            {
                                Rows = 1, 
                                Columns = 2, 
                                Content = "*." + Environment.NewLine
                            };
            var populator = new HintsPopulator(field);
            Assert.That(populator.GetHints().Content, Is.EqualTo("*1" + Environment.NewLine));
        }
    }
}