using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iron_Bulls_and_Cows
{
    public class GameRecord
    {
        public string PlayerName { get; }
        public DateTime Date { get; }
        public int WordLength { get; }
        public string SecretWord { get; }
        public bool IsWin { get; }
        public int AttemptsUsed { get; }

        public GameRecord(string playerName, DateTime date, int wordLength,
                          string secretWord, bool isWin, int attemptsUsed)
        {
            PlayerName = playerName;
            Date = date;
            WordLength = wordLength;
            SecretWord = secretWord;
            IsWin = isWin;
            AttemptsUsed = attemptsUsed;
        }
    }
}
