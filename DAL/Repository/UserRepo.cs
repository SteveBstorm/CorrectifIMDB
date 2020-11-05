using ADOLibrary;
using DAL.Interface;
using DAL.Models;
using DAL.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public class UserRepo : BaseRepository, IUserRepository<User>
    {
        
        public UserRepo(): base()
        {
           
        }

        public bool Delete(int Id)
        {
            Command cmd = new Command("DELETE FROM User WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<User> GetAll()
        {
            Command cmd = new Command("SELECT * FROM User");
            return _connection.ExecuteReader<User>(cmd, Converters.Convert);
        }

        public User GetOne(int Id)
        {
            Command cmd = new Command("SELECT * FROM User WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader<User>(cmd, Converters.Convert).FirstOrDefault();
        }

        public void Insert(User u)
        {
            string query = "INSERT INTO User VALUES(@email, @password, @firstName, @lastName, @birthDate)";
            Command cmd = new Command(query);
            cmd.AddParameter("email", u.Email);
            cmd.AddParameter("password", u.Password);
            cmd.AddParameter("firstName", u.FirstName);
            cmd.AddParameter("lastName", u.LastName);
            cmd.AddParameter("birthDate", u.BirthDate);

            _connection.ExecuteNonQuery(cmd);
        }

        public void Update(User u)
        {
            string query = "UPDATE User SET Email = @email, Password = @password, FirstName = @firstName, LastName = @lastName, BirthDate = @birthDate" +
                " WHERE Id = @Id";
            Command cmd = new Command(query);
            cmd.AddParameter("email", u.Email);
            cmd.AddParameter("password", u.Password);
            cmd.AddParameter("firstName", u.FirstName);
            cmd.AddParameter("lastName", u.LastName);
            cmd.AddParameter("birthDate", u.BirthDate);
            cmd.AddParameter("Id", u.Id);

            _connection.ExecuteNonQuery(cmd);
        }
    }
}
