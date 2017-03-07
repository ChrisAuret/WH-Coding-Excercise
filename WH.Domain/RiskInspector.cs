using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH.Domain.Interfaces;

namespace WH.Domain
{
    public class RiskInspector : IRiskInspector
    {
        public List<Customer> CustomersWithUnusualWinRate(List<Customer> customers)
        {
            var unusualCustomers = new List<Customer>();

            foreach (var customer in customers)
            {
                var allWins = (double)customer.Settled.Where(x => x.BetAmount > 0).ToList().Count;
                var allBets = (double)customer.Settled.Count;
                var betAverage = allWins / allBets * 100.0;

                if (betAverage > 60)
                {
                    unusualCustomers.Add(customer);
                }
            }

            return unusualCustomers;
        }
    }
}