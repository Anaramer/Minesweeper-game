using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomb
{
    public partial class Init : Form
    {
        public Init()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm FrmGame = null;

            if (radioButton1.Checked) FrmGame = new MainForm(10, 15);
            if (radioButton2.Checked) FrmGame = new MainForm(15, 25);
            if (radioButton3.Checked) FrmGame = new MainForm(20, 50);


            this.Hide();
            FrmGame.ShowDialog();
            Close();
        }
    }
}
