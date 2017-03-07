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
        public List<Customer> CustomersWithUnusualWinRate(List<Customer> customers, int threshold)
        {
            var unusualCustomers = new List<Customer>();

            foreach (var customer in customers)
            {
                var allWins = (double)customer.Settled.Where(x => x.BetAmount > 0).ToList().Count;
                var allBets = (double)customer.Settled.Count;
                var betAverage = allWins / allBets * 100.0;

                if (betAverage > threshold)
                {
                    unusualCustomers.Add(customer);
                }
            }

            return unusualCustomers;
        }

        public List<Bet> CustomersWithHighBets(List<Customer> customers, int threshold)
        {
            var highBets = new List<Bet>();

            foreach (var customer in customers)
            {
                foreach (var bet in customer.Unsettled)
                {
                    if (bet.BetAmount > threshold)
                    {
                        highBets.Add(bet);
                    }
                }
            }

            return highBets;
        }

        public List<Bet> BetsWithUnusualStakes(List<Customer> customers, int threshold)
        {
            var bets = new List<Bet>();

            foreach (var customer in customers)
            {
                foreach (var bet in customer.Unsettled)
                {
                    if (bet.Stake > customer.SettledAverageStake * threshold)
                    {
                        bets.Add(bet);
                    }
                }
            }

            return bets;
        }

        public List<Bet> BetsWithVeryUnusualStakes(List<Customer> customers, int threshold)
        {
            var bets = new List<Bet>();

            foreach (var customer in customers)
            {
                foreach (var bet in customer.Unsettled)
                {
                    if (bet.Stake > customer.SettledAverageStake * threshold)
                    {
                        bets.Add(bet);
                    }
                }
            }

            return bets;
        }
    }
}