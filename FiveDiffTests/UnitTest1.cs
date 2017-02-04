using System;
using NUnit.Framework;
using System.Drawing;
using FiveDiff;

namespace FiveDiffTests
{
    public class UnitTest1
    {
        [Test]
        public void nu_GetFiveMinIndex_1()
        {
            ImageDiff z = new ImageDiff(new Bitmap(100, 100));
            float[] a = new float[8] { 4.6f, 3.2f, 1.5f, 0.6f, 3.1f, 0.5f, 2.5f, 45.9f };
            int[] b = new int[5] { 5, 3, 2, 6, 4 };
            Assert.AreEqual(b, z.nu_GetFiveMinIndex(a));
        }
        [Test]
        public void nu_GetFiveMinIndex_2()
        {
            ImageDiff z = new ImageDiff(new Bitmap(100, 100));
            float[] a = new float[8] { 3.1f, 3.2f, 1.5f, 0.6f, 3.1f, 0.5f, 2.5f, 45.9f };
            int[] b = new int[5] { 5, 3, 2, 6, 0 };
            Assert.AreEqual(b, z.nu_GetFiveMinIndex(a));
        }
        [Test]
        public void nu_GetFiveMinIndex_3()
        {
            ImageDiff z = new ImageDiff(new Bitmap(100, 100));
            float[] a = new float[8] { 3.3f, 3.1f, 3.1f, 3.1f, 3.1f, 3.11f, 3.1f, 3.1f };
            int[] b = new int[5] { 1, 2, 3, 4, 6 };
            Assert.AreEqual(b, z.nu_GetFiveMinIndex(a));
        }
        [Test]
        public void nu_GetMinIndex_1()
        {
            ImageDiff z = new ImageDiff(new Bitmap(100, 100));
            float[] a = new float[4] { 4.6f, 3.1f, 1.5f, 45.9f };
            Assert.AreEqual(2, z.nu_GetMinIndex(a));
        }
        [Test]
        public void nu_GetMinIndex_2()
        {
            ImageDiff z = new ImageDiff(new Bitmap(100, 100));
            float[] a = new float[4] { 0.6f, 3.1f, 1.5f, 45.9f };
            Assert.AreEqual(0, z.nu_GetMinIndex(a));
        }

    }
}
