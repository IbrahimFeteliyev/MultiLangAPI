using Business.Abstarct;
using Entities.DTOs.CategoryDTOs;
using Entities.DTOs.ShortInfoDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Entities.DTOs.ShortInfoDTOs.ShortInfoDTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortInfoController : ControllerBase
    {
        private readonly IShortInfoService _shortInfoService;

        public ShortInfoController(IShortInfoService shortInfoService)
        {
            _shortInfoService = shortInfoService;
        }


        [HttpGet]
        public IActionResult GetShortInfos(string langCode)
        {
            var result = _shortInfoService.GetAllShortInfosAdmin(langCode);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("CreateShortInfo")]
        public async Task<IActionResult> CreateShortInfo(ShortInfoAddDTO shortInfoAddDTO)
        {
            var result = await _shortInfoService.AddShortInfoByLanguageAsync(shortInfoAddDTO);
            return Ok(result);
        }

        [HttpPut("UpdateShortInfo/{id}")]
        public async Task<IActionResult> UpdateShortInfo(ShortInfoUpdateDTO shortInfoUpdateDTO, int Id)
        {
            var result = await _shortInfoService.UpdateShortInfoByLanguageAsync(shortInfoUpdateDTO, Id);
            return Ok(result);
        }

        [HttpGet("GetShortInfoById/{id}")]
        public IActionResult GetShortInfoById(int id)
        {
            var result = _shortInfoService.GetShortInfoById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpDelete("RemoveShortInfoById/{id}")]
        public IActionResult RemoveShortInfoById(int id)
        {
            var result = _shortInfoService.RemoveShortInfo(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }

}