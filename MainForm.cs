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

        Bitmap imgMF = new Bitmap(1, 1);
        static readonly int MF_WIDTH  = 500;
        static readonly int MF_HEIGHT = 500;
        static readonly int BG_WIDTH  = 300;
        static readonly int BG_HEIGHT = 300;
        static readonly int PB1_WIDTH  = 100;
        static readonly int PB1_HEIGHT = 100;


        public MainForm()
        {
            MinimumSize = new Size(MF_WIDTH, MF_HEIGHT);
            
            backGround = new PictureBox();
            backGround.Location = new Point(backGround_X, backGround_Y);
            backGround.BackColor = Color.AliceBlue;
            backGround.Size = new Size(BG_WIDTH, BG_HEIGHT);

            pBox1 = new PictureBox();
            pBox1.Location = new Point(pBox1_X, pBox1_Y);
            pBox1.BackColor = Color.Red;
            pBox1.Size = new Size(PB1_WIDTH, PB1_HEIGHT);

            //コントロールを追加するときはContlors.AddRangeを使う
            Controls.AddRange(new Control[] {pBox1, backGround});
            KeyDown += new KeyEventHandler(KeyControl);
        }

        void LoadImage()
        {
            //var g = Graphics.FromImage(imgMF);
            //Image img = Image.FromFile(FilePath);
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

        void ViewImage(Graphics g, int px, int py)
        {
             
        }

    }
}
