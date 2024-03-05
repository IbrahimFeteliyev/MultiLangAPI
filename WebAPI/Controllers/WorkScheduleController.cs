//using Business.Abstarct;
//using Entities.DTOs;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class WorkScheduleController : ControllerBase
//    {
//        private readonly IWorkScheduleManager _workScheduleManager;

//        public WorkScheduleController(IWorkScheduleManager workScheduleManager)
//        {
//            _workScheduleManager = workScheduleManager;
//        }

//        [HttpPost("add")]
//        public IActionResult AddWorkSchedule([FromBody] AddWorkScheduleDTO dto)
//        {
//            try
//            {
//                var workSchedule = _workScheduleManager.AddWorkSchedule(dto.WorkDay, dto.AvailableSlots);
//                return Ok(workSchedule); 
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpGet("{id}")]
//        public IActionResult GetWorkSchedule(int id)
//        {
//            var workSchedule = _workScheduleManager.GetWorkScheduleById(id);
//            if (workSchedule != null)
//            {
//                return Ok(workSchedule);
//            }
//            return NotFound("Work schedule not found.");
//        }
//    }
//}
