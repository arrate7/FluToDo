using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace FluToDo.Services
{
    interface ITodoService
    {
        Task<List<TodoItem>> GetTodoItems();
        Task<TodoItem> AddTodoItem(TodoItem todo);
        Task UpdateTodoItem(TodoItem todo);
    }
}
