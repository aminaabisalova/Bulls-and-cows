using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iron_Bulls_and_Cows
{
    public partial class WelcomeForm : Form
    {
        private string selectedDifficulty = "легкий";
        public WelcomeForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Угадай слово - Приветствие";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Заголовок
            Label titleLabel = new Label();
            titleLabel.Text = "ИГРА «УГАДАЙ СЛОВО»";
            titleLabel.Font = new Font("Arial", 18, FontStyle.Bold);
            titleLabel.Size = new Size(400, 40);
            titleLabel.Location = new Point(50, 30);
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;

            // Правила игры
            Label rulesLabel = new Label();
            rulesLabel.Text = "Правила игры:\n\n" +
                             "1. Вам нужно угадать слово из 5 букв\n" +
                             "2. У вас есть 5 попыток\n" +
                             "3. Зеленая ячейка - буква на правильном месте\n" +
                             "4. Желтая ячейка - буква есть в слове, но не на своем месте\n" +
                             "5. Белая ячейка - такой буквы нет в слове\n\n" +
                             "Удачи!";
            rulesLabel.Font = new Font("Arial", 11);
            rulesLabel.Size = new Size(400, 200);
            rulesLabel.Location = new Point(50, 80);

            // Выбор сложности
            Label difficultyLabel = new Label();
            difficultyLabel.Text = "Выберите сложность:";
            difficultyLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            difficultyLabel.Size = new Size(200, 25);
            difficultyLabel.Location = new Point(50, 290);

            ComboBox difficultyCombo = new ComboBox();
            difficultyCombo.Size = new Size(150, 25);
            difficultyCombo.Location = new Point(50, 320);
            difficultyCombo.Items.AddRange(new string[] { "легкий", "средний", "сложный" });
            difficultyCombo.SelectedIndex = 0;
            difficultyCombo.SelectedIndexChanged += (s, e) =>
            {
                selectedDifficulty = difficultyCombo.SelectedItem.ToString();
            };

            // Кнопка начала игры
            Button startButton = new Button();
            startButton.Text = "Начать игру!";
            startButton.Font = new Font("Arial", 12, FontStyle.Bold);
            startButton.Size = new Size(150, 40);
            startButton.Location = new Point(250, 315);
            startButton.BackColor = Color.LightGreen;
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.Click += (s, e) =>
            {
                MainForm gameForm = new MainForm(selectedDifficulty);
                gameForm.Show();
                this.Hide();
            };

            this.Controls.AddRange(new Control[] { titleLabel, rulesLabel, difficultyLabel, difficultyCombo, startButton });
        }
    }
}
