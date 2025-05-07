using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do.Model.DTOs;
using To_Do.Model.Entities;
using To_Do.Repository.Implementations;
using To_Do.Repository.Interfaces;
using To_Do.Service.Interfaces;

namespace To_Do.Service.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _repository;
        private readonly IMapper _mapper;

        public ToDoService(IToDoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ToDoItemDto> CreateAsync(CreateToDoDto dto)
        {
            var entity = _mapper.Map<ToDoItem>(dto);

            var created = await _repository.AddAsync(entity);
            return _mapper.Map<ToDoItemDto>(created);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ToDoItemDto>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ToDoItemDto>>(items);
        }

        public async Task<ToDoItemDto?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return item == null ? null : _mapper.Map<ToDoItemDto>(item);
        }

        //public async Task<IEnumerable<ToDoItemDto>> SearchAsync(string term)
        //{
        //    var results = await _repository.SearchAsync(term);
        //    return _mapper.Map<IEnumerable<ToDoItemDto>>(results);
        //}

        public async Task<bool> UpdateAsync(int id, UpdateToDoDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return false;

            _mapper.Map(dto, existing);
            existing.UpdatedAt = DateTime.Now;

            try
            {
                return await _repository.UpdateAsync(existing);
            }
            catch
            {
                return false;
            }
        }

    }
}