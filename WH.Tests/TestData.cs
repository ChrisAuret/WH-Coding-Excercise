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
            var testCustomers = new List<Customer>()
            {
                new Customer()
                {
                    Id = 1,
                    // 2 Win, 1 Lose = 66% Winning Bets
                    Settled = new List<Bet>
                    {
                        new Bet()   // Win
                        {
                            CustomerId = 1,
                            EventId = 1,
                            ParticipantId = 1,
                            Stake = 1,
                            BetAmount = 5
                        },
                        new Bet // Win
                        {
                            CustomerId = 1,
                            EventId = 1,
                            ParticipantId = 1,
                            Stake = 1,
                            BetAmount = 5
                        },
                        new Bet // Lose
                        {
                            CustomerId = 1,
                            EventId = 1,
                            ParticipantId = 1,
                            Stake = 1,
                            BetAmount = 0
                        }
                    }
                }
            };

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

        public static List<Customer> CustomersWithHighStakes10()
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Settled = new List<Bet>
                    {
                        new Bet
                        {
                            CustomerId = 1,
                            EventId = 1,
                            ParticipantId = 1,
                            Stake = 1,
                            BetAmount = 3
                        }
                    },
                    Unsettled = new List<Bet>()
                    {
                        new Bet
                        {
                            CustomerId = 1,
                            EventId = 1,
                            ParticipantId = 1,
                            Stake = 11,
                            BetAmount = 100
                        },
                        new Bet
                        {
                            CustomerId = 1,
                            EventId = 1,
                            ParticipantId = 1,
                            Stake = 10,
                            BetAmount = 30
                        },                    
                        new Bet
                        {
                            CustomerId = 1,
                            EventId = 1,
                            ParticipantId = 1,
                            Stake = 20,
                            BetAmount = 200
                        }
                    }
                }
            };

            return customers;
        }

        public static List<Customer> CustomersWithHighStakes30()
        {
            // Bets where the stake is more than 30 times higher than that customer’s average bet in their betting history should be highlighted as highly unusual

            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Settled = new List<Bet>
                    {
                        // Average bet history of 1
                        new Bet()
                        {
                            CustomerId = 1,
                            EventId = 1,
                            ParticipantId = 1,
                            Stake = 1,
                            BetAmount = 2
                        }
                    },
                    Unsettled = new List<Bet>
                    {
                        new Bet // Stake MORE than 30x greater than history average.
                        {
                            CustomerId = 1,
                            EventId = 1,
                            ParticipantId = 1,
                            Stake = 31,
                            BetAmount = 100
                        },
                        new Bet // Stake MORE than 30x greater than history average.
                        {
                            CustomerId = 1,
                            EventId = 1,
                            ParticipantId = 1,
                            Stake = 32,
                            BetAmount = 30
                        },
                        new Bet // Stake LESS than 30x the history average.
                        {
                            CustomerId = 1,
                            EventId = 1,
                            ParticipantId = 1,
                            Stake = 20,
                            BetAmount = 200
                        }
                    }
                }
            };

            return customers;
        }
    }
}