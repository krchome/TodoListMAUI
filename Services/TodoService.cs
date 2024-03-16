using System.Collections.Generic;
using System.Threading.Tasks;
using TodoListApp.Models;

namespace TodoListApp.Services
{
    public class TodoService : ITodoService
    {
        private List<TodoItem> _todoItems; // Simulated data source

        public TodoService()
        {
            // Initialize the list of Todo items (simulated data source)
            _todoItems = new List<TodoItem>
            {
                new TodoItem { Id = 1, Title = "Task 1", IsCompleted = false },
                new TodoItem { Id = 2, Title = "Task 2", IsCompleted = false }
            };
        }

        public Task<List<TodoItem>> GetTodoItemsAsync()
        {
            // Simulate fetching data asynchronously (e.g., from a database or web service)
            return Task.FromResult(_todoItems);
        }

        public Task AddTodoItemAsync(TodoItem todoItem)
        {
            // Assign a unique Id to the new Todo item
            todoItem.Id = _todoItems.Count + 1;

            // Add the new Todo item to the list
            _todoItems.Add(todoItem);

            // Simulate saving data asynchronously (e.g., to a database or web service)
            return Task.CompletedTask;
        }

        public Task ToggleTodoItemCompletionAsync(TodoItem todoItem)
        {
            // Toggle the completion status of the specified Todo item
            todoItem.IsCompleted = !todoItem.IsCompleted;

            // Simulate updating data asynchronously (e.g., in a database or web service)
            return Task.CompletedTask;
        }
    }
}
