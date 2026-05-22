namespace Iron_Bulls_and_Cows
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelHint = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.dataGridViewUserWord = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelCows = new System.Windows.Forms.Label();
            this.labelBulls = new System.Windows.Forms.Label();
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.pictureBoxBackground = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserWord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHint
            // 
            this.labelHint.AutoSize = true;
            this.labelHint.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.labelHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHint.Location = new System.Drawing.Point(116, 15);
            this.labelHint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHint.Name = "labelHint";
            this.labelHint.Size = new System.Drawing.Size(401, 26);
            this.labelHint.TabIndex = 2;
            this.labelHint.Text = "Ныффыс дзырд фондз дамгъæйæ";
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOK.Location = new System.Drawing.Point(253, 261);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(111, 30);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "Дарддæр";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // dataGridViewUserWord
            // 
            this.dataGridViewUserWord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUserWord.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewUserWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUserWord.ColumnHeadersVisible = false;
            this.dataGridViewUserWord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridViewUserWord.Location = new System.Drawing.Point(116, 70);
            this.dataGridViewUserWord.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewUserWord.Name = "dataGridViewUserWord";
            this.dataGridViewUserWord.RowHeadersVisible = false;
            this.dataGridViewUserWord.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridViewUserWord.RowTemplate.Height = 24;
            this.dataGridViewUserWord.Size = new System.Drawing.Size(370, 153);
            this.dataGridViewUserWord.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // labelCows
            // 
            this.labelCows.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.labelCows.AutoSize = true;
            this.labelCows.BackColor = System.Drawing.Color.PaleGreen;
            this.labelCows.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCows.Location = new System.Drawing.Point(448, 301);
            this.labelCows.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCows.Name = "labelCows";
            this.labelCows.Size = new System.Drawing.Size(142, 24);
            this.labelCows.TabIndex = 5;
            this.labelCows.Text = "Хъуццытæ - 0";
            // 
            // labelBulls
            // 
            this.labelBulls.AutoSize = true;
            this.labelBulls.BackColor = System.Drawing.Color.PaleGreen;
            this.labelBulls.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBulls.Location = new System.Drawing.Point(68, 304);
            this.labelBulls.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBulls.Name = "labelBulls";
            this.labelBulls.Size = new System.Drawing.Size(103, 24);
            this.labelBulls.TabIndex = 6;
            this.labelBulls.Text = "Галтæ - 0";
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNewGame.Location = new System.Drawing.Point(263, 304);
            this.buttonNewGame.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(91, 28);
            this.buttonNewGame.TabIndex = 8;
            this.buttonNewGame.Text = "Ногæй";
            this.buttonNewGame.UseVisualStyleBackColor = false;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // pictureBoxBackground
            // 
            this.pictureBoxBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxBackground.InitialImage = null;
            this.pictureBoxBackground.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBackground.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxBackground.Name = "pictureBoxBackground";
            this.pictureBoxBackground.Size = new System.Drawing.Size(600, 366);
            this.pictureBoxBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBackground.TabIndex = 0;
            this.pictureBoxBackground.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.buttonNewGame);
            this.Controls.Add(this.labelBulls);
            this.Controls.Add(this.labelCows);
            this.Controls.Add(this.dataGridViewUserWord);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelHint);
            this.Controls.Add(this.pictureBoxBackground);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Галтæ æмæ хъуццытæ";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserWord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBackground;
        private System.Windows.Forms.Label labelHint;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.DataGridView dataGridViewUserWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label labelCows;
        private System.Windows.Forms.Label labelBulls;
        private System.Windows.Forms.Button buttonNewGame;
    }
}

