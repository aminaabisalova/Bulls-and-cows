using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Iron_Bulls_and_Cows
{
    public partial class MainForm : Form
    {

        string playerName;
        int wordLength;
        string secretWord;       
        int currentAttempt;                
        List<GameResult> gameLog;
        GameHistory gameHistory;


        string[] words3 = { "арв", "хур", "мыд", "мад", "фыд", "ных", "тых", "кад", "дур", "тиу", "дин", "был", "дон", "арт", "фос", "хос", "бон", "хай" };
        string[] words4 = { "фарн", "хъаз", "цард", "кард", "къух", "рухс", "цъиу", "дуар", "калм", "фырт", "зард", "дзул", "цыхт", "чызг", "нард", "бикъ" };
        string[] words5 = { "даргъ", "заман", "зарын", "цыргъ", "маргъ", "куыст", "дзырд", "дзыпп", "аууон", "куыдз", "галиу", "гауыз", "давын", "бындз" };

        public MainForm(int wordLength, string playerName)
        {
            this.playerName = playerName;
            this.wordLength = wordLength;
            InitializeComponent();

            dataGridViewUserWord.RowCount = 5;
            dataGridViewUserWord.ColumnCount = wordLength;
            gameHistory = new GameHistory(playerName);

            switch (wordLength)
            {  
               case 3:labelHint.Text = "Ныффыс дзырд æртæ дамгъæйæ"; break;
               case 4: labelHint.Text = "Ныффыс дзырд цыппар дамгъæйæ"; break;
               case 5: labelHint.Text = "Ныффыс дзырд фондз дамгъæйæ"; break;
            }

            StartNewGame();            

        }

        private void StartNewGame()
        {
            
            string[] words = null;
            if (wordLength == 3)
                words = words3;
            else if (wordLength == 4)
                words = words4;
            else if (wordLength == 5)
                words = words5;
            
            secretWord = words[new Random().Next(words.Length)].Trim().ToUpper();

            currentAttempt = 0;        
          
            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < wordLength; c++)
                {
                    dataGridViewUserWord.Rows[r].Cells[c].Value = "";
                    dataGridViewUserWord.Rows[r].Cells[c].Style.BackColor = Color.White;
                }
            }

       
            for (int r = 1; r < 5; r++)
                dataGridViewUserWord.Rows[r].ReadOnly = true;
                dataGridViewUserWord.Rows[0].ReadOnly = false;

            if (dataGridViewUserWord.Rows[0].Cells.Count > 0)
                dataGridViewUserWord.CurrentCell = dataGridViewUserWord.Rows[0].Cells[0];

            labelBulls.Text = "Галтæ - 0";
            labelCows.Text = "Хъуццытæ - 0";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
         
            string guess = "";
            for (int c = 0; c < wordLength; c++)
            {
                object val = dataGridViewUserWord.Rows[currentAttempt].Cells[c].Value;
                string letter;
                if (val == null)
                    letter = " ";
                else
                {
                    letter = val.ToString().Trim().ToUpper();
                    if (letter == "")
                        letter = " ";
                }
                guess += letter;
            }

       
            string errorMessage;
            GameResult result = CheckGuess(guess, out errorMessage);
            if (result == null)
            {
                MessageBox.Show(errorMessage);
                return;
            }

            Color[] colors = result.CellColors;
            for (int c = 0; c < wordLength; c++)
            {
                dataGridViewUserWord.Rows[currentAttempt].Cells[c].Style.BackColor = colors[c];
            }


            labelBulls.Text = "Галтæ - " + result.Bulls.ToString();
            labelCows.Text = "Хъуццытæ - " + result.Cows.ToString();
                     

            if (result.IsWin)
            {
                MessageBox.Show("Поздравляем! Вы угадали слово!");
                GameRecord record = new GameRecord(
                    playerName,
                    DateTime.Now,
                    wordLength,
                    secretWord,
                    true,  
                    currentAttempt + 1  
                );
                gameHistory.Add(record);

                StartNewGame();
                return;
            }

            currentAttempt++;
            if (currentAttempt >= 5)
            {

                MessageBox.Show("Вы проиграли! Загаданное слово: " + secretWord);

                GameRecord record = new GameRecord(
                    playerName,
                    DateTime.Now,
                    wordLength,
                    secretWord,
                    false,  
                    5     
                );
                gameHistory.Add(record);                

                StartNewGame();
                return;
            }
            dataGridViewUserWord.Rows[currentAttempt].ReadOnly = false;
            dataGridViewUserWord.CurrentCell = dataGridViewUserWord.Rows[currentAttempt].Cells[0];
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }
        
        private GameResult CheckGuess(string guess, out string errorMessage)
        {
            errorMessage = null;

            if (string.IsNullOrEmpty(secretWord))
            {
                errorMessage = "Игра не начата.";
                return null;
            }

            if (string.IsNullOrWhiteSpace(guess))
            {
                errorMessage = "Догадка не может быть пустой.";
                return null;
            }

            guess = guess.Trim().ToUpper();

            if (guess.Length != secretWord.Length)
            {
                errorMessage = "Длина слова должна быть " + secretWord.Length + " символов.";
                return null;
            }

            string secret = secretWord;
            int len = secret.Length;
            int bulls = 0, cows = 0;
            bool[] usedSecret = new bool[len];
            bool[] usedGuess = new bool[len];
            Color[] cellColors = new Color[len];

            for (int i = 0; i < len; i++)
            {
                if (guess[i] == secret[i])
                {
                    bulls++;
                    usedSecret[i] = true;
                    usedGuess[i] = true;
                    cellColors[i] = Color.LightGreen;   
                }
            }

            for (int i = 0; i < len; i++)
            {
                if (!usedGuess[i])
                {
                    bool foundCow = false;
                    for (int j = 0; j < len; j++)
                    {
                        if (!usedSecret[j] && guess[i] == secret[j])
                        {
                            cows++;
                            usedSecret[j] = true;
                            cellColors[i] = Color.LightYellow; 
                            foundCow = true;
                            break;
                        }
                    }
                    if (!foundCow)
                    {
                        cellColors[i] = Color.White; 
                    }
                }
            }

            bool isWin = (bulls == len);
            return new GameResult(guess, bulls, cows, isWin, cellColors);
        }
    }
}