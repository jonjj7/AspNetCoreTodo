using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Models.ViewModels;
using AspNetCoreTodo.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTodo.Controllers {
    public class TodoController : Controller {
        private readonly ITodoItemService _todoItemService;

        public TodoController (ITodoItemService todoItemService) {
            _todoItemService = todoItemService;
        }

        public async Task<IActionResult> Index () {
            // Get items
            var todoItems = await _todoItemService.GetIncompleteItemsAsync ();

            // Create model
            var viewModel = new TodoViewModel () {
                Items = todoItems
            };
            
            // Pass to the view
            return View(viewModel);
        }
    }
}