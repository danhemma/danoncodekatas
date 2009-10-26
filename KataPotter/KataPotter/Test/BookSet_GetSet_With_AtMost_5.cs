using System;
using NUnit.Framework;

namespace KataPotter.Test
{
    [TestFixture]
    public class BookSet_GetSet_With_AtMost_5
    {
        [Test]
        public void Test1()
        {
            var bookSet = new BookSet(1);
            var result = bookSet.PopCart(5);
            Assert.That(result, Is.EquivalentTo(new [] {1}));
        }
        
        [Test]
        public void Test1_1()
        {
            var bookSet = new BookSet(1, 1);
            var result = bookSet.PopCart(5);
            Assert.That(result, Is.EquivalentTo(new [] {1}));
        }
        
        [Test]
        public void Test1_2()
        {
            var bookSet = new BookSet(1, 2);
            var result = bookSet.PopCart(5);
            Assert.That(result, Is.EquivalentTo(new[] { 1, 2 }));
        }
        
        [Test]
        public void Test1_2_Should_Be_Empty_After_Pop()
        {
            var bookSet = new BookSet(1, 2);
            var result = bookSet.PopCart(5);
            result = bookSet.PopCart(5);
            Assert.That(result, Is.EquivalentTo(new int[] {}));
        }
    }
}