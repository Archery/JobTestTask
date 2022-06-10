using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DividendsCalculation.Tests {
    [TestClass()]
    public class DividendsManagerTests {
        [TestMethod()]
        public void DividendsManagerTest() {
            Assert.Fail();
        }

        [TestMethod,
         DataRow(null, null, 100000, 0.1, 20, 124668.85)]
        public void CalculateTotalInterestTest(DateTime? start_date, DateTime? calc_date, double X, double R, int N, double result) {
            start_date ??= DateTime.Today;
            calc_date ??= DateTime.Today;

            var dm = new DividendsManager() {
                AgreementDate = start_date.Value,
                InvestedSum = X,
                InvestmentDuration = N,
                InterestRate = R,
            };

            Assert.AreEqual(result, dm.CalculateTotalInterest(calc_date.Value));
            Assert.Fail();
        }
    }
}