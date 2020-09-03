using System;
using System.Collections.Generic;

namespace ApiEntityFW.Models
{
    public partial class Clients
    {
        public Clients()
        {
            Accounts = new HashSet<Accounts>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Accounts> Accounts { get; set; }
    }
}
