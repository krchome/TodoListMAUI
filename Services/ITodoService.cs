using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Models;

namespace TodoListApp.Services
{
    public interface ITodoService
    {
        Task<List<TodoItem>> GetTodoItemsAsync();
        Task AddTodoItemAsync(TodoItem todoItem); // Add this method to add a new Todo item
        Task ToggleTodoItemCompletionAsync(TodoItem todoItem); // Add this method to handle tap events on Todo items
    }
}
