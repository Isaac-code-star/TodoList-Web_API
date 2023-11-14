using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace TODO.Models
{
    public class TodoList
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Title { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;

        
    }
}