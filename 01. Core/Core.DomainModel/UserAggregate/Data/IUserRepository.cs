using Core.DomainModel.UserAggregate.Entities;
using System;
using System.Collections.Generic;

namespace Core.DomainModel.UserAggregate.Data
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetById(Guid id);
        User GetByUsernameAndPassword(string username, string password);
        IEnumerable<User> Search(string query = null);
        bool Exists(Guid userId);
        bool Exists(User user);
    }
}
