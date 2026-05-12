using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iron_Bulls_and_Cows
{
    internal class GameResult
    {
        public string GuessWord { get; set; }
        public int Bulls { get; set; }
        public int Cows { get; set; }
        public int Attempt { get; set; }
        public DateTime CheckTime { get; set; }
        public string[] CellColors { get; set; }

        public GameResult()
        {
            CellColors = new string[5];
            CheckTime = DateTime.Now;
        }
    }
}
