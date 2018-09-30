using System;
using System.Threading.Tasks;
using aboutRPGs.Models;
using aboutRPGs.Services;
using Microsoft.AspNetCore.Mvc;

namespace aboutRPGs.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoItemService _todoItemService;
        
        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _todoItemService.GetIncompleteItemAsync();
            
            var model = new TodoViewModel()
            {
                Items = items
            };
            
            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var succesful = await _todoItemService.AddItemAsync(newItem);
            if (!succesful)
            {
                return BadRequest("could not add item");
            }
            return RedirectToAction("Index");
        }

        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> MarkDone(Guid id) {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var succesful = await _todoItemService.MarkAsDoneItem(id);
            if (!succesful)
            {
                return BadRequest("could not complete this item");
            }
            return RedirectToAction("Index");
        }
    }
}