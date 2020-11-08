using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClNombreEnLettres;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodNegatif()
        {
            Assert.AreEqual("moins ", EnToutesLettres.EntierEnLettres(-1));
        }

        [TestMethod]
        public void TestMethod0()
        {
            Assert.AreEqual("zéro",EnToutesLettres.EntierEnLettres(0));
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("un", EnToutesLettres.EntierEnLettres(1));
        }

        [TestMethod]
        public void TestMethod7()
        {
            Assert.AreEqual("sept", EnToutesLettres.EntierEnLettres(7));
        }

        [TestMethod]
        public void TestMethod10()
        {
            Assert.AreEqual("dix", EnToutesLettres.EntierEnLettres(10));
        }

        [TestMethod]
        public void TestMethod15()
        {
            Assert.AreEqual("quinze", EnToutesLettres.EntierEnLettres(15));
        }

        [TestMethod]
        public void TestMethod17()
        {
            Assert.AreEqual("dix-sept", EnToutesLettres.EntierEnLettres(17));
        }

        [TestMethod]
        public void TestMethod20()
        {
            Assert.AreEqual("vingt", EnToutesLettres.EntierEnLettres(20));
        }

        [TestMethod]
        public void TestMethod21()
        {
            Assert.AreEqual("vingt-et-un", EnToutesLettres.EntierEnLettres(21));
        }

        [TestMethod]
        public void TestMethod23()
        {
            Assert.AreEqual("vingt-trois", EnToutesLettres.EntierEnLettres(23));
        }

        [TestMethod]
        public void TestMethod60()
        {
            Assert.AreEqual("soixante", EnToutesLettres.EntierEnLettres(60));
        }

        [TestMethod]
        public void TestMethod70()
        {
            Assert.AreEqual("soixante-dix", EnToutesLettres.EntierEnLettres(70));
        }

        [TestMethod]
        public void TestMethod91()
        {
            Assert.AreEqual("quatre-vingt-onze", EnToutesLettres.EntierEnLettres(91));
        }
    }
}
