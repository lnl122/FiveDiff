// Copyright © 2016 Antony S. Ovsyannikov aka lnl122
// License: http://opensource.org/licenses/MIT

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveDiff
{
    public class FiveDifference
    {
        // базовая картинка
        Bitmap Bmp;
        // половины картинок
        Bitmap Img1, Img2;
        public Part[] Parts = new Part[2];
        public int LineLen = 0;
        // смещения
        public int shift_hor, shift_ver;
        // размер сетки
        public int rows, columns;

        // структура настроек
        private Settings settings;
        public enum setNums { Left, Up };
        public enum setLang { Rus, Eng };
        public enum setType { _A1, _1A };
        public struct Settings
        {
            public setNums nums;
            public setLang lang;
            public setType type;
            public Settings(setNums nn, setLang ll, setType tt)
            {
                nums = nn;
                lang = ll;
                type = tt;
            }
        }

        // структура для половинки картинки
        public struct Part
        {
            public Rectangle rect;
            public Bitmap img;
            public Rectangle rect_shift;
            public Bitmap img_shift;
            public byte[] ba;
            public bool[] grid_lines, grid_columns;
            public Bound BoundLetterLeft, BoundLetterUp;
            public Bound[] BoundsLeftRight, BoundsUpDown;
            public int columns, rows;
        }
        public struct ShArr
        {
            public int shift_v;
            public int shift_h;
            public long diff;
        }
        public struct Bound
        {
            public int start, end;
            public Bound(int p1, int p2)
            {
                start = p1;
                end = p2;
            }
            public static bool operator ==(Bound c1, Bound c2)
            {
                return ((c1.start == c2.start) && (c1.end == c2.end));
            }
            public static bool operator !=(Bound c1, Bound c2)
            {
                return ((c1.start == c2.start) && (c1.end == c2.end));
            }
        }
        /// <summary>
        /// структура для массива количества белого цвета по строкам и столбцам
        /// </summary>
        public struct TwoWhiteArray
        {
            public int[] cols, rows;
        }

        // константы
        private const int BmpHeader = 54;

        // параметры для подгонки эффективности

        // = 1, иначе ошибки совсем
        public int DetectGridOne_ArrSumMultiplier = 1; // поиск сетки по строкам/столбцам, отсечение ошибок до сравнения на белый цвет

        public int FindCommonShift_shift2 = 5; // общий сдвиг, сдвиг поиска вокруг найденных пересечений
        public int FindDiffsByShiftsOne_CutPart = 5; // часть (1/х) половинок, для поиска соответствия в одном пересечении
        public int GetLineDiffArr_max_shift = 3; // часть (1/х) строк, по которым ищем сдвиг
        //public int FindLetterBounds_start = 30; // с какой позиции искать границу окончения первой буквы
        public int FindGrid_SkipPointsAroundLetters = 2; // точек пропустить от границ букв 2-3 где-то так
        public float GetBounds_AllowSizeMultiplier = 1.5f; // допустимые изменения размеров блоков
        public float DetectGridOne_MaxDiffPeakMultiplier = 1.3f; // максимальная разница в пиках
        public int FindGrid_AllowedWhitePixels = 3; // сколько может быть белых пикселей в сетке
        public int GetWhiteBound_PortionWhiteBound1000 = 10; // доля +- точек для определения границ белого по краям
        public int GetWhiteBound_PortionWhiteBound1000_0 = 5; // доля +- точек для определения границ белого по краям (1% = 10)

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="b">анализируемая картинка</param>
        /// <param name="s">структура настроек строкой, для совместимости</param>
        public FiveDifference(Bitmap b, string s = "EnLeA1")
        {
            // EnLe1A
            Settings ss = new Settings();
            string p1 = s.Substring(0, 2);
            string p2 = s.Substring(2, 2);
            string p3 = s.Substring(4, 2);
            if (p1 == "Ru") { ss.lang = setLang.Rus; } else { ss.lang = setLang.Eng; }
            if (p2 == "Up") { ss.nums = setNums.Up; } else { ss.nums = setNums.Left; }
            if (p3 == "A1") { ss.type = setType._A1; } else { ss.type = setType._1A; }
            settings = ss;
            Bmp = b;
            FiveDifferenceDo();
        }
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="b">анализируемая картинка</param>
        /// <param name="s">структура настроек</param>
        public FiveDifference(Bitmap b, Settings s)
        {
            settings = s;
            Bmp = b;
            FiveDifferenceDo();
        }

        /// <summary>
        /// main code
        /// </summary>
        public void FiveDifferenceDo()
        {
            // разрежем картинку, переведем обе части и массив байт - BMP, расставим флаги наличия сетки
            CutImageToParts();
            ImageToByteArray();

            // найдем сетку, границы, колонки/строки
            DetectGrid();
            
            // найдем общий сдвиг двух частей, сформируем прямоугольники с учетом сдвига.
            FindCommonShift();
            StoreParts();
            CreatePairImage();

            // для каждой ячейки найденной сетки выполним сравнение прямоугольных областей, запомним разницу цветов

            // для наибольших разниц цветов составим код по полученной маске

            //StoreImage(Parts[0].img, @"C:\_2del\part1.jpg");
            //StoreImage(Parts[1].img, @"C:\_2del\part2.jpg");
        }

        /// <summary>
        /// создает парные изображения для вывода на экран
        /// </summary>
        public void CreatePairImage()
        {
            Img1 = Parts[0].img;
            Bitmap b = new Bitmap(Parts[0].img.Width, Parts[0].img.Height);
            Graphics g = Graphics.FromImage(b);
            g.DrawImage(Parts[0].img, new Rectangle(0, 0, Parts[0].img.Width, Parts[0].img.Height), new Rectangle(0, 0, Parts[0].img.Width, Parts[0].img.Height), GraphicsUnit.Pixel);
            g.DrawImage(Parts[1].img, Parts[0].rect_shift, Parts[1].rect_shift, GraphicsUnit.Pixel);
            Img2 = b;
        }

        /// <summary>
        /// сохраняет части по найденным смещениям
        /// </summary>
        public void StoreParts()
        {
            int ww = Parts[0].rect.Width - Math.Abs(shift_hor);
            int hh = Parts[0].rect.Height - Math.Abs(shift_ver);
            if (shift_ver >= 0)
            {
                if (shift_hor >= 0)
                {
                    Parts[0].rect_shift = new Rectangle(0, 0, ww, hh);
                    Parts[1].rect_shift = new Rectangle(shift_hor, shift_ver, ww, hh);
                }
                else
                {
                    Parts[0].rect_shift = new Rectangle(-shift_hor, 0, ww, hh);
                    Parts[1].rect_shift = new Rectangle(0, shift_ver, ww, hh);
                }
            }
            else
            {
                if (shift_hor >= 0)
                {
                    Parts[0].rect_shift = new Rectangle(0, -shift_ver, ww, hh);
                    Parts[1].rect_shift = new Rectangle(shift_hor, 0, ww, hh);
                }
                else
                {
                    Parts[0].rect_shift = new Rectangle(-shift_hor, -shift_ver, ww, hh);
                    Parts[1].rect_shift = new Rectangle(0, 0, ww, hh);
                }
            }
            Parts[0].img_shift = Parts[0].img.Clone(Parts[0].rect_shift, Bmp.PixelFormat);
            Parts[1].img_shift = Parts[1].img.Clone(Parts[1].rect_shift, Bmp.PixelFormat);
        }
 
        /// <summary>
        /// находит общий для двух частей
        /// </summary>
        public void FindCommonShift()
        {
            int[] r0 = GetSumRowsParts(0);
            int[] r1 = GetSumRowsParts(1);
            int[] c0 = GetSumColsParts(0);
            int[] c1 = GetSumColsParts(1);

            int[] sh_v = GetLineDiffArr(r0, r1, Parts[0].grid_lines, Parts[1].grid_lines);
            int[] sh_h = GetLineDiffArr(c0, c1, Parts[0].grid_columns, Parts[1].grid_columns);
            int sh_v_len = sh_v.Length;
            int sh_h_len = sh_h.Length;

            int s_cnt = FindCommonShift_shift2;
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
            ShArr[] Shifts3 = KillDupesShifts(Shifts2);
            ShArr[] Shifts = FindDiffsByShifts(Shifts3);
            long[] dd = new long[Shifts.Length];
            for (int i = 0; i < Shifts.Length; i++) { dd[i] = Shifts[i].diff; }
            int idx = GetMinIndex(dd);
            shift_ver = -Shifts[idx].shift_v;
            shift_hor = Shifts[idx].shift_h;
        }
  
        /// <summary>
        /// находит индекс минимального значения из массива
        /// </summary>
        /// <param name="diff">массив</param>
        /// <returns>минимальный индекс</returns>
        public int GetMinIndex(long[] diff)
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
        /// для всех сдвигов ищет сумму разниц отличий
        /// </summary>
        public ShArr[] FindDiffsByShifts(ShArr[] Shifts)
        {
            int len = Shifts.Length;
            ShArr[] res = new ShArr[len];
            for (int i = 0; i < len; i++)
            {
                res[i] = Shifts[i];
                res[i].diff = FindDiffsByShiftsOne(Shifts[i]);
            }
            return res;
        }
 
        /// <summary>
        /// ищет сумму разниц отличий для одной пары сдвигов по прямоугольнику
        /// </summary>
        /// <param name="num">индекс в массиве сдвигов</param>
        /// <returns>разница цветов</returns>
        public long FindDiffsByShiftsOne(ShArr sh)
        {
            int sh_v = sh.shift_v;
            int sh_h = sh.shift_h;
            int Parts_v = Parts[0].rect.Height;
            int Parts_h = Parts[0].rect.Width;
            int pv5 = Parts_v / FindDiffsByShiftsOne_CutPart;
            int ph5 = Parts_h / FindDiffsByShiftsOne_CutPart;
            long dd = 0;
            for (int i = 0; i < ph5; i++)
            {
                for (int j = 0; j < pv5; j++)
                {
                    int x = ph5 * 2 + i;
                    int y = pv5 * 2 + j;
                    int x2 = x + sh_h;
                    int y2 = y + sh_v;
                    //if ((Parts[0].grid_columns[x]) || (Parts[1].grid_columns[x2]) || (Parts[0].grid_lines[y]) || (Parts[1].grid_lines[y2])) { continue; }
                    int pos = GetIndexByXY(x, y);
                    int pos2 = GetIndexByXY(x2, y2);
                    dd += Math.Abs(Parts[0].ba[pos] - Parts[1].ba[pos2]);
                    dd += Math.Abs(Parts[0].ba[pos + 1] - Parts[1].ba[pos2 + 1]);
                    dd += Math.Abs(Parts[0].ba[pos + 2] - Parts[1].ba[pos2 + 2]);
                }
            }
            return dd;
        }
   
        /// <summary>
        /// убивает дубликаты структур в Shifts
        /// </summary>
        /// <param name="shifts2">исходный массив</param>
        /// <returns>массив без дупов</returns>
        public ShArr[] KillDupesShifts(ShArr[] shifts2)
        {
            List<ShArr> resL = new List<ShArr>();
            foreach (ShArr q in shifts2)
            {
                if (!resL.Contains(q)) { resL.Add(q); }
            }
            int len = resL.Count;
            ShArr[] res = new ShArr[len];
            for (int i = 0; i < len; i++)
            {
                res[i] = resL[i];
            }
            return res;
        }
     
        /// <summary>
        /// находит смещение по разнице цветов из двух массивов
        /// </summary>
        /// <param name="a1">массив цветов 1</param>
        /// <param name="a2">массив цветов 2</param>
        /// <param name="b1">маска сетки 1</param>
        /// <param name="b2">маска сетки 2</param>
        /// <returns>смещение массива 2 относительно массива 1</returns>
        public int[] GetLineDiffArr(int[] a1, int[] a2, bool[] b1, bool[] b2)
        {
            int len = a1.Length;
            if (len != a2.Length) { return new int[0]; }
            if (len != b1.Length*3) { return new int[0]; }
            if (len != b2.Length*3) { return new int[0]; }
            int shift = len / 3 / GetLineDiffArr_max_shift;
            float[] diff = new float[shift * 2 + 1];
            for (int i = -shift; i <= shift; i++)
            {
                diff[i + shift] = GetLineDiffOne(a1, a2, i*3, b1, b2);
            }
            int[] res2 = GetFiveMinIndex(diff);
            int lenres = res2.Length;
            int[] res = new int[lenres];
            for (int i = 0; i < lenres; i++) { res[i] = res2[i] - shift; }
            return res;
        }
     
        /// <summary>
        /// находит индексы пяти минимальных значений из массива
        /// </summary>
        /// <param name="d">массив</param>
        /// <returns>массив минимальных индексов</returns>
        public int[] GetFiveMinIndex(float[] d)
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
            for (int i = 0; i < res_l.Count; i++)
            {
                res[i] = res_l[i];
            }
            return res;
        }
     
        /// <summary>
        /// находит разницу цветов из двух массивов для конкретного смещения. усредняет
        /// </summary>
        /// <param name="a1">массив цветов 1</param>
        /// <param name="a2">массив цветов 2</param>
        /// <param name="i">смещение</param>
        /// <returns>усредненная разница</returns>
        public float GetLineDiffOne(int[] a1, int[] a2, int sh, bool[] b1, bool[] b2)
        {
            int len = a1.Length;
            int cnt = 0;
            int sum = 0;
            for (int i = 0; i < len; i++)
            {
                int j = i + sh;
                if ((j < 0) || (j >= len)) { continue; }
                if ( b1[i/3] || b2[j/3] ) { continue; }
                cnt++;
                sum += Math.Abs(a1[i] - a2[j]);
            }
            return (float)sum / (float)(cnt);
        }
    
        /// <summary>
        /// получает массив сумм цветов горизонталей
        /// </summary>
        /// <param name="v">номер части</param>
        /// <returns>массив</returns>
        public int[] GetSumRowsParts(int v)
        {
            int w = Parts[v].rect.Width;
            int h = Parts[v].rect.Height;
            int[] res = new int[h * 3];
            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    int pos = GetIndexByXY(i, j);
                    int idx = j * 3;
                    res[idx] += Parts[v].ba[pos];
                    res[idx + 1] += Parts[v].ba[pos + 1];
                    res[idx + 2] += Parts[v].ba[pos + 2];
                }
            }
            return res;
        }
    
        /// <summary>
        /// получает массив сумм цветов вертикалей
        /// </summary>
        /// <param name="v">номер части</param>
        /// <returns>массив</returns>
        public int[] GetSumColsParts(int v)
        {
            int w = Parts[v].rect.Width;
            int h = Parts[v].rect.Height;
            int[] res = new int[w * 3];
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    int pos = GetIndexByXY(i, j);
                    int idx = i * 3;
                    res[idx] += Parts[v].ba[pos];
                    res[idx + 1] += Parts[v].ba[pos + 1];
                    res[idx + 2] += Parts[v].ba[pos + 2];
                }
            }
            return res;
        }
     
        /// <summary>
        /// получает индекс в массиве байт для координат
        /// </summary>
        /// <param name="x">координата пикселя горизонталь, слева</param>
        /// <param name="y">координата пикселя вертикаль, снизу</param>
        /// <returns>положение в массиве</returns>
        public int GetIndexByXY(int x, int y)
        {
            return BmpHeader + y * LineLen + x * 3;
        }
      
        /// <summary>
        ///  получает 3 бит цвет точки
        /// </summary>
        /// <param name="idx">индекс</param>
        /// <returns>цвет</returns>
        public int GetColor3bit(byte[] ba, int idx)
        {
            return (ba[idx + 0] >> 7) + ((ba[idx + 1] >> 7) << 1) + ((ba[idx + 2] >> 7) << 2);
        }
    
        /// <summary>
        ///  получает 6 бит цвет точки
        /// </summary>
        /// <param name="idx">индекс</param>
        /// <returns>цвет</returns>
        public int GetColor6bit(byte[] ba, int idx)
        {
            return (ba[idx + 0] >> 6) + ((ba[idx + 1] >> 6) << 2) + ((ba[idx + 2] >> 6) << 4);
        }
     
        /// <summary>
        ///  получает 9 бит цвет точки
        /// </summary>
        /// <param name="idx">индекс</param>
        /// <returns>цвет</returns>
        public int GetColor9bit(byte[] ba, int idx)
        {
            return (ba[idx + 0] >> 5) + ((ba[idx + 1] >> 5) << 3) + ((ba[idx + 2] >> 5) << 6);
        }
  
        /// <summary>
        ///  получает 12 бит цвет точки
        /// </summary>
        /// <param name="idx">индекс</param>
        /// <returns>цвет</returns>
        public int GetColor12bit(byte[] ba, int idx)
        {
            return (ba[idx + 0] >> 4) + ((ba[idx + 1] >> 4) << 4) + ((ba[idx + 2] >> 4) << 8);
        }
  
        /// <summary>
        /// находит сетку для обоих половинок
        /// </summary>
        public void DetectGrid()
        {
            DetectGridOne(0);
            DetectGridOne(1);
            columns = Parts[0].columns;
            rows = Parts[0].rows;
        }
    
        /// <summary>
        /// получает количества белых цветов в части картинки
        /// </summary>
        /// <param name="num">номер части</param>
        /// <returns>структура из двух массивов</returns>
        public TwoWhiteArray GetWhiteCounts(int num)
        {
            byte[] ba = Parts[num].ba;
            int width = Parts[num].rect.Width;
            int height = Parts[num].rect.Height;

            TwoWhiteArray res = new TwoWhiteArray();
            res.cols = new int[width];
            res.rows = new int[height];
            // считаем белые цвета
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int clr12 = GetColor12bit(ba, GetIndexByXY(i, j));
                    if (clr12 == 4095)
                    {
                        res.cols[i]++;
                        res.rows[height - j - 1]++;
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// находит границы белого фона
        /// </summary>
        /// <param name="ar">линейка количества белого цвета</param>
        /// <param name="max">теоретически максимальное значение</param>
        /// <returns>границы слева и справа</returns>
        public Bound GetWhiteBound(int[] ar, int max)
        {
            int m = max - max * GetWhiteBound_PortionWhiteBound1000 / 1000;
            int cnt = ar.Length;

            int b1 = 0;
            int b2 = cnt - 1;
            for (int i = b1; i < cnt; i++) { if (ar[i] < m) { b1 = i; break; } }
            for (int i = b2; i >= 0; i--) { if (ar[i] < m) { b2 = i; break; } }

            return new Bound(b1, b2);
        }

        /// <summary>
        /// находит мнодество границ клеток сетки, включая ту, где символы
        /// </summary>
        /// <param name="ar">массив количеств белых цветов</param>
        /// <param name="b">границы краев, за которыми искать не нужно</param>
        /// <returns>массив границ ячеек сетки</returns>
        public List<Bound> GetWhiteSquare(int[] ar, Bound b, int wh)
        {
            int len = ar.Length;
            int diff = wh + len * GetWhiteBound_PortionWhiteBound1000_0 / 1000;
            int start = b.start;
            int end = b.end;
            int[] ard = new int[len];
            for (int i = start; i < end; i++) { int x = ar[i] - diff; if (x < 0) { x = 0; } ard[i] = x; }
            int b_start = start;
            int b_end = end;
            List<Bound> res = new List<Bound>();
            for (int i = start; i < end-1; i++)
            {
                if ((ard[i] > 0) && (ard[i + 1] == 0))
                {
                    // конец ячейки
                    b_end = i;
                    res.Add(new Bound(b_start, b_end));
                    b_start = i + 1;
                }
                if ((ard[i + 1] > 0) && (ard[i] == 0))
                {
                    // начало ячейки
                    b_start = i;
                }
            }
            if ((b_start < end) && ((end-b_start)>20) ) { res.Add(new Bound(b_start, end)); }
            return res;
        }

        /// <summary>
        /// считает количество белых цветов, паразитных на картинке
        /// </summary>
        /// <param name="b"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public int GetWhiteCnt(Bound b, int l)
        {
            return (b.start) + (l-b.end);
        }

        /// <summary>
        /// находит сетку для одной из половинок
        /// <param name="num">номер части</param>
        /// </summary>
        public void DetectGridOne(int num)
        {
            // * найти количества белых цветов
            TwoWhiteArray white = GetWhiteCounts(num);
            int cols_cnt = white.cols.Length;
            int rows_cnt = white.rows.Length;
            // * максимальные значения, = 99% или больше чем другое измерение - отсекать, т.к. это белый фон вокруг картинки
            Bound boundUD = GetWhiteBound(white.rows, cols_cnt);
            Bound boundLR = GetWhiteBound(white.cols, rows_cnt);
            // заполним показания в сетке
            Parts[num].grid_columns = new bool[cols_cnt];
            Parts[num].grid_lines = new bool[rows_cnt];
            for (int i = 0; i < boundUD.start; i++) { Parts[num].grid_lines[i] = true; }
            for (int i = boundUD.end; i < rows_cnt; i++) { Parts[num].grid_lines[i] = true; }
            for (int i = 0; i < boundLR.start; i++) { Parts[num].grid_columns[i] = true; }
            for (int i = boundLR.end; i < cols_cnt; i++) { Parts[num].grid_columns[i] = true; }
            // * в оставшихся искать значения равные минимальному +- 3 пикселя, или минимум +-0,5% от него - это сетка
            List<Bound> squareUD = GetWhiteSquare(white.rows, boundUD, GetWhiteCnt(boundLR, cols_cnt));
            List<Bound> squareLR = GetWhiteSquare(white.cols, boundLR, GetWhiteCnt(boundUD, rows_cnt));
            // заполним в сетке
            
            int ii0 = 9;
            if (num == 0)
            {
                Parts[0].columns = squareLR.Count -1;
                Parts[1].columns = Parts[0].columns;
                Parts[0].rows = squareUD.Count -1;
                Parts[1].rows = Parts[0].rows;
                columns = Parts[0].columns;
                rows = Parts[0].rows;
            }
            // * для Parts[0] - символы у нас в первой колонке/столбце
            // * для Parts[1] - символы могут быть вначале/конце. надо найти где посмотрев на величину сдвига, учтя белые границы
            // все остальное - наша сетка для поиска.



            /*
            int[] white_col_diff = GetWhiteDiff(white_columns, white_columns4);
            int[] white_row_diff = GetWhiteDiff(white_rows, white_rows4);
            // находим разницы для определения сетки
            int max_diff_col = (int)(GetMax(white_col_diff) / DetectGridOne_MaxDiffPeakMultiplier);
            int max_diff_row = (int)(GetMax(white_row_diff) / DetectGridOne_MaxDiffPeakMultiplier); // критерий определения заголовков/поля - значение выше половины максимума
            Parts[num].grid_columns = GetGridFlagByDiff2(white_col_diff, max_diff_col);
            Parts[num].grid_lines = GetGridFlagByDiff2(white_row_diff, max_diff_row);
            // нужно найти наибольший промежуток, а затем слева от него ещё раз наибольший - это будет место с символами
            Bound b1_col = GetMaxBound(Parts[num].grid_columns, new Bound(-1,-1));
            Bound b1_row = GetMaxBound(Parts[num].grid_lines, new Bound(-1, -1));
            Parts[num].BoundLetterLeft = GetMaxBound(Parts[num].grid_columns, b1_col);
            Parts[num].BoundLetterUp = GetMaxBound(Parts[num].grid_lines, b1_row);

            // тут у нас есть границы букв, и, ориентируясь на них нужно найти сетку и посчитать кол/стр
            FindGrid(num);
            */
        }

        /// <summary>
        /// поиск сетки по разделителям букв
        /// </summary>
        /// <param name="num">номер части</param>
        public void FindGrid(int num)
        {
            int width = Parts[num].img.Width;
            int height = Parts[num].img.Height;
            byte[] ba = Parts[num].ba;
            // получим расположение букв
            int h_left = Parts[num].BoundLetterLeft.start + FindGrid_SkipPointsAroundLetters;
            int h_right = Parts[num].BoundLetterLeft.end - FindGrid_SkipPointsAroundLetters;
            int v_up = Parts[num].BoundLetterUp.start + FindGrid_SkipPointsAroundLetters;
            int v_down = Parts[num].BoundLetterUp.end - FindGrid_SkipPointsAroundLetters;
            // соберем количества белых цветов для вертикали и горизонтали
            int[] white_columns = new int[width];
            for (int i = 0; i < width; i++)
            {
                for (int j = v_up; j < v_down; j++)
                {
                    if (GetColor12bit(ba, GetIndexByXY(i, height - j - 1)) == 4095) { white_columns[i]++; }
                }
            }
            int[] white_rows = new int[height];
            for (int j = 0; j < height; j++)
            {
                for (int i = h_left; i < h_right; i++)
                {
                    if (GetColor12bit(ba, GetIndexByXY(i, height - j - 1)) == 4095) { white_rows[j]++; }
                }
            }
            // для найденных маркеров заполним grid_columns/grid_lines
            int[] white_columns2 = GetArrSubInt(white_columns, GetMin(white_columns));
            int[] white_rows2 = GetArrSubInt(white_rows, GetMin(white_rows));
            for (int i = 0; i < width; i++)
            {
                if (white_columns[i] <= FindGrid_AllowedWhitePixels) { Parts[num].grid_columns[i] = true; } //else { Parts[num].grid_columns[i] = false; }
            }
            for (int i = 0; i < height; i++)
            {
                if (white_rows[i] <= FindGrid_AllowedWhitePixels) { Parts[num].grid_lines[i] = true; } //else { Parts[num].grid_lines[i] = false; }
            }
            Parts[num].grid_columns[0] = true;
            Parts[num].grid_columns[1] = true;
            Parts[num].grid_columns[width - 2] = true;
            Parts[num].grid_columns[width - 1] = true;
            Parts[num].grid_lines[0] = true;
            Parts[num].grid_lines[1] = true;
            Parts[num].grid_lines[height - 2] = true;
            Parts[num].grid_lines[height - 1] = true;
            // заполним Bounds для сетки
            Parts[num].BoundsLeftRight = GetBounds(Parts[num].grid_columns, Parts[num].BoundLetterLeft);
            Parts[num].BoundsUpDown = GetBounds(Parts[num].grid_lines, Parts[num].BoundLetterUp);
            // посчитаем колонки/строки
            Parts[num].columns = Parts[num].BoundsLeftRight.Length;
            Parts[num].rows = Parts[num].BoundsUpDown.Length;

        }

        /// <summary>
        /// создает массив границ по маске сетки, и расположению символов
        /// </summary>
        /// <param name="grid">маска сетки</param>
        /// <param name="Bnd">границы символов</param>
        /// <returns></returns>
        public Bound[] GetBounds(bool[] grid, Bound Bnd)
        {
            int len = grid.Length;
            int avg_letter = (Bnd.end + Bnd.start) / 2;
            int i_start = 0;
            int i_end = 0;
            if(avg_letter < len / 2)
            {
                // сначала символы, потом сетка
                i_start = Bnd.end;
                i_end = len - 1;
            }
            else
            {
                // сначала сетки, потом символы
                i_start = 0;
                i_end = Bnd.start;
            }
            // находим границы
            List<Bound> b = new List<Bound>();
            int begin = -1;
            int end = -1;
            for(int i = i_start+1; i < i_end-1; i++)
            {
                if (grid[i] && !grid[i + 1])
                {
                    begin = i;
                }
                if (!grid[i] && grid[i + 1])
                {
                    end = i;
                    if(begin != -1)
                    {
                        b.Add(new Bound(begin, end));
                    }
                }
            }
            b.Add(new Bound(end, i_end));
            // если границ так мало, выбросимся
            if (b.Count < 3) { return new Bound[0]; }
            // убиваем чрезмерно мелкие и большие границы
            List<Bound> b2 = new List<Bound>();
            int avg = 0;
            foreach (Bound bb in b) { avg = avg + (bb.end - bb.start); }
            avg = avg / b.Count;
            foreach (Bound bb in b)
            {
                int diff = bb.end - bb.start;
                if ((diff < avg * GetBounds_AllowSizeMultiplier) && (diff > avg / GetBounds_AllowSizeMultiplier)) { b2.Add(bb); }
            }
            // в массив
            Bound[] res = new Bound[b2.Count];
            for(int i = 0; i < b2.Count; i++) { res[i] = b2[i]; }
            return res;
        }

        /// <summary>
        /// находит в сетке между указанными координатами максимальный блок
        /// </summary>
        /// <param name="grid">сетка</param>
        /// <param name="b">исключение</param>
        /// <returns>границы с максимальной шириной</returns>
        public Bound GetMaxBound(bool[] grid, Bound b)
        {
            int len = grid.Length;
            // получим границы
            List<Bound> bounds = new List<Bound>();
            int last = 0;
            for (int i = 0; i < len; i++)
            {
                if (grid[i])
                {
                    bounds.Add(new Bound(last, i));
                    last = i;
                }
            }
            bounds.Add(new Bound(last, len-1));
            int max = -1;
            int idx = -1;
            for (int i = 0; i < bounds.Count; i++)
            {
                if (bounds[i] == b) { continue; }
                if (max < bounds[i].end - bounds[i].start)
                {
                    max = bounds[i].end - bounds[i].start;
                    idx = i;
                }
            }
            return bounds[idx];
        }        
   
        /// <summary>
        /// находит в сетке между указанными координатами максимальный блок
        /// </summary>
        /// <param name="grid">сетка</param>
        /// <param name="v1">начало</param>
        /// <param name="v2">конец</param>
        /// <returns>границы с максимальной шириной</returns>
        public Bound GetMaxBound(bool[] grid, int v1, int v2)
        {
            // получим границы
            List<Bound> bounds = new List<Bound>();
            int last = 0;
            for (int i = v1; i < v2; i++)
            {
                if (grid[i])
                {
                    bounds.Add(new Bound(last, i));
                    last = i;
                }
            }
            bounds.Add(new Bound(last, v2));
            int max = -1;
            int idx = -1;
            for (int i = 0; i < bounds.Count; i++)
            {
                if (max < bounds[i].end - bounds[i].start)
                {
                    max = bounds[i].end - bounds[i].start;
                    idx = i;
                }
            }
            return bounds[idx];
        }

        /// <summary>
        /// заполняет перезаписывая булев массив признаков сетки
        /// </summary>
        /// <param name="ar">массив значений разностей</param>
        /// <param name="val">критерий оценки</param>
        /// <returns>флаги сетки</returns>
        public bool[] GetGridFlagByDiff2(int[] ar, int val)
        {
            int len = ar.Length;
            bool[] res = new bool[len+1];
            for(int i = 0; i < len; i++)
            {
                if (ar[i] >= val)
                {
                    res[i] = true;                   
                }
                else {
                    res[i] = false;
                }
            }
            res[len] = true;
            return res;
        }

        /// <summary>
        /// находим разницу цветов по 3/4 нижней-правой части (без заголовков)
        /// </summary>
        /// <param name="ar1"></param>
        /// <param name="ar2"></param>
        /// <returns></returns>
        public int[] GetWhiteDiff(int[] ar1, int[] ar2)
        {
            int len = ar1.Length - 1;
            int[] res = new int[len];
            for(int i = 0; i < len; i++)
            {
                res[i] = Math.Abs(Math.Abs(ar1[i]-ar1[i + 1]) - Math.Abs(ar2[i] - ar2[i + 1]));
            }
            return res;
        }

        /// <summary>
        /// находит максимум в массиве
        /// </summary>
        /// <param name="ar">массив</param>
        /// <returns>максимум значение</returns>
        public int GetMax(int[] ar)
        {
            int max = -1;
            int cnt = ar.Length;
            for (int i = 0; i < cnt; i++) { if (ar[i] > max) { max = ar[i]; } }
            return max;
        }        
   
        /// <summary>
        /// вычитает из массива число, отрицательные приводит к нулю
        /// </summary>
        /// <param name="ar">массив</param>
        /// <param name="num">вычитаемое</param>
        /// <returns>уменьшенный массив</returns>
        public int[] SubArr(int[] ar, int num)
        {
            int cnt = ar.Length;
            int[] res = new int[cnt];
            for (int i = 0; i < cnt; i++) { res[i] = Math.Max(ar[i] - num, 0); }
            return res;
        }
   
        /// <summary>
        /// возвращает булев флаг наличия сетки по значениям массива меньше или равных 0
        /// </summary>
        /// <param name="ar">входящий массив</param>
        /// <returns>массив флагов</returns>
        public bool[] GetGridFlag(int[] ar)
        {
            int cnt = ar.Length;
            bool[] res = new bool[cnt];
            for(int i = 0; i < cnt; i++)
            {
                if (ar[i] <= 0) { res[i] = true; } else { res[i] = false; }
            }
            res[0] = true;
            res[cnt-1] = true;
            return res;
        }
    
        /// <summary>
        /// перевод 6 битного цвета в 3 битный
        /// </summary>
        /// <param name="num">цвет 6 бит</param>
        /// <returns>цвет 3 бит</returns>
        public int Color6to3bit(int num)
        {
            return ((num & 2) >> 1) | ((num & 8) >> 2) | ((num & 32) >> 3);
        }
    
        /// <summary>
        /// вычитает из массива число
        /// </summary>
        /// <param name="ar">массив</param>
        /// <param name="num">число</param>
        /// <returns>массив</returns>
        public int[] GetArrSubInt(int[] ar, int num)
        {
            int cnt = ar.Length;
            int[] res = new int[cnt];
            for (int i = 0; i < cnt; i++) { res[i] = ar[i] - num; }
            return res;
        }
   
        /// <summary>
        /// находит минимум в массиве
        /// </summary>
        /// <param name="ar">массив</param>
        /// <returns>минимальное значение</returns>
        public int GetMin(int[] ar)
        {
            int min = 256 * 256 * 256;
            int cnt = ar.Length;
            for (int i = 0; i < cnt; i++) { if (ar[i] < min) { min = ar[i]; } }
            return min;
        }        
  
        /// <summary>
        /// находит минимум в массиве, не равный нулю
        /// </summary>
        /// <param name="ar">массив</param>
        /// <returns>минимальное значение</returns>
        public int GetMin_NonZero(int[] ar)
        {
            int min = 256 * 256 * 256;
            int cnt = ar.Length;
            for (int i = 0; i < cnt; i++)
            {
                if (ar[i] <= 0) { continue; }
                if (ar[i] < min) { min = ar[i]; }
            }
            return min;
        }
   
        /// <summary>
        /// из битмапа делает массив байт - представление bmp
        /// </summary>
        /// <param name="img">битмап</param>
        /// <returns>массив байт</returns>
        public byte[] BitmapToByteArray(Bitmap img)
        {
            // 54 байта - заголовок
            // line = width * 3 + width % 4; /* Длина строки с учетом выравнивания */
            MemoryStream mStream = new MemoryStream();
            img.Save(mStream, System.Drawing.Imaging.ImageFormat.Bmp);
            return mStream.ToArray();
        }
   
        /// <summary>
        /// из картинок делает массив байт
        /// </summary>
        public void ImageToByteArray()
        {
            // переведем в массив байт
            Parts[0].ba = BitmapToByteArray(Parts[0].img);
            Parts[1].ba = BitmapToByteArray(Parts[1].img);
            // найдем длину линии в BMP
            LineLen = Parts[0].img.Width * 3 + Parts[0].img.Width % 4;
        }
   
        /// <summary>
        /// сохраняет картинку или её часть в файл
        /// </summary>
        /// <param name="b">картинка</param>
        /// <param name="p">путь куда сохранить</param>
        /// <param name="r">область, которую сохраняем</param>
        private void StoreImage(Bitmap b, string p, Rectangle r)
        {
            Bitmap t = b.Clone(r, b.PixelFormat);
            t.Save(p);
        }
  
        /// <summary>
        /// сохраняет картинку или её часть в файл
        /// </summary>
        /// <param name="b">картинка</param>
        /// <param name="p">путь куда сохранить</param>
        private void StoreImage(Bitmap b, string p)
        {
            b.Save(p);
        }
  
        /// <summary>
        /// разрезаем картинку на две части
        /// </summary>
        private void CutImageToParts()
        {
            int width = Bmp.Width;
            int height = Bmp.Height;
            // определим метод разрезания (верт/гор), определим прямоугольники
            if (width >= height)
            {
                int t = (width / 2) - 1;
                Parts[0].rect = new Rectangle(0, 0, t, height);
                Parts[1].rect = new Rectangle(t, 0, t, height);
            }
            else
            {
                int t = (height / 2) - 1;
                Parts[0].rect = new Rectangle(0, 0, width, t);
                Parts[1].rect = new Rectangle(0, t, width, t);
            }
            // разрежем картинку
            Parts[0].img = Bmp.Clone(Parts[0].rect, Bmp.PixelFormat);
            Parts[1].img = Bmp.Clone(Parts[1].rect, Bmp.PixelFormat);
        }
    }
}
