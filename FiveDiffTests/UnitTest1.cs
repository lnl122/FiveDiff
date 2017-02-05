using System;
using NUnit.Framework;
using System.Drawing;
using FiveDiff;

namespace FiveDiffTests
{
    /*
    [TestFixture]
    public class UnitTestNameExample
    {
        [Test]
        public void MethodName()
        {
            ImageDiff z = new ImageDiff(new Bitmap(@"C:\_2del\9\0.jpg"));
            Assert.AreEqual(0, z.nu_GetShHor());
        }
    }
    */

    [TestFixture]
    public class UnitTestShifts
    {
        [Test]
        public void nu_Shift_0_h()
        {
            ImageDiff z = new ImageDiff(new Bitmap(@"C:\_2del\9\0.jpg"));
            Assert.AreEqual(0+1, z.nu_GetShHor());
        }
        [Test]
        public void nu_Shift_0_v()
        {
            ImageDiff z = new ImageDiff(new Bitmap(@"C:\_2del\9\0.jpg"));
            Assert.AreEqual(0, z.nu_GetShVer());
        }
        [Test]
        public void nu_Shift_l_h()
        {
            ImageDiff z = new ImageDiff(new Bitmap(@"C:\_2del\9\l.jpg"));
            Assert.AreEqual(-5 + 1, z.nu_GetShHor());
        }
        [Test]
        public void nu_Shift_l_v()
        {
            ImageDiff z = new ImageDiff(new Bitmap(@"C:\_2del\9\l.jpg"));
            Assert.AreEqual(0, z.nu_GetShVer());
        }
        [Test]
        public void nu_Shift_r_h()
        {
            ImageDiff z = new ImageDiff(new Bitmap(@"C:\_2del\9\r.jpg"));
            Assert.AreEqual(5 + 1, z.nu_GetShHor());
        }
        [Test]
        public void nu_Shift_r_v()
        {
            ImageDiff z = new ImageDiff(new Bitmap(@"C:\_2del\9\r.jpg"));
            Assert.AreEqual(0, z.nu_GetShVer());
        }
        [Test]
        public void nu_Shift_u_h()
        {
            ImageDiff z = new ImageDiff(new Bitmap(@"C:\_2del\9\u.jpg"));
            Assert.AreEqual(0 + 1, z.nu_GetShHor());
        }
        [Test]
        public void nu_Shift_u_v()
        {
            ImageDiff z = new ImageDiff(new Bitmap(@"C:\_2del\9\u.jpg"));
            Assert.AreEqual(-6, z.nu_GetShVer());
        }
        [Test]
        public void nu_Shift_d_h()
        {
            ImageDiff z = new ImageDiff(new Bitmap(@"C:\_2del\9\d.jpg"));
            Assert.AreEqual(0 + 1, z.nu_GetShHor());
        }
        [Test]
        public void nu_Shift_d_v()
        {
            ImageDiff z = new ImageDiff(new Bitmap(@"C:\_2del\9\d.jpg"));
            Assert.AreEqual(5, z.nu_GetShVer());
        }
        [Test]
        public void nu_Shift_lu_h()
        {
            ImageDiff z = new ImageDiff(new Bitmap(@"C:\_2del\9\lu.jpg"));
            Assert.AreEqual(-6 + 1, z.nu_GetShHor());
        }
        [Test]
        public void nu_Shift_lu_v()
        {
            ImageDiff z = new ImageDiff(new Bitmap(@"C:\_2del\9\lu.jpg"));
            Assert.AreEqual(-7, z.nu_GetShVer());
        }
        [Test]
        public void nu_Shift_ld_h()
        {
            ImageDiff z = new ImageDiff(new Bitmap(@"C:\_2del\9\ld.jpg"));
            Assert.AreEqual(-5 + 1, z.nu_GetShHor());
        }
        [Test]
        public void nu_Shift_ld_v()
        {
            ImageDiff z = new ImageDiff(new Bitmap(@"C:\_2del\9\ld.jpg"));
            Assert.AreEqual(5, z.nu_GetShVer());
        }
        [Test]
        public void nu_Shift_rd_h()
        {
            ImageDiff z = new ImageDiff(new Bitmap(@"C:\_2del\9\rd.jpg"));
            Assert.AreEqual(6 + 1, z.nu_GetShHor());
        }
        [Test]
        public void nu_Shift_rd_v()
        {
            ImageDiff z = new ImageDiff(new Bitmap(@"C:\_2del\9\rd.jpg"));
            Assert.AreEqual(6, z.nu_GetShVer());
        }
        [Test]
        public void nu_Shift_ru_h()
        {
            ImageDiff z = new ImageDiff(new Bitmap(@"C:\_2del\9\ru.jpg"));
            Assert.AreEqual(5 + 1, z.nu_GetShHor());
        }
        [Test]
        public void nu_Shift_ru_v()
        {
            ImageDiff z = new ImageDiff(new Bitmap(@"C:\_2del\9\ru.jpg"));
            Assert.AreEqual(-6, z.nu_GetShVer());
        }
    }

