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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.map = new System.Windows.Forms.PictureBox();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.lblScore = new System.Windows.Forms.Label();
            this.btnStats = new System.Windows.Forms.Button();
            this.GameBeat = new System.Windows.Forms.Timer(this.components);
            this.ShotBeat = new System.Windows.Forms.Timer(this.components);
            this.StatsBeat = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.map)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // map
            // 
            this.map.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.map.Location = new System.Drawing.Point(6, 15);
            this.map.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(650, 650);
            this.map.TabIndex = 0;
            this.map.TabStop = false;
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(668, 548);
            this.btnNewGame.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(252, 117);
            this.btnNewGame.TabIndex = 1;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Controls.Add(this.lblScore);
            this.panel.Location = new System.Drawing.Point(670, 15);
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
            this.btnStats.Enabled = false;
            this.btnStats.Location = new System.Drawing.Point(670, 132);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(252, 66);
            this.btnStats.TabIndex = 3;
            this.btnStats.Text = "Stats";
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            // 
            // GameBeat
            // 
            this.GameBeat.Interval = 50;
            this.GameBeat.Tick += new System.EventHandler(this.GameBeat_Tick);
            // 
            // ShotBeat
            // 
            this.ShotBeat.Interval = 25;
            this.ShotBeat.Tick += new System.EventHandler(this.ShotBeat_Tick);
            // 
            // StatsBeat
            // 
            this.StatsBeat.Interval = 1000;
            this.StatsBeat.Tick += new System.EventHandler(this.StatsBeat_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(936, 672);
            this.Controls.Add(this.btnStats);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.map);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "MainForm";
            this.Text = "Tanks";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.map)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button btnStats;
        public System.Windows.Forms.Timer GameBeat;
        private System.Windows.Forms.Timer ShotBeat;
        private System.Windows.Forms.Timer StatsBeat;
        public System.Windows.Forms.PictureBox map;
    }
}

