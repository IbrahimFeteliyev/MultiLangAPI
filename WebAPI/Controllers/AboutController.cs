//using Business.Abstarct;
//using Entities.DTOs.AboutDTOs;
//using Entities.DTOs.CategoryDTOs;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AboutController : ControllerBase
//    {
//        private readonly IAboutService _aboutService;
//        private readonly IWebHostEnvironment _env;

//        public AboutController(IAboutService aboutService, IWebHostEnvironment env)
//        {
//            _aboutService = aboutService;
//            _env = env;
//        }

//        [HttpPost("CreateAbout")]
//        public async Task<IActionResult> CreateAbout(AboutAddDTO about)
//        {
//            var result = await _aboutService.AddAboutByLanguageAsync(about);
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);
//        }

//        [HttpPost("uploadimage")]
//        public async Task<IActionResult> UploadImageAsync(IFormFile Image)
//        {
//            string path = "C:\\CodingProjects\\C#\\API\\WebAPI\\WebAPI\\uploads\\" + Guid.NewGuid() + Image.FileName;
//            using (var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create))
//            {
//                await Image.CopyToAsync(fileStream);
//            }
//            return Ok(new { status = 200, message = path });
//        }
//    }
//}
