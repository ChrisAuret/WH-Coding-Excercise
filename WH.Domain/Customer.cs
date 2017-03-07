using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH.Domain
{
    public class Customer
    {
        /// <summary>
        /// Customer identifier
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Customers settled bets
        /// </summary>
        public List<Bet> Settled { get; set; }

        /// <summary>
        /// Customers Unsettled bets
        /// </summary>
        public List<Bet> Unsettled { get; set; }
    }
}