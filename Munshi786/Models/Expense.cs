using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Munshi786.Models
{
    public class Expense
    {
        public int id { get; set; }

        public int appartment_id { get; set; }

        public int expense_type_id { get; set; }

        public decimal expense { get; set; }

        public string payment_to { get; set; }

        public int payment_by_id { get; set; }

        public string description { get; set; }

        public int added_by { get; set; }

        public int status { get; set; }

        public DateTime added_date { get; set; }

        public DateTime expence_date { get; set; }

    }
}