using Auth.WebAPI.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Auth.ModelsManipulations.AddUser;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Auth.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        IMediator mediator;

        public Auth(IMediator m)
        {
            mediator = m;
        }
        // GET: api/<Auth>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Auth>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Auth>
        [HttpPost]
        public async Task<bool> Post([FromBody] AddUserReq req)
        {
            bool isUserCreated = await mediator.Send(new AddUserCommand(req.Email, req.Password));
            return isUserCreated;
        }

        // PUT api/<Auth>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Auth>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
