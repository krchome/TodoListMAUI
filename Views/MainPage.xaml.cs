using Microsoft.Maui.Controls;
using TodoListApp.Models;
using TodoListApp.Services;
using TodoListApp.ViewModels;

namespace TodoListApp.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            _viewModel = new MainViewModel(new TodoService());
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadTodoItemsAsync();
        }

        private async void OnAddTodoClicked(object sender, System.EventArgs e)
        {
            var newTodoTitle = NewTodoEntry.Text;
            if (!string.IsNullOrWhiteSpace(newTodoTitle))
            {
                await _viewModel.AddTodoItemAsync(newTodoTitle);
                NewTodoEntry.Text = string.Empty;
            }
        }

        private async void OnTodoItemToggled(object sender, ToggledEventArgs e)
        {
            if (sender is Switch toggleSwitch && toggleSwitch.BindingContext is TodoItem todoItem)
            {
                await _viewModel.ToggleTodoItemCompletionAsync(todoItem);
            }
        }
    }
}
