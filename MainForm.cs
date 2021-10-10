using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test_Program
{
    class MainForm : Form
    {
        string FilePath;
        PictureBox backGround;
        int backGround_X = 0;
        int backGround_Y = 0;

        PictureBox pBox1;
        int pBox1_X = 0;
        int pBox1_Y = 0;

        Panel panel1;
        int panel1_X = 0;
        int panel1_Y = 0;

        Button button1;
        int btn1_X = 100;
        int btn1_Y = 0;
        bool button1Flag = false;

        Bitmap imgMF = new Bitmap(1, 1);

        static readonly int MS_WIDTH  = 500;
        static readonly int MS_HEIGHT = 500;
        static readonly int BG_WIDTH  = 300;
        static readonly int BG_HEIGHT = 300;
        static readonly int PB1_WIDTH  = 100;
        static readonly int PB1_HEIGHT = 100;
        static readonly int PN1_WIDTH  = 50;
        static readonly int PN1_HEIGHT = 50;
        static readonly int BTN1_WIDTH  = 100;
        static readonly int BTN1_HEIGHT = 100;


        public MainForm()
        {
            MinimumSize = new Size(MS_WIDTH, MS_HEIGHT);

            //PictureBoxを追加
            backGround = new PictureBox();
            backGround.Location = new Point(backGround_X, backGround_Y);
            backGround.BackColor = Color.AliceBlue;
            backGround.Size = new Size(BG_WIDTH, BG_HEIGHT);

            //PictureBoxを追加
            pBox1 = new PictureBox();
            pBox1.Location = new Point(pBox1_X, pBox1_Y);
            pBox1.BackColor = Color.Red;
            pBox1.Size = new Size(PB1_WIDTH, PB1_HEIGHT);

            //Panelを追加
            panel1_X = ClientSize.Width;
            panel1_Y = 0;
            panel1 = new Panel();
            panel1.Location = new Point(panel1_X, panel1_Y);
            panel1.BackColor = Color.Blue;
            panel1.Size = new Size(PN1_WIDTH, PN1_HEIGHT);

            //Buttonを追加
            button1 = new Button();
            button1.Text = "リスト";
            button1.ForeColor = Color.White;
            button1.Location = new Point(btn1_X, btn1_Y);
            button1.BackColor = Color.Green;
            button1.Size = new Size(BTN1_WIDTH, BTN1_HEIGHT);

            //コントロールを追加するときはContlors.AddRangeを使う
            Controls.AddRange(new Control[] {button1, pBox1, panel1, backGround});
            KeyDown += new KeyEventHandler(KeyControl);
            button1.Click += new EventHandler(button1_Click);
            Load += new EventHandler(MainForm_Load);
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            //ウィンドウサイズが変更されたときに呼び出す
            SizeChanged += Window_SizeChanged;
        }

            void LoadImage()
        {

        }


        //KeyCodeを使ってPictureBoxを移動させる
        void KeyControl(object sender, KeyEventArgs e)
        {
            var k = e.KeyCode;
            Console.WriteLine($"{k}");

            switch (k)
            {
                case Keys.Up:
                    pBox1_Y += 1;
                    backGround_Y -= 1;
                    break;

                case Keys.Down:
                    pBox1_Y -= 1;
                    backGround_Y += 1;
                    break;

                case Keys.Left:
                    pBox1_X -= 1;
                    backGround_X += 1;
                    break;

                case Keys.Right:
                    pBox1_X += 1;
                    backGround_X -= 1;
                    break;

                default:
                    break;

            }

            pBox1.Location = new Point(pBox1_X, pBox1_Y);
            backGround.Location = new Point(backGround_X, backGround_Y);
        }

        void button1_Click(object sender, EventArgs e)
        {
            if (button1Flag == false)
            {
                panel1_X = ClientSize.Width - PN1_WIDTH;
                panel1.Location = new Point(panel1_X, panel1_Y);
                button1Flag = true;
                Console.WriteLine($"{button1Flag}");
            }
            else if (button1Flag == true)
            {
                panel1_X = ClientSize.Width;
                panel1.Location = new Point(panel1_X, panel1_Y);
                button1Flag = false;
                Console.WriteLine($"{button1Flag}");
            }

        }

        private void Window_SizeChanged(object sender, EventArgs e)
        {

        }

        void ViewImage(Graphics g, int px, int py)
        {
             
        }

    }
}
