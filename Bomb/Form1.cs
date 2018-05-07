using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomb
{
    public partial class Form1 : Form
    {
        int[,] Arena = null;
        const int AreaSize = 15;
        const int ButtonSize = 30;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Arena = new int[AreaSize, AreaSize];
            this.Width = AreaSize * ButtonSize+15;
            this.Height = AreaSize * ButtonSize + 34 + PnlInfo.Height;
            CreateGame(15);
            CreateButton();
        }

        private void CreateGame(int BombNumber)
        {
            Random rnd = new Random();
            while (true)
            {
                int x = rnd.Next(0, AreaSize);
                int y = rnd.Next(0, AreaSize);
                if(Arena[x,y]!=1)
                {
                    BombNumber--;
                    Arena[x, y] = 1;
                }
                if (BombNumber < 0) break;
            }
        }

        private void CreateButton()
        {
            for (int x = 0; x < AreaSize; x++)
            {
                for (int y = 0; y < AreaSize; y++)
                {
                    Button btn = new Button
                    {
                        Name = "BTN_" + x.ToString() + "_" + y.ToString(),
                        Size = new Size(ButtonSize, ButtonSize),
                        Location = new Point(x * ButtonSize, y * ButtonSize),
                        Text = "",
                        BackColor = Color.LightBlue,
                        FlatStyle = FlatStyle.Flat,
                        TabStop = false,
                        BackgroundImageLayout = ImageLayout.Center
                };
                    btn.Click += Btn_Click;
                    btn.MouseDown += Btn_MouseDown;
                    PnlGame.Controls.Add(btn);
                }
            }
        }

        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            if (e.Button == MouseButtons.Right)
            {
                if (btn.Text == ".")
                {
                    btn.BackgroundImage = null;
                    btn.Text = "";
                }
                else
                {
                    btn.BackgroundImage = global::Bomb.Properties.Resources.bomb_25;
                    btn.Text = ".";
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int x = int.Parse(btn.Name.Split('_')[1]);
            int y = int.Parse(btn.Name.Split('_')[2]);
            if (Arena[x, y] == 1)
            {
                LoseGame();
                return;
            }
            else
            {
                ProccessCell(x, y);
            }
        }

        private Button GetButtonByName(string buttonName)
        {
            if (PnlGame.Controls.Find(buttonName, false).Count() == 0) return null;
            Button btn = (Button)PnlGame.Controls.Find(buttonName, false)[0];
            return btn;
        }

        private void ProccessCell(int x,int y)
        {
            int BomNum = CountBombAround(x, y);
            string BtnName = "BTN_" + x.ToString() + "_" + y.ToString();
            if (GetButtonByName(BtnName) == null) return;
            Button btn = GetButtonByName(BtnName);
            if (btn.Visible == false) return;
            btn.Visible = false;

            if (BomNum > 0)
            { 
                CreateLabel(x, y, BomNum);
            }
            else
            {
                if (x > 0)
                {
                    if (y > 0) ProccessCell(x-1, y-1);
                    if (y > 0 && y < AreaSize - 1) ProccessCell(x - 1, y);
                    if (y < AreaSize - 1) ProccessCell(x - 1, y+ 1);
                }
                if (x < AreaSize - 1)
                {
                    if (y > 0) ProccessCell(x + 1, y - 1);
                    if (y > 0 && y < AreaSize - 1) ProccessCell(x + 1, y);
                    if (y < AreaSize - 1) ProccessCell(x + 1, y + 1);
                }
                if (y > 0) ProccessCell(x, y - 1);
                if (y < AreaSize - 1) ProccessCell(x, y - 1);
            }
        }

        private void LoseGame()
        {
            foreach (Control item in PnlGame.Controls)
            {
                if(item is Button)
                {
                    Button btn = (Button)item;
                    int x = int.Parse(btn.Name.Split('_')[1]);
                    int y = int.Parse(btn.Name.Split('_')[2]);
                    if(Arena[x,y]==1)
                        btn.BackgroundImage = global::Bomb.Properties.Resources.bomb_25;
                    Thread.Sleep(3);
                    Application.DoEvents();
                }
            }
            MessageBox.Show("You Lose!");
        }

        private int CountBombAround(int x,int y)
        {
            int SumResult = 0;
            if (x > 0)
            {
                if (y > 0) SumResult += Arena[x-1, y - 1];
                if (y > 0 && y < AreaSize - 1) SumResult += Arena[x - 1, y];
                if (y < AreaSize - 1) SumResult += Arena[x-1, y + 1];
            }
            if (x<AreaSize-1)
            {
                if (y > 0) SumResult += Arena[x + 1, y - 1];
                if (y > 0 && y < AreaSize - 1) SumResult += Arena[x + 1, y];
                if (y < AreaSize - 1) SumResult += Arena[x + 1, y + 1];
            }
            if (y > 0) SumResult += Arena[x, y - 1];
            if (y < AreaSize - 1) SumResult += Arena[x, y + 1];

            return SumResult;
        }

        private void CreateLabel(int x,int y,int number)
        {
            Label lbl = new Label
            {
                Name = "LBL_" + x.ToString() + "_" + y.ToString(),
                Text = number.ToString(),
                Size = new Size(ButtonSize, ButtonSize),
                Location = new Point(x * ButtonSize, y * ButtonSize),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Tahoma", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)))
            };
            switch (number)
            {
                case 1: lbl.ForeColor = Color.BlueViolet; break;
                case 2: lbl.ForeColor = Color.Blue; break;
                case 3: lbl.ForeColor = Color.DarkBlue; break;
                case 4: lbl.ForeColor = Color.LightGreen; break;
                case 5: lbl.ForeColor = Color.Green; break;
                case 6: lbl.ForeColor = Color.DarkGreen; break;
                case 7: lbl.ForeColor = Color.Red; break;
                case 8: lbl.ForeColor = Color.DarkRed; break;
            }
            PnlGame.Controls.Add(lbl);
        }
    }
}
