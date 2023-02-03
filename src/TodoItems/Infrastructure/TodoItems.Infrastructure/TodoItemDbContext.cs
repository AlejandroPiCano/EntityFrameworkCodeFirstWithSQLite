using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TodoItems.Domain;
using TodoItems.Infrastructure.Entities;

namespace TodoItems.Infrastructure
{
    public class TodoItemDbContext: DbContext, IUnitOfWork
    {
        private const string FileName = "TodoItemsDB.sqlite";

        public DbSet<TodoItem> Items { get; set; }

        public Task RollbackAsync()
        {
            return Task.Run(() => this.ChangeTracker.Clear());
        }

        public Task SaveChangeAsync()
        {
           return this.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: $"FileName={FileName}",
                sqliteOptionsAction: op =>
                {
                    op.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().ToTable("TodoItem");
            modelBuilder.Entity<TodoItem>(e =>
            {
                e.HasKey(k => k.Id);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
