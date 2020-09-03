using System;
using System.Collections.Generic;

namespace ApiEntityFW.Models
{
    public partial class VClientBalances
    {
        public string Name { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
    }
}
