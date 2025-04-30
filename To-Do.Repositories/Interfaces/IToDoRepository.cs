using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do.Model.Entities;

namespace To_Do.Repository.Interfaces
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDoItem>> GetAllAsync();
        Task<ToDoItem?> GetByIdAsync(int id);
        Task<ToDoItem> AddAsync(ToDoItem item);
        Task<bool> UpdateAsync(ToDoItem item);
        Task<bool> DeleteAsync(int id);
    }
}
