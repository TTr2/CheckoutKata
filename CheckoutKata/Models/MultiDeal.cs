using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Models
{
    /// <summary>
    /// Represents the terms of a special offer, which can be assigned to a product.
    /// </summary>
    class MultiDeal
    {
        /// <summary>
        /// Default constructor for an invalid MultiDeal.
        /// </summary>
        public MultiDeal()
        {
            this.Units = 0;
            this.MultiDealPrice = 0;
            this.ValidFromDate = DateTime.MinValue;
            this.ValidBeforeDate = DateTime.MinValue;
        }

        /// <summary>
        /// Constructor for creating a valid MultiDeal.
        /// </summary>
        /// <param name="units"><see cref="MultiDeal.Units"/></param>
        /// <param name="multiDealPrice"><see cref="MultiDeal.MultiDealPrice"/></param>
        /// <param name="validFromDate"><see cref="MultiDeal.ValidFromDate"/></param>
        /// <param name="validBeforeDate"><see cref="MultiDeal.ValidBeforeDate"/></param>
        public MultiDeal(int units, int multiDealPrice, DateTime validFromDate, DateTime validBeforeDate)
        {
            this.Units = units;
            this.MultiDealPrice = multiDealPrice;
            this.ValidFromDate = validFromDate;
            this.ValidBeforeDate = validBeforeDate;
        }

        /// <summary>
        /// The number of units required for a valid multi deal purchase.
        /// </summary>
        internal int Units { get; set; }

        /// <summary>
        /// The total price of a valid multi deal purchase.
        /// </summary>
        internal int MultiDealPrice { get; set; }

        /// <summary>
        /// The date from which this multi deal is valid.
        /// </summary>
        internal DateTime ValidFromDate { get; set; }

        /// <summary>
        /// The date until this multi deal is valid (invalid if date equals this time).
        /// </summary>
        internal DateTime ValidBeforeDate { get; set; }
    }
}
