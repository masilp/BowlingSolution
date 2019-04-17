using System;
using System.Collections.Generic;

namespace BowlingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            var rollings = new List<int> { 1, 4, 4, 5, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 10, 10, 10 };

            foreach (int pins in rollings)
            {
                game.Roll(pins);
            }

            Console.WriteLine("Score: " + game.Score());

            Console.ReadLine();
        }
    }
}
