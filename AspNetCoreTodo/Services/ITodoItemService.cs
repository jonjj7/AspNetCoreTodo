using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Models.ViewModels;

namespace AspNetCoreTodo.Services
{
  public interface ITodoItemService
  {
    Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync(ApplicationUser currentUser);

    Task<bool> AddItemAsync(NewTodoItem newItem, ApplicationUser currentUser);

    Task<bool> MarkDoneAsync(Guid id, ApplicationUser currentUser);
  }
}