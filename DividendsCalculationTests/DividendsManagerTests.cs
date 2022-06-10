using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DividendsCalculation.Tests {
    [TestClass()]
    public class DividendsManagerTests {
        [TestInitialize]
        public void StartTest() {
            Mew.AppLogAndEventHelper.Instance.AddReceiver(Mew.Recievers.DebugConsoleWrite);
        }

        [TestCleanup]
        public void AfterTest() {
            Mew.AppLogAndEventHelper.Instance.RemoveReceiver(Mew.Recievers.DebugConsoleWrite);
        }

        [TestMethod,
         DataRow("", "", 100000, 0.1, 20, 124668.85)]
        [DataRow("2022-06-10", "2022-06-10", 10000, 0.05, 3, 771.11)]
        [DataRow("2022-06-10", "2025-04-26", 10000, 0.05, 3, 1.21)]
        [DataRow("2022-06-10", "2040-04-26", 10000, 0.05, 3, 0)]
        public void CalculateTotalInterestTest(string start_date_str, string calc_date_str, double X, double R, int N, double result) {
            var start_date = GetDateFromString(start_date_str);
            var calc_date = GetDateFromString(calc_date_str);

            var dm = new DividendsManager() {
                AgreementDate = start_date,
                InvestedSum = X,
                InvestmentDuration = N,
                InterestRate = R,
            };
            Mew.AppLogAndEventHelper.Instance.RaiseDebugInfo(start_date, calc_date, X, R, N, result);
            var r = Math.Round(dm.CalculateTotalInterest(calc_date), 2);
            Mew.AppLogAndEventHelper.Instance.RaiseDebugInfo(r);

            if (result == 0)
                Assert.AreEqual(r, result);
            else
                Assert.IsTrue(Math.Abs(1 - r / result) <= 0.001);
        }

        private static DateTime GetDateFromString(string s) {
            if (string.IsNullOrWhiteSpace(s)) return DateTime.Today;
            if (!DateTime.TryParse(s, out var d)) {
                d = DateTime.Today;
            }

            return d;
        }
    }
}