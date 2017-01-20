using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(@"C:\_2del\pic01.jpg");
            ImageDiff a = new ImageDiff(bmp);
            int ii = 0;
            //Application.Run(new Form1());
        }
    }
}
