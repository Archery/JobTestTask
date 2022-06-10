using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public double InterestRate {//R
            get => this.interestRate_;
            set {
                Debug.Assert(value > 0, "Interest rate (R) must be positive");
                this.interestRate_ = value;
            }
        }

        public DateTime AgreementDate { get; set; } //Agreement date

        public DividendsManager() { }

        public double CalculateTotalInterest(DateTime calculation_date) {
            //Коэффициент аннуитета
            var ka = 
            var period_payment = 

            throw new NotImplementedException();
        }

        public class Dividend {
            public DateTime Date { get; private set; }
            public double InterestPayment { get; private set; }
            public double PrincipalPayment { get; private set; }
            public double DebtRest { get; private set; }

            public Dividend(DateTime date, double interest_payment, double principal_payment, double debt_rest) {
                this.Date = date;
                this.InterestPayment = interest_payment;
                this.PrincipalPayment = principal_payment;
                this.DebtRest = debt_rest;
            }
        }
    }
}
