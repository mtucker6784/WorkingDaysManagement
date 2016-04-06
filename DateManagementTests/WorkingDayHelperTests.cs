﻿using DateManagementTests.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DateManagement.Tests
{
    [TestClass()]
    public class WorkingDayHelperTests
    {
        [TestMethod()]
        public void WorkingDayHelperNoArgsTest()
        {
            var helper = new WorkingDayHelper();

            Assert.AreNotEqual(null, helper);
        }

        [TestMethod()]
        public void WorkingDayHelperHolidayTest()
        {
            var helper = new WorkingDayHelper(new List<DateTime>());

            Assert.AreNotEqual(null, helper);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WorkingDayHelperNullTest()
        {
            var helper = new WorkingDayHelper(null);
        }

        [TestMethod]
        public void TestCalculDate1JourFerie()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 01, 08);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-08"), managementHelper.GetLast(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-01-07"), managementHelper.GetYesterday(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2014-12-31"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void TestCalculDate1JourFerieCas2()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 01, 07);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-07"), managementHelper.GetLast(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-01-06"), managementHelper.GetYesterday(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2014-12-30"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void TestCalculDate1JourFerieCas3()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 12, 28);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-28"), managementHelper.GetLast(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-12-24"), managementHelper.GetYesterday(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-12-18"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void TestCalculDate1JourFerieCas4()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 12, 29);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-29"), managementHelper.GetLast(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-12-28"), managementHelper.GetYesterday(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-12-21"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void TestCalculDate2JoursFeriesCas1()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2014, 12, 30);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2014-12-30"), managementHelper.GetLast(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2014-12-29"), managementHelper.GetYesterday(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2014-12-22"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void TestCalculDate2JoursFeriesCas2()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2016, 01, 04);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2016-01-04"), managementHelper.GetLast(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-12-31"), managementHelper.GetYesterday(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-12-24"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void TestCalculDate3JourFerie()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 01, 02);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-02"), managementHelper.GetLast(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2014-12-31"), managementHelper.GetYesterday(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2014-12-25"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void TestCalculDateAucunJourFerie()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 01, 13);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-13"), managementHelper.GetLast(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-01-12"), managementHelper.GetYesterday(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-01-05"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void TestCalculDateNormal()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 07, 23);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-07-23"), managementHelper.GetLast(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-07-22"), managementHelper.GetYesterday(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-07-15"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void TestCalculDateWeekEnd()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 01, 12);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-12"), managementHelper.GetLast(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-01-09"), managementHelper.GetYesterday(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-01-02"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void TestCalculLendemainJourFeriePuisWeekend()
        {
            var dateReference = new DateTime(2015, 04, 30);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-05-04"), managementHelper.GetTomorrow(Convert.ToDateTime("2015-04-30")));
        }

        [TestMethod]
        public void TestCalculLendemainSemaine()
        {
            var dateReference = new DateTime(2015, 08, 11);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-08-12"), managementHelper.GetTomorrow(Convert.ToDateTime("2015-08-11")));
        }

        [TestMethod]
        public void TestCalculLendemainSemaineJourFerie()
        {
            var dateReference = new DateTime(2014, 12, 31);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-02"), managementHelper.GetTomorrow(Convert.ToDateTime("2014-12-31")));
        }

        [TestMethod]
        public void TestCalculLendemainWeekend()
        {
            var dateReference = new DateTime(2015, 08, 11);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-08-17"), managementHelper.GetTomorrow(Convert.ToDateTime("2015-08-14")));
        }

        [TestMethod]
        public void TestCalculLendemainWeekendPuisJourFerie()
        {
            var dateReference = new DateTime(2015, 04, 03);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-04-07"), managementHelper.GetTomorrow(Convert.ToDateTime("2015-04-03")));
        }

        [TestMethod]
        public void TestCalculNbJoursUnAnDimanche()
        {
            var dateReference = new DateTime(2014, 11, 22);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            // Le 22-11-15 est un dimanche donc 365+1
            Assert.AreEqual(366.00, managementHelper.GetSpanDays(dateReference, dateReference.AddYears(1) - dateReference));
        }

        [TestMethod]
        public void TestCalculNbJoursUnAnFerie()
        {
            var dateReference = new DateTime(2015, 03, 28);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            // Le 28-03-2016 est ferié donc 366+1
            Assert.AreEqual(367.00, managementHelper.GetSpanDays(dateReference, dateReference.AddYears(1) - dateReference));
        }

        [TestMethod]
        public void TestCalculNbJoursUnAnSamedi()
        {
            var dateReference = new DateTime(2014, 11, 21);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            // Le 21-11-15 est un samedi donc 365+2
            Assert.AreEqual(367.00, managementHelper.GetSpanDays(dateReference, dateReference.AddYears(1) - dateReference));
        }
    }
}