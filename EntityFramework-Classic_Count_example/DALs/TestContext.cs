using EntityFramework_Classic_Count_example.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_Classic_Count_example.DALs
{
    public class TestContext : DbContext
    {
        public DbSet<Element> Elements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=EntityFramework_Classic_Test;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
