using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Iron_Bulls_and_Cows
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            int wordLength;
            if (radioButton3.Checked) wordLength = 3;
            else if (radioButton4.Checked) wordLength = 4;
            else if (radioButton5.Checked) wordLength = 5;
            else
            {
                MessageBox.Show("Выберите уровень сложности!");
                return;
            }

            this.Hide();
            MainForm gameForm = new MainForm(wordLength);
            gameForm.FormClosed += (s, args) => this.Close();
            gameForm.Show();
        }
    }
}
