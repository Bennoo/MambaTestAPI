using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Linq;
using MambaTestApi.Models;
using MambaTestApi.Repo.Interfaces;

namespace TodoApi.Controllers
{

    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoItemsRepository _repo;

        public TodoController(ITodoItemsRepository repo)
        {
            _repo = repo;
        } 

        [HttpGet]
        public IEnumerable<ToDoItem> GetAll()
        {
            return _repo.AllItems;
        }

        [HttpGet("{id:int}", Name = "GetByIdRoute")]
        public IActionResult GetById(int id)
        {
            var item = _repo.GetById(id);
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
                _repo.Add(item);

                string url = Url.RouteUrl("GetByIdRoute", new { id = item.Id },
                    Request.Scheme, Request.Host.ToUriComponent());

                Context.Response.StatusCode = 201;
                Context.Response.Headers["Location"] = url;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {            
            if (!_repo.TryDelete(id))
            {
                return HttpNotFound();
            }            
            return new HttpStatusCodeResult(204); // 201 No Content
        }
    }
}