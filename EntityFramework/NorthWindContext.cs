using Models;
using System.Data.Entity;

namespace EntityFrameworkRepository
{
    public class NorthWindContext : DbContext
    {
        public NorthWindContext() : base("NetFundamentals") //base("NetFundamentalsAventure")
        {            
        }

        public DbSet<Region> Regions { get; set; }
    }
}
