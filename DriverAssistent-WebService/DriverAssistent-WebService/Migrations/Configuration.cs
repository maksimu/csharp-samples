namespace DriverAssistent_WebService.Migrations
{
    using DriverAssistent_WebService.Models;
    using DriverAssistent_WebService.Security;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DriverAssistent_WebService.Models.UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DriverAssistent_WebService.Models.UserContext context)
        {
            // INIT USERS
            context.Users.AddOrUpdate(new User[] {
                new User() {
                    userName = "maksim", 
                    firstName = "Maksim", 
                    lastName = "Ustinov", 
                    password = PasswordHash.CreateHash("password"),
                    role = new UserRole{Name="admin"}
                },
                new User() {
                    userName = "john", 
                    firstName = "John", 
                    lastName = "Smith", 
                    password = PasswordHash.CreateHash("password"),
                    role = new UserRole{Name="user"}
                }
            });
         
        }
    }
}
