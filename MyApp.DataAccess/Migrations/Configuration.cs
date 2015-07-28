using System;
using System.Linq;
using MyApp.DataAccess.Models;

namespace MyApp.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MyAppContext>
    {
        private int MaxUsers = 100;

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyAppContext context)
        {

            int currentUserCount = context.Users.Count();
            if (currentUserCount < MaxUsers)
            {
                for (int i = 0; i < MaxUsers - currentUserCount; i++)
                {
                    var person = Mortware.DataFactory.PersonGenerator.Person();
                    context.Users.Add(new UserEntity()
                    {
                        Id = Guid.NewGuid().ToString("N"),
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        DisplayName = string.Format("{0} {1}", person.FirstName, person.LastName),
                        DateOfBirth = person.DateOfBirth,
                    });
                }    
            }
        }
    }
}
