using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Iron_Bulls_and_Cows
{
    public partial class MainForm : Form
    {
        int wordLength;
        GameLogic gameLogic = new GameLogic();
        int currentAttempt;                
        List<GameResult> gameLog;          

        
        string[] words3 = { "арв", "хур", "мыд", "мад", "фыд", "ных", "тых", "кад", "дур", "тиу", "дин", "был", "дон", "арт", "фос", "хос", "бон", "хай" };
        string[] words4 = { "фарн", "хъаз", "цард", "кард", "къух", "рухс", "цъиу", "дуар", "калм", "фырт", "зард", "дзул", "цыхт", "чызг", "нард", "бикъ" };
        string[] words5 = { "даргъ", "заман", "зарын", "цыргъ", "маргъ", "куыст", "дзырд", "дзыпп", "аууон", "куыдз", "галиу", "гауыз", "давын", "бындз" };

        public MainForm(int wordLength)
        {
            this.wordLength = wordLength;
            InitializeComponent();

            dataGridViewUserWord.RowCount = 5;
            dataGridViewUserWord.ColumnCount = wordLength;
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
            else
            {
                MessageBox.Show("Неверная длина слова. Игра будет закрыта.");
                this.Close();
                return;
            }

     
            string secretWord = words[new Random().Next(words.Length)];
            gameLogic.StartNewGame(secretWord);

            currentAttempt = 0;
            gameLog = new List<GameResult>();

            
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
                string letter = (val == null) ? " " : val.ToString().Trim().ToUpper();
                if (letter == "")
                    letter = " ";
                guess += letter;
            }

       
            string errorMessage;
            GameResult result = gameLogic.CheckGuess(guess, out errorMessage);
            if (result == null)
            {
                MessageBox.Show(errorMessage);
                return;
            }

       
            gameLog.Add(result);

         
            for (int c = 0; c < wordLength; c++)
            {
                Color color;
                if (result.LetterStates[c] == LetterStatus.CorrectPosition)
                    color = Color.LightGreen;
                else if (result.LetterStates[c] == LetterStatus.WrongPosition)
                    color = Color.LightYellow;
                else
                    color = Color.White;

                dataGridViewUserWord.Rows[currentAttempt].Cells[c].Style.BackColor = color;
            }

         
            labelBulls.Text = "Галтæ - " + result.Bulls.ToString();
            labelCows.Text = "Хъуццытæ - " + result.Cows.ToString();

       
            if (result.IsWin)
            {
                MessageBox.Show("Поздравляем! Вы угадали слово!");
                SaveLogToFile();
                StartNewGame();
                return;
            }

            currentAttempt++;
            if (currentAttempt >= 5)
            {
                MessageBox.Show("Вы проиграли! Загаданное слово: " + gameLogic.SecretWord);
                SaveLogToFile();
                StartNewGame();
                return;
            }

            dataGridViewUserWord.Rows[currentAttempt].ReadOnly = false;
            dataGridViewUserWord.CurrentCell = dataGridViewUserWord.Rows[currentAttempt].Cells[0];
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            if (gameLog.Count > 0)
                SaveLogToFile();
            StartNewGame();
        }

        private void SaveLogToFile()
        {
                using (StreamWriter writer = new StreamWriter("game_log.txt", true))
                {
                    writer.WriteLine("Игра от " + DateTime.Now.ToString());
                    writer.WriteLine("Загаданное слово: " + gameLogic.SecretWord);
                    foreach (GameResult res in gameLog)
                    {
                        writer.WriteLine("Попытка: " + res.Guess +
                                         " | Быки: " + res.Bulls +
                                         " | Коровы: " + res.Cows +
                                         " | Победа: " + res.IsWin);
                    }
                    writer.WriteLine();
                }
                MessageBox.Show("Попытка сохранёна в game_log.txt");
        }

     
    }
}