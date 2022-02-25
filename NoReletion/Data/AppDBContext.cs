using Microsoft.EntityFrameworkCore;
using NoReletion.Entities;

namespace NoReletion.Data
{
    /// <summary>
    /// This class is important for using EF Core
    /// internal acces modifier recomended
    /// because we us interfaces and don't use it another project
    /// </summary>
    internal class AppDBContext:DbContext
    {
        // This is for Database Tables
        // EF Core recognize tables with DBSet
        public DbSet<User> Users { get; set; }

        // This mehtod override is nesessary for connect to database
        // we need to specify a path to connect to the database 
        // and 
        // we need to enter which database type to use
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server = (localdb)\\MSSQLLocalDB; Database=EFCoreLearnDB; Trusted_Connection=True;";
            
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
