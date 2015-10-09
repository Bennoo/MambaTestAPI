using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MambaTestApi.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
}
