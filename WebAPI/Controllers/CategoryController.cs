using Business.Abstarct;
using Entities.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _env;

        public CategoryController(ICategoryService categoryService, IWebHostEnvironment env)
        {
            _categoryService = categoryService;
            _env = env;
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CategoryAddDTO categoryAddDTO)
        {
            var result = await _categoryService.AddCategoryByLanguageAsync(categoryAddDTO, _env.WebRootPath);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet]
        public IActionResult GetCategories(string langCode)
        {
            var result = _categoryService.GetAllCategoriesAdmin(langCode);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpPost("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(IFormFile Image, CategoryAdminDetailDTO categoryEditDTO)
        {
            var result = await _categoryService.UpdateCategoryByLanguageAsync(categoryEditDTO, Image, _env.WebRootPath);
            return Ok(result);
        }

        //[HttpPost("uploadimage")]
        //public async Task<IActionResult> UploadImageAsync(IFormFile Image)
        //{
        //    var filePath = Path.Combine(_env.WebRootPath, "uploads").ToLower();
        //    if (!Directory.Exists(filePath))
        //    {
        //        Directory.CreateDirectory(filePath);
        //    }
        //    string path = "/uploads/" + Guid.NewGuid() + Image.FileName;
        //    using (var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create))
        //    {
        //        await Image.CopyToAsync(fileStream);
        //    }
        //    return Ok(new { status = 200, message = path });
        //}


        //[HttpPost("uploadimages")]
        //public async Task<IActionResult> UploadImagesAsync(IFormFile Image)
        //{
        //    string path = "/files/" + Guid.NewGuid() + Image.FileName;
        //    using (var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create))
        //    {
        //        await Image.CopyToAsync(fileStream);
        //    }

        //    return Ok(new { status = 200, message = path });
        //}
    }

}
