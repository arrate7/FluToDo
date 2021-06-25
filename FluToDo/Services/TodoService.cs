using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TodoApi.Models;

namespace FluToDo.Services
{
    public class TodoService : ITodoService
    {
        private readonly HttpClient _http;

        public TodoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TodoItem>> GetTodoItems()
        {
            return await _http.GetFromJsonAsync<List<TodoItem>>("");
        }
        public async Task<TodoItem> AddTodoItem(TodoItem todo)
        {
            var responseMessage = await  _http.PostAsJsonAsync("", todo);
            return await responseMessage.Content.ReadFromJsonAsync<TodoItem>();
        }
        public async Task UpdateTodoItem(TodoItem todo)
        {
                await _http.PutAsJsonAsync($"/api/todo/{todo.Key}", todo);
        }
        public async Task DeleteTodoItem(string key)
        {
            await _http.DeleteAsync($"/api/todo/{key}");
        }
    }
}
