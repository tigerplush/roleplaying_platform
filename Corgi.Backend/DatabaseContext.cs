﻿using Corgi.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Corgi.Backend
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterField> CharacterFields { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<TemplateField> TemplateFields { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<TemplateField>()
                .Property(e => e.FieldType)
                .HasConversion<string>();

            modelBuilder
                .Entity<CharacterField>()
                .Property(e => e.FieldType)
                .HasConversion<string>();
        }

        public override int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            throw new NotImplementedException();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            SetDateTime();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetDateTime();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetDateTime()
        {
            var entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
            foreach (var entry in entries)
            {
                if (entry.Entity is ILastModified lastModified)
                {
                    lastModified.LastModified = DateTime.UtcNow;
                }
                if (entry.Entity is ICreatedAt createdAt && entry.State == EntityState.Added)
                {
                    createdAt.CreatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}
