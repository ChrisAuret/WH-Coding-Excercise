using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WH.Domain
{
    public class Customer
    {
        public Customer()
        {
            Settled = new List<Bet>();
            Unsettled = new List<Bet>();
        }

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

        /// <summary>
        /// Customers average stake of settled bets
        /// </summary>
        public decimal SettledAverageStake => Settled.Sum(x => x.Stake) / Settled.Count;

        /// <summary>
        /// Customers average stake of unsettled bets
        /// </summary>
        public decimal UnsettledAverageStake => Unsettled.Sum(x => x.Stake) / Unsettled.Count;

        public override bool Equals(object obj)
        {
            var item = obj as Customer;

            if (item == null)
            {
                return false;
            }

            return Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}