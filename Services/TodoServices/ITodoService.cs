using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODO.Dtos.TodoLIst;
using TODO.Models;

namespace TODO.Services.TodoService
{
    public interface ITodoService
    {
        Task<ServiceResponse<List<GetTodoListResponseDto>>> GetAllTask();
        Task<ServiceResponse<GetTodoListResponseDto>> GetTaskById(Guid id);
        Task<ServiceResponse<List<GetTodoListResponseDto>>> AddTask(AddTodoListRequestDto newtodoList);
        Task<ServiceResponse<GetTodoListResponseDto>> UpdateTask(UpdateTodoListRequestDto updateTodoList);
        Task<ServiceResponse<GetTodoListResponseDto>> DeleteTask(Guid id);
    }
}