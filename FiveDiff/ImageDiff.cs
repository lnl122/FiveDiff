//using System;
using System.Collections.Generic;
using System;
using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace FiveDiff
{
    class ImageDiff
    {
        public const int vertical = 1;
        public const int horizontal = 2;
        private Bitmap bmp;
        private int method = 0;
        private Rectangle rPart1;
        private Rectangle rPart2;
        private Bitmap Part1;
        private Bitmap Part2;
        bool error = false;

        public Lines[] LineAnalize;
        public struct Lines
        {
            public int PartNum;
            public char orientation;
            public int[] SumCol;
            public int[] MainCol;
            public int[] Diff;
            public int[] flag;
            public MainCols[] maincols;
            public int SeparatorStart;
            public int SeparatorEnd;
            public int SeparatorCount;
            public float SeparatorWidth;
        }
        public struct MainCols
        {
            public int[] col;
        }

        /// <summary>
        /// определяет по ширине/высоте картинки вероятное расположение частей (вертикаль/горизонталь)
        /// </summary>
        private void GetMethod()
        {
            int width = bmp.Width;
            int height = bmp.Height;
            if (width >= height)
            {
                method = vertical;
                rPart1 = new Rectangle(0, 0, (int)(width / 2), height);
                rPart2 = new Rectangle(rPart1.Width, 0, width - rPart1.Width, height);
            }
            else
            {
                method = horizontal;
                rPart1 = new Rectangle(0, 0, width, (int)(height / 2));
                rPart2 = new Rectangle(0, rPart1.Height, width, height - rPart1.Height);
            }
        }

        /// <summary>
        /// отрезает один кусок из начального файла
        /// </summary>
        /// <param name="r">прямоугольная область</param>
        /// <returns>отрезанный битмап</returns>
        private Bitmap CutPart(Rectangle r)
        {
            Bitmap res = new Bitmap(r.Width, r.Height);
            res = bmp.Clone(r, bmp.PixelFormat);
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
        /// получает и заполняет сведения о линиях всех направлений в обоих частях
        /// </summary>
        private void GetImagesLines()
        {
            LineAnalize = new Lines[4];
            LineAnalize[0] = GetLineInfo(1, 'v');
            LineAnalize[1] = GetLineInfo(1, 'h');
            LineAnalize[2] = GetLineInfo(2, 'v');
            LineAnalize[3] = GetLineInfo(2, 'h');
        }

        /// <summary>
        /// получает сведения о линиях в одной из картинок
        /// </summary>
        /// <param name="num">1/2 - первая/вторая часть картинки</param>
        /// <param name="orient">h/v - ориентация</param>
        /// <returns></returns>
        private Lines GetLineInfo(int num, char orient)
        {
            Lines res = new Lines();

            res.orientation = orient;
            res.PartNum = num;
            Bitmap part = Part1;
            if (num == 1) { part = Part1; }
            if (num == 2) { part = Part2; }
            int h = part.Height;
            int w = part.Width;

            if (orient == 'h')
            {
                int len = h;
                int cnt = w;
                res.SumCol = new int[len];
                res.Diff = new int[len - 1];
                res.flag = new int[len];
                res.maincols = new MainCols[len];
                res.MainCol = new int[len];
                for (int i = 0; i < len; i++)
                {
                    int[] sumcol = new int[cnt];
                    int[] diff = new int[cnt];
                    int[] main = new int[cnt];
                    for (int j = 0; j < cnt; j++)
                    {
                        Color c = part.GetPixel(j, i);
                        sumcol[j] = c.R + c.G + c.B;
                        if (i != len - 1)
                        {
                            Color c2 = part.GetPixel(j, i + 1);
                            diff[j] = Math.Abs(c.R - c2.R) + Math.Abs(c.G - c2.G) + Math.Abs(c.B - c2.B);
                        };
                        main[j] = ((c.R >> 7) << 2) + ((c.G >> 7) << 1) + (c.B >> 7);
                    }
                    MainCols mcols = new MainCols();
                    mcols.col = new int[8];
                    for (int j = 0; j < main.Length; j++)
                    {
                        mcols.col[main[j]]++;
                    }
                    res.maincols[i] = mcols;
                    int idx = 0;
                    int midx = mcols.col[0];
                    for (int j = 0; j < 8; j++)
                    {
                        if (mcols.col[j] > midx)
                        {
                            midx = mcols.col[j];
                            idx = j;
                        }
                    }
                    res.MainCol[i] = idx;
                    if (i != len - 1)
                    {
                        for (int j = 0; j < diff.Length; j++)
                        {
                            res.Diff[i] += diff[j];
                        }
                    }
                    for (int j = 0; j < sumcol.Length; j++)
                    {
                        res.SumCol[i] += sumcol[j];
                    }
                }
            }
            if (orient == 'v')
            {
                int len = w;
                int cnt = h;
                res.SumCol = new int[len];
                res.Diff = new int[len - 1];
                res.flag = new int[len];
                res.maincols = new MainCols[len];
                res.MainCol = new int[len];
                for (int i = 0; i < len; i++)
                {
                    int[] sumcol = new int[cnt];
                    int[] diff = new int[cnt];
                    int[] main = new int[cnt];
                    for (int j = 0; j < cnt; j++)
                    {
                        Color c = part.GetPixel(i, j);
                        sumcol[j] = c.R + c.G + c.B;
                        if (i != len - 1)
                        {
                            Color c2 = part.GetPixel(i + 1, j);
                            diff[j] = Math.Abs(c.R - c2.R) + Math.Abs(c.G - c2.G) + Math.Abs(c.B - c2.B);
                        }
                        main[j] = ((c.R >> 7) << 2) + ((c.G >> 7) << 1) + (c.B >> 7);
                    }
                    MainCols mcols = new MainCols();
                    mcols.col = new int[8];
                    for (int j = 0; j < main.Length; j++)
                    {
                        mcols.col[main[j]]++;
                    }
                    res.maincols[i] = mcols;
                    int idx = 0;
                    int midx = mcols.col[0];
                    for (int j = 0; j < 8; j++)
                    {
                        if (mcols.col[j] > midx)
                        {
                            midx = mcols.col[j];
                            idx = j;
                        }
                    }
                    res.MainCol[i] = idx;
                    if (i != len - 1)
                    {
                        for (int j = 0; j < diff.Length; j++)
                        {
                            res.Diff[i] += diff[j];
                        }
                    }
                    for (int j = 0; j < sumcol.Length; j++)
                    {
                        res.SumCol[i] += sumcol[j];
                    }
                }
            }

            return res;
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
            GetImagesLines();
            FindSeparators();
            //проверяем корректность полученных данных
            if ((LineAnalize[0].SeparatorCount != LineAnalize[2].SeparatorCount) ||
                (LineAnalize[1].SeparatorCount != LineAnalize[3].SeparatorCount) )
            {
                error = true;
            }
            //если все ок - продолжаем разбор
            if (!error)
            {
                // выравниваем саму таблицу с картинкой (убираем из видимости буквы/цифры)
                //


                // ищем несоответствия
                //
            }
        }

        /// <summary>
        /// ищет границы сетки
        /// </summary>
        private void FindSeparators()
        {
            for(int block=0; block<4; block++)
            {
                int[] diff = LineAnalize[block].Diff;
                int len = diff.Length;
                int cnt = GetCountNotZero(diff);
                while (cnt > len/20)
                {
                    int sum = GetSumArray(diff);
                    int avg = sum / cnt;
                    for(int i=0; i<len; i++)
                    {
                        if(diff[i] < avg)
                        {
                            diff[i] = 0;
                        }
                    }
                    cnt = GetCountNotZero(diff);
                }
                // diff = не более 3% наиболее высоких значений
                for (int i = 0; i < len; i++)
                {
                    if (diff[i] != 0)
                    {
                        LineAnalize[block].flag[i] = 1;
                        LineAnalize[block].flag[i+1] = 1;
                    }
                }
                // есть двойные и тройные подряд флаги - надо сузить их до точечно одной
                // для чёрного цвета должны быть пики цвета вниз
                for(int i = 1; i<len; i++)
                {
                    if (LineAnalize[block].flag[i] == 1)
                    {
                        if( (LineAnalize[block].SumCol[i] < LineAnalize[block].SumCol[i-1]) && (LineAnalize[block].SumCol[i] < LineAnalize[block].SumCol[i + 1]))
                        {
                            LineAnalize[block].flag[i] = 1;
                        }else
                        {
                            LineAnalize[block].flag[i] = 0;
                        }
                    }
                }
                LineAnalize[block].flag[0] = 1;
                LineAnalize[block].flag[len] = 1;
                AnalizeFlag(block);
            }

        }

        /// <summary>
        /// алализирует массив флагов из блока
        /// </summary>
        /// <param name="block">номер блока</param>
        private void AnalizeFlag(int block)
        {
            int[] a = LineAnalize[block].flag;
            int cnt = GetCountNotZero(a);
            //соберем позиции в один массив
            int[] b = new int[cnt];
            int j = 0;
            for(int i=0; i<a.Length; i++)
            {
                if(a[i] != 0)
                {
                    b[j] = i;
                    j++;
                }
            }
            // соберем разницы, а также разници "через одну" еще в один массив
            int l = (b.Length - 1) + (b.Length - 2);
            int[] c = new int[l];
            j = 0;
            for (int i = 0; i < b.Length - 1; i++)
            {
                c[j] = b[i + 1] - b[i];
                j++;
            }
            for (int i = 0; i < b.Length - 2; i++)
            {
                c[j] = b[i + 2] - b[i];
                j++;
            }
            // надо найти два самых частых значения, и. считать сколько попадает значений в диапазон +-5 от двух частых
            // если количества будут примерно равны - то берем наименьшее из двух частых.
            // иначе - то, которое чаще.
            List<int> number1 = new List<int>();
            List<int> count1 = new List<int>();
            for (int i = 0; i < l; i++)
            {
                int tested = c[i];
                int k = -1;
                for (int jj = 0; jj < number1.Count; jj++)
                {
                    if (number1[jj] == tested)
                    {
                        k = jj;
                    }
                }
                if (k == -1)
                {
                    number1.Add(c[i]);
                    count1.Add(1);
                }
                else
                {
                    count1[k]++;
                }
            }
            List<int> number = new List<int>();
            List<int> count = new List<int>();
            for(int i=0; i<l; i++)
            {
                int tested = c[i];
                int k = -1;
                for(int jj=0; jj<number.Count; jj++)
                {
                    if( (number[jj] >= tested-5) && (number[jj] <= tested + 5))
                    {
                        k = jj;
                    }
                }
                if (k == -1)
                {
                    number.Add(c[i]);
                    count.Add(1);
                }
                else
                {
                    count[k]++;
                }
            }
            int max1 = -1;
            int idx1 = -1;
            for(int i=0; i<count.Count; i++)
            {
                if(count[i] > max1)
                {
                    max1 = count[i];
                    idx1 = i;
                }
            }
            int max2 = -1;
            int idx2 = -1;
            for (int i = 0; i < count.Count; i++)
            {
                if(i == idx1) { continue; }
                if (count[i] > max2)
                {
                    max2 = count[i];
                    idx2 = i;
                }
            }
            int max3 = number[idx1];
            if ((1.0)*max1 < (1.5)*max2)
            {
                int aaa = number[idx1];
                int bbb = number[idx2];
                max3 = aaa;
                if (bbb < aaa) { max3 = bbb; }
                if (max3 <= 25) { max3 = aaa; }
            }
            // max3 - примерная ширина/высота ячеек. надо узнать точную, а также начало и конец сетки.
            int ss = 0;
            int cc = 0;
            for(int i=0; i<number1.Count; i++)
            {
                if ((number1[i] >= max3-5) && (number1[i] <= max3 + 5))
                {
                    ss += number1[i];
                    cc++;
                }
            }
            float width = (float)ss / (float)cc;
            //осталось найти начало и конец сетки
            LineAnalize[block].SeparatorWidth = width;
            int[] tests = new int[5];
            tests[0] = TestStartEnd(block, b, b[0]);
            tests[1] = TestStartEnd(block, b, b[1]);
            tests[2] = TestStartEnd(block, b, b[2]);
            tests[3] = TestStartEnd(block, b, b[3]);
            tests[4] = TestStartEnd(block, b, b[4]);
            int idx3 = -1;
            int mmm = -1;
            for(int i=0; i<5; i++)
            {
                if (tests[i] > mmm)
                {
                    mmm = tests[i];
                    idx3 = i;
                }
            }
            LineAnalize[block].SeparatorStart = b[idx3];
            LineAnalize[block].SeparatorCount = tests[idx3];
            LineAnalize[block].SeparatorEnd = TestEnd(block, b, b[idx3]);
            LineAnalize[block].SeparatorWidth = ((float)(LineAnalize[block].SeparatorEnd - b[idx3])) / ((float)(tests[idx3]));
        }

        /// <summary>
        /// тест на длину сетки
        /// </summary>
        /// <param name="block">блок</param>
        /// <param name="b">массив предполагаемых границ сетки</param>
        /// <param name="v">начальная точка</param>
        /// <returns></returns>
        private int TestStartEnd(int block, int[] b, int v)
        {
            int w = (int)LineAnalize[block].SeparatorWidth;
            int cnt = 0;
            int max = b[b.Length - 1];
            int curr = v;
            while (curr <= max)
            {
                curr = curr + w;
                bool fl = false;
                for (int j = 0; j < b.Length; j++)
                {
                    if ((b[j] >= curr - 5) && (b[j] <= curr + 5))
                    {
                        fl = true;
                        curr = b[j];
                        cnt++;
                        break;
                    }
                }
                if (!fl) { return cnt; }
            }
            return cnt;
        }
        private int TestEnd(int block, int[] b, int v)
        {
            int w = (int)LineAnalize[block].SeparatorWidth;
            int cnt = 0;
            int max = b[b.Length - 1];
            int curr = v;
            while (curr <= max)
            {
                curr = curr + w;
                bool fl = false;
                for (int j = 0; j < b.Length; j++)
                {
                    if ((b[j] >= curr - 5) && (b[j] <= curr + 5))
                    {
                        fl = true;
                        curr = b[j];
                        cnt++;
                        break;
                    }
                }
                if (!fl) { return curr - w; }
            }
            return curr - w;
        }

        /// <summary>
        /// считает количество ненулевых элементов массива
        /// </summary>
        /// <param name="a">массив</param>
        /// <returns>количество</returns>
        private int GetCountNotZero(int[] a)
        {
            int l = a.Length;
            int s = 0;
            for(int i=0; i<l; i++)
            {
                if(a[i] != 0) { s++; }
            }
            return s;
        }

        /// <summary>
        /// считает сумму массива
        /// </summary>
        /// <param name="a">массив</param>
        /// <returns>сумма</returns>
        private int GetSumArray(int[] a)
        {
            int l = a.Length;
            int s = 0;
            for (int i = 0; i < l; i++)
            {
                s += a[i];
            }
            return s;
        }

    }
}
