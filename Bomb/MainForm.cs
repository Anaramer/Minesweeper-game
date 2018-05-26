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
    public partial class MainForm : Form
    {
        const int ButtonSize = 25;

        int[,] Arena = null;
        int AreaSize;
        int BombNumber;

        DateTime StartGameTime = new DateTime();

        public MainForm(int AreaSize= 15, int BombNumber= 10)
        {
            this.AreaSize = AreaSize;
            this.BombNumber = BombNumber;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Arena = new int[AreaSize, AreaSize];
            this.Width = AreaSize * ButtonSize+15;
            this.Height = AreaSize * ButtonSize + 34 + PnlInfo.Height;
            CreateRandomBomb();
            CreateButton();
        }

        private void CreateRandomBomb()
        {
            lbl_BombCounter.Text = BombNumber.ToString();
            int cnt = BombNumber;
            Random rnd = new Random();
            while (true)
            {
                int x = rnd.Next(0, AreaSize);
                int y = rnd.Next(0, AreaSize);
                if(Arena[x,y]!=1)
                {
                    cnt--;
                    Arena[x, y] = 1;
                }
                if (cnt == 0) break;
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
                    lbl_BombCounter.Text =(int.Parse(lbl_BombCounter.Text)+1).ToString();
                }
                else
                {
                    btn.BackgroundImage = global::Bomb.Properties.Resources.bomb_25;
                    btn.Text = ".";
                    lbl_BombCounter.Text = (int.Parse(lbl_BombCounter.Text) - 1).ToString();
                }
            }
        }


        private int CountButtonOnGame()
        {
            int res = 0;
            foreach (var btn in PnlGame.Controls.OfType<Button>())
            {
                if (btn.Visible) res++;
            }
            return res;
        }


        private void Btn_Click(object sender, EventArgs e)
        {
            if(!timer1.Enabled) timer1.Enabled = true;
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

            if (CountButtonOnGame() == BombNumber) WinGame();
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
            ShowBombCells();
            timer1.Enabled = false;
            MessageBox.Show("You Lose!");
            Close();
        }

        private void WinGame()
        {
            ShowBombCells();
            timer1.Enabled = false;
            MessageBox.Show("You Win!");
        }

        private void ShowBombCells()
        {
            foreach (Control item in PnlGame.Controls)
            {
                if (item is Button)
                {
                    Button btn = (Button)item;
                    int x = int.Parse(btn.Name.Split('_')[1]);
                    int y = int.Parse(btn.Name.Split('_')[2]);
                    if (Arena[x, y] == 1)
                        btn.BackgroundImage = global::Bomb.Properties.Resources.bomb_25;
                    Thread.Sleep(3);
                    Application.DoEvents();
                }
            }
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            StartGameTime = StartGameTime.AddSeconds(1);
            lbl_time.Text = string.Format("{0:00}:{1:00}", StartGameTime.Minute,StartGameTime.Second);
        }
    }
}
