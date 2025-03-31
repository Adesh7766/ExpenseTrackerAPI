using ExpenseTrackerAPI.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }          
        
        public DbSet<User> Users { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Category> Category { get; set; }

    }
}
