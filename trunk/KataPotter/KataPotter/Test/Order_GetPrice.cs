using System;
using NUnit.Framework;

namespace KataPotter.Test
{
    [TestFixture]
    public class Order_GetPrice
    {
        [Test]
        public void Buy_1_Should_Cost_8()
        {
            Assert.That(new Order(1).GetPrice(), Is.EqualTo(8));
        }

        [Test]
        public void Buy_1_1_Should_Cost_16()
        {
            Assert.That(new Order(1, 1).GetPrice(), Is.EqualTo(16));
        }

        [Test]
        public void Buy_1_2_1_2_Should_Get_5_Percent_Off()
        {
            Assert.That(
                new Order(1, 2, 1, 2).GetPrice(), Is.EqualTo(32 * 0.95));
        }

        [Test]
        public void Buy_1_2_3_4_5_Should_Get_25_Percent_Off()
        {
            Assert.That(
                new Order(1, 2, 3, 4, 5).GetPrice(), Is.EqualTo(40 * 0.75));
        }

        [Test]
        public void Buy_1_2_3_4_Should_Get_20_Percent_Off()
        {
            Assert.That(
                new Order(1, 2, 3, 4).GetPrice(), Is.EqualTo(32 * 0.8));
        }

        [Test]
        public void Buy_1_2_3_Should_Get_10_Percent_Off()
        {
            Assert.That(new Order(1, 2, 3).GetPrice(), Is.EqualTo(24 * 0.9));
        }

        [Test]
        public void Buy_1_2_Should_Get_5_Percent_Off()
        {
            Assert.That(new Order(1, 2).GetPrice(), Is.EqualTo(16 * 0.95));
        }

        [Test]
        public void Final_Test()
        {
            Assert.That(
                new Order(1, 1, 2, 2, 3, 3, 4, 5).GetPrice(), 
                    Is.EqualTo(51.20m));
        }
        
        [Test]
        public void Final_Final_Test()
        {
            Assert.That(
                new Order(1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 5, 5).GetPrice(), 
                    Is.EqualTo(81.20m));
        }
        
        [Test]
        public void Beat_Test2()
        {
            Assert.That(
                new Order(1, 1, 1, 1, 2, 3, 4).GetPrice(), 
                    Is.EqualTo(49.60m));
        }
        
        [Test]
        public void Buy_1_1_2_3_4_5()
        {
            Assert.That(
                new Order(1, 1, 2, 3, 4, 5).GetPrice(), 
                    Is.EqualTo(5 *8m * 0.75m + 8));
        }
    }
}