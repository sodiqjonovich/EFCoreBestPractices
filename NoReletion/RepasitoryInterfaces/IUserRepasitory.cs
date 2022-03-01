using NoReletion.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoReletion.RepasitoryInterfaces
{
    // Repasitory Interfaces should be public
    // Beacuse We use it another Layer
    public interface IUserRepasitory
    {
        /// <summary>
        /// This is simple impliment pagination
        /// Because We don't use all data 
        /// We use several rows
        /// </summary>
        /// <param name="skipItems"></param>
        /// skipItems is need for skip rows from tables
        /// For example 5
        /// repasitory must skip 5 row from table
        /// and take some rows
        /// <param name="takeItems"></param>
        /// takeItmes is give one question
        /// How much row do you need?
        /// <returns></returns>
        public Task<IEnumerable<User>> GetAsync(int skipItems, int takeItems);

        public Task<User> GetAsync(int userId);

        public Task<User> CreateAsync(User user);

        public Task<User> UpdateAsync(User updatedUser);

        public Task<bool> DeleteAsync(int userId);
    }
}
