using System;
using NUnit.Framework;

using KataPotter;

namespace KataPotter.Test
{
    [TestFixture]
    public class BookSet_PopCart_With_AtMost_4
    {
        [Test]
        public void Five_Books_Should_Leave_One()
        {
            var bookSet = new BookSet(1, 2, 3, 4, 5);
            var result = bookSet.PopCart(4);
            result = bookSet.PopCart(5);
            Assert.That(result.Length, Is.EqualTo(1));
        }
    }

    [TestFixture]
    public class BookSet_PopCart_With_AtMost_1
    {
        [Test]
        public void Five_Books_Should_Leave_Four()
        {
            var bookSet = new BookSet(1, 2, 3, 4, 5);
            var result = bookSet.PopCart(1);
            result = bookSet.PopCart(5);
            Assert.That(result.Length, Is.EqualTo(4));
        }
    }
}