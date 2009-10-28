using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling.Kata1
{
    public class Frame
    {
        private readonly List<int> rollsAddingPoints = new List<int>();

        public Frame(int pins)
        {
            Add(pins);
        }

        public bool Complete
        {
            get
            {
                return CompleteRegular || CompleteStrike || CompleteSpare;
            }
        }

        private bool CompleteRegular
        {
            get { return Count == 2 && SumFirstTwo < 10; }
        }

        private int SumFirstTwo
        {
            get { return rollsAddingPoints[0] + rollsAddingPoints[1]; }
        }

        public bool Spare
        {
            get { return Count > 1 && SumFirstTwo == 10; }
        }

        private bool CompleteSpare
        {
            get { return Spare && Count == 3; }
        }

        public bool Strike
        {
            get { return Count > 0 && rollsAddingPoints[0] == 10; }
        }

        public bool CompleteStrike
        {
            get { return Strike && Count == 3; }
        }

        public int Sum
        {
            get { return Complete ? rollsAddingPoints.Sum() : 0; }
        }

        private int Count
        {
            get { return rollsAddingPoints.Count(); }
        }

        public bool SpareOrStrike
        {
            get { return Spare || Strike; }
        }

        public void AddUnlessComplete(int pins)
        {
            if (!Complete)
                Add(pins);
        }

        private void Add(int pins)
        {
            rollsAddingPoints.Add(pins);
        }
    }
}