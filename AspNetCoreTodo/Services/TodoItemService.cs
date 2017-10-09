using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTodo.Services
{
  public class TodoItemService : ITodoItemService
  {
    private readonly ApplicationDbContext _context;

    public TodoItemService(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<bool> AddItemAsync(NewTodoItem newItem, ApplicationUser currentUser)
    {
      var entity = new TodoItem
      {
        Id = Guid.NewGuid(),
        OwnerId = currentUser.Id,
        IsDone = false,
        Title = newItem.Title,
        DueAt = newItem.DueAt
      };

      _context.Items.Add(entity);

      var saveResult = await _context.SaveChangesAsync();
      return saveResult == 1;
    }

    public async Task<bool> MarkDoneAsync(Guid id, ApplicationUser currentUser)
    {
      var item = await _context.Items
          .Where(x => x.Id == id && x.OwnerId == currentUser.Id)
          .SingleOrDefaultAsync();

      if (item == null)
      {
        return false;
      }

      item.IsDone = true;

      var saveResult = await _context.SaveChangesAsync();
      return saveResult == 1; // One entity should have been updated
    }

    public async Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync(ApplicationUser currentUser)
    {
      var items = await _context.Items
          .Where(x => x.IsDone == false && x.OwnerId == currentUser.Id)
          .ToArrayAsync();

      return items;
    }
  }
}