using System;
using NUnit.Framework;

namespace KataMinesweeper
{
    [TestFixture]
    public class GameTest
    {
        [Test]
        public void Test_1_Single_Box()
        {
            var input = 
                "1 1" + Environment.NewLine +
                "*";
            var output =
                "Field #1:" + Environment.NewLine +
                "*";
            Assert.That((new Game(input)).ShowHints(), Is.EqualTo(output));
        }
        
        [Test]
        public void Test_2_Single_Box()
        {
            var input = 
                "1 1" + Environment.NewLine +
                "*"+ Environment.NewLine + 
                "1 1" + Environment.NewLine +
                "*";

            var output =
                "Field #1:" + Environment.NewLine +
                "*" + Environment.NewLine +
                "Field #2:" + Environment.NewLine +
                "*";
            Assert.That((new Game(input)).ShowHints(), Is.EqualTo(output));
        }
    }
}