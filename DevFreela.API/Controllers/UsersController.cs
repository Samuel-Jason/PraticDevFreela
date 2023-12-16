using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly object _mediator;

        public UsersController(object mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserQuery(id);
            
            var user = await _mediator.Send(query);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommandModel command)
        {
            var id = await _mediator.Send(command);

            return  CreatedAtAction(nameof(GetById), new {id = id}, command);
        }

    }

    internal class GetUserQuery
    {
        private int id;

        public GetUserQuery(int id)
        {
            this.id = id;
        }
    }
}
