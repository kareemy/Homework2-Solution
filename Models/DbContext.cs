using System;
using Microsoft.EntityFrameworkCore;

namespace Homework2
{
    // DbContext template code
    // We are using SQLite with database.db as our database name
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }
        // Reference to Patient entity class so it can be referenced in the database
        public DbSet<Patient> Patients {get; set;}
    }
}