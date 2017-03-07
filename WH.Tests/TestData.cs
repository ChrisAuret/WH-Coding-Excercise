using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH.Domain;

namespace WH.Tests
{
    public class TestData
    {
        public static List<Customer> CustomersThatWinMoreThan60PercentOfBets()
        {
            var testCustomers = new List<Customer>();

            // Win
            var settledBet1 = new Bet()
            {
                CustomerId = 1,
                EventId = 1,
                ParticipantId = 1,
                Stake = 1,
                BetAmount = 5
            };

            // Win
            var settledBet2 = new Bet
            {
                CustomerId = 1,
                EventId = 1,
                ParticipantId = 1,
                Stake = 1,
                BetAmount = 5
            };

            // Lose
            var settledBet3 = new Bet
            {
                CustomerId = 1,
                EventId = 1,
                ParticipantId = 1,
                Stake = 1,
                BetAmount = 0
            };

            // 2 Win, 1 Lose = 66% Winning Bets
            var settledBets = new List<Bet> { settledBet1, settledBet2, settledBet3 };

            testCustomers.Add(new Customer
            {
                Id = 1,
                Settled = settledBets
            });

            return testCustomers;
        }

        public static List<Customer> CustomersWithHighBets()
        {
            var customers = new List<Customer>();

            var customer = new Customer
            {
                Id = 1,
                Unsettled = new List<Bet>
                {
                    // ToWin amount > 1000
                    new Bet
                    {
                        CustomerId = 1,
                        EventId = 1,
                        ParticipantId = 1,
                        Stake = 20,
                        BetAmount = 2000
                    },
                    // ToWin amount < 1000
                    new Bet
                    {
                        CustomerId = 1,
                        EventId = 1,
                        ParticipantId = 1,
                        Stake = 20,
                        BetAmount = 200
                    }
                }
            };

            customers.Add(customer);

            return customers;
        }
    }
}