using System;
using NUnit.Framework;

namespace KataPotter.Test
{
    [TestFixture]
    public class BookSet_NumberOfUnprocessed
    {
        [Test]
        public void Test1()
        {
            var bookSet = new BookSet(1);
            Assert.That(bookSet.CountFor(1), Is.EqualTo(1));
            Assert.That(bookSet.CountFor(2), Is.EqualTo(0));
            Assert.That(bookSet.CountFor(3), Is.EqualTo(0));
            Assert.That(bookSet.CountFor(4), Is.EqualTo(0));
            Assert.That(bookSet.CountFor(5), Is.EqualTo(0));
        }
        
        [Test]
        public void Test1_2_3()
        {
            var bookSet = new BookSet(1, 2, 3);
            Assert.That(bookSet.CountFor(1), Is.EqualTo(1));
            Assert.That(bookSet.CountFor(2), Is.EqualTo(1));
            Assert.That(bookSet.CountFor(3), Is.EqualTo(1));
            Assert.That(bookSet.CountFor(4), Is.EqualTo(0));
            Assert.That(bookSet.CountFor(5), Is.EqualTo(0));
        }
        
        [Test]
        public void Test1_1_2_3()
        {
            var bookSet = new BookSet(1, 1, 2, 3);
            Assert.That(bookSet.CountFor(1), Is.EqualTo(2));
            Assert.That(bookSet.CountFor(2), Is.EqualTo(1));
            Assert.That(bookSet.CountFor(3), Is.EqualTo(1));
            Assert.That(bookSet.CountFor(4), Is.EqualTo(0));
            Assert.That(bookSet.CountFor(5), Is.EqualTo(0));
        }
    }
}