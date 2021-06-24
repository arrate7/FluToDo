using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TodoApi.Models;

namespace FluToDo.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[EnableCors("CorsPolicy")]
	public class TodoController : ControllerBase
	{
		public TodoController()
		{
			if (TodoItems == null)
			{
				TodoItems = new TodoRepository();
			}
		}

		public static ITodoRepository TodoItems { get; set; }

		[HttpGet]
		public IEnumerable<TodoItem> GetAll()
		{
			return TodoItems.GetAll();
		}

		[HttpGet]
		[Route("{id}")]
		public ActionResult<TodoItem> GetById(string id)
		{
			var item = TodoItems.Find(id);
			if (item == null)
			{
				return new NotFoundResult();
			}
			return item;
		}

		[HttpPost]
		public IActionResult Create([FromBody] TodoItem item)
		{
			if (item == null)
			{
				return BadRequest();
			}
			TodoItems.Add(item);
			return CreatedAtRoute("GetTodo", new { id = item.Key }, item);
		}

		[HttpPut]
		[Route("{id}")]
		public IActionResult Update(string id, [FromBody] TodoItem item)
		{
			if (item == null || item.Key != id)
			{
				return BadRequest();
			}

			var todo = TodoItems.Find(id);
			if (todo == null)
			{
				return NotFound();
			}

			TodoItems.Update(item);
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		public IActionResult Update([FromBody] TodoItem item, string id)
		{
			if (item == null)
			{
				return BadRequest();
			}

			var todo = TodoItems.Find(id);
			if (todo == null)
			{
				return NotFound();
			}

			item.Key = todo.Key;

			TodoItems.Update(item);
			return Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		public IActionResult Delete(string id)
		{
			var todo = TodoItems.Find(id);
			if (todo == null)
			{
				return NotFound();
			}

			TodoItems.Remove(id);
			return Ok();
		}
	}
}
