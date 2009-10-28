using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling.Kata1
{
    public class ScoreCard 
    {
        private readonly List<Frame> frames = new List<Frame>();

        protected Frame Last
        {
            get { return frames.LastOrDefault(); }
        }

        public int Count
        {
            get { return frames.Count; }
        }

        public Frame this[int index]
        {
            get { return frames[index]; }
        }

        protected Frame SecondLast
        {
            get { return Count > 1 ? this[Count - 2] : null; }
        }

        public int Score
        {
            get
            {
                return frames.Sum(f => f.Sum);
            }
        }

        public void AddRoll(int pins)
        {
            if (Complete())
                throw new InvalidOperationException("No more rolls on this ScoreCard");
            bool shouldAddFrame = NewFrameNeeded();
            RegisterRoll(pins);
            if (shouldAddFrame)
                frames.Add(new Frame(pins));
        }

        private bool Complete()
        {
            return Count == 10 && Last.Complete;
        }

        private bool NewFrameNeeded()
        {
            return Count < 10 && (Last == null || Last.Complete || Last.SpareOrStrike);
        }

        private void RegisterRoll(int pins)
        {
            if (Last != null)
                Last.AddUnlessComplete(pins);
            if (SecondLast != null)
                SecondLast.AddUnlessComplete(pins);
        }
    }
}