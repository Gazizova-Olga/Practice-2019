namespace Tanks
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
            this.pbGame = new System.Windows.Forms.PictureBox();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.lblScore = new System.Windows.Forms.Label();
            this.btnStats = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbGame)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbGame
            // 
            this.pbGame.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbGame.Location = new System.Drawing.Point(6, 15);
            this.pbGame.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.pbGame.Name = "pbGame";
            this.pbGame.Size = new System.Drawing.Size(624, 624);
            this.pbGame.TabIndex = 0;
            this.pbGame.TabStop = false;
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(644, 522);
            this.btnNewGame.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(252, 117);
            this.btnNewGame.TabIndex = 1;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Controls.Add(this.lblScore);
            this.panel.Location = new System.Drawing.Point(644, 15);
            this.panel.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(252, 108);
            this.panel.TabIndex = 2;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(30, 39);
            this.lblScore.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(75, 26);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "Score:";
            // 
            // btnStats
            // 
            this.btnStats.Location = new System.Drawing.Point(644, 142);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(252, 66);
            this.btnStats.TabIndex = 3;
            this.btnStats.Text = "Stats";
            this.btnStats.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 649);
            this.Controls.Add(this.btnStats);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.pbGame);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "MainForm";
            this.Text = "Tanks";
            ((System.ComponentModel.ISupportInitialize)(this.pbGame)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGame;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button btnStats;
    }
}

