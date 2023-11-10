using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TODO.Dtos.TodoLIst;
using TODO.Models;
using TODO.Services.TodoService;

namespace TODO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoListController : ControllerBase
    {
       //injection ITodoService
        private readonly ITodoService _todoService;

        public TodoListController(ITodoService todoService)
        {
            _todoService = todoService;
            
        }
        
        //geting all Todo Task
        [HttpGet("GetAllTask")]
        public async Task<ActionResult<ServiceResponse<List<GetTodoListResponseDto>>>> GetAllTask(){
            return Ok(await _todoService.GetAllTask());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTodoListResponseDto>>> GetTaskById(Guid id){           
            return Ok(await _todoService.GetTaskById(id));
        }

        [HttpPost("AddTask")]
        public async Task<ActionResult<ServiceResponse<List<GetTodoListResponseDto>>>> AddTask(AddTodoListRequestDto newtodoList){
            
            return Ok(await _todoService.AddTask(newtodoList));
        }

        [HttpPut("UpdateTask")]
        public async Task<ActionResult<ServiceResponse<GetTodoListResponseDto>>> UpdateTask(UpdateTodoListRequestDto updateTodoList){
            return Ok(await _todoService.UpdateTask(updateTodoList));
        }

        [HttpDelete("DeleteTask")]
        public async Task<ActionResult<ServiceResponse<GetTodoListResponseDto>>> DeleteTask(Guid id){
            return Ok(await _todoService.DeleteTask(id));
        }
    }
}