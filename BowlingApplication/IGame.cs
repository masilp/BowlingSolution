using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingApplication
{
    public interface IGame
    {
        void Roll(int knockedPins);
        int Score();
    }
}
