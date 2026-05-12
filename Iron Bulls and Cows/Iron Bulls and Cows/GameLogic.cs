using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iron_Bulls_and_Cows
{
    internal class GameLogic
    {
        string[] words3 = { "арв", "хур", "мыд", "мад", "фыд", "ных", "тых", "кад", "дур", "тиу", "дин", "был", "дон", "арт", "фос", "хос", "бон", "хай" };
        string[] words4 = { "фарн", "хъаз", "цард", "кард", "къух", "рухс", "цъиу", "дуар", "калм", "фырт", "зард", "дзул", "цыхт", "чызг", "нард", "бикъ" };
        string[] words5 = { "даргъ", "заман", "зарын", "цыргъ", "маргъ", "куыст", "дзырд", "дзыпп", "аууон", "куыдз", "галиу", "гауыз", "давын", "бындз" };


        string secretWord;
        int currentAttempt;
        int maxAttempts = 5;
        int wordLength = 5;

        int CurrentAttempt => currentAttempt;
        bool IsGameOver => currentAttempt >= maxAttempts;
        int MaxAttempts => maxAttempts;
        int WordLength => wordLength;

        public GameLogic(string difficulty)
        {
            SelectWordByDifficulty(difficulty);
            currentAttempt = 0;
        }

        private void SelectWordByDifficulty(string difficulty)
        {
            Random rnd = new Random();

            switch (difficulty.ToLower())
            {
                case "3 дамгъон дзырд":
                    secretWord = words3[rnd.Next(words3.Length)];
                    wordLength = 3;
                    break;
                case "4 дамгъон дзырд":
                    secretWord = words4[rnd.Next(words4.Length)];
                    wordLength = 4;
                    break;
                case "5 дамгъон дзырд":
                    secretWord = words5[rnd.Next(words5.Length)];
                    wordLength = 5;
                    break;
                default:
                    secretWord = words3[rnd.Next(words3.Length)];
                    break;
            }
        }

        public GameResult CheckGuess(string guessWord)
        {
            GameResult result = new GameResult();
            result.GuessWord = guessWord;
            result.Attempt = currentAttempt;

            if (guessWord.Length != secretWord.Length)
            {
                result.Bulls = -1; // Ошибка - не та длина
                return result;
            }

            int bulls = 0;
            int cows = 0;
            bool[] usedSecret = new bool[secretWord.Length];
            bool[] usedGuess = new bool[guessWord.Length];

            result.CellColors = new string[secretWord.Length];

            // Инициализируем массив цветов (по умолчанию белый)
            for (int i = 0; i < secretWord.Length; i++)
            {
                result.CellColors[i] = "White";
            }

            // Сначала ищем быков (точные совпадения)
            for (int i = 0; i < secretWord.Length; i++)
            {
                if (i < guessWord.Length && char.ToUpper(guessWord[i]) == char.ToUpper(secretWord[i]))
                {
                    bulls++;
                    usedSecret[i] = true;
                    usedGuess[i] = true;
                    result.CellColors[i] = "LightGreen";
                }
            }

            // Затем ищем коров (буквы есть, но не на своих местах)
            for (int i = 0; i < guessWord.Length && i < secretWord.Length; i++)
            {
                if (!usedGuess[i])
                {
                    for (int j = 0; j < secretWord.Length; j++)
                    {
                        if (!usedSecret[j] && char.ToUpper(guessWord[i]) == char.ToUpper(secretWord[j]))
                        {
                            cows++;
                            usedSecret[j] = true;
                            if (result.CellColors[i] != "LightGreen")
                            {
                                result.CellColors[i] = "LightYellow";
                            }
                            break;
                        }
                    }
                }
            }

            result.Bulls = bulls;
            result.Cows = cows;

            if (bulls == secretWord.Length)
            {
                currentAttempt = maxAttempts; // Игра окончена победой
            }
            else
            {
                currentAttempt++;
            }

            return result;
        }

        public string GetSecretWord()
        {
            return secretWord;
        }

        public void ResetGame(string difficulty)
        {
            SelectWordByDifficulty(difficulty);
            currentAttempt = 0;
        }
    }
}
