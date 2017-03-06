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
        // половины картинок
        public Bitmap Img1, Img2;
        // ответ
        public string Answer = "";

        // базовая картинка
        private Bitmap Bmp;
        private Part[] Parts = new Part[2];
        private int LineLen = 0;
        // смещения
        private int shift_hor, shift_ver;
        // размер сетки
        private int rows, columns;
        
        private Block[] blocks;
        // настройки
        private Settings settings;

        // структура настроек
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
        private string answ_lett = "";

        // структура для половинки картинки
        public struct Part
        {
            public Rectangle rect;
            public Bitmap img;
            public Rectangle rect_shift;
            public Bitmap img_shift;
            public byte[] ba;
            public bool[] grid_lines, grid_columns;
            public TwoWhiteArray twa;
            public Bound BoundLetterLeft, BoundLetterUp;
            public List<Bound> BoundsLeftRight, BoundsUpDown;
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
        }
        /// <summary>
        /// структура для массива количества белого цвета по строкам и столбцам
        /// </summary>
        public struct TwoWhiteArray
        {
            public int[] cols, rows;
        }
        public struct Block
        {
            public int num;
            public long diff;
            public long[] diff25;
            public long[] diff25_cnt;
            public long max25;
            public Rectangle rect;
            public Block(int i, long d)
            {
                num = i;
                diff = d;
                diff25 = new long[25];
                diff25_cnt = new long[25];
                max25 = 0;
                rect = new Rectangle(0, 0, 1, 1);
            }
        }

        /// <summary>
        /// структура хэша отличий
        /// </summary>
        private struct BoundHash
        {
            public int min, max, avg, min_cnt, max_cnt, high_cnt, low_cnt;
            public BoundHash(int imin, int imax, int iavg)
            {
                min = imin;
                max = imax;
                avg = iavg;
                min_cnt = 0;
                max_cnt = 0;
                low_cnt = 0;
                high_cnt = 0;
            }
        }

        // константы
        private const int BmpHeader = 54;

        // параметры для подгонки эффективности

        // = 1, иначе ошибки совсем
        //private int DetectGridOne_ArrSumMultiplier = 1; // поиск сетки по строкам/столбцам, отсечение ошибок до сравнения на белый цвет

        private int FindCommonShift_shift2 = 5; // общий сдвиг, сдвиг поиска вокруг найденных пересечений
        private int FindDiffsByShiftsOne_CutPart = 5; // часть (1/х) половинок, для поиска соответствия в одном пересечении
        private int GetLineDiffArr_max_shift = 3; // часть (1/х) строк, по которым ищем сдвиг
        //public int FindLetterBounds_start = 30; // с какой позиции искать границу окончения первой буквы
        //public int FindGrid_SkipPointsAroundLetters = 2; // точек пропустить от границ букв 2-3 где-то так
        private float GetBounds_AllowSizeMultiplier = 1.5f; // допустимые изменения размеров блоков
        //public float DetectGridOne_MaxDiffPeakMultiplier = 1.3f; // максимальная разница в пиках
        //public int FindGrid_AllowedWhitePixels = 3; // сколько может быть белых пикселей в сетке
        private int GetWhiteBound_PortionWhiteBound1000 = 10; // доля +- точек для определения границ белого по краям
        private int GetWhiteBound_PortionWhiteBound1000_0 = 5; // доля +- точек для определения границ белого по краям (1% = 10)
        private bool CorrectGridBorder_flag = true; // (true/false) - корректировать сетку на 1 пиксель шире?
        private int GetMinBlock_criteria = 1; // 1/9/16/25 - критерий выбора минимального блока

        private int FindOneDiff_shift_compare = 1; // сдвиг поиска в одной ячейке
        //public int CalculateDifference_Variant = 8; // вариант расчета различий ячеек
        //public int v81_level = 500; // ниже это различия мы не считаем различием. для v8_1
        //public int v82_level = 5; // ниже это различия мы не считаем различием. для v8_2
        //public int v83_level = 50; // ниже это различия мы не считаем различием. для v8_3


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

        /* пробы вариантов
            //  +  / -  / all -  0,0% - options
            // 161 / 26 / 187 - 86,1% - 25, shift_compare=8, v1 (!), 60,0сек

            // 152 / 35 / 187 - 81,3% - 25, shift_compare=0, v2, 0,6сек
            // 150 / 37 / 187 - 80,2% - 25, shift_compare=0, v3, 0,6сек
            // 155 / 32 / 187 - 82,9% - 25, shift_compare=0, v4, 0,6сек
            // 153 / 34 / 187 - 81,8% - 25, shift_compare=0, v5, 0,6сек
            // 120 / 67 / 187 - 64,2% - 25, shift_compare=0, v6, 1,0сек
            // 155 / 32 / 187 - 82,9% - 25, shift_compare=0, v7, 0,6сек
            // 161 / 26 / 187 - 86,1% - 25, shift_compare=1, v8, 0,6сек
            // 144 / 43 / 187 - 77,0% - 25, shift_compare=1, v9, 0,6сек

            // 157 / 30 / 187 - 84,0% - 25, shift_compare=1, v2, 1,0сек
            // 155 / 32 / 187 - 82,9% - 25, shift_compare=1, v3, 1,0сек
            // 156 / 31 / 187 - 83,4% - 25, shift_compare=1, v4, 1,0сек
            // 155 / 32 / 187 - 82,9% - 25, shift_compare=1, v5, 1,0сек
            // 124 / 63 / 187 - 66,3% - 25, shift_compare=1, v6, 4,0сек
            // 159 / 28 / 187 - 85,0% - 25, shift_compare=1, v7, 0,6сек
            // 162 / 25 / 187 - 86,6% - 25, shift_compare=1, v8, 0,6сек
            // 151 / 36 / 187 - 80,1% - 25, shift_compare=1, v9, 0,6сек
            // v8 - более прогрессивный

            // 162 / 25 / 187 - 86,6% - 25, shift_compare=1, v8, 0,6сек
            // 166 / 21 / 187 - 88,8% - 25, shift_compare=1, v8, CorrectGridBorder_flag, 0,6сек (!)
            // 166 / 21 / 187 - 88,8% - 25, shift_compare=1, v8, CorrectGridBorder_flag, criteria = 25, 0,6сек
            // 161 / 26 / 187 - 86,1% - 25, shift_compare=1, v8, criteria = 25, 0,6сек
            // критерий не роляет. CorrectGridBorder_flag - роляет.

            // 166 / 21 / 187 - 88,8% - 25, shift_compare=1, v8, CorrectGridBorder_flag, 0,6сек
            // 150 / 37 / 187 - 80,2% - 1, shift_compare=1, v8, CorrectGridBorder_flag, 0,6сек
            // искать одним блоком - плохая идея

            // 163 / 24 / 187 - 87,2% - 25, shift_compare=0, v8, CorrectGridBorder_flag, 0,5сек
            // 166 / 21 / 187 - 88,8% - 25, shift_compare=1, v8, CorrectGridBorder_flag, 0,6сек
            // 166 / 21 / 187 - 88,8% - 25, shift_compare=2, v8, CorrectGridBorder_flag, 1,0сек
            // 160 / 27 / 187 - 85,6% - 25, shift_compare=3, v8, CorrectGridBorder_flag, 1,5сек
            // shift_compare=1

            // 166 / 21 / 187 - 88,8% - 25, shift_compare=1, v8, CorrectGridBorder_flag, 0,6сек
            // 150 / 37 / 187 - 80,2% - 25, shift_compare=1, v9, CorrectGridBorder_flag, 1,0сек
            // bad / bad / 187 - 0,8% - 25, shift_compare=1, v10, CorrectGridBorder_flag, 0,0сек
            // bad / bad / 187 - 0,8% - 25, shift_compare=1, v11, CorrectGridBorder_flag, 0,0сек
            // 125 / 62 / 187 - 66,8% - 25, shift_compare=1, v12, CorrectGridBorder_flag, 0,6сек
            // 83 / 104 / 187 - 44,4% - 25, shift_compare=1, v13, CorrectGridBorder_flag, 0,6сек

            // 166 / 21 / 187 - 88,8% - 25, shift_compare=1, v81, v81_level=1-200, CorrectGridBorder_flag, 1,0сек
            // 165 / 22 / 187 - 88,2% - 25, shift_compare=1, v81, v81_level=500,   CorrectGridBorder_flag, 1,0сек
            // 162 / 25 / 187 - 86,6% - 25, shift_compare=1, v81, v81_level=1000,  CorrectGridBorder_flag, 1,0сек
            // 160 / 27 / 187 - 85,6% - 25, shift_compare=1, v82, v82_level=5,     CorrectGridBorder_flag, 1,0сек
            // 160 / 27 / 187 - 85,6% - 25, shift_compare=1, v82, v82_level=10,    CorrectGridBorder_flag, 1,0сек
            // 165 / 22 / 187 - 88,2% - 25, shift_compare=1, v83, v83_level=5,     CorrectGridBorder_flag, 1,0сек
            // 165 / 22 / 187 - 88,2% - 25, shift_compare=1, v83, v83_level=10,    CorrectGridBorder_flag, 1,0сек
            // 165 / 22 / 187 - 88,2% - 25, shift_compare=1, v83, v83_level=20,    CorrectGridBorder_flag, 1,0сек
            // 158 / 29 / 187 - 84,5% - 25, shift_compare=1, v83, v83_level=50,    CorrectGridBorder_flag, 1,0сек
         */

        /// <summary>
        /// формирует ответ
        /// </summary>
        private void DoAnswer()
        {
            // 2Do: (!)
            // засечь время работы при компиляции в ОпКод или х86-32бит

            // 166 / 21 / 187 - 88,8% - 25, shift_compare=1, v8,                   CorrectGridBorder_flag, 1,0сек

            Block[] sorted = SortBlocks(25);
            int[] Five = GetFiveBlockIndexes(sorted);
            Answer = GetAnswer(Five);
            DrawSquaresOnImages(sorted, 5, 5);
        }

        /// <summary>
        /// выполняет отрисовку на Img1/Img2 блоков двумя цветами. количества блоков = cnt1/cnt2
        /// первые cnt1 блоков - красным цветом, следующие cnt2 блоков - желтым
        /// </summary>
        /// <param name="bl">сортированный массив блоков</param>
        /// <param name="cnt1">сколько красных вначале</param>
        /// <param name="cnt2">сколько желтых за красными</param>
        private void DrawSquaresOnImages(Block[] bl, int cnt1, int cnt2)
        {
            int cnt = bl.Length;
            for (int i = 0; i < cnt; i++)
            {
                if (i < cnt1) { DrawRectangle(bl[i].rect, Color.Red); }
                if ((i >= cnt1) && (i < cnt1+cnt2)) { DrawRectangle(bl[i].rect, Color.Yellow); }
            }
        }

        /// <summary>
        /// отрсовывает прямоугольник нужного цвета на Img1/Img2
        /// </summary>
        /// <param name="rect">прямоугольник</param>
        /// <param name="col">цвет</param>
        private void DrawRectangle(Rectangle rect, Color col)
        {
            Graphics g1 = Graphics.FromImage(Img1);
            Graphics g2 = Graphics.FromImage(Img2);
            Rectangle rect2 = new Rectangle(rect.Left + 1, rect.Top + 1, rect.Width - 2, rect.Height - 2);
            g1.DrawRectangle(new Pen(col), rect);
            g2.DrawRectangle(new Pen(col), rect);
            g1.DrawRectangle(new Pen(col), rect2);
            g2.DrawRectangle(new Pen(col), rect2);

        }

        /// <summary>
        /// находит различие в одной ячейке
        /// </summary>
        /// <param name="r">строка</param>
        /// <param name="c">колонка</param>
        /// <param name="l1">1 часть - левый</param>
        /// <param name="u1">1 часть - верхний</param>
        /// <param name="l2">2 часть - левый</param>
        /// <param name="u2">2 часть - верхний</param>
        /// <param name="w">ширина</param>
        /// <param name="h">высота</param>
        /// <returns>отличия</returns>
        private Block FindOneDiffShift(int r, int c, int sh_w, int sh_h)
        {
            // разнца сдвигов картинки и сетки + наш сдвиг, текущий
            int shift_w = (Parts[1].BoundsLeftRight[c].start - Parts[0].BoundsLeftRight[c].start) - shift_hor + sh_w;
            int shift_h = (Parts[1].BoundsUpDown[r].start - Parts[0].BoundsUpDown[r].start) - shift_ver + sh_h;
            
            // координаты ячеек
            int p1_l = Parts[0].BoundsLeftRight[c].start;
            int p1_r = Parts[0].BoundsLeftRight[c].end;
            int p1_u = Parts[0].BoundsUpDown[r].start;
            int p1_d = Parts[0].BoundsUpDown[r].end;
            int p2_l = Parts[1].BoundsLeftRight[c].start;
            int p2_r = Parts[1].BoundsLeftRight[c].end;
            int p2_u = Parts[1].BoundsUpDown[r].start;
            int p2_d = Parts[1].BoundsUpDown[r].end;
            if (sh_w < 0)
            {
                p2_r -= shift_w;
                if (sh_h < 0) { p2_d -= shift_h; } else { p1_u += shift_h; }
            }
            else
            {
                p1_l += shift_w;
                if (sh_h < 0) { p2_d -= shift_h; } else { p1_u += shift_h; }
            }

            int w = Math.Min(p1_r - p1_l, p2_r - p2_l);
            int h = Math.Min(p1_d - p1_u, p2_d - p2_u);
            p1_r = p1_l + w;
            p1_d = p1_u + h;
            p2_r = p2_l + w;
            p2_d = p2_u + h;
            int sw = p2_l - p1_l;
            int sh = p2_u - p1_u;
            int w5 = w / 5 + 1;
            int h5 = h / 5 + 1;

            return CalculateDifference_v8(r, c, p1_l, p1_r, p1_u, p1_d, sw, sh, w5, h5);
            /*
            if (CalculateDifference_Variant == 2) { return CalculateDifference_v2(r, c, p1_l, p1_r, p1_u, p1_d, sw, sh, w5, h5); }
            if (CalculateDifference_Variant == 3) { return CalculateDifference_v3(r, c, p1_l, p1_r, p1_u, p1_d, sw, sh, w5, h5); }
            if (CalculateDifference_Variant == 4) { return CalculateDifference_v4(r, c, p1_l, p1_r, p1_u, p1_d, sw, sh, w5, h5); }
            if (CalculateDifference_Variant == 5) { return CalculateDifference_v5(r, c, p1_l, p1_r, p1_u, p1_d, sw, sh, w5, h5); }
            if (CalculateDifference_Variant == 6) { return CalculateDifference_v6(r, c, p1_l, p1_r, p1_u, p1_d, sw, sh, w5, h5); }
            if (CalculateDifference_Variant == 7) { return CalculateDifference_v7(r, c, p1_l, p1_r, p1_u, p1_d, sw, sh, w5, h5); }
            if (CalculateDifference_Variant == 8) { return CalculateDifference_v8(r, c, p1_l, p1_r, p1_u, p1_d, sw, sh, w5, h5); }
            if (CalculateDifference_Variant == 9) { return CalculateDifference_v9(r, c, p1_l, p1_r, p1_u, p1_d, sw, sh, w5, h5); }
            if (CalculateDifference_Variant == 10) { return CalculateDifference_v10(r, c, p1_l, p1_r, p1_u, p1_d, sw, sh, w5, h5); }
            if (CalculateDifference_Variant == 11) { return CalculateDifference_v11(r, c, p1_l, p1_r, p1_u, p1_d, sw, sh, w5, h5); }
            if (CalculateDifference_Variant == 12) { return CalculateDifference_v12(r, c, p1_l, p1_r, p1_u, p1_d, sw, sh, w5, h5); }
            if (CalculateDifference_Variant == 13) { return CalculateDifference_v13(r, c, p1_l, p1_r, p1_u, p1_d, sw, sh, w5, h5); }
            if (CalculateDifference_Variant == 81) { return CalculateDifference_v8_1(r, c, p1_l, p1_r, p1_u, p1_d, sw, sh, w5, h5); }
            if (CalculateDifference_Variant == 82) { return CalculateDifference_v8_2(r, c, p1_l, p1_r, p1_u, p1_d, sw, sh, w5, h5); }
            if (CalculateDifference_Variant == 83) { return CalculateDifference_v8_3(r, c, p1_l, p1_r, p1_u, p1_d, sw, sh, w5, h5); }
            */

            //для теста надо бы сохранять ячейки в файлы
            /*
            string name = "_r" + r.ToString() + "_c" + c.ToString() + "_shw" + sh_w.ToString() + "_shh" + sh_h.ToString() + "_res" + res.diff.ToString();
            string name1 = @"C:\TEMP\1\img_" + name + "_p0.jpg";
            string name2 = @"C:\TEMP\1\img_" + name + "_p1.jpg";
            StoreImage(Parts[0].img, name1, new Rectangle(p1_l, p1_u, w, h));
            StoreImage(Parts[1].img, name2, new Rectangle(p2_l, p2_u, w, h));
            */

            //return new Block(r * columns + c, 0);
        }

        // здесь и ниже - варианты расчета отличий.
        private Block CalculateDifference_v8(int r, int c, int p1_l, int p1_r, int p1_u, int p1_d, int sw, int sh, int w5, int h5)
        {
            int hh = Parts[0].img.Height - 1;

            Block res = new Block(r * columns + c, 0);
            res.rect = new Rectangle(p1_l, p1_u, p1_r-p1_l, p1_d-p1_u);

            int[] c1_r = new int[25];
            int[] c1_g = new int[25];
            int[] c1_b = new int[25];
            int[] c2_r = new int[25];
            int[] c2_g = new int[25];
            int[] c2_b = new int[25];

            for (int i = p1_l; i < p1_r; i++)
            {
                if (Parts[0].grid_columns[i]) { continue; }
                int i2 = i + sw;
                if (Parts[1].grid_columns[i2]) { continue; }
                for (int j = p1_u; j < p1_d; j++)
                {
                    if (Parts[0].grid_lines[j]) { continue; }
                    int j2 = j + sh;
                    if (Parts[1].grid_lines[j2]) { continue; }

                    int idx1 = GetIndexByXY(i, hh - j);
                    int idx2 = GetIndexByXY(i2, hh - j2);

                    int idx25 = ((i - p1_l) / w5) * 5 + ((j - p1_u) / h5);

                    c1_r[idx25] += Parts[0].ba[idx1 + 0];
                    c1_g[idx25] += Parts[0].ba[idx1 + 1];
                    c1_b[idx25] += Parts[0].ba[idx1 + 2];
                    c2_r[idx25] += Parts[1].ba[idx2 + 0];
                    c2_g[idx25] += Parts[1].ba[idx2 + 1];
                    c2_b[idx25] += Parts[1].ba[idx2 + 2];

                    res.diff25_cnt[idx25]++;
                }
            }
            res.diff = 0;
            for (int iii = 0; iii < 25; iii++)
            {
                res.diff25[iii] = Math.Abs(c1_r[iii] - c2_r[iii]) + Math.Abs(c1_g[iii] - c2_g[iii]) + Math.Abs(c1_b[iii] - c2_b[iii]);
                res.diff += res.diff25[iii];
            }
            res.max25 = 0; for (int iii = 0; iii < 25; iii++) { if (res.max25 < res.diff25[iii]) { res.max25 = res.diff25[iii]; } }
            return res;
        }
        /* менее удачные варианты
        public Block CalculateDifference_v2(int r, int c, int p1_l, int p1_r, int p1_u, int p1_d, int sw, int sh, int w5, int h5)
        {
            int hh = Parts[0].img.Height - 1;

            Block res = new Block(r * columns + c, 0);

            for (int i = p1_l; i < p1_r; i++)
            {
                if (Parts[0].grid_columns[i]) { continue; }
                int i2 = i + sw;
                if (Parts[1].grid_columns[i2]) { continue; }
                for (int j = p1_u; j < p1_d; j++)
                {
                    if (Parts[0].grid_lines[j]) { continue; }
                    int j2 = j + sh;
                    if (Parts[1].grid_lines[j2]) { continue; }

                    int idx1 = GetIndexByXY(i, hh - j);
                    int idx2 = GetIndexByXY(i2, hh - j2);

                    int res_pixel = Math.Abs(Parts[0].ba[idx1 + 0] - Parts[1].ba[idx2 + 0]);
                    res_pixel = res_pixel + Math.Abs(Parts[0].ba[idx1 + 1] - Parts[1].ba[idx2 + 1]);
                    res_pixel = res_pixel + Math.Abs(Parts[0].ba[idx1 + 2] - Parts[1].ba[idx2 + 2]);

                    res.diff += res_pixel;
                    int idx25 = ((i - p1_l) / w5) * 5 + ((j - p1_u) / h5);
                    res.diff25[idx25] += res_pixel;
                    res.diff25_cnt[idx25]++;
                }
            }
            res.max25 = 0; for (int iii = 0; iii < 25; iii++) { if (res.max25 < res.diff25[iii]) { res.max25 = res.diff25[iii]; } }
            return res;
        }
        public Block CalculateDifference_v3(int r, int c, int p1_l, int p1_r, int p1_u, int p1_d, int sw, int sh, int w5, int h5)
        {
            int hh = Parts[0].img.Height - 1;

            Block res = new Block(r * columns + c, 0);

            for (int i = p1_l; i < p1_r; i++)
            {
                if (Parts[0].grid_columns[i]) { continue; }
                int i2 = i + sw;
                if (Parts[1].grid_columns[i2]) { continue; }
                for (int j = p1_u; j < p1_d; j++)
                {
                    if (Parts[0].grid_lines[j]) { continue; }
                    int j2 = j + sh;
                    if (Parts[1].grid_lines[j2]) { continue; }

                    int idx1 = GetIndexByXY(i, hh - j);
                    int idx2 = GetIndexByXY(i2, hh - j2);

                    int res_pixel = Math.Abs(Parts[0].ba[idx1 + 0] - Parts[1].ba[idx2 + 0]);
                    res_pixel = res_pixel + Math.Abs(Parts[0].ba[idx1 + 1] - Parts[1].ba[idx2 + 1]);
                    res_pixel = res_pixel + Math.Abs(Parts[0].ba[idx1 + 2] - Parts[1].ba[idx2 + 2]);

                    res.diff += res_pixel;
                    int idx25 = ((i - p1_l) / w5) * 5 + ((j - p1_u) / h5);
                    res.diff25[idx25] += res_pixel;
                    res.diff25_cnt[idx25]++;
                }
            }
            res.max25 = 0; for (int iii = 0; iii < 25; iii++) { if (res.diff25_cnt[iii] != 0) { if (res.max25 < res.diff25[iii] / res.diff25_cnt[iii]) { res.max25 = res.diff25[iii] / res.diff25_cnt[iii]; } } }
            return res;
        }
        public Block CalculateDifference_v4(int r, int c, int p1_l, int p1_r, int p1_u, int p1_d, int sw, int sh, int w5, int h5)
        {
            int hh = Parts[0].img.Height - 1;

            Block res = new Block(r * columns + c, 0);

            for (int i = p1_l; i < p1_r; i++)
            {
                if (Parts[0].grid_columns[i]) { continue; }
                int i2 = i + sw;
                if (Parts[1].grid_columns[i2]) { continue; }
                for (int j = p1_u; j < p1_d; j++)
                {
                    if (Parts[0].grid_lines[j]) { continue; }
                    int j2 = j + sh;
                    if (Parts[1].grid_lines[j2]) { continue; }

                    int idx1 = GetIndexByXY(i, hh - j);
                    int idx2 = GetIndexByXY(i2, hh - j2);

                    long pp = (Parts[0].ba[idx1 + 0] - Parts[1].ba[idx2 + 0]) * (Parts[0].ba[idx1 + 0] - Parts[1].ba[idx2 + 0]) +
                        (Parts[0].ba[idx1 + 1] - Parts[1].ba[idx2 + 1]) * (Parts[0].ba[idx1 + 1] - Parts[1].ba[idx2 + 1]) +
                        (Parts[0].ba[idx1 + 2] - Parts[1].ba[idx2 + 2]) * (Parts[0].ba[idx1 + 2] - Parts[1].ba[idx2 + 2]);
                    int res_pixel = (int)Math.Sqrt(pp);

                    res.diff += res_pixel;
                    int idx25 = ((i - p1_l) / w5) * 5 + ((j - p1_u) / h5);
                    res.diff25[idx25] += res_pixel;
                    res.diff25_cnt[idx25]++;
                }
            }
            res.max25 = 0; for (int iii = 0; iii < 25; iii++) { if (res.max25 < res.diff25[iii]) { res.max25 = res.diff25[iii]; } }
            return res;
        }
        public Block CalculateDifference_v5(int r, int c, int p1_l, int p1_r, int p1_u, int p1_d, int sw, int sh, int w5, int h5)
        {
            int hh = Parts[0].img.Height - 1;

            Block res = new Block(r * columns + c, 0);

            for (int i = p1_l; i < p1_r; i++)
            {
                if (Parts[0].grid_columns[i]) { continue; }
                int i2 = i + sw;
                if (Parts[1].grid_columns[i2]) { continue; }
                for (int j = p1_u; j < p1_d; j++)
                {
                    if (Parts[0].grid_lines[j]) { continue; }
                    int j2 = j + sh;
                    if (Parts[1].grid_lines[j2]) { continue; }

                    int idx1 = GetIndexByXY(i, hh - j);
                    int idx2 = GetIndexByXY(i2, hh - j2);

                    long pp = (Parts[0].ba[idx1 + 0] - Parts[1].ba[idx2 + 0]) * (Parts[0].ba[idx1 + 0] - Parts[1].ba[idx2 + 0]) +
                        (Parts[0].ba[idx1 + 1] - Parts[1].ba[idx2 + 1]) * (Parts[0].ba[idx1 + 1] - Parts[1].ba[idx2 + 1]) +
                        (Parts[0].ba[idx1 + 2] - Parts[1].ba[idx2 + 2]) * (Parts[0].ba[idx1 + 2] - Parts[1].ba[idx2 + 2]);
                    int res_pixel = (int)Math.Sqrt(pp);

                    res.diff += res_pixel;
                    int idx25 = ((i - p1_l) / w5) * 5 + ((j - p1_u) / h5);
                    res.diff25[idx25] += res_pixel;
                    res.diff25_cnt[idx25]++;
                }
            }
            res.max25 = 0; for (int iii = 0; iii < 25; iii++) { if (res.diff25_cnt[iii] != 0) { if (res.max25 < res.diff25[iii] / res.diff25_cnt[iii]) { res.max25 = res.diff25[iii] / res.diff25_cnt[iii]; } } }
            return res;
        }
        public Block CalculateDifference_v6(int r, int c, int p1_l, int p1_r, int p1_u, int p1_d, int sw, int sh, int w5, int h5)
        {
            int hh = Parts[0].img.Height - 1;

            Block res = new Block(r * columns + c, 0);

            for (int i = p1_l; i < p1_r; i++)
            {
                if (Parts[0].grid_columns[i]) { continue; }
                int i2 = i + sw;
                if (Parts[1].grid_columns[i2]) { continue; }
                for (int j = p1_u; j < p1_d; j++)
                {
                    if (Parts[0].grid_lines[j]) { continue; }
                    int j2 = j + sh;
                    if (Parts[1].grid_lines[j2]) { continue; }

                    int idx1 = GetIndexByXY(i, hh - j);
                    int idx2 = GetIndexByXY(i2, hh - j2);

                    Color c1 = Color.FromArgb(Parts[0].ba[idx1 + 2], Parts[0].ba[idx1 + 1], Parts[0].ba[idx1 + 0]);
                    Color c2 = Color.FromArgb(Parts[1].ba[idx2 + 2], Parts[1].ba[idx2 + 1], Parts[1].ba[idx2 + 0]);
                    float c1_b = 360 * c1.GetBrightness();
                    float c2_b = 360 * c2.GetBrightness();
                    float c1_s = 360 * c1.GetSaturation();
                    float c2_s = 360 * c2.GetSaturation();
                    float c1_h = c1.GetHue();
                    float c2_h = c2.GetHue();

                    float ch = Math.Abs(c1.GetHue() - c2.GetHue());
                    float cs = Math.Abs(c1.GetSaturation() - c2.GetSaturation());
                    float cb = Math.Abs(c1.GetBrightness() - c2.GetBrightness());
                    int res_pixel = (int)(360 * cb);

                    res.diff += res_pixel;
                    int idx25 = ((i - p1_l) / w5) * 5 + ((j - p1_u) / h5);
                    res.diff25[idx25] += res_pixel;
                    res.diff25_cnt[idx25]++;
                }
            }
            res.max25 = 0; for (int iii = 0; iii < 25; iii++) { if (res.max25 < res.diff25[iii] ) { res.max25 = res.diff25[iii]; } }
            return res;
        }
        public Block CalculateDifference_v7(int r, int c, int p1_l, int p1_r, int p1_u, int p1_d, int sw, int sh, int w5, int h5)
        {
            int hh = Parts[0].img.Height - 1;

            Block res = new Block(r * columns + c, 0);

            int[] c1_r = new int[25];
            int[] c1_g = new int[25];
            int[] c1_b = new int[25];
            int[] c2_r = new int[25];
            int[] c2_g = new int[25];
            int[] c2_b = new int[25];

            for (int i = p1_l; i < p1_r; i++)
            {
                if (Parts[0].grid_columns[i]) { continue; }
                int i2 = i + sw;
                if (Parts[1].grid_columns[i2]) { continue; }
                for (int j = p1_u; j < p1_d; j++)
                {
                    if (Parts[0].grid_lines[j]) { continue; }
                    int j2 = j + sh;
                    if (Parts[1].grid_lines[j2]) { continue; }

                    int idx1 = GetIndexByXY(i, hh - j);
                    int idx2 = GetIndexByXY(i2, hh - j2);

                    int idx25 = ((i - p1_l) / w5) * 5 + ((j - p1_u) / h5);

                    c1_r[idx25] += Parts[0].ba[idx1 + 0];
                    c1_g[idx25] += Parts[0].ba[idx1 + 1];
                    c1_b[idx25] += Parts[0].ba[idx1 + 2];
                    c2_r[idx25] += Parts[1].ba[idx2 + 0];
                    c2_g[idx25] += Parts[1].ba[idx2 + 1];
                    c2_b[idx25] += Parts[1].ba[idx2 + 2];

                    res.diff25_cnt[idx25]++;
                }
            }
            res.diff = 0;
            for (int iii = 0; iii < 25; iii++)
            {
                c1_r[iii] = c1_r[iii] / (int)res.diff25_cnt[iii];
                c1_g[iii] = c1_g[iii] / (int)res.diff25_cnt[iii];
                c1_b[iii] = c1_b[iii] / (int)res.diff25_cnt[iii];
                c2_r[iii] = c2_r[iii] / (int)res.diff25_cnt[iii];
                c2_g[iii] = c2_g[iii] / (int)res.diff25_cnt[iii];
                c2_b[iii] = c2_b[iii] / (int)res.diff25_cnt[iii];
                res.diff25[iii] = Math.Abs(c1_r[iii] - c2_r[iii]) + Math.Abs(c1_g[iii] - c2_g[iii]) + Math.Abs(c1_b[iii] - c2_b[iii]);
                res.diff += res.diff25[iii];
            }
            res.max25 = 0; for (int iii = 0; iii < 25; iii++) { if (res.max25 < res.diff25[iii]) { res.max25 = res.diff25[iii]; } }
            return res;
        }
        public Block CalculateDifference_v9(int r, int c, int p1_l, int p1_r, int p1_u, int p1_d, int sw, int sh, int w5, int h5)
        {
            int hh = Parts[0].img.Height - 1;

            Block res = new Block(r * columns + c, 0);

            int[] c1_r = new int[25];
            int[] c1_g = new int[25];
            int[] c1_b = new int[25];
            int[] c2_r = new int[25];
            int[] c2_g = new int[25];
            int[] c2_b = new int[25];

            for (int i = p1_l; i < p1_r; i++)
            {
                if (Parts[0].grid_columns[i]) { continue; }
                int i2 = i + sw;
                if (Parts[1].grid_columns[i2]) { continue; }
                for (int j = p1_u; j < p1_d; j++)
                {
                    if (Parts[0].grid_lines[j]) { continue; }
                    int j2 = j + sh;
                    if (Parts[1].grid_lines[j2]) { continue; }

                    int idx1 = GetIndexByXY(i, hh - j);
                    int idx2 = GetIndexByXY(i2, hh - j2);

                    int idx25 = ((i - p1_l) / w5) * 5 + ((j - p1_u) / h5);

                    c1_r[idx25] += Parts[0].ba[idx1 + 0];
                    c1_g[idx25] += Parts[0].ba[idx1 + 1];
                    c1_b[idx25] += Parts[0].ba[idx1 + 2];
                    c2_r[idx25] += Parts[1].ba[idx2 + 0];
                    c2_g[idx25] += Parts[1].ba[idx2 + 1];
                    c2_b[idx25] += Parts[1].ba[idx2 + 2];
                    int pixel = (int)Math.Sqrt((c1_r[idx25] - c2_r[idx25]) * (c1_r[idx25] - c2_r[idx25]) +
                        (c1_g[idx25] - c2_g[idx25]) * (c1_g[idx25] - c2_g[idx25]) +
                        (c1_b[idx25] - c2_b[idx25]) * (c1_b[idx25] - c2_b[idx25]));

                    res.diff25_cnt[idx25]++;
                    res.diff25[idx25] += pixel;
                    res.diff += pixel;
                }
            }
            res.max25 = 0; for (int iii = 0; iii < 25; iii++) { if (res.max25 < res.diff25[iii]) { res.max25 = res.diff25[iii]; } }
            return res;
        }
        public Block CalculateDifference_v10(int r, int c, int p1_l, int p1_r, int p1_u, int p1_d, int sw, int sh, int w5, int h5)
        {
            int hh = Parts[0].img.Height - 1;

            Block res = new Block(r * columns + c, 0);

            int[] c1_r = new int[25];
            int[] c1_g = new int[25];
            int[] c1_b = new int[25];
            int[] c2_r = new int[25];
            int[] c2_g = new int[25];
            int[] c2_b = new int[25];

            int[] minr = new int[25];
            int[] maxr = new int[25];
            int[] ming = new int[25];
            int[] maxg = new int[25];
            int[] minb = new int[25];
            int[] maxb = new int[25];
            for (int i = 0; i < 25; i++) { minr[i] = 9999999; ming[i] = 9999999; minb[i] = 9999999; }

            for (int i = p1_l; i < p1_r; i++)
            {
                if (Parts[0].grid_columns[i]) { continue; }
                int i2 = i + sw;
                if (Parts[1].grid_columns[i2]) { continue; }
                for (int j = p1_u; j < p1_d; j++)
                {
                    if (Parts[0].grid_lines[j]) { continue; }
                    int j2 = j + sh;
                    if (Parts[1].grid_lines[j2]) { continue; }

                    int idx1 = GetIndexByXY(i, hh - j);
                    int idx2 = GetIndexByXY(i2, hh - j2);

                    int idx25 = ((i - p1_l) / w5) * 5 + ((j - p1_u) / h5);

                    minr[idx25] = Math.Min(minr[idx25], Math.Min(Parts[0].ba[idx1 + 0], Parts[1].ba[idx2 + 0]));
                    ming[idx25] = Math.Min(ming[idx25], Math.Min(Parts[0].ba[idx1 + 1], Parts[1].ba[idx2 + 1]));
                    minb[idx25] = Math.Min(minb[idx25], Math.Min(Parts[0].ba[idx1 + 2], Parts[1].ba[idx2 + 2]));
                    maxr[idx25] = Math.Max(maxr[idx25], Math.Max(Parts[0].ba[idx1 + 0], Parts[1].ba[idx2 + 0]));
                    maxg[idx25] = Math.Max(maxg[idx25], Math.Max(Parts[0].ba[idx1 + 1], Parts[1].ba[idx2 + 1]));
                    maxb[idx25] = Math.Max(maxb[idx25], Math.Max(Parts[0].ba[idx1 + 2], Parts[1].ba[idx2 + 2]));
                }
            }

            for (int i = p1_l; i < p1_r; i++)
            {
                if (Parts[0].grid_columns[i]) { continue; }
                int i2 = i + sw;
                if (Parts[1].grid_columns[i2]) { continue; }
                for (int j = p1_u; j < p1_d; j++)
                {
                    if (Parts[0].grid_lines[j]) { continue; }
                    int j2 = j + sh;
                    if (Parts[1].grid_lines[j2]) { continue; }

                    int idx1 = GetIndexByXY(i, hh - j);
                    int idx2 = GetIndexByXY(i2, hh - j2);

                    int idx25 = ((i - p1_l) / w5) * 5 + ((j - p1_u) / h5);

                    c1_r[idx25] += (Parts[0].ba[idx1 + 0] - minr[idx25]) * 256 / (maxr[idx25] - minr[idx25]);
                    c1_g[idx25] += (Parts[0].ba[idx1 + 1] - ming[idx25]) * 256 / (maxg[idx25] - ming[idx25]);
                    c1_b[idx25] += (Parts[0].ba[idx1 + 2] - minb[idx25]) * 256 / (maxb[idx25] - minb[idx25]);
                    c2_r[idx25] += (Parts[1].ba[idx2 + 0] - minr[idx25]) * 256 / (maxr[idx25] - minr[idx25]);
                    c2_g[idx25] += (Parts[1].ba[idx2 + 1] - ming[idx25]) * 256 / (maxg[idx25] - ming[idx25]);
                    c2_b[idx25] += (Parts[1].ba[idx2 + 2] - minb[idx25]) * 256 / (maxb[idx25] - minb[idx25]);

                    res.diff25_cnt[idx25]++;
                }
            }
            res.diff = 0;
            for (int iii = 0; iii < 25; iii++)
            {
                res.diff25[iii] = Math.Abs(c1_r[iii] - c2_r[iii]) + Math.Abs(c1_g[iii] - c2_g[iii]) + Math.Abs(c1_b[iii] - c2_b[iii]);
                res.diff += res.diff25[iii];
            }
            res.max25 = 0; for (int iii = 0; iii < 25; iii++) { if (res.max25 < res.diff25[iii]) { res.max25 = res.diff25[iii]; } }
            return res;
        }
        public Block CalculateDifference_v11(int r, int c, int p1_l, int p1_r, int p1_u, int p1_d, int sw, int sh, int w5, int h5)
        {
            int hh = Parts[0].img.Height - 1;

            Block res = new Block(r * columns + c, 0);

            int[] c1_r = new int[25];
            int[] c1_g = new int[25];
            int[] c1_b = new int[25];
            int[] c2_r = new int[25];
            int[] c2_g = new int[25];
            int[] c2_b = new int[25];

            int[] minr = new int[25];
            int[] maxr = new int[25];
            int[] ming = new int[25];
            int[] maxg = new int[25];
            int[] minb = new int[25];
            int[] maxb = new int[25];
            for (int i = 0; i < 25; i++) { minr[i] = 9999999; ming[i] = 9999999; minb[i] = 9999999; }

            for (int i = p1_l; i < p1_r; i++)
            {
                if (Parts[0].grid_columns[i]) { continue; }
                int i2 = i + sw;
                if (Parts[1].grid_columns[i2]) { continue; }
                for (int j = p1_u; j < p1_d; j++)
                {
                    if (Parts[0].grid_lines[j]) { continue; }
                    int j2 = j + sh;
                    if (Parts[1].grid_lines[j2]) { continue; }

                    int idx1 = GetIndexByXY(i, hh - j);
                    int idx2 = GetIndexByXY(i2, hh - j2);

                    int idx25 = ((i - p1_l) / w5) * 5 + ((j - p1_u) / h5);

                    minr[idx25] = Math.Min(minr[idx25], Math.Min(Parts[0].ba[idx1 + 0], Parts[1].ba[idx2 + 0]));
                    ming[idx25] = Math.Min(ming[idx25], Math.Min(Parts[0].ba[idx1 + 1], Parts[1].ba[idx2 + 1]));
                    minb[idx25] = Math.Min(minb[idx25], Math.Min(Parts[0].ba[idx1 + 2], Parts[1].ba[idx2 + 2]));
                    maxr[idx25] = Math.Max(maxr[idx25], Math.Max(Parts[0].ba[idx1 + 0], Parts[1].ba[idx2 + 0]));
                    maxg[idx25] = Math.Max(maxg[idx25], Math.Max(Parts[0].ba[idx1 + 1], Parts[1].ba[idx2 + 1]));
                    maxb[idx25] = Math.Max(maxb[idx25], Math.Max(Parts[0].ba[idx1 + 2], Parts[1].ba[idx2 + 2]));
                }
            }

            for (int i = p1_l; i < p1_r; i++)
            {
                if (Parts[0].grid_columns[i]) { continue; }
                int i2 = i + sw;
                if (Parts[1].grid_columns[i2]) { continue; }
                for (int j = p1_u; j < p1_d; j++)
                {
                    if (Parts[0].grid_lines[j]) { continue; }
                    int j2 = j + sh;
                    if (Parts[1].grid_lines[j2]) { continue; }

                    int idx1 = GetIndexByXY(i, hh - j);
                    int idx2 = GetIndexByXY(i2, hh - j2);

                    int idx25 = ((i - p1_l) / w5) * 5 + ((j - p1_u) / h5);

                    c1_r[idx25] += (Parts[0].ba[idx1 + 0] - minr[idx25]) * 256 / (maxr[idx25] - minr[idx25]);
                    c1_g[idx25] += (Parts[0].ba[idx1 + 1] - ming[idx25]) * 256 / (maxg[idx25] - ming[idx25]);
                    c1_b[idx25] += (Parts[0].ba[idx1 + 2] - minb[idx25]) * 256 / (maxb[idx25] - minb[idx25]);
                    c2_r[idx25] += (Parts[1].ba[idx2 + 0] - minr[idx25]) * 256 / (maxr[idx25] - minr[idx25]);
                    c2_g[idx25] += (Parts[1].ba[idx2 + 1] - ming[idx25]) * 256 / (maxg[idx25] - ming[idx25]);
                    c2_b[idx25] += (Parts[1].ba[idx2 + 2] - minb[idx25]) * 256 / (maxb[idx25] - minb[idx25]);

                    res.diff25_cnt[idx25]++;
                }
            }
            res.diff = 0;
            for (int iii = 0; iii < 25; iii++)
            {
                res.diff25[iii] = Math.Abs(c1_r[iii] - c2_r[iii]) + Math.Abs(c1_g[iii] - c2_g[iii]) + Math.Abs(c1_b[iii] - c2_b[iii]);
                res.diff += res.diff25[iii];
            }
            res.max25 = 0; for (int iii = 0; iii < 25; iii++) { if (res.diff25_cnt[iii] != 0) { if (res.max25 < res.diff25[iii] / res.diff25_cnt[iii]) { res.max25 = res.diff25[iii] / res.diff25_cnt[iii]; } } }
            return res;
        }
        public Block CalculateDifference_v12(int r, int c, int p1_l, int p1_r, int p1_u, int p1_d, int sw, int sh, int w5, int h5)
        {
            int hh = Parts[0].img.Height - 1;

            Block res = new Block(r * columns + c, 0);

            int[,,] dat = new int[25, 2, 64];

            for (int i = p1_l; i < p1_r; i++)
            {
                if (Parts[0].grid_columns[i]) { continue; }
                int i2 = i + sw;
                if (Parts[1].grid_columns[i2]) { continue; }
                for (int j = p1_u; j < p1_d; j++)
                {
                    if (Parts[0].grid_lines[j]) { continue; }
                    int j2 = j + sh;
                    if (Parts[1].grid_lines[j2]) { continue; }

                    int idx1 = GetIndexByXY(i, hh - j);
                    int idx2 = GetIndexByXY(i2, hh - j2);
                    int c1 = GetColor6bit(Parts[0].ba, idx1);
                    int c2 = GetColor6bit(Parts[1].ba, idx2);
                    int idx25 = ((i - p1_l) / w5) * 5 + ((j - p1_u) / h5);
                    dat[idx25, 0, c1]++;
                    dat[idx25, 1, c2]++;
                }
            }
            res.diff = 0;
            for (int iii = 0; iii < 25; iii++)
            {
                for (int j = 0; j < 64; j++)
                {
                    res.diff25[iii] += Math.Abs(dat[iii, 0, j] - dat[iii, 1, j]);
                }
                res.diff += res.diff25[iii];
            }
            res.max25 = 0; for (int iii = 0; iii < 25; iii++) { if (res.max25 < res.diff25[iii]) { res.max25 = res.diff25[iii]; } }
            return res;
        }
        public Block CalculateDifference_v13(int r, int c, int p1_l, int p1_r, int p1_u, int p1_d, int sw, int sh, int w5, int h5)
        {
            int hh = Parts[0].img.Height - 1;

            Block res = new Block(r * columns + c, 0);

            int[,,] dat = new int[25, 2, 8];

            for (int i = p1_l; i < p1_r; i++)
            {
                if (Parts[0].grid_columns[i]) { continue; }
                int i2 = i + sw;
                if (Parts[1].grid_columns[i2]) { continue; }
                for (int j = p1_u; j < p1_d; j++)
                {
                    if (Parts[0].grid_lines[j]) { continue; }
                    int j2 = j + sh;
                    if (Parts[1].grid_lines[j2]) { continue; }

                    int idx1 = GetIndexByXY(i, hh - j);
                    int idx2 = GetIndexByXY(i2, hh - j2);
                    int c1 = GetColor3bit(Parts[0].ba, idx1);
                    int c2 = GetColor3bit(Parts[1].ba, idx2);
                    int idx25 = ((i - p1_l) / w5) * 5 + ((j - p1_u) / h5);
                    dat[idx25, 0, c1]++;
                    dat[idx25, 1, c2]++;
                }
            }
            res.diff = 0;
            for (int iii = 0; iii < 25; iii++)
            {
                for (int j = 0; j < 8; j++)
                {
                    res.diff25[iii] += Math.Abs(dat[iii, 0, j] - dat[iii, 1, j]);
                }
                res.diff += res.diff25[iii];
            }
            res.max25 = 0; for (int iii = 0; iii < 25; iii++) { if (res.max25 < res.diff25[iii]) { res.max25 = res.diff25[iii]; } }
            return res;
        }
        public Block CalculateDifference_v8_1(int r, int c, int p1_l, int p1_r, int p1_u, int p1_d, int sw, int sh, int w5, int h5)
        {
            int hh = Parts[0].img.Height - 1;

            Block res = new Block(r * columns + c, 0);

            int[] c1_r = new int[25];
            int[] c1_g = new int[25];
            int[] c1_b = new int[25];
            int[] c2_r = new int[25];
            int[] c2_g = new int[25];
            int[] c2_b = new int[25];

            for (int i = p1_l; i < p1_r; i++)
            {
                if (Parts[0].grid_columns[i]) { continue; }
                int i2 = i + sw;
                if (Parts[1].grid_columns[i2]) { continue; }
                for (int j = p1_u; j < p1_d; j++)
                {
                    if (Parts[0].grid_lines[j]) { continue; }
                    int j2 = j + sh;
                    if (Parts[1].grid_lines[j2]) { continue; }

                    int idx1 = GetIndexByXY(i, hh - j);
                    int idx2 = GetIndexByXY(i2, hh - j2);

                    int idx25 = ((i - p1_l) / w5) * 5 + ((j - p1_u) / h5);

                    c1_r[idx25] += Parts[0].ba[idx1 + 0];
                    c1_g[idx25] += Parts[0].ba[idx1 + 1];
                    c1_b[idx25] += Parts[0].ba[idx1 + 2];
                    c2_r[idx25] += Parts[1].ba[idx2 + 0];
                    c2_g[idx25] += Parts[1].ba[idx2 + 1];
                    c2_b[idx25] += Parts[1].ba[idx2 + 2];

                    res.diff25_cnt[idx25]++;
                }
            }
            res.diff = 0;
            for (int iii = 0; iii < 25; iii++)
            {
                int d1 = Math.Abs(c1_r[iii] - c2_r[iii]);
                int d2 = Math.Abs(c1_g[iii] - c2_g[iii]);
                int d3 = Math.Abs(c1_b[iii] - c2_b[iii]);
                if (d1 <= v81_level) { d1 = 0; }
                if (d2 <= v81_level) { d2 = 0; }
                if (d3 <= v81_level) { d3 = 0; }
                res.diff25[iii] = d1+d2+d3;
                res.diff += res.diff25[iii];
            }
            res.max25 = 0; for (int iii = 0; iii < 25; iii++) { if (res.max25 < res.diff25[iii]) { res.max25 = res.diff25[iii]; } }
            return res;
        }
        public Block CalculateDifference_v8_2(int r, int c, int p1_l, int p1_r, int p1_u, int p1_d, int sw, int sh, int w5, int h5)
        {
            int hh = Parts[0].img.Height - 1;

            Block res = new Block(r * columns + c, 0);

            int[] c1_r = new int[25];
            int[] c1_g = new int[25];
            int[] c1_b = new int[25];
            int[] c2_r = new int[25];
            int[] c2_g = new int[25];
            int[] c2_b = new int[25];

            for (int i = p1_l; i < p1_r; i++)
            {
                if (Parts[0].grid_columns[i]) { continue; }
                int i2 = i + sw;
                if (Parts[1].grid_columns[i2]) { continue; }
                for (int j = p1_u; j < p1_d; j++)
                {
                    if (Parts[0].grid_lines[j]) { continue; }
                    int j2 = j + sh;
                    if (Parts[1].grid_lines[j2]) { continue; }

                    int idx1 = GetIndexByXY(i, hh - j);
                    int idx2 = GetIndexByXY(i2, hh - j2);

                    int idx25 = ((i - p1_l) / w5) * 5 + ((j - p1_u) / h5);

                    c1_r[idx25] += Parts[0].ba[idx1 + 0];
                    c1_g[idx25] += Parts[0].ba[idx1 + 1];
                    c1_b[idx25] += Parts[0].ba[idx1 + 2];
                    c2_r[idx25] += Parts[1].ba[idx2 + 0];
                    c2_g[idx25] += Parts[1].ba[idx2 + 1];
                    c2_b[idx25] += Parts[1].ba[idx2 + 2];

                    res.diff25_cnt[idx25]++;
                }
            }
            res.diff = 0;
            for (int iii = 0; iii < 25; iii++)
            {
                int d1 = Math.Abs(c1_r[iii] - c2_r[iii]);
                int d2 = Math.Abs(c1_g[iii] - c2_g[iii]);
                int d3 = Math.Abs(c1_b[iii] - c2_b[iii]);
                if (d1 <= v82_level) { d1 = 0; }
                if (d2 <= v82_level) { d2 = 0; }
                if (d3 <= v82_level) { d3 = 0; }
                res.diff25[iii] = d1 + d2 + d3;
                res.diff += res.diff25[iii];
            }
            res.max25 = 0; for (int iii = 0; iii < 25; iii++) { if (res.diff25_cnt[iii] != 0) { if (res.max25 < res.diff25[iii] / res.diff25_cnt[iii]) { res.max25 = res.diff25[iii] / res.diff25_cnt[iii]; } } }
            return res;
        }
        public Block CalculateDifference_v8_3(int r, int c, int p1_l, int p1_r, int p1_u, int p1_d, int sw, int sh, int w5, int h5)
        {
            int hh = Parts[0].img.Height - 1;

            Block res = new Block(r * columns + c, 0);

            int[] c1_r = new int[25];
            int[] c1_g = new int[25];
            int[] c1_b = new int[25];
            int[] c2_r = new int[25];
            int[] c2_g = new int[25];
            int[] c2_b = new int[25];

            for (int i = p1_l; i < p1_r; i++)
            {
                if (Parts[0].grid_columns[i]) { continue; }
                int i2 = i + sw;
                if (Parts[1].grid_columns[i2]) { continue; }
                for (int j = p1_u; j < p1_d; j++)
                {
                    if (Parts[0].grid_lines[j]) { continue; }
                    int j2 = j + sh;
                    if (Parts[1].grid_lines[j2]) { continue; }

                    int idx1 = GetIndexByXY(i, hh - j);
                    int idx2 = GetIndexByXY(i2, hh - j2);

                    int idx25 = ((i - p1_l) / w5) * 5 + ((j - p1_u) / h5);
                    int r0 = Parts[0].ba[idx1 + 0];
                    int r1 = Parts[1].ba[idx2 + 0];
                    int g0 = Parts[0].ba[idx1 + 1];
                    int g1 = Parts[1].ba[idx2 + 1];
                    int b0 = Parts[0].ba[idx1 + 2];
                    int b1 = Parts[1].ba[idx2 + 2];

                    if (Math.Abs(r0 - r1) <= v83_level) { r0 = 0; r1 = 0; };
                    if (Math.Abs(g0 - g1) <= v83_level) { g0 = 0; g1 = 0; };
                    if (Math.Abs(b0 - b1) <= v83_level) { b0 = 0; b1 = 0; };

                    c1_r[idx25] += r0;
                    c1_g[idx25] += g0;
                    c1_b[idx25] += b0;
                    c2_r[idx25] += r1;
                    c2_g[idx25] += g1;
                    c2_b[idx25] += b1;

                    res.diff25_cnt[idx25]++;
                }
            }
            res.diff = 0;
            for (int iii = 0; iii < 25; iii++)
            {
                res.diff25[iii] = Math.Abs(c1_r[iii] - c2_r[iii]) + Math.Abs(c1_g[iii] - c2_g[iii]) + Math.Abs(c1_b[iii] - c2_b[iii]);
                res.diff += res.diff25[iii];
            }
            res.max25 = 0; for (int iii = 0; iii < 25; iii++) { if (res.max25 < res.diff25[iii]) { res.max25 = res.diff25[iii]; } }
            return res;
        }
        */

        /// <summary>
        /// main code
        /// </summary>
        private void FiveDifferenceDo()
        {
            // установим язык по настройкам
            if (settings.lang == setLang.Rus) { answ_lett = "АБВГДЕЖЗИКЛМНОПРСТУФ"; } else { answ_lett = "ABCDEFGHIJKLMNOPQRST"; }

            // разрежем картинку
            CutImageToParts();
            // переведем обе части и массив байт - BMP
            ImageToByteArray();
            // найдем сетку, границы, колонки/строки
            DetectGrid();
            CorrectGridBorder();
            // найдем общий сдвиг двух частей, сформируем прямоугольники с учетом сдвига.
            FindCommonShift();
            // сохраним различия
            StoreParts();
            // создадим парные картинки для отображения
            CreatePairImage();

            if ((Parts[0].columns == Parts[1].columns)&&(Parts[0].rows == Parts[1].rows)) { 
                // для каждой ячейки найденной сетки выполним сравнение прямоугольных областей, запомним разницу цветов
                FindDifferenceSquares();
                // для наибольших разниц цветов составим код по полученной маске
                DoAnswer();
            }
        }

        /// <summary>
        /// корректирует сетку на 1 пиксель
        /// </summary>
        private void CorrectGridBorder()
        {
            if (!CorrectGridBorder_flag) { return; }
            int cols = Parts[0].grid_columns.Length;
            int rows = Parts[0].grid_lines.Length;
            for (int i = 0; i < cols - 1; i++)
            {
                if ((!Parts[0].grid_columns[i]) && (Parts[0].grid_columns[i + 1])) { Parts[0].grid_columns[i] = true; }
                if ((!Parts[1].grid_columns[i]) && (Parts[1].grid_columns[i + 1])) { Parts[1].grid_columns[i] = true; }
            }
            for (int i = cols-1; i > 1; i--)
            {
                if ((!Parts[0].grid_columns[i]) && (Parts[0].grid_columns[i - 1])) { Parts[0].grid_columns[i] = true; }
                if ((!Parts[1].grid_columns[i]) && (Parts[1].grid_columns[i - 1])) { Parts[1].grid_columns[i] = true; }
            }
            for (int i = 0; i < rows - 1; i++)
            {
                if ((!Parts[0].grid_lines[i]) && (Parts[0].grid_lines[i + 1])) { Parts[0].grid_lines[i] = true; }
                if ((!Parts[1].grid_lines[i]) && (Parts[1].grid_lines[i + 1])) { Parts[1].grid_lines[i] = true; }
            }
            for (int i = rows-1; i > 1; i--)
            {
                if ((!Parts[0].grid_lines[i]) && (Parts[0].grid_lines[i - 1])) { Parts[0].grid_lines[i] = true; }
                if ((!Parts[1].grid_lines[i]) && (Parts[1].grid_lines[i - 1])) { Parts[1].grid_lines[i] = true; }
            }
        }

        /// <summary>
        /// собирает ответ из массива номеров блоков
        /// </summary>
        /// <param name="a">массив</param>
        /// <returns>ответ</returns>
        private string GetAnswer(int[] a)
        {
            string res = "";
            for (int i = 0; i < a.Length; i++)
            {
                res += GetPartAnswer(a[i]);
            }
            return res;
        }

        /// <summary>
        /// согласно формата ответа возвращает строку с частью ответа по идентификатору блока
        /// </summary>
        /// <param name="num">номер блока</param>
        /// <returns>часть ответа</returns>
        private string GetPartAnswer(int num)
        {
            if(columns == 0) { return ""; }
            string res = "";
            int row = num / columns;
            int col = num % columns;
            if (settings.type == setType._1A)
            {
                if (settings.nums == setNums.Up) { res = (col + 1).ToString() + answ_lett[row]; }
                else { res = (row + 1).ToString() + answ_lett[col]; }
            }
            else
            {
                if (settings.nums == setNums.Up) { res = answ_lett[row] + (col + 1).ToString(); }
                else { res = answ_lett[col] + (row + 1).ToString(); }
            }
            return res;
        }

        /// <summary>
        /// выбирает индексы блоков (номера)
        /// </summary>
        /// <param name="b">блоки</param>
        /// <returns>массив лучших индексов</returns>
        private int[] GetFiveBlockIndexes(Block[] b, int cnt = 5)
        {
            if(b.Length < cnt) { return new int[5] { 0, 0, 0, 0, 0 }; }
            int[] res = new int[cnt];
            for (int i = 0; i < cnt; i++) { res[i] = b[i].num; }
            bool needSort = true;
            while (needSort)
            {
                needSort = false;
                for (int i = 0; i < cnt - 1; i++)
                {
                    if (res[i] > res[i + 1])
                    {
                        int t = res[i];
                        res[i] = res[i + 1];
                        res[i + 1] = t;
                        needSort = true;
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// сортирует блоки по убыванию отличий
        /// </summary>
        /// <param name="v">1 - на целом блоке, 9 - на 1/9 блока, 16 - на 1/16 блока</param>
        private Block[] SortBlocks(int v)
        {
            Block[] bl = blocks;
            if (!((v == 1) || (v == 9) || (v == 16) || (v == 25) || (v == 77) || (v == 88) || (v == 99))) { return blocks; }
            int cnt = blocks.Length;
            bool needSort = true;
            while (needSort)
            {
                needSort = false;
                for (int i = 0; i < cnt - 1; i++)
                {
                    if (((v == 1) && (bl[i].diff < bl[i + 1].diff)) ||
                        ((v == 25) && (bl[i].max25 < bl[i + 1].max25)) 
                        ) /*||
                        ((v == 9) && (bl[i].max9 < bl[i + 1].max9)) ||
                        ((v == 16) && (bl[i].max16 < bl[i + 1].max16)) ||
                        ((v == 77) && ((bl[i].max16 + bl[i].max25) < (bl[i + 1].max16 + bl[i + 1].max25))) ||
                        ((v == 88) && ((bl[i].max16 + bl[i].max9) < (bl[i + 1].max16 + bl[i + 1].max9))) )
                        */
                    {
                        Block q = bl[i];
                        bl[i] = bl[i + 1];
                        bl[i + 1] = q;
                        needSort = true;
                    }
                }
            }
            return bl;
        }

        /// <summary>
        /// находит разницы ячеек, заполняет difss
        /// </summary>
        private void FindDifferenceSquares()
        {
            int cnt = columns * rows;
            blocks = new Block[cnt];
            int curr = 0;
            for(int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    blocks[curr] = FindOneDiff(r, c);
                    curr++;
                }
            }
        }

        /// <summary>
        /// находит разницу в ячейках, с учетом сдвигов
        /// </summary>
        /// <param name="r">строка</param>
        /// <param name="c">колонка</param>
        /// <returns>минимум разницы с учетом сдвигов</returns>
        private Block FindOneDiff(int r, int c)
        {
            int FindOneDiff_shift_compare2 = FindOneDiff_shift_compare * 2 + 1;
            Block[] res_sh = new Block[FindOneDiff_shift_compare2 * FindOneDiff_shift_compare2];
            for(int i = 0; i < FindOneDiff_shift_compare2; i++)
            {
                for (int j = 0; j < FindOneDiff_shift_compare2; j++)
                {
                    res_sh[i * FindOneDiff_shift_compare2 + j] = FindOneDiffShift(r, c, i - FindOneDiff_shift_compare, j - FindOneDiff_shift_compare);
                }
            }
            return GetMinBlock(res_sh);
        }

        /// <summary>
        /// находит из массива блоков тот, у которого общая разница меньше
        /// </summary>
        /// <param name="arbl">массив блоков</param>
        /// <returns>блок с минимальным diff</returns>
        private Block GetMinBlock(Block[] arbl)
        {
            long min = 0xffffffffffff;
            int idx = -1;
            if (GetMinBlock_criteria == 1)
            {
                for (int i = 0; i < arbl.Length; i++)
                {
                    if (min > arbl[i].diff) { idx = i; min = arbl[i].diff; }
                }
            }
            if (GetMinBlock_criteria == 25)
            {
                for (int i = 0; i < arbl.Length; i++)
                {
                    if (min > arbl[i].max25) { idx = i; min = arbl[i].max25; }
                }
            }
            return arbl[idx];
        }

        /// <summary>
        /// создает парные изображения для вывода на экран
        /// </summary>
        private void CreatePairImage()
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
        private void StoreParts()
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
        private void FindCommonShift()
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
        /// для всех сдвигов ищет сумму разниц отличий
        /// </summary>
        private ShArr[] FindDiffsByShifts(ShArr[] Shifts)
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
        private long FindDiffsByShiftsOne(ShArr sh)
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
        private ShArr[] KillDupesShifts(ShArr[] shifts2)
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
        private int[] GetLineDiffArr(int[] a1, int[] a2, bool[] b1, bool[] b2)
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
        private float GetLineDiffOne(int[] a1, int[] a2, int sh, bool[] b1, bool[] b2)
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
        private int[] GetSumRowsParts(int v)
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
        private int[] GetSumColsParts(int v)
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
        private int GetIndexByXY(int x, int y)
        {
            return BmpHeader + y * LineLen + x * 3;
        }

        /// <summary>
        ///  получает 3 бит цвет точки
        /// </summary>
        /// <param name="idx">индекс</param>
        /// <returns>цвет</returns>
        private int GetColor3bit(byte[] ba, int idx)
        {
            return (ba[idx + 0] >> 7) + ((ba[idx + 1] >> 7) << 1) + ((ba[idx + 2] >> 7) << 2);
        }

        /// <summary>
        ///  получает 6 бит цвет точки
        /// </summary>
        /// <param name="idx">индекс</param>
        /// <returns>цвет</returns>
        private int GetColor6bit(byte[] ba, int idx)
        {
            return (ba[idx + 0] >> 6) + ((ba[idx + 1] >> 6) << 2) + ((ba[idx + 2] >> 6) << 4);
        }

        /// <summary>
        ///  получает 9 бит цвет точки
        /// </summary>
        /// <param name="idx">индекс</param>
        /// <returns>цвет</returns>
        private int GetColor9bit(byte[] ba, int idx)
        {
            return (ba[idx + 0] >> 5) + ((ba[idx + 1] >> 5) << 3) + ((ba[idx + 2] >> 5) << 6);
        }

        /// <summary>
        ///  получает 12 бит цвет точки
        /// </summary>
        /// <param name="idx">индекс</param>
        /// <returns>цвет</returns>
        private int GetColor12bit(byte[] ba, int idx)
        {
            return (ba[idx + 0] >> 4) + ((ba[idx + 1] >> 4) << 4) + ((ba[idx + 2] >> 4) << 8);
        }

        /// <summary>
        /// находит сетку для обоих половинок
        /// </summary>
        private void DetectGrid()
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
        private TwoWhiteArray GetWhiteCounts(int num)
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
        private Bound GetWhiteBound(int[] ar, int max)
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
        private List<Bound> GetWhiteSquare(int[] ar, Bound b, int wh)
        {
            int len = ar.Length;
            int min = GetMin(ar);
            int wh2 = Math.Max(wh, min);
            int diff = wh2 + len * GetWhiteBound_PortionWhiteBound1000_0 / 1000;
            int start = b.start+1;
            int end = b.end-1;
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
                    if (b_start + 10 < b_end) { res.Add(new Bound(b_start, b_end)); }
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
        private int GetWhiteCnt(Bound b, int l)
        {
            return (b.start) + (l-b.end);
        }

        /// <summary>
        /// находит сетку для одной из половинок
        /// <param name="num">номер части</param>
        /// </summary>
        private void DetectGridOne(int num)
        {
            // * найти количества белых цветов
            TwoWhiteArray white = GetWhiteCounts(num);
            Parts[num].twa = white;
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
            Parts[num].BoundsUpDown = squareUD;
            Parts[num].BoundsLeftRight = squareLR;
            // 2Do:
            // в отдельных случаях, для картинок в низком разрешении, есть ложные срабатывания двух видов:
            // 1. одна из колонок, или несколько делиться на две части по метке символа -- их надо бы объединять
            // 2. какие-нить две колонки, или несколько, могут быть объединены в одну, с большим размером - их надо бы разбивать.
            // как - находить наиболее частый размер, и, анализировать все примерно вдвое большие/меньшие размеры. 
            // если такие найдутся - то соотв. разбивать их по локальному минимуму, или объединять.
            // как временное решение - не использовать картинки в мелком р
            // в тестах мелкие картинки выделил отдельно

            // заполним в сетке
            for (int i = 0; i < squareUD.Count - 1; i++)
            {
                for (int j = squareUD[i].end; j <= squareUD[i + 1].start; j++) { Parts[num].grid_lines[j] = true; }
            }
            for (int i = 0; i < squareLR.Count - 1; i++)
            {
                for (int j = squareLR[i].end; j <= squareLR[i + 1].start; j++) { Parts[num].grid_columns[j] = true; }
            }

            Parts[num].columns = squareLR.Count - 1;
            Parts[num].rows = squareUD.Count - 1;
            // * для Parts[0] - символы у нас в первой колонке/столбце
            // * для Parts[1] - символы могут быть вначале/конце. надо найти где посмотрев на величину сдвига, учтя белые границы
            if(num == 1)
            {
                // для num==1 нужно определить, где символы, и, удалить эти границы из общего списка
                // для num==0 границы всегда слева и вверху.
                BoundHash u0 = GetBoundHash(Parts[0].BoundsUpDown[0], Parts[0].twa.rows);
                BoundHash u1_first = GetBoundHash(Parts[1].BoundsUpDown[0], Parts[1].twa.rows);
                BoundHash u1_last = GetBoundHash(Parts[1].BoundsUpDown[Parts[1].BoundsUpDown.Count-1], Parts[1].twa.rows);
                int choiceUD = ElectionHash(u0, u1_first, u1_last);

                BoundHash l0 = GetBoundHash(Parts[0].BoundsLeftRight[0], Parts[0].twa.cols);
                BoundHash l1_first = GetBoundHash(Parts[1].BoundsLeftRight[0], Parts[1].twa.cols);
                BoundHash l1_last = GetBoundHash(Parts[1].BoundsLeftRight[Parts[1].BoundsLeftRight.Count - 1], Parts[1].twa.cols);
                int choiceLR = ElectionHash(l0, l1_first, l1_last);

                // 2Do:
                // Может быть ещё и третий вариант - choice == -1 -- когда мы не может сделать выбор -- не решено 
                Parts[0].BoundsUpDown.RemoveAt(0);
                Parts[0].BoundsLeftRight.RemoveAt(0);
                if (choiceUD == 0) { Parts[1].BoundsUpDown.RemoveAt(0); } else { Parts[1].BoundsUpDown.RemoveAt(Parts[1].BoundsUpDown.Count - 1); }
                if (choiceLR == 0) { Parts[1].BoundsLeftRight.RemoveAt(0); } else { Parts[1].BoundsLeftRight.RemoveAt(Parts[1].BoundsLeftRight.Count - 1); }
            }            
            // все остальное - наша сетка для поиска.
            // границы определены; сетка, которую не нужно проверять - тоже.
        }

        /// <summary>
        /// производит выбор одного из диапазонов, более соответствующему эталонному
        /// </summary>
        /// <param name="p0">хэш эталона</param>
        /// <param name="p1_f">кандидат 0</param>
        /// <param name="p1_l">кандидат 1</param>
        /// <returns>номер кандидата 0/1 (первый/послений)</returns>
        private int ElectionHash(BoundHash p0, BoundHash c0, BoundHash c1)
        {
            int f = 0;
            int l = 0;
            if (Math.Abs(p0.min - c0.min) < Math.Abs(p0.min - c1.min)) { f++; }
            if (Math.Abs(p0.min - c0.min) > Math.Abs(p0.min - c1.min)) { l++; }
            if (Math.Abs(p0.max - c0.max) < Math.Abs(p0.max - c1.max)) { f++; }
            if (Math.Abs(p0.max - c0.max) > Math.Abs(p0.max - c1.max)) { l++; }
            if (Math.Abs(p0.avg - c0.avg) < Math.Abs(p0.avg - c1.avg)) { f++; }
            if (Math.Abs(p0.avg - c0.avg) > Math.Abs(p0.avg - c1.avg)) { l++; }
            if (Math.Abs(p0.low_cnt - c0.low_cnt) < Math.Abs(p0.low_cnt - c1.low_cnt)) { f++; }
            if (Math.Abs(p0.low_cnt - c0.low_cnt) > Math.Abs(p0.low_cnt - c1.low_cnt)) { l++; }
            if (Math.Abs(p0.high_cnt - c0.high_cnt) < Math.Abs(p0.high_cnt - c1.high_cnt)) { f++; }
            if (Math.Abs(p0.high_cnt - c0.high_cnt) > Math.Abs(p0.high_cnt - c1.high_cnt)) { l++; }
            if (Math.Abs(p0.min_cnt - c0.min_cnt) < Math.Abs(p0.min_cnt - c1.min_cnt)) { f++; }
            if (Math.Abs(p0.min_cnt - c0.min_cnt) > Math.Abs(p0.min_cnt - c1.min_cnt)) { l++; }
            if (Math.Abs(p0.max_cnt - c0.max_cnt) < Math.Abs(p0.max_cnt - c1.max_cnt)) { f++; }
            if (Math.Abs(p0.max_cnt - c0.max_cnt) > Math.Abs(p0.max_cnt - c1.max_cnt)) { l++; }
            if (f > l) { return 0; }
            if (f < l) { return 1; }
            return -1;
        }

        /// <summary>
        /// получает характеристики одной границы по белым цветам - мин, макс, среднее, разные количества
        /// </summary>
        /// <param name="b">границы</param>
        /// <param name="ar2">массив</param>
        /// <returns>хэш</returns>
        private BoundHash GetBoundHash(Bound b, int[] ar2)
        {
            int cnt = b.end - b.start + 1;
            int[] ar = new int[cnt];
            for(int i = 0; i < cnt; i++) { ar[i] = ar2[i + b.start]; }
            BoundHash res = new BoundHash(GetMin(ar), GetMax(ar), GetAvg(ar));
            for (int i = 0; i < cnt; i++)
            {
                int x = ar[i];
                if (x == res.min) { res.min_cnt++; }
                if (x == res.max) { res.max_cnt++; }
                if (x < res.avg) { res.low_cnt++; }
                if (x > res.avg) { res.high_cnt++; }
            }
            return res;
        }

        /// <summary>
        /// создает массив границ по маске сетки, и расположению символов
        /// </summary>
        /// <param name="grid">маска сетки</param>
        /// <param name="Bnd">границы символов</param>
        /// <returns></returns>
        private Bound[] GetBounds(bool[] grid, Bound Bnd)
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
        private Bound GetMaxBound(bool[] grid, Bound b)
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
                if ((bounds[i].start == b.start)&&(bounds[i].end == b.end)) { continue; }
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
        private Bound GetMaxBound(bool[] grid, int v1, int v2)
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
        private bool[] GetGridFlagByDiff2(int[] ar, int val)
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
        private int[] GetWhiteDiff(int[] ar1, int[] ar2)
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
        private int GetMax(int[] ar)
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
        private int[] SubArr(int[] ar, int num)
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
        private bool[] GetGridFlag(int[] ar)
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
        private int Color6to3bit(int num)
        {
            return ((num & 2) >> 1) | ((num & 8) >> 2) | ((num & 32) >> 3);
        }

        /// <summary>
        /// вычитает из массива число
        /// </summary>
        /// <param name="ar">массив</param>
        /// <param name="num">число</param>
        /// <returns>массив</returns>
        private int[] GetArrSubInt(int[] ar, int num)
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
        private int GetMin(int[] ar)
        {
            int min = 256 * 256 * 256;
            int cnt = ar.Length;
            for (int i = 0; i < cnt; i++) { if (ar[i] < min) { min = ar[i]; } }
            return min;
        }

        /// <summary>
        /// находит минимум в массиве
        /// </summary>
        /// <param name="ar">массив</param>
        /// <returns>минимальное значение</returns>
        private long GetMin(long[] ar)
        {
            long min = 0xffffffffff;
            int cnt = ar.Length;
            for (int i = 0; i < cnt; i++) { if (ar[i] < min) { min = ar[i]; } }
            return min;
        }

        /// <summary>
        /// находит среднее в массиве
        /// </summary>
        /// <param name="ar">массив</param>
        /// <returns>среднее значение</returns>
        private int GetAvg(int[] ar)
        {
            int sum = 0;
            int cnt = ar.Length;
            for (int i = 0; i < cnt; i++) { sum += ar[i]; }
            return sum/cnt;
        }

        /// <summary>
        /// находит минимум в массиве, не равный нулю
        /// </summary>
        /// <param name="ar">массив</param>
        /// <returns>минимальное значение</returns>
        private int GetMin_NonZero(int[] ar)
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
        private byte[] BitmapToByteArray(Bitmap img)
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
        private void ImageToByteArray()
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
