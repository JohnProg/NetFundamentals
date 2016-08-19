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
        private static RegionMapper dapperRepository = new RegionMapper();
        private static RegionRepository efRepository = new RegionRepository();
        static void Main(string[] args)
        {
            /** Dapper  **/
            //var newRegion = new Region
            //{                
            //    RegionDescription="Dapper Example"
            //};
            //var watch = System.Diagnostics.Stopwatch.StartNew();            
            //CreateRegionDapper(newRegion);
            //watch.Stop();
            //Console.WriteLine($"Dapper {FormattedExecutionTime(watch.ElapsedMilliseconds)}");
            ////UpdateRegionDapper(5, "Lo que queremos que aparezca");
            //watch.Reset();

            
            Console.WriteLine("Dapper Get List");
            //watch.Start();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var regionDapperList = dapperRepository.RegionList();
            watch.Stop();
            Console.WriteLine($"Total Elements:  {regionDapperList.Count()}");
            PrintRegion(regionDapperList);

            Console.WriteLine($"Dapper time {FormattedExecutionTime(watch.ElapsedMilliseconds)}");
            watch.Reset();

            /** Entity Framework  **/
            //newRegion.RegionDescription = "EF Example";
            //watch.Start();            
            //CreateRegionEF(newRegion);
            //watch.Stop();
            //Console.WriteLine($"EF {FormattedExecutionTime(watch.ElapsedMilliseconds)}");

            
            Console.WriteLine("Entity Framework Get List");
            watch.Start();
            var regionEFList = efRepository.RegionList();
            watch.Stop();
            Console.WriteLine($"Total Elements:  {regionDapperList.Count()}");
            Console.WriteLine($"Entity Time {FormattedExecutionTime(watch.ElapsedMilliseconds)}");
            PrintRegion(regionDapperList);

            Console.ReadKey();
        }

        static void PrintRegion(IEnumerable<Region> regionList)
        {
            foreach (var region in regionList)
            {
                Console.WriteLine($"Id: {region.RegionID} - Description: {region.RegionDescription}");
            }
        }

        static string FormattedExecutionTime(long milliseconds)
        {
            return $"Execution time: {milliseconds} milliseconds";
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
            if(dapperRepository.Create(region)>0)            
                Console.WriteLine("The Region is created");
            else
                Console.WriteLine("Something is wrong.");
        }

        static void UpdateRegionDapper(int id, string change)
        {
            var region = dapperRepository.GetById(id);
            if (region == null) return;

            region.RegionDescription = change;
            if(dapperRepository.Update(region))
                Console.WriteLine("The Region is updated");
            else
                Console.WriteLine("Something is wrong.");
        }

        #endregion
    }
}
