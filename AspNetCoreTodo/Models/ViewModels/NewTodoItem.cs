using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreTodo.Models.ViewModels
{
    public class NewTodoItem
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime DueAt { get; set; }
    }
}