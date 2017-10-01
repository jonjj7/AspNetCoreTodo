using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Models.ViewModels;

namespace AspNetCoreTodo.Services
{
    public class MockTodoItemService : ITodoItemService
    {
        public Task<bool> AddItemAsync(NewTodoItem newItem)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync()
        {
            // Return an array of TodoItems
            IEnumerable<TodoItem> items = new[]
            {
                new TodoItem
                {
                    Title = "Learn ASP.NET Core",
                    DueAt = DateTimeOffset.Now.AddDays(1)
                },
                new TodoItem
                {
                    Title = "Build awesome apps",
                    DueAt = DateTimeOffset.Now.AddDays(2)
                }
            };

            return Task.FromResult(items);
        }
    }
}