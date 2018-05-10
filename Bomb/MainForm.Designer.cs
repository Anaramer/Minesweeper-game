namespace Bomb
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.PnlInfo = new System.Windows.Forms.Panel();
            this.lbl_BombCounter = new System.Windows.Forms.Label();
            this.lbl_time = new System.Windows.Forms.Label();
            this.PnlGame = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlInfo
            // 
            this.PnlInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PnlInfo.Controls.Add(this.lbl_BombCounter);
            this.PnlInfo.Controls.Add(this.lbl_time);
            this.PnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlInfo.Location = new System.Drawing.Point(0, 0);
            this.PnlInfo.Name = "PnlInfo";
            this.PnlInfo.Size = new System.Drawing.Size(531, 59);
            this.PnlInfo.TabIndex = 0;
            // 
            // lbl_BombCounter
            // 
            this.lbl_BombCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_BombCounter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BombCounter.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_BombCounter.Location = new System.Drawing.Point(454, 19);
            this.lbl_BombCounter.Name = "lbl_BombCounter";
            this.lbl_BombCounter.Size = new System.Drawing.Size(65, 21);
            this.lbl_BombCounter.TabIndex = 1;
            this.lbl_BombCounter.Text = "0";
            this.lbl_BombCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_time
            // 
            this.lbl_time.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.Location = new System.Drawing.Point(12, 19);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(65, 21);
            this.lbl_time.TabIndex = 0;
            this.lbl_time.Text = "00:00";
            this.lbl_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlGame
            // 
            this.PnlGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlGame.Location = new System.Drawing.Point(0, 59);
            this.PnlGame.Name = "PnlGame";
            this.PnlGame.Size = new System.Drawing.Size(531, 489);
            this.PnlGame.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 548);
            this.Controls.Add(this.PnlGame);
            this.Controls.Add(this.PnlInfo);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minesweeper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PnlInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlInfo;
        private System.Windows.Forms.Panel PnlGame;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_BombCounter;
    }
}

