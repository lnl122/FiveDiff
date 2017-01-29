using System.Collections.Generic;
using System;
using System.Drawing;
using System.IO;

namespace FiveDiff
{
    class ImageDiff
    {
        private const int BmpHeader = 54;
        private Bitmap Bmp;
        private Parts[] Part = new Parts[2];
        private int LineLen;

        private struct Parts
        {
            public Bitmap img;
            public Rectangle rect;
            public byte[] ba;
        }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="b">битмап, в котором нужно найти отличия</param>
        public ImageDiff(Bitmap b)
        {
            Bmp = b;
            CutImage();
            FindShift();
            //byte[] ba2 = test2(b);
            //int[,] la1 = test3(b);

            int iii = 0;
        }
        /*private int[,] test3(Bitmap img)
        {
            byte[] ba;
            using (MemoryStream mStream = new MemoryStream())
            {
                img.Save(mStream, System.Drawing.Imaging.ImageFormat.Bmp);
                // 54 байта - заголовок
                //    temp = width * 3;
                // line = temp + width % 4; // Длина строки с учетом выравнивания
                //System.Drawing.Imaging.ImageFormat.Png
                ba = mStream.ToArray();
            }
            int[,] res = new int[img.Width, img.Height];
            int linelen = img.Width * 3 + img.Width % 4;
            int tl = 0;
            int tc = 0;
            for (int y = 0; y < img.Height; y++)
            {
                tl = y * linelen + 54;
                for (int x = 0; x < img.Width; x++)
                {
                    tc = tl + x;
                    res[x, y] = ((((int)ba[tc]) <<16) + (((int)ba[tc + 1]) <<8) + ((int)ba[tc + 2]));
                }
            }

            return res;
        }*/

        private void FindShift()
        {
            int width = Bmp.Width;
            int heigth = Bmp.Height;
            int width6 = width / 6;
            int heigth6 = heigth / 6;
            int width3 = width6 * 2;
            int heigth3 = heigth6 * 2;
            byte[] sq = GetColorMapRect(0, width3, heigth3, width3, heigth3);
            ulong[,] diffs = new ulong[width3, heigth3];
            for(int j = heigth6; j < heigth6 * 3; j++)
            {
                for (int i = width6; i < width6 * 3; i++)
                {
                    diffs[i-width6, j-heigth6] = GetDifference(sq, GetColorMapRect(1, i, j, width3, heigth3));
                }
            }
            ulong min = 0xffffffff;
            int idxi = 0;
            int idxj = 0;
            for (int j = heigth6; j < heigth6 * 3; j++)
            {
                for (int i = width6; i < width6 * 3; i++)
                {
                    if (min > diffs[i - width6, j - heigth6])
                    {
                        min = diffs[i - width6, j - heigth6];
                        idxi = i;
                        idxj = j;
                    }
                }
            }
            int iii = 0;
        }

        /// <summary>
        /// расчитывает сумму моделей разниц в цветах между двумя массивами. 
        /// </summary>
        /// <param name="a">массив байт 1</param>
        /// <param name="b">массив байт 2</param>
        /// <returns>значение разницы</returns>
        private ulong GetDifference(byte[] a, byte[] b)
        {
            int len = a.Length;
            if(len != b.Length) { return 0xffffffff; }
            ulong res = 0;
            for(int i=0; i<len; i++)
            {
                if (a[i] >= b[i])
                {
                    res += (ulong)(a[i] - b[i]);
                }
                else
                {
                    res += (ulong)(b[i] - a[i]);
                }
            }
            return res;
        }

        /// <summary>
        /// получает маску цветов для прямоугольника. массив байт
        /// </summary>
        /// <param name="p">номер части 0/1</param>
        /// <param name="x">начальная позиция по горизонтали</param>
        /// <param name="y">начальная позиция по вертикали</param>
        /// <param name="w">ширина</param>
        /// <param name="h">высота</жparam>
        /// <returns>массив байт - цвета прямоугольника</returns>
        private byte[] GetColorMapRect(int p, int x, int y, int w, int h)
        {
            byte[] res = new byte[3 * (w + 1) * (h + 1)];
            int y2 = y + h;
            int x2 = x + w;
            int pos = 0;
            for (int yy = y; yy < y2; yy++)
            {
                for (int xx = x; xx < x2; xx++)
                {
                    int idx = GetIndexByXY(xx, yy);
                    res[pos] = Part[p].ba[idx];
                    res[pos+1] = Part[p].ba[idx+1];
                    res[pos+2] = Part[p].ba[idx+2];
                    pos += 3;
                }
            }
            return res;
        }

        /// <summary>
        /// получает индекс в массиве байт для координат
        /// </summary>
        /// <param name="x">координата пикселя слева-направо</param>
        /// <param name="y">координата пикселя сверху-вниз</param>
        /// <returns>положение в массиве</returns>
        private int GetIndexByXY(int x, int y)
        {
            return BmpHeader + y*LineLen + x*3;
        }

        /// <summary>
        /// из битмапа делает массив байт - представление bmp
        /// </summary>
        /// <param name="img">битмап</param>
        /// <returns>массив байт</returns>
        private byte[] BitmapToByteArray(Bitmap img)
        {
            // 54 байта - заголовок
            // line = width * 3 + width % 4; /* Длина строки с учетом выравнивания */
            MemoryStream mStream = new MemoryStream();
            img.Save(mStream, System.Drawing.Imaging.ImageFormat.Bmp);
            return mStream.ToArray();
        }

