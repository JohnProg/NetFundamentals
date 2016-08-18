using Models;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace EntityFrameworkRepository
{
    public class RegionRepository
    {
        public int Create(Region region)
        {
            using (var dbContext = new NorthWindContext())
            {
                dbContext.Entry(region).State = EntityState.Added;
                return dbContext.SaveChanges();
            }
        }

        public int Update(Region region)
        {
            using (var dbContext = new NorthWindContext())
            {
                dbContext.Entry(region).State = EntityState.Modified;
                return dbContext.SaveChanges();
            }
        }

        public int Delete(Region region)
        {
            using (var dbContext = new NorthWindContext())
            {
                dbContext.Entry(region).State = EntityState.Deleted;
                return dbContext.SaveChanges();
            }
        }

        public IEnumerable<Region> RegionList()
        {
            using (var dbContext = new NorthWindContext())
            {                
                return dbContext.Regions;
            }
        }

        public Region GetById(int id)
        {
            using (var dbContext = new NorthWindContext())
            {
                return dbContext.Regions.FirstOrDefault(x => x.RegionID == id);
            }
        }
    }
}
