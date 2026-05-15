using System;
using System.Drawing;
using System.Windows.Forms;

namespace Iron_Bulls_and_Cows
{
    public partial class MainForm : Form
    {
       
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
            labelBulls.Text = "Галтæ - 0";
            labelCows.Text = "Хъуццытæ - 0";
        }

        private void CheckWord()
        { 
        }
    }
}