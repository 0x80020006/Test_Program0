using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test_Program
{
    class MainForm : Form
    {
        string FilePath;

        //読み込んだファイル一覧
        List<string> filesList;
        List<string> fileNameList;
        List<FileInfo> fileInfo;

        //メニューバー
        MenuStrip menuStrip;
        OpenFileDialog ofd;


        PictureBox backGround;
        int backGround_X = 0;
        int backGround_Y = 23;

        PictureBox pBox1;
        int pBox1_X = 0;
        int pBox1_Y = 23;

        Panel panel1;
        int panel1_X = 0;
        int panel1_Y = 23;

        ListBox lBox1;
        int lBox1_X = 0;
        int lBox1_Y = 23;

        ListView lView1;
        int lView1_X = 0;
        int lView1_Y = 23;

        ColumnHeader lView1Name;
        ColumnHeader lView1FileSize;

        Button button1;
        int btn1_X = 100;
        int btn1_Y = 23;
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
        static readonly int LV1_WIDTH  = 200;
        static readonly int LV1_HEIGHT = 400;
        static readonly int LB1_WIDTH  = 200;
        static readonly int LB1_HEIGHT = 400;
        static readonly int BTN1_WIDTH  = 100;
        static readonly int BTN1_HEIGHT = 100;


        public MainForm()
        {
            MinimumSize = new Size(MS_WIDTH, MS_HEIGHT);

            //メニューバー表示
            menuStrip = new MenuStrip();

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
            panel1 = new Panel();
            panel1.Location = new Point(panel1_X, panel1_Y);
            panel1.BackColor = Color.Blue;
            panel1.Size = new Size(PN1_WIDTH, PN1_HEIGHT);

            //ListViewを追加
            lView1_X = ClientSize.Width;
            lView1 = new ListView();
            lView1.Location = new Point(lView1_X, lView1_Y);
            lView1.BackColor = Color.Green;
            lView1.Size = new Size(LV1_WIDTH, LV1_HEIGHT);
            //ListViewへのColumnの追加
            lView1.View = View.Details;
            lView1Name = new ColumnHeader();

            lView1Name.Text = "名前";
            ColumnHeader[] lView1Header = { lView1Name };
            lView1.Columns.AddRange(lView1Header);

            //ListBoxを追加
            lBox1_X = ClientSize.Width - lBox1_X;
            lBox1 = new ListBox();
            lBox1.Location = new Point(lBox1_X, lBox1_Y);
            lBox1.Size = new Size(LB1_WIDTH, LB1_HEIGHT);

            //Buttonを追加
            button1 = new Button();
            button1.Text = "リスト";
            button1.ForeColor = Color.White;
            button1.Location = new Point(btn1_X, btn1_Y);
            button1.BackColor = Color.Green;
            button1.Size = new Size(BTN1_WIDTH, BTN1_HEIGHT);

            //コントロールを追加するときはContlors.AddRangeを使う
            Controls.AddRange(new Control[] {menuStrip, button1, pBox1, lView1, lBox1, panel1, backGround});
            KeyDown += new KeyEventHandler(KeyControl);
            button1.Click += new EventHandler(button1_Click);
            Load += new EventHandler(MainForm_Load);
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            //ウィンドウサイズが変更されたときに呼び出す
            SizeChanged += Window_SizeChanged;

            //メニューにファイルを表示する
            ToolStripMenuItem menuFile = new ToolStripMenuItem();
            menuFile.Text = "ファイル(&F)";
            menuStrip.Items.Add(menuFile);

            //メニュー内容            
            ToolStripMenuItem menuFileOpen = new ToolStripMenuItem();

            menuFileOpen.Text = "開く(&O)";
            //「ファイルを開く」の実行
            menuFileOpen.Click += new EventHandler(Open_Click);
            menuFile.DropDownItems.Add(menuFileOpen);
            ToolStripMenuItem menuFileEnd = new ToolStripMenuItem();

            menuFileEnd.Text = "終了(&X)";
            //「アプリケーションの終了」の実行
            menuFileEnd.Click += new EventHandler(Close_Click);
            menuFile.DropDownItems.Add(menuFileEnd);
        }

        private void Open_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            //読み込み許可ファイルの種類の設定 
            ofd.Filter = "Image File(*.bmp,*.jpg,*.png)|*.bmp;*.jpg;*.png|Bitmap(*.bmp)|*.bmp|Jpeg(*.jpg)|*.jpg|PNG(*.png)|*.png";
            //ファイルを選択してOKしたときの処理
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine($"読み込みファイル:{ofd.FileName}");
                string folderPath = Path.GetDirectoryName(ofd.FileName);

                //↓はListで要素格納できるけど、データサイズが格納できていない？
                //IEnumerable<string> files = Directory.EnumerateFiles(folderPath).Where(str => str.EndsWith(".bmp") || str.EndsWith(".jpg") || str.EndsWith(".png"));
                //filesList = files.ToList();
                //Console.WriteLine($"{fileInfo[0]},{fileInfo[0].Length}");


                //↓は動くけど、*(ワイルドカード)で要素を格納しているため、余計なファイルも格納してしまう
                fileInfo = new DirectoryInfo(folderPath).EnumerateFiles("*", SearchOption.TopDirectoryOnly).ToList();
                Console.WriteLine($"{fileInfo[1]},{fileInfo[1].Length}");
                fileInfo.ForEach(Console.WriteLine);

            }
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
                lView1_X = ClientSize.Width - LV1_WIDTH;
                //panel1.Location = new Point(panel1_X, panel1_Y);
                button1Flag = true;
            }
            else if (button1Flag == true)
            {
                panel1_X = ClientSize.Width;
                lView1_X = ClientSize.Width;
                //panel1.Location = new Point(panel1_X, panel1_Y);
                button1Flag = false;
            }
            lView1.Location = new Point(lView1_X, lView1_Y);
            Console.WriteLine($"{lView1.Size}{LV1_HEIGHT}");
            Console.WriteLine($"{button1Flag}");

        }

        private void Window_SizeChanged(object sender, EventArgs e)
        {
            //ウィンドウサイズ変更時にListBoxの位置も合わせて調整する
            if (button1Flag == false)
            {
                lView1_X = ClientSize.Width;
            }
            else if (button1Flag == true)
            {
                lView1_X = ClientSize.Width - LV1_WIDTH;
            }
            lView1.Location = new Point(lView1_X, lView1_Y);
        }

        void ViewImage(Graphics g, int px, int py)
        {
             
        }

        //アプリケーション終了
        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
