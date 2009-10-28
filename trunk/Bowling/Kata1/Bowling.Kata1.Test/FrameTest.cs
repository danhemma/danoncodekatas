using NUnit.Framework;

namespace Bowling.Kata1.Test
{
    [TestFixture]
    public class FrameTest
    {
        [Test]
        public void Frame_1_Should_Not_Be_Complete()
        {
            var frame = new Frame(1);
            Assert.That(frame.Complete, Is.False);
        }
        
        [Test]
        public void Frame_1_Should_Have_Score_0()
        {
            var frame = new Frame(1);
            Assert.That(frame.Sum, Is.EqualTo(0));
        }
        
        [Test]
        public void Frame_1_1_Should_Have_Score_2()
        {
            var frame = new Frame(1);
            frame.AddUnlessComplete(1);
            Assert.That(frame.Sum, Is.EqualTo(2));
        }
        
        [Test]
        public void Frame_1_1_Should_Be_Full()
        {
            var frame = new Frame(1);
            frame.AddUnlessComplete(1);
            Assert.That(frame.Complete, Is.True);
        }
        
        [Test]
        public void Frame_1_1_Should_Not_Be_Spare()
        {
            var frame = new Frame(1);
            frame.AddUnlessComplete(1);
            Assert.That(frame.Spare, Is.False);
        }
        
        [Test]
        public void Frame_1_1_Should_Not_Be_Strike()
        {
            var frame = new Frame(1);
            frame.AddUnlessComplete(1);
            Assert.That(frame.Strike, Is.False);
        }
        
        [Test]
        public void Frame_10_Should_Be_Strike()
        {
            var frame = new Frame(10);
            Assert.That(frame.Strike, Is.True);
        }
        
        [Test]
        public void Frame_10_Should_Not_Be_Complete()
        {
            var frame = new Frame(10);
            Assert.That(frame.Complete, Is.False);
        }
        
        [Test]
        public void Frame_10_1_1_Should_Be_Strike()
        {
            var frame = new Frame(10);
            frame.AddUnlessComplete(1);
            frame.AddUnlessComplete(1);
            Assert.That(frame.Strike, Is.True);
        }
        
        [Test]
        public void Frame_10_1_1_Should_Be_CompleteStrike()
        {
            var frame = new Frame(10);
            frame.AddUnlessComplete(1);
            frame.AddUnlessComplete(1);
            Assert.That(frame.CompleteStrike, Is.True);
        }
        
        [Test]
        public void Frame_1_9_Should_Not_Be_Complete()
        {
            var frame = new Frame(1);
            frame.AddUnlessComplete(9);
            Assert.That(frame.Complete, Is.False);
        }
        
        [Test]
        public void Frame_1_9_4_Should_Be_Complete()
        {
            var frame = new Frame(1);
            frame.AddUnlessComplete(9);
            frame.AddUnlessComplete(4);
            Assert.That(frame.Complete, Is.True);
        }
        
        [Test]
        public void Frame_1_9_4_Should_Have_Sum_14()
        {
            var frame = new Frame(1);
            frame.AddUnlessComplete(9);
            frame.AddUnlessComplete(4);
            Assert.That(frame.Sum, Is.EqualTo(14));
        }
        
        [Test]
        public void Frame_10_10_Should_Not_Be_Complete()
        {
            var frame = new Frame(10);
            frame.AddUnlessComplete(10);
            Assert.That(frame.Complete, Is.False);
        }
        
        [Test]
        public void Frame_10_1_9_Should_Be_Complete()
        {
            var frame = new Frame(10);
            frame.AddUnlessComplete(1);
            frame.AddUnlessComplete(9);
            Assert.That(frame.Complete, Is.True);
        }
        
        [Test]
        public void Frame_10_1_9_Should_Be_Complete_Strike()
        {
            var frame = new Frame(10);
            frame.AddUnlessComplete(1);
            frame.AddUnlessComplete(9);
            Assert.That(frame.CompleteStrike, Is.True);
        }

        [Test]
        public void Frame_10_1_9_Should_Have_Sum_20()
        {
            var frame = new Frame(10);
            frame.AddUnlessComplete(1);
            frame.AddUnlessComplete(9);
            Assert.That(frame.Sum, Is.EqualTo(20));
        }
        
        [Test]
        public void Frame_10_10_9_Should_Be_Complete()
        {
            var frame = new Frame(10);
            frame.AddUnlessComplete(10);
            frame.AddUnlessComplete(9);
            Assert.That(frame.Complete, Is.True);
        }
        
        [Test]
        public void Frame_10_10_10_Should_Be_Complete()
        {
            var frame = new Frame(10);
            frame.AddUnlessComplete(10);
            frame.AddUnlessComplete(10);
            Assert.That(frame.Complete, Is.True);
        }
    }
}