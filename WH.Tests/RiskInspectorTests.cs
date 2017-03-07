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
        public void Should_identify_customers_winning_more_than_60_percent_of_settled_bets()
        {
            // Arrange          
            var testCustomers = TestData.CustomersThatWinMoreThan60PercentOfBets();

            // Act
            var actualCustomers = _processor.CustomersWithUnusualWinRate(testCustomers, 60);

            // Assert
            Assert.IsTrue(actualCustomers.Count == 1);
            Assert.IsTrue(actualCustomers[0].Id == 1);
        }

        [Test]
        public void Should_identify_Bets_With_High_Amounts_To_Win()
        {
            // Arrange            
            var testCustomers = TestData.CustomersWithHighBets();

            // Act
            var bets = _processor.CustomersWithHighBets(testCustomers, 1000);

            // Assert
            Assert.IsTrue(bets.Count == 1);
            Assert.IsTrue(bets[0].BetAmount == 2000);
        }

        [Test]
        public void Should_identify_bets_with_unusual_stakes()
        {
            // Arrange            
            var testCustomers = TestData.CustomersWithHighStakes10();

            // Act
            var bets = _processor.BetsWithUnusualStakes(testCustomers, 10);

            // Assert
            Assert.AreEqual(bets.Count, 2);
        }

        [Test]
        public void Should_identify_bets_with_very_unusual_stakes()
        {
            // Arrange            
            var testCustomers = TestData.CustomersWithHighStakes30();

            // Act
            var bets = _processor.BetsWithUnusualStakes(testCustomers, 30);

            // Assert
            Assert.AreEqual(bets.Count, 2);
        }
    }
}