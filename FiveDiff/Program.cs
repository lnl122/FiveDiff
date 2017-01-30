using System;
using System.Drawing;
using System.Windows.Forms;

namespace FiveDiff
{
    static class Program
    {

        static public PictureBox img;
        static public Form F;
        static public System.Timers.Timer t1;
        static public Bitmap[] pairs;
        static public int num;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Bitmap bmp = new Bitmap(@"C:\_2del\pic01.jpg");
            //ImageDiff a = new ImageDiff(bmp);

            F = new Form();
            F.SizeChanged += F_SizeChanged;
            F.AllowDrop = true;
            img = new PictureBox();
            img.AllowDrop = true;
            img.SizeMode = PictureBoxSizeMode.StretchImage;
            img.DragDrop += Img_DragDrop;
            img.DragEnter += Img_DragEnter;
            F.Controls.Add(img);

            t1 = new System.Timers.Timer();
            t1.Interval = 500;
            t1.AutoReset = true;
            t1.Elapsed += T_Elapsed;

            F_SizeChanged(null, null);
            Application.Run(F);
        }

        private static void T_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            img.Image = pairs[num];
            num = 1 - num;
        }

        private static void Img_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private static void Img_DragDrop(object sender, DragEventArgs e)
        {
            t1.Enabled = false;
            string lnk = (string)e.Data.GetData(DataFormats.Text, true);
            if (lnk != null)
            {
                PictureBox PictBox = new PictureBox();
                PictBox.Load(lnk);
                Bitmap Bmp = new Bitmap(PictBox.Image);
                img.Image = Bmp;
                F.Update();
                ImageDiff a = new ImageDiff(Bmp);
                pairs = new Bitmap[2];
                pairs[0] = a.img1;
                pairs[1] = a.img2;
            }else
            {
                string[] lnkarr = (string[])e.Data.GetData(DataFormats.FileDrop, true);
                lnk = lnkarr[0];
                Bitmap Bmp = new Bitmap(lnk);
                img.Image = Bmp;
                F.Update();
                ImageDiff a = new ImageDiff(Bmp);
                pairs = new Bitmap[2];
                pairs[0] = a.img1;
                pairs[1] = a.img2;
            }
            t1.Enabled = true;
        }

        private static void F_SizeChanged(object sender, EventArgs e)
        {
            img.Top = 5;
            img.Left = 5;
            img.Width = F.Width - 25;
            img.Height = F.Height - 50;
        }
    }
}
