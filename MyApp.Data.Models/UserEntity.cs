using System;
using MyApp.Repository;

namespace MyApp.DataAccess.Models
{
    public class UserEntity : IEntity<string>
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
