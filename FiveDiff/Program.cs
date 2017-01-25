using System;
using System.Drawing;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiveDiff
{
    static class Program
    {

        static public PictureBox img;
        static public Form F;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Bitmap bmp = new Bitmap(@"C:\_2del\pic03.jpg");
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

            //img.Image = bmp;

            F_SizeChanged(null, null);
            Application.Run(F);
        }

        private static void Img_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private static void Img_DragDrop(object sender, DragEventArgs e)
        {
            string lnk = (string)e.Data.GetData(DataFormats.Text, true);
            System.Windows.Forms.PictureBox PictBox = new System.Windows.Forms.PictureBox();
            PictBox.Load(lnk);
            Bitmap Bmp = new Bitmap(PictBox.Image);
            img.Image = Bmp;
            F.Update();
            ImageDiff a = new ImageDiff(Bmp);
            img.Image = a.ResultBmp;
            F.Update();
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
