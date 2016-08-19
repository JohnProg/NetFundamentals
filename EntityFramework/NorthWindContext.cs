using Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EntityFrameworkRepository
{
    public class NorthWindContext : DbContext
    {
        public NorthWindContext() : base("NetFundamentals")
        {
            Database.SetInitializer<NorthWindContext>(null);
        }

        public DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
