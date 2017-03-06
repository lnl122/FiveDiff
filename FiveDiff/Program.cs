// Copyright © 2016 Antony S. Ovsyannikov aka lnl122
// License: http://opensource.org/licenses/MIT

// иконка взята из библиотеки http://ru.depositphotos.com/78534752/stock-illustration-numeric-number-created-with-painting.html

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
        static public PictureBox img = new PictureBox();
        static public ComboBox SelectLang;
        static public ComboBox SelectNumPlace;
        static public ComboBox SelectAnswerType;
        static public TextBox Answer;
        static public LinkLabel llLink = new LinkLabel();
        static public Label lInfo = new Label();
        static public Form F;
        static public System.Timers.Timer t1;
        // ответ картинками для отображения
        static public Bitmap[] pairs;
        // флаг для таймера
        static public int num = 1;
        // линк на гитхаб
        private const string github_project_link = "https://github.com/lnl122/FiveDiff";


        static public System.IO.StreamWriter logfile;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            string local_path = Environment.CurrentDirectory;
            string self_name = System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName;
            string pathfilename = local_path + "\\" + self_name + ".log";
            logfile = new System.IO.StreamWriter(System.IO.File.AppendText(pathfilename).BaseStream);
            logfile.AutoFlush = true;

            logfile.WriteLine("\r\n\r\nStart");

            logfile.WriteLine("GetTempPath");
            TempFolder = System.IO.Path.GetTempPath();
            logfile.WriteLine("PrepareForm");
            PrepareForm();
            logfile.WriteLine("PrepareTimer");
            PrepareTimer();
            /*
            string p1 = @"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic02.jpg"; // зеленая игра
            FiveDifference b = new FiveDifference(new Bitmap(p1), new FiveDifference.Settings(FiveDifference.setNums.Up, FiveDifference.setLang.Eng, FiveDifference.setType._A1));
            */

            logfile.WriteLine("F_SizeChanged");
            F_SizeChanged(null, null);
            logfile.WriteLine("Application.Run");
            Application.Run(F);

            logfile.WriteLine("End");

            logfile.Flush();
            logfile.Close();
            logfile = null;
        }

        /// <summary>
        /// создает структуру настроек из ГУИ для класса, решаемого задачу.
        /// </summary>
        /// <returns></returns>
        private static FiveDifference.Settings CreateAnswerFormat()
        {
            logfile.WriteLine("CreateAnswerFormat");
            FiveDifference.Settings set = new FiveDifference.Settings();
            set.lang = FiveDifference.setLang.Eng;
            if (SelectLang.SelectedIndex == 1) { set.lang = FiveDifference.setLang.Rus; }
            set.nums = FiveDifference.setNums.Up;
            if (SelectNumPlace.SelectedIndex == 1) { set.nums = FiveDifference.setNums.Left; }
            set.type = FiveDifference.setType._A1;
            if (SelectAnswerType.SelectedIndex == 1) { set.type = FiveDifference.setType._1A; }
            return set;
        }

        /// <summary>
        /// запустить решение с файлом картинки по указанному пути
        /// </summary>
        /// <param name="v">путь к изображению</param>
        private static void RunWithFile(string v)
        {
            logfile.WriteLine("RunWithFile");
            using (Bitmap Bmp = new Bitmap(v))
            {
                logfile.WriteLine("img.Image = Bmp");
                img.Image = Bmp;
                logfile.WriteLine("F.Update");
                F.Update();
                logfile.WriteLine("new FiveDifference");
                FiveDifference a = new FiveDifference(Bmp, CreateAnswerFormat());
                logfile.WriteLine("pairs = new Bitmap[2]");
                pairs = new Bitmap[2];
                logfile.WriteLine("pairs[1] = a.Img2");
                pairs[0] = a.Img1;
                pairs[1] = a.Img2;
                Answer.Text = a.Answer;
                logfile.WriteLine("Clipboard.SetText");
                if (a.Answer != "") { Clipboard.SetText(a.Answer); }
                a = null;
            }
            logfile.WriteLine("RunWithFile_End");
        }

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
            F.Icon = Properties.Resources.favicon;
            F.SizeChanged += F_SizeChanged;
            F.AllowDrop = true;
            F.Width = 530;
            F.Height = 300;
            SelectLang = new ComboBox();
            SelectLang.Items.Add("Latin");
            SelectLang.Items.Add("Русские");
            SelectLang.SelectedIndex = 0;
            F.Controls.Add(SelectLang);
            SelectNumPlace = new ComboBox();
            SelectNumPlace.Items.Add("Nums UP");
            SelectNumPlace.Items.Add("Nums LEFT");
            SelectNumPlace.SelectedIndex = 0;
            F.Controls.Add(SelectNumPlace);
            SelectAnswerType = new ComboBox();
            SelectAnswerType.Items.Add("A1B2C3D4E5");
            SelectAnswerType.Items.Add("1A2B3C4D5E");
            SelectAnswerType.SelectedIndex = 0;
            F.Controls.Add(SelectAnswerType);
            Answer = new TextBox();
            F.Controls.Add(Answer);
            lInfo.Text = "(c) 2017 Antony S. Ovsyannikov aka lnl122.";
            F.Controls.Add(lInfo);
            llLink.Text = github_project_link;
            llLink.TextAlign = System.Drawing.ContentAlignment.TopRight;
            llLink.LinkClicked += new LinkLabelLinkClickedEventHandler(Event_llLink_LinkClicked);
            F.Controls.Add(llLink);


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

            lInfo.Left = 10;

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
            logfile.WriteLine("Img_DragEnter");
            e.Effect = DragDropEffects.Move;
        }

        /// <summary>
        /// ивент по нажатию на ссылку перехода на страницу проекта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Event_llLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(github_project_link);
        }

        /// <summary>
        /// ивент на перетаскивание файла или ссылки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Img_DragDrop(object sender, DragEventArgs e)
        {
            logfile.WriteLine("Img_DragDrop");
            t1.Enabled = false;
            logfile.WriteLine("e.Data.GetData");
            string lnk = (string)e.Data.GetData(DataFormats.Text, true);
            if (lnk != null)
            {
                logfile.WriteLine("_browser");
                // перетащенная ссылка из браузера
                string path = TempFolder + lnk.Substring(lnk.LastIndexOf("/") + 1);
                logfile.WriteLine("SafeDownload");
                SafeDownload(lnk, path);
                logfile.WriteLine("if (System.IO.File.Exists");
                if (System.IO.File.Exists(path))
                {
                    logfile.WriteLine("RunWithFile(path)");
                    RunWithFile(path);
                    logfile.WriteLine("System.IO.File.Delete");
                    System.IO.File.Delete(path);
                }
            }
            else
            {
                logfile.WriteLine("_file");
                // перетащенный файл
                logfile.WriteLine("e.Data.GetData");
                string[] lnkarr = (string[])e.Data.GetData(DataFormats.FileDrop, true);
                logfile.WriteLine("RunWithFile(path)");
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
            logfile.WriteLine("SafeDownload");
            using (var client = new System.Net.WebClient())
            {
                logfile.WriteLine("new System.Net.WebClient()");
                int max_count = 5;
                bool need_download = true;
                logfile.WriteLine("before While");
                while (need_download && (max_count != 0))
                {
                    logfile.WriteLine("max_count = {0}", max_count.ToString());
                    try
                    {
                        logfile.WriteLine("try");
                        logfile.WriteLine("client.DownloadFile");
                        client.DownloadFile(lnk, path);
                        logfile.WriteLine("DownloadFile done");
                        need_download = false;
                    }
                    catch
                    {
                        logfile.WriteLine("catch");
                        max_count--;
                    }
                }
                logfile.WriteLine("after While");
            }
            logfile.WriteLine("SafeDownload end");
        }

        /// <summary>
        /// изменение размеров окна-  корректировка положения картинки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void F_SizeChanged(object sender, EventArgs e)
        {
            logfile.WriteLine("F_SizeChanged");
            img.Top = 5;
            img.Left = 5;
            img.Width = F.Width - 25;
            img.Height = F.Height - 50;

            lInfo.Top = F.Height - 55;
            lInfo.Width = 225;// Math.Min(F.Width / 2 - 15, 225);
            llLink.Top = lInfo.Top;
            llLink.Height = lInfo.Height;
            llLink.Width = 170;// Math.Min(F.Width / 2 - 15, 170);
            llLink.Left = F.Width - lInfo.Width + 30;

        }
    }
}
