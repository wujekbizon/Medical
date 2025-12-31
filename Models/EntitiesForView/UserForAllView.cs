
using System;

namespace Medical.Models.EntitiesForView
{
    public class UserForAllView
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public UserForAllView()
        {
        }
    }
}
