using System.Collections.Generic;

namespace BowlingApplication
{
    public static class Helper
    {
        public static IEnumerable<int> GetScores(this IList<int> pins)
        {
            // iterate by 2 rolls in each frames
            for (int i = 0; i + 1 < pins.Count; i += 2)
            {
                // FrameType.Normal
                if (pins[i] + pins[i + 1] < 10)
                {
                    yield return pins[i] + pins[i + 1];
                    continue;
                }

                // Bonus roll
                if (i + 2 >= pins.Count)
                    yield break;

                yield return pins[i] + pins[i + 1] + pins[i + 2];

                // FrameType.Strike; move by 1
                if (pins[i] == 10)
                    i--;
            }
        }
    }
}
