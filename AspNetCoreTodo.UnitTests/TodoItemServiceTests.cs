using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Models.ViewModels;
using AspNetCoreTodo.Services;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTodo.UnitTests
{
  [TestClass]
  public class TodoItemServiceTests
  {
    [TestMethod]
    public async Task AddNewItem()
    {
      var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(databaseName: "Test_AddNewItem").Options;

      // Set up a context (connection to the DB) for writing
      using (var inMemoryContext = new ApplicationDbContext(options))
      {
        var service = new TodoItemService(inMemoryContext);

        var fakeUser = new ApplicationUser
        {
          Id = "fake-000",
          UserName = "fake@fake"
        };

        await service.AddItemAsync(new NewTodoItem { Title = "Testing?" }, fakeUser);
      }

      // Use a separate context to read the data back from the DB
      using (var inMemoryContext = new ApplicationDbContext(options))
      {
        Assert.AreEqual(1, await inMemoryContext.Items.CountAsync());

        var item = await inMemoryContext.Items.FirstAsync();
        Assert.AreEqual("Testing?", item.Title);
        Assert.AreEqual(false, item.IsDone);
      }

    }
  }
}
