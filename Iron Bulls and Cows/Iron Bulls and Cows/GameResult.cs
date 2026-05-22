using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iron_Bulls_and_Cows
{
    public enum LetterStatus
    {
        CorrectPosition,    
        WrongPosition,      
        NotPresent          
    }
    public class GameResult
    {
        public string Guess { get; }
        public int Bulls { get; }
        public int Cows { get; }
        public bool IsWin { get; }
        public LetterStatus[] LetterStates { get; }

        public GameResult(string guess, int bulls, int cows, bool isWin, LetterStatus[] letterStates)
        {
            Guess = guess;
            Bulls = bulls;
            Cows = cows;
            IsWin = isWin;
            LetterStates = letterStates;
        }

        public override string ToString()
        {
            return $"Слово: {Guess} | Быки: {Bulls} | Коровы: {Cows} | Победа: {IsWin}";
        }
    }
}
