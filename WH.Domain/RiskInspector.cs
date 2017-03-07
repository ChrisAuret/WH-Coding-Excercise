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
        /// <summary>
        /// Identify cusotmers that win more than 60% of bets
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public List<Customer> CustomersWithUnusualWinRate(List<Customer> customers, int threshold)
        {
            return (
                from customer in customers
                let allWins = (double)customer.Settled.Where(x => x.BetAmount > 0).ToList().Count
                let allBets = (double)customer.Settled.Count
                let betAverage = allWins / allBets * 100.0
                where betAverage > threshold
                select customer
            ).ToList();
        }
        /// <summary>
        /// Identify customers that are winning more than $1000
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public List<Bet> CustomersWithHighBets(List<Customer> customers, int threshold)
        {
            return (
                from customer in customers
                from bet in customer.Unsettled
                where bet.BetAmount > threshold
                select bet
            ).ToList();
        }

        /// <summary>
        /// Identify customers that are betting higher than 10x their average
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public List<Bet> BetsWithUnusualStakes(List<Customer> customers, int threshold)
        {
            return (
                from customer in customers
                from bet in customer.Unsettled
                where bet.Stake > customer.SettledAverageStake * threshold
                select bet
            ).ToList();
        }

        /// <summary>
        /// Identify customers that are betting higher than 30x their average
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public List<Bet> BetsWithVeryUnusualStakes(List<Customer> customers, int threshold)
        {
            return (
                from customer in customers
                from bet in customer.Unsettled
                where bet.Stake > customer.SettledAverageStake * threshold
                select bet
            ).ToList();
        }
    }
}