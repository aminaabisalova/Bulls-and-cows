using System;
using System.Drawing;
using System.Windows.Forms;

namespace Iron_Bulls_and_Cows
{
    public partial class MainForm : Form
    {
        private GameLogic gameLogic;
        private string currentDifficulty;
        private int currentWordLength;

        public MainForm(string difficulty)
        {
            currentDifficulty = difficulty;
            InitializeComponent();
            gameLogic = new GameLogic(currentDifficulty);
            currentWordLength = gameLogic.WordLength;
            InitializeDataGridView(currentWordLength);
            NewGame();
            buttonOK.Click += buttonOK_Click;
            buttonNewGame.Click += buttonNewGame_Click;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void InitializeDataGridView(int columnCount)
        {
            dataGridViewUserWord.RowCount = 5;          // всегда 5 попыток
            dataGridViewUserWord.ColumnCount = columnCount;

            // Настраиваем столбцы
            for (int i = 0; i < columnCount; i++)
            {
                dataGridViewUserWord.Columns[i].Width = 70;
                dataGridViewUserWord.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewUserWord.Columns[i].HeaderText = (i + 1).ToString();

                for (int j = 0; j < 5; j++)
                {
                    dataGridViewUserWord.Rows[j].Height = 30;
                    dataGridViewUserWord.Rows[j].Cells[i].ReadOnly = true;
                    dataGridViewUserWord.Rows[j].Cells[i].Value = "";
                    dataGridViewUserWord.Rows[j].Cells[i].Style.BackColor = Color.White;
                }
            }

            dataGridViewUserWord.AllowUserToAddRows = false;
            dataGridViewUserWord.RowHeadersVisible = false;
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
            gameLogic.ResetGame(currentDifficulty);
            currentWordLength = gameLogic.WordLength;

            // Если длина слова изменилась (при перезапуске с другой сложности) — пересоздаём таблицу
            if (dataGridViewUserWord.ColumnCount != currentWordLength)
            {
                dataGridViewUserWord.Columns.Clear();
                dataGridViewUserWord.Rows.Clear();
                InitializeDataGridView(currentWordLength);
            }
            else
            {
                // Очищаем только содержимое
                for (int row = 0; row < 5; row++)
                {
                    for (int col = 0; col < currentWordLength; col++)
                    {
                        dataGridViewUserWord.Rows[row].Cells[col].Value = "";
                        dataGridViewUserWord.Rows[row].Cells[col].Style.BackColor = Color.White;
                        dataGridViewUserWord.Rows[row].Cells[col].ReadOnly = true;
                    }
                }
            }

            // Разблокируем первую строку
            for (int col = 0; col < currentWordLength; col++)
            {
                dataGridViewUserWord.Rows[0].Cells[col].ReadOnly = false;
            }

            labelBulls.Text = "Галтæ - 0";
            labelCows.Text = "Хъуццытæ - 0";
            this.Text = $"Угадай слово - Сложность: {currentDifficulty} (слово из {currentWordLength} букв)";

            dataGridViewUserWord.CurrentCell = dataGridViewUserWord.Rows[0].Cells[0];
        }


        private void CheckWord()
        { 
            string guess = "";
            bool hasEmptyCells = false;

            // Получаем текущую строку, которую заполняет пользователь
            int currentRowIndex = gameLogic.CurrentAttempt;

            // Проверяем, что все ячейки текущей строки заполнены
            for (int i = 0; i < currentWordLength; i++)
            {
                // !!! ИСПРАВЛЕНИЕ: Используем currentRowIndex, а не gameLogic.CurrentAttempt
                object val = dataGridViewUserWord.Rows[currentRowIndex].Cells[i].Value;
                if (val == null || string.IsNullOrEmpty(val.ToString()))
                {
                    hasEmptyCells = true;
                    break;
                }
                guess += val.ToString().ToUpper();
            }

            if (hasEmptyCells)
            {
                MessageBox.Show($"Ныффыс {currentWordLength} дамгъæйы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Блокируем текущую строку после ввода
            for (int i = 0; i < currentWordLength; i++)
            {
                dataGridViewUserWord.Rows[currentRowIndex].Cells[i].ReadOnly = true;
            }

            GameResult result = gameLogic.CheckGuess(guess); // gameLogic.CurrentAttempt увеличивается здесь

            if (result.Bulls == -1)
            {
                MessageBox.Show($"Слово должно состоять из {currentWordLength} букв!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Разблокируем строку обратно, если ошибка
                for (int i = 0; i < currentWordLength; i++)
                {
                    dataGridViewUserWord.Rows[currentRowIndex].Cells[i].ReadOnly = false;
                }
                return;
            }

            // Применяем цвета к ПРАВИЛЬНОЙ строке
            for (int i = 0; i < currentWordLength; i++)
            {
                Color cellColor = result.CellColors[i] switch
                {
                    "LightGreen" => Color.LightGreen,
                    "LightYellow" => Color.LightYellow,
                    _ => Color.White
                };
                // !!! ИСПРАВЛЕНИЕ: Красим строку currentRowIndex
                dataGridViewUserWord.Rows[currentRowIndex].Cells[i].Style.BackColor = cellColor;
            }

            labelBulls.Text = $"Галтæ - {result.Bulls}";
            labelCows.Text = $"Хъуццытæ - {result.Cows}";

            // Победа
            if (result.Bulls == currentWordLength)
            {
                MessageBox.Show($"Поздравляю! Вы угадали слово {gameLogic.GetSecretWord().ToUpper()}!", "Победа!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NewGame();
                return;
            }

            // Поражение
            if (gameLogic.IsGameOver)
            {
                MessageBox.Show($"К сожалению, вы не угадали! Загаданное слово: {gameLogic.GetSecretWord().ToUpper()}", "Игра окончена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NewGame();
                return;
            }

            // Разблокируем следующую строку
            int nextRow = gameLogic.CurrentAttempt;
            if (nextRow < 5)
            {
                for (int i = 0; i < currentWordLength; i++)
                {
                    dataGridViewUserWord.Rows[nextRow].Cells[i].ReadOnly = false;
                }
                dataGridViewUserWord.CurrentCell = dataGridViewUserWord.Rows[nextRow].Cells[0];
            }

        }

    }
}