    /*
    [TestFixture]
    public class UnitTestFuncs
    {
        [TestCase]
        public void nu_GetFiveMinIndex_1()
        {
            ImageDiff z = new ImageDiff(new Bitmap(100, 100));
            float[] a = new float[8] { 4.6f, 3.2f, 1.5f, 0.6f, 3.1f, 0.5f, 2.5f, 45.9f };
            int[] b = new int[5] { 5, 3, 2, 6, 4 };
            Assert.AreEqual(b, z.nu_GetFiveMinIndex(a));
        }
        [TestCase]
        public void nu_GetFiveMinIndex_2()
        {
            ImageDiff z = new ImageDiff(new Bitmap(100, 100));
            float[] a = new float[8] { 3.1f, 3.2f, 1.5f, 0.6f, 3.1f, 0.5f, 2.5f, 45.9f };
            int[] b = new int[5] { 5, 3, 2, 6, 0 };
            Assert.AreEqual(b, z.nu_GetFiveMinIndex(a));
        }
        [TestCase]
        public void nu_GetFiveMinIndex_3()
        {
            ImageDiff z = new ImageDiff(new Bitmap(100, 100));
            float[] a = new float[8] { 3.3f, 3.1f, 3.1f, 3.1f, 3.1f, 3.11f, 3.1f, 3.1f };
            int[] b = new int[5] { 1, 2, 3, 4, 6 };
            Assert.AreEqual(b, z.nu_GetFiveMinIndex(a));
        }
        [TestCase]
        public void nu_GetMinIndex_1()
        {
            ImageDiff z = new ImageDiff(new Bitmap(100, 100));
            float[] a = new float[4] { 4.6f, 3.1f, 1.5f, 45.9f };
            Assert.AreEqual(2, z.nu_GetMinIndex(a));
        }
        [TestCase]
        public void nu_GetMinIndex_2()
        {
            ImageDiff z = new ImageDiff(new Bitmap(100, 100));
            float[] a = new float[4] { 0.6f, 3.1f, 1.5f, 45.9f };
            Assert.AreEqual(0, z.nu_GetMinIndex(a));
        }
        [TestCase]
        public void nu_KillDupesShifts_1()
        {
            ImageDiff z = new ImageDiff(new Bitmap(100, 100));
            ImageDiff.ShArr[] arr1 = new ImageDiff.ShArr[5];
            ImageDiff.ShArr[] arr2 = new ImageDiff.ShArr[4];
            ImageDiff.ShArr q1 = new ImageDiff.ShArr();
            q1.shift_h = 10; q1.shift_v = 10; arr1[0] = q1; arr2[0] = q1;
            q1.shift_h = 20; q1.shift_v = 20; arr1[1] = q1; arr2[1] = q1;
            q1.shift_h = 24; q1.shift_v = -3; arr1[2] = q1; arr2[2] = q1;
            q1.shift_h = 20; q1.shift_v = 20; arr1[3] = q1;
            q1.shift_h = -9; q1.shift_v = -3; arr1[4] = q1; arr2[3] = q1;

            Assert.AreEqual(arr2, z.nu_KillDupesShifts(arr1));
        }
    }
    */
}
