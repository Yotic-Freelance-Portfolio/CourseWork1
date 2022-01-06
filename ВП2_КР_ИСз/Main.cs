using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ВП2_КР_ИСз
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(MyForm1_MouseDown);
            this.MouseMove += new MouseEventHandler(MyForm1_MouseMove);
            this.MouseUp += new MouseEventHandler(MyForm1_MouseUp);
        }

        #region MainMove

        public int iFormX = 1;
        public int iFormY = 1;
        public int iMouseX = MousePosition.X;
        public int iMouseY = MousePosition.Y;

        private void MyForm1_MouseDown(object sender, MouseEventArgs e)
        {
            this.isDragging = true;
            this.oldPos = new Point();
            this.oldPos.X = e.X;
            this.oldPos.Y = e.Y;
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            iFormX = this.Location.X;
            iFormY = this.Location.Y;
            iMouseX = MousePosition.X;
            iMouseY = MousePosition.Y;
        }
        private void MyForm1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isDragging)
            {
                Point tmp = new Point(this.Location.X, this.Location.Y);
                tmp.X += e.X - this.oldPos.X;
                tmp.Y += e.Y - this.oldPos.Y;
                this.Location = tmp;
            }
        }
        private void MyForm1_MouseUp(object sender, MouseEventArgs e)
        {
            this.isDragging = false;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int iMouseX2 = MousePosition.X;
            int iMouseY2 = MousePosition.Y;
            if (e.Button == MouseButtons.Left)
                this.Location = new Point(iFormX + (iMouseX2 - iMouseX), iFormY + (iMouseY2 - iMouseY));

        }
        private bool isDragging = false;
        private Point oldPos;

        #endregion

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process proc = Process.GetCurrentProcess();
            proc.Kill();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
