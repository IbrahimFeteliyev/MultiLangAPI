//using Business.Abstarct;
//using Entities.Concrete;
//using Entities.DTOs;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DoctorController : ControllerBase
//    {
//        private readonly IDoctorManager _manager;

//        public DoctorController(IDoctorManager manager)
//        {
//            _manager = manager;
//        }

//        [HttpGet("getall")]
//        public List<Doctor> GetAll() 
//        {
        
//            return _manager.GetAllDoctors();
//        }

//        [HttpPost("logindoctor")]
//        public IActionResult Login([FromBody] LoginDTO loginDTO)
//        {
//            var doctor = _manager.LoginDoctor(loginDTO);
//            if (doctor != null)
//            {
//                return Ok(doctor);
//            }
//            return Unauthorized("Invalid email or password.");
//        }


//        [HttpGet("getById")]
//        public IActionResult GetDoctorById([FromQuery] int id)
//        {
//            var doctor = _manager.GetDoctorById(id);
//            if (doctor != null)
//            {
//                return Ok(doctor);
//            }
//            return NotFound("Doctor not found.");
//        }

//        [HttpPost("add")]
//        public IActionResult Register([FromBody] DoctorDTO doctorDTO)
//        {
//            try
//            {
//                var doctor = _manager.AddDoctor(doctorDTO);
//                return Ok(doctor);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }
//    }
//}
