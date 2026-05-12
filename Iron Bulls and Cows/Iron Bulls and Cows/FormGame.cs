using System;
using System.Drawing;
using System.Windows.Forms;

namespace Iron_Bulls_and_Cows
{
    public partial class MainForm : Form
    {
        private readonly string[] words = { "цыргъ", "маргъ", "куыст", "дзырд", "дзыпп", "аууон", "куыдз", "галиу", "гауыз", "давын", "даргъ", "заман", "зарын" };
        private string secretWord;
        private int attempt;

        public MainForm()
        {
            InitializeComponent();
            InitializeDataGridView();
            NewGame();

            buttonOK.Click += buttonOK_Click;
            buttonNewGame.Click += buttonNewGame_Click;
        }

        private void InitializeDataGridView()
        {
            dataGridViewUserWord.RowCount = 5;

            for (int i = 0; i < 5; i++)
            {
                dataGridViewUserWord.Columns[i].Width = 70; 
                dataGridViewUserWord.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                for (int j = 0; j < 5; j++)
                {
                    dataGridViewUserWord.Rows[j].Height = 30;
                    dataGridViewUserWord.Rows[j].Cells[i].ReadOnly = true;
                }
            }
        }


        private void buttonOK_Click(object sender, EventArgs e)
        {
            CheckWord();
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void NewGame()
        {
            Random rnd = new Random();
            secretWord = words[rnd.Next(words.Length)];
            attempt = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    dataGridViewUserWord.Rows[i].Cells[j].Value = "";
                    dataGridViewUserWord.Rows[i].Cells[j].ReadOnly = true;
                    dataGridViewUserWord.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                dataGridViewUserWord.Rows[0].Cells[i].ReadOnly = false;
            }

            labelBulls.Text = "Галтæ - 0";
            labelCows.Text = "Хъуццытæ - 0";
        }

        private void CheckWord()
        {
            string guess = "";
            bool hasEmptyCells = false;

            for (int i = 0; i < 5; i++)
            {
                object val = dataGridViewUserWord.Rows[attempt].Cells[i].Value;
                if (val == null || string.IsNullOrEmpty(val.ToString()))
                {
                    guess += " ";
                    hasEmptyCells = true;
                }
                else
                {
                    guess += val.ToString().ToUpper();
                }
            }

            if (hasEmptyCells)
            {
                MessageBox.Show("Ныффыс ФОНДЗ дамгъæйы!");
                return;
            }

            int bulls = 0;
            int cows = 0;
            bool[] usedSecret = new bool[5];
            bool[] usedGuess = new bool[5];

            for (int i = 0; i < 5; i++)
            {
                if (guess[i] == char.ToUpper(secretWord[i]))
                {
                    bulls++;
                    usedSecret[i] = true;
                    usedGuess[i] = true;
                    dataGridViewUserWord.Rows[attempt].Cells[i].Style.BackColor = Color.LightGreen;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (!usedGuess[i])
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (!usedSecret[j] && guess[i] == char.ToUpper(secretWord[j]))
                        {
                            cows++;
                            usedSecret[j] = true;
                            dataGridViewUserWord.Rows[attempt].Cells[i].Style.BackColor = Color.LightYellow;
                            break;
                        }
                    }
                }
            }

            labelBulls.Text = $"Галтæ - {bulls}";
            labelCows.Text = $"Хъуццытæ - {cows}";

            if (bulls == 5)
            {
                MessageBox.Show("Рамбылдтай!");
                NewGame();
                return;
            }

            attempt++;

            if (attempt >= 5)
            {
                MessageBox.Show($"Нæ дын рауади! Дзырд: {secretWord}");
                NewGame();
                return;
            }

            for (int i = 0; i < 5; i++)
            {
                dataGridViewUserWord.Rows[attempt].Cells[i].ReadOnly = false;
                dataGridViewUserWord.Rows[attempt].Cells[i].Style.BackColor = Color.White;
            }
            dataGridViewUserWord.CurrentCell = dataGridViewUserWord.Rows[attempt].Cells[0];
        }
    }
}