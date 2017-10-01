using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Models.ViewModels;

namespace AspNetCoreTodo.Services
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync();

        Task<bool> AddItemAsync(NewTodoItem newItem);
    }
}