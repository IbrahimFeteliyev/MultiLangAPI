//using Business.Abstarct;
//using Business.Concrete;
//using Entities.Concrete;
//using Entities.DTOs;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly IUserManager _userManager;

//        public UserController(IUserManager userManager)
//        {
//            _userManager = userManager;
//        }

//        [HttpGet("getallusers")]
//        public List<User> GetAll() 
//        {
//            return _userManager.GetAllUsers();
//        }

//        [HttpPost("register")]
//        public IActionResult Register([FromBody] RegisterDTO registerDTO)
//        {
//            try
//            {
//                var user = _userManager.Register(registerDTO);
//                return Ok(user);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpPost("login")]
//        public IActionResult Login([FromBody] LoginDTO loginDTO)
//        {
//            var user = _userManager.Login(loginDTO);
//            if (user != null)
//            {
//                return Ok(user);
//            }
//            return Unauthorized("Invalid email or password.");
//        }

//        [HttpGet("getByEmail")]
//        public IActionResult GetUserByEmail([FromQuery] string email)
//        {
//            var user = _userManager.GetUserByEmail(email);
//            if (user != null)
//            {
//                return Ok(user);
//            }
//            return NotFound("User not found.");
//        }
//    }
//}
