using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODO.Dtos.TodoLIst
{
    public class GetTodoListResponseDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime DateTime { get; set; }
    }
}