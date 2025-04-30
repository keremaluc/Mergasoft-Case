using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do.Model.DTOs;

namespace To_Do.Service.Interfaces
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDoItemDto>> GetAllAsync();
        Task<ToDoItemDto?> GetByIdAsync(int id);
        Task<ToDoItemDto> CreateAsync(CreateToDoDto dto);
        Task<bool> UpdateAsync(int id, UpdateToDoDto dto);
        Task<bool> DeleteAsync(int id);
    }

}