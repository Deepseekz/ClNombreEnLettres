﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CLNombreEnLettres;
using System.Collections.Generic;

namespace UnitTestProject3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodZero()
        {
            Assert.AreEqual("zéro", EnToutesLettres.EntierEnLettres(0));
        }
        [TestMethod]
        public void TestMethodUn()
        {
            Assert.AreEqual("un", EnToutesLettres.EntierEnLettres(1));
        }
        [TestMethod]
        public void TestMethod17()
        {
            Assert.AreEqual("dix-sept", EnToutesLettres.EntierEnLettres(17));
        }
        [TestMethod]
        public void TestMethod23()
        {
            Assert.AreEqual("vingt-trois", EnToutesLettres.EntierEnLettres(23));
        }
        [TestMethod]
        public void TestMethod192814()
        {
            Assert.AreEqual("cent quatre-vingt-douze mille huit cent quatorze", EnToutesLettres.EntierEnLettres(192814));
        }
        [TestMethod]
        public void TestMethod80()
        {
            Assert.AreEqual("quatre-vingts", EnToutesLettres.EntierEnLettres(80));
        }
        [TestMethod]
        public void TestMethod82()
        {
            Assert.AreEqual("quatre-vingt-deux", EnToutesLettres.EntierEnLettres(82));
        }
        [TestMethod]
        public void TestMethod100()
        {
            Assert.AreEqual("cent", EnToutesLettres.EntierEnLettres(100));
        }
        [TestMethod]
        public void TestMethod200()
        {
            Assert.AreEqual("deux cents", EnToutesLettres.EntierEnLettres(200));
        }
        [TestMethod]
        public void TestMethod5600152000()
        {
            Assert.AreEqual("cinq milliards six cent millions cent cinquante-deux mille", EnToutesLettres.EntierEnLettres(5600152000));
        }

        [TestMethod]
        public void TestMethodDecouperNombre()
        {
            EnToutesLettres.DecouperNombre(4.452, out long partieEntiere, out int partieDecimal, out int nombreDecimal);
            Assert.AreEqual(4, partieEntiere);
            Assert.AreEqual(45, partieDecimal);
            Assert.AreEqual(2, nombreDecimal);
        }

        [TestMethod]
        public void TestMethodDecouperNombreUnChiffreApresVirgule()
        {
            EnToutesLettres.DecouperNombre(1235.2f, out long partieEntiere, out int partieDecimal, out int nombreDecimal);
            Assert.AreEqual(1235, partieEntiere);
            Assert.AreEqual(2, partieDecimal);
            Assert.AreEqual(1, nombreDecimal);
        }
    }
}
