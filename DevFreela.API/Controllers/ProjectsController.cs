using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly OpeningTimeOption _option;
        private readonly ExampleClass _exampleClass;
        public ProjectsController(IOptions<OpeningTimeOption> option, ExampleClass exampleClass)
        {
            exampleClass.Name = "Update at ProjectController";
            _option = option.Value;
        }

        // api/projects?query=net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            return Ok();
        }

        // api/projects/3
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // return NotFound();
            return Ok();
        }

        // api/projects
        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel createProject)
        {
            if (createProject.Title.Length > 50)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetById), new { id = createProject.Id }, createProject);
        }

        // api/projects/2
        [HttpPut("id")]
        public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProject)
        {
            if (updateProject.Description.Length > 3)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // api/projects/3
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }

        // api/projects/3/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentModel createComment)
        {
            return NoContent();
        }

        // api/projects/1/start
        [HttpPost("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        // api/projects/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            return NoContent();
        }
    }
}
