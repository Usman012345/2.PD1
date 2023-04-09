using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_1
{
    public partial class Form1 : Form
    {
        bool moveright, moveleft, moveup, movedown;
        int speed = 12;
        public Form1()
        {
            InitializeComponent();
            BackColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Welcome to GUI", title = "GUI practice";
            //     MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog image = new OpenFileDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Enemy1_Click(object sender, EventArgs e)
        {
 /*           int move = 12;
            bool start = false;
*/            /*while (true)
            {
                if (Enemy1.Left > 0)
                {
                    Enemy1.Left -= move;
                    if (Enemy1.Left == 0)
                    {
                        start = true;
                    }
                }
                if (Enemy1.Left <= 700 && start == true)
                {
                    Enemy1.Left += move;
                    if (Enemy1.Left == 700)
                    {
                        start = false;
                    }
                }
            }*/
    }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int move = 12;
            bool start = false;
            while (true)
            {
                if (Enemy1.Left > 0 && start == false)
                {
                    Enemy1.Left -= move;
                    if (Enemy1.Left <= 0)
                    {
                        start = true;
                    }
                    System.Threading.Thread.Sleep(50);
                }
                if (Enemy1.Left <= 700 && start == true)
                {
                    Enemy1.Left += move;
                    if (Enemy1.Left >= 700)
                    {
                        start = false;
                    }
                    System.Threading.Thread.Sleep(50);
                }
            }
        }

        private void timer1Event(object sender, EventArgs e)
        {
            if(moveleft && Player.Left>0)
            {
                Player.Left -= speed;
            }
            if (moveright && Player.Left < 687)
            {
                Player.Left += speed;
            }
            if (moveup && Player.Top > 0)
                Player.Top -= speed;
            if (movedown && Player.Top < 365)
                Player.Top += speed;
            }

        private void Keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Left)
            {
                moveleft = true;
            }
            if (e.KeyCode == Keys.Right)
                moveright = true;
            if (e.KeyCode == Keys.Up)
                moveup = true;
            if (e.KeyCode == Keys.Down)
                movedown = true;

        }

        private void Keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveleft = false;
            }
            if (e.KeyCode == Keys.Right)
                moveright = false;
            if (e.KeyCode == Keys.Up)
                moveup = false;
            if (e.KeyCode == Keys.Down)
                movedown = false;
        }
    }
}
