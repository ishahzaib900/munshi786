using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Munshi786.Models
{
    public class Transactions
    {
        public int id { get; set; }

        public int from_id { get; set; }

        public int to_id { get; set; }

        public decimal payment { get; set; }

        public DateTime date { get; set; }

        public string description { get; set; }
    }
}