using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using task_tracker.Repositories;
using task_tracker.Models;
using task_tracker.DTOs;

namespace task_tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private TaskRepository _repository;
        public TaskController(TaskRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<TaskController>
        [HttpGet(Name = "GetAllTasks")]
        public IActionResult Get()
        {
            return Ok(_repository.Get());
        }
        // GET api/<TaskController>/5
        [HttpGet("{id}", Name = "GetTask")]
        public IActionResult Get(int id)
        {
            return Ok(_repository.Get(id));
        }

        // POST api/<TaskController>
        [HttpPost]
        public IActionResult Post([FromBody] SetTaskDTO task)
        {
            if (task == null)
            {
                return BadRequest();
            }
            _repository.Create(task);
            return Ok(task);
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SetTaskDTO task)
        {
            if (task == null)
            {
                return BadRequest();
            }
            var _task = _repository.Get(id);
            if (_task == null)
            {
                return NotFound();
            }
            _repository.Update(id, task);
            return Ok(task);
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            GetTaskDTO task = _repository.Delete(id);
            if (task == null)
            {
                return BadRequest();
            }
            return new ObjectResult(task);
        }
    }
}
