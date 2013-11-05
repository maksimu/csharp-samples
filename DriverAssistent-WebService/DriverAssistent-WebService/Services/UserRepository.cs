using DriverAssistent_WebService.Models;
using DriverAssistent_WebService.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverAssistent_WebService.Services
{
    public class UserRepository
    {
        public User save(User u)
        {
            var db = new UserContext();
            u.password = PasswordHash.CreateHash(u.password); // Hashing password
            User savedUser = db.Users.Add(u);

            return savedUser;
        }

        public User find(long id)
        {
            var db = new UserContext();
            User foundUser = db.Users.Find(id);

            return foundUser;
        }

        public Boolean remove(User u)
        {
            var db = new UserContext();
            User removedUser = db.Users.Remove(u);

            return true;
        }


        public List<User> getAllUsers()
        {

            var db = new UserContext();

            var query = from u in db.Users orderby u.Id select u;
            //var query = from u in db.Users orderby u.Id select new User() { Id = u.Id, firstName = u.firstName, lastName = u.lastName, password = u.password, userName = u.userName };

            return query.ToList();
        }

        public User authenticateUser(string userName, string password)
        {

            var db = new UserContext();
            var query = from u in db.Users where u.userName == userName select u;
            User user = query.Single();

            bool isValidPassword = PasswordHash.ValidatePassword(password, user.password);

            if (!isValidPassword)
            {
                throw new UnauthorizedAccessException("Not authorized. Please check your password");
            }
            
            return user;
        }
    }
}