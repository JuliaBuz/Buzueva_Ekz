using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Skidka;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        Class1 class1 = new Class1();
        [TestMethod]
        public void TestMethod1()
        {
            int exp = 0;
            var ans = class1.sale(1, 300);
            Assert.AreEqual(exp, ans);
        }
        [TestMethod]
        public void TestMethod2()
        {
            int exp = 0;
            var ans = class1.sale(1, 200);
            Assert.AreEqual(exp, ans);
        }
        [TestMethod]
        public void TestMethod3()
        {
            int exp = 5;
            var ans = class1.sale(3, 400);
            Assert.AreEqual(exp, ans);
        }
        [TestMethod]
        public void TestMethod4()
        {
            int exp = 6;
            var ans = class1.sale(3, 700);
            Assert.AreEqual(exp, ans);
        }

        [TestMethod]
        public void TestMethod5()
        {
            int exp = 10;
            var ans = class1.sale(5, 450);
            Assert.AreEqual(exp, ans);
        }
        [TestMethod]
        public void TestMethod6()
        {
            int exp = 11;
            var ans = class1.sale(5, 580);
            Assert.AreEqual(exp, ans);
        }
        [TestMethod]
        public void TestMethod7()
        {
            int exp = 12;
            var ans = class1.sale(6, 1100);
            Assert.AreEqual(exp, ans);
        }

        [TestMethod]
        public void TestMethod8()
        {
            int exp = 17;
            var ans = class1.sale(10, 1000);
            Assert.AreEqual(exp, ans);
        }
        [TestMethod]
        public void TestMethod9()
        {
            int exp = 16;
            var ans = class1.sale(11, 600);
            Assert.AreEqual(exp, ans);
        }
        [TestMethod]
        public void TestMethod10()
        {
            int exp = 17;
            var ans = class1.sale(15, 1200);
            Assert.AreEqual(exp, ans);
        }
        
        
    }
}
