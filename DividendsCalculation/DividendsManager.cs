using System;
using System.Diagnostics;
using Mew;

namespace DividendsCalculation {
    public class DividendsManager {
        private double investedSum_;
        private int investmentDuration_;
        private double interestRate_;

        public double InvestedSum { //X
            get => this.investedSum_;
            set {
                Debug.Assert(value > 0, "Invested sum (X) must be positive");
                this.investedSum_ = value;
            }
        }

        public int InvestmentDuration { //N
            get => this.investmentDuration_;
            set {
                Debug.Assert(value > 0, "Investment duration (N) must be positive");
                this.investmentDuration_ = value;
            }
        }

        public double InterestRate { //R
            get => this.interestRate_;
            set {
                Debug.Assert(value > 0, "Interest rate (R) must be positive");
                this.interestRate_ = value > 1 ? value / 100.0 : value;
            }
        }

        public DateTime AgreementDate { get; set; } //Agreement date

        public DividendsManager() { }

        public double CalculateTotalInterest(DateTime calculation_date) {
            if (this.AgreementDate.AddYears(this.InvestmentDuration) < calculation_date) {
                AppLogAndEventHelper.Instance.RaiseEvent(EventType.Result, "Everything was payed");
                return 0;
            }

            // по формулам из википедии, за правильность ручаться трудно
            //ka - Коэффициент аннуитета, m: выплаты производятся постнумерандо m раз в год в течение n лет 
            const int period = 30;
            const int m = 365 / period;
            var p1 = Math.Pow(1 + this.InterestRate, 1d / m);
            var k = this.InvestmentDuration * m;
            var ka = Math.Pow(p1, k) * (p1 - 1) / (Math.Pow(p1, k) - 1);
            var payment_amount = this.InvestedSum * ka;
            AppLogAndEventHelper.Instance.RaiseDebugInfo(p1, k, ka, payment_amount);

            var day = this.AgreementDate;
            var debt_rest = this.InvestedSum;
            var interest_sum = 0d;
            while (debt_rest > 0.01) {
                day = day.AddDays(period);
                var interest_amount = (p1 - 1) * debt_rest;
                debt_rest -= payment_amount - interest_amount;

                if (day < calculation_date) continue;

                AppLogAndEventHelper.Instance.RaiseInfo($" {day:yyyy-MM-dd} {interest_amount:F2} {payment_amount - interest_amount:F2} {debt_rest:F2}");
                interest_sum += interest_amount;
            }

            return interest_sum;
        }
    }
}