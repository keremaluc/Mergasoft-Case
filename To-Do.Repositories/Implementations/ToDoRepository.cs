using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do.Data;
using To_Do.Model.Entities;
using To_Do.Repository.Interfaces;

namespace To_Do.Repository.Implementations
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ToDoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ToDoItem>> GetAllAsync()
        {
            return await _dbContext.ToDos.ToListAsync();
        }

        public async Task<ToDoItem?> GetByIdAsync(int id)
        {
            return await _dbContext.ToDos.FindAsync(id);
        }

        public async Task<ToDoItem> AddAsync(ToDoItem item)
        {
            _dbContext.ToDos.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _dbContext.ToDos.FindAsync(id);
            if (item == null) return false;

            _dbContext.ToDos.Remove(item);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(ToDoItem item)
        {
            try
            {
                _dbContext.ToDos.Update(item);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
