using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TodoListApp.Models;
using TodoListApp.Services;

namespace TodoListApp.ViewModels
{
    public class MainViewModel
    {
        private readonly ITodoService _todoService;

        public ObservableCollection<TodoItem> TodoItems { get; } = new ObservableCollection<TodoItem>();

        public MainViewModel(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task LoadTodoItemsAsync()
        {
            var todoItems = await _todoService.GetTodoItemsAsync();
            TodoItems.Clear();
            foreach (var item in todoItems)
            {
                TodoItems.Add(item);
            }
        }

        public async Task AddTodoItemAsync(string title)
        {
            var newTodoItem = new TodoItem { Title = title };
            await _todoService.AddTodoItemAsync(newTodoItem);
            TodoItems.Add(newTodoItem);
        }

        public async Task ToggleTodoItemCompletionAsync(TodoItem todoItem)
        {
            await _todoService.ToggleTodoItemCompletionAsync(todoItem);
        }
    }
}
