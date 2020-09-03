using System;
using System.Collections.Generic;

namespace ApiEntityFW.Models
{
    public partial class AccountTypes
    {
        public AccountTypes()
        {
            Accounts = new HashSet<Accounts>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Accounts> Accounts { get; set; }
    }
}
