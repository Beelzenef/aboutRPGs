
using System.Threading.Tasks;
using aboutRPGs.Models;

namespace aboutRPGs.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemAsync();
        Task<bool> AddItemAsync(TodoItem newItem);
    }
}