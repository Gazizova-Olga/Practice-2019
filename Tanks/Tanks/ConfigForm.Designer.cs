namespace Tanks
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.lblTanks = new System.Windows.Forms.Label();
            this.lblApples = new System.Windows.Forms.Label();
            this.ctrlTanks = new System.Windows.Forms.NumericUpDown();
            this.ctrlApples = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlSpeed = new System.Windows.Forms.TrackBar();
            this.btnStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlTanks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlApples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTanks
            // 
            this.lblTanks.AutoSize = true;
            this.lblTanks.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTanks.Location = new System.Drawing.Point(29, 27);
            this.lblTanks.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTanks.Name = "lblTanks";
            this.lblTanks.Size = new System.Drawing.Size(147, 24);
            this.lblTanks.TabIndex = 0;
            this.lblTanks.Text = "Number of tanks";
            // 
            // lblApples
            // 
            this.lblApples.AutoSize = true;
            this.lblApples.Location = new System.Drawing.Point(29, 93);
            this.lblApples.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblApples.Name = "lblApples";
            this.lblApples.Size = new System.Drawing.Size(160, 24);
            this.lblApples.TabIndex = 1;
            this.lblApples.Text = "Number of apples";
            // 
            // ctrlTanks
            // 
            this.ctrlTanks.Location = new System.Drawing.Point(221, 22);
            this.ctrlTanks.Name = "ctrlTanks";
            this.ctrlTanks.Size = new System.Drawing.Size(120, 29);
            this.ctrlTanks.TabIndex = 2;
            this.ctrlTanks.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // ctrlApples
            // 
            this.ctrlApples.Location = new System.Drawing.Point(221, 88);
            this.ctrlApples.Name = "ctrlApples";
            this.ctrlApples.Size = new System.Drawing.Size(120, 29);
            this.ctrlApples.TabIndex = 3;
            this.ctrlApples.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Speed";
            // 
            // ctrlSpeed
            // 
            this.ctrlSpeed.BackColor = System.Drawing.SystemColors.Control;
            this.ctrlSpeed.Location = new System.Drawing.Point(221, 156);
            this.ctrlSpeed.Name = "ctrlSpeed";
            this.ctrlSpeed.Size = new System.Drawing.Size(120, 45);
            this.ctrlSpeed.SmallChange = 5;
            this.ctrlSpeed.TabIndex = 5;
            this.ctrlSpeed.TickFrequency = 5;
            this.ctrlSpeed.Value = 5;
            // 
            // btnStart
            // 
            this.btnStart.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnStart.Location = new System.Drawing.Point(113, 234);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(158, 56);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "OK";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 324);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.ctrlSpeed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ctrlApples);
            this.Controls.Add(this.ctrlTanks);
            this.Controls.Add(this.lblApples);
            this.Controls.Add(this.lblTanks);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tanks: customize";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlTanks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlApples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTanks;
        private System.Windows.Forms.Label lblApples;
        private System.Windows.Forms.NumericUpDown ctrlTanks;
        private System.Windows.Forms.NumericUpDown ctrlApples;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar ctrlSpeed;
        private System.Windows.Forms.Button btnStart;
    }
}