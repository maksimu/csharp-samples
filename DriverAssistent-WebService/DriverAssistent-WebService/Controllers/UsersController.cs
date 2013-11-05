using DriverAssistent_WebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DriverAssistent_WebService.Services;

namespace DriverAssistent_WebService.Controllers
{
    public class UsersController : ApiController
    {
        UserRepository userRepository;

        public UsersController()
        {
            this.userRepository = new UserRepository(); 
        }

        
        /**
         * Returns all users in the database
         **/
        public List<User> Get()
        {
            return userRepository.getAllUsers();
        }

        /**
         * 
         * URL: [host]/api/users/1
         **/
        public User GetUser(long id)
        {
            User foundUser = userRepository.find(id);

            if (foundUser == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound); 
            }

            return foundUser;
        }

        /**
         * URL: [host]/api/users?userName=maksim&password=password
         **/
        public User GetUserByUserNameAndPassword(string userName, string password)
        {
            User foundUser = userRepository.authenticateUser(userName, password);

            if (foundUser == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return foundUser;
        }
    }
}
