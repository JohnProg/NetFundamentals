using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkRepository
{
    public class NorthWindContext : DbContext
    {
        public NorthWindContext() : base("NetFundamentals")
        {
        }

        public DbSet<Region> Regions { get; set; }
    }
}
