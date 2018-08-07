using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Munshi786.Models
{
    public class MunshiDBContext : DbContext
    {
        public DbSet<Property> Properties { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<ExpenseType> ExpenseTypes { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<ChequeDetail> ChequeDetails { get; set; }
    }
}