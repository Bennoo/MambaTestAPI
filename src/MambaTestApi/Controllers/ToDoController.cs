using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Linq;
using MambaTestApi.Models;

namespace TodoApi.Controllers
{

    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        static readonly List<ToDoItem> _items = new List<ToDoItem>()
        {
            new ToDoItem { Id = 1, Title = "First Item" }
        };

        [HttpGet]
        public IEnumerable<ToDoItem> GetAll()
        {
            return _items;
        }

        [HttpGet("{id:int}", Name = "GetByIdRoute")]
        public IActionResult GetById(int id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(item);
        }

        [HttpPost]
        public void CreateTodoItem([FromBody] ToDoItem item)
        {
            if (!ModelState.IsValid)
            {
                Context.Response.StatusCode = 400;
            }
            else
            {
                item.Id = 1 + _items.Max(x => (int?)x.Id) ?? 0;
                _items.Add(item);

                string url = Url.RouteUrl("GetByIdRoute", new { id = item.Id },
                    Request.Scheme, Request.Host.ToUriComponent());

                Context.Response.StatusCode = 201;
                Context.Response.Headers["Location"] = url;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            _items.Remove(item);
            return new HttpStatusCodeResult(204); // 201 No Content
        }
    }
}