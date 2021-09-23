using System;

namespace Infra.ApplicationServices.Dtos
{
    public sealed class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
