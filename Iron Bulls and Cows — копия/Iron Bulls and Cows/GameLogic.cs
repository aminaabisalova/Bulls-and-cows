using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iron_Bulls_and_Cows
{
    internal class GameLogic
    {
        string[] words3 = { "арв", "хур", "мыд", "мад", "фыд", "ных", "тых", "кад", "дур", "тиу", "дин", "был", "дон", "арт", "фос", "хос", "бон", "хай"};
        string[] words4 = {  "фарн", "хъаз", "цард", "кард", "къух", "рухс", "цъиу", "дуар", "калм", "фырт", "зард", "дзул", "цыхт", "чызг", "нард", "бикъ"};
        string[] words5 = { "даргъ", "заман", "зарын", "цыргъ", "маргъ", "куыст", "дзырд", "дзыпп", "аууон", "куыдз", "галиу", "гауыз", "давын", "бындз"};
        
        
        string secretWord;
        int currentAttempt;
        int maxAttempts = 5;
        int wordLength;

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
    }
}
