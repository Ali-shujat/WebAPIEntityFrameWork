using System;
using System.Collections.Generic;

namespace ApiEntityFW.Models
{
    public partial class Transactions
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public decimal OldBalance { get; set; }
        public decimal NewBalance { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? DateTime { get; set; }

        public virtual Accounts Account { get; set; }
    }
}
