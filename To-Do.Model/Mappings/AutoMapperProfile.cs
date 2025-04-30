using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do.Model.DTOs;
using To_Do.Model.Entities;

namespace To_Do.Model.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ToDoItem, ToDoItemDto>().ReverseMap();
            CreateMap<CreateToDoDto, ToDoItem>().ReverseMap();
            CreateMap<UpdateToDoDto, ToDoItem>().ReverseMap();
        }
    }
}
