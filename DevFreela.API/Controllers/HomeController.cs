using DevFreela.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    public class HomeController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get(string query)
        {
            return Ok();
        }

        //api/projects/3
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var resource = GetResourceByIdFromDatabase(id);

            if (resource != null)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel createProject)
        {
            if (createProject.Title.Length > 50)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { id = createProject.Id }, createProject);
        }

        //api/projects/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProject)
        {
            if (updateProject.Description.Length > 200)
            {
                return BadRequest();
            }
            
            //atualizou
            return NoContent();
        }

        //api/projects/3 DELETE
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            // Buscar, se nao existir, retorna NotFound
            // Remover
            return NoContent();
        }


        private object GetResourceByIdFromDatabase(int id)
        {
            //Dbcontext.Resources.SingleOfDefault(x => x.Id == id);
        }

    }

}
