using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iron_Bulls_and_Cows
{
    public class GameLogic
    {
        public string SecretWord { get; private set; }

        /// <summary>
        /// Начинает новую игру с заданным секретным словом.
        /// </summary>
        public void StartNewGame(string secretWord)
        { 
            SecretWord = secretWord.Trim().ToUpper();
        }

        /// <summary>
        /// Проверяет догадку. Возвращает null при ошибке, описание ошибки – в errorMessage.
        /// </summary>
        public GameResult CheckGuess(string guess, out string errorMessage)
        {
            errorMessage = null;

            if (string.IsNullOrWhiteSpace(guess))
            {
                errorMessage = "Догадка не может быть пустой.";
                return null;
            }

            guess = guess.Trim().ToUpper();

            if (guess.Length != SecretWord.Length)
            {
                errorMessage = "Длина слова должна быть " + SecretWord.Length.ToString() + " символов.";
                return null;
            }

            int len = SecretWord.Length;
            int bulls = 0, cows = 0;
            bool[] usedSecret = new bool[len];
            bool[] usedGuess = new bool[len];
            LetterStatus[] states = new LetterStatus[len];

            // Быки
            for (int i = 0; i < len; i++)
            {
                if (guess[i] == SecretWord[i])
                {
                    bulls++;
                    usedSecret[i] = usedGuess[i] = true;
                    states[i] = LetterStatus.CorrectPosition;
                }
            }

            // Коровы
            for (int i = 0; i < len; i++)
            {
                if (!usedGuess[i])
                {
                    for (int j = 0; j < len; j++)
                    {
                        if (!usedSecret[j] && guess[i] == SecretWord[j])
                        {
                            cows++;
                            usedSecret[j] = true;
                            states[i] = LetterStatus.WrongPosition;
                            break;
                        }
                    }
                    if (states[i] != LetterStatus.WrongPosition)
                        states[i] = LetterStatus.NotPresent;
                }
            }

            bool isWin = (bulls == len);
            return new GameResult(guess, bulls, cows, isWin, states);
        }
    }
}

