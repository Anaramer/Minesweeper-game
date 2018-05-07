namespace Bomb
{
    partial class Form1
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
            this.PnlInfo = new System.Windows.Forms.Panel();
            this.PnlGame = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // PnlInfo
            // 
            this.PnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlInfo.Location = new System.Drawing.Point(0, 0);
            this.PnlInfo.Name = "PnlInfo";
            this.PnlInfo.Size = new System.Drawing.Size(531, 59);
            this.PnlInfo.TabIndex = 0;
            // 
            // PnlGame
            // 
            this.PnlGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlGame.Location = new System.Drawing.Point(0, 59);
            this.PnlGame.Name = "PnlGame";
            this.PnlGame.Size = new System.Drawing.Size(531, 489);
            this.PnlGame.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 548);
            this.Controls.Add(this.PnlGame);
            this.Controls.Add(this.PnlInfo);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlInfo;
        private System.Windows.Forms.Panel PnlGame;
    }
}

