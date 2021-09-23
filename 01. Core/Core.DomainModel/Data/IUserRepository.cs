using Core.DomainModel.Entities;
using System;
using System.Collections.Generic;

namespace Core.DomainModel.Data
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetById(Guid id);
        IEnumerable<User> GetAll();
        User Remove(User user);
    }
}
