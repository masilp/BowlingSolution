using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingApplication
{
    public class Game : IGame
    {
        private const int MaximumFrame = 10;
        private const int StartingPins = 10;

        private readonly List<Frame> _frames = new List<Frame>();
        private int _score;

        public void Roll(int pins)
        {
            ValidateRoll();

            _frames.Last().RecordRolling(pins);

            SetFrameType();
        }

        public int Score()
        {
            List<int> pins = new List<int>();

            foreach (Frame frame in _frames)
            {
                frame.RollResults.ForEach(p => pins.Add(p));
            }

            _score = pins.GetScores().Sum();

            return _score;
        }

        #region "Private Methods"

        private void ValidateRoll()
        {
            if (_frames.Any() && _frames.Last().IsLastFrame && _frames.Last().IsFrameClosed)
            {
                throw new InvalidOperationException($" Maximum Frame limit {MaximumFrame} has been reached! ");
            }

            if (_frames.Count == 0 || _frames.Last().IsFrameClosed)
            {
                var isLastFrame = _frames.Count == MaximumFrame - 1;
                _frames.Add(new Frame(StartingPins) { IsLastFrame = isLastFrame, FrameNumber = _frames.Count + 1 });
            }
        }

        private void SetFrameType()
        {
            var frame = _frames.Last();

            if (frame.RollResults.First() == MaximumFrame)
                _frames.Last().FrameType = FrameType.Strike;

            if (frame.FrameType != FrameType.Strike && frame.TotalPins == StartingPins)
                _frames.Last().FrameType = FrameType.Spare;

            if (frame.TotalPins < StartingPins)
                _frames.Last().FrameType = FrameType.Normal;
        }

        #endregion
    }
}
