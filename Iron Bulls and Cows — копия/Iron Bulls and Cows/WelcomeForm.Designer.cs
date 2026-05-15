namespace Iron_Bulls_and_Cows
{
    partial class WelcomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelWelcome = new System.Windows.Forms.Label();
            this.labelRules = new System.Windows.Forms.Label();
            this.labelHard = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWelcome.Location = new System.Drawing.Point(271, 60);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(248, 39);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Базон дзырд!";
            // 
            // labelRules
            // 
            this.labelRules.AutoSize = true;
            this.labelRules.Location = new System.Drawing.Point(340, 168);
            this.labelRules.Name = "labelRules";
            this.labelRules.Size = new System.Drawing.Size(82, 13);
            this.labelRules.TabIndex = 1;
            this.labelRules.Text = "Правила игры:";
            // 
            // labelHard
            // 
            this.labelHard.AutoSize = true;
            this.labelHard.Location = new System.Drawing.Point(325, 283);
            this.labelHard.Name = "labelHard";
            this.labelHard.Size = new System.Drawing.Size(118, 13);
            this.labelHard.TabIndex = 2;
            this.labelHard.Text = "Выберите сложность:";
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelHard);
            this.Controls.Add(this.labelRules);
            this.Controls.Add(this.labelWelcome);
            this.Name = "WelcomeForm";
            this.Text = "WelcomeForm";
            this.Load += new System.EventHandler(this.WelcomeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label labelRules;
        private System.Windows.Forms.Label labelHard;
    }
}