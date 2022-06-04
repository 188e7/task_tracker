using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using task_tracker.DTOs;
using task_tracker.Models;
using task_tracker.Repositories;

namespace task_tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private ProjectRepository _repository;
        public ProjectController(ProjectRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<ProjectController>
        [HttpGet(Name = "GetAll")]
        public IActionResult Get()
        {
            return Ok(_repository.Get());
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}", Name = "GetProject")]
        public IActionResult Get(int id)
        {
            return Ok(_repository.Get(id));
        }

        // POST api/<ProjectController>
        [HttpPost]
        public IActionResult Post([FromBody] SetProjectDTO project)
        {
            if (project == null)
            {
                return BadRequest();
            }
            _repository.Create(project);
            return Ok(project);
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SetProjectDTO project)
        {
            if (project == null)
            {
                return BadRequest();
            }
            var _project = _repository.Get(id);
            if (_project == null)
            {
                return NotFound();
            }
            _repository.Update(id, project);
            return Ok(project);
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            GetProjectDTO project = _repository.Delete(id);

            if (project == null)
            {
                return BadRequest();
            }

            return new ObjectResult(project);
        }
    }
}
