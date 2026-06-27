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
        string secretWordR;
        int currentAttempt;  
        GameHistory gameHistory;


        string[] words3 = { "арв", "хур", "мыд", "мад", "фыд", "тых", "дур", "дон", "арт", "фос", "бон" };
        string[] words4 = { "хъаз", "цард", "кард", "къух", "цъиу", "дуар", "калм", "фырт", "дзул", "цыхт", "чызг" };
        string[] words5 = { "маргъ", "куыст", "дзырд", "дзыпп", "аууон", "куыдз", "гауыз", "бындз" };

        string[] words3R = { "небо", "солнце", "мёд", "мама", "папа", "сила", "камень", "вода", "огонь", "скот", "день"};
        string[] words4R = { "гусь", "жизнь", "нож", "рука", "птица", "дверь", "змея", "сын", "хлеб", "сыр", "девочка" };
        string[] words5R = { "птица", "работа", "слово", "карман", "тень", "собака", "ковер", "муха" };

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
            string[] wordsR = null;
            if (wordLength == 3)
            {
                words = words3;
                wordsR = words3R;
            }
            else if (wordLength == 4)
            {
                words = words4;
                wordsR = words4R;
            }
            else if (wordLength == 5)
            {
                words = words5;
                wordsR = words5R;
            }

            int secInd = new Random().Next(words.Length);

            secretWord = words[secInd].ToUpper();
            secretWordR = wordsR[secInd].ToUpper();

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

            GameResult result = CheckGuess(guess);
            if (result == null)
                return;
            

            Color[] colors = result.CellColors;
            for (int c = 0; c < wordLength; c++)
            {
                dataGridViewUserWord.Rows[currentAttempt].Cells[c].Style.BackColor = colors[c];
            }


            labelBulls.Text = "Галтæ - " + result.Bulls.ToString();
            labelCows.Text = "Хъуццытæ - " + result.Cows.ToString();
                     

            if (result.IsWin)
            {
                MessageBox.Show("Рамбылдай! Æмбæхст дзырд уыди: " + secretWord+ ". Тæлмац: "+secretWordR);
                GameRecord record = new GameRecord(playerName, DateTime.Now, wordLength, secretWord, true, currentAttempt + 1);
                gameHistory.Add(record);

                StartNewGame();
                return;
            }

            currentAttempt++;
            if (currentAttempt >= 5)
            {

                MessageBox.Show("Фæхæрд дæ! Æмбæхст дзырд уыди: " + secretWord + ". Тæлмац: " + secretWordR);

                GameRecord record = new GameRecord(playerName, DateTime.Now, wordLength, secretWord, false, 5 );
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
        
        private GameResult CheckGuess(string guess)
        {
            if (string.IsNullOrWhiteSpace(guess))
            {
                MessageBox.Show("Дзырд афтид нæ вæййы!");
                return null;
            }

            if (guess.Length != secretWord.Length)
            {
                MessageBox.Show("Дзырды дæргъ - " + secretWord.Length + " дамгъæйы.");
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