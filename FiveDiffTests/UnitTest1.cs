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
    /*
    [TestFixture]
    public class UnitTestAllBounds_1
    {
        [Test]
        public void Bounds_А1Ж4К6Ж7К8_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\А1Ж4К6Ж7К8-1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_А1И3И4З8И8_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\А1И3И4З8И8-1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_А2К2З4Д6Л6_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\А2К2З4Д6Л6-1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_Б1Д3А4Л5З6_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Б1Д3А4Л5З6-1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_Б1Л7В8И8В9_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Б1Л7В8И8В9-1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_Б2Г2Ж2Е5И10_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Б2Г2Ж2Е5И10-1.jpg"), "RuLeA1"); Assert.AreEqual(9, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_Б3Д4А6И6Ж8_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Б3Д4А6И6Ж8-1.jpg"), "RuLeA1"); Assert.AreEqual(9, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_Б3Ж3Е6З6В7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Б3Ж3Е6З6В7-1.jpg"), "RuLeA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_В1Е1Ж6Б7Е7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\В1Е1Ж6Б7Е7-1.jpg"), "RuLeA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_В1Л2Г3К5М9_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\В1Л2Г3К5М9-1.jpg"), "RuLeA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_В2З5В6Е7К7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\В2З5В6Е7К7-1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_Г1Е4Е5К5Г7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Г1Е4Е5К5Г7-1.jpg"), "RuLeA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_Г1И1К4Г8К8_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Г1И1К4Г8К8-1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_Г3З3К4Е7И8_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Г3З3К4Е7И8-1.jpg"), "RuLeA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_Г3Р4Ж6К6Б7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Г3Р4Ж6К6Б7-1.jpg"), "RuLeA1"); Assert.AreEqual(16, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_Г4И4Б6Г6Д8_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Г4И4Б6Г6Д8-1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_Д1К2В4Г5Ж8_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Д1К2В4Г5Ж8-1.jpg"), "RuLeA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_Д2В3К5Д6Б7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Д2В3К5Д6Б7-1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_Д4К4Л6А8Б9_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Д4К4Л6А8Б9-1.jpg"), "RuLeA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_Е1Д4В5И8Г9_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Е1Д4В5И8Г9-1.jpg"), "RuLeA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_Е2В4И4Б6Л8_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Е2В4И4Б6Л8-1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_Е2Д3В6И7Г10_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Е2Д3В6И7Г10-1.jpg"), "RuLeA1"); Assert.AreEqual(9, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_Е2З3А8Е9З9_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Е2З3А8Е9З9-1.jpg"), "RuLeA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_Е3М3И5Г7Д9_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Е3М3И5Г7Д9-1.jpg"), "RuLeA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_Ж1З3А8З8Д9_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Ж1З3А8З8Д9-1.jpg"), "RuLeA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_Ж2В3К3И5Е7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Ж2В3К3И5Е7-1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_Ж2В4Д7Г9Е10_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Ж2В4Д7Г9Е10-1.jpg"), "RuLeA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_Ж2Г3З4В6И9_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Ж2Г3З4В6И9-1.jpg"), "RuLeA1"); Assert.AreEqual(9, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_З1А2Г3Ж5А8_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\З1А2Г3Ж5А8-1.jpg"), "RuLeA1"); Assert.AreEqual(9, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_З1Г4Д5В6З7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\З1Г4Д5В6З7-1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_И1А2З3Б5Е6_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\И1А2З3Б5Е6-1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_К1А2Е2Ж5В7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\К1А2Е2Ж5В7-1.jpg"), "RuLeA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_К1Б2К2И3В4_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\К1Б2К2И3В4-1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_Л1И3Б4Г6Е7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Л1И3Б4Г6Е7-1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_М3Е4А5М5Д9_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\М3Е4А5М5Д9-1.jpg"), "RuLeA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_М3Е4Б7З7К8_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\М3Е4Б7З7К8-1.jpg"), "RuLeA1"); Assert.AreEqual(14, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_A1A3A7C1C2_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1A3A7C1C2-1.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(4, z.rows); }
        [Test]
        public void Bounds_A1A4E2F2F4_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1A4E2F2F4-1.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(6, z.rows); }
        [Test]
        public void Bounds_A1B2B5D2D5_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1B2B5D2D5-1.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(4, z.rows); }
        [Test]
        public void Bounds_A1B3B6D5E2_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1B3B6D5E2-1.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A1D3E4G3G5_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1D3E4G3G5-1.jpg"), "EnUpA1"); Assert.AreEqual(5, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_A2B1B3E3G1_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A2B1B3E3G1-1.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(7, z.rows); }
        [Test]
        public void Bounds_A2B5C5D5D7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A2B5C5D5D7-1.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A2B6C3D6E2_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A2B6C3D6E2-1.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A3A4C3D4F4_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A3A4C3D4F4-1.jpg"), "EnUpA1"); Assert.AreEqual(5, z.columns); Assert.AreEqual(7, z.rows); }
        [Test]
        public void Bounds_A3B3B4C7D3_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A3B3B4C7D3-1.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(4, z.rows); }
        [Test]
        public void Bounds_A3B8D3E1E7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A3B8D3E1E7-1.jpg"), "EnUpA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A4B1B5C3C6_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B1B5C3C6-1.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(4, z.rows); }
        [Test]
        public void Bounds_A4B1C1E2F2_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B1C1E2F2-1.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(6, z.rows); }
        [Test]
        public void Bounds_A4B2C1D2D5_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B2C1D2D5-1.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(4, z.rows); }
        [Test]
        public void Bounds_A4B5C7D1E7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B5C7D1E7-1.jpg"), "EnUpA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A4B6D4D6D7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B6D4D6D7-1.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A5B2B4B7E6_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A5B2B4B7E6-1.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A5B2C2D2D5_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A5B2C2D2D5-1.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(4, z.rows); }
        [Test]
        public void Bounds_A5C5C6D2E1_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A5C5C6D2E1-1.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A7B1B7D1E5_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A7B1B7D1E5-1.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A7B1D1D5D7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A7B1D1D5D7-1.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A7B6C1C2D6_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A7B6C1C2D6-1.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(4, z.rows); }
        [Test]
        public void Bounds_B1B4B6C3E5_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B1B4B6C3E5-1.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_B1B6D3E1E6_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B1B6D3E1E6-1.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(6, z.rows); }
        [Test]
        public void Bounds_B2B5D6E2E3_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B2B5D6E2E3-1.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_B2C4D2D4E3_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B2C4D2D4E3-1.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(6, z.rows); }
        [Test]
        public void Bounds_B3B4C3C4E1_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B3B4C3C4E1-1.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_B4D5D6E2F4_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B4D5D6E2F4-1.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(6, z.rows); }
        [Test]
        public void Bounds_B6C1C4E4F1_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B6C1C4E4F1-1.jpg"), "EnUpA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(6, z.rows); }
        [Test]
        public void Bounds_B6C3C4D2E5_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B6C3C4D2E5-1.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_1A3H5A5I9E_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1A3H5A5I9E-1.jpg"), "EnLe1A"); Assert.AreEqual(9, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_1B4H7A7D7H_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1B4H7A7D7H-1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_1C2J3D5J7G_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1C2J3D5J7G-1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_1C3F7I8L9B_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1C3F7I8L9B-1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_1D3G4E4J5L_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1D3G4E4J5L-1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_1F2C3J6I7I_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1F2C3J6I7I-1.jpg"), "EnLe1A"); Assert.AreEqual(15, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_1G3B3J6M7G_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1G3B3J6M7G-1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_1G3E5B5F7B_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1G3E5B5F7B-1.jpg"), "EnLe1A"); Assert.AreEqual(9, z.columns); Assert.AreEqual(11, z.rows); }
        [Test]
        public void Bounds_1I2F5I5K5L_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1I2F5I5K5L-1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_1I4F4K7L9H_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1I4F4K7L9H-1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_1K3G3L5A7G_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1K3G3L5A7G-1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_1L3G6G6K9E_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1L3G6G6K9E-1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_1M4H4N7D8C_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1M4H4N7D8C-1.jpg"), "EnLe1A"); Assert.AreEqual(14, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_2B2G3K5D8F_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2B2G3K5D8F-1.jpg"), "EnLe1A"); Assert.AreEqual(11, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_2B2G5H5K6A_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2B2G5H5K6A-1.jpg"), "EnLe1A"); Assert.AreEqual(11, z.columns); Assert.AreEqual(7, z.rows); }
        [Test]
        public void Bounds_2B2H2N7E8N_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2B2H2N7E8N-1.jpg"), "EnLe1A"); Assert.AreEqual(16, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_2I3L7F7H8B_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2I3L7F7H8B-1.jpg"), "EnLe1A"); Assert.AreEqual(14, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_2J3G4F5C5J_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2J3G4F5C5J-1.jpg"), "EnLe1A"); Assert.AreEqual(14, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_2L3K7L8G9A_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2L3K7L8G9A-1.jpg"), "EnLe1A"); Assert.AreEqual(16, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_2L5M6L7B8J_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2L5M6L7B8J-1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_3A3D4B5K7L_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3A3D4B5K7L-1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_3A5A6H6P9D_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3A5A6H6P9D-1.jpg"), "EnLe1A"); Assert.AreEqual(16, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_3B6N8A8L9C_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3B6N8A8L9C-1.jpg"), "EnLe1A"); Assert.AreEqual(16, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_3C3F3I4B6C_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3C3F3I4B6C-1.jpg"), "EnLe1A"); Assert.AreEqual(9, z.columns); Assert.AreEqual(7, z.rows); }
        [Test]
        public void Bounds_3C4G4L6F6H_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3C4G4L6F6H-1.jpg"), "EnLe1A"); Assert.AreEqual(12, z.columns); Assert.AreEqual(7, z.rows); }
        [Test]
        public void Bounds_3D4K6G7B7E_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3D4K6G7B7E-1.jpg"), "EnLe1A"); Assert.AreEqual(12, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_3G4E5E6E10E_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3G4E5E6E10E-1.jpg"), "EnLe1A"); Assert.AreEqual(10, z.columns); Assert.AreEqual(12, z.rows); }
        [Test]
        public void Bounds_3G6C6F9D9K_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3G6C6F9D9K-1.jpg"), "EnLe1A"); Assert.AreEqual(11, z.columns); Assert.AreEqual(11, z.rows); }
        [Test]
        public void Bounds_3H7B7G8H8J_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3H7B7G8H8J-1.jpg"), "EnLe1A"); Assert.AreEqual(15, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_3J4H6B6H7D_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3J4H6B6H7D-1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_3L6B6E6H6M_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3L6B6E6H6M-1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_4A5E8F8H9I_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4A5E8F8H9I-1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(16, z.rows); }
        [Test]
        public void Bounds_4E4L5H6E8K_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4E4L5H6E8K-1.jpg"), "EnLe1A"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_4G7L9G9L10C_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4G7L9G9L10C-1.jpg"), "EnLe1A"); Assert.AreEqual(16, z.columns); Assert.AreEqual(11, z.rows); }
        [Test]
        public void Bounds_4H5J5M6B8G_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4H5J5M6B8G-1.jpg"), "EnLe1A"); Assert.AreEqual(14, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_4K6E6J6K7F_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4K6E6J6K7F-1.jpg"), "EnLe1A"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_4M7I10E10G10J_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4M7I10E10G10J-1.jpg"), "EnLe1A"); Assert.AreEqual(16, z.columns); Assert.AreEqual(11, z.rows); }
        [Test]
        public void Bounds_5E6C7N7O10M_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\5E6C7N7O10M-1.jpg"), "EnLe1A"); Assert.AreEqual(16, z.columns); Assert.AreEqual(11, z.rows); }

    }
    */
    
    [TestFixture]
    public class UnitTestAllBounds_2
    {
        [Test]
        public void Bounds_А1Ж4К6Ж7К8_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\А1Ж4К6Ж7К8-2.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_А1И3И4З8И8_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\А1И3И4З8И8-2.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_А2К2З4Д6Л6_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\А2К2З4Д6Л6-2.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_Б1Д3А4Л5З6_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Б1Д3А4Л5З6-2.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_Б1Л7В8И8В9_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Б1Л7В8И8В9-2.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_Б2Г2Ж2Е5И10_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Б2Г2Ж2Е5И10-2.jpg"), "RuLeA1"); Assert.AreEqual(9, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_Б3Д4А6И6Ж8_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Б3Д4А6И6Ж8-2.jpg"), "RuLeA1"); Assert.AreEqual(9, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_Б3Ж3Е6З6В7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Б3Ж3Е6З6В7-2.jpg"), "RuLeA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_В1Е1Ж6Б7Е7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\В1Е1Ж6Б7Е7-2.jpg"), "RuLeA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_В1Л2Г3К5М9_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\В1Л2Г3К5М9-2.jpg"), "RuLeA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_В2З5В6Е7К7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\В2З5В6Е7К7-2.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_Г1Е4Е5К5Г7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Г1Е4Е5К5Г7-2.jpg"), "RuLeA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_Г1И1К4Г8К8_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Г1И1К4Г8К8-2.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_Г3З3К4Е7И8_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Г3З3К4Е7И8-2.jpg"), "RuLeA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_Г3Р4Ж6К6Б7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Г3Р4Ж6К6Б7-2.jpg"), "RuLeA1"); Assert.AreEqual(16, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_Г4И4Б6Г6Д8_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Г4И4Б6Г6Д8-2.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_Д1К2В4Г5Ж8_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Д1К2В4Г5Ж8-2.jpg"), "RuLeA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_Д2В3К5Д6Б7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Д2В3К5Д6Б7-2.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_Д4К4Л6А8Б9_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Д4К4Л6А8Б9-2.jpg"), "RuLeA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_Е1Д4В5И8Г9_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Е1Д4В5И8Г9-2.jpg"), "RuLeA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_Е2В4И4Б6Л8_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Е2В4И4Б6Л8-2.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_Е2Д3В6И7Г10_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Е2Д3В6И7Г10-2.jpg"), "RuLeA1"); Assert.AreEqual(9, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_Е2З3А8Е9З9_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Е2З3А8Е9З9-2.jpg"), "RuLeA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_Е3М3И5Г7Д9_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Е3М3И5Г7Д9-2.jpg"), "RuLeA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_Ж1З3А8З8Д9_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Ж1З3А8З8Д9-2.jpg"), "RuLeA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_Ж2В3К3И5Е7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Ж2В3К3И5Е7-2.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_Ж2В4Д7Г9Е10_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Ж2В4Д7Г9Е10-2.jpg"), "RuLeA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_Ж2Г3З4В6И9_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Ж2Г3З4В6И9-2.jpg"), "RuLeA1"); Assert.AreEqual(9, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_З1А2Г3Ж5А8_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\З1А2Г3Ж5А8-2.jpg"), "RuLeA1"); Assert.AreEqual(9, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_З1Г4Д5В6З7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\З1Г4Д5В6З7-2.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_И1А2З3Б5Е6_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\И1А2З3Б5Е6-2.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_К1А2Е2Ж5В7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\К1А2Е2Ж5В7-2.jpg"), "RuLeA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_К1Б2К2И3В4_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\К1Б2К2И3В4-2.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_Л1И3Б4Г6Е7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Л1И3Б4Г6Е7-2.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_М3Е4А5М5Д9_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\М3Е4А5М5Д9-2.jpg"), "RuLeA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_М3Е4Б7З7К8_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\М3Е4Б7З7К8-2.jpg"), "RuLeA1"); Assert.AreEqual(14, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_A1A3A7C1C2_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1A3A7C1C2-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(4, z.rows); }
        [Test]
        public void Bounds_A1A3A7C1C2_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1A3A7C1C2-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(4, z.rows); }
        [Test]
        public void Bounds_A1A4E2F2F4_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1A4E2F2F4-2.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(6, z.rows); }
        [Test]
        public void Bounds_A1A4E2F2F4_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1A4E2F2F4-3.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(6, z.rows); }
        [Test]
        public void Bounds_A1B2B5D2D5_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1B2B5D2D5-2.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(4, z.rows); }
        [Test]
        public void Bounds_A1B2B5D2D5_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1B2B5D2D5-3.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(4, z.rows); }
        [Test]
        public void Bounds_A1B3B6D5E2_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1B3B6D5E2-2.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A1B3B6D5E2_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1B3B6D5E2-3.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A1D3E4G3G5_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1D3E4G3G5-2.jpg"), "EnUpA1"); Assert.AreEqual(5, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_A1D3E4G3G5_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1D3E4G3G5-3.jpg"), "EnUpA1"); Assert.AreEqual(5, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_A2B1B3E3G1_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A2B1B3E3G1-2.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(7, z.rows); }
        [Test]
        public void Bounds_A2B1B3E3G1_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A2B1B3E3G1-3.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(7, z.rows); }
        [Test]
        public void Bounds_A2B5C5D5D7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A2B5C5D5D7-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A2B5C5D5D7_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A2B5C5D5D7-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A2B6C3D6E2_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A2B6C3D6E2-2.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A2B6C3D6E2_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A2B6C3D6E2-3.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A3A4C3D4F4_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A3A4C3D4F4-2.jpg"), "EnUpA1"); Assert.AreEqual(5, z.columns); Assert.AreEqual(7, z.rows); }
        [Test]
        public void Bounds_A3A4C3D4F4_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A3A4C3D4F4-3.jpg"), "EnUpA1"); Assert.AreEqual(5, z.columns); Assert.AreEqual(7, z.rows); }
        [Test]
        public void Bounds_A3B3B4C7D3_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A3B3B4C7D3-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(4, z.rows); }
        [Test]
        public void Bounds_A3B3B4C7D3_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A3B3B4C7D3-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(4, z.rows); }
        [Test]
        public void Bounds_A3B8D3E1E7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A3B8D3E1E7-2.jpg"), "EnUpA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A3B8D3E1E7_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A3B8D3E1E7-3.jpg"), "EnUpA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A4B1B5C3C6_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B1B5C3C6-2.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(4, z.rows); }
        [Test]
        public void Bounds_A4B1B5C3C6_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B1B5C3C6-3.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(4, z.rows); }
        [Test]
        public void Bounds_A4B1C1E2F2_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B1C1E2F2-2.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(6, z.rows); }
        [Test]
        public void Bounds_A4B1C1E2F2_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B1C1E2F2-3.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(6, z.rows); }
        [Test]
        public void Bounds_A4B2C1D2D5_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B2C1D2D5-2.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(4, z.rows); }
        [Test]
        public void Bounds_A4B2C1D2D5_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B2C1D2D5-3.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(4, z.rows); }
        [Test]
        public void Bounds_A4B5C7D1E7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B5C7D1E7-2.jpg"), "EnUpA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A4B5C7D1E7_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B5C7D1E7-3.jpg"), "EnUpA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A4B6D4D6D7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B6D4D6D7-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A4B6D4D6D7_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B6D4D6D7-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A5B2B4B7E6_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A5B2B4B7E6-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A5B2B4B7E6_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A5B2B4B7E6-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A5B2C2D2D5_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A5B2C2D2D5-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(4, z.rows); }
        [Test]
        public void Bounds_A5B2C2D2D5_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A5B2C2D2D5-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(4, z.rows); }
        [Test]
        public void Bounds_A5C5C6D2E1_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A5C5C6D2E1-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A5C5C6D2E1_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A5C5C6D2E1-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A7B1B7D1E5_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A7B1B7D1E5-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A7B1B7D1E5_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A7B1B7D1E5-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A7B1D1D5D7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A7B1D1D5D7-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A7B1D1D5D7_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A7B1D1D5D7-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_A7B6C1C2D6_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A7B6C1C2D6-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(4, z.rows); }
        [Test]
        public void Bounds_A7B6C1C2D6_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A7B6C1C2D6-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(4, z.rows); }
        [Test]
        public void Bounds_B1B4B6C3E5_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B1B4B6C3E5-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_B1B4B6C3E5_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B1B4B6C3E5-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_B1B6D3E1E6_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B1B6D3E1E6-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(6, z.rows); }
        [Test]
        public void Bounds_B1B6D3E1E6_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B1B6D3E1E6-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(6, z.rows); }
        [Test]
        public void Bounds_B2B5D6E2E3_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B2B5D6E2E3-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_B2B5D6E2E3_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B2B5D6E2E3-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_B2C4D2D4E3_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B2C4D2D4E3-2.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(6, z.rows); }
        [Test]
        public void Bounds_B2C4D2D4E3_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B2C4D2D4E3-3.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(6, z.rows); }
        [Test]
        public void Bounds_B3B4C3C4E1_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B3B4C3C4E1-2.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_B3B4C3C4E1_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B3B4C3C4E1-3.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_B4D5D6E2F4_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B4D5D6E2F4-2.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(6, z.rows); }
        [Test]
        public void Bounds_B4D5D6E2F4_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B4D5D6E2F4-3.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(6, z.rows); }
        [Test]
        public void Bounds_B6C1C4E4F1_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B6C1C4E4F1-2.jpg"), "EnUpA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(6, z.rows); }
        [Test]
        public void Bounds_B6C1C4E4F1_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B6C1C4E4F1-3.jpg"), "EnUpA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(6, z.rows); }
        [Test]
        public void Bounds_B6C3C4D2E5_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B6C3C4D2E5-2.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_B6C3C4D2E5_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B6C3C4D2E5-3.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(5, z.rows); }
        [Test]
        public void Bounds_1A3H5A5I9E_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1A3H5A5I9E-2.jpg"), "EnLe1A"); Assert.AreEqual(9, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_1B4H7A7D7H_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1B4H7A7D7H-2.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_1C2J3D5J7G_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1C2J3D5J7G-2.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_1C3F7I8L9B_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1C3F7I8L9B-2.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_1D3G4E4J5L_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1D3G4E4J5L-2.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_1F2C3J6I7I_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1F2C3J6I7I-2.jpg"), "EnLe1A"); Assert.AreEqual(15, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_1G3B3J6M7G_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1G3B3J6M7G-2.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_1G3E5B5F7B_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1G3E5B5F7B-2.jpg"), "EnLe1A"); Assert.AreEqual(9, z.columns); Assert.AreEqual(11, z.rows); }
        [Test]
        public void Bounds_1I2F5I5K5L_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1I2F5I5K5L-2.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_1I4F4K7L9H_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1I4F4K7L9H-2.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_1K3G3L5A7G_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1K3G3L5A7G-2.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_1L3G6G6K9E_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1L3G6G6K9E-2.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_1M4H4N7D8C_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1M4H4N7D8C-2.jpg"), "EnLe1A"); Assert.AreEqual(14, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_2B2G3K5D8F_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2B2G3K5D8F-2.jpg"), "EnLe1A"); Assert.AreEqual(11, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_2B2G5H5K6A_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2B2G5H5K6A-2.jpg"), "EnLe1A"); Assert.AreEqual(11, z.columns); Assert.AreEqual(7, z.rows); }
        [Test]
        public void Bounds_2B2H2N7E8N_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2B2H2N7E8N-2.jpg"), "EnLe1A"); Assert.AreEqual(16, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_2I3L7F7H8B_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2I3L7F7H8B-2.jpg"), "EnLe1A"); Assert.AreEqual(14, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_2J3G4F5C5J_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2J3G4F5C5J-2.jpg"), "EnLe1A"); Assert.AreEqual(14, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_2L3K7L8G9A_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2L3K7L8G9A-2.jpg"), "EnLe1A"); Assert.AreEqual(16, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_2L5M6L7B8J_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2L5M6L7B8J-2.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_3A3D4B5K7L_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3A3D4B5K7L-2.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_3A5A6H6P9D_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3A5A6H6P9D-2.jpg"), "EnLe1A"); Assert.AreEqual(16, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_3B6N8A8L9C_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3B6N8A8L9C-2.jpg"), "EnLe1A"); Assert.AreEqual(16, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_3C3F3I4B6C_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3C3F3I4B6C-2.jpg"), "EnLe1A"); Assert.AreEqual(9, z.columns); Assert.AreEqual(7, z.rows); }
        [Test]
        public void Bounds_3C4G4L6F6H_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3C4G4L6F6H-2.jpg"), "EnLe1A"); Assert.AreEqual(12, z.columns); Assert.AreEqual(7, z.rows); }
        [Test]
        public void Bounds_3D4K6G7B7E_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3D4K6G7B7E-2.jpg"), "EnLe1A"); Assert.AreEqual(12, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_3G4E5E6E10E_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3G4E5E6E10E-2.jpg"), "EnLe1A"); Assert.AreEqual(10, z.columns); Assert.AreEqual(12, z.rows); }
        [Test]
        public void Bounds_3G6C6F9D9K_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3G6C6F9D9K-2.jpg"), "EnLe1A"); Assert.AreEqual(11, z.columns); Assert.AreEqual(11, z.rows); }
        [Test]
        public void Bounds_3H7B7G8H8J_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3H7B7G8H8J-2.jpg"), "EnLe1A"); Assert.AreEqual(15, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_3J4H6B6H7D_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3J4H6B6H7D-2.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); }
        [Test]
        public void Bounds_3L6B6E6H6M_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3L6B6E6H6M-2.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(10, z.rows); }
        [Test]
        public void Bounds_4A5E8F8H9I_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4A5E8F8H9I-2.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(16, z.rows); }
        [Test]
        public void Bounds_4E4L5H6E8K_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4E4L5H6E8K-2.jpg"), "EnLe1A"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_4G7L9G9L10C_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4G7L9G9L10C-2.jpg"), "EnLe1A"); Assert.AreEqual(16, z.columns); Assert.AreEqual(11, z.rows); }
        [Test]
        public void Bounds_4H5J5M6B8G_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4H5J5M6B8G-2.jpg"), "EnLe1A"); Assert.AreEqual(14, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_4K6E6J6K7F_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4K6E6J6K7F-2.jpg"), "EnLe1A"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); }
        [Test]
        public void Bounds_4M7I10E10G10J_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4M7I10E10G10J-2.jpg"), "EnLe1A"); Assert.AreEqual(16, z.columns); Assert.AreEqual(11, z.rows); }
        [Test]
        public void Bounds_5E6C7N7O10M_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\5E6C7N7O10M-2.jpg"), "EnLe1A"); Assert.AreEqual(16, z.columns); Assert.AreEqual(11, z.rows); }

    }
    
    /*
    [TestFixture]
    public class UnitTestAllAnswers_1
    {
        [Test]
        public void Answer_А1Ж4К6Ж7К8_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\А1Ж4К6Ж7К8-1.jpg"), "RuLeA1"); Assert.AreEqual("А1Ж4К6Ж7К8", z.Answer); }
        [Test]
        public void Answer_А1И3И4З8И8_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\А1И3И4З8И8-1.jpg"), "RuLeA1"); Assert.AreEqual("А1И3И4З8И8", z.Answer); }
        [Test]
        public void Answer_А2К2З4Д6Л6_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\А2К2З4Д6Л6-1.jpg"), "RuLeA1"); Assert.AreEqual("А2К2З4Д6Л6", z.Answer); }
        [Test]
        public void Answer_Б1Д3А4Л5З6_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Б1Д3А4Л5З6-1.jpg"), "RuLeA1"); Assert.AreEqual("Б1Д3А4Л5З6", z.Answer); }
        [Test]
        public void Answer_Б1Л7В8И8В9_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Б1Л7В8И8В9-1.jpg"), "RuLeA1"); Assert.AreEqual("Б1Л7В8И8В9", z.Answer); }
        [Test]
        public void Answer_Б2Г2Ж2Е5И10_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Б2Г2Ж2Е5И10-1.jpg"), "RuLeA1"); Assert.AreEqual("Б2Г2Ж2Е5И10", z.Answer); }
        [Test]
        public void Answer_Б3Д4А6И6Ж8_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Б3Д4А6И6Ж8-1.jpg"), "RuLeA1"); Assert.AreEqual("Б3Д4А6И6Ж8", z.Answer); }
        [Test]
        public void Answer_Б3Ж3Е6З6В7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Б3Ж3Е6З6В7-1.jpg"), "RuLeA1"); Assert.AreEqual("Б3Ж3Е6З6В7", z.Answer); }
        [Test]
        public void Answer_В1Е1Ж6Б7Е7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\В1Е1Ж6Б7Е7-1.jpg"), "RuLeA1"); Assert.AreEqual("В1Е1Ж6Б7Е7", z.Answer); }
        [Test]
        public void Answer_В1Л2Г3К5М9_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\В1Л2Г3К5М9-1.jpg"), "RuLeA1"); Assert.AreEqual("В1Л2Г3К5М9", z.Answer); }
        [Test]
        public void Answer_В2З5В6Е7К7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\В2З5В6Е7К7-1.jpg"), "RuLeA1"); Assert.AreEqual("В2З5В6Е7К7", z.Answer); }
        [Test]
        public void Answer_Г1Е4Е5К5Г7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Г1Е4Е5К5Г7-1.jpg"), "RuLeA1"); Assert.AreEqual("Г1Е4Е5К5Г7", z.Answer); }
        [Test]
        public void Answer_Г1И1К4Г8К8_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Г1И1К4Г8К8-1.jpg"), "RuLeA1"); Assert.AreEqual("Г1И1К4Г8К8", z.Answer); }
        [Test]
        public void Answer_Г3З3К4Е7И8_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Г3З3К4Е7И8-1.jpg"), "RuLeA1"); Assert.AreEqual("Г3З3К4Е7И8", z.Answer); }
        [Test]
        public void Answer_Г3Р4Ж6К6Б7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Г3Р4Ж6К6Б7-1.jpg"), "RuLeA1"); Assert.AreEqual("Г3Р4Ж6К6Б7", z.Answer); }
        [Test]
        public void Answer_Г4И4Б6Г6Д8_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Г4И4Б6Г6Д8-1.jpg"), "RuLeA1"); Assert.AreEqual("Г4И4Б6Г6Д8", z.Answer); }
        [Test]
        public void Answer_Д1К2В4Г5Ж8_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Д1К2В4Г5Ж8-1.jpg"), "RuLeA1"); Assert.AreEqual("Д1К2В4Г5Ж8", z.Answer); }
        [Test]
        public void Answer_Д2В3К5Д6Б7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Д2В3К5Д6Б7-1.jpg"), "RuLeA1"); Assert.AreEqual("Д2В3К5Д6Б7", z.Answer); }
        [Test]
        public void Answer_Д4К4Л6А8Б9_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Д4К4Л6А8Б9-1.jpg"), "RuLeA1"); Assert.AreEqual("Д4К4Л6А8Б9", z.Answer); }
        [Test]
        public void Answer_Е1Д4В5И8Г9_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Е1Д4В5И8Г9-1.jpg"), "RuLeA1"); Assert.AreEqual("Е1Д4В5И8Г9", z.Answer); }
        [Test]
        public void Answer_Е2В4И4Б6Л8_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Е2В4И4Б6Л8-1.jpg"), "RuLeA1"); Assert.AreEqual("Е2В4И4Б6Л8", z.Answer); }
        [Test]
        public void Answer_Е2Д3В6И7Г10_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Е2Д3В6И7Г10-1.jpg"), "RuLeA1"); Assert.AreEqual("Е2Д3В6И7Г10", z.Answer); }
        [Test]
        public void Answer_Е2З3А8Е9З9_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Е2З3А8Е9З9-1.jpg"), "RuLeA1"); Assert.AreEqual("Е2З3А8Е9З9", z.Answer); }
        [Test]
        public void Answer_Е3М3И5Г7Д9_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Е3М3И5Г7Д9-1.jpg"), "RuLeA1"); Assert.AreEqual("Е3М3И5Г7Д9", z.Answer); }
        [Test]
        public void Answer_Ж1З3А8З8Д9_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Ж1З3А8З8Д9-1.jpg"), "RuLeA1"); Assert.AreEqual("Ж1З3А8З8Д9", z.Answer); }
        [Test]
        public void Answer_Ж2В3К3И5Е7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Ж2В3К3И5Е7-1.jpg"), "RuLeA1"); Assert.AreEqual("Ж2В3К3И5Е7", z.Answer); }
        [Test]
        public void Answer_Ж2В4Д7Г9Е10_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Ж2В4Д7Г9Е10-1.jpg"), "RuLeA1"); Assert.AreEqual("Ж2В4Д7Г9Е10", z.Answer); }
        [Test]
        public void Answer_Ж2Г3З4В6И9_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Ж2Г3З4В6И9-1.jpg"), "RuLeA1"); Assert.AreEqual("Ж2Г3З4В6И9", z.Answer); }
        [Test]
        public void Answer_З1А2Г3Ж5А8_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\З1А2Г3Ж5А8-1.jpg"), "RuLeA1"); Assert.AreEqual("З1А2Г3Ж5А8", z.Answer); }
        [Test]
        public void Answer_З1Г4Д5В6З7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\З1Г4Д5В6З7-1.jpg"), "RuLeA1"); Assert.AreEqual("З1Г4Д5В6З7", z.Answer); }
        [Test]
        public void Answer_И1А2З3Б5Е6_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\И1А2З3Б5Е6-1.jpg"), "RuLeA1"); Assert.AreEqual("И1А2З3Б5Е6", z.Answer); }
        [Test]
        public void Answer_К1А2Е2Ж5В7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\К1А2Е2Ж5В7-1.jpg"), "RuLeA1"); Assert.AreEqual("К1А2Е2Ж5В7", z.Answer); }
        [Test]
        public void Answer_К1Б2К2И3В4_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\К1Б2К2И3В4-1.jpg"), "RuLeA1"); Assert.AreEqual("К1Б2К2И3В4", z.Answer); }
        [Test]
        public void Answer_Л1И3Б4Г6Е7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Л1И3Б4Г6Е7-1.jpg"), "RuLeA1"); Assert.AreEqual("Л1И3Б4Г6Е7", z.Answer); }
        [Test]
        public void Answer_М3Е4А5М5Д9_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\М3Е4А5М5Д9-1.jpg"), "RuLeA1"); Assert.AreEqual("М3Е4А5М5Д9", z.Answer); }
        [Test]
        public void Answer_М3Е4Б7З7К8_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\М3Е4Б7З7К8-1.jpg"), "RuLeA1"); Assert.AreEqual("М3Е4Б7З7К8", z.Answer); }
        [Test]
        public void Answer_A1A3A7C1C2_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1A3A7C1C2-1.jpg"), "EnUpA1"); Assert.AreEqual("A1A3A7C1C2", z.Answer); }
        [Test]
        public void Answer_A1A4E2F2F4_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1A4E2F2F4-1.jpg"), "EnUpA1"); Assert.AreEqual("A1A4E2F2F4", z.Answer); }
        [Test]
        public void Answer_A1B2B5D2D5_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1B2B5D2D5-1.jpg"), "EnUpA1"); Assert.AreEqual("A1B2B5D2D5", z.Answer); }
        [Test]
        public void Answer_A1B3B6D5E2_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1B3B6D5E2-1.jpg"), "EnUpA1"); Assert.AreEqual("A1B3B6D5E2", z.Answer); }
        [Test]
        public void Answer_A1D3E4G3G5_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1D3E4G3G5-1.jpg"), "EnUpA1"); Assert.AreEqual("A1D3E4G3G5", z.Answer); }
        [Test]
        public void Answer_A2B1B3E3G1_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A2B1B3E3G1-1.jpg"), "EnUpA1"); Assert.AreEqual("A2B1B3E3G1", z.Answer); }
        [Test]
        public void Answer_A2B5C5D5D7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A2B5C5D5D7-1.jpg"), "EnUpA1"); Assert.AreEqual("A2B5C5D5D7", z.Answer); }
        [Test]
        public void Answer_A2B6C3D6E2_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A2B6C3D6E2-1.jpg"), "EnUpA1"); Assert.AreEqual("A2B6C3D6E2", z.Answer); }
        [Test]
        public void Answer_A3A4C3D4F4_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A3A4C3D4F4-1.jpg"), "EnUpA1"); Assert.AreEqual("A3A4C3D4F4", z.Answer); }
        [Test]
        public void Answer_A3B3B4C7D3_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A3B3B4C7D3-1.jpg"), "EnUpA1"); Assert.AreEqual("A3B3B4C7D3", z.Answer); }
        [Test]
        public void Answer_A3B8D3E1E7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A3B8D3E1E7-1.jpg"), "EnUpA1"); Assert.AreEqual("A3B8D3E1E7", z.Answer); }
        [Test]
        public void Answer_A4B1B5C3C6_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B1B5C3C6-1.jpg"), "EnUpA1"); Assert.AreEqual("A4B1B5C3C6", z.Answer); }
        [Test]
        public void Answer_A4B1C1E2F2_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B1C1E2F2-1.jpg"), "EnUpA1"); Assert.AreEqual("A4B1C1E2F2", z.Answer); }
        [Test]
        public void Answer_A4B2C1D2D5_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B2C1D2D5-1.jpg"), "EnUpA1"); Assert.AreEqual("A4B2C1D2D5", z.Answer); }
        [Test]
        public void Answer_A4B5C7D1E7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B5C7D1E7-1.jpg"), "EnUpA1"); Assert.AreEqual("A4B5C7D1E7", z.Answer); }
        [Test]
        public void Answer_A4B6D4D6D7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B6D4D6D7-1.jpg"), "EnUpA1"); Assert.AreEqual("A4B6D4D6D7", z.Answer); }
        [Test]
        public void Answer_A5B2B4B7E6_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A5B2B4B7E6-1.jpg"), "EnUpA1"); Assert.AreEqual("A5B2B4B7E6", z.Answer); }
        [Test]
        public void Answer_A5B2C2D2D5_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A5B2C2D2D5-1.jpg"), "EnUpA1"); Assert.AreEqual("A5B2C2D2D5", z.Answer); }
        [Test]
        public void Answer_A5C5C6D2E1_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A5C5C6D2E1-1.jpg"), "EnUpA1"); Assert.AreEqual("A5C5C6D2E1", z.Answer); }
        [Test]
        public void Answer_A7B1B7D1E5_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A7B1B7D1E5-1.jpg"), "EnUpA1"); Assert.AreEqual("A7B1B7D1E5", z.Answer); }
        [Test]
        public void Answer_A7B1D1D5D7_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A7B1D1D5D7-1.jpg"), "EnUpA1"); Assert.AreEqual("A7B1D1D5D7", z.Answer); }
        [Test]
        public void Answer_A7B6C1C2D6_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A7B6C1C2D6-1.jpg"), "EnUpA1"); Assert.AreEqual("A7B6C1C2D6", z.Answer); }
        [Test]
        public void Answer_B1B4B6C3E5_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B1B4B6C3E5-1.jpg"), "EnUpA1"); Assert.AreEqual("B1B4B6C3E5", z.Answer); }
        [Test]
        public void Answer_B1B6D3E1E6_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B1B6D3E1E6-1.jpg"), "EnUpA1"); Assert.AreEqual("B1B6D3E1E6", z.Answer); }
        [Test]
        public void Answer_B2B5D6E2E3_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B2B5D6E2E3-1.jpg"), "EnUpA1"); Assert.AreEqual("B2B5D6E2E3", z.Answer); }
        [Test]
        public void Answer_B2C4D2D4E3_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B2C4D2D4E3-1.jpg"), "EnUpA1"); Assert.AreEqual("B2C4D2D4E3", z.Answer); }
        [Test]
        public void Answer_B3B4C3C4E1_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B3B4C3C4E1-1.jpg"), "EnUpA1"); Assert.AreEqual("B3B4C3C4E1", z.Answer); }
        [Test]
        public void Answer_B4D5D6E2F4_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B4D5D6E2F4-1.jpg"), "EnUpA1"); Assert.AreEqual("B4D5D6E2F4", z.Answer); }
        [Test]
        public void Answer_B6C1C4E4F1_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B6C1C4E4F1-1.jpg"), "EnUpA1"); Assert.AreEqual("B6C1C4E4F1", z.Answer); }
        [Test]
        public void Answer_B6C3C4D2E5_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B6C3C4D2E5-1.jpg"), "EnUpA1"); Assert.AreEqual("B6C3C4D2E5", z.Answer); }
        [Test]
        public void Answer_1A3H5A5I9E_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1A3H5A5I9E-1.jpg"), "EnLe1A"); Assert.AreEqual("1A3H5A5I9E", z.Answer); }
        [Test]
        public void Answer_1B4H7A7D7H_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1B4H7A7D7H-1.jpg"), "EnLe1A"); Assert.AreEqual("1B4H7A7D7H", z.Answer); }
        [Test]
        public void Answer_1C2J3D5J7G_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1C2J3D5J7G-1.jpg"), "EnLe1A"); Assert.AreEqual("1C2J3D5J7G", z.Answer); }
        [Test]
        public void Answer_1C3F7I8L9B_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1C3F7I8L9B-1.jpg"), "EnLe1A"); Assert.AreEqual("1C3F7I8L9B", z.Answer); }
        [Test]
        public void Answer_1D3G4E4J5L_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1D3G4E4J5L-1.jpg"), "EnLe1A"); Assert.AreEqual("1D3G4E4J5L", z.Answer); }
        [Test]
        public void Answer_1F2C3J6I7I_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1F2C3J6I7I-1.jpg"), "EnLe1A"); Assert.AreEqual("1F2C3J6I7I", z.Answer); }
        [Test]
        public void Answer_1G3B3J6M7G_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1G3B3J6M7G-1.jpg"), "EnLe1A"); Assert.AreEqual("1G3B3J6M7G", z.Answer); }
        [Test]
        public void Answer_1G3E5B5F7B_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1G3E5B5F7B-1.jpg"), "EnLe1A"); Assert.AreEqual("1G3E5B5F7B", z.Answer); }
        [Test]
        public void Answer_1I2F5I5K5L_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1I2F5I5K5L-1.jpg"), "EnLe1A"); Assert.AreEqual("1I2F5I5K5L", z.Answer); }
        [Test]
        public void Answer_1I4F4K7L9H_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1I4F4K7L9H-1.jpg"), "EnLe1A"); Assert.AreEqual("1I4F4K7L9H", z.Answer); }
        [Test]
        public void Answer_1K3G3L5A7G_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1K3G3L5A7G-1.jpg"), "EnLe1A"); Assert.AreEqual("1K3G3L5A7G", z.Answer); }
        [Test]
        public void Answer_1L3G6G6K9E_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1L3G6G6K9E-1.jpg"), "EnLe1A"); Assert.AreEqual("1L3G6G6K9E", z.Answer); }
        [Test]
        public void Answer_1M4H4N7D8C_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1M4H4N7D8C-1.jpg"), "EnLe1A"); Assert.AreEqual("1M4H4N7D8C", z.Answer); }
        [Test]
        public void Answer_2B2G3K5D8F_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2B2G3K5D8F-1.jpg"), "EnLe1A"); Assert.AreEqual("2B2G3K5D8F", z.Answer); }
        [Test]
        public void Answer_2B2G5H5K6A_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2B2G5H5K6A-1.jpg"), "EnLe1A"); Assert.AreEqual("2B2G5H5K6A", z.Answer); }
        [Test]
        public void Answer_2B2H2N7E8N_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2B2H2N7E8N-1.jpg"), "EnLe1A"); Assert.AreEqual("2B2H2N7E8N", z.Answer); }
        [Test]
        public void Answer_2I3L7F7H8B_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2I3L7F7H8B-1.jpg"), "EnLe1A"); Assert.AreEqual("2I3L7F7H8B", z.Answer); }
        [Test]
        public void Answer_2J3G4F5C5J_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2J3G4F5C5J-1.jpg"), "EnLe1A"); Assert.AreEqual("2J3G4F5C5J", z.Answer); }
        [Test]
        public void Answer_2L3K7L8G9A_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2L3K7L8G9A-1.jpg"), "EnLe1A"); Assert.AreEqual("2L3K7L8G9A", z.Answer); }
        [Test]
        public void Answer_2L5M6L7B8J_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2L5M6L7B8J-1.jpg"), "EnLe1A"); Assert.AreEqual("2L5M6L7B8J", z.Answer); }
        [Test]
        public void Answer_3A3D4B5K7L_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3A3D4B5K7L-1.jpg"), "EnLe1A"); Assert.AreEqual("3A3D4B5K7L", z.Answer); }
        [Test]
        public void Answer_3A5A6H6P9D_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3A5A6H6P9D-1.jpg"), "EnLe1A"); Assert.AreEqual("3A5A6H6P9D", z.Answer); }
        [Test]
        public void Answer_3B6N8A8L9C_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3B6N8A8L9C-1.jpg"), "EnLe1A"); Assert.AreEqual("3B6N8A8L9C", z.Answer); }
        [Test]
        public void Answer_3C3F3I4B6C_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3C3F3I4B6C-1.jpg"), "EnLe1A"); Assert.AreEqual("3C3F3I4B6C", z.Answer); }
        [Test]
        public void Answer_3C4G4L6F6H_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3C4G4L6F6H-1.jpg"), "EnLe1A"); Assert.AreEqual("3C4G4L6F6H", z.Answer); }
        [Test]
        public void Answer_3D4K6G7B7E_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3D4K6G7B7E-1.jpg"), "EnLe1A"); Assert.AreEqual("3D4K6G7B7E", z.Answer); }
        [Test]
        public void Answer_3G4E5E6E10E_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3G4E5E6E10E-1.jpg"), "EnLe1A"); Assert.AreEqual("3G4E5E6E10E", z.Answer); }
        [Test]
        public void Answer_3G6C6F9D9K_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3G6C6F9D9K-1.jpg"), "EnLe1A"); Assert.AreEqual("3G6C6F9D9K", z.Answer); }
        [Test]
        public void Answer_3H7B7G8H8J_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3H7B7G8H8J-1.jpg"), "EnLe1A"); Assert.AreEqual("3H7B7G8H8J", z.Answer); }
        [Test]
        public void Answer_3J4H6B6H7D_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3J4H6B6H7D-1.jpg"), "EnLe1A"); Assert.AreEqual("3J4H6B6H7D", z.Answer); }
        [Test]
        public void Answer_3L6B6E6H6M_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3L6B6E6H6M-1.jpg"), "EnLe1A"); Assert.AreEqual("3L6B6E6H6M", z.Answer); }
        [Test]
        public void Answer_4A5E8F8H9I_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4A5E8F8H9I-1.jpg"), "EnLe1A"); Assert.AreEqual("4A5E8F8H9I", z.Answer); }
        [Test]
        public void Answer_4E4L5H6E8K_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4E4L5H6E8K-1.jpg"), "EnLe1A"); Assert.AreEqual("4E4L5H6E8K", z.Answer); }
        [Test]
        public void Answer_4G7L9G9L10C_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4G7L9G9L10C-1.jpg"), "EnLe1A"); Assert.AreEqual("4G7L9G9L10C", z.Answer); }
        [Test]
        public void Answer_4H5J5M6B8G_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4H5J5M6B8G-1.jpg"), "EnLe1A"); Assert.AreEqual("4H5J5M6B8G", z.Answer); }
        [Test]
        public void Answer_4K6E6J6K7F_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4K6E6J6K7F-1.jpg"), "EnLe1A"); Assert.AreEqual("4K6E6J6K7F", z.Answer); }
        [Test]
        public void Answer_4M7I10E10G10J_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4M7I10E10G10J-1.jpg"), "EnLe1A"); Assert.AreEqual("4M7I10E10G10J", z.Answer); }
        [Test]
        public void Answer_5E6C7N7O10M_1() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\5E6C7N7O10M-1.jpg"), "EnLe1A"); Assert.AreEqual("5E6C7N7O10M", z.Answer); }

    }
   */

    [TestFixture]
    public class UnitTestAllAnswers_2
    {
        [Test]
        public void Answer_А1Ж4К6Ж7К8_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\А1Ж4К6Ж7К8-2.jpg"), "RuLeA1"); Assert.AreEqual("А1Ж4К6Ж7К8", z.Answer); }
        [Test]
        public void Answer_А1И3И4З8И8_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\А1И3И4З8И8-2.jpg"), "RuLeA1"); Assert.AreEqual("А1И3И4З8И8", z.Answer); }
        [Test]
        public void Answer_А2К2З4Д6Л6_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\А2К2З4Д6Л6-2.jpg"), "RuLeA1"); Assert.AreEqual("А2К2З4Д6Л6", z.Answer); }
        [Test]
        public void Answer_Б1Д3А4Л5З6_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Б1Д3А4Л5З6-2.jpg"), "RuLeA1"); Assert.AreEqual("Б1Д3А4Л5З6", z.Answer); }
        [Test]
        public void Answer_Б1Л7В8И8В9_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Б1Л7В8И8В9-2.jpg"), "RuLeA1"); Assert.AreEqual("Б1Л7В8И8В9", z.Answer); }
        [Test]
        public void Answer_Б2Г2Ж2Е5И10_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Б2Г2Ж2Е5И10-2.jpg"), "RuLeA1"); Assert.AreEqual("Б2Г2Ж2Е5И10", z.Answer); }
        [Test]
        public void Answer_Б3Д4А6И6Ж8_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Б3Д4А6И6Ж8-2.jpg"), "RuLeA1"); Assert.AreEqual("Б3Д4А6И6Ж8", z.Answer); }
        [Test]
        public void Answer_Б3Ж3Е6З6В7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Б3Ж3Е6З6В7-2.jpg"), "RuLeA1"); Assert.AreEqual("Б3Ж3Е6З6В7", z.Answer); }
        [Test]
        public void Answer_В1Е1Ж6Б7Е7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\В1Е1Ж6Б7Е7-2.jpg"), "RuLeA1"); Assert.AreEqual("В1Е1Ж6Б7Е7", z.Answer); }
        [Test]
        public void Answer_В1Л2Г3К5М9_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\В1Л2Г3К5М9-2.jpg"), "RuLeA1"); Assert.AreEqual("В1Л2Г3К5М9", z.Answer); }
        [Test]
        public void Answer_В2З5В6Е7К7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\В2З5В6Е7К7-2.jpg"), "RuLeA1"); Assert.AreEqual("В2З5В6Е7К7", z.Answer); }
        [Test]
        public void Answer_Г1Е4Е5К5Г7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Г1Е4Е5К5Г7-2.jpg"), "RuLeA1"); Assert.AreEqual("Г1Е4Е5К5Г7", z.Answer); }
        [Test]
        public void Answer_Г1И1К4Г8К8_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Г1И1К4Г8К8-2.jpg"), "RuLeA1"); Assert.AreEqual("Г1И1К4Г8К8", z.Answer); }
        [Test]
        public void Answer_Г3З3К4Е7И8_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Г3З3К4Е7И8-2.jpg"), "RuLeA1"); Assert.AreEqual("Г3З3К4Е7И8", z.Answer); }
        [Test]
        public void Answer_Г3Р4Ж6К6Б7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Г3Р4Ж6К6Б7-2.jpg"), "RuLeA1"); Assert.AreEqual("Г3Р4Ж6К6Б7", z.Answer); }
        [Test]
        public void Answer_Г4И4Б6Г6Д8_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Г4И4Б6Г6Д8-2.jpg"), "RuLeA1"); Assert.AreEqual("Г4И4Б6Г6Д8", z.Answer); }
        [Test]
        public void Answer_Д1К2В4Г5Ж8_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Д1К2В4Г5Ж8-2.jpg"), "RuLeA1"); Assert.AreEqual("Д1К2В4Г5Ж8", z.Answer); }
        [Test]
        public void Answer_Д2В3К5Д6Б7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Д2В3К5Д6Б7-2.jpg"), "RuLeA1"); Assert.AreEqual("Д2В3К5Д6Б7", z.Answer); }
        [Test]
        public void Answer_Д4К4Л6А8Б9_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Д4К4Л6А8Б9-2.jpg"), "RuLeA1"); Assert.AreEqual("Д4К4Л6А8Б9", z.Answer); }
        [Test]
        public void Answer_Е1Д4В5И8Г9_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Е1Д4В5И8Г9-2.jpg"), "RuLeA1"); Assert.AreEqual("Е1Д4В5И8Г9", z.Answer); }
        [Test]
        public void Answer_Е2В4И4Б6Л8_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Е2В4И4Б6Л8-2.jpg"), "RuLeA1"); Assert.AreEqual("Е2В4И4Б6Л8", z.Answer); }
        [Test]
        public void Answer_Е2Д3В6И7Г10_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Е2Д3В6И7Г10-2.jpg"), "RuLeA1"); Assert.AreEqual("Е2Д3В6И7Г10", z.Answer); }
        [Test]
        public void Answer_Е2З3А8Е9З9_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Е2З3А8Е9З9-2.jpg"), "RuLeA1"); Assert.AreEqual("Е2З3А8Е9З9", z.Answer); }
        [Test]
        public void Answer_Е3М3И5Г7Д9_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Е3М3И5Г7Д9-2.jpg"), "RuLeA1"); Assert.AreEqual("Е3М3И5Г7Д9", z.Answer); }
        [Test]
        public void Answer_Ж1З3А8З8Д9_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Ж1З3А8З8Д9-2.jpg"), "RuLeA1"); Assert.AreEqual("Ж1З3А8З8Д9", z.Answer); }
        [Test]
        public void Answer_Ж2В3К3И5Е7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Ж2В3К3И5Е7-2.jpg"), "RuLeA1"); Assert.AreEqual("Ж2В3К3И5Е7", z.Answer); }
        [Test]
        public void Answer_Ж2В4Д7Г9Е10_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Ж2В4Д7Г9Е10-2.jpg"), "RuLeA1"); Assert.AreEqual("Ж2В4Д7Г9Е10", z.Answer); }
        [Test]
        public void Answer_Ж2Г3З4В6И9_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Ж2Г3З4В6И9-2.jpg"), "RuLeA1"); Assert.AreEqual("Ж2Г3З4В6И9", z.Answer); }
        [Test]
        public void Answer_З1А2Г3Ж5А8_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\З1А2Г3Ж5А8-2.jpg"), "RuLeA1"); Assert.AreEqual("З1А2Г3Ж5А8", z.Answer); }
        [Test]
        public void Answer_З1Г4Д5В6З7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\З1Г4Д5В6З7-2.jpg"), "RuLeA1"); Assert.AreEqual("З1Г4Д5В6З7", z.Answer); }
        [Test]
        public void Answer_И1А2З3Б5Е6_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\И1А2З3Б5Е6-2.jpg"), "RuLeA1"); Assert.AreEqual("И1А2З3Б5Е6", z.Answer); }
        [Test]
        public void Answer_К1А2Е2Ж5В7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\К1А2Е2Ж5В7-2.jpg"), "RuLeA1"); Assert.AreEqual("К1А2Е2Ж5В7", z.Answer); }
        [Test]
        public void Answer_К1Б2К2И3В4_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\К1Б2К2И3В4-2.jpg"), "RuLeA1"); Assert.AreEqual("К1Б2К2И3В4", z.Answer); }
        [Test]
        public void Answer_Л1И3Б4Г6Е7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\Л1И3Б4Г6Е7-2.jpg"), "RuLeA1"); Assert.AreEqual("Л1И3Б4Г6Е7", z.Answer); }
        [Test]
        public void Answer_М3Е4А5М5Д9_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\М3Е4А5М5Д9-2.jpg"), "RuLeA1"); Assert.AreEqual("М3Е4А5М5Д9", z.Answer); }
        [Test]
        public void Answer_М3Е4Б7З7К8_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\sar21623_RuLeA1\М3Е4Б7З7К8-2.jpg"), "RuLeA1"); Assert.AreEqual("М3Е4Б7З7К8", z.Answer); }
        [Test]
        public void Answer_A1A3A7C1C2_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1A3A7C1C2-2.jpg"), "EnUpA1"); Assert.AreEqual("A1A3A7C1C2", z.Answer); }
        [Test]
        public void Answer_A1A3A7C1C2_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1A3A7C1C2-3.jpg"), "EnUpA1"); Assert.AreEqual("A1A3A7C1C2", z.Answer); }
        [Test]
        public void Answer_A1A4E2F2F4_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1A4E2F2F4-2.jpg"), "EnUpA1"); Assert.AreEqual("A1A4E2F2F4", z.Answer); }
        [Test]
        public void Answer_A1A4E2F2F4_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1A4E2F2F4-3.jpg"), "EnUpA1"); Assert.AreEqual("A1A4E2F2F4", z.Answer); }
        [Test]
        public void Answer_A1B2B5D2D5_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1B2B5D2D5-2.jpg"), "EnUpA1"); Assert.AreEqual("A1B2B5D2D5", z.Answer); }
        [Test]
        public void Answer_A1B2B5D2D5_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1B2B5D2D5-3.jpg"), "EnUpA1"); Assert.AreEqual("A1B2B5D2D5", z.Answer); }
        [Test]
        public void Answer_A1B3B6D5E2_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1B3B6D5E2-2.jpg"), "EnUpA1"); Assert.AreEqual("A1B3B6D5E2", z.Answer); }
        [Test]
        public void Answer_A1B3B6D5E2_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1B3B6D5E2-3.jpg"), "EnUpA1"); Assert.AreEqual("A1B3B6D5E2", z.Answer); }
        [Test]
        public void Answer_A1D3E4G3G5_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1D3E4G3G5-2.jpg"), "EnUpA1"); Assert.AreEqual("A1D3E4G3G5", z.Answer); }
        [Test]
        public void Answer_A1D3E4G3G5_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A1D3E4G3G5-3.jpg"), "EnUpA1"); Assert.AreEqual("A1D3E4G3G5", z.Answer); }
        [Test]
        public void Answer_A2B1B3E3G1_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A2B1B3E3G1-2.jpg"), "EnUpA1"); Assert.AreEqual("A2B1B3E3G1", z.Answer); }
        [Test]
        public void Answer_A2B1B3E3G1_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A2B1B3E3G1-3.jpg"), "EnUpA1"); Assert.AreEqual("A2B1B3E3G1", z.Answer); }
        [Test]
        public void Answer_A2B5C5D5D7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A2B5C5D5D7-2.jpg"), "EnUpA1"); Assert.AreEqual("A2B5C5D5D7", z.Answer); }
        [Test]
        public void Answer_A2B5C5D5D7_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A2B5C5D5D7-3.jpg"), "EnUpA1"); Assert.AreEqual("A2B5C5D5D7", z.Answer); }
        [Test]
        public void Answer_A2B6C3D6E2_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A2B6C3D6E2-2.jpg"), "EnUpA1"); Assert.AreEqual("A2B6C3D6E2", z.Answer); }
        [Test]
        public void Answer_A2B6C3D6E2_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A2B6C3D6E2-3.jpg"), "EnUpA1"); Assert.AreEqual("A2B6C3D6E2", z.Answer); }
        [Test]
        public void Answer_A3A4C3D4F4_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A3A4C3D4F4-2.jpg"), "EnUpA1"); Assert.AreEqual("A3A4C3D4F4", z.Answer); }
        [Test]
        public void Answer_A3A4C3D4F4_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A3A4C3D4F4-3.jpg"), "EnUpA1"); Assert.AreEqual("A3A4C3D4F4", z.Answer); }
        [Test]
        public void Answer_A3B3B4C7D3_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A3B3B4C7D3-2.jpg"), "EnUpA1"); Assert.AreEqual("A3B3B4C7D3", z.Answer); }
        [Test]
        public void Answer_A3B3B4C7D3_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A3B3B4C7D3-3.jpg"), "EnUpA1"); Assert.AreEqual("A3B3B4C7D3", z.Answer); }
        [Test]
        public void Answer_A3B8D3E1E7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A3B8D3E1E7-2.jpg"), "EnUpA1"); Assert.AreEqual("A3B8D3E1E7", z.Answer); }
        [Test]
        public void Answer_A3B8D3E1E7_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A3B8D3E1E7-3.jpg"), "EnUpA1"); Assert.AreEqual("A3B8D3E1E7", z.Answer); }
        [Test]
        public void Answer_A4B1B5C3C6_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B1B5C3C6-2.jpg"), "EnUpA1"); Assert.AreEqual("A4B1B5C3C6", z.Answer); }
        [Test]
        public void Answer_A4B1B5C3C6_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B1B5C3C6-3.jpg"), "EnUpA1"); Assert.AreEqual("A4B1B5C3C6", z.Answer); }
        [Test]
        public void Answer_A4B1C1E2F2_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B1C1E2F2-2.jpg"), "EnUpA1"); Assert.AreEqual("A4B1C1E2F2", z.Answer); }
        [Test]
        public void Answer_A4B1C1E2F2_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B1C1E2F2-3.jpg"), "EnUpA1"); Assert.AreEqual("A4B1C1E2F2", z.Answer); }
        [Test]
        public void Answer_A4B2C1D2D5_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B2C1D2D5-2.jpg"), "EnUpA1"); Assert.AreEqual("A4B2C1D2D5", z.Answer); }
        [Test]
        public void Answer_A4B2C1D2D5_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B2C1D2D5-3.jpg"), "EnUpA1"); Assert.AreEqual("A4B2C1D2D5", z.Answer); }
        [Test]
        public void Answer_A4B5C7D1E7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B5C7D1E7-2.jpg"), "EnUpA1"); Assert.AreEqual("A4B5C7D1E7", z.Answer); }
        [Test]
        public void Answer_A4B5C7D1E7_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B5C7D1E7-3.jpg"), "EnUpA1"); Assert.AreEqual("A4B5C7D1E7", z.Answer); }
        [Test]
        public void Answer_A4B6D4D6D7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B6D4D6D7-2.jpg"), "EnUpA1"); Assert.AreEqual("A4B6D4D6D7", z.Answer); }
        [Test]
        public void Answer_A4B6D4D6D7_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A4B6D4D6D7-3.jpg"), "EnUpA1"); Assert.AreEqual("A4B6D4D6D7", z.Answer); }
        [Test]
        public void Answer_A5B2B4B7E6_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A5B2B4B7E6-2.jpg"), "EnUpA1"); Assert.AreEqual("A5B2B4B7E6", z.Answer); }
        [Test]
        public void Answer_A5B2B4B7E6_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A5B2B4B7E6-3.jpg"), "EnUpA1"); Assert.AreEqual("A5B2B4B7E6", z.Answer); }
        [Test]
        public void Answer_A5B2C2D2D5_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A5B2C2D2D5-2.jpg"), "EnUpA1"); Assert.AreEqual("A5B2C2D2D5", z.Answer); }
        [Test]
        public void Answer_A5B2C2D2D5_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A5B2C2D2D5-3.jpg"), "EnUpA1"); Assert.AreEqual("A5B2C2D2D5", z.Answer); }
        [Test]
        public void Answer_A5C5C6D2E1_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A5C5C6D2E1-2.jpg"), "EnUpA1"); Assert.AreEqual("A5C5C6D2E1", z.Answer); }
        [Test]
        public void Answer_A5C5C6D2E1_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A5C5C6D2E1-3.jpg"), "EnUpA1"); Assert.AreEqual("A5C5C6D2E1", z.Answer); }
        [Test]
        public void Answer_A7B1B7D1E5_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A7B1B7D1E5-2.jpg"), "EnUpA1"); Assert.AreEqual("A7B1B7D1E5", z.Answer); }
        [Test]
        public void Answer_A7B1B7D1E5_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A7B1B7D1E5-3.jpg"), "EnUpA1"); Assert.AreEqual("A7B1B7D1E5", z.Answer); }
        [Test]
        public void Answer_A7B1D1D5D7_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A7B1D1D5D7-2.jpg"), "EnUpA1"); Assert.AreEqual("A7B1D1D5D7", z.Answer); }
        [Test]
        public void Answer_A7B1D1D5D7_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A7B1D1D5D7-3.jpg"), "EnUpA1"); Assert.AreEqual("A7B1D1D5D7", z.Answer); }
        [Test]
        public void Answer_A7B6C1C2D6_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A7B6C1C2D6-2.jpg"), "EnUpA1"); Assert.AreEqual("A7B6C1C2D6", z.Answer); }
        [Test]
        public void Answer_A7B6C1C2D6_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\A7B6C1C2D6-3.jpg"), "EnUpA1"); Assert.AreEqual("A7B6C1C2D6", z.Answer); }
        [Test]
        public void Answer_B1B4B6C3E5_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B1B4B6C3E5-2.jpg"), "EnUpA1"); Assert.AreEqual("B1B4B6C3E5", z.Answer); }
        [Test]
        public void Answer_B1B4B6C3E5_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B1B4B6C3E5-3.jpg"), "EnUpA1"); Assert.AreEqual("B1B4B6C3E5", z.Answer); }
        [Test]
        public void Answer_B1B6D3E1E6_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B1B6D3E1E6-2.jpg"), "EnUpA1"); Assert.AreEqual("B1B6D3E1E6", z.Answer); }
        [Test]
        public void Answer_B1B6D3E1E6_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B1B6D3E1E6-3.jpg"), "EnUpA1"); Assert.AreEqual("B1B6D3E1E6", z.Answer); }
        [Test]
        public void Answer_B2B5D6E2E3_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B2B5D6E2E3-2.jpg"), "EnUpA1"); Assert.AreEqual("B2B5D6E2E3", z.Answer); }
        [Test]
        public void Answer_B2B5D6E2E3_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B2B5D6E2E3-3.jpg"), "EnUpA1"); Assert.AreEqual("B2B5D6E2E3", z.Answer); }
        [Test]
        public void Answer_B2C4D2D4E3_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B2C4D2D4E3-2.jpg"), "EnUpA1"); Assert.AreEqual("B2C4D2D4E3", z.Answer); }
        [Test]
        public void Answer_B2C4D2D4E3_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B2C4D2D4E3-3.jpg"), "EnUpA1"); Assert.AreEqual("B2C4D2D4E3", z.Answer); }
        [Test]
        public void Answer_B3B4C3C4E1_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B3B4C3C4E1-2.jpg"), "EnUpA1"); Assert.AreEqual("B3B4C3C4E1", z.Answer); }
        [Test]
        public void Answer_B3B4C3C4E1_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B3B4C3C4E1-3.jpg"), "EnUpA1"); Assert.AreEqual("B3B4C3C4E1", z.Answer); }
        [Test]
        public void Answer_B4D5D6E2F4_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B4D5D6E2F4-2.jpg"), "EnUpA1"); Assert.AreEqual("B4D5D6E2F4", z.Answer); }
        [Test]
        public void Answer_B4D5D6E2F4_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B4D5D6E2F4-3.jpg"), "EnUpA1"); Assert.AreEqual("B4D5D6E2F4", z.Answer); }
        [Test]
        public void Answer_B6C1C4E4F1_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B6C1C4E4F1-2.jpg"), "EnUpA1"); Assert.AreEqual("B6C1C4E4F1", z.Answer); }
        [Test]
        public void Answer_B6C1C4E4F1_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B6C1C4E4F1-3.jpg"), "EnUpA1"); Assert.AreEqual("B6C1C4E4F1", z.Answer); }
        [Test]
        public void Answer_B6C3C4D2E5_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B6C3C4D2E5-2.jpg"), "EnUpA1"); Assert.AreEqual("B6C3C4D2E5", z.Answer); }
        [Test]
        public void Answer_B6C3C4D2E5_3() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\kmv57389_EnUpA1\B6C3C4D2E5-3.jpg"), "EnUpA1"); Assert.AreEqual("B6C3C4D2E5", z.Answer); }
        [Test]
        public void Answer_1A3H5A5I9E_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1A3H5A5I9E-2.jpg"), "EnLe1A"); Assert.AreEqual("1A3H5A5I9E", z.Answer); }
        [Test]
        public void Answer_1B4H7A7D7H_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1B4H7A7D7H-2.jpg"), "EnLe1A"); Assert.AreEqual("1B4H7A7D7H", z.Answer); }
        [Test]
        public void Answer_1C2J3D5J7G_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1C2J3D5J7G-2.jpg"), "EnLe1A"); Assert.AreEqual("1C2J3D5J7G", z.Answer); }
        [Test]
        public void Answer_1C3F7I8L9B_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1C3F7I8L9B-2.jpg"), "EnLe1A"); Assert.AreEqual("1C3F7I8L9B", z.Answer); }
        [Test]
        public void Answer_1D3G4E4J5L_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1D3G4E4J5L-2.jpg"), "EnLe1A"); Assert.AreEqual("1D3G4E4J5L", z.Answer); }
        [Test]
        public void Answer_1F2C3J6I7I_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1F2C3J6I7I-2.jpg"), "EnLe1A"); Assert.AreEqual("1F2C3J6I7I", z.Answer); }
        [Test]
        public void Answer_1G3B3J6M7G_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1G3B3J6M7G-2.jpg"), "EnLe1A"); Assert.AreEqual("1G3B3J6M7G", z.Answer); }
        [Test]
        public void Answer_1G3E5B5F7B_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1G3E5B5F7B-2.jpg"), "EnLe1A"); Assert.AreEqual("1G3E5B5F7B", z.Answer); }
        [Test]
        public void Answer_1I2F5I5K5L_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1I2F5I5K5L-2.jpg"), "EnLe1A"); Assert.AreEqual("1I2F5I5K5L", z.Answer); }
        [Test]
        public void Answer_1I4F4K7L9H_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1I4F4K7L9H-2.jpg"), "EnLe1A"); Assert.AreEqual("1I4F4K7L9H", z.Answer); }
        [Test]
        public void Answer_1K3G3L5A7G_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1K3G3L5A7G-2.jpg"), "EnLe1A"); Assert.AreEqual("1K3G3L5A7G", z.Answer); }
        [Test]
        public void Answer_1L3G6G6K9E_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1L3G6G6K9E-2.jpg"), "EnLe1A"); Assert.AreEqual("1L3G6G6K9E", z.Answer); }
        [Test]
        public void Answer_1M4H4N7D8C_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\1M4H4N7D8C-2.jpg"), "EnLe1A"); Assert.AreEqual("1M4H4N7D8C", z.Answer); }
        [Test]
        public void Answer_2B2G3K5D8F_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2B2G3K5D8F-2.jpg"), "EnLe1A"); Assert.AreEqual("2B2G3K5D8F", z.Answer); }
        [Test]
        public void Answer_2B2G5H5K6A_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2B2G5H5K6A-2.jpg"), "EnLe1A"); Assert.AreEqual("2B2G5H5K6A", z.Answer); }
        [Test]
        public void Answer_2B2H2N7E8N_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2B2H2N7E8N-2.jpg"), "EnLe1A"); Assert.AreEqual("2B2H2N7E8N", z.Answer); }
        [Test]
        public void Answer_2I3L7F7H8B_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2I3L7F7H8B-2.jpg"), "EnLe1A"); Assert.AreEqual("2I3L7F7H8B", z.Answer); }
        [Test]
        public void Answer_2J3G4F5C5J_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2J3G4F5C5J-2.jpg"), "EnLe1A"); Assert.AreEqual("2J3G4F5C5J", z.Answer); }
        [Test]
        public void Answer_2L3K7L8G9A_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2L3K7L8G9A-2.jpg"), "EnLe1A"); Assert.AreEqual("2L3K7L8G9A", z.Answer); }
        [Test]
        public void Answer_2L5M6L7B8J_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\2L5M6L7B8J-2.jpg"), "EnLe1A"); Assert.AreEqual("2L5M6L7B8J", z.Answer); }
        [Test]
        public void Answer_3A3D4B5K7L_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3A3D4B5K7L-2.jpg"), "EnLe1A"); Assert.AreEqual("3A3D4B5K7L", z.Answer); }
        [Test]
        public void Answer_3A5A6H6P9D_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3A5A6H6P9D-2.jpg"), "EnLe1A"); Assert.AreEqual("3A5A6H6P9D", z.Answer); }
        [Test]
        public void Answer_3B6N8A8L9C_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3B6N8A8L9C-2.jpg"), "EnLe1A"); Assert.AreEqual("3B6N8A8L9C", z.Answer); }
        [Test]
        public void Answer_3C3F3I4B6C_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3C3F3I4B6C-2.jpg"), "EnLe1A"); Assert.AreEqual("3C3F3I4B6C", z.Answer); }
        [Test]
        public void Answer_3C4G4L6F6H_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3C4G4L6F6H-2.jpg"), "EnLe1A"); Assert.AreEqual("3C4G4L6F6H", z.Answer); }
        [Test]
        public void Answer_3D4K6G7B7E_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3D4K6G7B7E-2.jpg"), "EnLe1A"); Assert.AreEqual("3D4K6G7B7E", z.Answer); }
        [Test]
        public void Answer_3G4E5E6E10E_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3G4E5E6E10E-2.jpg"), "EnLe1A"); Assert.AreEqual("3G4E5E6E10E", z.Answer); }
        [Test]
        public void Answer_3G6C6F9D9K_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3G6C6F9D9K-2.jpg"), "EnLe1A"); Assert.AreEqual("3G6C6F9D9K", z.Answer); }
        [Test]
        public void Answer_3H7B7G8H8J_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3H7B7G8H8J-2.jpg"), "EnLe1A"); Assert.AreEqual("3H7B7G8H8J", z.Answer); }
        [Test]
        public void Answer_3J4H6B6H7D_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3J4H6B6H7D-2.jpg"), "EnLe1A"); Assert.AreEqual("3J4H6B6H7D", z.Answer); }
        [Test]
        public void Answer_3L6B6E6H6M_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\3L6B6E6H6M-2.jpg"), "EnLe1A"); Assert.AreEqual("3L6B6E6H6M", z.Answer); }
        [Test]
        public void Answer_4A5E8F8H9I_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4A5E8F8H9I-2.jpg"), "EnLe1A"); Assert.AreEqual("4A5E8F8H9I", z.Answer); }
        [Test]
        public void Answer_4E4L5H6E8K_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4E4L5H6E8K-2.jpg"), "EnLe1A"); Assert.AreEqual("4E4L5H6E8K", z.Answer); }
        [Test]
        public void Answer_4G7L9G9L10C_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4G7L9G9L10C-2.jpg"), "EnLe1A"); Assert.AreEqual("4G7L9G9L10C", z.Answer); }
        [Test]
        public void Answer_4H5J5M6B8G_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4H5J5M6B8G-2.jpg"), "EnLe1A"); Assert.AreEqual("4H5J5M6B8G", z.Answer); }
        [Test]
        public void Answer_4K6E6J6K7F_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4K6E6J6K7F-2.jpg"), "EnLe1A"); Assert.AreEqual("4K6E6J6K7F", z.Answer); }
        [Test]
        public void Answer_4M7I10E10G10J_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\4M7I10E10G10J-2.jpg"), "EnLe1A"); Assert.AreEqual("4M7I10E10G10J", z.Answer); }
        [Test]
        public void Answer_5E6C7N7O10M_2() { FindFiveDiff z = new FindFiveDiff(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\ne53350_EnLe1A\5E6C7N7O10M-2.jpg"), "EnLe1A"); Assert.AreEqual("5E6C7N7O10M", z.Answer); }

    }
    


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
