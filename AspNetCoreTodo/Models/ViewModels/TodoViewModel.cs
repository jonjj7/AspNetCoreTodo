using System.Collections.Generic;

namespace AspNetCoreTodo.Models.ViewModels
{
    public class TodoViewModel
    {
        public IEnumerable<TodoItem> Items { get; set; }
    }
}