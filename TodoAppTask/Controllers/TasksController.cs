using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using TodoAppTask.Models;
using TodoAppTask.Services;

namespace TodoAppTask.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/Task")]
    public class TasksController : ApiController
    {
        private readonly TaskService _taskService = new TaskService();

        [HttpGet]
        [Route("")]
        public IEnumerable<Task> GetAllTask()
        {
            return _taskService.GetAll();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateTask([FromBody] Task task)
        {
            if (string.IsNullOrWhiteSpace(task.Title) || task.Title.Length > 100)
            {
                return BadRequest("El título no puede estar vacío y debe tener un máximo de 100 caracteres.");
            }

            var createdTask = _taskService.Add(task);
            return CreatedAtRoute("GetTaskById", new { id = createdTask.Id }, createdTask);
        }


        [HttpGet]
        [Route("{id:int}", Name = "GetTaskById")]
        public IHttpActionResult GetTaskById(int id)
        {
            var todo = _taskService.GetById(id);
            if (todo == null)
                return NotFound();

            return Ok(todo);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult UpdateTask(int id, [FromBody] Task updatedTask)
        {
            if (string.IsNullOrWhiteSpace(updatedTask.Title) || updatedTask.Title.Length > 100)
            {
                return BadRequest("El título no puede estar vacío y debe tener un máximo de 100 caracteres.");
            }

            var result = _taskService.Update(id, updatedTask);
            if (!result) return NotFound();

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteTask(int id)
        {
            var result = _taskService.Delete(id);
            if (!result) return NotFound();

            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }
    }
}