using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodlamaioDevs.Domain.Entities;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
       

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(x =>
            {
                x.ToTable("ProgrammingLanguages").HasKey(a => a.Id);
                x.Property(a => a.Id).HasColumnName("Id");
                x.Property(a => a.Name).HasColumnName("Name");

                ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "C#"), new(2, "Python") };
                modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);
            });
            //Entity property ile ilgili bilgiler ve seed data trigger


        }
    }
}
