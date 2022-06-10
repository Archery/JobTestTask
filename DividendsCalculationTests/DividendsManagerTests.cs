using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DividendsCalculation.Tests {
    [TestClass()]
    public class DividendsManagerTests {
        [TestInitialize]
        public void StartTest() {
            Mew.AppLogAndEventHelper.Instance.AddReceiver(Mew.Recievers.DebugConsoleWrite);
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
            Mew.AppLogAndEventHelper.Instance.RaiseDebugInfo(start_date.Value, calc_date.Value, X, R, N, result);
            var r = dm.CalculateTotalInterest(calc_date.Value);
            Mew.AppLogAndEventHelper.Instance.RaiseDebugInfo(r);

            Assert.IsTrue(Math.Abs(result - r) / result <= 0.001);
        }
    }
}