        /// <summary>
        /// разрезает картину на две части согласно найденных прямоугольников
        /// </summary>
        private void CutImage()
        {
            int width = Bmp.Width;
            int height = Bmp.Height;
            // определим метод разрезания (верт/гор), определим прямоугольники
            if (width >= height)
            {
                int t = (int)(width / 2) - 1;
                Part[0].rect = new Rectangle(0, 0, t, height);
                Part[1].rect = new Rectangle(t, 0, t, height);
            }
            else
            {
                int t = (int)(height / 2) - 1;
                Part[0].rect = new Rectangle(0, 0, width, t);
                Part[1].rect = new Rectangle(0, t, width, t);
            }
            // разражем картинку
            Part[0].img = Bmp.Clone(Part[0].rect, Bmp.PixelFormat);
            Part[1].img = Bmp.Clone(Part[1].rect, Bmp.PixelFormat);
            // переведем в массив байт
            Part[0].ba = BitmapToByteArray(Part[0].img);
            Part[1].ba = BitmapToByteArray(Part[1].img);
            // найдем длину линии в BMP
            LineLen = Part[0].img.Width * 3 + Part[0].img.Width % 4;
        }


        /*
        public const int vertical = 1;
        public const int horizontal = 2;

        public Bitmap ResultBmp;
        private int method = 0;


        bool error = false;
        private int shift_lr = 0;
        private int shift_ud = 0;

        public List<int> diff_found;
        public List<int> diff_found2;

        private long[] Diffs_3b;
        private long[] Diffs_6b;
        private long[] Diffs_9b;
        private long[] Diffs_12b;

        private long[] Diffs_4_3b;
        private long[] Diffs_4_6b;
        private long[] Diffs_4_9b;
        private long[] Diffs_4m_3b;
        private long[] Diffs_4m_6b;
        private long[] Diffs_4m_9b;

        private long[] Diffs_9_3b;
        private long[] Diffs_9_6b;
        private long[] Diffs_9_9b;
        private long[] Diffs_9m_3b;
        private long[] Diffs_9m_6b;
        private long[] Diffs_9m_9b;

        private long[] Diffs_16_3b;
        private long[] Diffs_16_6b;
        private long[] Diffs_16_9b;
        private long[] Diffs_16m_3b;
        private long[] Diffs_16m_6b;
        private long[] Diffs_16m_9b;

        private Lines[] LineAnalize;
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

        public struct kv
        {
            public Bitmap b;
            public int num;
            public int h_num;
            public int v_num;
            public int[] color_map1_8;
            public int[] color_map1_64;
            public int[] color_map1_512;
            public int[] color_map1_4096;
            public int[] color_map4_1_8;
            public int[] color_map4_2_8;
            public int[] color_map4_3_8;
            public int[] color_map4_4_8;
            public int[] color_map4_1_64;
            public int[] color_map4_2_64;
            public int[] color_map4_3_64;
            public int[] color_map4_4_64;
            public int[] color_map4_1_512;
            public int[] color_map4_2_512;
            public int[] color_map4_3_512;
            public int[] color_map4_4_512;
            public int[,] color_map9_8;
            public int[,] color_map9_64;
            public int[,] color_map9_512;
            public int[,] color_map16_8;
            public int[,] color_map16_64;
            public int[,] color_map16_512;
        }
        public kv[] p1kv;
        public kv[] p2kv;





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
            ResultBmp = b;
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
                // собираем сведения о квадратиках
                p1kv = FillKV(Part1, 1,
                                    LineAnalize[0].SeparatorStart, LineAnalize[1].SeparatorStart, LineAnalize[0].SeparatorEnd, LineAnalize[1].SeparatorEnd,
                                    LineAnalize[0].SeparatorCount, LineAnalize[1].SeparatorCount);
                p2kv = FillKV(Part2, 2,
                                    LineAnalize[2].SeparatorStart, LineAnalize[3].SeparatorStart, LineAnalize[2].SeparatorEnd, LineAnalize[3].SeparatorEnd,
                                    LineAnalize[2].SeparatorCount, LineAnalize[3].SeparatorCount);

                // выравниваем саму таблицу с картинкой (убираем из видимости буквы/цифры)
                //
                FindShift();

                // ищем несоответствия
                //
                GetDiffs();
                Calculate();

                ResultBmp = bmp;
                DrawNewBmp();

            }
            else
            {
                ResultBmp = null;
            }

        }

        private void DrawNewBmp()
        {
            // тут нужно отрисовать новый битмап.
            int p1_left = LineAnalize[0].SeparatorStart + rPart1.Left;
            int p1_width = LineAnalize[0].SeparatorEnd - LineAnalize[0].SeparatorStart-1;
            int p1_top = LineAnalize[1].SeparatorStart + rPart1.Top;
            int p1_height = LineAnalize[1].SeparatorEnd - LineAnalize[1].SeparatorStart-1;
            int p2_left = LineAnalize[2].SeparatorStart + rPart2.Left;
            int p2_width = LineAnalize[2].SeparatorEnd - LineAnalize[2].SeparatorStart-1;
            int p2_top = LineAnalize[3].SeparatorStart + rPart2.Top;
            int p2_height = LineAnalize[3].SeparatorEnd - LineAnalize[3].SeparatorStart-1;

            Color cc = Color.Blue;

            DrawRectangle3(p1_left, p1_top, p1_width, p1_height, cc);
            DrawRectangle3(p2_left, p2_top, p2_width, p2_height, cc);

            int cnt_w = LineAnalize[0].SeparatorCount-1;
            int cnt_h = LineAnalize[1].SeparatorCount-1;
            float w = LineAnalize[0].SeparatorWidth;
            float h = LineAnalize[1].SeparatorWidth;

            cc = Color.Red;
            DrawSq(diff_found, LineAnalize[0].SeparatorStart, LineAnalize[1].SeparatorStart, LineAnalize[0].SeparatorEnd, LineAnalize[1].SeparatorEnd, LineAnalize[0].SeparatorCount, LineAnalize[1].SeparatorCount, cc);
            cc = Color.Yellow;
            DrawSq(diff_found2, LineAnalize[0].SeparatorStart, LineAnalize[1].SeparatorStart, LineAnalize[0].SeparatorEnd, LineAnalize[1].SeparatorEnd, LineAnalize[0].SeparatorCount, LineAnalize[1].SeparatorCount, cc);
            //private kv[] FillKV(Bitmap bb, int p, int w_start, int h_start, int w_end, int h_end, int w_cnt, int h_cnt)

        }
        private void DrawSq(List<int> df, int w_start, int h_start, int w_end, int h_end, int w_cnt, int h_cnt, Color cc)
        {
            int count = w_cnt * h_cnt;
            float w = (float)((float)(w_end - w_start) / (float)w_cnt);
            float h = (float)((float)(h_end - h_start) / (float)h_cnt);
            for (int i = 0; i < w_cnt; i++)
            {
                for (int j = 0; j < h_cnt; j++)
                {
                    int i2 = i + shift_lr;
                    int j2 = j + shift_ud;
                    int num2 = i2 * h_cnt + j2;

                    int num = i * h_cnt + j;
                    int l = w_start + (int)(i * w);
                    int r = l + (int)(w);
                    int t = h_start + (int)(j * h);
                    int b = t + (int)(h);

                    int l2 = rPart2.Left + LineAnalize[2].SeparatorStart + (int)(i2 * w);
                    int t2 = rPart2.Top + LineAnalize[3].SeparatorStart + (int)(j2 * h);

                    if (df.Contains(num))
                    {
                        DrawRectangle3(l + 1, t + 1, (int)(w) - 1, (int)(h) - 1, cc);
                        DrawRectangle3(l2 + 1, t2 + 1, (int)(w) - 1, (int)(h) - 1, cc);
                    }
                }
            }
        }

        private void DrawRectangle3(int left, int top, int width, int height, Color c)
        {
            DrawRectangle(left, top, width, height, c);
            DrawRectangle(left+1, top+1, width-2, height-2, c);
            DrawRectangle(left+2, top+2, width-4, height-4, c);
        }
        private void DrawRectangle(int left, int top, int width, int height, Color c)
        {
            for (int i = left; i < left + width; i++)
            {
                ResultBmp.SetPixel(i, top, c);
                ResultBmp.SetPixel(i, top + height, c);
            }
            for (int i = top; i < top + height; i++)
            {
                ResultBmp.SetPixel(left, i, c);
                ResultBmp.SetPixel(left + width, i, c);
            }
        }

        /// <summary>
        /// нахождение индексов выявленных квадратов
        /// </summary>
        private void Calculate()
        {
            List<int> res = new List<int>();
            res.AddRange(GetFiveTopIndexes(Diffs_4m_3b));
            res.AddRange(GetFiveTopIndexes(Diffs_4m_6b));
            res.AddRange(GetFiveTopIndexes(Diffs_4m_9b));
            res.AddRange(GetFiveTopIndexes(Diffs_9m_3b));
            res.AddRange(GetFiveTopIndexes(Diffs_9m_6b));
            res.AddRange(GetFiveTopIndexes(Diffs_9m_9b));
            res.AddRange(GetFiveTopIndexes(Diffs_16m_3b));
            res.AddRange(GetFiveTopIndexes(Diffs_16m_6b));
            res.AddRange(GetFiveTopIndexes(Diffs_16m_9b));
            // в res - перечень всех найденных индексов, с их дубликатами - надо их пересчитать

            List<int> num = new List<int>();
            List<int> cnt = new List<int>();
            for(int i=0; i<res.Count; i++)
            {
                int found = -1;
                int idx = res[i];
                for (int j = 0; j < num.Count; j++)
                {
                    if (num[j] == idx)
                    {
                        found = j;
                    }
                }
                if (found != -1)
                {
                    cnt[found] = cnt[found] + 1;
                }
                else
                {
                    num.Add(idx);
                    cnt.Add(1);
                }
            }
            List<int> l_6_9 = GetFiveTopIndexes(Diffs_9_6b);
            List<int> l_9_9 = GetFiveTopIndexes(Diffs_9_9b);
            List<int> l_6_16 = GetFiveTopIndexes(Diffs_16_6b);
            List<int> l_9_16 = GetFiveTopIndexes(Diffs_16_9b);
            for(int i=0; i<num.Count; i++)
            {
                if (l_6_9.Contains(num[i])) { cnt[i] = cnt[i] + 1; }
                if (l_9_9.Contains(num[i])) { cnt[i] = cnt[i] + 1; }
                if (l_6_16.Contains(num[i])) { cnt[i] = cnt[i] + 1; }
                if (l_9_16.Contains(num[i])) { cnt[i] = cnt[i] + 1; }
            }

            // теперь надо отсортировать num/cnt
            // и удалить те, где cnt=1
            int all = 0;
            foreach(int cc in cnt)
            {
                if(cc > 1) { all++; }
            }
            int[,] res2 = new int[all, 2];
            int iid = 0;
            for (int i = 0; i < num.Count; i++)
            {
                if(cnt[i] > 1)
                {
                    res2[iid, 0] = num[i];
                    res2[iid, 1] = cnt[i];
                    iid++;
                }
            }
            // в res2 - двумерный массив с найденными вариантами. топ-5 - решение, остальные - кандидаты
            List<int> top5 = new List<int>();
            while (top5.Count < 5)
            {
                if (SumCnt(res2, all) == 0) { break; }
                int max = 0;
                for (int i = 0; i < all; i++)
                {
                    if (res2[i, 1] > max)
                    {
                        max = res2[i, 1];
                    }
                }
                for (int i = 0; i < all; i++)
                {
                    if (res2[i, 1] == max)
                    {
                        res2[i, 1] = 0;
                        top5.Add(res2[i, 0]);
                    }
                }
            }
            List<int> top99 = new List<int>();
            for (int i = 0; i < all; i++)
            {
                if (!top5.Contains(res2[i, 0]))
                {
                    top99.Add(res2[i, 0]);
                }
            }
            diff_found = top5;
            diff_found2 = top99;
        }

        /// <summary>
        /// сумма чисел из двумерного массива, по второму индексу
        /// </summary>
        /// <param name="arr2">массив</param>
        /// <param name="size">размер длины массива</param>
        /// <returns>сумма колонки 1</returns>
        private int SumCnt(int[,] arr2, int size)
        {
            int res = 0;
            for(int i=0; i<size; i++)
            {
                res = res + arr2[i, 1];
            }
            return res;
        }

        /// <summary>
        /// получить топ-5 наибольших индексов из массива
        /// </summary>
        /// <param name="arr2">массив</param>
        /// <returns>список чисел</returns>
        private List<int> GetFiveTopIndexes(long[] arr2)
        {
            long[] arr = arr2;
            List<int> res = new List<int>();
            while (res.Count < 5)
            {
                long max = GetMaxArr(arr);
                int l = arr.Length;
                for (int i = 0; i < l; i++)
                {
                    if (arr[i] == max)
                    {
                        arr[i] = 0;
                        res.Add(i);
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// найти максимум в массиве
        /// </summary>
        /// <param name="arr">массив</param>
        /// <returns>максимальное значение</returns>
        private long GetMaxArr(long[] arr)
        {
            int l = arr.Length;
            long res = 0;
            for(int i=0; i<l; i++)
            {
                if(res < arr[i]) { res = arr[i]; }
            }
            return res;
        }

        /// <summary>
        /// ищет отличия, заполняет Diffs
        /// </summary>
        private void GetDiffs()
        {
            int cnt_w = LineAnalize[0].SeparatorCount;
            int cnt_h = LineAnalize[1].SeparatorCount;
            Diffs_3b = new long[cnt_w * cnt_h];
            Diffs_6b = new long[cnt_w * cnt_h];
            Diffs_9b = new long[cnt_w * cnt_h];
            Diffs_12b = new long[cnt_w * cnt_h];
            Diffs_4_3b = new long[cnt_w * cnt_h];
            Diffs_4_6b = new long[cnt_w * cnt_h];
            Diffs_4_9b = new long[cnt_w * cnt_h];
            Diffs_4m_3b = new long[cnt_w * cnt_h];
            Diffs_4m_6b = new long[cnt_w * cnt_h];
            Diffs_4m_9b = new long[cnt_w * cnt_h];
            Diffs_9_3b = new long[cnt_w * cnt_h];
            Diffs_9_6b = new long[cnt_w * cnt_h];
            Diffs_9_9b = new long[cnt_w * cnt_h];
            Diffs_9m_3b = new long[cnt_w * cnt_h];
            Diffs_9m_6b = new long[cnt_w * cnt_h];
            Diffs_9m_9b = new long[cnt_w * cnt_h];
            Diffs_16_3b = new long[cnt_w * cnt_h];
            Diffs_16_6b = new long[cnt_w * cnt_h];
            Diffs_16_9b = new long[cnt_w * cnt_h];
            Diffs_16m_3b = new long[cnt_w * cnt_h];
            Diffs_16m_6b = new long[cnt_w * cnt_h];
            Diffs_16m_9b = new long[cnt_w * cnt_h];
            for (int i = 0; i < cnt_w; i++)
            {
                for (int j = 0; j < cnt_h; j++)
                {
                    int i2 = i + shift_lr;
                    int j2 = j + shift_ud;
                    int num = i * cnt_h + j;
                    int num2 = i2 * cnt_h + j2;
                    Diffs_3b[num] = 0;
                    Diffs_6b[num] = 0;
                    Diffs_9b[num] = 0;
                    Diffs_12b[num] = 0;
                    Diffs_4_3b[num] = 0;
                    Diffs_4_6b[num] = 0;
                    Diffs_4_9b[num] = 0;
                    Diffs_4m_3b[num] = 0;
                    Diffs_4m_6b[num] = 0;
                    Diffs_4m_9b[num] = 0;
                    Diffs_9_3b[num] = 0;
                    Diffs_9_6b[num] = 0;
                    Diffs_9_9b[num] = 0;
                    Diffs_9m_3b[num] = 0;
                    Diffs_9m_6b[num] = 0;
                    Diffs_9m_9b[num] = 0;
                    Diffs_16_3b[num] = 0;
                    Diffs_16_6b[num] = 0;
                    Diffs_16_9b[num] = 0;
                    Diffs_16m_3b[num] = 0;
                    Diffs_16m_6b[num] = 0;
                    Diffs_16m_9b[num] = 0;
                    if ((i2 >= 0) && (i2 < cnt_w) && (j2 >= 0) && (j2 < cnt_h))
                    {
                        Diffs_3b[num] = CopmareKv8_(num, num2);
                        Diffs_6b[num] = CopmareKv64_(num, num2);
                        Diffs_9b[num] = CopmareKv512_(num, num2);
                        Diffs_12b[num] = CopmareKv4096_(num, num2);
                        Diffs_4_3b[num] = CopmareKv8_4_(num, num2);
                        Diffs_4_6b[num] = CopmareKv64_4_(num, num2);
                        Diffs_4_9b[num] = CopmareKv512_4_(num, num2);
                        Diffs_4m_3b[num] = CopmareKv8_4m_(num, num2);
                        Diffs_4m_6b[num] = CopmareKv64_4m_(num, num2);
                        Diffs_4m_9b[num] = CopmareKv512_4m_(num, num2);

                        Diffs_9_3b[num] = CopmareKv_(p1kv[num].color_map9_8, p2kv[num2].color_map9_8, 8, 9);
                        Diffs_9_6b[num] = CopmareKv_(p1kv[num].color_map9_64, p2kv[num2].color_map9_64, 64, 9);
                        Diffs_9_9b[num] = CopmareKv_(p1kv[num].color_map9_512, p2kv[num2].color_map9_512, 512, 9);
                        Diffs_9m_3b[num] = CopmareKv_m_(p1kv[num].color_map9_8, p2kv[num2].color_map9_8, 8, 9);
                        Diffs_9m_6b[num] = CopmareKv_m_(p1kv[num].color_map9_64, p2kv[num2].color_map9_64, 64, 9);
                        Diffs_9m_9b[num] = CopmareKv_m_(p1kv[num].color_map9_512, p2kv[num2].color_map9_512, 512, 9);

                        Diffs_16_3b[num] = CopmareKv_(p1kv[num].color_map16_8, p2kv[num2].color_map16_8, 8, 16);
                        Diffs_16_6b[num] = CopmareKv_(p1kv[num].color_map16_64, p2kv[num2].color_map16_64, 64, 16);
                        Diffs_16_9b[num] = CopmareKv_(p1kv[num].color_map16_512, p2kv[num2].color_map16_512, 512, 16);
                        Diffs_16m_3b[num] = CopmareKv_m_(p1kv[num].color_map16_8, p2kv[num2].color_map16_8, 8, 16);
                        Diffs_16m_6b[num] = CopmareKv_m_(p1kv[num].color_map16_64, p2kv[num2].color_map16_64, 64, 16);
                        Diffs_16m_9b[num] = CopmareKv_m_(p1kv[num].color_map16_512, p2kv[num2].color_map16_512, 512, 16);
                    }
                }
            }
        }

        /// <summary>
        /// сравнивалка
        /// </summary>
        /// <param name="a1">1й массив со значениями цветов мелких квадратиков</param>
        /// <param name="a2">2й массив</param>
        /// <param name="lines">колво цветов</param>
        /// <param name="squares">колво квадратиков</param>
        /// <returns>сумма</returns>
        private long CopmareKv_(int[,] a1, int[,] a2, int lines, int squares)
        {
            long res = 0;

            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < squares; j++)
                {
                    res += Math.Abs(a1[i,j] - a2[i,j]);
                }
            }

            return res;
        }
        /// <summary>
        /// сравнивалка и находился максимального отличия в мелких квадратиках
        /// </summary>
        /// <param name="a1">1й массив со значениями цветов мелких квадратиков</param>
        /// <param name="a2">2й массив</param>
        /// <param name="lines">колво цветов</param>
        /// <param name="squares">колво квадратиков</param>
        /// <returns>максимальная сумма</returns>
        private long CopmareKv_m_(int[,] a1, int[,] a2, int lines, int squares)
        {
            long res = 0;
            long[] resa = new long[squares];
            for (int i = 0; i < squares; i++)
            {
                res = 0;
                for (int j = 0; j < lines; j++)
                {
                    res += Math.Abs(a1[j, i] - a2[j, i]);
                }
                resa[i] = res;
            }
            long mm = 0;
            for (int i = 0; i < squares; i++)
            {
                if(mm < resa[i]) { mm = resa[i]; }
            }
            return mm;
        }

        /// <summary>
        /// находим для 9 сдвигов тот, где меньше ошибок по цветам, результат в shift_lr/shift_ud
        /// </summary>
        private void FindShift()
        {
            long[,] sh_errs = new long[3, 3];
            for(int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    sh_errs[i + 1, j + 1] = FindErrOneShift(i, j);
                }
            }
            long min = sh_errs[0, 0];
            int idx_i = 0;
            int idx_j = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if(sh_errs[i + 1, j + 1] < min)
                    {
                        min = sh_errs[i + 1, j + 1];
                        idx_i = i;
                        idx_j = j;
                    }
                }
            }
            shift_lr = idx_i;
            shift_ud = idx_j;
        }

        /// <summary>
        /// находим количество ошибок для одного сдвига
        /// </summary>
        /// <param name="sh_w">сдвиг лев/прав</param>
        /// <param name="sh_h">сдвиг верх/низ</param>
        /// <returns>кол-во ошибок</returns>
        private long FindErrOneShift(int sh_w, int sh_h)
        {
            long res = 0;
            int cnt_w = LineAnalize[0].SeparatorCount;
            int cnt_h = LineAnalize[1].SeparatorCount;
            long[] errs = new long[cnt_w * cnt_h];
            for(int i = 0; i < cnt_w; i++)
            {
                for (int j = 0; j < cnt_h; j++)
                {
                    int i2 = i + sh_w;
                    int j2 = j + sh_h;
                    int num = i * cnt_h + j;
                    int num2 = i2 * cnt_h + j2;
                    errs[num] = -1;
                    if ((i2>=0) && (i2<cnt_w) && (j2>=0) && (j2<cnt_h))
                    {
                        errs[num] = CopmareKv8(num, num2);
                        res += errs[num];
                    }
                }
            }

            return res;
        }

        /// <summary>
        /// сравниваем цвета квадратов по 3 битам
        /// </summary>
        /// <param name="num">номер квадрата из первой части</param>
        /// <param name="num2">номер квадрата из второй части</param>
        /// <returns>разница цветов</returns>
        private long CopmareKv8(int num, int num2)
        {
            long res = 0;
            int[] a1 = p1kv[num].color_map1_8;
            int[] a2 = p2kv[num2].color_map1_8;
            for (int i = 0; i < 8; i++)
            {
                res += Math.Abs(a1[i] - a2[i]);
            }

            return res;
        }
        /// <summary>
        /// сравниваем цвета квадратов по 6 битам
        /// </summary>
        /// <param name="num">номер квадрата из первой части</param>
        /// <param name="num2">номер квадрата из второй части</param>
        /// <returns>разница цветов</returns>
        private long CopmareKv64(int num, int num2)
        {
            long res = 0;
            int[] a1 = p1kv[num].color_map1_64;
            int[] a2 = p2kv[num2].color_map1_64;
            for (int i = 0; i < 64; i++)
            {
                res += Math.Abs(a1[i] - a2[i]);
            }

            return res;
        }

        /// <summary>
        /// сравниваем цвета квадратов по 3 битам
        /// </summary>
        /// <param name="num">номер квадрата из первой части</param>
        /// <param name="num2">номер квадрата из второй части</param>
        /// <returns>разница цветов</returns>
        private long CopmareKv8_(int num, int num2)
        {
            long res = 0;
            int[] a1 = p1kv[num].color_map1_8;
            int[] a2 = p2kv[num2].color_map1_8;
            for (int i = 0; i < 8; i++)
            {
                res += Math.Abs(a1[i] - a2[i]);
            }

            return res;
        }
        /// <summary>
        /// сравниваем цвета квадратов по 6 битам
        /// </summary>
        /// <param name="num">номер квадрата из первой части</param>
        /// <param name="num2">номер квадрата из второй части</param>
        /// <returns>разница цветов</returns>
        private long CopmareKv64_(int num, int num2)
        {
            long res = 0;
            int[] a1 = p1kv[num].color_map1_64;
            int[] a2 = p2kv[num2].color_map1_64;
            for (int i = 0; i < 64; i++)
            {
                res += Math.Abs(a1[i] - a2[i]);
            }

            return res;
        }
        /// <summary>
        /// сравниваем цвета квадратов по 9 битам
        /// </summary>
        /// <param name="num">номер квадрата из первой части</param>
        /// <param name="num2">номер квадрата из второй части</param>
        /// <returns>разница цветов</returns>
        private long CopmareKv512_(int num, int num2)
        {
            long res = 0;
            int[] a1 = p1kv[num].color_map1_512;
            int[] a2 = p2kv[num2].color_map1_512;
            for (int i = 0; i < 512; i++)
            {
                //int q = Math.Abs(a1[i] - a2[i]);
                //if ((a1[i] * 0.9 > a2[i]) || (a1[i] * 1.1 < a2[i])) {
                res += Math.Abs(a1[i] - a2[i]);
                //res++;
                //}
            }

            return res;
        } 
        /// <summary>
        /// сравниваем цвета квадратов по 12 битам
        /// </summary>
        /// <param name="num">номер квадрата из первой части</param>
        /// <param name="num2">номер квадрата из второй части</param>
        /// <returns>разница цветов</returns>
        private long CopmareKv4096_(int num, int num2)
        {
            long res = 0;
            int[] a1 = p1kv[num].color_map1_4096;
            int[] a2 = p2kv[num2].color_map1_4096;
            for (int i = 0; i < 4096; i++)
            {
                //int q = Math.Abs(a1[i] - a2[i]);
                //if ((a1[i] * 0.9 > a2[i]) || (a1[i] * 1.1 < a2[i])) {
                res += Math.Abs(a1[i] - a2[i]);
                //res++;
                //}
            }

            return res;
        }

        /// <summary>
        /// сравниваем цвета квадратов из мелких 4-х частичек по 3 битам
        /// </summary>
        /// <param name="num">номер квадрата из первой части</param>
        /// <param name="num2">номер квадрата из второй части</param>
        /// <returns>разница цветов</returns>
        private long CopmareKv8_4_(int num, int num2)
        {
            long res = 0;
            int[] a1 = p1kv[num].color_map4_1_8;
            int[] a2 = p2kv[num2].color_map4_1_8;
            for (int i = 0; i < 8; i++)
            {
                res += Math.Abs(a1[i] - a2[i]);
            }
            a1 = p1kv[num].color_map4_2_8;
            a2 = p2kv[num2].color_map4_2_8;
            for (int i = 0; i < 8; i++)
            {
                res += Math.Abs(a1[i] - a2[i]);
            }
            a1 = p1kv[num].color_map4_3_8;
            a2 = p2kv[num2].color_map4_3_8;
            for (int i = 0; i < 8; i++)
            {
                res += Math.Abs(a1[i] - a2[i]);
            }
            a1 = p1kv[num].color_map4_4_8;
            a2 = p2kv[num2].color_map4_4_8;
            for (int i = 0; i < 8; i++)
            {
                res += Math.Abs(a1[i] - a2[i]);
            }
            return res;
        }
        /// <summary>
        /// сравниваем цвета квадратов из мелких 4-х частичек по 6 битам
        /// </summary>
        /// <param name="num">номер квадрата из первой части</param>
        /// <param name="num2">номер квадрата из второй части</param>
        /// <returns>разница цветов</returns>
        private long CopmareKv64_4_(int num, int num2)
        {
            long res = 0;
            int[] a1 = p1kv[num].color_map4_1_64;
            int[] a2 = p2kv[num2].color_map4_1_64;
            for (int i = 0; i < 64; i++)
            {
                res += Math.Abs(a1[i] - a2[i]);
            }
            a1 = p1kv[num].color_map4_2_64;
            a2 = p2kv[num2].color_map4_2_64;
            for (int i = 0; i < 64; i++)
            {
                res += Math.Abs(a1[i] - a2[i]);
            }
            a1 = p1kv[num].color_map4_3_64;
            a2 = p2kv[num2].color_map4_3_64;
            for (int i = 0; i < 64; i++)
            {
                res += Math.Abs(a1[i] - a2[i]);
            }
            a1 = p1kv[num].color_map4_4_64;
            a2 = p2kv[num2].color_map4_4_64;
            for (int i = 0; i < 64; i++)
            {
                res += Math.Abs(a1[i] - a2[i]);
            }
            return res;
        }
        /// <summary>
        /// сравниваем цвета квадратов из мелких 4-х частичек по 9 битам
        /// </summary>
        /// <param name="num">номер квадрата из первой части</param>
        /// <param name="num2">номер квадрата из второй части</param>
        /// <returns>разница цветов</returns>
        private long CopmareKv512_4_(int num, int num2)
        {
            long res = 0;
            int[] a1 = p1kv[num].color_map4_1_512;
            int[] a2 = p2kv[num2].color_map4_1_512;
            for (int i = 0; i < 512; i++)
            {
                res += Math.Abs(a1[i] - a2[i]);
            }
            a1 = p1kv[num].color_map4_2_512;
            a2 = p2kv[num2].color_map4_2_512;
            for (int i = 0; i < 512; i++)
            {
                res += Math.Abs(a1[i] - a2[i]);
            }
            a1 = p1kv[num].color_map4_3_512;
            a2 = p2kv[num2].color_map4_3_512;
            for (int i = 0; i < 512; i++)
            {
                res += Math.Abs(a1[i] - a2[i]);
            }
            a1 = p1kv[num].color_map4_4_512;
            a2 = p2kv[num2].color_map4_4_512;
            for (int i = 0; i < 512; i++)
            {
                res += Math.Abs(a1[i] - a2[i]);
            }
            return res;
        }
        /// <summary>
        /// сравниваем цвета квадратов из мелких 4-х частичек по 3 битам
        /// </summary>
        /// <param name="num">номер квадрата из первой части</param>
        /// <param name="num2">номер квадрата из второй части</param>
        /// <returns>разница цветов</returns>
        private long CopmareKv8_4m_(int num, int num2)
        {
            long res1 = 0;
            long res2 = 0;
            long res3 = 0;
            long res4 = 0;
            int[] a1 = p1kv[num].color_map4_1_8;
            int[] a2 = p2kv[num2].color_map4_1_8;
            for (int i = 0; i < 8; i++)
            {
                res1 += Math.Abs(a1[i] - a2[i]);
            }
            a1 = p1kv[num].color_map4_2_8;
            a2 = p2kv[num2].color_map4_2_8;
            for (int i = 0; i < 8; i++)
            {
                res2 += Math.Abs(a1[i] - a2[i]);
            }
            a1 = p1kv[num].color_map4_3_8;
            a2 = p2kv[num2].color_map4_3_8;
            for (int i = 0; i < 8; i++)
            {
                res3 += Math.Abs(a1[i] - a2[i]);
            }
            a1 = p1kv[num].color_map4_4_8;
            a2 = p2kv[num2].color_map4_4_8;
            for (int i = 0; i < 8; i++)
            {
                res4 += Math.Abs(a1[i] - a2[i]);
            }

            return Math.Max(Math.Max(res1,res2), Math.Max(res3,res4));
        }
        /// <summary>
        /// сравниваем цвета квадратов из мелких 4-х частичек по 6 битам
        /// </summary>
        /// <param name="num">номер квадрата из первой части</param>
        /// <param name="num2">номер квадрата из второй части</param>
        /// <returns>разница цветов</returns>
        private long CopmareKv64_4m_(int num, int num2)
        {
            long res1 = 0;
            long res2 = 0;
            long res3 = 0;
            long res4 = 0;
            int[] a1 = p1kv[num].color_map4_1_64;
            int[] a2 = p2kv[num2].color_map4_1_64;
            for (int i = 0; i < 64; i++)
            {
                res1 += Math.Abs(a1[i] - a2[i]);
            }
            a1 = p1kv[num].color_map4_2_64;
            a2 = p2kv[num2].color_map4_2_64;
            for (int i = 0; i < 64; i++)
            {
                res2 += Math.Abs(a1[i] - a2[i]);
            }
            a1 = p1kv[num].color_map4_3_64;
            a2 = p2kv[num2].color_map4_3_64;
            for (int i = 0; i < 64; i++)
            {
                res3 += Math.Abs(a1[i] - a2[i]);
            }
            a1 = p1kv[num].color_map4_4_64;
            a2 = p2kv[num2].color_map4_4_64;
            for (int i = 0; i < 64; i++)
            {
                res4 += Math.Abs(a1[i] - a2[i]);
            }
            return Math.Max(Math.Max(res1, res2), Math.Max(res3, res4));
        }
        /// <summary>
        /// сравниваем цвета квадратов из мелких 4-х частичек по 9 битам
        /// </summary>
        /// <param name="num">номер квадрата из первой части</param>
        /// <param name="num2">номер квадрата из второй части</param>
        /// <returns>разница цветов</returns>
        private long CopmareKv512_4m_(int num, int num2)
        {
            long res1 = 0;
            long res2 = 0;
            long res3 = 0;
            long res4 = 0;
            int[] a1 = p1kv[num].color_map4_1_512;
            int[] a2 = p2kv[num2].color_map4_1_512;
            for (int i = 0; i < 512; i++)
            {
                res1 += Math.Abs(a1[i] - a2[i]);
            }
            a1 = p1kv[num].color_map4_2_512;
            a2 = p2kv[num2].color_map4_2_512;
            for (int i = 0; i < 512; i++)
            {
                res2 += Math.Abs(a1[i] - a2[i]);
            }
            a1 = p1kv[num].color_map4_3_512;
            a2 = p2kv[num2].color_map4_3_512;
            for (int i = 0; i < 512; i++)
            {
                res3 += Math.Abs(a1[i] - a2[i]);
            }
            a1 = p1kv[num].color_map4_4_512;
            a2 = p2kv[num2].color_map4_4_512;
            for (int i = 0; i < 512; i++)
            {
                res4 += Math.Abs(a1[i] - a2[i]);
            }
            return Math.Max(Math.Max(res1, res2), Math.Max(res3, res4));
        }

        /// <summary>
        /// заполняет структуры по всем мелким квадратикам на одной большой части
        /// </summary>
        /// <param name="bb">часть картинки (лев/прав), битмап</param>
        /// <param name="w_start">начало сетки по горизонтали</param>
        /// <param name="h_start">начало сетки по вертикали</param>
        /// <param name="w_end">конец сетки по горизонтали</param>
        /// <param name="h_end">конец сетки по вертикали</param>
        /// <param name="w_cnt">количество колонок слева направо</param>
        /// <param name="h_cnt">количество колонок сверху вниз</param>
        /// <returns>массив структур квадратиков</returns>
        private kv[] FillKV(Bitmap bb, int p, int w_start, int h_start, int w_end, int h_end, int w_cnt, int h_cnt)
        {
            int count = w_cnt * h_cnt;
            float w = (float)((float)(w_end - w_start) / (float)w_cnt);
            float h = (float)((float)(h_end - h_start) / (float)h_cnt);
            kv[] res = new kv[count];
            for(int i = 0; i < w_cnt; i++)
            {
                for (int j = 0; j < h_cnt; j++)
                {
                    int num = i * h_cnt + j;
                    int l = w_start + (int)(i * w);
                    int r = l + (int)(w);
                    int t = h_start + (int)(j * h);
                    int b = t + (int)(h);
                    res[num] = FillOneKV(bb, p, num, l, t, (int)w, (int)h);
                    res[num].num = num;
                    res[num].h_num = i;
                    res[num].v_num = j;
                }
            }
            return res;
        }

        /// <summary>
        /// заполняет структуру данных по одному квадратику
        /// </summary>
        /// <param name="b">общий битмап одной части картинки</param>
        /// <param name="num">номер квадратика</param>
        /// <param name="left">левая граниа</param>
        /// <param name="top">верхняя граница</param>
        /// <param name="width">ширина</param>
        /// <param name="height">высота</param>
        /// <returns>структуру одного квадратика</returns>
        private kv FillOneKV(Bitmap b, int p, int num, int left, int top, int width, int height)
        {
            kv res = new kv();
            int left2 = left + 2;
            int top2 = top + 2;
            int width2 = width - 3;
            int height2 = height - 3;
            Rectangle rect = new Rectangle(left2, top2, width2, height2);
            res.b = new Bitmap(width2, height2);
            res.b = b.Clone(rect, b.PixelFormat);
            res.color_map1_8 = new int[8];
            res.color_map1_64 = new int[64];
            res.color_map1_512 = new int[512];
            res.color_map1_4096 = new int[4096];
            res.color_map4_1_8 = new int[8];
            res.color_map4_2_8 = new int[8];
            res.color_map4_3_8 = new int[8];
            res.color_map4_4_8 = new int[8];
            res.color_map4_1_64 = new int[64];
            res.color_map4_2_64 = new int[64];
            res.color_map4_3_64 = new int[64];
            res.color_map4_4_64 = new int[64];
            res.color_map4_1_512 = new int[512];
            res.color_map4_2_512 = new int[512];
            res.color_map4_3_512 = new int[512];
            res.color_map4_4_512 = new int[512];
            res.color_map9_8 = new int[8, 9];
            res.color_map9_64 = new int[64, 9];
            res.color_map9_512 = new int[512, 9];
            res.color_map16_8 = new int[8, 16];
            res.color_map16_64 = new int[64, 16];
            res.color_map16_512 = new int[512, 16];
            for (int i = 0; i < width2; i++)
            {
                for (int j = 0; j < height2; j++)
                {
                    Color c = res.b.GetPixel(i, j);
                    int idx8 = ((c.R >> 7) << 2) + ((c.G >> 7) << 1) + (c.B >> 7);
                    int idx64 = ((c.R >> 6) << 4) + ((c.G >> 6) << 2) + (c.B >> 6);
                    int idx512 = ((c.R >> 5) << 6) + ((c.G >> 5) << 3) + (c.B >> 5);
                    int idx4096 = ((c.R >> 4) << 8) + ((c.G >> 4) << 4) + (c.B >> 4);
                    res.color_map1_8[idx8]++;
                    res.color_map1_64[idx64]++;
                    res.color_map1_512[idx512]++;
                    res.color_map1_4096[idx4096]++;
                    if (i < width2/2)
                    {
                        if (j < height2 / 2)
                        {
                            res.color_map4_1_8[idx8]++;
                            res.color_map4_1_64[idx64]++;
                            res.color_map4_1_512[idx512]++;
                        }
                        else
                        {
                            res.color_map4_2_8[idx8]++;
                            res.color_map4_2_64[idx64]++;
                            res.color_map4_2_512[idx512]++;
                        }
                    }
                    else
                    {
                        if (j < height2 / 2)
                        {
                            res.color_map4_3_8[idx8]++;
                            res.color_map4_3_64[idx64]++;
                            res.color_map4_3_512[idx512]++;

                        }
                        else
                        {
                            res.color_map4_4_8[idx8]++;
                            res.color_map4_4_64[idx64]++;
                            res.color_map4_4_512[idx512]++;
                        }
                    }
                    int ww = 0;
                    int hh = 0;
                    int idxidx = 0;
                    //color_map9_*
                    ww = (i * 3) / width2;
                    hh = (j * 3) / height2;
                    idxidx = ww * 3 + hh;
                    res.color_map9_8[idx8, idxidx]++;
                    res.color_map9_64[idx64, idxidx]++;
                    res.color_map9_512[idx512, idxidx]++;
                    //color_map16_*
                    ww = (i * 4) / width2;
                    hh = (j * 4) / height2;
                    idxidx = ww * 4 + hh;
                    res.color_map16_8[idx8, idxidx]++;
                    res.color_map16_64[idx64, idxidx]++;
                    res.color_map16_512[idx512, idxidx]++;
                }
            }
            //res.b.Save(@"C:\_2del\p" + p.ToString() +"_" +num.ToString() + ".jpg");
            return res;
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
                int k0 = 0;
                for(int k = 0; k < 15; k++)
                {
                    k0 += LineAnalize[block].flag[k];
                }
                if (k0 == 0)
                {
                    LineAnalize[block].flag[0] = 1;
                }
                int k9 = 0;
                for (int k = len; k > len-15; k--)
                {
                    k9 += LineAnalize[block].flag[k];
                }
                if (k9 == 0)
                {
                    LineAnalize[block].flag[len] = 1;
                }

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
            if (b.Length >= 5)
            {
                LineAnalize[block].SeparatorWidth = width;
                int[] tests = new int[5];
                tests[0] = TestStartEnd(block, b, b[0]);
                tests[1] = TestStartEnd(block, b, b[1]);
                tests[2] = TestStartEnd(block, b, b[2]);
                tests[3] = TestStartEnd(block, b, b[3]);
                tests[4] = TestStartEnd(block, b, b[4]);
                int idx3 = -1;
                int mmm = -1;
                for (int i = 0; i < 5; i++)
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
            else
            {
                LineAnalize[block].SeparatorStart = block;
                LineAnalize[block].SeparatorCount = block+1;
                LineAnalize[block].SeparatorEnd = block+5;
                LineAnalize[block].SeparatorWidth = block*5;
            }
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
        */
    }
}
