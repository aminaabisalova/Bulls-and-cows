using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iron_Bulls_and_Cows
{
    public class GameResult
    {
        public string Guess { get; }
        public int Bulls { get; }
        public int Cows { get; }
        public bool IsWin { get; }
        public Color[] CellColors { get; }

        public GameResult(string guess, int bulls, int cows, bool isWin, Color[] cellColors)
        {
            Guess = guess;
            Bulls = bulls;
            Cows = cows;
            IsWin = isWin;
            CellColors = cellColors;
        }
    }
}
