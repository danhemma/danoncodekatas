using System;
using NUnit.Framework;

namespace Bowling.Kata1.Test
{
    [TestFixture]
    public class ScoreCardTest
    {
        [Test]
        public void Serie_1_Should_Have_1_Frames()
        {
            var scoreCard = new ScoreCard();
            scoreCard.AddRoll(1);
            Assert.That(scoreCard.Count, Is.EqualTo(1));
        }

        [Test]
        public void Serie_1_Should_Have_Score_0()
        {
            var scoreCard = new ScoreCard();
            scoreCard.AddRoll(1);
            Assert.That(scoreCard.Score, Is.EqualTo(0));
        }

        [Test]
        public void Serie_1_1_Should_Have_Score_2()
        {
            var game = new ScoreCard();
            game.AddRoll(1);
            game.AddRoll(1);
            Assert.That(game.Score, Is.EqualTo(2));
        }

        [Test]
        public void Serie_1_9_4_Should_Have_Score_14()
        {
            var scoreCard = new ScoreCard();
            scoreCard.AddRoll(1);
            scoreCard.AddRoll(9);
            scoreCard.AddRoll(4);
            Assert.That(scoreCard.Score, Is.EqualTo(14));
        }
        
        [Test]
        public void Serie_1_1_Should_Have_1_Frames()
        {
            var scoreCard = new ScoreCard();
            scoreCard.AddRoll(1);
            scoreCard.AddRoll(1);
            Assert.That(scoreCard.Count, Is.EqualTo(1));
        }
        
        [Test]
        public void Serie_1_1_1_Should_Have_2_Frames()
        {
            var scoreCard = new ScoreCard();
            scoreCard.AddRoll(1);
            scoreCard.AddRoll(1);
            scoreCard.AddRoll(1);
            Assert.That(scoreCard.Count, Is.EqualTo(2));
        }
        
        [Test]
        public void Serie_1_9_1_Should_Have_2_Frames()
        {
            var scoreCard = new ScoreCard();
            scoreCard.AddRoll(1);
            scoreCard.AddRoll(9);
            scoreCard.AddRoll(1);
            Assert.That(scoreCard.Count, Is.EqualTo(2));
        }
        
        [Test]
        public void Serie_10_10_10_Should_Have_3_Frames()
        {
            var scoreCard = new ScoreCard();
            scoreCard.AddRoll(10);
            scoreCard.AddRoll(10);
            scoreCard.AddRoll(10);
            Assert.That(scoreCard.Count, Is.EqualTo(3));
        }
        
        [Test]
        public void Serie_10_10_10_Should_Have_30_In_First_Frame()
        {
            var scoreCard = new ScoreCard();
            scoreCard.AddRoll(10);
            scoreCard.AddRoll(10);
            scoreCard.AddRoll(10);
            Assert.That(scoreCard[0].Sum, Is.EqualTo(30));
        }
        
        [Test]
        public void Serie_10_10_10_Should_Have_Score_0_In_Second_Frame()
        {
            var scoreCard = new ScoreCard();
            scoreCard.AddRoll(10);
            scoreCard.AddRoll(10);
            scoreCard.AddRoll(10);
            Assert.That(scoreCard[1].Sum, Is.EqualTo(0));
        }

        [Test]
        public void Serie_1_9_4_5_Should_Have_Score_23()
        {
            var scoreCard = new ScoreCard();
            scoreCard.AddRoll(1);
            scoreCard.AddRoll(9);
            scoreCard.AddRoll(4);
            scoreCard.AddRoll(5);
            Assert.That(scoreCard.Score, Is.EqualTo(23));
        }

        [Test]
        public void Perfect_Game_Should_Have_Score_300()
        {
            var scoreCard = new ScoreCard();
            for (int i = 0; i < 12; i++)
                scoreCard.AddRoll(10);
            Assert.That(scoreCard.Score, Is.EqualTo(300));
        }
        
        [Test]
        public void Perfect_Game_Should_Have_10_Frames()
        {
            var scoreCard = new ScoreCard();
            for (int i = 0; i < 12; i++)
                scoreCard.AddRoll(10);
            Assert.That(scoreCard.Count, Is.EqualTo(10));
        }
        
        [Test]
        public void Should_Not_Be_Able_To_AddRoll_After_Perfect_Game()
        {
            var scoreCard = new ScoreCard();
            for (int i = 0; i < 12; i++)
                scoreCard.AddRoll(10);

            AssertCannotAddRoll(scoreCard);
        }

        [Test]
        public void Should_Not_Be_Able_To_AddRoll_After_Worst_Game_Possible()
        {
            var scoreCard = new ScoreCard();
            for (int i = 0; i < 20; i++)
                scoreCard.AddRoll(0);

            AssertCannotAddRoll(scoreCard);
        }

        private void AssertCannotAddRoll(ScoreCard scoreCard)
        {
            try
            {
                scoreCard.AddRoll(0);
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {}
        }
    }
}