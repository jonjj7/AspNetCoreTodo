using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Models.ViewModels;

namespace AspNetCoreTodo.Services
{
  public class MockTodoItemService : ITodoItemService
  {
    public Task<bool> AddItemAsync(NewTodoItem newItem, ApplicationUser currentUser)
    {
      throw new NotImplementedException();
    }

    public Task<bool> MarkDoneAsync(Guid id, ApplicationUser currentUser)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync(ApplicationUser currentUser)
    {
      // Return an array of TodoItems
      IEnumerable<TodoItem> items = new[]
      {
                new TodoItem
                {
                    Title = "Learn ASP.NET Core",
                    DueAt = DateTime.Now.AddDays(1)
                },
                new TodoItem
                {
                    Title = "Build awesome apps",
                    DueAt = DateTime.Now.AddDays(2)
                }
            };

      return Task.FromResult(items);
    }
  }
}