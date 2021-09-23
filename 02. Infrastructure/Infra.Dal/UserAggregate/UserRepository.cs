using Core.DomainModel.UserAggregate.Data;
using Core.DomainModel.UserAggregate.Entities;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Dal.UserAggregate
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly IMemoryCache _cache;
        private readonly AppDbContext _dbContext;
        const string CACHE_NAME = "users";

        public UserRepository(IMemoryCache cache, AppDbContext dbContext)
        {
            _cache = cache;
            _dbContext = dbContext;
        }

        public User Create(User user)
        {
            if (Exists(user))
            {
                throw new Exception($"A user with this username '{user.Username}' exists.");
            }

            var users = _cache.Get<List<User>>(CACHE_NAME);
            AddToCache(users, user);

            var userEntry = _dbContext.Add(user);
            return userEntry.Entity;
        }

        public IEnumerable<User> Search(string query = null)
        {
            var userExpression = GetUserExpression(query);
            var users = _cache.Get<List<User>>(CACHE_NAME);
            if (users is not null && users.Any())
            {
                return users.Where(userExpression);
            }

            var dbUsers = _dbContext.Users.ToList();
            _cache.Set(CACHE_NAME, dbUsers);

            return dbUsers.Where(userExpression);
        }

        public User GetById(Guid id)
        {
            var user = Search().SingleOrDefault(u => u.Id == id);

            if (user is null)
            {
                throw new Exception($"There is NO user with this id({id}).");
            }

            return user;
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            var user = Search().SingleOrDefault(u =>
                u.Username == username &&
                u.Password == password
            );

            if (user is null)
            {
                throw new Exception($"There is NO user with this credentials.");
            }

            return user;
        }

        public bool Exists(User user)
        {
            if (user is null)
            {
                throw new Exception("User can not be null.");
            }

            return Search().Any(u => u.Username == user.Username);
        }

        public bool Exists(Guid userId)
        {
            return Search().Any(u => u.Id == userId);
        }

        private static Func<User, bool> GetUserExpression(string searchQuery)
        {
            var lQuery = searchQuery?.ToLower();
            return searchQuery is null ?
                u => true :
                u => u.FirstName.ToLower().Contains(lQuery) ||
                     u.LastName.ToLower().Contains(lQuery) ||
                     u.Id.ToString().ToLower().Contains(lQuery) ||
                     u.Username.ToLower().Contains(lQuery);
        }

        private void AddToCache(IList<User> users, User user)
        {
            users?.Add(user);
            _cache.Set(CACHE_NAME, users);
        }
    }
}
