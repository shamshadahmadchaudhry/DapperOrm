using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperOrmDemo.Repository
{
    public class dbCon
    {
        private string connectionString;

        public dbCon()
        {
            connectionString = @"Server=DESKTOP-POJ0U4S;Database=DAPPERCRUDDB;Trusted_Connection=True;";
            //connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    }
}
