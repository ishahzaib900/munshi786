﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Munshi786.Models
{
    public class OtherExpense
    {
        public int id { get; set; }

        public int appartment_id { get; set; }

        public string expense_name { get; set; }

        public bool status { get; set; }

        public DateTime month { get; set; }

        public decimal amount { get; set; }

        public int payment_by_id { get; set; }

        public string description { get; set; }
    }
}