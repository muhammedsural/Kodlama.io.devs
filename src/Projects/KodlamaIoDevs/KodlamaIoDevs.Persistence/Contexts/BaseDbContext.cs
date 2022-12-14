using Core.Security.Entities;
using KodlamaioDevs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
            modelBuilder.Entity<Technology>().Navigation(x => x.ProgrammingLanguage).AutoInclude();
            modelBuilder.Entity<ProgrammingLanguage>().Navigation(x => x.Technologies).AutoInclude();

            modelBuilder.Entity<ProgrammingLanguage>(x =>
            {
                x.ToTable("ProgrammingLanguages").HasKey(a => a.Id);
                x.Property(a => a.Id).HasColumnName("Id");
                x.Property(a => a.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<Technology>(p =>
            {
                p.ToTable("Technologies").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.Name).HasColumnName("Name");
                p.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                p.HasOne(p => p.ProgrammingLanguage);
            });

            modelBuilder.Entity<User>(p =>
        {
            p.ToTable("Users").HasKey(k => k.Id);
            p.Property(p => p.Id).HasColumnName("Id");
            p.Property(p => p.FirstName).HasColumnName("FirstName");
            p.Property(p => p.LastName).HasColumnName("LastName");
            p.Property(p => p.Email).HasColumnName("Email");
            p.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
            p.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
            p.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
            p.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
            p.HasMany(p => p.UserOperationClaims);
            p.HasMany(p => p.RefreshTokens);
        });

            modelBuilder.Entity<Developer>(p =>
            {
                p.ToTable("Developers");
                p.HasMany(p => p.GitHubProfiles);
            });

            modelBuilder.Entity<OperationClaim>(p =>
            {
                p.ToTable("OperationClaims").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<UserOperationClaim>(p =>
            {
                p.ToTable("UserOperationClaims").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.UserId).HasColumnName("UserId");
                p.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                p.HasOne(p => p.OperationClaim);
                p.HasOne(p => p.User);
            });

            modelBuilder.Entity<GitHubProfile>(p =>
            {
                p.ToTable("GitHubProfiles").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.DeveloperId).HasColumnName("DeveloperId");
                p.Property(p => p.ProfileUrl).HasColumnName("ProfileUrl");
                p.HasOne(p => p.Developer);
            });


            //Entity property ile ilgili bilgiler ve seed data trigger

            ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "C#"), new(2, "Python") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);


            Technology[] technologies = { new(1, "ASP.NET CORE",1 ), new(2, "PyTorch", 2) };
            modelBuilder.Entity<Technology>().HasData(technologies);
        }
    }
}
