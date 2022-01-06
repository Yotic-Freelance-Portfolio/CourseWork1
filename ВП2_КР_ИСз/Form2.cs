using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ВП2_КР_ИСз
{
    public partial class Form2 : Form
    {
        int formWidth;
        int formHeight;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            formWidth = this.Size.Width;
            formHeight = this.Size.Height;

            button1.Location = new Point(formWidth - 26, 2);

            panel2.Location = new Point(0, 28);
            panel2.Size = new Size(formWidth, formHeight - 28);

            panel1.Size = new Size(formWidth, 37);
            panel1.Location = new Point(0, formHeight - 65);

            panel4.Location = new Point((formWidth / 2) - (panel4.Size.Width / 2), (formHeight / 2) - (panel4.Size.Height / 2));

            button4.Location = new Point( button1.Location.X - 2 - button4.Size.Width , button1.Location.Y);
        }

        static string stringST = "Автор : Евгений Новиков ВП2_КР_ИСз: №1 - 2 варинат || №2 - 6 вариант";
        static string stringST2 = "Автор : Евгений Новиков ВП2_КР_ИСз: №1 - 2 варинат || №2 - 6 вариант                              ";
        int countL = stringST.Length;
        int countT = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            RunString();
        }

        private void RunString()
        {
            string tempst = "";

            tempst = $"{stringST2[countT]}{stringST2[countT + 1]}{stringST2[countT + 2]}{stringST2[countT + 3]}{stringST2[countT + 4]}{stringST2[countT + 5]}{stringST2[countT + 6]}";
            label2.Text = tempst;
            countT += 1;
            if (countT > 68)
            {
                countT = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process proc = Process.GetCurrentProcess();
            proc.Kill();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel2.ClientRectangle, Color.Silver, ButtonBorderStyle.Solid);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint2);
        }

        private void panel1_Paint2(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("Автор : Евгений Новиков      ВП2_КР_ИСз : №1 - 2 варинат || №2 - 6 вариант", label1.Font, new SolidBrush(Color.Black), 15.0F, 15.0F);       
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        int[] colorLabel = new int[3] { 255, 0, 0 };
        int qTemp = 0;
        void RainbowUI()
        {
            if (qTemp == 0)
            {
                if (colorLabel[1] < 255)
                    colorLabel[1] += 1;
                else
                    qTemp += 1;
            }
            else if (qTemp == 1)
            {
                if (colorLabel[0] > 0)
                    colorLabel[0] = colorLabel[0] - 1;
                else
                    qTemp += 1;
            }
            else if (qTemp == 2)
            {
                if (colorLabel[2] < 255)
                    colorLabel[2] += 1;
                else
                    qTemp += 1;
            }
            else if (qTemp == 3)
            {
                if (colorLabel[1] > 0)
                    colorLabel[1] = colorLabel[1] - 1;
                else
                    qTemp += 1;
            }
            else if (qTemp == 4)
            {
                if (colorLabel[0] < 255)
                    colorLabel[0] += 1;
                else
                    qTemp += 1;
            }
            else if (qTemp == 5)
            {
                if (colorLabel[2] > 0)
                    colorLabel[2] = colorLabel[2] - 1;
                else
                    qTemp = 0;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            RainbowUI();
            label2.ForeColor = Color.FromArgb(colorLabel[0], colorLabel[1], colorLabel[2]);
        }
    }
}
