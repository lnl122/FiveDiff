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
            FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\9\0.jpg"));
            Assert.AreEqual(0, z.GetShHor());
        }
    }
    */
    /*
    // границы
    [TestFixture]
    public class UnitTestAllBounds_2
    {
        [Test]
        public void Bounds_1A3H5A5I9E_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1A3H5A5I9E-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(9, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_1B4H7A7D7H_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1B4H7A7D7H-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_1C2J3D5J7G_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1C2J3D5J7G-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_1C3F7I8L9B_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1C3F7I8L9B-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(10, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_1D3G4E4J5L_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1D3G4E4J5L-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_1F2C3J6I7I_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1F2C3J6I7I-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(15, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_1G3B3J6M7G_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1G3B3J6M7G-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_1G3E5B5F7B_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1G3E5B5F7B-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(9, z.columns); Assert.AreEqual(11, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_1I2F5I5K5L_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1I2F5I5K5L-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_1I4F4K7L9H_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1I4F4K7L9H-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(10, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_1K3G3L5A7G_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1K3G3L5A7G-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_1L3G6G6K9E_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1L3G6G6K9E-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_1M4H4N7D8C_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1M4H4N7D8C-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(14, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_2B2G3K5D8F_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\2B2G3K5D8F-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(11, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_2B2G5H5K6A_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\2B2G5H5K6A-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(11, z.columns); Assert.AreEqual(7, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_2B2H2N7E8N_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\2B2H2N7E8N-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(16, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_2I3L7F7H8B_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\2I3L7F7H8B-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(14, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_2J3G4F5C5J_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\2J3G4F5C5J-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(14, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_2L3K7L8G9A_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\2L3K7L8G9A-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(16, z.columns); Assert.AreEqual(10, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_2L5M6L7B8J_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\2L5M6L7B8J-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_3A3D4B5K7L_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\3A3D4B5K7L-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_3A5A6H6P9D_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\3A5A6H6P9D-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(16, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_3B6N8A8L9C_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\3B6N8A8L9C-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(16, z.columns); Assert.AreEqual(10, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_3C3F3I4B6C_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\3C3F3I4B6C-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(9, z.columns); Assert.AreEqual(7, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_3C4G4L6F6H_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\3C4G4L6F6H-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(12, z.columns); Assert.AreEqual(7, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_3D4K6G7B7E_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\3D4K6G7B7E-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(12, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_3G4E5E6E10E_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\3G4E5E6E10E-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(10, z.columns); Assert.AreEqual(12, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_3G6C6F9D9K_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\3G6C6F9D9K-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(11, z.columns); Assert.AreEqual(11, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_3H7B7G8H8J_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\3H7B7G8H8J-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(15, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_3J4H6B6H7D_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\3J4H6B6H7D-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_3L6B6E6H6M_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\3L6B6E6H6M-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(10, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_4A5E8F8H9I_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\4A5E8F8H9I-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(13, z.columns); Assert.AreEqual(16, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_4E4L5H6E8K_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\4E4L5H6E8K-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_4G7L9G9L10C_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\4G7L9G9L10C-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(16, z.columns); Assert.AreEqual(11, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_4H5J5M6B8G_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\4H5J5M6B8G-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(14, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_4K6E6J6K7F_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\4K6E6J6K7F-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_4M7I10E10G10J_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\4M7I10E10G10J-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(16, z.columns); Assert.AreEqual(11, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_5E6C7N7O10M_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\5E6C7N7O10M-2_g1.jpg"), "EnLe1A"); Assert.AreEqual(16, z.columns); Assert.AreEqual(11, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A10B5F10G2I13() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A10B5F10G2I13.jpg"), "EnUpA1"); Assert.AreEqual(13, z.columns); Assert.AreEqual(10, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A12B6D7G8H3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A12B6D7G8H3.jpg"), "EnUpA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A1A3A7C1C2_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A1A3A7C1C2-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(4, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A1A3A7C1C2_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A1A3A7C1C2-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(4, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A1A4E2F2F4_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A1A4E2F2F4-2.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(6, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A1A4E2F2F4_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A1A4E2F2F4-3.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(6, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A1B2B5D2D5_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A1B2B5D2D5-2.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(4, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A1B2B5D2D5_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A1B2B5D2D5-3.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(4, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A1B3B6D5E2_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A1B3B6D5E2-2.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A1B3B6D5E2_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A1B3B6D5E2-3.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A1D3E4G3G5_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A1D3E4G3G5-2.jpg"), "EnUpA1"); Assert.AreEqual(5, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A1D3E4G3G5_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A1D3E4G3G5-3.jpg"), "EnUpA1"); Assert.AreEqual(5, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A2A7D2D5E8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A2A7D2D5E8.jpg"), "EnUpA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(6, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A2B1B3E3G1_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A2B1B3E3G1-2.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(7, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A2B1B3E3G1_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A2B1B3E3G1-3.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(7, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A2B5C5D5D7_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A2B5C5D5D7-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A2B5C5D5D7_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A2B5C5D5D7-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A2B6C3D6E2_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A2B6C3D6E2-2.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A2B6C3D6E2_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A2B6C3D6E2-3.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A3A4C3D4F4_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A3A4C3D4F4-2.jpg"), "EnUpA1"); Assert.AreEqual(5, z.columns); Assert.AreEqual(7, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A3A4C3D4F4_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A3A4C3D4F4-3.jpg"), "EnUpA1"); Assert.AreEqual(5, z.columns); Assert.AreEqual(7, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A3B3B4C7D3_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A3B3B4C7D3-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(4, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A3B3B4C7D3_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A3B3B4C7D3-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(4, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A3B5F5H2J5() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A3B5F5H2J5.jpg"), "EnUpA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(10, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A3B8D3E1E7_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A3B8D3E1E7-2.jpg"), "EnUpA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A3B8D3E1E7_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A3B8D3E1E7-3.jpg"), "EnUpA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A4B1B5C3C6_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4B1B5C3C6-2.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(4, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A4B1B5C3C6_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4B1B5C3C6-3.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(4, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A4B1C1E2F2_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4B1C1E2F2-2.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(6, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A4B1C1E2F2_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4B1C1E2F2-3.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(6, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A4B2C1D2D5_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4B2C1D2D5-2.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(4, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A4B2C1D2D5_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4B2C1D2D5-3.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(4, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A4B5C7D1E7_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4B5C7D1E7-2.jpg"), "EnUpA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A4B5C7D1E7_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4B5C7D1E7-3.jpg"), "EnUpA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A4B6D4D6D7_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4B6D4D6D7-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A4B6D4D6D7_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4B6D4D6D7-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A4D2D9G6G7() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4D2D9G6G7.jpg"), "EnUpA1"); Assert.AreEqual(9, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A4F4I5J6K3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4F4I5J6K3.jpg"), "EnUpA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(12, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A5B2B4B7E6_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A5B2B4B7E6-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A5B2B4B7E6_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A5B2B4B7E6-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A5B2C2D2D5_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A5B2C2D2D5-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(4, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A5B2C2D2D5_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A5B2C2D2D5-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(4, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A5C5C6D2E1_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A5C5C6D2E1-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A5C5C6D2E1_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A5C5C6D2E1-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A6D7F2G4J9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A6D7F2G4J9.jpg"), "EnUpA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(13, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A7B1B7D1E5_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A7B1B7D1E5-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A7B1B7D1E5_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A7B1B7D1E5-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A7B1D1D5D7_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A7B1D1D5D7-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A7B1D1D5D7_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A7B1D1D5D7-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A7B6C1C2D6_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A7B6C1C2D6-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(4, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A7B6C1C2D6_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A7B6C1C2D6-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(4, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_A8B1B6E6F10() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A8B1B6E6F10.jpg"), "EnUpA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(7, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B1B4B6C3E5_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B1B4B6C3E5-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B1B4B6C3E5_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B1B4B6C3E5-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B1B6D3E1E6_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B1B6D3E1E6-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(6, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B1B6D3E1E6_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B1B6D3E1E6-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(6, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B1C2C9D4D8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B1C2C9D4D8.jpg"), "EnUpA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(7, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B1J5L5A6H9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B1J5L5A6H9.jpg"), "EnLeA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B2B3K4G5K6() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B2B3K4G5K6.jpg"), "EnLeA1"); Assert.AreEqual(13, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B2B5D6E2E3_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B2B5D6E2E3-2.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B2B5D6E2E3_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B2B5D6E2E3-3.jpg"), "EnUpA1"); Assert.AreEqual(7, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B2C4D2D4E3_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B2C4D2D4E3-2.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(6, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B2C4D2D4E3_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B2C4D2D4E3-3.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(6, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B3B4C3C4E1_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B3B4C3C4E1-2.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B3B4C3C4E1_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B3B4C3C4E1-3.jpg"), "EnUpA1"); Assert.AreEqual(4, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B3B6F3F7L6() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B3B6F3F7L6.jpg"), "EnUpA1"); Assert.AreEqual(9, z.columns); Assert.AreEqual(12, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B3G1G4H4H6() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B3G1G4H4H6.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B3G5L8E9M9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B3G5L8E9M9.jpg"), "EnLeA1"); Assert.AreEqual(13, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B4B7E2G4J2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B4B7E2G4J2.jpg"), "EnUpA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(11, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B4D5D6E2F4_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B4D5D6E2F4-2.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(6, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B4D5D6E2F4_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B4D5D6E2F4-3.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(6, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B5B7D2D8F9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B5B7D2D8F9.jpg"), "EnUpA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(7, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B5B9C9F2F8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B5B9C9F2F8.jpg"), "EnUpA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(7, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B5C1F6H8L4() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B5C1F6H8L4.jpg"), "EnUpA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(12, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B5D3D12F5I7() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B5D3D12F5I7.jpg"), "EnUpA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B6C1C4E4F1_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B6C1C4E4F1-2.jpg"), "EnUpA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(6, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B6C1C4E4F1_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B6C1C4E4F1-3.jpg"), "EnUpA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(6, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B6C3C4D2E5_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B6C3C4D2E5-2.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B6C3C4D2E5_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B6C3C4D2E5-3.jpg"), "EnUpA1"); Assert.AreEqual(6, z.columns); Assert.AreEqual(5, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B6E1F4G7H5() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B6E1F4G7H5.jpg"), "EnUpA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B7D2F6G2I8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B7D2F6G2I8.jpg"), "EnUpA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(11, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_B9H4H8I3M8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B9H4H8I3M8.jpg"), "EnUpA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(15, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_C1F1I2K6H7() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\C1F1I2K6H7.jpg"), "EnLeA1"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_C1I3F6A7I8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\C1I3F6A7I8.jpg"), "EnLeA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_C1J1M1B8F8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\C1J1M1B8F8.jpg"), "EnLeA1"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_C2D12H8H13K5() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\C2D12H8H13K5.jpg"), "EnUpA1"); Assert.AreEqual(15, z.columns); Assert.AreEqual(11, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_C2I6C7L7H9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\C2I6C7L7H9.jpg"), "EnLeA1"); Assert.AreEqual(13, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_C3D7J7E8F8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\C3D7J7E8F8.jpg"), "EnLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_C8E3G5G14H4() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\C8E3G5G14H4.jpg"), "EnUpA1"); Assert.AreEqual(15, z.columns); Assert.AreEqual(10, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_D1H3I8L7O6() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\D1H3I8L7O6.jpg"), "EnUpA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(16, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_D1J3A4A6I9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\D1J3A4A6I9.jpg"), "EnLeA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_D3G4K4I5G7() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\D3G4K4I5G7.jpg"), "EnLeA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_D3M4F6L6G8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\D3M4F6L6G8.jpg"), "EnLeA1"); Assert.AreEqual(13, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_D4E4G4C7B9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\D4E4G4C7B9.jpg"), "EnLeA1"); Assert.AreEqual(13, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_E1C2J2D5D7() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\E1C2J2D5D7.jpg"), "EnLeA1"); Assert.AreEqual(13, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_E3E9F15G3J10() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\E3E9F15G3J10.jpg"), "EnUpA1"); Assert.AreEqual(15, z.columns); Assert.AreEqual(11, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_F2H3C6G8D9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\F2H3C6G8D9.jpg"), "EnLeA1"); Assert.AreEqual(9, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_G1C2A7L7C8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\G1C2A7L7C8.jpg"), "EnLeA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_G2L2F3I4M8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\G2L2F3I4M8.jpg"), "EnLeA1"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_H1F2J5A6H8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\H1F2J5A6H8.jpg"), "EnLeA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_H2C5L5C7H7() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\H2C5L5C7H7.jpg"), "EnLeA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_H3B4K6H8F9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\H3B4K6H8F9.jpg"), "EnLeA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_H3C4J4E6M9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\H3C4J4E6M9.jpg"), "EnLeA1"); Assert.AreEqual(13, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_I1G3M3H5F8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\I1G3M3H5F8.jpg"), "EnLeA1"); Assert.AreEqual(13, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_I1H4L4D7I8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\I1H4L4D7I8.jpg"), "EnLeA1"); Assert.AreEqual(13, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_I1H6C10E11I11() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\I1H6C10E11I11.jpg"), "EnLeA1"); Assert.AreEqual(9, z.columns); Assert.AreEqual(14, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_I2B7I9D10F12() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\I2B7I9D10F12.jpg"), "EnLeA1"); Assert.AreEqual(9, z.columns); Assert.AreEqual(14, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_I3B4M6B7L9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\I3B4M6B7L9.jpg"), "EnLeA1"); Assert.AreEqual(13, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_I3J4G5M7F8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\I3J4G5M7F8.jpg"), "EnLeA1"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_J1E2F3J3C6() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\J1E2F3J3C6.jpg"), "EnLeA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_K2C3F3K4K9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\K2C3F3K4K9.jpg"), "EnLeA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_L1I3M3M5C7() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\L1I3M3M5C7.jpg"), "EnLeA1"); Assert.AreEqual(13, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_L3G4I5C6K8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\L3G4I5C6K8.jpg"), "EnLeA1"); Assert.AreEqual(13, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_А1Ж4К6Ж7К8_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\А1Ж4К6Ж7К8-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_А1И3И4З8И8_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\А1И3И4З8И8-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_А2К2З4Д6Л6_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\А2К2З4Д6Л6-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_Б1Д3А4Л5З6_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Б1Д3А4Л5З6-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_Б1Л7В8И8В9_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Б1Л7В8И8В9-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_Б2Г2Ж2Е5И10_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Б2Г2Ж2Е5И10-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(9, z.columns); Assert.AreEqual(10, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_Б3Д4А6И6Ж8_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Б3Д4А6И6Ж8-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(9, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_Б3Ж3Е6З6В7_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Б3Ж3Е6З6В7-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_В1Е1Ж6Б7Е7_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\В1Е1Ж6Б7Е7-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(10, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_В1Л2Г3К5М9_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\В1Л2Г3К5М9-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_В2З5В6Е7К7_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\В2З5В6Е7К7-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_Г1Е4Е5К5Г7_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Г1Е4Е5К5Г7-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_Г1И1К4Г8К8_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Г1И1К4Г8К8-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_Г3З3К4Е7И8_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Г3З3К4Е7И8-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_Г3Р4Ж6К6Б7_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Г3Р4Ж6К6Б7-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(16, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_Г4И4Б6Г6Д8_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Г4И4Б6Г6Д8-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_Д1К2В4Г5Ж8_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Д1К2В4Г5Ж8-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_Д2В3К5Д6Б7_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Д2В3К5Д6Б7-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_Д4К4Л6А8Б9_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Д4К4Л6А8Б9-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(10, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_Е1Д4В5И8Г9_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Е1Д4В5И8Г9-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_Е2В4И4Б6Л8_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Е2В4И4Б6Л8-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_Е2Д3В6И7Г10_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Е2Д3В6И7Г10-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(9, z.columns); Assert.AreEqual(10, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_Е2З3А8Е9З9_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Е2З3А8Е9З9-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_Е3М3И5Г7Д9_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Е3М3И5Г7Д9-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_Ж1З3А8З8Д9_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Ж1З3А8З8Д9-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(10, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_Ж2В3К3И5Е7_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Ж2В3К3И5Е7-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_Ж2В4Д7Г9Е10_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Ж2В4Д7Г9Е10-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(8, z.columns); Assert.AreEqual(10, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_Ж2Г3З4В6И9_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Ж2Г3З4В6И9-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(9, z.columns); Assert.AreEqual(10, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_З1А2Г3Ж5А8_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\З1А2Г3Ж5А8-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(9, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_З1Г4Д5В6З7_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\З1Г4Д5В6З7-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_И1А2З3Б5Е6_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\И1А2З3Б5Е6-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_К1А2Е2Ж5В7_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\К1А2Е2Ж5В7-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(10, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_К1Б2К2И3В4_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\К1Б2К2И3В4-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_Л1И3Б4Г6Е7_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Л1И3Б4Г6Е7-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(11, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_М3Е4А5М5Д9_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\М3Е4А5М5Д9-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(12, z.columns); Assert.AreEqual(9, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }
        [Test]
        public void Bounds_М3Е4Б7З7К8_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\М3Е4Б7З7К8-2_g1.jpg"), "RuLeA1"); Assert.AreEqual(14, z.columns); Assert.AreEqual(8, z.rows); Assert.AreEqual(z.Parts[0].columns, z.Parts[1].columns); Assert.AreEqual(z.Parts[0].rows, z.Parts[1].rows); }

    }

    */
        // ответы
        [TestFixture]
        public class UnitTestAllAnswers_2
        {
[Test] public void Answer_1A3H5A5I9E_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1A3H5A5I9E-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("1A3H5A5I9E", z.Answer); }
[Test] public void Answer_1B4H7A7D7H_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1B4H7A7D7H-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("1B4H7A7D7H", z.Answer); }
[Test] public void Answer_1C2J3D5J7G_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1C2J3D5J7G-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("1C2J3D5J7G", z.Answer); }
[Test] public void Answer_1C3F7I8L9B_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1C3F7I8L9B-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("1C3F7I8L9B", z.Answer); }
[Test] public void Answer_1D3G4E4J5L_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1D3G4E4J5L-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("1D3G4E4J5L", z.Answer); }
[Test] public void Answer_1F2C3J6I7I_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1F2C3J6I7I-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("1F2C3J6I7I", z.Answer); }
[Test] public void Answer_1G3B3J6M7G_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1G3B3J6M7G-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("1G3B3J6M7G", z.Answer); }
[Test] public void Answer_1G3E5B5F7B_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1G3E5B5F7B-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("1G3E5B5F7B", z.Answer); }
[Test] public void Answer_1I2F5I5K5L_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1I2F5I5K5L-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("1I2F5I5K5L", z.Answer); }
[Test] public void Answer_1I4F4K7L9H_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1I4F4K7L9H-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("1I4F4K7L9H", z.Answer); }
[Test] public void Answer_1K3G3L5A7G_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1K3G3L5A7G-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("1K3G3L5A7G", z.Answer); }
[Test] public void Answer_1L3G6G6K9E_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1L3G6G6K9E-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("1L3G6G6K9E", z.Answer); }
[Test] public void Answer_1M4H4N7D8C_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\1M4H4N7D8C-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("1M4H4N7D8C", z.Answer); }
[Test] public void Answer_2B2G3K5D8F_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\2B2G3K5D8F-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("2B2G3K5D8F", z.Answer); }
[Test] public void Answer_2B2G5H5K6A_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\2B2G5H5K6A-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("2B2G5H5K6A", z.Answer); }
[Test] public void Answer_2B2H2N7E8N_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\2B2H2N7E8N-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("2B2H2N7E8N", z.Answer); }
[Test] public void Answer_2I3L7F7H8B_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\2I3L7F7H8B-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("2I3L7F7H8B", z.Answer); }
[Test] public void Answer_2J3G4F5C5J_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\2J3G4F5C5J-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("2J3G4F5C5J", z.Answer); }
[Test] public void Answer_2L3K7L8G9A_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\2L3K7L8G9A-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("2L3K7L8G9A", z.Answer); }
[Test] public void Answer_2L5M6L7B8J_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\2L5M6L7B8J-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("2L5M6L7B8J", z.Answer); }
[Test] public void Answer_3A3D4B5K7L_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\3A3D4B5K7L-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("3A3D4B5K7L", z.Answer); }
[Test] public void Answer_3A5A6H6P9D_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\3A5A6H6P9D-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("3A5A6H6P9D", z.Answer); }
[Test] public void Answer_3B6N8A8L9C_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\3B6N8A8L9C-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("3B6N8A8L9C", z.Answer); }
[Test] public void Answer_3C3F3I4B6C_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\3C3F3I4B6C-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("3C3F3I4B6C", z.Answer); }
[Test] public void Answer_3C4G4L6F6H_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\3C4G4L6F6H-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("3C4G4L6F6H", z.Answer); }
[Test] public void Answer_3D4K6G7B7E_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\3D4K6G7B7E-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("3D4K6G7B7E", z.Answer); }
[Test] public void Answer_3G4E5E6E10E_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\3G4E5E6E10E-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("3G4E5E6E10E", z.Answer); }
[Test] public void Answer_3G6C6F9D9K_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\3G6C6F9D9K-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("3G6C6F9D9K", z.Answer); }
[Test] public void Answer_3H7B7G8H8J_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\3H7B7G8H8J-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("3H7B7G8H8J", z.Answer); }
[Test] public void Answer_3J4H6B6H7D_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\3J4H6B6H7D-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("3J4H6B6H7D", z.Answer); }
[Test] public void Answer_3L6B6E6H6M_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\3L6B6E6H6M-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("3L6B6E6H6M", z.Answer); }
[Test] public void Answer_4A5E8F8H9I_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\4A5E8F8H9I-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("4A5E8F8H9I", z.Answer); }
[Test] public void Answer_4E4L5H6E8K_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\4E4L5H6E8K-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("4E4L5H6E8K", z.Answer); }
[Test] public void Answer_4G7L9G9L10C_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\4G7L9G9L10C-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("4G7L9G9L10C", z.Answer); }
[Test] public void Answer_4H5J5M6B8G_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\4H5J5M6B8G-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("4H5J5M6B8G", z.Answer); }
[Test] public void Answer_4K6E6J6K7F_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\4K6E6J6K7F-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("4K6E6J6K7F", z.Answer); }
[Test] public void Answer_4M7I10E10G10J_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\4M7I10E10G10J-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("4M7I10E10G10J", z.Answer); }
[Test] public void Answer_5E6C7N7O10M_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\5E6C7N7O10M-2_g1.jpg"), "EnLe1A"); Assert.AreEqual("5E6C7N7O10M", z.Answer); }
[Test] public void Answer_A10B5F10G2I13() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A10B5F10G2I13.jpg"), "EnUpA1"); Assert.AreEqual("A10B5F10G2I13", z.Answer); }
[Test] public void Answer_A12B6D7G8H3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A12B6D7G8H3.jpg"), "EnUpA1"); Assert.AreEqual("A12B6D7G8H3", z.Answer); }
[Test] public void Answer_A1A3A7C1C2_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A1A3A7C1C2-2.jpg"), "EnUpA1"); Assert.AreEqual("A1A3A7C1C2", z.Answer); }
[Test] public void Answer_A1A3A7C1C2_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A1A3A7C1C2-3.jpg"), "EnUpA1"); Assert.AreEqual("A1A3A7C1C2", z.Answer); }
[Test] public void Answer_A1A4E2F2F4_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A1A4E2F2F4-2.jpg"), "EnUpA1"); Assert.AreEqual("A1A4E2F2F4", z.Answer); }
[Test] public void Answer_A1A4E2F2F4_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A1A4E2F2F4-3.jpg"), "EnUpA1"); Assert.AreEqual("A1A4E2F2F4", z.Answer); }
[Test] public void Answer_A1B2B5D2D5_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A1B2B5D2D5-2.jpg"), "EnUpA1"); Assert.AreEqual("A1B2B5D2D5", z.Answer); }
[Test] public void Answer_A1B2B5D2D5_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A1B2B5D2D5-3.jpg"), "EnUpA1"); Assert.AreEqual("A1B2B5D2D5", z.Answer); }
[Test] public void Answer_A1B3B6D5E2_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A1B3B6D5E2-2.jpg"), "EnUpA1"); Assert.AreEqual("A1B3B6D5E2", z.Answer); }
[Test] public void Answer_A1B3B6D5E2_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A1B3B6D5E2-3.jpg"), "EnUpA1"); Assert.AreEqual("A1B3B6D5E2", z.Answer); }
[Test] public void Answer_A1D3E4G3G5_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A1D3E4G3G5-2.jpg"), "EnUpA1"); Assert.AreEqual("A1D3E4G3G5", z.Answer); }
[Test] public void Answer_A1D3E4G3G5_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A1D3E4G3G5-3.jpg"), "EnUpA1"); Assert.AreEqual("A1D3E4G3G5", z.Answer); }
[Test] public void Answer_A2A7D2D5E8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A2A7D2D5E8.jpg"), "EnUpA1"); Assert.AreEqual("A2A7D2D5E8", z.Answer); }
[Test] public void Answer_A2B1B3E3G1_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A2B1B3E3G1-2.jpg"), "EnUpA1"); Assert.AreEqual("A2B1B3E3G1", z.Answer); }
[Test] public void Answer_A2B1B3E3G1_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A2B1B3E3G1-3.jpg"), "EnUpA1"); Assert.AreEqual("A2B1B3E3G1", z.Answer); }
[Test] public void Answer_A2B5C5D5D7_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A2B5C5D5D7-2.jpg"), "EnUpA1"); Assert.AreEqual("A2B5C5D5D7", z.Answer); }
[Test] public void Answer_A2B5C5D5D7_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A2B5C5D5D7-3.jpg"), "EnUpA1"); Assert.AreEqual("A2B5C5D5D7", z.Answer); }
[Test] public void Answer_A2B6C3D6E2_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A2B6C3D6E2-2.jpg"), "EnUpA1"); Assert.AreEqual("A2B6C3D6E2", z.Answer); }
[Test] public void Answer_A2B6C3D6E2_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A2B6C3D6E2-3.jpg"), "EnUpA1"); Assert.AreEqual("A2B6C3D6E2", z.Answer); }
[Test] public void Answer_A3A4C3D4F4_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A3A4C3D4F4-2.jpg"), "EnUpA1"); Assert.AreEqual("A3A4C3D4F4", z.Answer); }
[Test] public void Answer_A3A4C3D4F4_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A3A4C3D4F4-3.jpg"), "EnUpA1"); Assert.AreEqual("A3A4C3D4F4", z.Answer); }
[Test] public void Answer_A3B3B4C7D3_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A3B3B4C7D3-2.jpg"), "EnUpA1"); Assert.AreEqual("A3B3B4C7D3", z.Answer); }
[Test] public void Answer_A3B3B4C7D3_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A3B3B4C7D3-3.jpg"), "EnUpA1"); Assert.AreEqual("A3B3B4C7D3", z.Answer); }
[Test] public void Answer_A3B5F5H2J5() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A3B5F5H2J5.jpg"), "EnUpA1"); Assert.AreEqual("A3B5F5H2J5", z.Answer); }
[Test] public void Answer_A3B8D3E1E7_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A3B8D3E1E7-2.jpg"), "EnUpA1"); Assert.AreEqual("A3B8D3E1E7", z.Answer); }
[Test] public void Answer_A3B8D3E1E7_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A3B8D3E1E7-3.jpg"), "EnUpA1"); Assert.AreEqual("A3B8D3E1E7", z.Answer); }
[Test] public void Answer_A4B1B5C3C6_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4B1B5C3C6-2.jpg"), "EnUpA1"); Assert.AreEqual("A4B1B5C3C6", z.Answer); }
[Test] public void Answer_A4B1B5C3C6_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4B1B5C3C6-3.jpg"), "EnUpA1"); Assert.AreEqual("A4B1B5C3C6", z.Answer); }
[Test] public void Answer_A4B1C1E2F2_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4B1C1E2F2-2.jpg"), "EnUpA1"); Assert.AreEqual("A4B1C1E2F2", z.Answer); }
[Test] public void Answer_A4B1C1E2F2_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4B1C1E2F2-3.jpg"), "EnUpA1"); Assert.AreEqual("A4B1C1E2F2", z.Answer); }
[Test] public void Answer_A4B2C1D2D5_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4B2C1D2D5-2.jpg"), "EnUpA1"); Assert.AreEqual("A4B2C1D2D5", z.Answer); }
[Test] public void Answer_A4B2C1D2D5_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4B2C1D2D5-3.jpg"), "EnUpA1"); Assert.AreEqual("A4B2C1D2D5", z.Answer); }
[Test] public void Answer_A4B5C7D1E7_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4B5C7D1E7-2.jpg"), "EnUpA1"); Assert.AreEqual("A4B5C7D1E7", z.Answer); }
[Test] public void Answer_A4B5C7D1E7_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4B5C7D1E7-3.jpg"), "EnUpA1"); Assert.AreEqual("A4B5C7D1E7", z.Answer); }
[Test] public void Answer_A4B6D4D6D7_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4B6D4D6D7-2.jpg"), "EnUpA1"); Assert.AreEqual("A4B6D4D6D7", z.Answer); }
[Test] public void Answer_A4B6D4D6D7_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4B6D4D6D7-3.jpg"), "EnUpA1"); Assert.AreEqual("A4B6D4D6D7", z.Answer); }
[Test] public void Answer_A4D2D9G6G7() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4D2D9G6G7.jpg"), "EnUpA1"); Assert.AreEqual("A4D2D9G6G7", z.Answer); }
[Test] public void Answer_A4F4I5J6K3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A4F4I5J6K3.jpg"), "EnUpA1"); Assert.AreEqual("A4F4I5J6K3", z.Answer); }
[Test] public void Answer_A5B2B4B7E6_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A5B2B4B7E6-2.jpg"), "EnUpA1"); Assert.AreEqual("A5B2B4B7E6", z.Answer); }
[Test] public void Answer_A5B2B4B7E6_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A5B2B4B7E6-3.jpg"), "EnUpA1"); Assert.AreEqual("A5B2B4B7E6", z.Answer); }
[Test] public void Answer_A5B2C2D2D5_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A5B2C2D2D5-2.jpg"), "EnUpA1"); Assert.AreEqual("A5B2C2D2D5", z.Answer); }
[Test] public void Answer_A5B2C2D2D5_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A5B2C2D2D5-3.jpg"), "EnUpA1"); Assert.AreEqual("A5B2C2D2D5", z.Answer); }
[Test] public void Answer_A5C5C6D2E1_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A5C5C6D2E1-2.jpg"), "EnUpA1"); Assert.AreEqual("A5C5C6D2E1", z.Answer); }
[Test] public void Answer_A5C5C6D2E1_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A5C5C6D2E1-3.jpg"), "EnUpA1"); Assert.AreEqual("A5C5C6D2E1", z.Answer); }
[Test] public void Answer_A6D7F2G4J9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A6D7F2G4J9.jpg"), "EnUpA1"); Assert.AreEqual("A6D7F2G4J9", z.Answer); }
[Test] public void Answer_A7B1B7D1E5_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A7B1B7D1E5-2.jpg"), "EnUpA1"); Assert.AreEqual("A7B1B7D1E5", z.Answer); }
[Test] public void Answer_A7B1B7D1E5_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A7B1B7D1E5-3.jpg"), "EnUpA1"); Assert.AreEqual("A7B1B7D1E5", z.Answer); }
[Test] public void Answer_A7B1D1D5D7_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A7B1D1D5D7-2.jpg"), "EnUpA1"); Assert.AreEqual("A7B1D1D5D7", z.Answer); }
[Test] public void Answer_A7B1D1D5D7_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A7B1D1D5D7-3.jpg"), "EnUpA1"); Assert.AreEqual("A7B1D1D5D7", z.Answer); }
[Test] public void Answer_A7B6C1C2D6_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A7B6C1C2D6-2.jpg"), "EnUpA1"); Assert.AreEqual("A7B6C1C2D6", z.Answer); }
[Test] public void Answer_A7B6C1C2D6_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A7B6C1C2D6-3.jpg"), "EnUpA1"); Assert.AreEqual("A7B6C1C2D6", z.Answer); }
[Test] public void Answer_A8B1B6E6F10() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\A8B1B6E6F10.jpg"), "EnUpA1"); Assert.AreEqual("A8B1B6E6F10", z.Answer); }
[Test] public void Answer_B1B4B6C3E5_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B1B4B6C3E5-2.jpg"), "EnUpA1"); Assert.AreEqual("B1B4B6C3E5", z.Answer); }
[Test] public void Answer_B1B4B6C3E5_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B1B4B6C3E5-3.jpg"), "EnUpA1"); Assert.AreEqual("B1B4B6C3E5", z.Answer); }
[Test] public void Answer_B1B6D3E1E6_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B1B6D3E1E6-2.jpg"), "EnUpA1"); Assert.AreEqual("B1B6D3E1E6", z.Answer); }
[Test] public void Answer_B1B6D3E1E6_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B1B6D3E1E6-3.jpg"), "EnUpA1"); Assert.AreEqual("B1B6D3E1E6", z.Answer); }
[Test] public void Answer_B1C2C9D4D8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B1C2C9D4D8.jpg"), "EnUpA1"); Assert.AreEqual("B1C2C9D4D8", z.Answer); }
[Test] public void Answer_B1J5L5A6H9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B1J5L5A6H9.jpg"), "EnLeA1"); Assert.AreEqual("B1J5L5A6H9", z.Answer); }
[Test] public void Answer_B2B3K4G5K6() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B2B3K4G5K6.jpg"), "EnLeA1"); Assert.AreEqual("B2B3K4G5K6", z.Answer); }
[Test] public void Answer_B2B5D6E2E3_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B2B5D6E2E3-2.jpg"), "EnUpA1"); Assert.AreEqual("B2B5D6E2E3", z.Answer); }
[Test] public void Answer_B2B5D6E2E3_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B2B5D6E2E3-3.jpg"), "EnUpA1"); Assert.AreEqual("B2B5D6E2E3", z.Answer); }
[Test] public void Answer_B2C4D2D4E3_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B2C4D2D4E3-2.jpg"), "EnUpA1"); Assert.AreEqual("B2C4D2D4E3", z.Answer); }
[Test] public void Answer_B2C4D2D4E3_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B2C4D2D4E3-3.jpg"), "EnUpA1"); Assert.AreEqual("B2C4D2D4E3", z.Answer); }
[Test] public void Answer_B3B4C3C4E1_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B3B4C3C4E1-2.jpg"), "EnUpA1"); Assert.AreEqual("B3B4C3C4E1", z.Answer); }
[Test] public void Answer_B3B4C3C4E1_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B3B4C3C4E1-3.jpg"), "EnUpA1"); Assert.AreEqual("B3B4C3C4E1", z.Answer); }
[Test] public void Answer_B3B6F3F7L6() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B3B6F3F7L6.jpg"), "EnUpA1"); Assert.AreEqual("B3B6F3F7L6", z.Answer); }
[Test] public void Answer_B3G1G4H4H6() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B3G1G4H4H6.jpg"), "EnUpA1"); Assert.AreEqual("B3G1G4H4H6", z.Answer); }
[Test] public void Answer_B3G5L8E9M9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B3G5L8E9M9.jpg"), "EnLeA1"); Assert.AreEqual("B3G5L8E9M9", z.Answer); }
[Test] public void Answer_B4B7E2G4J2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B4B7E2G4J2.jpg"), "EnUpA1"); Assert.AreEqual("B4B7E2G4J2", z.Answer); }
[Test] public void Answer_B4D5D6E2F4_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B4D5D6E2F4-2.jpg"), "EnUpA1"); Assert.AreEqual("B4D5D6E2F4", z.Answer); }
[Test] public void Answer_B4D5D6E2F4_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B4D5D6E2F4-3.jpg"), "EnUpA1"); Assert.AreEqual("B4D5D6E2F4", z.Answer); }
[Test] public void Answer_B5B7D2D8F9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B5B7D2D8F9.jpg"), "EnUpA1"); Assert.AreEqual("B5B7D2D8F9", z.Answer); }
[Test] public void Answer_B5B9C9F2F8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B5B9C9F2F8.jpg"), "EnUpA1"); Assert.AreEqual("B5B9C9F2F8", z.Answer); }
[Test] public void Answer_B5C1F6H8L4() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B5C1F6H8L4.jpg"), "EnUpA1"); Assert.AreEqual("B5C1F6H8L4", z.Answer); }
[Test] public void Answer_B5D3D12F5I7() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B5D3D12F5I7.jpg"), "EnUpA1"); Assert.AreEqual("B5D3D12F5I7", z.Answer); }
[Test] public void Answer_B6C1C4E4F1_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B6C1C4E4F1-2.jpg"), "EnUpA1"); Assert.AreEqual("B6C1C4E4F1", z.Answer); }
[Test] public void Answer_B6C1C4E4F1_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B6C1C4E4F1-3.jpg"), "EnUpA1"); Assert.AreEqual("B6C1C4E4F1", z.Answer); }
[Test] public void Answer_B6C3C4D2E5_2() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B6C3C4D2E5-2.jpg"), "EnUpA1"); Assert.AreEqual("B6C3C4D2E5", z.Answer); }
[Test] public void Answer_B6C3C4D2E5_3() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B6C3C4D2E5-3.jpg"), "EnUpA1"); Assert.AreEqual("B6C3C4D2E5", z.Answer); }
[Test] public void Answer_B6E1F4G7H5() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B6E1F4G7H5.jpg"), "EnUpA1"); Assert.AreEqual("B6E1F4G7H5", z.Answer); }
[Test] public void Answer_B7D2F6G2I8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B7D2F6G2I8.jpg"), "EnUpA1"); Assert.AreEqual("B7D2F6G2I8", z.Answer); }
[Test] public void Answer_B9H4H8I3M8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\B9H4H8I3M8.jpg"), "EnUpA1"); Assert.AreEqual("B9H4H8I3M8", z.Answer); }
[Test] public void Answer_C1F1I2K6H7() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\C1F1I2K6H7.jpg"), "EnLeA1"); Assert.AreEqual("C1F1I2K6H7", z.Answer); }
[Test] public void Answer_C1I3F6A7I8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\C1I3F6A7I8.jpg"), "EnLeA1"); Assert.AreEqual("C1I3F6A7I8", z.Answer); }
[Test] public void Answer_C1J1M1B8F8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\C1J1M1B8F8.jpg"), "EnLeA1"); Assert.AreEqual("C1J1M1B8F8", z.Answer); }
[Test] public void Answer_C2D12H8H13K5() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\C2D12H8H13K5.jpg"), "EnUpA1"); Assert.AreEqual("C2D12H8H13K5", z.Answer); }
[Test] public void Answer_C2I6C7L7H9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\C2I6C7L7H9.jpg"), "EnLeA1"); Assert.AreEqual("C2I6C7L7H9", z.Answer); }
[Test] public void Answer_C3D7J7E8F8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\C3D7J7E8F8.jpg"), "EnLeA1"); Assert.AreEqual("C3D7J7E8F8", z.Answer); }
[Test] public void Answer_C8E3G5G14H4() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\C8E3G5G14H4.jpg"), "EnUpA1"); Assert.AreEqual("C8E3G5G14H4", z.Answer); }
[Test] public void Answer_D1H3I8L7O6() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\D1H3I8L7O6.jpg"), "EnUpA1"); Assert.AreEqual("D1H3I8L7O6", z.Answer); }
[Test] public void Answer_D1J3A4A6I9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\D1J3A4A6I9.jpg"), "EnLeA1"); Assert.AreEqual("D1J3A4A6I9", z.Answer); }
[Test] public void Answer_D3G4K4I5G7() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\D3G4K4I5G7.jpg"), "EnLeA1"); Assert.AreEqual("D3G4K4I5G7", z.Answer); }
[Test] public void Answer_D3M4F6L6G8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\D3M4F6L6G8.jpg"), "EnLeA1"); Assert.AreEqual("D3M4F6L6G8", z.Answer); }
[Test] public void Answer_D4E4G4C7B9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\D4E4G4C7B9.jpg"), "EnLeA1"); Assert.AreEqual("D4E4G4C7B9", z.Answer); }
[Test] public void Answer_E1C2J2D5D7() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\E1C2J2D5D7.jpg"), "EnLeA1"); Assert.AreEqual("E1C2J2D5D7", z.Answer); }
[Test] public void Answer_E3E9F15G3J10() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\E3E9F15G3J10.jpg"), "EnUpA1"); Assert.AreEqual("E3E9F15G3J10", z.Answer); }
[Test] public void Answer_F2H3C6G8D9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\F2H3C6G8D9.jpg"), "EnLeA1"); Assert.AreEqual("F2H3C6G8D9", z.Answer); }
[Test] public void Answer_G1C2A7L7C8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\G1C2A7L7C8.jpg"), "EnLeA1"); Assert.AreEqual("G1C2A7L7C8", z.Answer); }
[Test] public void Answer_G2L2F3I4M8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\G2L2F3I4M8.jpg"), "EnLeA1"); Assert.AreEqual("G2L2F3I4M8", z.Answer); }
[Test] public void Answer_H1F2J5A6H8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\H1F2J5A6H8.jpg"), "EnLeA1"); Assert.AreEqual("H1F2J5A6H8", z.Answer); }
[Test] public void Answer_H2C5L5C7H7() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\H2C5L5C7H7.jpg"), "EnLeA1"); Assert.AreEqual("H2C5L5C7H7", z.Answer); }
[Test] public void Answer_H3B4K6H8F9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\H3B4K6H8F9.jpg"), "EnLeA1"); Assert.AreEqual("H3B4K6H8F9", z.Answer); }
[Test] public void Answer_H3C4J4E6M9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\H3C4J4E6M9.jpg"), "EnLeA1"); Assert.AreEqual("H3C4J4E6M9", z.Answer); }
[Test] public void Answer_I1G3M3H5F8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\I1G3M3H5F8.jpg"), "EnLeA1"); Assert.AreEqual("I1G3M3H5F8", z.Answer); }
[Test] public void Answer_I1H4L4D7I8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\I1H4L4D7I8.jpg"), "EnLeA1"); Assert.AreEqual("I1H4L4D7I8", z.Answer); }
[Test] public void Answer_I1H6C10E11I11() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\I1H6C10E11I11.jpg"), "EnLeA1"); Assert.AreEqual("I1H6C10E11I11", z.Answer); }
[Test] public void Answer_I2B7I9D10F12() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\I2B7I9D10F12.jpg"), "EnLeA1"); Assert.AreEqual("I2B7I9D10F12", z.Answer); }
[Test] public void Answer_I3B4M6B7L9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\I3B4M6B7L9.jpg"), "EnLeA1"); Assert.AreEqual("I3B4M6B7L9", z.Answer); }
[Test] public void Answer_I3J4G5M7F8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\I3J4G5M7F8.jpg"), "EnLeA1"); Assert.AreEqual("I3J4G5M7F8", z.Answer); }
[Test] public void Answer_J1E2F3J3C6() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\J1E2F3J3C6.jpg"), "EnLeA1"); Assert.AreEqual("J1E2F3J3C6", z.Answer); }
[Test] public void Answer_K2C3F3K4K9() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\K2C3F3K4K9.jpg"), "EnLeA1"); Assert.AreEqual("K2C3F3K4K9", z.Answer); }
[Test] public void Answer_L1I3M3M5C7() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\L1I3M3M5C7.jpg"), "EnLeA1"); Assert.AreEqual("L1I3M3M5C7", z.Answer); }
[Test] public void Answer_L3G4I5C6K8() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\L3G4I5C6K8.jpg"), "EnLeA1"); Assert.AreEqual("L3G4I5C6K8", z.Answer); }
[Test] public void Answer_А1Ж4К6Ж7К8_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\А1Ж4К6Ж7К8-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("А1Ж4К6Ж7К8", z.Answer); }
[Test] public void Answer_А1И3И4З8И8_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\А1И3И4З8И8-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("А1И3И4З8И8", z.Answer); }
[Test] public void Answer_А2К2З4Д6Л6_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\А2К2З4Д6Л6-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("А2К2З4Д6Л6", z.Answer); }
[Test] public void Answer_Б1Д3А4Л5З6_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Б1Д3А4Л5З6-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("Б1Д3А4Л5З6", z.Answer); }
[Test] public void Answer_Б1Л7В8И8В9_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Б1Л7В8И8В9-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("Б1Л7В8И8В9", z.Answer); }
[Test] public void Answer_Б2Г2Ж2Е5И10_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Б2Г2Ж2Е5И10-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("Б2Г2Ж2Е5И10", z.Answer); }
[Test] public void Answer_Б3Д4А6И6Ж8_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Б3Д4А6И6Ж8-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("Б3Д4А6И6Ж8", z.Answer); }
[Test] public void Answer_Б3Ж3Е6З6В7_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Б3Ж3Е6З6В7-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("Б3Ж3Е6З6В7", z.Answer); }
[Test] public void Answer_В1Е1Ж6Б7Е7_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\В1Е1Ж6Б7Е7-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("В1Е1Ж6Б7Е7", z.Answer); }
[Test] public void Answer_В1Л2Г3К5М9_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\В1Л2Г3К5М9-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("В1Л2Г3К5М9", z.Answer); }
[Test] public void Answer_В2З5В6Е7К7_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\В2З5В6Е7К7-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("В2З5В6Е7К7", z.Answer); }
[Test] public void Answer_Г1Е4Е5К5Г7_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Г1Е4Е5К5Г7-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("Г1Е4Е5К5Г7", z.Answer); }
[Test] public void Answer_Г1И1К4Г8К8_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Г1И1К4Г8К8-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("Г1И1К4Г8К8", z.Answer); }
[Test] public void Answer_Г3З3К4Е7И8_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Г3З3К4Е7И8-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("Г3З3К4Е7И8", z.Answer); }
[Test] public void Answer_Г3Р4Ж6К6Б7_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Г3Р4Ж6К6Б7-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("Г3Р4Ж6К6Б7", z.Answer); }
[Test] public void Answer_Г4И4Б6Г6Д8_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Г4И4Б6Г6Д8-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("Г4И4Б6Г6Д8", z.Answer); }
[Test] public void Answer_Д1К2В4Г5Ж8_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Д1К2В4Г5Ж8-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("Д1К2В4Г5Ж8", z.Answer); }
[Test] public void Answer_Д2В3К5Д6Б7_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Д2В3К5Д6Б7-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("Д2В3К5Д6Б7", z.Answer); }
[Test] public void Answer_Д4К4Л6А8Б9_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Д4К4Л6А8Б9-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("Д4К4Л6А8Б9", z.Answer); }
[Test] public void Answer_Е1Д4В5И8Г9_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Е1Д4В5И8Г9-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("Е1Д4В5И8Г9", z.Answer); }
[Test] public void Answer_Е2В4И4Б6Л8_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Е2В4И4Б6Л8-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("Е2В4И4Б6Л8", z.Answer); }
[Test] public void Answer_Е2Д3В6И7Г10_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Е2Д3В6И7Г10-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("Е2Д3В6И7Г10", z.Answer); }
[Test] public void Answer_Е2З3А8Е9З9_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Е2З3А8Е9З9-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("Е2З3А8Е9З9", z.Answer); }
[Test] public void Answer_Е3М3И5Г7Д9_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Е3М3И5Г7Д9-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("Е3М3И5Г7Д9", z.Answer); }
[Test] public void Answer_Ж1З3А8З8Д9_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Ж1З3А8З8Д9-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("Ж1З3А8З8Д9", z.Answer); }
[Test] public void Answer_Ж2В3К3И5Е7_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Ж2В3К3И5Е7-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("Ж2В3К3И5Е7", z.Answer); }
[Test] public void Answer_Ж2В4Д7Г9Е10_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Ж2В4Д7Г9Е10-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("Ж2В4Д7Г9Е10", z.Answer); }
[Test] public void Answer_Ж2Г3З4В6И9_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Ж2Г3З4В6И9-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("Ж2Г3З4В6И9", z.Answer); }
[Test] public void Answer_З1А2Г3Ж5А8_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\З1А2Г3Ж5А8-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("З1А2Г3Ж5А8", z.Answer); }
[Test] public void Answer_З1Г4Д5В6З7_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\З1Г4Д5В6З7-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("З1Г4Д5В6З7", z.Answer); }
[Test] public void Answer_И1А2З3Б5Е6_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\И1А2З3Б5Е6-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("И1А2З3Б5Е6", z.Answer); }
[Test] public void Answer_К1А2Е2Ж5В7_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\К1А2Е2Ж5В7-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("К1А2Е2Ж5В7", z.Answer); }
[Test] public void Answer_К1Б2К2И3В4_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\К1Б2К2И3В4-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("К1Б2К2И3В4", z.Answer); }
[Test] public void Answer_Л1И3Б4Г6Е7_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\Л1И3Б4Г6Е7-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("Л1И3Б4Г6Е7", z.Answer); }
[Test] public void Answer_М3Е4А5М5Д9_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\М3Е4А5М5Д9-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("М3Е4А5М5Д9", z.Answer); }
[Test] public void Answer_М3Е4Б7З7К8_2_g1() { FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\М3Е4Б7З7К8-2_g1.jpg"), "RuLeA1"); Assert.AreEqual("М3Е4Б7З7К8", z.Answer); }

        }
       


    /*    
    [TestFixture]
    public class UnitTestShifts2
    {
        [Test]
        public void Shifts0()
        {
            FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\9\0.jpg"));
            Assert.AreEqual(0 + 1, z.shift_hor);
            Assert.AreEqual(0, z.shift_ver);
        }
        [Test]
        public void ShiftsL()
        {
            FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\9\l.jpg"));
            Assert.AreEqual(-5 + 1, z.shift_hor);
            Assert.AreEqual(0, z.shift_ver);
        }
        [Test]
        public void ShiftsR()
        {
            FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\9\r.jpg"));
            Assert.AreEqual(5 + 1, z.shift_hor);
            Assert.AreEqual(0, z.shift_ver);
        }
        [Test]
        public void ShiftsU()
        {
            FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\9\u.jpg"));
            Assert.AreEqual(0 + 1, z.shift_hor);
            Assert.AreEqual(-6, z.shift_ver);
        }
        [Test]
        public void ShiftsD()
        {
            FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\9\d.jpg"));
            Assert.AreEqual(0 + 1, z.shift_hor);
            Assert.AreEqual(5, z.shift_ver);
        }
        [Test]
        public void ShiftsLU()
        {
            FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\9\lu.jpg"));
            Assert.AreEqual(-6 + 1, z.shift_hor);
            Assert.AreEqual(-7, z.shift_ver);
        }
        [Test]
        public void ShiftsLD()
        {
            FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\9\ld.jpg"));
            Assert.AreEqual(-5 + 1, z.shift_hor);
            Assert.AreEqual(5, z.shift_ver);
        }
        [Test]
        public void ShiftsRD()
        {
            FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\9\rd.jpg"));
            Assert.AreEqual(6 + 1, z.shift_hor);
            Assert.AreEqual(6, z.shift_ver);
        }
        [Test]
        public void ShiftsRU()
        {
            FiveDifference z = new FiveDifference(new Bitmap(@"C:\Users\Антон\Source\Repos\FiveDiff\FiveDiff\FiveDiffTests\pics4test\9\ru.jpg"));
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
            FiveDifference z = new FiveDifference(new Bitmap(@"C:\temp\01.jpg"));
            float[] a = new float[8] { 4.6f, 3.2f, 1.5f, 0.6f, 3.1f, 0.5f, 2.5f, 45.9f };
            int[] b = new int[5] { 5, 3, 2, 6, 4 };
            Assert.AreEqual(b, z.GetFiveMinIndex(a));
            z = new FiveDifference(new Bitmap(@"C:\temp\01.jpg"));
            a = new float[8] { 3.1f, 3.2f, 1.5f, 0.6f, 3.1f, 0.5f, 2.5f, 45.9f };
            b = new int[5] { 5, 3, 2, 6, 0 };
            Assert.AreEqual(b, z.GetFiveMinIndex(a));
            z = new FiveDifference(new Bitmap(@"C:\temp\01.jpg"));
            a = new float[8] { 3.3f, 3.1f, 3.1f, 3.1f, 3.1f, 3.11f, 3.1f, 3.1f };
            b = new int[5] { 1, 2, 3, 4, 6 };
            Assert.AreEqual(b, z.GetFiveMinIndex(a));
        }
        [TestCase]
        public void GetMinIndex_1()
        {
            FiveDifference z = new FiveDifference(new Bitmap(@"C:\temp\01.jpg"));
            float[] a = new float[4] { 4.6f, 3.1f, 1.5f, 45.9f };
            Assert.AreEqual(2, z.GetMinIndex(a));
            a = new float[4] { 0.6f, 3.1f, 1.5f, 45.9f };
            Assert.AreEqual(0, z.GetMinIndex(a));
        }
        [TestCase]
        public void KillDupesShifts_1()
        {
            FiveDifference z = new FiveDifference(new Bitmap(@"C:\temp\01.jpg"));
            FiveDifference.ShArr[] arr1 = new FiveDifference.ShArr[5];
            FiveDifference.ShArr[] arr2 = new FiveDifference.ShArr[4];
            FiveDifference.ShArr q1 = new FiveDifference.ShArr();
            q1.shift_h = 10; q1.shift_v = 10; arr1[0] = q1; arr2[0] = q1;
            q1.shift_h = 20; q1.shift_v = 20; arr1[1] = q1; arr2[1] = q1;
            q1.shift_h = 24; q1.shift_v = -3; arr1[2] = q1; arr2[2] = q1;
            q1.shift_h = 20; q1.shift_v = 20; arr1[3] = q1;
            q1.shift_h = -9; q1.shift_v = -3; arr1[4] = q1; arr2[3] = q1;

            Assert.AreEqual(arr2, z.KillDupesShifts(arr1));
        }
    }
    */
}
