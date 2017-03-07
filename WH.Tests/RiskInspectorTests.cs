using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WH.Domain;
using WH.Domain.Interfaces;

namespace WH.Tests
{
    [TestFixture]
    public class RiskInspectorTests
    {
        private readonly IRiskInspector _processor = new RiskInspector();

        [Test]
        public void Should_identify_high_winning_customers_greater_than_60()
        {
            // Arrange          
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

            var settledBets = new List<Bet> { settledBet1, settledBet2, settledBet3 };

            testCustomers.Add(new Customer
            {
                Id = 1,
                Settled = settledBets
            });

            // Act
            var actualCustomers = _processor.CustomersWithUnusualWinRate(testCustomers);

            // Assert
            Assert.IsTrue(actualCustomers.Count == 1);
            Assert.IsTrue(actualCustomers[0].Id == 1);
        }
    }
}
