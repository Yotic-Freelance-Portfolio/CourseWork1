using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ВП2_КР_ИСз
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(MyForm1_MouseDown);
            this.MouseMove += new MouseEventHandler(MyForm1_MouseMove);
            this.MouseUp += new MouseEventHandler(MyForm1_MouseUp);
        }

        #region Form1Move

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

        #region PreWork

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateWorkDirecory();
            LoadTab();
        }

        FlowLayoutPanel[] _FLP = new FlowLayoutPanel[4];
        private void LoadTab()
        {
            for (int i = 0; i < _FLP.Length; i++)
            {
                _FLP[i] = new FlowLayoutPanel();

                _FLP[i].BackColor = Color.FromArgb(252, 252, 252);
                _FLP[i].Location = new Point(i * 118, 0);
                _FLP[i].Margin = new Padding(1);
                _FLP[i].Name = "_FLP[i]";
                _FLP[i].Padding = new Padding(1);
                _FLP[i].Size = new Size(118, 350);
                _FLP[i].Paint += new PaintEventHandler(this.Flow_Paint);
                panel2.Controls.Add(_FLP[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void Flow_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ((FlowLayoutPanel)sender).ClientRectangle, Color.Silver, ButtonBorderStyle.Solid);
        }

        DateTime tepTime;
        private void CreateWorkDirecory()
        {
            Directory.CreateDirectory(@"C:\DeleteMe");
            Directory.CreateDirectory(@"C:\DeleteMe\Save");

            if(File.Exists(@"C:\DeleteMe\Save\Test.Json") == false)
                using (FileStream reader = new FileStream(@"C:\DeleteMe\Save\Test.Json", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    byte[] tempb = new byte[] { 0x5b, 0x0a, 0x20, 0x20, 0x7b, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x22, 0x54, 0x69, 0x6d, 0x65, 0x22, 0x3a, 0x20, 0x22, 0x32, 0x30, 0x32, 0x31, 0x2d, 0x30, 0x35, 0x2d, 0x33, 0x30, 0x54, 0x30, 0x31, 0x3a, 0x30, 0x31, 0x3a, 0x35, 0x37, 0x2e, 0x33, 0x36, 0x33, 0x38, 0x37, 0x31, 0x33, 0x2b, 0x30, 0x33, 0x3a, 0x30, 0x30, 0x22, 0x2c, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x22, 0x43, 0x61, 0x74, 0x65, 0x67, 0x6f, 0x72, 0x79, 0x22, 0x3a, 0x20, 0x22, 0x43, 0x61, 0x74, 0x65, 0x67, 0x6f, 0x72, 0x79, 0x22, 0x2c, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x22, 0x4e, 0x61, 0x6d, 0x65, 0x22, 0x3a, 0x20, 0x22, 0x4e, 0x61, 0x6d, 0x65, 0x34, 0x22, 0x2c, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x22, 0x53, 0x70, 0x65, 0x61, 0x6b, 0x65, 0x72, 0x22, 0x3a, 0x20, 0x22, 0x53, 0x70, 0x65, 0x61, 0x6b, 0x65, 0x72, 0x22, 0x0a, 0x20, 0x20, 0x7d, 0x2c, 0x0a, 0x20, 0x20, 0x7b, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x22, 0x54, 0x69, 0x6d, 0x65, 0x22, 0x3a, 0x20, 0x22, 0x32, 0x30, 0x32, 0x31, 0x2d, 0x30, 0x35, 0x2d, 0x33, 0x30, 0x54, 0x30, 0x31, 0x3a, 0x30, 0x31, 0x3a, 0x35, 0x38, 0x2e, 0x33, 0x36, 0x33, 0x38, 0x37, 0x31, 0x33, 0x2b, 0x30, 0x33, 0x3a, 0x30, 0x30, 0x22, 0x2c, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x22, 0x43, 0x61, 0x74, 0x65, 0x67, 0x6f, 0x72, 0x79, 0x22, 0x3a, 0x20, 0x22, 0x43, 0x61, 0x74, 0x65, 0x67, 0x6f, 0x72, 0x79, 0x22, 0x2c, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x22, 0x4e, 0x61, 0x6d, 0x65, 0x22, 0x3a, 0x20, 0x22, 0x4e, 0x61, 0x6d, 0x65, 0x38, 0x34, 0x22, 0x2c, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x22, 0x53, 0x70, 0x65, 0x61, 0x6b, 0x65, 0x72, 0x22, 0x3a, 0x20, 0x22, 0x53, 0x70, 0x65, 0x61, 0x6b, 0x65, 0x72, 0x22, 0x0a, 0x20, 0x20, 0x7d, 0x2c, 0x0a, 0x20, 0x20, 0x7b, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x22, 0x54, 0x69, 0x6d, 0x65, 0x22, 0x3a, 0x20, 0x22, 0x32, 0x30, 0x32, 0x31, 0x2d, 0x30, 0x35, 0x2d, 0x33, 0x30, 0x54, 0x30, 0x31, 0x3a, 0x30, 0x31, 0x3a, 0x35, 0x30, 0x2e, 0x33, 0x36, 0x33, 0x38, 0x37, 0x31, 0x33, 0x2b, 0x30, 0x33, 0x3a, 0x30, 0x30, 0x22, 0x2c, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x22, 0x43, 0x61, 0x74, 0x65, 0x67, 0x6f, 0x72, 0x79, 0x22, 0x3a, 0x20, 0x22, 0x43, 0x61, 0x74, 0x65, 0x67, 0x6f, 0x72, 0x79, 0x22, 0x2c, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x22, 0x4e, 0x61, 0x6d, 0x65, 0x22, 0x3a, 0x20, 0x22, 0x4e, 0x61, 0x6d, 0x65, 0x35, 0x22, 0x2c, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x22, 0x53, 0x70, 0x65, 0x61, 0x6b, 0x65, 0x72, 0x22, 0x3a, 0x20, 0x22, 0x53, 0x70, 0x65, 0x61, 0x6b, 0x65, 0x72, 0x22, 0x0a, 0x20, 0x20, 0x7d, 0x2c, 0x0a, 0x20, 0x20, 0x7b, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x22, 0x54, 0x69, 0x6d, 0x65, 0x22, 0x3a, 0x20, 0x22, 0x32, 0x30, 0x32, 0x31, 0x2d, 0x30, 0x35, 0x2d, 0x33, 0x30, 0x54, 0x30, 0x31, 0x3a, 0x30, 0x32, 0x3a, 0x35, 0x37, 0x2e, 0x33, 0x36, 0x33, 0x38, 0x37, 0x31, 0x33, 0x2b, 0x30, 0x33, 0x3a, 0x30, 0x30, 0x22, 0x2c, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x22, 0x43, 0x61, 0x74, 0x65, 0x67, 0x6f, 0x72, 0x79, 0x22, 0x3a, 0x20, 0x22, 0x43, 0x61, 0x74, 0x65, 0x67, 0x6f, 0x72, 0x79, 0x22, 0x2c, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x22, 0x4e, 0x61, 0x6d, 0x65, 0x22, 0x3a, 0x20, 0x22, 0x4e, 0x61, 0x6d, 0x65, 0x33, 0x22, 0x2c, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x22, 0x53, 0x70, 0x65, 0x61, 0x6b, 0x65, 0x72, 0x22, 0x3a, 0x20, 0x22, 0x53, 0x70, 0x65, 0x61, 0x6b, 0x65, 0x72, 0x22, 0x0a, 0x20, 0x20, 0x7d, 0x2c, 0x0a, 0x20, 0x20, 0x7b, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x22, 0x54, 0x69, 0x6d, 0x65, 0x22, 0x3a, 0x20, 0x22, 0x32, 0x30, 0x32, 0x31, 0x2d, 0x30, 0x35, 0x2d, 0x33, 0x30, 0x54, 0x30, 0x31, 0x3a, 0x30, 0x36, 0x3a, 0x35, 0x37, 0x2e, 0x33, 0x36, 0x33, 0x38, 0x37, 0x31, 0x33, 0x2b, 0x30, 0x33, 0x3a, 0x30, 0x30, 0x22, 0x2c, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x22, 0x43, 0x61, 0x74, 0x65, 0x67, 0x6f, 0x72, 0x79, 0x22, 0x3a, 0x20, 0x22, 0x43, 0x61, 0x74, 0x65, 0x67, 0x6f, 0x72, 0x79, 0x22, 0x2c, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x22, 0x4e, 0x61, 0x6d, 0x65, 0x22, 0x3a, 0x20, 0x22, 0x4e, 0x61, 0x6d, 0x65, 0x31, 0x22, 0x2c, 0x0a, 0x20, 0x20, 0x20, 0x20, 0x22, 0x53, 0x70, 0x65, 0x61, 0x6b, 0x65, 0x72, 0x22, 0x3a, 0x20, 0x22, 0x53, 0x70, 0x65, 0x61, 0x6b, 0x65, 0x72, 0x22, 0x0a, 0x20, 0x20, 0x7d, 0x0a, 0x5d, 0x0a};
                    reader.Write(tempb, 0 , tempb.Length);
                    reader.Close();
                }

            tepTime = DateTime.Now;
        }

        public List<TVShow> tVClass = new List<TVShow>();
        public class TVShow
        {
            ///<summary> Время кино.</summary>
            public DateTime Time { get; set; }

            ///<summary> Категория кино.</summary>
            public string Category { get; set; }

            ///<summary> Название кино.</summary>
            public string Name { get; set; }

            ///<summary> Ведущий кино.</summary>
            public string Speaker { get; set; }
        }

        Label[] textBoxs = new Label[4];
        private void button3_Click(object sender, EventArgs e)
        {
            string fileContent = "";
            string filePath = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\DeleteMe\Save";
                openFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;

                    var fileStream = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                        reader.Close();
                    }

                    tVClass = JsonConvert.DeserializeObject<List<TVShow>>(fileContent);
                    tVClass = tVClass.OrderBy(x => -x.Time.Ticks).ToList();
                    tVClass.Reverse();
                    for (int o = 0; o < _FLP[0].Controls.Count; o++)
                        _FLP[o].Controls.Remove(_FLP[o].Controls[o]);

                    for (int i = 0; i < tVClass.Count; i++)
                    {
                        for (int u = 0; u < 4; u++)
                        {
                            textBoxs[u] = new Label();
                            _FLP[u].Controls.Add(textBoxs[u]);

                            textBoxs[u].FlatStyle = FlatStyle.Flat;
                            textBoxs[u].ForeColor = Color.Gray;
                            textBoxs[u].BackColor = Color.White;
                            textBoxs[u].Font = label1.Font;
                            textBoxs[u].Size = new Size(110, 15);
                            textBoxs[u].TabIndex = 1000 + i;
                            textBoxs[u].Click += new EventHandler(ChoiceFilm);
                        }

                        textBoxs[0].Text = tVClass[i].Time.ToString();
                        textBoxs[1].Text = tVClass[i].Category;
                        textBoxs[2].Text = tVClass[i].Name;
                        textBoxs[3].Text = tVClass[i].Speaker;
                    }
                }
            }
        }

        private void ChoiceFilm(object sender, EventArgs e)
        {
            var send = (Label)sender;
            int sendID = send.TabIndex - 1000;
            if (send.BackColor == Color.White)
            {
                int ConCon = _FLP[0].Controls.Count;
                for (int i = 0; i < 4; i++)
                    _FLP[i].Controls[sendID].BackColor = Color.AliceBlue;

                for (int o = 0; o < 4; o++)
                {
                    for (int i = 0; i < ConCon - 1 - sendID; i++)
                    {
                        _FLP[o].Controls.Remove(_FLP[o].Controls[sendID + 1]);
                    }
                }
            }
            else
            {
                int ConCon = _FLP[0].Controls.Count;

                for (int o = 0; o < 4; o++)
                    for (int i = 0; i < ConCon; i++)
                        _FLP[o].Controls.Remove(_FLP[o].Controls[0]);

                for (int i = 0; i < tVClass.Count; i++)
                {
                    for (int u = 0; u < 4; u++)
                    {
                        textBoxs[u] = new Label();
                        _FLP[u].Controls.Add(textBoxs[u]);

                        textBoxs[u].FlatStyle = FlatStyle.Flat;
                        textBoxs[u].ForeColor = Color.Gray;
                        textBoxs[u].BackColor = Color.White;
                        textBoxs[u].Font = label1.Font;
                        textBoxs[u].Size = new Size(110, 15);
                        textBoxs[u].TabIndex = 1000 + i;
                        textBoxs[u].Click += new EventHandler(ChoiceFilm);
                    }

                    textBoxs[0].Text = tVClass[i].Time.ToString();
                    textBoxs[1].Text = tVClass[i].Category;
                    textBoxs[2].Text = tVClass[i].Name;
                    textBoxs[3].Text = tVClass[i].Speaker;
                }                
            }            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (StreamWriter reader = new StreamWriter($@"C:\DeleteMe\Save\1"))
            {
                string temp = JsonConvert.SerializeObject(tVClass, Formatting.Indented);
                reader.WriteLine(temp);
                reader.Close();
            }
        }

        #endregion

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}