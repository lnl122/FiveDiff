using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveDiff
{
    class ImageDiff
    {
        public const int vertical = 1;
        public const int horizontal = 2;
        private Bitmap bmp;
        private int method = 0;
        private Rect rPart1;
        private Rect rPart2;
        private Bitmap Part1;
        private Bitmap Part2;

        private struct Rect
        {
            public int left;
            public int top;
            public int width;
            public int height;
        }
        /// <summary>
        /// определяет по ширине/высоте картинки вероятное расположение частей (вертикаль/горизонталь)
        /// </summary>
        private void GetMethod()
        {
            int width = bmp.Width;
            int height = bmp.Height;
            Rect r = new Rect();
            if (width >= height)
            {
                method = vertical;
                r.top = 0;
                r.left = 0;
                r.width = width / 2;
                r.height = height;
                rPart1 = r;
                r.top = 0;
                r.left = r.width + 1;
                r.width = width - r.width;
                r.height = height;
                rPart2 = r;
            }
            else
            {
                method = horizontal;
                r.top = 0;
                r.left = 0;
                r.width = width;
                r.height = height / 2;
                rPart1 = r;
                r.top = r.height + 1;
                r.left = 0;
                r.width = width;
                r.height = height - r.height;
                rPart2 = r;
            }
        }

        private Bitmap CutPart(Rect r)
        {
            Bitmap res = new Bitmap(r.width, r.height);
            Rectangle re1 = new Rectangle(r.left, r.top, r.width, r.height);
            res = bmp.Clone(re1, bmp.PixelFormat);
            return res;
        }
        /// <summary>
        /// разрезает картину на две части согласно выбранного метода
        /// </summary>
        private void CutImage()
        {
            Part1 = CutPart(rPart1);
            Part2 = CutPart(rPart2);
        }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="b">битмап, в котором нужно найти отличия</param>
        /// <param name="m">метод разделения изображения (0-опрелелим, 1-вертикально, 2-горизонтально)</param>
        public ImageDiff(Bitmap b, int m = 0)
        {
            bmp = b;
            method = m;
            if (method == 0)
            {
                GetMethod();
            }
            CutImage();


        }
    }
}
