using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Task = TaskApi.Models.Task;

namespace TaskApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private static List<Task> tasks = new List<Task>();
        private static int nextId = 1;

        // GET /api/tasks
        [HttpGet]
        public ActionResult<IEnumerable<Task>> GetAll()
        {
            return Ok(tasks);
        }

        // POST /api/tasks
        [HttpPost]
        public ActionResult<Task> Create(Task newTask)
        {
            newTask.Id = nextId++;
            newTask.IsCompleted = false; // Siempre false al crear
            tasks.Add(newTask);
            return CreatedAtAction(nameof(GetById), new { id = newTask.Id }, newTask);
        }

        // Helper: GET /api/tasks/{id}
        [HttpGet("{id}")]
        public ActionResult<Task> GetById(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound();
            return Ok(task);
        }

        // PUT /api/tasks/{id} -> Marcar como completada
        [HttpPut("{id}")]
        public IActionResult MarkCompleted(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound();

            task.IsCompleted = true;
            return NoContent();
        }

        // DELETE /api/tasks/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound();

            tasks.Remove(task);
            return NoContent();
        }
    }
}

