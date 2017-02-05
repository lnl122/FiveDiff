using System.Collections.Generic;
using System;
using System.Drawing;
using System.IO;

namespace FiveDiff
{
    public class ImageDiff
    {
        public Bitmap img1;
        public Bitmap img2;

        private const int BmpHeader = 54;
        private Bitmap Bmp;
        private Parts[] Part = new Parts[2];
        private int LineLen;
        private int shift_ver;
        private int shift_hor;
        private ShArr[] Shifts;

        private struct Parts
        {
            public Bitmap img;
            public Rectangle rect;
            public byte[] ba;
            public Rectangle rect_shift;
            public Bitmap img_shift;
            public Bitmap pair;
        }
        public struct ShArr
        {
            public int shift_v;
            public int shift_h;
            public long diff;
        }

#if DEBUG
        // набор функций предназначен для юнит-тестов private методов
        public int nu_GetMinIndex(float[] diff)
        {
            return GetMinIndex(diff);
        }
        public int[] nu_GetFiveMinIndex(float[] diff)
        {
            return GetFiveMinIndex(diff);
        }
        public ShArr[] nu_KillDupesShifts(ShArr[] shifts2)
        {
            return KillDupesShifts(shifts2);
        }
        public int nu_GetShHor()
        {
            return shift_hor;
        }
        public int nu_GetShVer()
        {
            return shift_ver;
        }
        // конец набора функций для юнит-тестов
#endif

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="b">битмап, в котором нужно найти отличия</param>
        public ImageDiff(Bitmap b)
        {
            Bmp = b;
            CutImage();
            FindShift();
            StoreParts();
            CreatePairImage();
            img1 = Part[0].pair;
            img2 = Part[1].pair;
        }
        /// <summary>
        /// создает парные изображения для вывода на экран
        /// </summary>
        private void CreatePairImage()
        {
            Part[0].pair = Part[0].img;
            Bitmap b = new Bitmap(Part[0].img.Width, Part[0].img.Height);
            Graphics g = Graphics.FromImage(b);
            g.DrawImage(Part[0].img, new Rectangle(0, 0, Part[0].img.Width, Part[0].img.Height), new Rectangle(0, 0, Part[0].img.Width, Part[0].img.Height), GraphicsUnit.Pixel);
            g.DrawImage(Part[1].img, Part[0].rect_shift, Part[1].rect_shift, GraphicsUnit.Pixel);
            Part[1].pair = b;
            Part[0].pair.Save(@"C:\_2del\f1.jpg");
            Part[1].pair.Save(@"C:\_2del\f2.jpg");
        }
        /// <summary>
        /// находит смещения по разнице цветов в линиях
        /// </summary>
        private void FindShift()
        {
            int[] w0 = GetSumWidthPart(0);
            int[] w1 = GetSumWidthPart(1);
            int[] h0 = GetSumHeigthPart(0);
            int[] h1 = GetSumHeigthPart(1);

            int[] sh_v = GetLineDiffArr(w0, w1);
            int[] sh_h = GetLineDiffArr(h0, h1);
            int sh_v_len = sh_v.Length;
            int sh_h_len = sh_h.Length;
            int s_cnt = 5;
            ShArr[] Shifts2 = new ShArr[sh_v_len * sh_h_len * s_cnt * s_cnt];
            for (int i = 0; i < sh_v_len; i++)
            {
                for (int j = 0; j < sh_h_len; j++)
                {
                    for (int i2 = 0; i2 < s_cnt; i2++)
                    {
                        for (int j2 = 0; j2 < s_cnt; j2++)
                        {
                            int idx2 = (i * sh_v_len + j) * s_cnt * s_cnt + i2 * s_cnt + j2;
                            ShArr q = new ShArr();
                            q.diff = 0;
                            q.shift_h = sh_h[j] + j2 - s_cnt / 2;
                            q.shift_v = sh_v[i] + i2 - s_cnt / 2;
                            Shifts2[idx2] = q;
                        }
                    }
                }
            }
            Shifts = KillDupesShifts(Shifts2);
            FindDiffsByShifts();
            long[] dd = new long[Shifts.Length];
            for(int i = 0; i < Shifts.Length; i++) { dd[i] = Shifts[i].diff; }
            int idx = GetMinIndex(dd);
            shift_ver = -Shifts[idx].shift_v;
            shift_hor = Shifts[idx].shift_h;
        }
        /// <summary>
        /// для всех сдвигов ищет сумму разниц отличий
        /// </summary>
        private void FindDiffsByShifts()
        {
            int len = Shifts.Length;
            for(int i=0; i<len; i++)
            {
                Shifts[i].diff = FindDiffsByShiftsOne(i);
            }
        }
        /// <summary>
        /// ищет сумму разниц отличий для одной пары сдвигов по прямоугольнику
        /// </summary>
        /// <param name="num">индекс в массиве сдвигов</param>
        /// <returns>разница цветов</returns>
        private long FindDiffsByShiftsOne(int num)
        {
            int sh_v = Shifts[num].shift_v;
            int sh_h = Shifts[num].shift_h;
            int part_v = Part[0].rect.Height;
            int part_h = Part[0].rect.Width;
            int pv5 = part_v / 5;
            int ph5 = part_h / 5;
            long dd = 0;
            for(int i = 0; i < ph5; i++)
            {
                for (int j = 0; j < pv5; j++)
                {
                    int x = ph5 * 2 + i;
                    int y = pv5 * 2 + j;
                    int x2 = x + sh_h;
                    int y2 = y + sh_v;
                    dd = dd + Math.Abs(Part[0].ba[GetIndexByXY(x, y)] - Part[1].ba[GetIndexByXY(x2, y2)]);
                    dd = dd + Math.Abs(Part[0].ba[GetIndexByXY(x, y)+1] - Part[1].ba[GetIndexByXY(x2, y2)]+1);
                    dd = dd + Math.Abs(Part[0].ba[GetIndexByXY(x, y)+2] - Part[1].ba[GetIndexByXY(x2, y2)]+2);
                }
            }
            return dd;
        }
        /// <summary>
        /// убивает дубликаты структур в Shifts
        /// </summary>
        /// <param name="shifts2">исходный массив</param>
        /// <returns>массив без дупов</returns>
        private ShArr[] KillDupesShifts(ShArr[] shifts2)
        {
            List<ShArr> resL = new List<ShArr>();
            foreach(ShArr q in shifts2)
            {
                if (!resL.Contains(q)) { resL.Add(q); }
            }
            int len = resL.Count;
            ShArr[] res = new ShArr[len];
            for(int i = 0; i < len; i++)
            {
                res[i] = resL[i];
            }
            return res;
        }
        /// <summary>
        /// сохраняет части по найденным смещениям
        /// </summary>
        private void StoreParts() { 
            int ww = Part[0].rect.Width - Math.Abs(shift_hor);
            int hh = Part[0].rect.Height - Math.Abs(shift_ver);
            if (shift_ver >= 0)
            {
                if (shift_hor >= 0)
                {
                    Part[0].rect_shift = new Rectangle(0, 0, ww, hh);
                    Part[1].rect_shift = new Rectangle(shift_hor, shift_ver, ww, hh);
                }
                else
                {
                    Part[0].rect_shift = new Rectangle(-shift_hor, 0, ww, hh);
                    Part[1].rect_shift = new Rectangle(0, shift_ver, ww, hh);
                }
            }
            else
            {
                if (shift_hor >= 0)
                {
                    Part[0].rect_shift = new Rectangle(0, -shift_ver, ww, hh);
                    Part[1].rect_shift = new Rectangle(shift_hor, 0, ww, hh);
                }
                else
                {
                    Part[0].rect_shift = new Rectangle(-shift_hor, -shift_ver, ww, hh);
                    Part[1].rect_shift = new Rectangle(0, 0, ww, hh);
                }
            }
            Part[0].img_shift = Part[0].img.Clone(Part[0].rect_shift, Bmp.PixelFormat);
            Part[1].img_shift = Part[1].img.Clone(Part[1].rect_shift, Bmp.PixelFormat);

            Part[0].img_shift.Save(@"C:\_2del\p1.jpg");
            Part[1].img_shift.Save(@"C:\_2del\p2.jpg");
        }
        /// <summary>
        /// находит индекс минимального значения из массива
        /// </summary>
        /// <param name="diff">массив</param>
        /// <returns>минимальный индекс</returns>
        private int GetMinIndex(float[] diff)
        {
            int res = 0;
            int len = diff.Length;
            float min = (float)9e50;
            for (int i = 0; i < len; i++)
            {
                if (min > diff[i])
                {
                    min = diff[i];
                    res = i;
                }
            }
            return res;
        }
        /// <summary>
        /// находит индекс минимального значения из массива
        /// </summary>
        /// <param name="diff">массив</param>
        /// <returns>минимальный индекс</returns>
        private int GetMinIndex(long[] diff)
        {
            int res = 0;
            int len = diff.Length;
            float min = 0xffffffffffffff;
            for (int i = 0; i < len; i++)
            {
                if (min > diff[i])
                {
                    min = diff[i];
                    res = i;
                }
            }
            return res;
        }
        /// <summary>
        /// находит индексы пяти минимальных значений из массива
        /// </summary>
        /// <param name="d">массив</param>
        /// <returns>массив минимальных индексов</returns>
        private int[] GetFiveMinIndex(float[] d)
        {
            float[] diff = d;
            List<int> res_l = new List<int>();
            int len = diff.Length;
            while (res_l.Count < 5)
            {
                int ii = 0;
                float min = (float)9e50;
                for (int i = 0; i < len; i++)
                {
                    if (min > diff[i])
                    {
                        min = diff[i];
                        ii = i;
                    }
                }
                res_l.Add(ii);
                diff[ii] = (float)9e50;
            }
            int[] res = new int[res_l.Count];
            for(int i=0; i<res_l.Count; i++)
            {
                res[i] = res_l[i];
            }
            return res;
        }
        /// <summary>
        /// находит смещение по разнице цветов из двух массивов
        /// </summary>
        /// <param name="a1">массив цветов 1</param>
        /// <param name="a2">массив цветов 2</param>
        /// <returns>смещение массива 2 относительно массива 1</returns>
        private int GetLineDiff(int[] a1, int[] a2)
        {
            int res = 0;
            int len = a1.Length;
            if (len != a2.Length) { return -1; }
            int shift = len / 3 / 3;
            float[] diff = new float[shift * 2 + 1];
            for (int i = -shift; i <= shift; i++)
            {
                diff[i + shift] = GetLineDiffOne(a1, a2, i * 3);
            }
            res = GetMinIndex(diff) - shift;
            return res;
        }        
        /// <summary>
        /// находит смещение по разнице цветов из двух массивов
        /// </summary>
        /// <param name="a1">массив цветов 1</param>
        /// <param name="a2">массив цветов 2</param>
        /// <returns>смещение массива 2 относительно массива 1</returns>
        private int[] GetLineDiffArr(int[] a1, int[] a2)
        {
            int len = a1.Length;
            if (len != a2.Length) { return new int[0]; }
            int shift = len / 3 / 3;
            float[] diff = new float[shift * 2 + 1];
            for (int i = -shift; i <= shift; i++)
            {
                diff[i + shift] = GetLineDiffOne(a1, a2, i * 3);
            }
            int[] res2 = GetFiveMinIndex(diff);
            int lenres = res2.Length;
            int[] res = new int[lenres];
            for(int i=0; i<lenres; i++) { res[i] = res2[i] - shift; }
            return res;
        }
        /// <summary>
        /// находит разницу цветов из двух массивов для конкретного смещения. усредняет
        /// </summary>
        /// <param name="a1">массив цветов 1</param>
        /// <param name="a2">массив цветов 2</param>
        /// <param name="i">смещение</param>
        /// <returns>усредненная разница</returns>
        private float GetLineDiffOne(int[] a1, int[] a2, int sh)
        {
            int len = a1.Length;
            int cnt = 0;
            int sum = 0;
            for(int i = 0; i < len; i++)
            {
                int j = i + sh;
                if((j < 0) || (j >= len)) { continue; }
                cnt++;
                int x1 = a1[i];
                int x2 = a2[j];
                if(x1 >= x2)
                {
                    sum += (x1 - x2);
                }
                else
                {
                    sum += (x2 - x1);
                }
            }
            return (float)sum/(float)(cnt);
        }
        /// <summary>
        /// получает массив сумм цветов горизонталей
        /// </summary>
        /// <param name="v">номер части</param>
        /// <returns>массив</returns>
        private int[] GetSumWidthPart(int v)
        {
            int w = Part[v].rect.Width;
            int h = Part[v].rect.Height;
            int[] res = new int[h * 3];
            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    res[j * 3] += Part[v].ba[GetIndexByXY(i, j)];
                    res[j * 3 + 1] += Part[v].ba[GetIndexByXY(i, j) + 1];
                    res[j * 3 + 2] += Part[v].ba[GetIndexByXY(i, j) + 2];
                }
            }
            return res;
        }        
        /// <summary>
        /// получает массив сумм цветов вертикалей
        /// </summary>
        /// <param name="v">номер части</param>
        /// <returns>массив</returns>
        private int[] GetSumHeigthPart(int v)
        {
            int w = Part[v].rect.Width;
            int h = Part[v].rect.Height;
            int[] res = new int[w * 3];
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    res[i * 3] += Part[v].ba[GetIndexByXY(i, j)];
                    res[i * 3 + 1] += Part[v].ba[GetIndexByXY(i, j) + 1];
                    res[i * 3 + 2] += Part[v].ba[GetIndexByXY(i, j) + 2];
                }
            }
            return res;
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
    }
}
