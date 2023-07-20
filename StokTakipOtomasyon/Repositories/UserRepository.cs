using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using StokTakipOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace StokTakipOtomasyon.Repositories
{
    public class userRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using(var command=new SqlCommand())
            {
                SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-B20RK80B\\SQLEXPRESS;Initial Catalog=uyeBilgileri;User ID=sa;Password=1;Integrated Security=True;");
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [User] where username=@username and [password]=@password";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = credential.UserName;  
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value =credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }

            return validUser; 
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            
                UserModel user=null;
                using (var connection = GetConnection())
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "select *from [User] where username=@username";
                    command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new UserModel()
                            {
                                Id = reader[0].ToString(),
                                Username = reader[1].ToString(),
                                Password = string.Empty,
                                Name = reader[3].ToString(),
                                LastName = reader[4].ToString(),
                                Email = reader[5].ToString(),
                            };
                        }
                    }  
                }
                return user;          
        }

        public void Remove(int id)
        {
           
        }
    }
}
