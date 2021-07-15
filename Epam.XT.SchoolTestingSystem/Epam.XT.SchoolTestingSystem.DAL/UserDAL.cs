using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.XT.SchoolTestingSystem.Common.Entities;
using Epam.XT.SchoolTestingSystem.DAL.Interfaces;

namespace Epam.XT.SchoolTestingSystem.DAL
{
    public class UserDAL : IUserDAL
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

         
        public bool AddUser(User user)
        {
            throw new NotImplementedException();
        }



        public User GetUserByLogin(string login)
        {
            var _connection = new SqlConnection(_connectionString);
            using (_connection)
            {
                User user = null;
                var stProc = "TestingSystem_GetUserByLogin";
                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@login", login);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    user = new User(reader["Name"].ToString(), reader["Surname"].ToString(), reader["Login"].ToString());
                }
                return user;
            }
        }

        public string[] GetUserRoles(string login)
        {
            var _connection = new SqlConnection(_connectionString);
            List<string> returnableArrOfString = new List<string>();
            using (_connection)
            {
                var stProc = "TestingSystem_GetUserRoles";
                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@login", login);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        returnableArrOfString.Add(reader[0].ToString());
                    }
                    return returnableArrOfString.ToArray();
                }
                else
                {
                    return new string[0];
                }

            }
        }

        public IEnumerable<Test> GetUserTests(string login)
        {
            throw new NotImplementedException();
        }

        public bool IsUserExist(string login, string pass)
        {
            var _connection = new SqlConnection(_connectionString);
            using (_connection)
            {
                var stProc = "TestingSystem_IsUserExist";
                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@password", pass);
                _connection.Open();


                return (int)command.ExecuteScalar() == 1;

            }
        }

        public bool IsUserInRole(string login, string role)
        {
            var _connection = new SqlConnection(_connectionString);
            using (_connection)
            {
                var stProc = "TestingSystem_IsUserExist";
                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@role", role);
                _connection.Open();


                return (int)command.ExecuteScalar() == 1;

            }
        }
    }
}
