using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Munshi786.Munshi_Models
{
    public class Transactions
    {
        public int id { get; set; }

        public int from { get; set; }

        public int to { get; set; }

        public decimal payment { get; set; }

        public DateTime date { get; set; }

        public string description { get; set; }
    }
}