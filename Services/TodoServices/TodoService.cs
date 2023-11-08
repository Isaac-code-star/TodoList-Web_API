using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TODO.Data;
using TODO.Dtos.TodoLIst;
using TODO.Models;
using TODO.Services.TodoService;

namespace TODO.Services.TodoServices
{
    public class TodoService : ITodoService
    {

        private readonly IMapper _mapper;
        //injecting ef-core database
        private readonly DataContext _dataContext;
        public TodoService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        public async Task<ServiceResponse<List<GetTodoListResponseDto>>> AddTask(AddTodoListRequestDto newtodoList)
        {
            var serviceResponse = new ServiceResponse<List<GetTodoListResponseDto>>();
            var todolist = _mapper.Map<TodoList>(newtodoList);
            await _dataContext.TodoList.AddAsync(todolist);
            _dataContext.SaveChanges();
            serviceResponse.Data = _dataContext.TodoList.Select(c => _mapper.Map<GetTodoListResponseDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTodoListResponseDto>>> GetAllTask()
        {
            var serviceResponse = new ServiceResponse<List<GetTodoListResponseDto>>
            {
                Data = await _dataContext.TodoList.Select(c => _mapper.Map<GetTodoListResponseDto>(c)).ToListAsync(),
                Message = "Data's successful"
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTodoListResponseDto>> GetTaskById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTodoListResponseDto>();
            var todoLists = await _dataContext.TodoList.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetTodoListResponseDto>(todoLists);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTodoListResponseDto>> UpdateTask(UpdateTodoListRequestDto updateTodoList){
            var serviceResponse = new ServiceResponse<GetTodoListResponseDto>();
            
            var todoLists = await _dataContext.TodoList.FirstOrDefaultAsync(c => c.Id == updateTodoList.Id);

            if(todoLists is null)
                throw new Exception($"TodoList with id {updateTodoList.Id} not found");

            todoLists.Title = updateTodoList.Title;
            todoLists.DateTime = updateTodoList.DateTime;
            _dataContext.TodoList.Update(todoLists);
            serviceResponse.Data = _mapper.Map<GetTodoListResponseDto>(todoLists);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTodoListResponseDto>> DeleteTask(int id){
            var serviceResponse = new ServiceResponse<GetTodoListResponseDto>();
            var todoLists = await _dataContext.TodoList.FirstOrDefaultAsync(c => c.Id == id);
            if(todoLists is null)
                throw new Exception($"Task with is {id} not found");
            _dataContext.TodoList.Remove(todoLists);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetTodoListResponseDto>(todoLists);
            return serviceResponse;
        }
    }
}