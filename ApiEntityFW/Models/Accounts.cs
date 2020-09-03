using System;
using System.Collections.Generic;

namespace ApiEntityFW.Models
{
    public partial class Accounts
    {
        public Accounts()
        {
            Transactions = new HashSet<Transactions>();
        }

        public int Id { get; set; }
        public int? AccountTypeId { get; set; }
        public decimal Balance { get; set; }
        public int? ClientId { get; set; }

        public virtual AccountTypes AccountType { get; set; }
        public virtual Clients Client { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
