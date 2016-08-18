using EntityFrameworkRepository;
using DapperRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class Program
    {
        private static RegionMapper repository = new RegionMapper();
        private static RegionRepository efRepository = new RegionRepository();
        static void Main(string[] args)
        {
            /** Dapper  **/
            var newRegion = new Region
            {                
                RegionDescription="Dapper Example"
            };
            var watch = System.Diagnostics.Stopwatch.StartNew();            
            CreateRegionDapper(newRegion);
            watch.Stop();
            Console.WriteLine($"Dapper {FormattedExecutionTime(watch.ElapsedMilliseconds)}");
            watch.Reset();

            newRegion.RegionDescription = "EF Example";
            watch.Start();            
            CreateRegionEF(newRegion);
            watch.Stop();
            Console.WriteLine($"EF {FormattedExecutionTime(watch.ElapsedMilliseconds)}");

            //UpdateRegionDapper(5, "Lo que queremos que aparezca");
            Console.ReadKey();
        }

        static string FormattedExecutionTime(long milliseconds)
        {
            return $"Execution time: {milliseconds:F}";
        }

        #region EntityFramework
        static void CreateRegionEF(Region region)
        {
            if (efRepository.Create(region) > 0)
                Console.WriteLine("The Region is created");
            else
                Console.WriteLine("Something is wrong.");
        }
        #endregion

        #region Dapper
        static void CreateRegionDapper(Region region)
        {
            if(repository.Create(region)>0)            
                Console.WriteLine("The Region is created");
            else
                Console.WriteLine("Something is wrong.");
        }

        static void UpdateRegionDapper(int id, string change)
        {
            var region = repository.GetById(id);
            if (region == null) return;

            region.RegionDescription = change;
            if(repository.Update(region))
                Console.WriteLine("The Region is updated");
            else
                Console.WriteLine("Something is wrong.");
        }

        #endregion
    }
}
