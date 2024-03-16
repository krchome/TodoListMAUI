using TodoListApp.Services;
using TodoListApp.ViewModels;
using TodoListApp.Views;

namespace TodoListApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        var builder = MauiApp.CreateBuilder();
        builder.Services.AddScoped<ITodoService, TodoService>();
        // Register other services or dependencies here
        var app = builder.Build();
        app.Services.GetService<ITodoService>(); // Ensure service can be resolved
        MainPage = new AppShell();
    }
}

