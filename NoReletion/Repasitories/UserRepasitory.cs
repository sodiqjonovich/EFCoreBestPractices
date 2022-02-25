using Microsoft.EntityFrameworkCore;
using NoReletion.Data;
using NoReletion.Entities;
using NoReletion.RepasitoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoReletion.Repasitories
{
    public class UserRepasitory : IUserRepasitory
    {
        /// <summary>
        /// When we work something with Database
        /// DBContext class is important for us
        /// Our AppDBContext class is inherited from DBContext
        /// </summary>
        private readonly AppDBContext _dbContext;

        /// <summary>
        /// We create contructor
        /// Because we impiment Dependency Injection
        /// And we follow Depencency Inversion Principle 
        /// When you use IoC Container 
        /// You should add AppDBContext then
        /// you can inject this class with other contructors
        /// </summary>
        /// We create contructor
        public UserRepasitory()
        {
            this._dbContext = new AppDBContext();
        }
        public async Task<User> CreateAsync(User user)
        {
            if (user is not null)
            {
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return user;
            }
            else return null;
        }

        public async Task DeleteAsync(int userId)
        {
            var user = _dbContext.Users.Find(userId);

            if (user is not null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SavedChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAsync(int skipItem, int takItems)
        {
            return await _dbContext.Users.Skip(skipItem)
                    .Take(skipItem).ToListAsync();
        }

        public async Task<User> GetAsync(int userId)
        {
            return await _dbContext.Users.FindAsync(userId);
        }

        public async Task<User> UpdateAsync(User updatedUser)
        {
            // this code may be a little more complicated to understand
            
            // Firt we attach updatedUser to DBContext
            var user = _dbContext.Users.Attach(updatedUser);
            
            // And We change State to modified 
            // The state is important for save chages to database 
            user.State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
            return updatedUser;
        }
    }
}
