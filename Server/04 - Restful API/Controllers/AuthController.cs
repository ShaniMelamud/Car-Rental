using Microsoft.AspNetCore.Mvc;


namespace CarRental
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtHelper jwtHelper;
        private readonly UsersLogic logic;
        public AuthController(JwtHelper jwtHelper, UsersLogic logic)
        {
            this.jwtHelper = jwtHelper;
            this.logic = logic;
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(CredentialsModel credentials)
        {
           

            UserModel user = logic.GetUserByCredentials(credentials);

            if (user == null)
                return Unauthorized("Incorrect user name or password!");

            user.JwtToken = jwtHelper.GetJwtToken(user.UserName, user.Role);

            user.Password = null;

            return Ok(user);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserModel user)
        {
            if (logic.IsUserNameExists(user.UserName))
                return BadRequest("UserName already taken");

            
            logic.AddUser(user);

            user.JwtToken = jwtHelper.GetJwtToken(user.UserName, user.Role);

            user.Password = null;

            return Created("api/users/" + user.ID, user);
        }
    }
}
