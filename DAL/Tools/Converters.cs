using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Tools
{
    public static class Converters
    {
        public static User Convert(this SqlDataReader reader)
        {
            return new User
            {
                Id = (int)reader["Id"],
                Email = reader["Email"].ToString(),
                Password = reader["Password"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                BirthDate = (DateTime)reader["BirthDate"],
                IsActive = (bool)reader["IsActive"],
                IsAdmin = (bool)reader["IsAdmin"]
            };
        }
    }
}
