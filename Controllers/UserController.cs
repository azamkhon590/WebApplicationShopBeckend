using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationBackend.Data;
using WebApplicationBackend.Model;

namespace WebApplicationBackend.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly ApplicationDbContext context;

        public UserController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var user = await context.User.ToListAsync();
            return Ok(user);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            var user = await context.User.FirstOrDefaultAsync(x => x.id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserApp userObj)
        {
            if (userObj == null)
                return BadRequest("user not found");

            var user = await context.User
                .FirstOrDefaultAsync(x => x.userName == userObj.userName && x.password == userObj.password);

            return Ok(new
            {
                Message = "LoginSuccess"
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserApp userObj)
        {
            if (userObj == null)
                return BadRequest();

            userObj.role = "User";
            userObj.token = "";

            await context.User.AddAsync(userObj);
            await context.SaveChangesAsync();

            return Ok(
            new
            {
                Message = "RegistSuccess"
            });
        }
    }
}
