using System;
using System.Collections.Generic;
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
    }
}
