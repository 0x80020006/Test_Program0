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

        PictureBox backGround;
        PictureBox pBox1;
        static readonly int MF_WIDTH  = 500;
        static readonly int MF_HEIGHT = 500;

        public MainForm()
        {
            MinimumSize = new Size(MF_WIDTH, MF_HEIGHT);
            
            backGround = new PictureBox();
            backGround.Location = new Point(0, 0);
            backGround.BackColor = Color.AliceBlue;
            backGround.Size = new Size(300, 300);


            pBox1 = new PictureBox();
            pBox1.Location = new Point(0, 0);
            pBox1.BackColor = Color.Red;
            pBox1.Size = new Size(100, 100);

            //コントロールを追加するときはContlors.AddRangeを使う
            Controls.AddRange(new Control[] {pBox1, backGround});
        }

    }
}
