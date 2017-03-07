using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH.Domain
{
    public class Bet
    {
        /// <summary>
        /// The Customer Identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// The Event Identifier
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// The Participant Identifier
        /// </summary>
        public int ParticipantId { get; set; }

        /// <summary>
        /// The dollar amount bet
        /// </summary>
        public decimal Stake { get; set; }

        /// <summary>
        /// Dollar amount bet that will be won if a bet is successful
        /// </summary>
        public decimal BetAmount { get; set; }
    }
}
