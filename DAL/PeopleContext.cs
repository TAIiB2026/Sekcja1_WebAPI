using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class PeopleContext : DbContext
    {
        public DbSet<PersonEntity> peopleDbSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder = optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Lab_1_01;Integrated Security=True;Trust Server Certificate=True");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
