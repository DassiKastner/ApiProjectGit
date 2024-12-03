using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EX2.Models;
using EX2.services;
using System.Collections.Generic;

namespace EX2.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet]
        public IEnumerable<Tasks> GetTasks()
        {
            return _taskService.GetTasks();
        }

        [HttpPost]
        public IActionResult AddTask(string? Title, string? Date, string? Status, int UserId , int ProjectId)
        {
            _taskService.addTask(Title, Date, Status, UserId, ProjectId);

            return CreatedAtAction(nameof(GetTasks), new {title = Title, date = Date, status = Status, userId = UserId });
        }
        [HttpDelete]
        public IActionResult deleteTask([FromQuery] int id)
        {
            _taskService.DeleteTaskById(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult updateTask([FromQuery] int Id, string? Title, string? Date, string? Status, int ProjectId, int UserId)
        {
            _taskService.updateTask(Id, Title, Date, Status, ProjectId, UserId);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult getTasksByUser(int id)
        {
            var x = _taskService.getTasksByUser(id);
            if (x != null)
            {
                return Ok(x);
            }
            return BadRequest("The id is undefind");
        }

    }
}
