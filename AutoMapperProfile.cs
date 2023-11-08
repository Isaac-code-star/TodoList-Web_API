using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TODO.Dtos.TodoLIst;
using TODO.Models;

namespace TODO
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TodoList, GetTodoListResponseDto>();
            CreateMap<AddTodoListRequestDto, TodoList>();
            CreateMap<UpdateTodoListRequestDto, TodoList>();
        }
        
    }
}