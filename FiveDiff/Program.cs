// Copyright © 2016 Antony S. Ovsyannikov aka lnl122
// License: http://opensource.org/licenses/MIT

using System;
using System.Drawing;
using System.Windows.Forms;

namespace FiveDiff
{
    static class Program
    {
        // заполнится ниже
        static public string TempFolder = "";
        // элементы формы
        static public PictureBox img;
        static public ComboBox SelectLang;
        static public ComboBox SelectNumPlace;
        static public ComboBox SelectAnswerType;
        static public TextBox Answer;
        static public Form F;
        static public System.Timers.Timer t1;
        // ответ картинками для отображения
        static public Bitmap[] pairs;
        // флаг для таймера
        static public int num = 1;

        //
        //
        // удалить после перехода на новый класс
        //
        //
        static public string answerformat;// = "LaUp1A";

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TempFolder = System.IO.Path.GetTempPath();
            PrepareForm();
            PrepareTimer();

            string p1 = @"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic02.jpg"; // зеленая игра
            //p1 = @"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\9\lu.jpg";
            p1 = @"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\5_EnUpA1\B5C1F6H8L4.jpg"; //розовая сетка
            //p1 = @"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\5_EnUpA1\A2A7D2D5E8.jpg"; // яйца, поля
            //p1 = @"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\4_EnLeA1\F2H3C6G8D9.jpg"; // шахматы
            p1 = @"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Б3Д4А6И6Ж8-2.jpg";
            p1 = @"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B6C3C4D2E5-1.jpg"; // фрукты
            p1 = @"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A2A7D2D5E8.jpg"; // белая раска вокруг
            p1 = @"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4F4I5J6K3.jpg"; // белый фон картинки
            FiveDifference b = new FiveDifference(new Bitmap(p1), new FiveDifference.Settings(FiveDifference.setNums.Left, FiveDifference.setLang.Rus, FiveDifference.setType._A1));

            //string v1 = @"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A5B2B4B7E6-2.jpg";
            //string v2 = "EnUpA1";
            //FindFiveDiff a = new FindFiveDiff(new Bitmap(v1), v2);

            //F_SizeChanged(null, null);
            //Application.Run(F);
        }

        //
        //
        //
        // здесь и в следующем методе необходимо будет заменить метод подготовки формата ответа и вызова класса, решающего задачу.
        //
        //
        //
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
                Clipboard.SetText(a.Answer);
                a = null;
            }
        }
        //
        //
        //


        /// <summary>
        /// подготовка таймера
        /// </summary>
        private static void PrepareTimer()
        {
            t1 = new System.Timers.Timer();
            t1.Interval = 250;
            t1.AutoReset = true;
            t1.Elapsed += T_Elapsed;
        }
        /// <summary>
        /// подготовка формы
        /// </summary>
        private static void PrepareForm()
        {
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
            SelectAnswerType.Items.Add("A1B2C3D4E5");
            SelectAnswerType.Items.Add("1A2B3C4D5E");
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
            img.Top = 5;
            img.Left = 5;
            img.Width = F.Width - 25;
            img.Height = F.Height - 50;
            img.DragDrop += Img_DragDrop;
            img.DragEnter += Img_DragEnter;
            F.Controls.Add(img);
        }
        /// <summary>
        /// дейсвтие таймера (менять картинку)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void T_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            img.Image = pairs[num];
            num = 1 - num;
        }
        /// <summary>
        /// d&d enter event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Img_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        /// <summary>
        /// ивент на перетаскивание файла или ссылки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Img_DragDrop(object sender, DragEventArgs e)
        {
            t1.Enabled = false;
            string lnk = (string)e.Data.GetData(DataFormats.Text, true);
            if (lnk != null)
            {
                // перетащенная ссылка из браузера
                string path = TempFolder + lnk.Substring(lnk.LastIndexOf("/") + 1);
                SafeDownload(lnk, path);
                if (System.IO.File.Exists(path))
                {
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
        /// <summary>
        /// пятикратные попытки скачивания - не гарант, но хоть чтото
        /// </summary>
        /// <param name="lnk">ссылка</param>
        /// <param name="path">путь для сохранения локально</param>
        private static void SafeDownload(string lnk, string path)
        {
            using (var client = new System.Net.WebClient())
            {
                int max_count = 5;
                bool need_download = true;
                while (need_download && (max_count != 0))
                {
                    try
                    {
                        client.DownloadFile(lnk, path);
                        need_download = false;
                    }
                    catch
                    {
                        max_count--;
                    }
                }
            }
        }
        /// <summary>
        /// изменение размеров окна-  корректировка положения картинки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void F_SizeChanged(object sender, EventArgs e)
        {
            img.Top = 5;
            img.Left = 5;
            img.Width = F.Width - 25;
            img.Height = F.Height - 50;
        }
    }
}
