// Copyright © 2016 Antony S. Ovsyannikov aka lnl122
// License: http://opensource.org/licenses/MIT

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
    // [TestFixtureSetUp] 
    // [TestFixtureTearDown]
    // [SetUp] 
    // [TearDown]
    // Assert.That( array/List , Has.Member(value) );
    // Assert.That( array/List , Has.No.Member(value) );
    // Assert.Contains( value, array/List );
        [Test]
        public void MethodName()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\9\0.jpg"));
            Assert.AreEqual(0, z.GetShHor());
        }
    }
    */

    [TestFixture]
    public class UnitTestAnswers
    {
        [Test]
        public void Answer00()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic00.jpg"), "RuLeA1");
            Assert.AreEqual("А1И3И4З8И8", z.Answer);
        }
        [Test]
        public void Answer01()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic01.jpg"), "RuLeA1");
            Assert.AreEqual("Г1Е4Е5К5Г7", z.Answer);
        }
        [Test]
        public void Answer02()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic02.jpg"), "RuLeA1");
            Assert.AreEqual("А1И3И4З8И8", z.Answer);
        }
        [Test]
        public void Answer03()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic03.jpg"), "RuLeA1");
            Assert.AreEqual("В2З5В6Е7К7", z.Answer);
        }
        [Test]
        public void Answer04()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic04.jpg"), "RuLeA1");
            Assert.AreEqual("Г4И4Б6Г6Д8", z.Answer);
        }
        [Test]
        public void Answer05()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic05.jpg"), "RuLeA1");
            Assert.AreEqual("М3Е4А5М5Д9", z.Answer);
        }
        [Test]
        public void Answer06()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic06.jpg"), "RuLeA1");
            Assert.AreEqual("Г3Р4Ж6К6Б7", z.Answer);
        }
        [Test]
        public void Answer07()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic07.jpg"), "RuLeA1");
            Assert.AreEqual("Е3М3И5Г7Д9", z.Answer);
        }
        [Test]
        public void Answer08()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic08.jpg"), "RuLeA1");
            Assert.AreEqual("М3Е4Б7З7К8", z.Answer);
        }
        /*
        [Test]
        public void Bounds11()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic11.jpg"), "LaLeA1");
            Assert.AreEqual(15, z.h_bounds.Count);
            Assert.AreEqual(8, z.v_bounds.Count);
        }
        [Test]
        public void Bounds12()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic12.jpg"), "LaLeA1");
            Assert.AreEqual(9, z.h_bounds.Count);
            Assert.AreEqual(7, z.v_bounds.Count);
        }
        [Test]
        public void Bounds13()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic13.jpg"), "LaUpA1");
            Assert.AreEqual(7, z.h_bounds.Count);
            Assert.AreEqual(4, z.v_bounds.Count);
        }
        [Test]
        public void Bounds14()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic14.jpg"), "LaUpA1");
            Assert.AreEqual(7, z.h_bounds.Count);
            Assert.AreEqual(6, z.v_bounds.Count);
        }
        [Test]
        public void Bounds15()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic15.jpg"), "LaLeA1");
            Assert.AreEqual(13, z.h_bounds.Count);
            Assert.AreEqual(8, z.v_bounds.Count);
        }
        [Test]
        public void Bounds16()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic16.jpg"), "RuLeA1");
            Assert.AreEqual(12, z.h_bounds.Count);
            Assert.AreEqual(9, z.v_bounds.Count);
        }
        [Test]
        public void Bounds17_none()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic17.jpg"), "LaUpA1");
            Assert.AreEqual(0, z.h_bounds.Count);
            Assert.AreEqual(0, z.v_bounds.Count);
        }
        [Test]
        public void Bounds18()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic18.jpg"), "LaUpA1");
            Assert.AreEqual(8, z.h_bounds.Count);
            Assert.AreEqual(5, z.v_bounds.Count);
        }
        [Test]
        public void Bounds19()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic19.jpg"), "LaUpA1");
            Assert.AreEqual(7, z.h_bounds.Count);
            Assert.AreEqual(6, z.v_bounds.Count);
        }
        [Test]
        public void Bounds20()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic20.jpg"), "LaUpA1");
            Assert.AreEqual(4, z.h_bounds.Count);
            Assert.AreEqual(6, z.v_bounds.Count);
        }
        [Test]
        public void Bounds21()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic21.jpg"), "LaLeA1");
            Assert.AreEqual(9, z.h_bounds.Count);
            Assert.AreEqual(9, z.v_bounds.Count);
        }*/
    }
    /*
    [TestFixture]
    public class UnitTestBounds
    {
        [Test]
        public void Bounds00()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic00.jpg"), "RuLeA1");
            Assert.AreEqual(11, z.h_bounds.Count);
            Assert.AreEqual(8, z.v_bounds.Count);
        }
        [Test]
        public void Bounds01()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic01.jpg"), "RuLeA1");
            Assert.AreEqual(10, z.h_bounds.Count);
            Assert.AreEqual(9, z.v_bounds.Count);
        }
        [Test]
        public void Bounds02()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic02.jpg"), "RuLeA1");
            Assert.AreEqual(11, z.h_bounds.Count);
            Assert.AreEqual(8, z.v_bounds.Count);
        }
        [Test]
        public void Bounds03()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic03.jpg"), "RuLeA1");
            Assert.AreEqual(11, z.h_bounds.Count);
            Assert.AreEqual(9, z.v_bounds.Count);
        }
        [Test]
        public void Bounds04()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic04.jpg"), "RuLeA1");
            Assert.AreEqual(11, z.h_bounds.Count);
            Assert.AreEqual(9, z.v_bounds.Count);
        }
        [Test]
        public void Bounds05()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic05.jpg"), "RuLeA1");
            Assert.AreEqual(12, z.h_bounds.Count);
            Assert.AreEqual(9, z.v_bounds.Count);
        }
        [Test]
        public void Bounds06()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic06.jpg"), "RuLeA1");
            Assert.AreEqual(16, z.h_bounds.Count);
            Assert.AreEqual(9, z.v_bounds.Count);
        }
        [Test]
        public void Bounds07()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic07.jpg"), "RuLeA1");
            Assert.AreEqual(12, z.h_bounds.Count);
            Assert.AreEqual(9, z.v_bounds.Count);
        }
        [Test]
        public void Bounds08()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic08.jpg"), "RuLeA1");
            Assert.AreEqual(14, z.h_bounds.Count);
            Assert.AreEqual(8, z.v_bounds.Count);
        }
        [Test]
        public void Bounds11()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic11.jpg"), "LaLeA1");
            Assert.AreEqual(15, z.h_bounds.Count);
            Assert.AreEqual(8, z.v_bounds.Count);
        }
        [Test]
        public void Bounds12()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic12.jpg"), "LaLeA1");
            Assert.AreEqual(9, z.h_bounds.Count);
            Assert.AreEqual(7, z.v_bounds.Count);
        }
        [Test]
        public void Bounds13()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic13.jpg"), "LaUpA1");
            Assert.AreEqual(7, z.h_bounds.Count);
            Assert.AreEqual(4, z.v_bounds.Count);
        }
        [Test]
        public void Bounds14()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic14.jpg"), "LaUpA1");
            Assert.AreEqual(7, z.h_bounds.Count);
            Assert.AreEqual(6, z.v_bounds.Count);
        }
        [Test]
        public void Bounds15()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic15.jpg"), "LaLeA1");
            Assert.AreEqual(13, z.h_bounds.Count);
            Assert.AreEqual(8, z.v_bounds.Count);
        }
        [Test]
        public void Bounds16()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic16.jpg"), "RuLeA1");
            Assert.AreEqual(12, z.h_bounds.Count);
            Assert.AreEqual(9, z.v_bounds.Count);
        }
        [Test]
        public void Bounds17_none()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic17.jpg"), "LaUpA1");
            Assert.AreEqual(0, z.h_bounds.Count);
            Assert.AreEqual(0, z.v_bounds.Count);
        }
        [Test]
        public void Bounds18()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic18.jpg"), "LaUpA1");
            Assert.AreEqual(8, z.h_bounds.Count);
            Assert.AreEqual(5, z.v_bounds.Count);
        }
        [Test]
        public void Bounds19()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic19.jpg"), "LaUpA1");
            Assert.AreEqual(7, z.h_bounds.Count);
            Assert.AreEqual(6, z.v_bounds.Count);
        }
        [Test]
        public void Bounds20()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic20.jpg"), "LaUpA1");
            Assert.AreEqual(4, z.h_bounds.Count);
            Assert.AreEqual(6, z.v_bounds.Count);
        }
        [Test]
        public void Bounds21()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\pic21.jpg"), "LaLeA1");
            Assert.AreEqual(9, z.h_bounds.Count);
            Assert.AreEqual(9, z.v_bounds.Count);
        }
    }
    */
    /*
    [TestFixture]
    public class UnitTestShifts2
    {
        [Test]
        public void Shifts0()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\9\0.jpg"));
            Assert.AreEqual(0 + 1, z.shift_hor);
            Assert.AreEqual(0, z.shift_ver);
        }
        [Test]
        public void ShiftsL()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\9\l.jpg"));
            Assert.AreEqual(-5 + 1, z.shift_hor);
            Assert.AreEqual(0, z.shift_ver);
        }
        [Test]
        public void ShiftsR()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\9\r.jpg"));
            Assert.AreEqual(5 + 1, z.shift_hor);
            Assert.AreEqual(0, z.shift_ver);
        }
        [Test]
        public void ShiftsU()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\9\u.jpg"));
            Assert.AreEqual(0 + 1, z.shift_hor);
            Assert.AreEqual(-6, z.shift_ver);
        }
        [Test]
        public void ShiftsD()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\9\d.jpg"));
            Assert.AreEqual(0 + 1, z.shift_hor);
            Assert.AreEqual(5, z.shift_ver);
        }
        [Test]
        public void ShiftsLU()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\9\lu.jpg"));
            Assert.AreEqual(-6 + 1, z.shift_hor);
            Assert.AreEqual(-7, z.shift_ver);
        }
        [Test]
        public void ShiftsLD()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\9\ld.jpg"));
            Assert.AreEqual(-5 + 1, z.shift_hor);
            Assert.AreEqual(5, z.shift_ver);
        }
        [Test]
        public void ShiftsRD()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\9\rd.jpg"));
            Assert.AreEqual(6 + 1, z.shift_hor);
            Assert.AreEqual(6, z.shift_ver);
        }
        [Test]
        public void ShiftsRU()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\9\ru.jpg"));
            Assert.AreEqual(5 + 1, z.shift_hor);
            Assert.AreEqual(-6, z.shift_ver);
        }
    }*/
    /*
    [TestFixture]
    public class UnitTestFuncs
    {
        [TestCase]
        public void GetFiveMinIndex_1()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\temp\01.jpg"));
            float[] a = new float[8] { 4.6f, 3.2f, 1.5f, 0.6f, 3.1f, 0.5f, 2.5f, 45.9f };
            int[] b = new int[5] { 5, 3, 2, 6, 4 };
            Assert.AreEqual(b, z.GetFiveMinIndex(a));
            z = new FindFiveDiff(new Bitmap(@"C:\temp\01.jpg"));
            a = new float[8] { 3.1f, 3.2f, 1.5f, 0.6f, 3.1f, 0.5f, 2.5f, 45.9f };
            b = new int[5] { 5, 3, 2, 6, 0 };
            Assert.AreEqual(b, z.GetFiveMinIndex(a));
            z = new FindFiveDiff(new Bitmap(@"C:\temp\01.jpg"));
            a = new float[8] { 3.3f, 3.1f, 3.1f, 3.1f, 3.1f, 3.11f, 3.1f, 3.1f };
            b = new int[5] { 1, 2, 3, 4, 6 };
            Assert.AreEqual(b, z.GetFiveMinIndex(a));
        }
        [TestCase]
        public void GetMinIndex_1()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\temp\01.jpg"));
            float[] a = new float[4] { 4.6f, 3.1f, 1.5f, 45.9f };
            Assert.AreEqual(2, z.GetMinIndex(a));
            a = new float[4] { 0.6f, 3.1f, 1.5f, 45.9f };
            Assert.AreEqual(0, z.GetMinIndex(a));
        }
        [TestCase]
        public void KillDupesShifts_1()
        {
            FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\temp\01.jpg"));
            FindFiveDiff.ShArr[] arr1 = new FindFiveDiff.ShArr[5];
            FindFiveDiff.ShArr[] arr2 = new FindFiveDiff.ShArr[4];
            FindFiveDiff.ShArr q1 = new FindFiveDiff.ShArr();
            q1.shift_h = 10; q1.shift_v = 10; arr1[0] = q1; arr2[0] = q1;
            q1.shift_h = 20; q1.shift_v = 20; arr1[1] = q1; arr2[1] = q1;
            q1.shift_h = 24; q1.shift_v = -3; arr1[2] = q1; arr2[2] = q1;
            q1.shift_h = 20; q1.shift_v = 20; arr1[3] = q1;
            q1.shift_h = -9; q1.shift_v = -3; arr1[4] = q1; arr2[3] = q1;

            Assert.AreEqual(arr2, z.KillDupesShifts(arr1));
        }
    }*/
}
