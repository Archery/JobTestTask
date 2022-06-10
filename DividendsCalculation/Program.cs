using System;
using Mew;

namespace DividendsCalculation {
    internal class Program {
        private static void Main(string[] args) {
            AppLogAndEventHelper.Instance.AddLog("DividendsCalculation.log");
            AppLogAndEventHelper.Instance.AddReceiver(Recievers.WriteEventToConsole);

            try {
                var dm = new DividendsManager();
                DateTime calculation_date;
                if (args.Length >= 5) {
                    dm.AgreementDate = DateTime.Parse(args[0]);
                    calculation_date = DateTime.Parse(args[1]);
                    dm.InvestedSum = double.Parse(args[3]);
                    dm.InterestRate = double.Parse(args[4]);
                    dm.InvestmentDuration = int.Parse(args[5]);
                }
                else {
                    Console.Write("Enter Agreement date = ");
                    dm.AgreementDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter Calculation date = ");
                    calculation_date = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter X = ");
                    dm.InvestedSum = double.Parse(Console.ReadLine());
                    Console.Write("Enter R = ");
                    dm.InterestRate = double.Parse(Console.ReadLine());
                    Console.Write("Enter N = ");
                    dm.InvestmentDuration = int.Parse(Console.ReadLine());
                }

                AppLogAndEventHelper.Instance.RaiseEvent(EventType.Result, dm.CalculateTotalInterest(calculation_date));
            }
            catch (Exception ex) {
                AppLogAndEventHelper.Instance.RaiseError(ex);
            }
            finally {
                AppLogAndEventHelper.Instance.Dispose();
            }
        }
    }
}