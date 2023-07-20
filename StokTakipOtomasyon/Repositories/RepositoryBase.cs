using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Amazon.Auth.AccessControlPolicy;
using System.Windows.Markup;

namespace StokTakipOtomasyon.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            _connectionString = "Data Source=LAPTOP-B20RK80B\\SQLEXPRESS;Initial Catalog=uyeBilgileri;User ID=sa;Password=1;Integrated Security=True;";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

    }
}
