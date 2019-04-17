using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingApplication
{
    public class Frame
    {
        public bool IsFrameClosed { get; set; }
        public bool IsLastFrame { get; set; }

        public List<int> RollResults { get; set; } = new List<int>();
        public int FrameNumber { get; set; }
        public int TotalPins { get; set; }
        public int BonusPins { get; set; }
        public int FrameScore { get; set; }
        public FrameType FrameType { get; set; }


        private int _remainingPins;

        private bool _bonusRollAllowed;

        /// <summary>
        /// Constructor with Parameter: Number of Pins
        /// </summary>
        /// <param name="startingPins">Number set at Game level (=10)</param>
        public Frame(int startingPins)
        {
            _remainingPins = startingPins;
        }

        /// <summary>
        /// Validate and Record Rollings 
        /// </summary>
        /// <param name="pins">Number of Pins knocked down in a roll</param>
        public void RecordRolling(int pins)
        {
            ValidateRoll(pins);
            RollResults.Add(pins);
            _remainingPins -= pins;
            ResetPinsForLastFrame();
            IsFrameClosed = SetFrameClosed();


            if (IsFrameClosed)
            {
                if (RollResults.Count == 1)
                    TotalPins = RollResults.First();
                if (RollResults.Count == 2)
                    TotalPins = RollResults.First() + RollResults.Last();
                if (RollResults.Count == 3)
                {
                    TotalPins = RollResults.First() + RollResults[1];
                    BonusPins = RollResults.Last();
                }
            }

        }

        #region "Private Methods"

        private bool SetFrameClosed()
        {
            return !IsLastFrame && _remainingPins == 0 || !IsLastFrame && RollResults.Count == 2 || RollResults.Count == 3;
        }

        private void ResetPinsForLastFrame()
        {
            if (IsLastFrame && _remainingPins == 0)
            {
                _remainingPins = 10;
                _bonusRollAllowed = true;
            }
        }

        private void ValidateRoll(int pins)
        {
            if (_remainingPins == 0) // no pins left in a frame
                throw new InvalidOperationException("Not allowed to roll when there are no remaining pins");

            if (!IsLastFrame && RollResults.Count == 2 ||
                IsLastFrame && RollResults.Count == 2 && !_bonusRollAllowed ||
                RollResults.Count > 2) // maximum 3
            {
                throw new InvalidOperationException($"Not allowed to roll more than {RollResults.Count} rolls in this frame");
            }

            if (pins < 0 || pins > _remainingPins)
            {
                throw new ArgumentException($"Rolling not allowed!"); // Wrong argument passed
            }
        }

        #endregion
    }
}
