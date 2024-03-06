﻿
using Core.Security.Entities;
using Course.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Course.Persistence.Contexts
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }
         
        public DbSet<Language> Languages { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<SocialMediaAddres> SocialMediaAddres { get; set; }
        public DbSet<ProgramingLanguages> ProgramingLanguages { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions,IConfiguration configuration):base(dbContextOptions)
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
            modelBuilder.Entity<Language>(l =>
            {
                l.ToTable("Languages").HasKey(k => k.Id);
                l.Property(p => p.Id).HasColumnName("Id");
                l.Property(p => p.Name).HasColumnName("Name");
                l.Property(p => p.ExperienceDate).HasColumnName("ExperienceDate");
                l.HasMany(p => p.ProgramingLanguages);

            });


            modelBuilder.Entity<User>(a =>
            {
                a.ToTable("Users").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.FirstName).HasColumnName("FirstName");
                a.Property(p => p.LastName).HasColumnName("LastName");
                a.Property(p => p.Email).HasColumnName("Email");
                a.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                a.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                a.Property(p => p.Status).HasColumnName("Status");
                a.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
                a.HasMany(p => p.UserOperationClaims);
                a.HasMany(p => p.RefreshTokens);


            });

            modelBuilder.Entity<UserOperationClaim>(a =>
            {
                a.ToTable("UserOperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                a.HasOne(p => p.User);
                a.HasOne(p => p.OperationClaim);


            });

            modelBuilder.Entity<OperationClaim>(a =>
            {
                a.ToTable("OperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<RefreshToken>(a =>
            {
                a.ToTable("RefreshTokens").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.Token).HasColumnName("Token");
                a.Property(p => p.Expires).HasColumnName("Expires");
                a.Property(p => p.Created).HasColumnName("Created");
                a.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp");
                a.Property(p => p.Revoked).HasColumnName("Revoked");
                a.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken");
                a.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");
                a.HasOne(p => p.User);

            });

            modelBuilder.Entity<SocialMediaAddres>(a =>
            {
                a.ToTable("SocialMediaAddres").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.SocialMediaName).HasColumnName("SocialMediaName");
                a.Property(p => p.SocialMediaUrl).HasColumnName("SocialMediaUrl");
                a.HasOne(p => p.User);
            });


            modelBuilder.Entity<ProgramingLanguages>(a =>
            {
                a.ToTable("ProgramingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.LanguageId).HasColumnName("LanguageId");
                a.HasOne(p => p.Language);
            });


            Language[] languageEntitySeeds = { new(1, "Java",DateTime.Now), new(2, "Python", DateTime.Now) };
            modelBuilder.Entity<Language>().HasData(languageEntitySeeds);
        }
    }
}
