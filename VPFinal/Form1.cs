using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPFinal
{
    public partial class Form1 : Form
    {
        Grid grid;

        Timer timer;

        int c;

        SortedDictionary<int, String> players;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            players = new SortedDictionary<int, String>();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(c == 70)
            {
                bool stop = grid.CreateObject();

                if(!stop)
                {
                    timer.Stop();
                    MessageBox.Show("Your score is: " + lblScore.Text + "!", "Game ended!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    int sc = int.Parse(lblScore.Text);
                    players.Add(sc, label2.Text);

                    lblLevel.Text = "";
                    lblLines.Text = "";
                    label2.Text = "";
                    lblScore.Text = "";
                    btnHelp.Enabled = true;
                    btnNewGame.Enabled = true;
                    btnHighScores.Enabled = true;
                    Graphics g = CreateGraphics();
                    g.FillRectangle(Brushes.White, 5, 18, 210, 378);
                    g.DrawRectangle(new Pen(SystemColors.ControlDark), 5, 18, 210, 378);
                    g.Dispose();
                    return;
                }

                c = 0;

                int num = int.Parse(lblScore.Text);
                lblScore.Text = (num + 200).ToString();
                lblLevel.Text = (((num + 200) / 1000) + 1).ToString();

                int ti = 50 - (num + 200) / 1000 + 1;

                if (ti > 0)
                {
                    timer.Interval = ti;
                }
            }

            grid.MoveDown();
            int n = grid.RemoveFilledLines();

            int q = int.Parse(lblLines.Text);
            
            q += n;

            lblLines.Text = q.ToString();

            int score = int.Parse(lblScore.Text);

            score += 1000 * n;

            lblScore.Text = score.ToString();
            lblLevel.Text = ((score / 1000) + 1).ToString();

            int time = 50 - score / 1000 + 1;

            if(time > 0)
            {
                timer.Interval = time;
            }

            Invalidate();

            ++c;
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.White, 5, 18, 210, 378);
            Pen pen = new Pen(SystemColors.ControlDark);
            e.Graphics.DrawRectangle(pen, 5, 18, 210, 378);
            pen.Dispose();

            if (grid!=null) grid.Draw(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData.ToString() == "Right")
            {
                grid.MoveRight();
            }

            else if (e.KeyData.ToString() == "Left")
            {
                grid.MoveLeft();
            }

            else if (e.KeyData.ToString() == "Down")
            {
                grid.MoveDown();
            }

            else if (e.KeyData.ToString() == "Up")
            {
                grid.Rotate();
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            DialogResult result = form.ShowDialog();

            if(result == DialogResult.OK)
            {
                label2.Text = form.PlayerName;
                lblLines.Text = "0";
                lblLevel.Text = "1";
                lblScore.Text = "0";
                btnHelp.Enabled = false;
                btnNewGame.Enabled = false;
                btnHighScores.Enabled = false;

                grid = new Grid();

                timer = new Timer();
                timer.Interval = 50;
                timer.Tick += Timer_Tick;
                
                c = 0;

                timer.Start();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("1. Click the left or right keyboard button to move the falling Tetrimino in the corresponding direction\n");
            sb.Append("2. Clicking the up button will rotate the Tetrimino\n");
            sb.Append("3. Clicking the down button will bring the Tetrimino down faster\n");

            MessageBox.Show(sb.ToString(), "How to play", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            foreach(KeyValuePair<int, string> pair in players.Reverse())
            {
                sb.Append(pair.Value + " (" + pair.Key + ")\n");
            }

            MessageBox.Show(sb.ToString());
        }
    }
}