using System;

namespace Core.DomainModel.UserAggregate.Entities
{
    public sealed class User
    {
        private User()
        { }

        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public DateTime CreationDate { get; private set; }

        public User Create(string firstName, string lastName, string username, string password)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                Password = password,
                CreationDate = DateTime.UtcNow,
            };
        }
    }
}
