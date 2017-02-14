// Copyright © 2016 Antony S. Ovsyannikov aka lnl122
// License: http://opensource.org/licenses/MIT

using System;
using System.Drawing;
using System.Windows.Forms;

namespace FiveDiff
{
    static class Program
    {

        static public PictureBox img;
        static public ComboBox SelectLang;
        static public ComboBox SelectNumPlace;
        static public ComboBox SelectAnswerType;
        static public TextBox Answer;
        static public Form F;
        static public System.Timers.Timer t1;
        static public Bitmap[] pairs;
        static public int num = 1;
        static public string answerformat = "LaUp1A";

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            F = new Form();
            F.Text = "Найдём пять отличий и покажем код. Перетащите картинку.";
            F.SizeChanged += F_SizeChanged;
            F.AllowDrop = true;
            SelectLang = new ComboBox();
            SelectLang.Items.Add("Latin");
            SelectLang.Items.Add("Русские");
            SelectLang.SelectedIndex = 0;
            //SelectLang.SelectedIndexChanged += Select_SelectedIndexChanged;
            F.Controls.Add(SelectLang);
            SelectNumPlace = new ComboBox();
            SelectNumPlace.Items.Add("Nums UP");
            SelectNumPlace.Items.Add("Nums LEFT");
            SelectNumPlace.SelectedIndex = 0;
            //SelectNumPlace.SelectedIndexChanged += Select_SelectedIndexChanged;
            F.Controls.Add(SelectNumPlace);
            SelectAnswerType = new ComboBox();
            SelectAnswerType.Items.Add("1A2B3C4D5E");
            SelectAnswerType.Items.Add("A1B2C3D4E5");
            SelectAnswerType.SelectedIndex = 0;
            //SelectAnswerType.SelectedIndexChanged += Select_SelectedIndexChanged;
            F.Controls.Add(SelectAnswerType);
            Answer = new TextBox();
            F.Controls.Add(Answer);

            SelectLang.Top = 10;
            SelectLang.Left = 10;
            SelectLang.Width = 100;
            SelectNumPlace.Top = 10;
            SelectNumPlace.Left = SelectLang.Right + 20;
            SelectNumPlace.Width = 100;
            SelectAnswerType.Top = 10;
            SelectAnswerType.Left = SelectNumPlace.Right + 20;
            SelectAnswerType.Width = 100;

            Answer.Top = 10;
            Answer.Left = SelectAnswerType.Right + 50;
            Answer.Width = 100;


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
            /*
            Bitmap bmp = new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic00.jpg");
            FindFiveDiff a = new FindFiveDiff(bmp, "RuLeA1");
            //Save_h_info(b,"01");
            int iii = 0;
            Bitmap bmp2 = new Bitmap(@"C:\temp\02.jpg");
            FindFiveDiff a2 = new FindFiveDiff(bmp2, answerformat);
            //Save_h_info(b2,"02");
            //return;
            int iiii = 0;
            */
            //t1.Enabled = true;

            F_SizeChanged(null, null);
            Application.Run(F);
        }

        /*private static void Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lang = "La";
            if (SelectLang.SelectedIndex == 1) { lang = "Ru"; }
            string nums = "Up";
            if (SelectLang.SelectedIndex == 1) { nums = "Le"; }
            string answ = "1A";
            if (SelectLang.SelectedIndex == 1) { answ = "A1"; }
            answerformat = lang + nums + answ;
        }*/
        private static void CreateAnswerFormat()
        {
            string lang = "La";
            if (SelectLang.SelectedIndex == 1) { lang = "Ru"; }
            string nums = "Up";
            if (SelectNumPlace.SelectedIndex == 1) { nums = "Le"; }
            string answ = "1A";
            if (SelectAnswerType.SelectedIndex == 1) { answ = "A1"; }
            answerformat = lang + nums + answ;
        }

        /*
private static void Save_h_info(FindLetters b, string s)
{
   using (System.IO.StreamWriter log = new System.IO.StreamWriter(System.IO.File.AppendText(@"C:\temp\"+s+".txt").BaseStream))
   {
       log.WriteLine("0_1\tf_1\t0_2\tf_2\tg1\tc1\tg2\tc2\tg3\tc3");
       for (int i = 0; i < b.h_00_1.Length; i++)
       {
           log.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}",
               b.h_00_1[i], b.h_ff_1[i], b.h_00_2[i], b.h_ff_2[i],
               b.h_gr_4[i], b.h_co_4[i], b.h_gr_8[i], b.h_co_8[i], b.h_gr_16[i], b.h_co_16[i]);
       }
   }
}
*/
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
                // перетащенная ссылка из браузера
                using (var client = new System.Net.WebClient())
                {
                    string path = @"C:\TEMP\" + lnk.Substring(lnk.LastIndexOf("/") + 1);
                    client.DownloadFile(lnk, path);
                    RunWithFile(path);
                    System.IO.File.Delete(path);
                }
            }
            else
            {
                // перетащенный файл
                string[] lnkarr = (string[])e.Data.GetData(DataFormats.FileDrop, true);
                RunWithFile(lnkarr[0]);
            }
            t1.Enabled = true;
        }

        private static void RunWithFile(string v)
        {
            using (Bitmap Bmp = new Bitmap(v))
            {
                img.Image = Bmp;
                F.Update();
                CreateAnswerFormat();
                FindFiveDiff a = new FindFiveDiff(Bmp, answerformat);
                pairs = new Bitmap[2];
                pairs[0] = a.Img1;
                pairs[1] = a.Img2;
                Answer.Text = a.Answer;
                a = null;
            }
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
