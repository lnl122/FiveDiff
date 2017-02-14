using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveDiff
{
    public class FindFiveDiff
    {
        
        public Bitmap Bmp, Img1, Img2;          // изначальния картинка, первая и вторая часть
        public const int BmpHeader = 54;        // длина заголовка BMP
        public Part[] Parts = new Part[2];      // рабочая структура с частями
        public int LineLen;                     // длина линии в байтах
        public int shift_ver, shift_hor;        // сдвиг первой и второй части
        public ShArr[] Shifts;                  // массив сдвигов
        public int h_up, h_down, v_left, v_right;// границы букв
        public bool presentBounds = false;
        public List<Bounds> h_bounds = new List<Bounds>(); // границы разрезанных букв
        public List<Bounds> v_bounds = new List<Bounds>();
        public int rows, columns;
        public Block[] blocks;
        public string answ_lang, answ_nums, answ_type, answ_lett;
        public string Answer;

        public struct Part
        {
            public Bitmap img;
            public Rectangle rect;
            public byte[] ba;
            public Rectangle rect_shift;
            public Bitmap img_shift;
        }
        public struct ShArr
        {
            public int shift_v;
            public int shift_h;
            public long diff;
        }
        public struct Bounds
        {
            public int start, end;
            public Bitmap img_letter;
            public Bounds(int p1, int p2)
            {
                start = p1;
                end = p2;
                img_letter = new Bitmap(5, 5);
            }
            public Bounds(int p1, int p2, Bitmap bb)
            {
                start = p1;
                end = p2;
                img_letter = bb;
            }
        }
        public struct Block
        {
            public int row;
            public int col;
            public int num;
            public int sh_h;
            public int sh_v;
            public long diff;
            public long[] diff16;
            public long[] diff9;
            public long max9;
            public long max16;
            public long diff99;
            public Block(int r, int c, int sh, int sv, int i)
            {
                row = r;
                col = c;
                num = i;
                sh_h = sh;
                sh_v = sv;
                diff = 0;
                diff9 = new long[9];
                diff16 = new long[16];
                max9 = 0;
                max16 = 0;
                diff99 = 0;
            }
        }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="b">битмап, в котором нужно найти отличия</param>
        public FindFiveDiff(Bitmap b, string answerformat = "LaUpA1")
        {
            Bmp = b;
            SetAnswerFormat(answerformat);

            CutImage();
            ImageToByteArray();
            FindShift();//долгая
            StorePart();
            CreatePairImage();
            FillColorLines();
            // а если границ толковых нет?
            FlagBoundsPresent();
            Answer = "";
            if (presentBounds) { GetDelimiters(); }
            if (presentBounds)
            {
                // выполним нарезку кусочков, их синхронизацию и найдем разницы
                FindBlockDiffs();//долгая
                FindDifferenceInBlocks();
                int[] prior1 = GetFiveBlockIndexes(SortBlocks(1));
                int[] prior9 = GetFiveBlockIndexes(SortBlocks(9));
                int[] prior16 = GetFiveBlockIndexes(SortBlocks(16));
                int[] prior99 = GetFiveBlockIndexes(SortBlocks(99));
                Answer = GetAnswer(prior16);
            }
        }

        /// <summary>
        /// инициализация параметров ответа
        /// </summary>
        /// <param name="a">входящая строка "LaUp1A". La/Ru Up/Le 1A/A1</param>
        private void SetAnswerFormat(string a)
        {
            answ_lang = a.Substring(0, 2);
            answ_nums = a.Substring(2, 2);
            answ_type = a.Substring(4, 2);
            string Rus = "АБВГДЕЖЗИКЛМНОПРСТУФ";
            string Eng = "ABCDEFGHIJKLMNOPQRST";
            if (answ_lang == "Ru") { answ_lett = Rus; } else { answ_lett = Eng; }
        }
        /// <summary>
        /// собирает ответ из массива номеров блоков
        /// </summary>
        /// <param name="a">массив</param>
        /// <returns>ответ</returns>
        public string GetAnswer(int[] a)
        {
            string res = "";
            for(int i=0; i<a.Length; i++)
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
        public string GetPartAnswer(int num)
        {
            string res = "";
            int row = num / columns;
            int col = num % columns;
            if(answ_type == "1A")
            {
                if (answ_nums == "Up") { res = (col + 1).ToString() + answ_lett[row]; }
                else { res = (row + 1).ToString() + answ_lett[col]; }
            }
            else
            {
                if (answ_nums == "Up") { res = answ_lett[row] + (col + 1).ToString(); }
                else { res = answ_lett[col] + (row + 1).ToString(); }
            }
            return res;
        }
        /// <summary>
        /// выбирает индексы блоков (номера)
        /// </summary>
        /// <param name="b">блоки</param>
        /// <returns>массив лучших индексов</returns>
        public int[] GetFiveBlockIndexes(Block[] b)
        {
            int cnt = 5;
            int[] res = new int[cnt];
            for (int i = 0; i < cnt; i++) { res[i] = b[i].num; }
            bool needSort = true;
            while (needSort)
            {
                needSort = false;
                for(int i = 0; i < cnt-1; i++)
                {
                    if (res[i] > res[i+1])
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
        public Block[] SortBlocks(int v)
        {
            Block[] bl = blocks;
            if (!((v == 1) || (v == 9) || (v == 16) || (v == 99))) { return blocks; }
            int cnt = blocks.Length;
            bool needSort = true;
            while (needSort)
            {
                needSort = false;
                for(int i = 0; i < cnt-1; i++)
                {
                    if ( ((v == 1) && (bl[i].diff < bl[i + 1].diff)) ||
                        ((v == 9) && (bl[i].max9 < bl[i + 1].max9)) ||
                        ((v == 16) && (bl[i].max16 < bl[i + 1].max16)) ||
                        ((v == 99) && (bl[i].diff99 < bl[i + 1].diff99)))
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
        /// находит разницы в блоках, в т.ч. в частях по 9 и 16 кусочков
        /// </summary>
        public void FindDifferenceInBlocks()
        {
            for(int k = 0; k < blocks.Length; k++)
            {
                Block q = blocks[k];
                int height = Img1.Height;
                int corner = 1;
                int img1_left = h_bounds[q.col].start + corner;
                int img1_up = v_bounds[q.row].start + corner;
                int img2_left = img1_left + shift_hor + q.sh_h;
                int img2_up = img1_up + shift_ver + q.sh_v;
                int img_width = h_bounds[q.col].end - h_bounds[q.col].start - 2 * corner;
                int img_heigth = v_bounds[q.row].end - v_bounds[q.row].start - 2 * corner;
                //long res = 0;
                //#if DEBUG
                //                Bitmap temp1 = Parts[0].img.Clone(new Rectangle(img1_left, img1_up, img_width, img_heigth), Parts[0].img.PixelFormat);
                //                temp1.Save(@"C:\_2del\23\row=" + q.row.ToString() + " col=" + q.col.ToString() + " l=" + img1_left.ToString() + " u=" + img1_up.ToString() + " h=" + q.sh_h.ToString() + " v=" + q.sh_v.ToString() + " part 0.jpg");
                //                Bitmap temp2 = Parts[1].img.Clone(new Rectangle(img2_left, img2_up, img_width, img_heigth), Parts[1].img.PixelFormat);
                //                temp2.Save(@"C:\_2del\23\row=" + q.row.ToString() + " col=" + q.col.ToString() + " l=" + img2_left.ToString() + " u=" + img2_up.ToString() + " h=" + q.sh_h.ToString() + " v=" + q.sh_v.ToString() + " part 1.jpg");
                //#endif
                int w3 = img_width / 3 + 1;
                int h3 = img_heigth / 3 + 1;
                int w4 = img_width / 4 + 1;
                int h4 = img_heigth / 4 + 1;
                q.diff = 0;
                q.diff9 = new long[9];
                q.diff16 = new long[16];
                for (int i = 0; i < img_width; i++)
                {
                    for (int j = 0; j < img_heigth; j++)
                    {
                        int pos1 = GetIndexByXY(img1_left + i, height - (img1_up + j ));
                        int pos2 = GetIndexByXY(img2_left + i, height - (img2_up + j ));
                        int res_pixel = Math.Abs(Parts[0].ba[pos1 + 0] - Parts[1].ba[pos2 + 0]);
                        res_pixel += Math.Abs(Parts[0].ba[pos1 + 1] - Parts[1].ba[pos2 + 1]);
                        res_pixel += Math.Abs(Parts[0].ba[pos1 + 2] - Parts[1].ba[pos2 + 2]);
                        q.diff += res_pixel;
                        int idx9 = (i / w3) * 3 + (j / h3);
                        int idx16 = (i / w4) * 4 + (j / h4);
                        q.diff9[idx9] += res_pixel;
                        q.diff16[idx16] += res_pixel;
                    }
                }
                q.num = q.row * columns + q.col;
                q.max16 = Math.Max(Math.Max(Math.Max(Math.Max(q.diff16[0], q.diff16[1]), Math.Max(q.diff16[2], q.diff16[3])), Math.Max(Math.Max(q.diff16[4], q.diff16[5]), Math.Max(q.diff16[6], q.diff16[7]))), Math.Max(Math.Max(Math.Max(q.diff16[8], q.diff16[9]), Math.Max(q.diff16[10], q.diff16[11])), Math.Max(Math.Max(q.diff16[12], q.diff16[13]), Math.Max(q.diff16[14], q.diff16[15]))));
                q.max9 = Math.Max(Math.Max(Math.Max(q.diff16[0], q.diff16[1]), Math.Max(q.diff16[2], q.diff16[3])), Math.Max(Math.Max(q.diff16[4], q.diff16[5]), Math.Max(q.diff16[6], Math.Max(q.diff16[7], q.diff16[8]))));
                q.diff99 = q.diff + q.max9 * 9 + q.max16 * 16;
                blocks[k] = q;
            }
        }
        /// <summary>
        /// для всех блоков находит разницу, также +- смещение
        /// </summary>
        public void FindBlockDiffs()
        {
            rows = v_bounds.Count;
            columns = h_bounds.Count;
            int local_shift = 1;
            int blocks_cnt = rows * columns;
            blocks = new Block[blocks_cnt];
            int blocks2_cnt = rows * columns * (local_shift * 2 + 1) * (local_shift * 2 + 1);
            Block[] blocks2 = new Block[blocks2_cnt];
            int idx = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    for (int ii = -local_shift; ii <= local_shift; ii++)
                    {
                        for (int jj = -local_shift; jj <= local_shift; jj++)
                        {
                            Block q = new Block(i, j, ii, jj, idx);
                            q.diff = FindBlockDiffOne(q);
                            blocks2[idx] = q;
                            idx++;
                        }
                    }
                }
            }
            // полученные блоки нужно отцентровать. найдем максимально похожие
            int idx_bl = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    long min = 0xffffffff;
                    int idx_min = 0;
                    for (int k = 0; k < blocks2_cnt; k++)
                    {
                        if((blocks2[k].col == j) && (blocks2[k].row == i))
                        {
                            if(blocks2[k].diff < min)
                            {
                                min = blocks2[k].diff;
                                idx_min = k;
                            }
                        }
                    }
                    blocks[idx_bl] = blocks2[idx_min];
                    idx_bl++;
                }
            }
        }
        /// <summary>
        /// поиск различий для целоко блока - цель - отцентровать его для поиска
        /// </summary>
        /// <param name="q">блок</param>
        /// <returns>разница цветов</returns>
        public long FindBlockDiffOne(Block q)
        {
            int height = Img1.Height;
            int corner = 3;
            int img1_left = h_bounds[q.col].start + corner;
            int img1_up = v_bounds[q.row].start + corner;
            int img2_left = img1_left + shift_hor + q.sh_h;
            int img2_up = img1_up + shift_ver + q.sh_v;
            int img_width = h_bounds[q.col].end - h_bounds[q.col].start - 2 * corner;
            int img_heigth = v_bounds[q.row].end - v_bounds[q.row].start - 2 * corner;
            long res = 0;
//#if DEBUG
//            if ((q.sh_v == 0) && (q.sh_h == 0))
//            {
//                Bitmap temp1 = Parts[0].img.Clone(new Rectangle(img1_left, img1_up, img_width, img_heigth), Parts[0].img.PixelFormat);
//                temp1.Save(@"C:\_2del\23\row=" + q.row.ToString() + " col=" + q.col.ToString() + " l=" + img1_left.ToString() + " u=" + img1_up.ToString() + " h=" + q.sh_h.ToString() + " v=" + q.sh_v.ToString() + " part 0.jpg");
//                Bitmap temp2 = Parts[1].img.Clone(new Rectangle(img2_left, img2_up, img_width, img_heigth), Parts[1].img.PixelFormat);
//                temp2.Save(@"C:\_2del\23\row=" + q.row.ToString() + " col=" + q.col.ToString() + " l=" + img2_left.ToString() + " u=" + img2_up.ToString() + " h=" + q.sh_h.ToString() + " v=" + q.sh_v.ToString() + " part 1.jpg");
//            }
//#endif
            for (int i = 0; i < img_width; i++)
            {
                for (int j = 0; j < img_heigth; j++)
                {
                    int pos1 = GetIndexByXY(img1_left + i, height - (img1_up + j));
                    int pos2 = GetIndexByXY(img2_left + i, height - (img2_up + j));
                    res = res + Math.Abs(Parts[0].ba[pos1 + 0] - Parts[1].ba[pos2 + 0]);
                    res = res + Math.Abs(Parts[0].ba[pos1 + 1] - Parts[1].ba[pos2 + 1]);
                    res = res + Math.Abs(Parts[0].ba[pos1 + 2] - Parts[1].ba[pos2 + 2]);
                }
            }
            return res;
        }
        /// <summary>
        /// проверяет наличие границ 
        /// </summary>
        public void FlagBoundsPresent()
        {
            if ((v_right == -1) || (v_left == -1) || (h_up == -1) || (h_down == -1))
            {
                presentBounds = false;
            }
            if ((v_left > v_right) || (h_up > h_down))
            {
                presentBounds = false;
            }
            if ((Math.Abs(v_left - v_right) < 10) || ((Math.Abs(h_up - h_down) < 10)))
            {
                presentBounds = false;
            }
            presentBounds = true;
        }
        /// <summary>
        /// разрезает картину на две части согласно найденных прямоугольников
        /// </summary>
        public void CutImage()
        {
            int width = Bmp.Width;
            int height = Bmp.Height;
            // определим метод разрезания (верт/гор), определим прямоугольники
            if (width >= height)
            {
                int t = (int)(width / 2) - 1;
                Parts[0].rect = new Rectangle(0, 0, t, height);
                Parts[1].rect = new Rectangle(t, 0, t, height);
            }
            else
            {
                int t = (int)(height / 2) - 1;
                Parts[0].rect = new Rectangle(0, 0, width, t);
                Parts[1].rect = new Rectangle(0, t, width, t);
            }
            // разрежем картинку
            Parts[0].img = Bmp.Clone(Parts[0].rect, Bmp.PixelFormat);
            Parts[1].img = Bmp.Clone(Parts[1].rect, Bmp.PixelFormat);
        }
        /// <summary>
        /// из картинок делает массив байт
        /// </summary>
        public void ImageToByteArray() { 
            // переведем в массив байт
            Parts[0].ba = BitmapToByteArray(Parts[0].img);
            Parts[1].ba = BitmapToByteArray(Parts[1].img);
            // найдем длину линии в BMP
            LineLen = Parts[0].img.Width * 3 + Parts[0].img.Width % 4;
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
        /// находит смещения по разнице цветов в линиях
        /// </summary>
        public void FindShift()
        {
            int[] w0 = GetSumWidthParts(0);
            int[] w1 = GetSumWidthParts(1);
            int[] h0 = GetSumHeigthParts(0);
            int[] h1 = GetSumHeigthParts(1);

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
            for (int i = 0; i < Shifts.Length; i++) { dd[i] = Shifts[i].diff; }
            int idx = GetMinIndex(dd);
            shift_ver = -Shifts[idx].shift_v;
            shift_hor = Shifts[idx].shift_h;
        }
        /// <summary>
        /// получает массив сумм цветов горизонталей
        /// </summary>
        /// <param name="v">номер части</param>
        /// <returns>массив</returns>
        public int[] GetSumWidthParts(int v)
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
        public int[] GetSumHeigthParts(int v)
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
        /// <param name="x">координата пикселя горизонталь</param>
        /// <param name="y">координата пикселя вертикаль</param>
        /// <returns>положение в массиве</returns>
        public int GetIndexByXY(int x, int y)
        {
            return BmpHeader + y * LineLen + x * 3;
        }
        /// <summary>
        /// находит смещение по разнице цветов из двух массивов
        /// </summary>
        /// <param name="a1">массив цветов 1</param>
        /// <param name="a2">массив цветов 2</param>
        /// <returns>смещение массива 2 относительно массива 1</returns>
        public int[] GetLineDiffArr(int[] a1, int[] a2)
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
            for (int i = 0; i < lenres; i++) { res[i] = res2[i] - shift; }
            return res;
        }
        /// <summary>
        /// находит разницу цветов из двух массивов для конкретного смещения. усредняет
        /// </summary>
        /// <param name="a1">массив цветов 1</param>
        /// <param name="a2">массив цветов 2</param>
        /// <param name="i">смещение</param>
        /// <returns>усредненная разница</returns>
        public float GetLineDiffOne(int[] a1, int[] a2, int sh)
        {
            int len = a1.Length;
            int cnt = 0;
            int sum = 0;
            for (int i = 0; i < len; i++)
            {
                int j = i + sh;
                if ((j < 0) || (j >= len)) { continue; }
                cnt++;
                int x1 = a1[i];
                int x2 = a2[j];
                if (x1 >= x2)
                {
                    sum += (x1 - x2);
                }
                else
                {
                    sum += (x2 - x1);
                }
            }
            return (float)sum / (float)(cnt);
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
        /// для всех сдвигов ищет сумму разниц отличий
        /// </summary>
        public void FindDiffsByShifts()
        {
            int len = Shifts.Length;
            for (int i = 0; i < len; i++)
            {
                Shifts[i].diff = FindDiffsByShiftsOne(i);
            }
        }
        /// <summary>
        /// ищет сумму разниц отличий для одной пары сдвигов по прямоугольнику
        /// </summary>
        /// <param name="num">индекс в массиве сдвигов</param>
        /// <returns>разница цветов</returns>
        public long FindDiffsByShiftsOne(int num)
        {
            int sh_v = Shifts[num].shift_v;
            int sh_h = Shifts[num].shift_h;
            int Parts_v = Parts[0].rect.Height;
            int Parts_h = Parts[0].rect.Width;
            int pv5 = Parts_v / 5;
            int ph5 = Parts_h / 5;
            long dd = 0;
            for (int i = 0; i < ph5; i++)
            {
                for (int j = 0; j < pv5; j++)
                {
                    int x = ph5 * 2 + i;
                    int y = pv5 * 2 + j;
                    int x2 = x + sh_h;
                    int y2 = y + sh_v;
                    int pos = GetIndexByXY(x, y);
                    int pos2 = GetIndexByXY(x2, y2);
                    dd += Math.Abs(Parts[0].ba[pos] - Parts[1].ba[pos2]);
                    dd += Math.Abs(Parts[0].ba[pos + 1] - Parts[1].ba[pos2 + 1] );
                    dd += Math.Abs(Parts[0].ba[pos + 2] - Parts[1].ba[pos2 + 2] );
                }
            }
            return dd;
        }
        /// <summary>
        /// находит индекс минимального значения из массива
        /// </summary>
        /// <param name="diff">массив</param>
        /// <returns>минимальный индекс</returns>
        public int GetMinIndex(float[] diff)
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
        /// сохраняет части по найденным смещениям
        /// </summary>
        public void StorePart()
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
        /// находит среднее из массива
        /// </summary>
        /// <param name="ar">входящий массив</param>
        /// <returns>среднее значение</returns>
        public int GetAvg(int[] ar)
        {
            int s = 0;
            int cnt = ar.Length;
            for (int i = 0; i < cnt; i++) { s += ar[i]; }
            return s / cnt;
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
        /// находит границы текста (для верхней строки нижний верхний край, для левой - левый/правый)
        /// </summary>
        public void FillColorLines()
        {
            v_left = -1;
            v_right = -1;
            h_up = -1;
            h_down = -1;
            int height = Img1.Height;
            int width = Img1.Width;
            byte[] ba = Parts[0].ba;
            // ищем в верхней части картинки
            int h3 = height / 3;
            int[] h1 = new int[h3];
            for (int i = 0; i < h3; i++)
            {
                for (int j = width / 4; j < width; j++)
                {
                    int idx = GetIndexByXY(j, height - i - 1);
                    int idx1 = GetColor6bit(ba, idx);
                    if (idx1 == 63) { h1[i]++; }
                }
            }
            int h_med = GetMax(h1);
            int[] h2 = SubArr(h1, h_med /2);
            for (int i = 25; i < h3; i++) // начинаем смотреть с 25 линии
            {
                if (h2[i] == 0) { h_down = i - 3; break; }
            }
            h_up = 3; // дефолтное значение, если рамки сверху нет
            for (int i = h_down; i >= 0; i--)
            {
                if (h2[i] == 0) { h_up = i + 3; break; }
            }

            // ищем в левой части картинки
            int w3 = width / 3;
            int[] v1 = new int[w3];
            for (int i = 0; i < w3; i++)
            {
                for (int j = height / 4; j < height; j++)
                {
                    int idx = GetIndexByXY(i, height - j - 1);
                    int idx1 = GetColor6bit(ba, idx);
                    if (idx1 == 63) { v1[i]++; }
                }
            }
            int v_med = GetMax(v1);
            int[] v2 = SubArr(v1, v_med /2);
            for (int i = 25; i < w3; i++) // начинаем смотреть с 25 линии
            {
                if (v2[i] == 0) { v_right = i - 3; break; }
            }
            v_left = 3; // дефолтное значение, если рамки сверху нет
            for (int i = v_right; i >= 0; i--)
            {
                if (v2[i] == 0) { v_left = i + 3; break; }
            }
        }
        /// <summary>
        /// находит разделители букв, они же сетка
        /// </summary>
        public void GetDelimiters()
        {
            int height = Img1.Height;
            int width = Img1.Width;
            byte[] ba = Parts[0].ba;
            // ищем в верхней части картинки
            int[] h1 = new int[width - v_right];
            for (int i = v_right; i < width; i++)
            {
                for (int j = h_up; j < h_down; j++)
                {
                    int idx = GetIndexByXY(i, height - j - 1);
                    int idx1 = GetColor6bit(ba, idx);
                    if (idx1 == 63) { h1[i - v_right]++; }
                }
            }
            // ищем в левой части картинки
            int[] v1 = new int[height - h_down];
            for (int i = h_down; i < height; i++)
            {
                for (int j = v_left; j < v_right; j++)
                {
                    int idx = GetIndexByXY(j, height - i - 1);
                    int idx1 = GetColor6bit(ba, idx);
                    if (idx1 == 63) { v1[i - h_down]++; }
                }
            }
            // далее надо найти переход от нулей к ненулям и наоборот, это соответственно начала и концы клеток
            List<Bounds> h_bounds2 = GetBounds(h1, v_right);
            List<Bounds> v_bounds2 = GetBounds(v1, h_down);
            // вырезаем картинки букв
            foreach (Bounds bb in h_bounds2)
            {
                h_bounds.Add(new Bounds(bb.start, bb.end,
                    Img1.Clone(new Rectangle(bb.start + 3, h_up + 3, bb.end - bb.start - 6, h_down - h_up - 6), Img1.PixelFormat)
                ));
            }
            foreach (Bounds bb in v_bounds2)
            {
                v_bounds.Add(new Bounds(bb.start, bb.end,
                    Img1.Clone(new Rectangle(v_left + 3, bb.start + 3, v_right - v_left - 6, bb.end - bb.start - 6), Img1.PixelFormat)
                ));
            }
        }
        /// <summary>
        /// получает список границ букв
        /// </summary>
        /// <param name="ar">массив с цуетами разделителей</param>
        /// <param name="shift">начальное смещение</param>
        /// <returns>список начал и концов букв</returns>
        public List<Bounds> GetBounds(int[] ar, int shift)
        {
            List<Bounds> res = new List<Bounds>();
            int prev_idx = -1;
            int curr = ar[0];
            for (int i = 1; i < ar.Length; i++)
            {
                int col = ar[i];
                if ((curr == 0) && (col != 0))
                {
                    //после черного - белый, сохранить индекс начала
                    prev_idx = i;
                    curr = col;
                }
                else if ((curr != 0) && (col == 0))
                {
                    //после белого черный - надо записать
                    if (prev_idx != -1)
                    {
                        res.Add(new Bounds(prev_idx + shift, i + shift - 1));
                    }
                    curr = col;
                }
            }
            if (curr != 0) { res.Add(new Bounds(prev_idx + shift, ar.Length + shift - 1)); }
            // убираем чрезмерно мелкие и большие
            List<Bounds> res2 = new List<Bounds>();
            if (res.Count < 3) { presentBounds = false; }
            else
            {

                int avg = 0;
                foreach (Bounds bb in res) { avg = avg + (bb.end - bb.start); }
                avg = avg / res.Count;
                foreach (Bounds bb in res)
                {
                    int diff = bb.end - bb.start;
                    if ((diff < avg * 1.5) && (diff > avg / 1.5))
                    {
                        res2.Add(bb);
                    }
                }
            }
            return res2;
        }
    }
}
