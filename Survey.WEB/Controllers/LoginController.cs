using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey.Data.Models;
using Survey.Repositories.UnitOfWork;

namespace Survey.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _login;
        public LoginController(ILogin login)
        {
            _login = login;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetRespondent(string username)
        {
            var item = await _login.Respondent.GetByUsername(username);

            if (item == null)
                return NotFound();

            return Ok(item);
        }


        [HttpPost]
        public async Task<IActionResult> Login(Respondent respondent)
        {
            if (ModelState.IsValid)
            {
                var item = await _login.Respondent.GetByUsernameAndPassword(respondent.Username, respondent.Password);

                if (item == null)
                    return Unauthorized(respondent);


                return CreatedAtAction("GetRespondent", new { item.Username }, item);
            }

            return new JsonResult("Something Went wrong") { StatusCode = 500 };
        }       
    }
}
