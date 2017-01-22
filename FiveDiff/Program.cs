using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiveDiff
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Go(1);
            //Go(2);
            //Go(3);
            //Go(4);
            //Go(5);
            //Go(6);
            //Go(7);
            //Go(8);

            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(@"C:\_2del\pic02.jpg");
            ImageDiff a = new ImageDiff(bmp);

            int ii = 0;
            //Application.Run(new Form1());
        }

        static void Go(int i)
        {
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(@"C:\_2del\pic0"+i.ToString()+".jpg");
            ImageDiff a = new ImageDiff(bmp);
            string res = "";
            for (int j = 0; j < 4; j++)
            {
                res = res + j.ToString() + ": " +
                a.LineAnalize[j].PartNum + " " +
                a.LineAnalize[j].orientation + " " +
                a.LineAnalize[j].SeparatorCount.ToString() + " " +
                a.LineAnalize[j].SeparatorWidth.ToString() + "\r\n";
            }
            MessageBox.Show(res);
        }
    }
}
