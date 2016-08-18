using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions;
using System.Configuration;
using DapperExtensions.Mapper;

namespace DapperRepository
{
    public class RegionMapper : ClassMapper<Region>
    {
        private string connectionString;

        public RegionMapper()
        {
            connectionString = ConfigurationManager.ConnectionStrings["NetFundamentals"].ToString();            
        }

        public int Create(Region model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Insert(model);
                connection.Close();
                return result;
            }
        }

        public bool Update(Region model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Update(model);
                connection.Close();
                return result;
            }
        }

        public Region GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Get<Region>(id);
                connection.Close();
                return result;
            }
        }

    }
}
