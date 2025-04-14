using MyPortfolio_Website.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyPortfolio_Website.DAL.Context
{
    public class MyPortfolioDb : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SUNA\\SQLEXPRESS;Initial Catalog=MyPortfolio;Integrated Security=true;TrustServerCertificate=true");
        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=77.245.159.112\\MSSQLSERVER2022;database=beratmet_HurdaciDb;user=beratmet_beratmet; password=Cansever_4251;TrustServerCertificate=true");
        }*/
        public DbSet<About> Abouts { get; set; }
        public DbSet<Expericence> Contacts { get; set; }
        public DbSet<Personal> Features { get; set; }
        public DbSet<Portfolio> Scraps { get; set; }
        public DbSet<Services> ScrapImgs { get; set; }
        public DbSet<Skill> Admins { get; set; }
        public DbSet<User> Users { get; set; }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Scrap>()
        //        .HasMany(s => s.ScrapImgs)
        //        .WithOne(si => si.Scrap)
        //        .HasForeignKey(si => si.ScrapId);

        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
