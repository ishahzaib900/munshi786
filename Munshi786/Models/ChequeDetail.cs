using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Munshi786.Models
{
    public class ChequeDetail
    {
        public int id { get; set; }

        public int cheque_no { get; set; }

        public DateTime cheque_date { get; set; }

        public DateTime cheque_till { get; set; }

        public decimal cheque_amount { get; set; }

        public int cheque_by_id { get; set; }

        public int appartment_id { get; set; }
    }
}