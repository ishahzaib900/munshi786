using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Munshi786.Models
{
    public class Property
    {
        public int id { get; set; }

        public string area { get; set; }

        public string building { get; set; }

        public DateTime contract_start_date { get; set; }

        public DateTime contract_end_date { get; set; }

        public decimal rent { get; set; }

        public decimal deposite { get; set; }

        public decimal commission { get; set; }

        public int no_beds { get; set; }

        public int no_cheques { get; set; }

        public int appartment_no { get; set; }

        public int dewa_no { get; set; }

        public int du_no { get; set; }

        public int empower_no { get; set; }
    }
}