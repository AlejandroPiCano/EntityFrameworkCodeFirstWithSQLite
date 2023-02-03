using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoItems.Domain;
using TodoItems.Infrastructure.Entities;

namespace TodoItems.Infrastructure
{
    public class TodoItemRepository : IRepository<TodoItem>
    {
        private readonly TodoItemDbContext context;

        public TodoItemRepository(TodoItemDbContext context)
        {
            this.context = context;
            this.context.Database.EnsureCreated();
        }

        public IUnitOfWork UnitOfWork => context;

        public async Task CreateAsync(TodoItem entity)
        {
            await this.context.Items.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await this.context.Items.FindAsync(id);

            this.context.Items.Remove(item);
        }

        public async Task<List<TodoItem>> GetAllAsync()
        {
            return await this.context.Items.ToListAsync();
        }

        public async Task<TodoItem> GetAsync(int id)
        {
            return await this.context.Items.FindAsync(id);
        }

        public async Task UpdateAsync(int id, TodoItem entity)
        {
            context.Items.Attach(entity);
            await Task.Run(() => this.context.Entry(entity).State = EntityState.Modified);
        }
    }
}
