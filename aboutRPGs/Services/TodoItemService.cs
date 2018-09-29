using System;
using System.Linq;
using System.Threading.Tasks;
using aboutRPGs.Data;
using aboutRPGs.Models;
using Microsoft.EntityFrameworkCore;

namespace aboutRPGs.Services 
{
    public class TodoItemService : ITodoItemService 
    {
        private readonly ApplicationDbContext _context;

        public TodoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddItemAsync(TodoItem newItem)
        {
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            newItem.DueAt = DateTime.Now.AddDays(1);

            _context.Items.Add(newItem);

            var result = await _context.SaveChangesAsync();
            return result == 1;
        }

        public async Task<TodoItem[]> GetIncompleteItemAsync()
        {
            return await _context.Items
                .Where(x => x.IsDone == false)
                .ToArrayAsync();
        }
    }
}