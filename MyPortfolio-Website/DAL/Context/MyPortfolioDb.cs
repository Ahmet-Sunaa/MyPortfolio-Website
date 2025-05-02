using MyPortfolio_Website.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyPortfolio_Website.DAL.Context
{
    public class MyPortfolioDb : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer("Server=yourSqlServer;Initial Catalog=YourDataBaseName;Integrated Security=true;TrustServerCertificate=true");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Expericence> Expericences { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Services> Servicess { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<User> Users { get; set; }



    }
}
