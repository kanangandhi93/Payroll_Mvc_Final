using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Payroll_Mvc.Models
{
    public class PayrollContext : DbContext
    {
        public DbSet<country> Country { get; set; }
    }
}