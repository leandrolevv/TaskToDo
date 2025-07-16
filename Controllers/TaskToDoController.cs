using CadastroTarefaAPI.Model;
using CadastroTarefaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CadastroTarefaAPI.Controllers
{
    [Route("api/TaskToDo")]
    public class TaskToDoController : ControllerBase
    {
        private readonly ITaskToDoRepository _taskRepository;

        /// <summary>
        public TaskToDoController(ITaskToDoRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var tasks = await _taskRepository.GetAllAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}", Name = "GetTaskById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TaskToDo taskToDo)
        {
            if (taskToDo == null)
            {
                return BadRequest("Task cannot be null");
            }
            await _taskRepository.CreateAsync(taskToDo);
            return CreatedAtRoute("GetTaskById", new { id = taskToDo.Id }, taskToDo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] TaskToDo taskToDo)
        {
            if (taskToDo == null || taskToDo.Id != id)
            {
                return BadRequest("Task ID mismatch");
            }
            var existingTask = await _taskRepository.GetByIdAsync(id);
            
            if (existingTask == null)
            {
                return NotFound();
            }
            await _taskRepository.UpdateByIdAsync(taskToDo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var existingTask = await _taskRepository.GetByIdAsync(id);
            if (existingTask == null)
            {
                return NotFound();
            }
            await _taskRepository.DeleteByIdAsync(id);
            return NoContent();
        }
    }
}
